Imports System.Data
Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class UC_ViewPatrolTeams

    Private bsSecurity As New BindingSource()
    Private dtSecurity As DataTable
    Private errorProv As New ErrorProvider()

    ' =================================================================
    ' 1. INITIALIZATION & UX SETUP
    ' =================================================================
    Private Sub UC_ViewPatrolTeams_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Apply UI Styling (Ensure your external utilities exist)
        RadiusButton(btnDelete, 1.5F)
        DataGridViewHelper.ApplyBeautifulStyle(dgvSecurityPatrolTeam)
        DataGridViewHelper.AdjustDataGridViewRowHeight(dgvSecurityPatrolTeam, 40)

        ' UX GUIDANCE: Setup Tooltips
        Dim patrolToolTip As New ToolTip() With {
            .ToolTipIcon = ToolTipIcon.Info,
            .IsBalloon = True,
            .AutoPopDelay = 5000,
            .InitialDelay = 500
        }
        patrolToolTip.SetToolTip(cmbFilterCampuses, "Filter the grid to show guards from a specific campus.")
        patrolToolTip.SetToolTip(txtSearch, "Type a username or full name to filter results instantly.")
        patrolToolTip.SetToolTip(btnDelete, "Permanently remove a security guard. (Blocked if they have incident history).")
        patrolToolTip.SetToolTip(dgvSecurityPatrolTeam, "Double-click a row to update a guard's name or transfer them to another campus.")

        errorProv.BlinkStyle = ErrorBlinkStyle.NeverBlink

        LoadCampusesFilter()
        LoadSecurityData()
    End Sub

    ' =================================================================
    ' 2. DATABASE SYNC & RELATIONAL QUERIES
    ' =================================================================
    Private Sub LoadCampusesFilter()
        Dim query As String = "SELECT campus_id, campus_name FROM campuses ORDER BY campus_name ASC"
        Dim dtCampuses As New DataTable()

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dtCampuses)
                    End Using
                End Using
            End Using

            ' Insert an "All Campuses" option at the top of the DataTable
            Dim dr As DataRow = dtCampuses.NewRow()
            dr("campus_id") = 0
            dr("campus_name") = "-- All Campuses --"
            dtCampuses.Rows.InsertAt(dr, 0)

            cmbFilterCampuses.DataSource = dtCampuses
            cmbFilterCampuses.DisplayMember = "campus_name"
            cmbFilterCampuses.ValueMember = "campus_id"
            cmbFilterCampuses.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show($"Failed to load campus filters: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSecurityData()
        ' Perform a JOIN to get the human-readable campus name, but keep the IDs hidden for updates
        Dim query As String = "SELECT u.user_id AS 'ID', u.username AS 'Username', u.full_name AS 'Full Name', " &
                              "c.campus_name AS 'Campus', u.campus_id AS 'CampusID' " &
                              "FROM users u " &
                              "LEFT JOIN campuses c ON u.campus_id = c.campus_id " &
                              "WHERE u.role = 'SECURITY' " &
                              "ORDER BY u.full_name ASC"

        dtSecurity = New DataTable()

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dtSecurity)
                    End Using
                End Using
            End Using

            bsSecurity.DataSource = dtSecurity
            dgvSecurityPatrolTeam.DataSource = bsSecurity

            ' Hide system ID columns from the user
            If dgvSecurityPatrolTeam.Columns.Contains("ID") Then dgvSecurityPatrolTeam.Columns("ID").Visible = False
            If dgvSecurityPatrolTeam.Columns.Contains("CampusID") Then dgvSecurityPatrolTeam.Columns("CampusID").Visible = False

            dgvSecurityPatrolTeam.ClearSelection()

        Catch ex As Exception
            MessageBox.Show($"Failed to load patrol teams: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =================================================================
    ' 3. DUAL-DIMENSIONAL LIVE FILTERING
    ' =================================================================
    Private Sub ApplyFilters()
        If bsSecurity.DataSource Is Nothing Then Return

        Dim filterParts As New List(Of String)()

        ' 1. Text Search Filter
        Dim searchText As String = txtSearch.Text.Trim().Replace("'", "''")
        If Not String.IsNullOrEmpty(searchText) Then
            filterParts.Add($"([Username] LIKE '%{searchText}%' OR [Full Name] LIKE '%{searchText}%')")
        End If

        ' 2. Campus Dropdown Filter
        If cmbFilterCampuses.SelectedIndex > 0 Then ' Ignore the "-- All Campuses --" option
            Dim campusId As Integer = Convert.ToInt32(cmbFilterCampuses.SelectedValue)
            filterParts.Add($"[CampusID] = {campusId}")
        End If

        ' Apply combined filter to memory
        If filterParts.Count > 0 Then
            bsSecurity.Filter = String.Join(" AND ", filterParts)
        Else
            bsSecurity.Filter = ""
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilters()
    End Sub

    Private Sub cmbFilterCampuses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterCampuses.SelectedIndexChanged
        ApplyFilters()
    End Sub

    ' =================================================================
    ' 4. DELETE LOGIC (AUDIT TRAIL DEFENSE)
    ' =================================================================
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvSecurityPatrolTeam.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a security guard to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvSecurityPatrolTeam.SelectedRows(0)

        If selectedRow.IsNewRow OrElse selectedRow.Cells("ID").Value Is Nothing OrElse IsDBNull(selectedRow.Cells("ID").Value) Then
            MessageBox.Show("Invalid selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim userId As Integer = Convert.ToInt32(selectedRow.Cells("ID").Value)
        Dim username As String = selectedRow.Cells("Username").Value.ToString()

        If MessageBox.Show($"Are you sure you want to permanently delete guard '{username}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Using conn As MySqlConnection = Database.CreateOpenConnection()
                    Dim cmd As New MySqlCommand("DELETE FROM users WHERE user_id = @id AND role = 'SECURITY'", conn)
                    cmd.Parameters.AddWithValue("@id", userId)
                    cmd.ExecuteNonQuery()
                End Using
                LoadSecurityData() ' Refresh Grid
            Catch ex As Exception
                MessageBox.Show($"Cannot delete this user. They are likely tied to existing incident reports or assignments. {vbCrLf}System Message: {ex.Message}", "Foreign Key Restriction", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' =================================================================
    ' 5. EDIT LOGIC (DYNAMIC DIALOG)
    ' =================================================================
    ' =================================================================
    ' CRYPTOGRAPHY (Ensure this exists in your UC_ViewPatrolTeams class)
    ' =================================================================
    Private Function HashPassword(password As String) As String
        Using sha256 As System.Security.Cryptography.SHA256 = System.Security.Cryptography.SHA256.Create()
            Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(password)
            Dim hashBytes As Byte() = sha256.ComputeHash(bytes)
            Return Convert.ToBase64String(hashBytes)
        End Using
    End Function

    ' =================================================================
    ' EDIT LOGIC (DYNAMIC DIALOG WITH CONDITIONAL PASSWORD RESET)
    ' =================================================================
    Private Sub dgvSecurityPatrolTeam_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSecurityPatrolTeam.CellDoubleClick
        ' DEFENSIVE GUARD: Ignore header clicks or empty new rows
        If e.RowIndex < 0 OrElse dgvSecurityPatrolTeam.Rows(e.RowIndex).IsNewRow Then Return

        Dim selectedRow As DataGridViewRow = dgvSecurityPatrolTeam.Rows(e.RowIndex)
        If selectedRow.Cells("ID").Value Is Nothing OrElse IsDBNull(selectedRow.Cells("ID").Value) Then Return

        Dim userId As Integer = Convert.ToInt32(selectedRow.Cells("ID").Value)
        Dim oldName As String = selectedRow.Cells("Full Name").Value.ToString()
        Dim username As String = selectedRow.Cells("Username").Value.ToString()
        Dim oldCampusId As Integer = If(IsDBNull(selectedRow.Cells("CampusID").Value), 0, Convert.ToInt32(selectedRow.Cells("CampusID").Value))

        ' Dynamically create the edit dialog (Height increased to fit password)
        Using editForm As New Form() With {
            .Text = $"Edit Patrol: {username}",
            .Size = New Size(350, 310),
            .StartPosition = FormStartPosition.CenterParent,
            .FormBorderStyle = FormBorderStyle.FixedDialog,
            .MaximizeBox = False,
            .MinimizeBox = False
        }
            ' Controls definition
            Dim lblName As New Label() With {.Text = "Full Name:", .Location = New Point(20, 20), .AutoSize = True}
            Dim txtName As New TextBox() With {.Text = oldName, .Location = New Point(20, 40), .Width = 290}

            Dim lblCampus As New Label() With {.Text = "Assign Campus:", .Location = New Point(20, 70), .AutoSize = True}
            Dim cmbCampus As New ComboBox() With {.DropDownStyle = ComboBoxStyle.DropDownList, .Location = New Point(20, 90), .Width = 290}

            ' Clone the campus list from the filter box, but remove the "-- All Campuses --" option
            Dim dtDialogCampuses As DataTable = CType(cmbFilterCampuses.DataSource, DataTable).Copy()
            If dtDialogCampuses.Rows.Count > 0 AndAlso dtDialogCampuses.Rows(0)("campus_id").ToString() = "0" Then
                dtDialogCampuses.Rows.RemoveAt(0)
            End If

            cmbCampus.DataSource = dtDialogCampuses
            cmbCampus.DisplayMember = "campus_name"
            cmbCampus.ValueMember = "campus_id"
            cmbCampus.SelectedValue = oldCampusId

            ' THE NEW PASSWORD FIELD
            Dim lblPassword As New Label() With {.Text = "New Password (Leave blank to keep current):", .Location = New Point(20, 120), .AutoSize = True}
            Dim txtPassword As New TextBox() With {.Location = New Point(20, 140), .Width = 290}

            Dim btnSave As New Button() With {.Text = "Save Changes", .Location = New Point(110, 190), .Width = 100, .Height = 35}
            Dim btnCancel As New Button() With {.Text = "Cancel", .Location = New Point(215, 190), .Width = 95, .Height = 35}

            editForm.Controls.AddRange(New Control() {lblName, txtName, lblCampus, cmbCampus, lblPassword, txtPassword, btnSave, btnCancel})
            editForm.AcceptButton = btnSave
            editForm.CancelButton = btnCancel

            AddHandler btnCancel.Click, Sub() editForm.DialogResult = DialogResult.Cancel
            AddHandler btnSave.Click, Sub()
                                          Dim validRegex As New Regex("^[a-zA-Z\s\-]+$")
                                          If Not validRegex.IsMatch(txtName.Text.Trim()) Then
                                              MessageBox.Show("Name must contain only letters, spaces, and hyphens.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                              Return
                                          End If

                                          ' Validate password length only if the admin actually typed something
                                          If txtPassword.Text.Trim().Length > 0 AndAlso txtPassword.Text.Trim().Length < 4 Then
                                              MessageBox.Show("If changing the password, it must be at least 4 characters long.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                              Return
                                          End If

                                          editForm.DialogResult = DialogResult.OK
                                      End Sub

            If editForm.ShowDialog() = DialogResult.OK Then
                Dim newName As String = txtName.Text.Trim()
                Dim newCampusId As Integer = Convert.ToInt32(cmbCampus.SelectedValue)
                Dim newPassword As String = txtPassword.Text.Trim()

                ' Skip database hit if absolutely nothing was changed
                If newName.Equals(oldName, StringComparison.OrdinalIgnoreCase) AndAlso newCampusId = oldCampusId AndAlso String.IsNullOrEmpty(newPassword) Then Return

                Try
                    Using conn As MySqlConnection = Database.CreateOpenConnection()
                        Dim updateCmd As New MySqlCommand()
                        updateCmd.Connection = conn

                        ' DYNAMIC SQL: Only overwrite the password if the Admin provided a new one
                        If String.IsNullOrEmpty(newPassword) Then
                            updateCmd.CommandText = "UPDATE users SET full_name = @name, campus_id = @campus WHERE user_id = @id AND role = 'SECURITY'"
                        Else
                            updateCmd.CommandText = "UPDATE users SET full_name = @name, campus_id = @campus, password_hash = @hash WHERE user_id = @id AND role = 'SECURITY'"
                            updateCmd.Parameters.AddWithValue("@hash", HashPassword(newPassword))
                        End If

                        updateCmd.Parameters.AddWithValue("@name", newName)
                        updateCmd.Parameters.AddWithValue("@campus", newCampusId)
                        updateCmd.Parameters.AddWithValue("@id", userId)
                        updateCmd.ExecuteNonQuery()
                    End Using

                    LoadSecurityData()

                    If Not String.IsNullOrEmpty(newPassword) Then
                        MessageBox.Show($"Profile updated and password reset successfully for {username}.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Catch ex As Exception
                    MessageBox.Show($"Update failed: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub
End Class