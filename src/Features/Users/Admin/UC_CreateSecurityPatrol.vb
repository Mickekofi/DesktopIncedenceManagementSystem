Imports System.Data
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography

Public Class UC_CreateSecurityPatrol

    Private errorProv As New ErrorProvider()

    ' =================================================================
    ' 1. INITIALIZATION & UX SETUP
    ' =================================================================
    Private Sub UC_CreateSecurityPatrol_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Apply UI Styling 
        RadiusButton(btnCreate, 1.5F)

        ' UX GUIDANCE: Setup Tooltips
        Dim secToolTip As New ToolTip() With {
            .ToolTipIcon = ToolTipIcon.Info,
            .IsBalloon = True,
            .AutoPopDelay = 5000,
            .InitialDelay = 500
        }
        secToolTip.SetToolTip(txtUsername, "Enter a unique username (e.g., 'sec_north01'). No spaces allowed.")
        secToolTip.SetToolTip(txtFullName, "Enter the guard's official full name. Letters and spaces only.")
        secToolTip.SetToolTip(txtPassword, "Assign the permanent starting password.")
        secToolTip.SetToolTip(cmbSelectCampus, "Assign the patrol to a specific campus.")
        secToolTip.SetToolTip(btnCreate, "Validate and create the new security account.")

        errorProv.BlinkStyle = ErrorBlinkStyle.NeverBlink

        LoadCampusesIntoComboBox()
    End Sub

    ' =================================================================
    ' 2. REAL-TIME VALIDATION & UX EVENTS
    ' =================================================================

    ' LIVE SEARCH / REGEX ERROR PROVIDER: Validates as the admin types
    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        Dim validUserRegex As New Regex("^[a-zA-Z0-9_]+$")
        If Not String.IsNullOrEmpty(txtUsername.Text) AndAlso Not validUserRegex.IsMatch(txtUsername.Text) Then
            errorProv.SetError(txtUsername, "Invalid format. Use only letters, numbers, and underscores (no spaces).")
        Else
            errorProv.SetError(txtUsername, "") ' Clear error if valid
        End If
    End Sub

    Private Sub txtFullName_TextChanged(sender As Object, e As EventArgs) Handles txtFullName.TextChanged
        Dim validNameRegex As New Regex("^[a-zA-Z\s\-]+$")
        If Not String.IsNullOrEmpty(txtFullName.Text) AndAlso Not validNameRegex.IsMatch(txtFullName.Text) Then
            errorProv.SetError(txtFullName, "Invalid format. Use only letters, spaces, and hyphens.")
        Else
            errorProv.SetError(txtFullName, "")
        End If
    End Sub

    ' KEYDOWN EVENT: Trigger the create button when the admin presses Enter
    Private Sub TextBoxes_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown, txtFullName.KeyDown, txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True ' Prevent the annoying "ding" sound
            btnCreate.PerformClick()
        End If
    End Sub

    ' =================================================================
    ' 3. DATABASE SYNC & CRYPTOGRAPHY
    ' =================================================================
    Private Sub LoadCampusesIntoComboBox()
        Dim query As String = "SELECT campus_id, campus_name FROM campuses WHERE is_active = TRUE ORDER BY campus_name ASC"
        Dim dtCampuses As New DataTable()

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dtCampuses)
                    End Using
                End Using
            End Using

            If dtCampuses.Rows.Count = 0 Then
                MessageBox.Show("No active campuses found in the database. You must create a campus first.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnCreate.Enabled = False
                Return
            End If

            cmbSelectCampus.DataSource = dtCampuses
            cmbSelectCampus.DisplayMember = "campus_name"
            cmbSelectCampus.ValueMember = "campus_id"
            cmbSelectCampus.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show($"Failed to load campuses: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            Dim hashBytes As Byte() = sha256.ComputeHash(bytes)
            Return Convert.ToBase64String(hashBytes)
        End Using
    End Function

    ' =================================================================
    ' 4. INSERT LOGIC
    ' =================================================================
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        ' We do not clear the ErrorProvider blindly here anymore, because the TextChanged events manage it.
        ' However, we still do final block validations.

        Dim username As String = txtUsername.Text.Trim()
        Dim fullName As String = txtFullName.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        Dim validUserRegex As New Regex("^[a-zA-Z0-9_]+$")
        If String.IsNullOrEmpty(username) OrElse Not validUserRegex.IsMatch(username) Then
            MessageBox.Show("Please fix the errors in the Username field.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If

        Dim validNameRegex As New Regex("^[a-zA-Z\s\-]+$")
        If String.IsNullOrEmpty(fullName) OrElse Not validNameRegex.IsMatch(fullName) Then
            MessageBox.Show("Please fix the errors in the Full Name field.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return
        End If

        If String.IsNullOrEmpty(password) OrElse password.Length < 4 Then
            errorProv.SetError(txtPassword, "Password must be at least 4 characters long.")
            txtPassword.Focus()
            Return
        Else
            errorProv.SetError(txtPassword, "")
        End If

        If cmbSelectCampus.SelectedValue Is Nothing Then
            errorProv.SetError(cmbSelectCampus, "You must assign this user to a campus.")
            Return
        Else
            errorProv.SetError(cmbSelectCampus, "")
        End If

        Dim campusId As Integer = Convert.ToInt32(cmbSelectCampus.SelectedValue)
        Dim hashedPassword As String = HashPassword(password)

        btnCreate.Enabled = False

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                ' Duplicate Check
                Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE LOWER(username) = @username"
                Using checkCmd As New MySqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@username", username.ToLower())
                    If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show($"The username '{username}' is already taken. Choose another.", "Duplicate Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        btnCreate.Enabled = True
                        Return
                    End If
                End Using

                ' Insert into Database
                ' CRITICAL CHANGE: first_login_completed is now set to TRUE for SECURITY role.
                Dim insertQuery As String = "INSERT INTO users (username, password_hash, role, full_name, campus_id, first_login_completed, is_active) " &
                                            "VALUES (@username, @password_hash, 'SECURITY', @full_name, @campus_id, TRUE, TRUE)"

                Using insertCmd As New MySqlCommand(insertQuery, conn)
                    insertCmd.Parameters.AddWithValue("@username", username)
                    insertCmd.Parameters.AddWithValue("@password_hash", hashedPassword)
                    insertCmd.Parameters.AddWithValue("@full_name", fullName)
                    insertCmd.Parameters.AddWithValue("@campus_id", campusId)
                    insertCmd.ExecuteNonQuery()
                End Using
            End Using

            ' Success Reset
            txtUsername.Clear()
            txtFullName.Clear()
            txtPassword.Clear()
            cmbSelectCampus.SelectedIndex = -1
            errorProv.Clear()

            MessageBox.Show($"Security Patrol user '{username}' successfully created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show($"Failed to create security user: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnCreate.Enabled = True
        End Try
    End Sub

End Class