Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class UC_HandleIncidence

    ' THE LEASH: Prevent database misfires during UI startup
    Private isInitializing As Boolean = True

    ' =================================================================
    ' 1. INITIALIZATION & UX SETUP
    ' =================================================================
    Private Sub UC_HandleIncidence_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pbxImageEvidence.SizeMode = PictureBoxSizeMode.Zoom

        ' UI ToolTips
        Dim handleToolTip As New ToolTip() With {
            .ToolTipIcon = ToolTipIcon.Info,
            .IsBalloon = True,
            .AutoPopDelay = 5000,
            .InitialDelay = 500
        }

        handleToolTip.SetToolTip(cmbUserName, "Select an active incident currently assigned to you.")
        handleToolTip.SetToolTip(cmbTaskStatus, "Update the current progress of this task.")
        handleToolTip.SetToolTip(btnInitiate, "Commit your status update and notify the administration.")

        LoadTaskStatuses()

        isInitializing = False
        LoadAssignedTasks()
    End Sub

    ' =================================================================
    ' 2. FILTER & DATA LOADERS
    ' =================================================================
    Private Sub LoadTaskStatuses()
        ' Security should only push tasks forward, not backwards to PENDING
        cmbTaskStatus.Items.Clear()
        cmbTaskStatus.Items.AddRange(New String() {"IN_PROGRESS", "RESOLVED", "FALSE_ALARM"})
        cmbTaskStatus.SelectedIndex = -1
    End Sub

    Private Sub LoadAssignedTasks()
        ' TENANT ISOLATION: The security guard ONLY sees tasks assigned to them 
        ' that have not yet been resolved or closed.
        Dim query As String = "SELECT i.incident_id, CONCAT(i.incident_reference, ' - ', u.username) AS display_name " &
                              "FROM incidents i " &
                              "INNER JOIN incident_assignments ia ON i.incident_id = ia.incident_id " &
                              "INNER JOIN users u ON i.reported_by_user_id = u.user_id " &
                              "WHERE ia.assigned_to_user_id = @userId " &
                              "AND i.current_status IN ('ASSIGNED', 'IN_PROGRESS') " &
                              "ORDER BY i.reported_at ASC"

        Dim dt As New DataTable()

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", Session.CurrentUserId)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            ' Unwire event temporarily to prevent misfires during binding
            RemoveHandler cmbUserName.SelectedIndexChanged, AddressOf cmbUserName_SelectedIndexChanged

            cmbUserName.DisplayMember = "display_name"
            cmbUserName.ValueMember = "incident_id"
            cmbUserName.DataSource = dt
            cmbUserName.SelectedIndex = -1

            AddHandler cmbUserName.SelectedIndexChanged, AddressOf cmbUserName_SelectedIndexChanged

            ClearIncidentDetails()

        Catch ex As Exception
            MessageBox.Show($"Failed to load assignments: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =================================================================
    ' 3. INCIDENT DETAIL EXTRACTION
    ' =================================================================
    Private Sub cmbUserName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUserName.SelectedIndexChanged
        If isInitializing OrElse cmbUserName.SelectedIndex = -1 Then Return

        Dim incidentId As Integer = Convert.ToInt32(cmbUserName.SelectedValue)

        Dim query As String = "SELECT i.incident_title, i.incident_description, i.incident_location, i.evidence_image_path, " &
                              "c.category_name, u.full_name AS student_name, cam.campus_name AS student_campus " &
                              "FROM incidents i " &
                              "INNER JOIN incident_categories c ON i.category_id = c.category_id " &
                              "INNER JOIN users u ON i.reported_by_user_id = u.user_id " &
                              "INNER JOIN campuses cam ON u.campus_id = cam.campus_id " &
                              "WHERE i.incident_id = @id"

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", incidentId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lblFullName.Text = reader("student_name").ToString()
                            lblStudentLocation.Text = reader("student_campus").ToString()
                            txtTitle.Text = reader("incident_title").ToString()
                            txtDescription.Text = reader("incident_description").ToString()
                            txtIncidentLocation.Text = reader("incident_location").ToString()
                            lblCategory.Text = reader("category_name").ToString()

                            ' Safely extract visual evidence without crashing on missing files
                            Dim imgPath As String = reader("evidence_image_path").ToString()
                            If Not String.IsNullOrEmpty(imgPath) Then
                                Dim fullPath As String = Path.Combine(Application.StartupPath, "IncidentEvidence", imgPath)
                                If File.Exists(fullPath) Then
                                    pbxImageEvidence.Image = Image.FromFile(fullPath)
                                Else
                                    pbxImageEvidence.Image = Nothing
                                End If
                            Else
                                pbxImageEvidence.Image = Nothing
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Failed to load details: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearIncidentDetails()
        lblFullName.Text = "---"
        lblStudentLocation.Text = "---"
        txtTitle.Clear()
        txtDescription.Clear()
        txtIncidentLocation.Clear()
        lblCategory.Text = "---"
        pbxImageEvidence.Image = Nothing
        cmbTaskStatus.SelectedIndex = -1
    End Sub

    ' =================================================================
    ' 4. SECURE TRANSACTION COMMITS
    ' =================================================================
    Private Sub btnInitiate_Click(sender As Object, e As EventArgs) Handles btnInitiate.Click
        If cmbUserName.SelectedIndex = -1 Then
            MessageBox.Show("Select an incident to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If cmbTaskStatus.SelectedIndex = -1 Then
            MessageBox.Show("Select a new task status.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim incidentId As Integer = Convert.ToInt32(cmbUserName.SelectedValue)
        Dim newStatus As String = cmbTaskStatus.SelectedItem.ToString()
        Dim previousStatus As String = ""

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()

                ' First, grab the exact current status to preserve accurate audit logs
                Dim getStatusQuery As String = "SELECT current_status FROM incidents WHERE incident_id = @incId"
                Using cmdStatus As New MySqlCommand(getStatusQuery, conn)
                    cmdStatus.Parameters.AddWithValue("@incId", incidentId)
                    previousStatus = cmdStatus.ExecuteScalar().ToString()
                End Using

                If previousStatus = newStatus Then
                    MessageBox.Show("The task is already set to this status.", "No Action Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                ' Begin SQL Transaction to guarantee database integrity
                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        ' 1. Update the core incident record
                        Dim qUpdate As String = "UPDATE incidents SET current_status = @newStatus WHERE incident_id = @incId"
                        Using cmdUpdate As New MySqlCommand(qUpdate, conn, transaction)
                            cmdUpdate.Parameters.AddWithValue("@newStatus", newStatus)
                            cmdUpdate.Parameters.AddWithValue("@incId", incidentId)
                            cmdUpdate.ExecuteNonQuery()
                        End Using

                        ' 2. Log the exact change into the historical audit trail
                        Dim qHistory As String = "INSERT INTO incident_status_history (incident_id, changed_by_user_id, previous_status, new_status, change_reason) " &
                                                 "VALUES (@incId, @userId, @prevStatus, @newStatus, 'Security Patrol updated task progress.')"
                        Using cmdHistory As New MySqlCommand(qHistory, conn, transaction)
                            cmdHistory.Parameters.AddWithValue("@incId", incidentId)
                            cmdHistory.Parameters.AddWithValue("@userId", Session.CurrentUserId)
                            cmdHistory.Parameters.AddWithValue("@prevStatus", previousStatus)
                            cmdHistory.Parameters.AddWithValue("@newStatus", newStatus)
                            cmdHistory.ExecuteNonQuery()
                        End Using

                        ' Commit Transaction
                        transaction.Commit()
                        MessageBox.Show("Task status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' ARCHITECTURE LINKAGE: Force the parent dashboard to recalculate its notification count immediately
                        If TypeOf Me.ParentForm Is SecurityPatrolDashboard Then
                            DirectCast(Me.ParentForm, SecurityPatrolDashboard).UpdatePendingTaskCount()
                        End If

                        ' Refresh the active task list. 
                        ' If they chose 'RESOLVED', this will drop the incident from their combobox so they can move to the next task.
                        LoadAssignedTasks()

                    Catch ex As Exception
                        transaction.Rollback()
                        Throw New Exception("Transaction failed: " & ex.Message)
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PanelInputBundle_Paint(sender As Object, e As PaintEventArgs) Handles PanelInputBundle.Paint

    End Sub
End Class