Imports System.Data
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient
Imports System.Threading.Tasks

Public Class UC_EntrollStudents

    Private bsStudents As New BindingSource()
    Private dtStudents As DataTable
    Private recentlyUploadedIds As New HashSet(Of String)() ' To colorize new rows

    ' =================================================================
    ' 1. INITIALIZATION
    ' =================================================================
    Private Sub UC_EntrollStudents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadiusButton(btnUpload, 1.5F)
        RadiusButton(btnDelete, 1.5F)

        DataGridViewHelper.ApplyBeautifulStyle(dgvStudents)
        DataGridViewHelper.AdjustDataGridViewRowHeight(dgvStudents, 80)

        LoadStudentsFromDatabase()
    End Sub

    ' =================================================================
    ' 2. DATABASE SYNC (THE SOURCE OF TRUTH)
    ' =================================================================
    Private Sub LoadStudentsFromDatabase()
        Dim query As String = "SELECT username AS 'Index Number', full_name AS 'Full Name', phone_number AS 'Phone', campus_id, is_active FROM users WHERE role = 'STUDENT'"
        dtStudents = New DataTable()

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dtStudents)
                    End Using
                End Using
            End Using

            bsStudents.DataSource = dtStudents
            dgvStudents.DataSource = bsStudents

            ' Hide DB-specific columns if necessary, style headers
            dgvStudents.ClearSelection()
        Catch ex As Exception
            MessageBox.Show($"Failed to load students: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =================================================================
    ' 3. EXCEL IMPORT & VALIDATION (ASYNC)
    ' =================================================================
    Private Async Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Using ofd As New OpenFileDialog With {
            .Title = "Select Excel File",
            .Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx"
        }
            If ofd.ShowDialog = DialogResult.OK Then
                lblFilePath.Text = "Processing: " & ofd.FileName
                lblFilePath.ForeColor = Color.Orange
                btnUpload.Enabled = False

                Try
                    ' 1. Read Excel
                    Dim dtExcel As DataTable = LoadExcelToDataTable(ofd.FileName)

                    ' 2. Process to Database Asynchronously to prevent UI freeze
                    Await Task.Run(Sub() ProcessAndInsertExcelData(dtExcel))

                    ' 3. Refresh UI
                    LoadStudentsFromDatabase()
                    lblFilePath.Text = "Upload Complete: " & ofd.FileName
                    lblFilePath.ForeColor = Color.Green

                Catch ex As Exception
                    MessageBox.Show("Upload Failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    lblFilePath.ForeColor = Color.Red
                Finally
                    btnUpload.Enabled = True
                End Try
            End If
        End Using
    End Sub

    Private Sub ProcessAndInsertExcelData(dtExcel As DataTable)
        recentlyUploadedIds.Clear()
        Dim validIndexRegex As New Regex("^\d{10}$")
        Dim validNameRegex As New Regex("^[a-zA-Z\s\-]+$")

        ' The default password assigned to all new students
        Dim defaultPassword As String = "1234"
        Dim defaultHashedPassword As String = HashPasswordSHA256(defaultPassword)

        Using conn As MySqlConnection = Database.CreateOpenConnection()
            ' Use a transaction for bulk insert performance and safety
            Using transaction = conn.BeginTransaction()

                ' CRITICAL FIX: ON DUPLICATE KEY only updates the name. 
                ' It DOES NOT overwrite the password. If a student already set their own secure password,
                ' re-uploading an Excel roster will not reset it back to the default.
                Dim query As String = "INSERT INTO users (username, full_name, password_hash, role, first_login_completed, is_active) " &
                                  "VALUES (@username, @full_name, @password_hash, 'STUDENT', FALSE, TRUE) " &
                                  "ON DUPLICATE KEY UPDATE full_name = @full_name"

                Using cmd As New MySqlCommand(query, conn, transaction)
                    For Each row As DataRow In dtExcel.Rows
                        ' We now only read the first TWO columns
                        Dim indexNum As String = row(0).ToString().Trim()
                        Dim fullName As String = row(1).ToString().Trim()

                        ' VALIDATION: Skip invalid rows
                        If Not validIndexRegex.IsMatch(indexNum) OrElse Not validNameRegex.IsMatch(fullName) Then
                            Continue For
                        End If

                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("@username", indexNum)
                        cmd.Parameters.AddWithValue("@full_name", fullName)
                        cmd.Parameters.AddWithValue("@password_hash", defaultHashedPassword)

                        cmd.ExecuteNonQuery()

                        ' Track this ID to highlight it later
                        recentlyUploadedIds.Add(indexNum)
                    Next
                End Using
                transaction.Commit()
            End Using
        End Using
    End Sub
    Private Function LoadExcelToDataTable(filePath As String) As DataTable
        Dim dt As New DataTable()
        Dim connStr As String = If(filePath.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase),
            $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1"";",
            $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={filePath};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1"";")

        Using conn As New OleDbConnection(connStr)
            conn.Open()
            Dim sheetSchema As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim firstSheetName As String = sheetSchema.Rows(0)("TABLE_NAME").ToString().Trim("'"c)

            Using cmd As New OleDbCommand($"SELECT * FROM [{firstSheetName}]", conn)
                Using da As New OleDbDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ' =================================================================
    ' 4. LIVE SEARCH & HIGHLIGHTING
    ' =================================================================
    Private Sub txtIndexNumberSearch_TextChanged(sender As Object, e As EventArgs) Handles txtIndexNumberSearch.TextChanged
        Dim filterText As String = txtIndexNumberSearch.Text.Trim()
        If String.IsNullOrEmpty(filterText) Then
            bsStudents.Filter = ""
        Else
            ' Safely escape single quotes for the RowFilter
            filterText = filterText.Replace("'", "''")
            bsStudents.Filter = $"[Index Number] LIKE '%{filterText}%' OR [Full Name] LIKE '%{filterText}%'"
        End If
    End Sub

    ' Make sure the Handles clause matches your ACTUAL grid name (dgvStudents or dgvApplicants)
    Private Sub dgvStudents_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvStudents.CellFormatting

        ' 1. Defensive Guard: Ignore the empty "New" row at the bottom of the grid
        If dgvStudents.Rows(e.RowIndex).IsNewRow Then Return

        ' 2. Only format the specific column
        If dgvStudents.Columns(e.ColumnIndex).Name = "Index Number" Then
            Dim cell As DataGridViewCell = dgvStudents.Rows(e.RowIndex).Cells("Index Number")

            ' 3. Defensive Guard: Never assume a cell has data. Always check for Nothing and DBNull.
            If cell.Value IsNot Nothing AndAlso Not IsDBNull(cell.Value) Then
                Dim indexVal As String = cell.Value.ToString()

                ' Apply the highlight if it was just uploaded
                If recentlyUploadedIds.Contains(indexVal) Then
                    dgvStudents.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.WhiteSmoke
                End If
            End If
        End If
    End Sub
    ' =================================================================
    ' 5. EDIT & DELETE LOGIC
    ' =================================================================
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvStudents.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a student to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvStudents.SelectedRows(0)

        ' =================================================================
        ' THE DEFENSIVE GUARD: Predict the empty row and stop the execution
        ' =================================================================
        If selectedRow.IsNewRow OrElse selectedRow.Cells("Index Number").Value Is Nothing OrElse IsDBNull(selectedRow.Cells("Index Number").Value) Then
            MessageBox.Show("You cannot delete an empty or invalid row.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Now it is 100% mathematically safe to call .ToString()
        Dim indexNum As String = selectedRow.Cells("Index Number").Value.ToString()
        Dim confirm As DialogResult = MessageBox.Show($"Are you sure you want to delete student {indexNum}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            ' =================================================================
            ' EXCEPTION HANDLING: Used here because DB connections are unpredictable
            ' =================================================================
            Try
                Using conn As MySqlConnection = Database.CreateOpenConnection()
                    Dim cmd As New MySqlCommand("DELETE FROM users WHERE username = @username AND role = 'STUDENT'", conn)
                    cmd.Parameters.AddWithValue("@username", indexNum)
                    cmd.ExecuteNonQuery()
                End Using

                LoadStudentsFromDatabase() ' Refresh the source of truth

            Catch ex As Exception
                MessageBox.Show($"Database deletion failed: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' =================================================================
    ' 6. SECURITY HELPER
    ' =================================================================
    Private Function HashPasswordSHA256(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            Return Convert.ToBase64String(hash)
        End Using
    End Function

    Private Sub dgvStudents_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudents.CellContentClick

    End Sub
End Class