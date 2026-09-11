Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data

Public Class StudentRegister

    ' THIS IS CRITICAL: The Login screen MUST set this property when opening this form
    ' so the system knows WHICH student is updating their account.
    Public Property ActivatingUserID As Integer

    Private errorProv As New ErrorProvider()
    Private generatedImageFilename As String = ""

    ' =================================================================
    ' 1. INITIALIZATION & UX SETUP
    ' =================================================================
    Private Sub StudentRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Ensure the form is maximized and centered
        Me.WindowState = FormWindowState.Maximized



        If ActivatingUserID = 0 Then
            MessageBox.Show("Critical Error: No User ID passed to the registration screen. Cannot proceed.", "System Halt", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Return
        End If

        ' Apply UI Styling 
        RadiusButton(btnUploadPhoto, 1.5F)
        RadiusButton(btnSignUp, 1.5F)

        ' UX GUIDANCE: Setup Tooltips
        Dim regToolTip As New ToolTip() With {
            .ToolTipIcon = ToolTipIcon.Info,
            .IsBalloon = True,
            .AutoPopDelay = 5000,
            .InitialDelay = 500
        }
        regToolTip.SetToolTip(txtPhone, "Enter your 10-digit phone number. Must start with 02 or 05.")
        regToolTip.SetToolTip(cmbCampus, "Select your primary campus.")
        regToolTip.SetToolTip(txtPassword, "Create a secure, memorable password. Minimum 6 characters.")
        regToolTip.SetToolTip(btnUploadPhoto, "Select a clear profile picture (JPG or PNG).")
        regToolTip.SetToolTip(btnSignUp, "Activate your student account.")

        errorProv.BlinkStyle = ErrorBlinkStyle.NeverBlink
        pbxProfilePhoto.SizeMode = PictureBoxSizeMode.Zoom

        LoadCampuses()
        LoadStudentName()
    End Sub

    ' =================================================================
    ' 2. DATABASE SYNC & PRE-LOADING
    ' =================================================================
    Private Sub LoadStudentName()
        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Dim cmd As New MySqlCommand("SELECT full_name FROM users WHERE user_id = @id", conn)
                cmd.Parameters.AddWithValue("@id", ActivatingUserID)

                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    lblfull_name.Text = result.ToString()
                Else
                    lblfull_name.Text = "Unknown Student"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Failed to load student profile: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadCampuses()
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

            cmbCampus.DataSource = dtCampuses
            cmbCampus.DisplayMember = "campus_name"
            cmbCampus.ValueMember = "campus_id"
            cmbCampus.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show($"Failed to load campuses: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =================================================================
    ' 3. FILE SYSTEM ARCHITECTURE (THE PHOTO UPLOAD)
    ' =================================================================
    Private Sub btnUploadPhoto_Click(sender As Object, e As EventArgs) Handles btnUploadPhoto.Click
        Using ofd As New OpenFileDialog()
            ofd.Title = "Select Profile Photo"
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png"

            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    ' 1. Display it instantly to the user
                    pbxProfilePhoto.Image = Image.FromFile(ofd.FileName)

                    ' 2. Define the application's internal photo directory
                    Dim appStoragePath As String = Path.Combine(Application.StartupPath, "ProfilePhotos")
                    If Not Directory.Exists(appStoragePath) Then
                        Directory.CreateDirectory(appStoragePath)
                    End If

                    ' 3. Create a unique filename so two "me.jpg" files don't overwrite each other
                    Dim fileExtension As String = Path.GetExtension(ofd.FileName)
                    generatedImageFilename = $"user_{ActivatingUserID}_{DateTime.Now.ToString("yyyyMMddHHmmss")}{fileExtension}"

                    ' 4. Define the final destination path
                    Dim targetFilePath As String = Path.Combine(appStoragePath, generatedImageFilename)

                    ' 5. Copy the file automatically. We save ONLY the filename to the database later.
                    File.Copy(ofd.FileName, targetFilePath, True)

                    ' Show the relative filename for verification purposes
                    lblPhotoPath.Text = generatedImageFilename

                Catch ex As Exception
                    MessageBox.Show($"Error processing image: {ex.Message}", "File System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    generatedImageFilename = ""
                    lblPhotoPath.Text = "No photo selected"
                End Try
            End If
        End Using
    End Sub

    ' =================================================================
    ' 4. VALIDATION & UX EVENTS
    ' =================================================================

    ' TRIGGERED ON LEAVE: Evaluates only after the user finishes typing
    Private Sub txtPhone_Leave(sender As Object, e As EventArgs) Handles txtPhone.Leave
        Dim validPhoneRegex As New Regex("^(02|05)\d{8}$")
        If Not String.IsNullOrEmpty(txtPhone.Text) AndAlso Not validPhoneRegex.IsMatch(txtPhone.Text.Trim()) Then
            errorProv.SetError(txtPhone, "Invalid phone number. Must be 10 digits starting with 02 or 05.")
        Else
            errorProv.SetError(txtPhone, "")
        End If
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If Not String.IsNullOrEmpty(txtPassword.Text) AndAlso txtPassword.Text.Length < 6 Then
            errorProv.SetError(txtPassword, "Password is too weak. Minimum 6 characters required.")
        Else
            errorProv.SetError(txtPassword, "")
        End If
    End Sub

    ' KeyDown: Allow pressing Enter to submit
    Private Sub TextBoxes_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPhone.KeyDown, txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnSignUp.PerformClick()
        End If
    End Sub

    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            Dim hashBytes As Byte() = sha256.ComputeHash(bytes)
            Return Convert.ToBase64String(hashBytes)
        End Using
    End Function

    ' =================================================================
    ' 5. THE UPDATE LOGIC
    ' =================================================================
    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        ' Final hard-stops for validation
        Dim phone As String = txtPhone.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        Dim validPhoneRegex As New Regex("^(02|05)\d{8}$")
        If Not validPhoneRegex.IsMatch(phone) Then
            MessageBox.Show("Please enter a valid 10-digit phone number starting with 02 or 05.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhone.Focus()
            Return
        End If

        If cmbCampus.SelectedValue Is Nothing Then
            MessageBox.Show("You must select your campus.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCampus.Focus()
            Return
        End If

        If password.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        If String.IsNullOrEmpty(generatedImageFilename) Then
            MessageBox.Show("Please upload a profile photo.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim campusId As Integer = Convert.ToInt32(cmbCampus.SelectedValue)
        Dim hashedPassword As String = HashPassword(password)

        btnSignUp.Enabled = False

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                ' UPDATE the existing record, flip first_login_completed to TRUE
                Dim updateQuery As String = "UPDATE users SET phone_number = @phone, campus_id = @campus, " &
                                            "password_hash = @hash, profile_photo_path = @photo, " &
                                            "first_login_completed = TRUE WHERE user_id = @id"

                Using cmd As New MySqlCommand(updateQuery, conn)
                    cmd.Parameters.AddWithValue("@phone", phone)
                    cmd.Parameters.AddWithValue("@campus", campusId)
                    cmd.Parameters.AddWithValue("@hash", hashedPassword)
                    cmd.Parameters.AddWithValue("@photo", generatedImageFilename)
                    cmd.Parameters.AddWithValue("@id", ActivatingUserID)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Account successfully activated. You will now be redirected to your dashboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Transition to the Student Dashboard (Replace with your actual dashboard form)
            ' Dim dashboard As New StudentDashboard()
            ' dashboard.Show()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show($"Account activation failed: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnSignUp.Enabled = True
        End Try
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class