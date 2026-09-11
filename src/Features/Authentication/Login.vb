Imports System.Text.RegularExpressions
Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class Login

    ' =================================================================
    ' 1. UI ANIMATIONS & EFFECTS
    ' =================================================================
    Private Sub FadeIn(sender As Object, e As EventArgs)
        If Me.Opacity < 1 Then
            Me.Opacity += 0.05
        Else
            tmrFade.Stop()
            RemoveHandler tmrFade.Tick, AddressOf FadeIn
        End If
    End Sub

    ' =================================================================
    ' 2. FORM INITIALIZATION
    ' =================================================================
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "System Login"
        Me.WindowState = FormWindowState.Maximized
        Me.Opacity = 0

        ' Start Fade
        tmrFade.Start()
        AddHandler tmrFade.Tick, AddressOf FadeIn

        txtUsername.Focus()

        ' Ensure password is masked by default
        txtPassword.UseSystemPasswordChar = True

        ' Apply UI Styles 
        RadiusButton(btnLogin, 1.5F)

        Dim navButtons As New List(Of Button) From {btnLogin, btnNoUse}
        NavButtonStyles.InitializeNavButtons(Me, navButtons, btnNoUse)

        ' UX GUIDANCE: Setup Tooltips for Login Instructions
        Dim loginToolTip As New ToolTip() With {
            .ToolTipIcon = ToolTipIcon.Info,
            .IsBalloon = True,
            .ToolTipTitle = "Login Instructions",
            .AutoPopDelay = 5000,
            .InitialDelay = 500
        }
        loginToolTip.SetToolTip(txtUsername, "Students: Enter Index Number." & vbCrLf & "Staff: Enter Username.")
        loginToolTip.SetToolTip(txtPassword, "Enter your secure password.")
    End Sub

    ' =================================================================
    ' 3. CRYPTOGRAPHY HELPER 
    ' =================================================================
    Private Function HashPasswordSHA256(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            Return Convert.ToBase64String(hash)
        End Using
    End Function

    ' =================================================================
    ' 4. KEYBOARD NAVIGATION
    ' =================================================================
    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then txtPassword.Focus()
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then btnLogin.PerformClick()
    End Sub

    ' =================================================================
    ' 5. CORE DATABASE AUTHENTICATION
    ' =================================================================
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text

        ' Basic empty check
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Enter username/index number and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Disable button to prevent double-clicking
        btnLogin.Enabled = False

        Dim query As String = "SELECT user_id, password_hash, role, full_name, campus_id, first_login_completed " &
                              "FROM users WHERE username = @username AND is_active = TRUE"

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim storedHash As String = reader("password_hash").ToString()

                            ' Hash the user's input and compare it to the database hash
                            Dim inputHash As String = HashPasswordSHA256(password)

                            If inputHash = storedHash Then
                                ' Extract Data
                                Dim userId As Integer = Convert.ToInt32(reader("user_id"))
                                Dim role As String = reader("role").ToString().ToUpper()
                                Dim fullName As String = reader("full_name").ToString()
                                Dim firstLogin As Boolean = Convert.ToBoolean(reader("first_login_completed"))

                                Dim campusId As Integer? = Nothing
                                If Not IsDBNull(reader("campus_id")) Then
                                    campusId = Convert.ToInt32(reader("campus_id"))
                                End If

                                ' Initialize Global State
                                Session.StartSession(userId, username, fullName, role, campusId)

                                ' Route User based on Role and Onboarding Status
                                Select Case role
                                    Case "ADMIN"
                                        Dim frm As New AdminDashboard()
                                        frm.Show()
                                    Case "SECURITY"
                                        Dim frm As New SecurityPatrolDashboard()
                                        frm.Show()
                                    Case "STUDENT"
                                        If firstLogin Then
                                            Dim frm As New StudentDashBoard()
                                            frm.Show()
                                        Else
                                            ' THIS IS THE ARCHITECTURAL BRIDGE YOU MISSED
                                            Dim frm As New StudentRegister()
                                            frm.ActivatingUserID = userId ' <-- Passing the ID
                                            frm.Show()
                                        End If
                                    Case Else
                                        MessageBox.Show("Unrecognized role.", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Session.EndSession()
                                        btnLogin.Enabled = True
                                        Return
                                End Select

                                Me.Hide()
                                Return ' Exit successful login
                            End If
                        End If
                    End Using
                End Using
            End Using

            ' If code reaches here, user not found or password incorrect
            MessageBox.Show("Invalid username or password. Access denied.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Clear()
            txtPassword.Focus()

        Catch ex As Exception
            MessageBox.Show($"Authentication error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnLogin.Enabled = True
        End Try
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class