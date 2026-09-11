Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class StudentDashBoard

    ' TIMER: Required for real-time dashboard updates without freezing the UI thread
    Private WithEvents tmrLiveNotification As New Timer()

    ' STATE MANAGEMENT: Now tracked by the database, not just volatile RAM
    Private lastCheckedTime As DateTime = DateTime.MinValue

    ' Maintain a reference to our tooltip so we can update it dynamically
    Private dashToolTip As New ToolTip()

    ' Utility method to load User Controls dynamically into the central panel
    Private Sub LoadControl(control As UserControl)
        ' Prevent Memory Leaks
        If PanelWithUC.Controls.Count > 0 Then
            Dim oldControl As Control = PanelWithUC.Controls(0)
            PanelWithUC.Controls.Remove(oldControl)
            oldControl.Dispose()
        End If

        control.Dock = DockStyle.Fill
        PanelWithUC.Controls.Add(control)
    End Sub

    ' =================================================================
    ' 1. FORM INITIALIZATION & SESSION BINDING
    ' =================================================================
    Private Sub StudentDashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' THE GATEKEEPER: Ensure only valid users load this form
        If Not Session.IsAuthenticated() Then
            MessageBox.Show("CRITICAL: Unauthorized Access. Returning to login.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Dim loginForm As New Login()
            loginForm.Show()
            Return
        End If

        Me.WindowState = FormWindowState.Maximized
        Me.Text = "Student Incident Management Portal"

        ' UI Styling
        RadiusButton(btnFileIncident, 1.5F)

        Dim navButtons As New List(Of Button) From {
            btnFileIncident
        }
        NavButtonStyles.InitializeNavButtons(Me, navButtons, btnFileIncident)

        ' ToolTips Configuration
        dashToolTip.IsBalloon = True
        dashToolTip.AutoPopDelay = 5000
        dashToolTip.InitialDelay = 500
        dashToolTip.ToolTipIcon = ToolTipIcon.Info

        dashToolTip.SetToolTip(btnFileIncident, "Report a new campus security or infrastructure incident.")
        dashToolTip.SetToolTip(pbxNotify, "No new updates.")
        dashToolTip.SetToolTip(lblNotify, "Live count of recent administrative actions on your incidents.")

        ' BIND SESSION DATA
        lblFullName.Text = $"Welcome, {Session.CurrentFullName}"

        ' FETCH PERSISTENT STATE: Ask the database when this user last checked notifications
        FetchLastNotificationCheckTime()

        ' Fetch live notification counts immediately
        UpdateNotificationCount()

        ' Start Live Polling (Every 15 Seconds)
        tmrLiveNotification.Interval = 15000
        tmrLiveNotification.Start()

        ' Load default screen
        btnFileIncident.PerformClick()
    End Sub

    ' =================================================================
    ' 2. REAL-TIME NOTIFICATION ENGINE
    ' =================================================================
    Private Sub FetchLastNotificationCheckTime()
        Dim query As String = "SELECT last_notification_check FROM users WHERE user_id = @userId"
        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", Session.CurrentUserId)
                    Dim result = cmd.ExecuteScalar()

                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        lastCheckedTime = Convert.ToDateTime(result)
                    Else
                        ' First time logging in ever, or column was just created. Default to yesterday.
                        lastCheckedTime = DateTime.Now.AddDays(-1)
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Fail-safe
            lastCheckedTime = DateTime.Now.AddDays(-1)
        End Try
    End Sub

    Private Sub tmrLiveNotification_Tick(sender As Object, e As EventArgs) Handles tmrLiveNotification.Tick
        UpdateNotificationCount()
    End Sub

    Private Sub UpdateNotificationCount()
        If Not Session.IsAuthenticated() Then Return

        Dim query As String = "SELECT COUNT(*) AS new_updates, MAX(ish.new_status) AS latest_status " &
                              "FROM incident_status_history ish " &
                              "INNER JOIN incidents i ON ish.incident_id = i.incident_id " &
                              "WHERE i.reported_by_user_id = @userId " &
                              "AND ish.changed_by_user_id != @userId "

        If lastCheckedTime > DateTime.MinValue Then
            query &= " AND ish.changed_at > @lastChecked"
        End If

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", Session.CurrentUserId)
                    If lastCheckedTime > DateTime.MinValue Then
                        cmd.Parameters.AddWithValue("@lastChecked", lastCheckedTime)
                    End If

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim count As Integer = Convert.ToInt32(If(IsDBNull(reader("new_updates")), 0, reader("new_updates")))
                            Dim latestStatus As String = If(IsDBNull(reader("latest_status")), "", reader("latest_status").ToString())

                            ' Update UI
                            lblNotify.Text = count.ToString()

                            ' Dynamic ToolTip logic based on actual data
                            If count > 0 Then
                                lblNotify.ForeColor = Color.White
                                dashToolTip.SetToolTip(pbxNotify, $"You have {count} new update(s)! Latest action: {latestStatus}.")
                            Else
                                lblNotify.ForeColor = Color.WhiteSmoke
                                dashToolTip.SetToolTip(pbxNotify, "All caught up. No new updates on your reported incidents.")
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Silent fail for background ticks to prevent freezing the UI
            lblNotify.Text = "0"
        End Try
    End Sub

    ' =================================================================
    ' 3. NAVIGATION & EVENT HANDLERS
    ' =================================================================
    Private Sub btnFileIncident_Click(sender As Object, e As EventArgs) Handles btnFileIncident.Click
        LoadControl(New UC_FileIncidence())
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs)
        LoadControl(New UC_History)
    End Sub

    ' =================================================================
    ' 4. NOTIFICATION CLEARING LOGIC (PERSISTED)
    ' =================================================================
    Private Sub Notification_Click(sender As Object, e As EventArgs) Handles pbxNotify.Click, lblNotify.Click
        ' 1. Update memory
        lastCheckedTime = DateTime.Now

        ' 2. COMMIT TO DATABASE: This guarantees the state survives logouts and crashes
        Dim updateQuery As String = "UPDATE users SET last_notification_check = @now WHERE user_id = @userId"
        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(updateQuery, conn)
                    cmd.Parameters.AddWithValue("@now", lastCheckedTime)
                    cmd.Parameters.AddWithValue("@userId", Session.CurrentUserId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' If the db update fails, they will see the notifications again later. Not fatal, but loggable.
        End Try

        ' 3. Force UI refresh immediately to drop the counter to zero
        UpdateNotificationCount()

        ' 4. Route them to the tracking screen
        LoadControl(New UC_Notification())

        NavButtonStyles.InitializeNavButtons(Me, New List(Of Button) From {btnFileIncident})
    End Sub

    ' =================================================================
    ' 5. SESSION TEARDOWN & LOGOUT
    ' =================================================================
    Private Sub LOGOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to log out of the portal?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' Stop the polling timer to prevent background crashes
            tmrLiveNotification.Stop()

            ' Safely wipe session memory before exiting
            Session.EndSession()

            Me.Close()
            Dim loginForm As New Login()
            loginForm.Show()
        End If
    End Sub

    Private Sub AboutUsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutUsToolStripMenuItem.Click
        MessageBox.Show("Campus Incident Management System (IMS) v1.0" & vbCrLf &
                        "Engineered for real-time security tracking and infrastructure support.",
                        "About System", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub PanelWithNavButtons_Paint(sender As Object, e As PaintEventArgs) Handles PanelWithNavButtons.Paint

    End Sub
End Class