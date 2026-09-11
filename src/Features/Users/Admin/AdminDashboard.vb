Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class AdminDashboard

    ' Timer to keep the notification badge live without locking the UI thread
    Private WithEvents tmrLiveNotification As New Timer()

    ' =================================================================
    ' 1. MEMORY-SAFE CONTROL LOADER
    ' =================================================================
    Private Sub LoadControl(control As UserControl)
        ' CRITICAL: Properly dispose of existing controls to prevent memory leaks
        If PanelWithUC.Controls.Count > 0 Then
            Dim oldControl As Control = PanelWithUC.Controls(0)
            PanelWithUC.Controls.Remove(oldControl)
            oldControl.Dispose()
        End If

        control.Dock = DockStyle.Fill
        PanelWithUC.Controls.Add(control)
    End Sub

    ' =================================================================
    ' 2. FORM INITIALIZATION & SECURITY CHECK
    ' =================================================================
    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' THE GATEKEEPER: Instantly kick out unauthorized users
        If Not Session.IsAuthenticated() OrElse Not Session.IsAdmin() Then
            MessageBox.Show("CRITICAL: Unauthorized Access. Security violation logged.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Session.EndSession()
            Application.Exit() ' Hard kill the app if a bypass is attempted
            Return
        End If

        Me.WindowState = FormWindowState.Maximized
        Me.Text = $"Incident Management System - Administrator: {Session.CurrentFullName}"

        ' UI Styling
        RadiusButton(btnRegister, 1.5F)
        RadiusButton(btnIncidentCategory, 1.5F)
        RadiusButton(btnCreateSecurityPatrol, 1.5F)
        RadiusButton(btnFeeds, 1.5F)
        RadiusButton(btnCreateCampuses, 1.5F)

        Dim navButtons As New List(Of Button) From {
            btnCreateSecurityPatrol,
            btnIncidentCategory,
            btnRegister,
            btnFeeds,
            btnCreateCampuses
        }
        NavButtonStyles.InitializeNavButtons(Me, navButtons, btnRegister)

        ' UX GUIDANCE: Setup Tooltips
        Dim adminToolTip As New ToolTip() With {
            .ToolTipIcon = ToolTipIcon.Info,
            .IsBalloon = True,
            .AutoPopDelay = 5000,
            .InitialDelay = 500
        }

        adminToolTip.SetToolTip(btnRegister, "Import students from Excel or manually enroll them.")
        adminToolTip.SetToolTip(btnCreateSecurityPatrol, "Create and assign campus security team accounts.")
        adminToolTip.SetToolTip(btnIncidentCategory, "Manage severity levels and categories (e.g., Theft, Fire).")
        adminToolTip.SetToolTip(btnFeeds, "Monitor live incident reports and assign them to patrols.")
        adminToolTip.SetToolTip(btnCreateCampuses, "Add new campuses to the system for incident tracking.")
        adminToolTip.SetToolTip(pbxNotify, "Click to view new unassigned incidents.")
        adminToolTip.SetToolTip(lblNotify, "Live count of PENDING incidents awaiting assignment.")

        ' Initialize Live Notifications
        UpdatePendingIncidentsCount()

        ' Set Timer to tick every 15 seconds (15000 milliseconds)
        tmrLiveNotification.Interval = 15000
        tmrLiveNotification.Start()
    End Sub

    ' Load the default screen after the UI renders
    Private Sub AdminDashboard_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' Only load if authentication passed
        If Session.IsAdmin() Then
            LoadControl(New UC_EntrollStudents())
        End If
    End Sub

    ' =================================================================
    ' 3. LIVE NOTIFICATION ENGINE (THE "COUNTDOWN" FIX)
    ' =================================================================

    ' Timer Tick Event to poll the database quietly
    Private Sub tmrLiveNotification_Tick(sender As Object, e As EventArgs) Handles tmrLiveNotification.Tick
        UpdatePendingIncidentsCount()
    End Sub

    ''' <summary>
    ''' Queries the absolute truth from the database regarding unassigned incidents.
    ''' This is marked Public so UC_IncidentFeeds can call it instantly after assigning a task.
    ''' </summary>
    Public Sub UpdatePendingIncidentsCount()
        ' Based strictly on your locked schema: Unassigned = PENDING
        Dim query As String = "SELECT COUNT(*) FROM incidents WHERE current_status = 'PENDING'"

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    ' Update UI
                    lblNotify.Text = count.ToString()

                    ' Visual cue: Turn red if there are unattended incidents
                    If count > 0 Then
                        lblNotify.ForeColor = Color.Red
                    Else
                        lblNotify.ForeColor = Color.Black
                    End If
                End Using
            End Using
        Catch ex As Exception
            lblNotify.Text = "0" ' Fail silently on background ticks
        End Try
    End Sub

    ' =================================================================
    ' 4. NAVIGATION HANDLERS
    ' =================================================================
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        LoadControl(New UC_EntrollStudents())
    End Sub

    Private Sub btnCreateSecurityPatrol_Click(sender As Object, e As EventArgs) Handles btnCreateSecurityPatrol.Click
        LoadControl(New UC_CreateSecurityPatrol())
    End Sub

    Private Sub btnIncidentCategory_Click(sender As Object, e As EventArgs) Handles btnIncidentCategory.Click
        LoadControl(New UC_CreateIncidentCat())
    End Sub

    Private Sub btnFeeds_Click(sender As Object, e As EventArgs) Handles btnFeeds.Click
        LoadControl(New UC_IncidentFeeds())
    End Sub

    Private Sub btnCreateCampuses_Click(sender As Object, e As EventArgs) Handles btnCreateCampuses.Click
        LoadControl(New UC_CreateCampus())
    End Sub

    Private Sub ViewPatrolTeamsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewPatrolTeamsToolStripMenuItem.Click
        LoadControl(New UC_ViewPatrolTeams())
    End Sub

    ' Bind BOTH the picture box and the label text to the feeds navigation
    Private Sub pbxNotify_Click(sender As Object, e As EventArgs) Handles pbxNotify.Click, lblNotify.Click
        LoadControl(New UC_IncidentFeeds())
    End Sub

    ' =================================================================
    ' 5. SECURE LOGOUT
    ' =================================================================
    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click ' FIXED EVENT HANDLER MAPPING
        If MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            tmrLiveNotification.Stop()
            Session.EndSession()

            Dim loginForm As New Login()
            loginForm.Show()
            Me.Close()
        End If
    End Sub

    Private Sub PanelWithUC_Paint(sender As Object, e As PaintEventArgs) Handles PanelWithUC.Paint

    End Sub
End Class