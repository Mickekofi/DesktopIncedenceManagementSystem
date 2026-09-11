Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text

Public Class UC_IncidentFeeds

    ' THE LEASH: Prevents dropdowns from querying the database while they are still being built in memory.
    Private isInitializing As Boolean = True

    ' =================================================================
    ' 1. INITIALIZATION & UX SETUP
    ' =================================================================
    Private Sub UC_IncidentFeeds_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pbxImageEvidence.SizeMode = PictureBoxSizeMode.Zoom

        ' UI ToolTips
        Dim feedToolTip As New ToolTip() With {
            .ToolTipIcon = ToolTipIcon.Info,
            .IsBalloon = True,
            .AutoPopDelay = 5000,
            .InitialDelay = 500
        }
        feedToolTip.SetToolTip(cmbFilterNewOrOld, "Filter by Incident Status (e.g., PENDING for new ones).")
        feedToolTip.SetToolTip(cmbFilterCategory, "Filter by specific incident categories.")
        feedToolTip.SetToolTip(cmbFilterCampus, "Filter by the campus where the incident occurred.")
        feedToolTip.SetToolTip(cmbUserName, "Select a specific incident report to view details.")
        feedToolTip.SetToolTip(btnAssignSecurity, "Assign the selected patrol officer to this incident.")
        feedToolTip.SetToolTip(btnExport, "Export the currently filtered list of incidents to a CSV file.")

        ' Initialize Filters
        LoadStatusFilter()
        LoadCategoryFilter()
        LoadCampusFilter()

        ' Release the leash. The form is now fully built.
        isInitializing = False

        ' Now it is safe to load the data.
        LoadFilteredIncidents()
    End Sub

    ' =================================================================
    ' 2. FILTER LOADERS
    ' =================================================================
    Private Sub LoadStatusFilter()
        cmbFilterNewOrOld.Items.Clear()
        cmbFilterNewOrOld.Items.AddRange(New String() {"ALL", "PENDING", "ASSIGNED", "IN_PROGRESS", "RESOLVED", "CLOSED", "REJECTED"})
        cmbFilterNewOrOld.SelectedIndex = 1 ' Default to PENDING (New)
    End Sub

    Private Sub LoadCategoryFilter()
        Dim query As String = "SELECT category_id, category_name FROM incident_categories WHERE is_active = TRUE ORDER BY category_name ASC"
        Dim dt As New DataTable()
        dt.Columns.Add("category_id", GetType(String))
        dt.Columns.Add("category_name", GetType(String))
        dt.Rows.Add("ALL", "All Categories")

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            dt.Rows.Add(reader("category_id").ToString(), reader("category_name").ToString())
                        End While
                    End Using
                End Using
            End Using

            cmbFilterCategory.DisplayMember = "category_name"
            cmbFilterCategory.ValueMember = "category_id"
            cmbFilterCategory.DataSource = dt
            cmbFilterCategory.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadCampusFilter()
        Dim query As String = "SELECT campus_id, campus_name FROM campuses WHERE is_active = TRUE ORDER BY campus_name ASC"
        Dim dt As New DataTable()
        dt.Columns.Add("campus_id", GetType(String))
        dt.Columns.Add("campus_name", GetType(String))
        dt.Rows.Add("ALL", "All Campuses")

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            dt.Rows.Add(reader("campus_id").ToString(), reader("campus_name").ToString())
                        End While
                    End Using
                End Using
            End Using

            cmbFilterCampus.DisplayMember = "campus_name"
            cmbFilterCampus.ValueMember = "campus_id"
            cmbFilterCampus.DataSource = dt
            cmbFilterCampus.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    ' =================================================================
    ' 3. DYNAMIC INCIDENT & SECURITY LOADERS
    ' =================================================================

    Private Sub Filters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterNewOrOld.SelectedIndexChanged, cmbFilterCategory.SelectedIndexChanged, cmbFilterCampus.SelectedIndexChanged
        ' DO NOT attempt to filter if the UI is still booting up
        If isInitializing Then Return

        LoadFilteredIncidents()
        LoadSecurityPersonnel()
    End Sub

    Private Sub LoadFilteredIncidents()
        Dim query As String = "SELECT i.incident_id, CONCAT(u.username, ' - ', i.incident_reference) AS display_name " &
                              "FROM incidents i " &
                              "INNER JOIN users u ON i.reported_by_user_id = u.user_id WHERE 1=1 "

        If cmbFilterNewOrOld.SelectedItem IsNot Nothing AndAlso cmbFilterNewOrOld.SelectedItem.ToString() <> "ALL" Then
            query &= $" AND i.current_status = '{cmbFilterNewOrOld.SelectedItem.ToString()}' "
        End If

        If cmbFilterCategory.SelectedValue IsNot Nothing AndAlso cmbFilterCategory.SelectedValue.ToString() <> "ALL" Then
            query &= $" AND i.category_id = {cmbFilterCategory.SelectedValue} "
        End If

        If cmbFilterCampus.SelectedValue IsNot Nothing AndAlso cmbFilterCampus.SelectedValue.ToString() <> "ALL" Then
            query &= $" AND i.campus_id = {cmbFilterCampus.SelectedValue} "
        End If

        Dim dt As New DataTable()
        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            RemoveHandler cmbUserName.SelectedIndexChanged, AddressOf cmbUserName_SelectedIndexChanged

            cmbUserName.DisplayMember = "display_name"
            cmbUserName.ValueMember = "incident_id"
            cmbUserName.DataSource = dt
            cmbUserName.SelectedIndex = -1

            AddHandler cmbUserName.SelectedIndexChanged, AddressOf cmbUserName_SelectedIndexChanged

            ClearIncidentDetails()

        Catch ex As Exception
            MessageBox.Show($"Failed to load incidents: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSecurityPersonnel()
        Dim query As String = "SELECT user_id, full_name FROM users WHERE role = 'SECURITY' AND is_active = TRUE "

        If cmbFilterCampus.SelectedValue IsNot Nothing AndAlso cmbFilterCampus.SelectedValue.ToString() <> "ALL" Then
            query &= $" AND campus_id = {cmbFilterCampus.SelectedValue} "
        End If

        Dim dt As New DataTable()
        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            cmbAssignSecurity.DisplayMember = "full_name"
            cmbAssignSecurity.ValueMember = "user_id"
            cmbAssignSecurity.DataSource = dt
            cmbAssignSecurity.SelectedIndex = -1
        Catch ex As Exception
        End Try
    End Sub

    ' =================================================================
    ' 4. INCIDENT DETAIL DISPLAY
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

                            ' Load Image Safely
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
    End Sub

    ' =================================================================
    ' 5. SECURE ASSIGNMENT TRANSACTION
    ' =================================================================
    Private Sub btnAssignSecurity_Click(sender As Object, e As EventArgs) Handles btnAssignSecurity.Click
        If cmbUserName.SelectedIndex = -1 Then
            MessageBox.Show("Please select an incident to assign.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If cmbAssignSecurity.SelectedIndex = -1 Then
            MessageBox.Show("Please select a security patrol officer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim incidentId As Integer = Convert.ToInt32(cmbUserName.SelectedValue)
        Dim securityId As Integer = Convert.ToInt32(cmbAssignSecurity.SelectedValue)

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()

                ' THE GATEKEEPER CHECK: Ensure the incident hasn't already been assigned by someone else
                Dim checkStatusQuery As String = "SELECT current_status FROM incidents WHERE incident_id = @incId"
                Dim currentStatus As String = ""

                Using cmdCheck As New MySqlCommand(checkStatusQuery, conn)
                    cmdCheck.Parameters.AddWithValue("@incId", incidentId)
                    Dim result = cmdCheck.ExecuteScalar()
                    If result IsNot Nothing Then
                        currentStatus = result.ToString()
                    End If
                End Using

                If currentStatus <> "PENDING" Then
                    MessageBox.Show($"Assignment blocked: This incident cannot be assigned because its status is already '{currentStatus}'.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' Begin SQL Transaction to guarantee all 3 queries succeed or fail together
                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        ' 1. Insert Assignment
                        Dim qAssign As String = "INSERT INTO incident_assignments (incident_id, assigned_by_user_id, assigned_to_user_id) " &
                                                "VALUES (@incId, @adminId, @secId)"
                        Using cmd1 As New MySqlCommand(qAssign, conn, transaction)
                            cmd1.Parameters.AddWithValue("@incId", incidentId)
                            cmd1.Parameters.AddWithValue("@adminId", Session.CurrentUserId)
                            cmd1.Parameters.AddWithValue("@secId", securityId)
                            cmd1.ExecuteNonQuery()
                        End Using

                        ' 2. Update Incident Status
                        Dim qUpdate As String = "UPDATE incidents SET current_status = 'ASSIGNED' WHERE incident_id = @incId"
                        Using cmd2 As New MySqlCommand(qUpdate, conn, transaction)
                            cmd2.Parameters.AddWithValue("@incId", incidentId)
                            cmd2.ExecuteNonQuery()
                        End Using

                        ' 3. Insert Status History Audit Trail
                        Dim qHistory As String = "INSERT INTO incident_status_history (incident_id, changed_by_user_id, previous_status, new_status, change_reason) " &
                                                 "VALUES (@incId, @adminId, 'PENDING', 'ASSIGNED', 'Initial deployment of security patrol.')"
                        Using cmd3 As New MySqlCommand(qHistory, conn, transaction)
                            cmd3.Parameters.AddWithValue("@incId", incidentId)
                            cmd3.Parameters.AddWithValue("@adminId", Session.CurrentUserId)
                            cmd3.ExecuteNonQuery()
                        End Using

                        ' Commit Transaction
                        transaction.Commit()

                        MessageBox.Show("Security assigned successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Update Dashboard Notification Badge (Architecture linkage)
                        If TypeOf Me.ParentForm Is AdminDashboard Then
                            DirectCast(Me.ParentForm, AdminDashboard).UpdatePendingIncidentsCount()
                        End If

                        ' Refresh Feed
                        LoadFilteredIncidents()
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

    ' =================================================================
    ' 6. DATA EXPORT (SMART CSV)
    ' =================================================================
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Using sfd As New SaveFileDialog()
            sfd.Filter = "CSV (Comma delimited)|*.csv"
            sfd.FileName = $"IncidentReport_{DateTime.Now.ToString("yyyyMMdd")}.csv"

            If sfd.ShowDialog() = DialogResult.OK Then
                ' Added incident_description, incident_location, and evidence_image_path
                Dim query As String = "SELECT i.incident_reference, u.username, c.category_name, cam.campus_name, " &
                                      "i.incident_title, i.incident_description, i.incident_location, i.evidence_image_path, " &
                                      "i.current_status, i.reported_at " &
                                      "FROM incidents i " &
                                      "INNER JOIN users u ON i.reported_by_user_id = u.user_id " &
                                      "INNER JOIN incident_categories c ON i.category_id = c.category_id " &
                                      "INNER JOIN campuses cam ON i.campus_id = cam.campus_id WHERE 1=1 "

                If cmbFilterNewOrOld.SelectedItem IsNot Nothing AndAlso cmbFilterNewOrOld.SelectedItem.ToString() <> "ALL" Then
                    query &= $" AND i.current_status = '{cmbFilterNewOrOld.SelectedItem.ToString()}' "
                End If
                If cmbFilterCategory.SelectedValue IsNot Nothing AndAlso cmbFilterCategory.SelectedValue.ToString() <> "ALL" Then
                    query &= $" AND i.category_id = {cmbFilterCategory.SelectedValue} "
                End If
                If cmbFilterCampus.SelectedValue IsNot Nothing AndAlso cmbFilterCampus.SelectedValue.ToString() <> "ALL" Then
                    query &= $" AND i.campus_id = {cmbFilterCampus.SelectedValue} "
                End If

                Try
                    Using conn As MySqlConnection = Database.CreateOpenConnection()
                        Using cmd As New MySqlCommand(query, conn)
                            Using reader As MySqlDataReader = cmd.ExecuteReader()
                                Using sw As New StreamWriter(sfd.FileName, False, Encoding.UTF8)
                                    ' Write Updated Headers
                                    sw.WriteLine("Reference ID,Reporter,Category,Campus,Title,Description,Location,Evidence Attached,Status,Reported Date")

                                    ' Write Data
                                    While reader.Read()
                                        Dim ref As String = reader("incident_reference").ToString().Replace(",", " ")
                                        Dim reporter As String = reader("username").ToString().Replace(",", " ")
                                        Dim cat As String = reader("category_name").ToString().Replace(",", " ")
                                        Dim campus As String = reader("campus_name").ToString().Replace(",", " ")
                                        Dim title As String = reader("incident_title").ToString().Replace(",", " ")

                                        ' Brutal scrubbing to ensure the description does not break CSV rows and columns
                                        Dim desc As String = reader("incident_description").ToString()
                                        desc = desc.Replace(vbCrLf, " ").Replace(vbCr, " ").Replace(vbLf, " ").Replace(",", ";")

                                        Dim location As String = reader("incident_location").ToString().Replace(",", " ")

                                        Dim evidencePath As String = reader("evidence_image_path").ToString()
                                        Dim hasEvidence As String = If(String.IsNullOrEmpty(evidencePath), "NO", "YES")

                                        Dim status As String = reader("current_status").ToString()
                                        Dim rDate As String = Convert.ToDateTime(reader("reported_at")).ToString("yyyy-MM-dd HH:mm")

                                        sw.WriteLine($"{ref},{reporter},{cat},{campus},{title},{desc},{location},{hasEvidence},{status},{rDate}")
                                    End While
                                End Using
                            End Using
                        End Using
                    End Using
                    MessageBox.Show("Detailed export completed successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show($"Export failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub PanelInputBundle_Paint(sender As Object, e As PaintEventArgs) Handles PanelInputBundle.Paint

    End Sub
End Class