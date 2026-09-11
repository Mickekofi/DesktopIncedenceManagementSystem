Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data

Public Class UC_CreateIncidentCat

    Private bsCategories As New BindingSource()
    Private dtCategories As DataTable
    Private errorProv As New ErrorProvider()

    ' =================================================================
    ' 1. INITIALIZATION & UX SETUP
    ' =================================================================
    Private Sub UC_CreateIncidentCat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Apply UI Styling (Ensure your RadiusButton and DataGridViewHelper exist)
        RadiusButton(btnAddCategory, 1.5F)
        RadiusButton(btnDelete, 1.5F)
        DataGridViewHelper.ApplyBeautifulStyle(dgvIncidentCat)
        DataGridViewHelper.AdjustDataGridViewRowHeight(dgvIncidentCat, 40)

        ' UX GUIDANCE: Setup Tooltips
        Dim catToolTip As New ToolTip() With {
            .ToolTipIcon = ToolTipIcon.Info,
            .IsBalloon = True,
            .AutoPopDelay = 5000,
            .InitialDelay = 500
        }
        catToolTip.SetToolTip(txtIncidentCategoryName, "Enter the official category name (e.g., Theft, Vandalism).")
        catToolTip.SetToolTip(cmbIncidentSeverity, "Select the default severity level mapped to this incident type.")
        catToolTip.SetToolTip(btnAddCategory, "Validate and save the new category to the system.")
        catToolTip.SetToolTip(btnDelete, "Permanently delete the selected category from the system.")
        catToolTip.SetToolTip(dgvIncidentCat, "Double-click any row to edit the category details.")

        ' Ensure ErrorProvider doesn't blink annoyingly
        errorProv.BlinkStyle = ErrorBlinkStyle.NeverBlink

        ' Initialize Data
        LoadSeverities(cmbIncidentSeverity)
        LoadCategoriesFromDatabase()
    End Sub

    ' =================================================================
    ' 2. DATABASE SYNC & MEMORY FILTERING
    ' =================================================================
    Private Sub LoadSeverities(cmb As ComboBox)
        cmb.Items.Clear()
        ' Explicitly matching the uppercase ENUMs in your database schema
        cmb.Items.AddRange(New String() {"LOW", "MEDIUM", "HIGH", "CRITICAL"})
        If cmb.Items.Count > 0 Then cmb.SelectedIndex = 0
    End Sub

    Private Sub LoadCategoriesFromDatabase()
        ' Targeting severity_default to match your schema exactly
        Dim query As String = "SELECT category_id AS 'ID', category_name AS 'Category Name', severity_default AS 'Severity' FROM incident_categories ORDER BY category_name ASC"
        dtCategories = New DataTable()

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dtCategories)
                    End Using
                End Using
            End Using

            bsCategories.DataSource = dtCategories
            dgvIncidentCat.DataSource = bsCategories

            ' Hide the internal database ID from the users
            If dgvIncidentCat.Columns.Contains("ID") Then
                dgvIncidentCat.Columns("ID").Visible = False
            End If

            dgvIncidentCat.ClearSelection()

        Catch ex As Exception
            MessageBox.Show($"Failed to load categories: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 🌟 LIVE SEARCH (Memory-based, no database lag)
    ' NOTE: Your prompt said 'cmbSearch'. You must use a TextBox named 'txtSearch' for live typing.
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) ' Handles txtSearch.TextChanged
        If bsCategories.DataSource IsNot Nothing Then
            Dim filterText As String = txtSearch.Text.Trim().Replace("'", "''") ' Escape single quotes to prevent crashes
            If String.IsNullOrEmpty(filterText) Then
                bsCategories.Filter = ""
            Else
                bsCategories.Filter = $"[Category Name] LIKE '%{filterText}%' OR [Severity] LIKE '%{filterText}%'"
            End If
        End If
    End Sub

    ' =================================================================
    ' 3. INSERT LOGIC (VALIDATION & DUPLICATE PREVENTION)
    ' =================================================================
    Private Sub btnAddCategory_Click(sender As Object, e As EventArgs) Handles btnAddCategory.Click
        errorProv.Clear()
        Dim catName As String = txtIncidentCategoryName.Text.Trim()
        Dim severity As String = cmbIncidentSeverity.SelectedItem?.ToString()

        ' 1. REGEX VALIDATION: Prevent SQL injection via bad characters
        Dim validNameRegex As New Regex("^[a-zA-Z0-9\s\-]+$")
        If String.IsNullOrEmpty(catName) OrElse Not validNameRegex.IsMatch(catName) Then
            errorProv.SetError(txtIncidentCategoryName, "Invalid format. Use letters, numbers, spaces, and hyphens.")
            MessageBox.Show("Please enter a valid category name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtIncidentCategoryName.Focus()
            Return
        End If

        If String.IsNullOrEmpty(severity) Then
            errorProv.SetError(cmbIncidentSeverity, "Please select a severity.")
            Return
        End If

        ' Disable UI during database operation
        btnAddCategory.Enabled = False

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()

                ' 2. DUPLICATE CHECK: Never trust the UI, ask the database
                Dim checkQuery As String = "SELECT COUNT(*) FROM incident_categories WHERE LOWER(category_name) = @name"
                Using checkCmd As New MySqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@name", catName.ToLower())
                    If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show($"The category '{catName}' already exists.", "Duplicate Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        btnAddCategory.Enabled = True
                        Return
                    End If
                End Using

                ' 3. INSERT INTO DATABASE (Targeting severity_default)
                Dim insertQuery As String = "INSERT INTO incident_categories (category_name, severity_default) VALUES (@name, @severity)"
                Using insertCmd As New MySqlCommand(insertQuery, conn)
                    insertCmd.Parameters.AddWithValue("@name", catName)
                    insertCmd.Parameters.AddWithValue("@severity", severity)
                    insertCmd.ExecuteNonQuery()
                End Using
            End Using

            ' Success: Clear input and refresh grid
            txtIncidentCategoryName.Clear()
            LoadCategoriesFromDatabase()

        Catch ex As Exception
            MessageBox.Show($"Failed to add category: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnAddCategory.Enabled = True
        End Try
    End Sub

    ' =================================================================
    ' 4. DELETE LOGIC (DEFENSIVE ROW HANDLING)
    ' =================================================================
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvIncidentCat.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a category to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvIncidentCat.SelectedRows(0)

        ' DEFENSIVE GUARD: Ensure user didn't select an empty or invalid row
        If selectedRow.IsNewRow OrElse selectedRow.Cells("ID").Value Is Nothing OrElse IsDBNull(selectedRow.Cells("ID").Value) Then
            MessageBox.Show("Invalid selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim catId As Integer = Convert.ToInt32(selectedRow.Cells("ID").Value)
        Dim catName As String = selectedRow.Cells("Category Name").Value.ToString()

        If MessageBox.Show($"Are you sure you want to permanently delete '{catName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Using conn As MySqlConnection = Database.CreateOpenConnection()
                    Dim cmd As New MySqlCommand("DELETE FROM incident_categories WHERE category_id = @id", conn)
                    cmd.Parameters.AddWithValue("@id", catId)
                    cmd.ExecuteNonQuery()
                End Using
                LoadCategoriesFromDatabase()
            Catch ex As Exception
                ' If incidents are tied to this category, MySQL blocks the deletion via foreign key constraints. 
                ' This is the correct, defensive behavior.
                MessageBox.Show($"Cannot delete category. It may be currently tied to existing incident records. {vbCrLf}{ex.Message}", "Database Restriction", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' =================================================================
    ' 5. EDIT LOGIC (DYNAMIC DIALOG)
    ' =================================================================
    Private Sub dgvIncidentCat_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIncidentCat.CellDoubleClick
        ' DEFENSIVE GUARD: Ensure user didn't click the header or the empty new row
        If e.RowIndex < 0 OrElse dgvIncidentCat.Rows(e.RowIndex).IsNewRow Then Return

        Dim selectedRow As DataGridViewRow = dgvIncidentCat.Rows(e.RowIndex)
        If selectedRow.Cells("ID").Value Is Nothing OrElse IsDBNull(selectedRow.Cells("ID").Value) Then Return

        Dim catId As Integer = Convert.ToInt32(selectedRow.Cells("ID").Value)
        Dim oldName As String = selectedRow.Cells("Category Name").Value.ToString()
        Dim oldSeverity As String = selectedRow.Cells("Severity").Value.ToString()

        ' Dynamically create a clean, focused edit dialog
        Using editForm As New Form() With {
            .Text = "Edit Incident Category",
            .Size = New Size(350, 250),
            .StartPosition = FormStartPosition.CenterParent,
            .FormBorderStyle = FormBorderStyle.FixedDialog,
            .MaximizeBox = False,
            .MinimizeBox = False
        }
            Dim lblName As New Label() With {.Text = "Category Name:", .Location = New Point(20, 20), .AutoSize = True}
            Dim txtName As New TextBox() With {.Text = oldName, .Location = New Point(20, 40), .Width = 290}

            Dim lblSeverity As New Label() With {.Text = "Severity:", .Location = New Point(20, 70), .AutoSize = True}
            Dim cmbSeverity As New ComboBox() With {.DropDownStyle = ComboBoxStyle.DropDownList, .Location = New Point(20, 90), .Width = 290}
            LoadSeverities(cmbSeverity)
            cmbSeverity.SelectedItem = oldSeverity

            Dim btnSave As New Button() With {.Text = "Save Changes", .Location = New Point(110, 140), .Width = 100, .Height = 35}
            Dim btnCancel As New Button() With {.Text = "Cancel", .Location = New Point(215, 140), .Width = 95, .Height = 35}

            editForm.Controls.AddRange(New Control() {lblName, txtName, lblSeverity, cmbSeverity, btnSave, btnCancel})
            editForm.AcceptButton = btnSave
            editForm.CancelButton = btnCancel

            AddHandler btnCancel.Click, Sub() editForm.DialogResult = DialogResult.Cancel
            AddHandler btnSave.Click, Sub()
                                          Dim validRegex As New Regex("^[a-zA-Z0-9\s\-]+$")
                                          If Not validRegex.IsMatch(txtName.Text.Trim()) Then
                                              MessageBox.Show("Name must contain only letters, numbers, spaces, and hyphens.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                              Return
                                          End If
                                          editForm.DialogResult = DialogResult.OK
                                      End Sub

            If editForm.ShowDialog() = DialogResult.OK Then
                Dim newName As String = txtName.Text.Trim()
                Dim newSeverity As String = cmbSeverity.SelectedItem.ToString()

                ' Skip database hit if nothing actually changed
                If newName.Equals(oldName, StringComparison.OrdinalIgnoreCase) AndAlso newSeverity = oldSeverity Then Return

                Try
                    Using conn As MySqlConnection = Database.CreateOpenConnection()
                        ' Ensure the new name isn't taking another category's name
                        Dim checkCmd As New MySqlCommand("SELECT COUNT(*) FROM incident_categories WHERE LOWER(category_name) = @name AND category_id != @id", conn)
                        checkCmd.Parameters.AddWithValue("@name", newName.ToLower())
                        checkCmd.Parameters.AddWithValue("@id", catId)

                        If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                            MessageBox.Show("Another category with that name already exists.", "Duplicate Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If

                        ' UPDATE DATABASE (Targeting severity_default)
                        Dim updateCmd As New MySqlCommand("UPDATE incident_categories SET category_name = @name, severity_default = @severity WHERE category_id = @id", conn)
                        updateCmd.Parameters.AddWithValue("@name", newName)
                        updateCmd.Parameters.AddWithValue("@severity", newSeverity)
                        updateCmd.Parameters.AddWithValue("@id", catId)
                        updateCmd.ExecuteNonQuery()
                    End Using
                    LoadCategoriesFromDatabase()
                Catch ex As Exception
                    MessageBox.Show($"Update failed: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

End Class