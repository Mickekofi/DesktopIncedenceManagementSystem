Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class UC_History

    ' THE LEASH
    Private isInitializing As Boolean = True

    ' =================================================================
    ' 1. INITIALIZATION & UX SETUP
    ' =================================================================
    Private Sub UC_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Format the Grid
        SetupGrid()

        ' 2. Load the dropdown data
        LoadFilters()

        ' 3. Release the leash and load the default view (Last 7 Days)
        isInitializing = False
        btnSearch.PerformClick()
    End Sub

    Private Sub SetupGrid()
        dgvHistory.AutoGenerateColumns = False
        dgvHistory.AllowUserToAddRows = False
        dgvHistory.AllowUserToDeleteRows = False
        dgvHistory.ReadOnly = True
        dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvHistory.RowHeadersVisible = False

        ' Define Columns Explicitly
        dgvHistory.Columns.Clear()

        dgvHistory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colDate", .DataPropertyName = "change_date", .HeaderText = "Date & Time", .FillWeight = 20
        })
        dgvHistory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colRef", .DataPropertyName = "incident_reference", .HeaderText = "Reference ID", .FillWeight = 15
        })
        dgvHistory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colTitle", .DataPropertyName = "incident_title", .HeaderText = "Incident Title", .FillWeight = 30
        })
        dgvHistory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colChangedBy", .DataPropertyName = "changer_name", .HeaderText = "Action By", .FillWeight = 20
        })
        dgvHistory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colAction", .DataPropertyName = "action_taken", .HeaderText = "Status Change", .FillWeight = 20
        })

        ' Tap the UI Helper
        DataGridViewHelper.ApplyBeautifulStyle(dgvHistory)
        DataGridViewHelper.AdjustDataGridViewRowHeight(dgvHistory, 40)
    End Sub

    ' =================================================================
    ' 2. FILTER LOADERS
    ' =================================================================
    Private Sub LoadFilters()
        ' Date Range Filter
        cmbDateRange.Items.Clear()
        cmbDateRange.Items.AddRange(New String() {"Today", "Last 7 Days", "Last 30 Days", "All Time"})
        cmbDateRange.SelectedIndex = 1 ' Default to Last 7 Days for performance

        ' Status Filter
        cmbStatusFilter.Items.Clear()
        cmbStatusFilter.Items.AddRange(New String() {"ALL", "PENDING", "ASSIGNED", "IN_PROGRESS", "RESOLVED", "CLOSED", "REJECTED"})
        cmbStatusFilter.SelectedIndex = 0 ' Default to ALL
    End Sub

    ' =================================================================
    ' 3. THE ENTERPRISE AUDIT QUERY
    ' =================================================================
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If isInitializing Then Return

        ' THE MASTERPIECE QUERY: 
        ' We do not just query incidents. We query the HISTORY table and join it back to 
        ' the incidents and the users so we have a full human-readable audit trail.
        Dim query As String = "SELECT h.created_at AS change_date, i.incident_reference, i.incident_title, " &
                              "u.full_name AS changer_name, " &
                              "CONCAT(h.previous_status, ' ➔ ', h.new_status) AS action_taken " &
                              "FROM incident_status_history h " &
                              "INNER JOIN incidents i ON h.incident_id = i.incident_id " &
                              "INNER JOIN users u ON h.changed_by_user_id = u.user_id " &
                              "WHERE 1=1 "

        ' 1. Apply Date Filter
        Dim dateFilter As String = cmbDateRange.SelectedItem.ToString()
        If dateFilter = "Today" Then
            query &= " AND DATE(h.created_at) = CURDATE() "
        ElseIf dateFilter = "Last 7 Days" Then
            query &= " AND h.created_at >= DATE_SUB(CURDATE(), INTERVAL 7 DAY) "
        ElseIf dateFilter = "Last 30 Days" Then
            query &= " AND h.created_at >= DATE_SUB(CURDATE(), INTERVAL 30 DAY) "
        End If

        ' 2. Apply Status Filter
        If cmbStatusFilter.SelectedItem IsNot Nothing AndAlso cmbStatusFilter.SelectedItem.ToString() <> "ALL" Then
            ' We check the NEW status in the history log to see if it matches what we are searching for
            query &= $" AND h.new_status = '{cmbStatusFilter.SelectedItem.ToString()}' "
        End If

        query &= " ORDER BY h.created_at DESC"

        Dim dt As New DataTable()
        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            dgvHistory.DataSource = dt
            dgvHistory.ClearSelection()

            ' Provide feedback on row count
            If dt.Rows.Count = 0 Then
                ' Assuming you have a label named lblRecordCount
                ' lblRecordCount.Text = "No records found for the selected criteria."
            End If

        Catch ex As Exception
            MessageBox.Show($"Failed to load audit history: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class