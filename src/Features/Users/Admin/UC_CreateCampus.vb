Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing

Public Class UC_CreateCampus

    Private bsCampuses As New BindingSource()
    Private dtCampuses As DataTable
    Private errorProv As New ErrorProvider()

    ' =================================================================
    ' 1. INITIALIZATION & UX SETUP
    ' =================================================================
    Private Sub UC_CreateCampus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Apply styling
        RadiusButton(btnAddCampus, 1.5F)
        RadiusButton(btnDeleteCampus, 1.5F)
        DataGridViewHelper.ApplyBeautifulStyle(dgvCampuses)
        DataGridViewHelper.AdjustDataGridViewRowHeight(dgvCampuses, 40)

        ' UX GUIDANCE: Setup Tooltips
        Dim campusToolTip As New ToolTip() With {
            .ToolTipIcon = ToolTipIcon.Info,
            .IsBalloon = True,
            .AutoPopDelay = 5000,
            .InitialDelay = 500
        }
        campusToolTip.SetToolTip(txtCampusName, "Enter the official name of the campus (e.g., North Campus). Only letters, spaces, and hyphens allowed.")
        campusToolTip.SetToolTip(btnAddCampus, "Validate and save the new campus to the system.")
        campusToolTip.SetToolTip(dgvCampuses, "Double-click any row to edit the campus name.")
        campusToolTip.SetToolTip(btnDeleteCampus, "Select a campus and click to remove it from the system. This action is irreversible.")

        ' Configure ErrorProvider
        errorProv.BlinkStyle = ErrorBlinkStyle.NeverBlink

        LoadCampusesFromDatabase()
    End Sub

    ' =================================================================
    ' 2. DATABASE SYNC (THE SOURCE OF TRUTH)
    ' =================================================================
    Private Sub LoadCampusesFromDatabase()
        Dim query As String = "SELECT campus_id AS 'ID', campus_code AS 'Campus Code', campus_name AS 'Campus Name' FROM campuses ORDER BY campus_name ASC"
        dtCampuses = New DataTable()

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dtCampuses)
                    End Using
                End Using
            End Using

            bsCampuses.DataSource = dtCampuses
            dgvCampuses.DataSource = bsCampuses

            ' Hide the internal database ID from the users
            If dgvCampuses.Columns.Contains("ID") Then
                dgvCampuses.Columns("ID").Visible = False
            End If

            dgvCampuses.ClearSelection()

        Catch ex As Exception
            MessageBox.Show($"Failed to load campuses: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =================================================================
    ' 3. INSERT LOGIC (VALIDATION & DUPLICATE PREVENTION)
    ' =================================================================
    Private Sub btnAddCampus_Click(sender As Object, e As EventArgs) Handles btnAddCampus.Click
        errorProv.Clear()
        Dim campusName As String = txtCampusName.Text.Trim()

        ' 1. REGEX VALIDATION: Prevent SQL injection via bad characters and enforce clean names
        Dim validNameRegex As New Regex("^[a-zA-Z\s\-]+$")
        If String.IsNullOrEmpty(campusName) OrElse Not validNameRegex.IsMatch(campusName) Then
            errorProv.SetError(txtCampusName, "Invalid format. Use only letters, spaces, and hyphens.")
            MessageBox.Show("Please enter a valid campus name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCampusName.Focus()
            Return
        End If

        ' Disable UI during database operation
        btnAddCampus.Enabled = False

        ' THE FIX: Declare generatedCode outside the Try/Using blocks so it stays in memory
        Dim generatedCode As String = ""

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()

                ' 2. DUPLICATE CHECK: Never trust the UI, ask the database
                Dim checkQuery As String = "SELECT COUNT(*) FROM campuses WHERE LOWER(campus_name) = @name"
                Using checkCmd As New MySqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@name", campusName.ToLower())
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show($"The campus '{campusName}' already exists in the system.", "Duplicate Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        btnAddCampus.Enabled = True
                        Return
                    End If
                End Using

                ' 3. GENERATE CAMPUS CODE (Format: CMP-XXXX)
                generatedCode = "CMP-" & Guid.NewGuid().ToString().Substring(0, 4).ToUpper()

                ' 4. INSERT INTO DATABASE
                Dim insertQuery As String = "INSERT INTO campuses (campus_code, campus_name) VALUES (@code, @name)"
                Using insertCmd As New MySqlCommand(insertQuery, conn)
                    insertCmd.Parameters.AddWithValue("@code", generatedCode)
                    insertCmd.Parameters.AddWithValue("@name", campusName)
                    insertCmd.ExecuteNonQuery()
                End Using
            End Using

            ' Success: Clear input and refresh grid. generatedCode is safely in scope here.
            txtCampusName.Clear()
            MessageBox.Show($"Campus '{campusName}' successfully added with code {generatedCode}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadCampusesFromDatabase()

        Catch ex As Exception
            MessageBox.Show($"Failed to add campus: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnAddCampus.Enabled = True
        End Try
    End Sub


    'btnDeleteCampus_Click: Handles the deletion of a selected campus with confirmation and error handling
    Private Sub btnDeleteCampus_Click(sender As Object, e As EventArgs) Handles btnDeleteCampus.Click


        ' Ensure a row is selected
        If dgvCampuses.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a campus to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If



        Dim selectedRow As DataGridViewRow = dgvCampuses.SelectedRows(0)


        ' Defensive check for nulls before conversion
        If selectedRow.Cells("ID").Value Is Nothing OrElse IsDBNull(selectedRow.Cells("ID").Value) Then
            MessageBox.Show("Selected campus data is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim campusId As Integer = Convert.ToInt32(selectedRow.Cells("ID").Value)
        Dim campusName As String = selectedRow.Cells("Campus Name").Value.ToString()
        ' Confirm deletion with the user
        Dim confirmResult As DialogResult = MessageBox.Show($"Are you sure you want to delete the campus '{campusName}'?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirmResult = DialogResult.Yes Then
            Try
                Using conn As MySqlConnection = Database.CreateOpenConnection()
                    Dim deleteQuery As String = "DELETE FROM campuses WHERE campus_id = @id"
                    Using deleteCmd As New MySqlCommand(deleteQuery, conn)
                        deleteCmd.Parameters.AddWithValue("@id", campusId)
                        deleteCmd.ExecuteNonQuery()
                    End Using
                End Using
                MessageBox.Show($"Campus '{campusName}' has been deleted.", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadCampusesFromDatabase()
            Catch ex As Exception
                MessageBox.Show($"Failed to delete campus: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub



    ' =================================================================
    ' 4. EDIT LOGIC (DEFENSIVE ROW HANDLING)
    ' =================================================================
    Private Sub dgvCampuses_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCampuses.CellDoubleClick
        ' DEFENSIVE GUARD: Ensure user didn't click the header or the empty new row
        If e.RowIndex < 0 OrElse dgvCampuses.Rows(e.RowIndex).IsNewRow Then Return

        Dim selectedRow As DataGridViewRow = dgvCampuses.Rows(e.RowIndex)

        ' Defensive check for nulls before conversion
        If selectedRow.Cells("ID").Value Is Nothing OrElse IsDBNull(selectedRow.Cells("ID").Value) Then Return

        Dim campusId As Integer = Convert.ToInt32(selectedRow.Cells("ID").Value)
        Dim oldName As String = selectedRow.Cells("Campus Name").Value.ToString()
        Dim campusCode As String = selectedRow.Cells("Campus Code").Value.ToString()

        ' Dynamically create a clean, focused edit dialog
        Using editForm As New Form() With {
            .Text = $"Edit Campus: {campusCode}",
            .Size = New Size(350, 200),
            .StartPosition = FormStartPosition.CenterParent,
            .FormBorderStyle = FormBorderStyle.FixedDialog,
            .MaximizeBox = False,
            .MinimizeBox = False
        }
            Dim lblName As New Label() With {.Text = "Campus Name:", .Location = New Point(20, 20), .AutoSize = True}
            Dim txtName As New TextBox() With {.Text = oldName, .Location = New Point(20, 40), .Width = 290}

            Dim btnSave As New Button() With {.Text = "Save Changes", .Location = New Point(110, 90), .Width = 100, .Height = 35}
            Dim btnCancel As New Button() With {.Text = "Cancel", .Location = New Point(215, 90), .Width = 95, .Height = 35}

            editForm.Controls.AddRange(New Control() {lblName, txtName, btnSave, btnCancel})
            editForm.AcceptButton = btnSave
            editForm.CancelButton = btnCancel

            AddHandler btnCancel.Click, Sub() editForm.DialogResult = DialogResult.Cancel
            AddHandler btnSave.Click, Sub()
                                          Dim validRegex As New Regex("^[a-zA-Z\s\-]+$")
                                          If Not validRegex.IsMatch(txtName.Text.Trim()) Then
                                              MessageBox.Show("Name must contain only letters, spaces, and hyphens.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                              Return
                                          End If
                                          editForm.DialogResult = DialogResult.OK
                                      End Sub

            If editForm.ShowDialog() = DialogResult.OK Then
                Dim newName As String = txtName.Text.Trim()

                ' Skip database hit if the name didn't actually change
                If newName.Equals(oldName, StringComparison.OrdinalIgnoreCase) Then Return

                Try
                    Using conn As MySqlConnection = Database.CreateOpenConnection()
                        ' Ensure the new name isn't taking another campus's name
                        Dim checkCmd As New MySqlCommand("SELECT COUNT(*) FROM campuses WHERE LOWER(campus_name) = @name AND campus_id != @id", conn)
                        checkCmd.Parameters.AddWithValue("@name", newName.ToLower())
                        checkCmd.Parameters.AddWithValue("@id", campusId)

                        If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                            MessageBox.Show("Another campus with that name already exists.", "Duplicate Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If

                        Dim updateCmd As New MySqlCommand("UPDATE campuses SET campus_name = @name WHERE campus_id = @id", conn)
                        updateCmd.Parameters.AddWithValue("@name", newName)
                        updateCmd.Parameters.AddWithValue("@id", campusId)
                        updateCmd.ExecuteNonQuery()
                    End Using
                    LoadCampusesFromDatabase()
                Catch ex As Exception
                    MessageBox.Show($"Update failed: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub






End Class