Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.IO ' CRITICAL: Required for checking if the image file exists on the hard drive

Public Class UC_Notification

    ' THE LEASH: Prevent premature database queries during UI rendering
    Private isInitializing As Boolean = True

    ' =================================================================
    ' 1. INITIALIZATION & UX SETUP
    ' =================================================================
    Private Sub UC_Notification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Format the Grid first using YOUR module
        SetupGrid()

        ' 2. Load the dropdown data
        LoadStatusFilter()
        LoadIncidentFilter()

        ' 3. Release the leash and load the student's data
        isInitializing = False
        LoadTrackingData()
    End Sub

    Private Sub SetupGrid()
        ' Basic Grid configuration
        dgvNotification.AutoGenerateColumns = False
        dgvNotification.AllowUserToAddRows = False
        dgvNotification.AllowUserToDeleteRows = False
        dgvNotification.ReadOnly = True
        dgvNotification.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvNotification.RowHeadersVisible = False

        ' Define Columns Explicitly
        dgvNotification.Columns.Clear()

        dgvNotification.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colRef", .DataPropertyName = "incident_reference", .HeaderText = "Reference ID", .FillWeight = 20
        })
        dgvNotification.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colTitle", .DataPropertyName = "incident_title", .HeaderText = "Incident Title", .FillWeight = 40
        })
        dgvNotification.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colStatus", .DataPropertyName = "current_status", .HeaderText = "Current Status", .FillWeight = 20
        })
        dgvNotification.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colDate", .DataPropertyName = "reported_at", .HeaderText = "Date Reported", .FillWeight = 20
        })

        ' =================================================================
        ' TAPPING YOUR MODULE HERE
        ' =================================================================

        ' 1. Call your module to create the safe image column
        Dim imgCol As DataGridViewImageColumn = DataGridViewHelper.CreatePhotoColumn("Evidence")
        imgCol.DataPropertyName = "EvidenceImage" ' Maps to our compressed memory column, NOT the database string
        imgCol.FillWeight = 20
        dgvNotification.Columns.Add(imgCol)

        ' 2. Call your module to apply the global enterprise styling
        DataGridViewHelper.ApplyBeautifulStyle(dgvNotification)

        ' 3. Call your module to increase row height so the images actually fit
        DataGridViewHelper.AdjustDataGridViewRowHeight(dgvNotification, 80)
    End Sub

    ' =================================================================
    ' 2. FILTER LOADERS
    ' =================================================================
    Private Sub LoadStatusFilter()
        cmbIncidentStatus.Items.Clear()
        cmbIncidentStatus.Items.AddRange(New String() {"ALL", "PENDING", "ASSIGNED", "IN_PROGRESS", "RESOLVED", "CLOSED", "REJECTED"})
        cmbIncidentStatus.SelectedIndex = 0 ' Default to ALL
    End Sub

    Private Sub LoadIncidentFilter()
        ' CRITICAL: Only load the incidents that belong to the logged-in student
        Dim query As String = "SELECT incident_id, CONCAT(incident_reference, ' - ', incident_title) AS display_name " &
                              "FROM incidents WHERE reported_by_user_id = @userId ORDER BY reported_at DESC"

        Dim dt As New DataTable()
        dt.Columns.Add("incident_id", GetType(String))
        dt.Columns.Add("display_name", GetType(String))
        dt.Rows.Add("ALL", "All My Incidents")

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", Session.CurrentUserId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            dt.Rows.Add(reader("incident_id").ToString(), reader("display_name").ToString())
                        End While
                    End Using
                End Using
            End Using

            cmbSelectIncident.DisplayMember = "display_name"
            cmbSelectIncident.ValueMember = "incident_id"
            cmbSelectIncident.DataSource = dt
            cmbSelectIncident.SelectedIndex = 0
        Catch ex As Exception
            ' Fail silently on load to prevent crash loops
        End Try
    End Sub

    ' =================================================================
    ' 3. DYNAMIC DATA TRACKING & MEMORY-SAFE IMAGE LOADING
    ' =================================================================
    Private Sub Filters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbIncidentStatus.SelectedIndexChanged, cmbSelectIncident.SelectedIndexChanged
        If isInitializing Then Return
        LoadTrackingData()
    End Sub

    Private Sub LoadTrackingData()
        ' BASE QUERY: Added evidence_image_path
        Dim query As String = "SELECT incident_reference, incident_title, current_status, reported_at, evidence_image_path " &
                              "FROM incidents WHERE reported_by_user_id = @userId "

        ' Apply Status Filter
        If cmbIncidentStatus.SelectedItem IsNot Nothing AndAlso cmbIncidentStatus.SelectedItem.ToString() <> "ALL" Then
            query &= $" AND current_status = '{cmbIncidentStatus.SelectedItem.ToString()}' "
        End If

        ' Apply Specific Incident Filter
        If cmbSelectIncident.SelectedValue IsNot Nothing AndAlso cmbSelectIncident.SelectedValue.ToString() <> "ALL" Then
            query &= $" AND incident_id = {cmbSelectIncident.SelectedValue} "
        End If

        query &= " ORDER BY reported_at DESC"

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

            ' =========================================================
            ' IMAGE COMPRESSION PIPELINE (Prevents OutOfMemory Crashes)
            ' =========================================================
            dt.Columns.Add("EvidenceImage", GetType(Image))

            For Each row As DataRow In dt.Rows
                Dim imgPath As String = row("evidence_image_path").ToString()

                If Not String.IsNullOrEmpty(imgPath) Then
                    ' Ensure the application looks in the correct relative folder
                    Dim fullPath As String = Path.Combine(Application.StartupPath, "IncidentEvidence", imgPath)

                    If File.Exists(fullPath) Then
                        ' Load the image, crush it down to thumbnail size, and assign it to the row
                        Using sourceImg As Image = Image.FromFile(fullPath)
                            row("EvidenceImage") = New Bitmap(sourceImg, New Size(100, 100))
                        End Using
                    Else
                        row("EvidenceImage") = Nothing
                    End If
                Else
                    row("EvidenceImage") = Nothing
                End If
            Next

            ' Bind the processed data table to the UI
            dgvNotification.DataSource = dt
            dgvNotification.ClearSelection()

        Catch ex As Exception
            MessageBox.Show($"Failed to load tracking data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =================================================================
    ' 4. DEEP DIVE (CELL DOUBLE CLICK)
    ' =================================================================
    Private Sub dgvNotification_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNotification.CellDoubleClick
        If e.RowIndex < 0 Then Return

        Dim refId As String = dgvNotification.Rows(e.RowIndex).Cells("colRef").Value.ToString()
        Dim status As String = dgvNotification.Rows(e.RowIndex).Cells("colStatus").Value.ToString()

        MessageBox.Show($"Incident {refId} is currently {status}. Future update: Bind this to a detailed history timeline.", "Tracking Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class