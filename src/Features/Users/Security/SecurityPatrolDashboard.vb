Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class SecurityPatrolDashboard

    ' TIMER: Required for real-time dashboard updates
    Private WithEvents tmrLiveNotification As New Timer()
    Private dashToolTip As New ToolTip()

    ' =================================================================
    ' 1. MEMORY-SAFE CONTROL LOADER
    ' =================================================================
    Private Sub LoadControl(control As UserControl)
        ' CRITICAL: Stop using .Clear(). You must dispose of objects in RAM.
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
    Private Sub SecurityPatrolDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' THE GATEKEEPER: Instantly kick out unauthorized users or non-security roles
        If Not Session.IsAuthenticated() Then
            MessageBox.Show("CRITICAL: Unauthorized Access. Security violation logged.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Session.EndSession()
            Application.Exit()
            Return
        End If

        Me.WindowState = FormWindowState.Maximized
        Me.Text = $"Incident Management System - Security Patrol: {Session.CurrentFullName}"

        ' UI Styling
        RadiusButton(btnHandleIncident, 1.5F)
        ' Assuming btnNoUse is a placeholder in your layout
        RadiusButton(btnNoUse, 1.5F)

        Dim navButtons As New List(Of Button) From {
            btnHandleIncident,
            btnNoUse
        }
        NavButtonStyles.InitializeNavButtons(Me, navButtons, btnNoUse)

        ' Display Security Personnel Name
        lblSecurityPatrol.Text = $"Officer: {Session.CurrentFullName}"

        ' UX GUIDANCE: Setup Tooltips
        dashToolTip.IsBalloon = True
        dashToolTip.AutoPopDelay = 5000
        dashToolTip.InitialDelay = 500
        dashToolTip.ToolTipIcon = ToolTipIcon.Info

        dashToolTip.SetToolTip(btnHandleIncident, "View and resolve incidents assigned to you.")
        dashToolTip.SetToolTip(pbxNotify, "Click to open your active task list.")
        dashToolTip.SetToolTip(lblNotify, "Live count of pending incidents requiring your immediate action.")
        dashToolTip.SetToolTip(lblNotify2, "This number updates every 15 seconds to reflect the latest incident assignments.")
        ' Initialize Live Notifications
        UpdatePendingTaskCount()

        ' Set Timer to tick every 15 seconds
        tmrLiveNotification.Interval = 15000
        tmrLiveNotification.Start()

        ' Load the default operational screen immediately
        btnHandleIncident.PerformClick()
    End Sub

    ' =================================================================
    ' 3. LIVE NOTIFICATION ENGINE (THE "SUBTRACTION" FIX)
    ' =================================================================
    Private Sub tmrLiveNotification_Tick(sender As Object, e As EventArgs) Handles tmrLiveNotification.Tick
        UpdatePendingTaskCount()
    End Sub

    ''' <summary>
    ''' Queries the absolute truth from the database regarding this specific officer's active tasks.
    ''' </summary>
    Public Sub UpdatePendingTaskCount()
        If Not Session.IsAuthenticated() Then Return

        ' Strict query: Count only incidents assigned to THIS officer that are still in 'ASSIGNED' status.
        Dim query As String = "SELECT COUNT(*) FROM incident_assignments ia " &
                              "INNER JOIN incidents i ON ia.incident_id = i.incident_id " &
                              "WHERE ia.assigned_to_user_id = @userId AND i.current_status = 'ASSIGNED'"

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", Session.CurrentUserId)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    ' Update UI
                    lblNotify.Text = count.ToString()
                    lblNotify2.Text = count.ToString()
                    ' Visual cue: Turn red if there are unattended tasks
                    If count > 0 Then
                        lblNotify.ForeColor = Color.White
                        lblNotify2.ForeColor = Color.White
                        dashToolTip.SetToolTip(pbxNotify, $"You have {count} active task(s) requiring response.")
                    Else
                        lblNotify.ForeColor = Color.White
                        lblNotify2.ForeColor = Color.White
                        dashToolTip.SetToolTip(pbxNotify, "All clear. No pending assignments.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            lblNotify.Text = "0" ' Fail silently on background ticks
            lblNotify2.Text = "0"
        End Try
    End Sub

    ' =================================================================
    ' 4. NAVIGATION HANDLERS
    ' =================================================================
    Private Sub btnHandleIncident_Click(sender As Object, e As EventArgs) Handles btnHandleIncident.Click
        LoadControl(New UC_HandleIncidence())
        ' Sync navigation styles
        NavButtonStyles.InitializeNavButtons(Me, New List(Of Button) From {btnHandleIncident, btnNoUse}, btnHandleIncident)
    End Sub

    ' Bind BOTH the picture box and the label text to open the Handle Incident view
    Private Sub pbxNotify_Click(sender As Object, e As EventArgs) Handles pbxNotify.Click, lblNotify.Click
        btnHandleIncident.PerformClick()
    End Sub

    ' =================================================================
    ' 5. SECURE LOGOUT
    ' =================================================================
    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to end your patrol session?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
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