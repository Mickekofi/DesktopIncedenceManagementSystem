<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminDashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        PanelWithUC = New Panel()
        btnRegister = New Button()
        panelLeft = New Panel()
        Panel2 = New Panel()
        pbxNotify = New PictureBox()
        lblNotify = New Label()
        btnCreateCampuses = New Button()
        Panel1 = New Panel()
        MenuStrip1 = New MenuStrip()
        ManageSecurityPatrolToolStripMenuItem = New ToolStripMenuItem()
        LogoutToolStripMenuItem = New ToolStripMenuItem()
        ManagePatrolTeamsToolStripMenuItem = New ToolStripMenuItem()
        ViewPatrolTeamsToolStripMenuItem = New ToolStripMenuItem()
        UpdatePatrolTeamToolStripMenuItem = New ToolStripMenuItem()
        DeletePatrolTeamToolStripMenuItem = New ToolStripMenuItem()
        btnFeeds = New Button()
        btnIncidentCategory = New Button()
        btnCreateSecurityPatrol = New Button()
        panelLeft.SuspendLayout()
        Panel2.SuspendLayout()
        CType(pbxNotify, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelWithUC
        ' 
        PanelWithUC.AutoScroll = True
        PanelWithUC.BackColor = Color.WhiteSmoke
        PanelWithUC.BorderStyle = BorderStyle.FixedSingle
        PanelWithUC.Dock = DockStyle.Right
        PanelWithUC.ForeColor = SystemColors.InactiveBorder
        PanelWithUC.Location = New Point(380, 33)
        PanelWithUC.Margin = New Padding(571, 5, 4, 5)
        PanelWithUC.Name = "PanelWithUC"
        PanelWithUC.Size = New Size(1371, 943)
        PanelWithUC.TabIndex = 2
        ' 
        ' btnRegister
        ' 
        btnRegister.BackColor = Color.White
        btnRegister.FlatAppearance.BorderSize = 0
        btnRegister.Font = New Font("Arial Narrow", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegister.ForeColor = Color.Black
        btnRegister.Location = New Point(14, 481)
        btnRegister.Margin = New Padding(4, 5, 4, 5)
        btnRegister.Name = "btnRegister"
        btnRegister.Size = New Size(342, 95)
        btnRegister.TabIndex = 1
        btnRegister.Text = "Enroll Students"
        btnRegister.UseVisualStyleBackColor = False
        ' 
        ' panelLeft
        ' 
        panelLeft.AutoScroll = True
        panelLeft.BackColor = Color.White
        panelLeft.BorderStyle = BorderStyle.FixedSingle
        panelLeft.Controls.Add(Panel2)
        panelLeft.Controls.Add(btnCreateCampuses)
        panelLeft.Controls.Add(btnFeeds)
        panelLeft.Controls.Add(btnIncidentCategory)
        panelLeft.Controls.Add(btnCreateSecurityPatrol)
        panelLeft.Controls.Add(btnRegister)
        panelLeft.Dock = DockStyle.Left
        panelLeft.ForeColor = Color.MintCream
        panelLeft.Location = New Point(0, 33)
        panelLeft.Margin = New Padding(4, 5, 4, 5)
        panelLeft.Name = "panelLeft"
        panelLeft.Size = New Size(410, 943)
        panelLeft.TabIndex = 3
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.WhiteSmoke
        Panel2.Controls.Add(pbxNotify)
        Panel2.Controls.Add(lblNotify)
        Panel2.Location = New Point(41, 47)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(300, 231)
        Panel2.TabIndex = 11
        ' 
        ' pbxNotify
        ' 
        pbxNotify.Image = My.Resources.Resources.notify
        pbxNotify.Location = New Point(134, 65)
        pbxNotify.Margin = New Padding(4)
        pbxNotify.Name = "pbxNotify"
        pbxNotify.Size = New Size(88, 78)
        pbxNotify.SizeMode = PictureBoxSizeMode.StretchImage
        pbxNotify.TabIndex = 27
        pbxNotify.TabStop = False
        ' 
        ' lblNotify
        ' 
        lblNotify.AutoSize = True
        lblNotify.BackColor = Color.Transparent
        lblNotify.Font = New Font("Garamond", 48F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblNotify.ForeColor = Color.DarkRed
        lblNotify.Location = New Point(43, 49)
        lblNotify.Margin = New Padding(4, 0, 4, 0)
        lblNotify.Name = "lblNotify"
        lblNotify.Size = New Size(83, 108)
        lblNotify.TabIndex = 26
        lblNotify.Text = "1"
        lblNotify.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnCreateCampuses
        ' 
        btnCreateCampuses.BackColor = Color.White
        btnCreateCampuses.FlatAppearance.BorderSize = 0
        btnCreateCampuses.Font = New Font("Arial Narrow", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCreateCampuses.ForeColor = Color.Black
        btnCreateCampuses.Location = New Point(12, 357)
        btnCreateCampuses.Margin = New Padding(4, 5, 4, 5)
        btnCreateCampuses.Name = "btnCreateCampuses"
        btnCreateCampuses.Size = New Size(342, 95)
        btnCreateCampuses.TabIndex = 10
        btnCreateCampuses.Text = "Create Campuses"
        btnCreateCampuses.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(panelLeft)
        Panel1.Controls.Add(PanelWithUC)
        Panel1.Controls.Add(MenuStrip1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(4, 5, 4, 5)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1751, 976)
        Panel1.TabIndex = 2
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {ManageSecurityPatrolToolStripMenuItem, ManagePatrolTeamsToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New Padding(8, 2, 0, 2)
        MenuStrip1.Size = New Size(1751, 33)
        MenuStrip1.TabIndex = 4
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' ManageSecurityPatrolToolStripMenuItem
        ' 
        ManageSecurityPatrolToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {LogoutToolStripMenuItem})
        ManageSecurityPatrolToolStripMenuItem.Name = "ManageSecurityPatrolToolStripMenuItem"
        ManageSecurityPatrolToolStripMenuItem.Size = New Size(92, 29)
        ManageSecurityPatrolToolStripMenuItem.Text = "Options"
        ' 
        ' LogoutToolStripMenuItem
        ' 
        LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        LogoutToolStripMenuItem.Size = New Size(182, 34)
        LogoutToolStripMenuItem.Text = "LOGOUT"
        ' 
        ' ManagePatrolTeamsToolStripMenuItem
        ' 
        ManagePatrolTeamsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ViewPatrolTeamsToolStripMenuItem, UpdatePatrolTeamToolStripMenuItem, DeletePatrolTeamToolStripMenuItem})
        ManagePatrolTeamsToolStripMenuItem.Name = "ManagePatrolTeamsToolStripMenuItem"
        ManagePatrolTeamsToolStripMenuItem.Size = New Size(196, 29)
        ManagePatrolTeamsToolStripMenuItem.Text = "Manage Patrol Teams"
        ' 
        ' ViewPatrolTeamsToolStripMenuItem
        ' 
        ViewPatrolTeamsToolStripMenuItem.Name = "ViewPatrolTeamsToolStripMenuItem"
        ViewPatrolTeamsToolStripMenuItem.Size = New Size(268, 34)
        ViewPatrolTeamsToolStripMenuItem.Text = "View Patrol Teams"
        ' 
        ' UpdatePatrolTeamToolStripMenuItem
        ' 
        UpdatePatrolTeamToolStripMenuItem.Name = "UpdatePatrolTeamToolStripMenuItem"
        UpdatePatrolTeamToolStripMenuItem.Size = New Size(268, 34)
        UpdatePatrolTeamToolStripMenuItem.Text = "Update Patrol Team"
        ' 
        ' DeletePatrolTeamToolStripMenuItem
        ' 
        DeletePatrolTeamToolStripMenuItem.Name = "DeletePatrolTeamToolStripMenuItem"
        DeletePatrolTeamToolStripMenuItem.Size = New Size(268, 34)
        DeletePatrolTeamToolStripMenuItem.Text = "Delete Patrol team"
        ' 
        ' btnFeeds
        ' 
        btnFeeds.BackColor = Color.White
        btnFeeds.FlatAppearance.BorderSize = 0
        btnFeeds.Font = New Font("Arial Narrow", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFeeds.ForeColor = Color.Black
        btnFeeds.Location = New Point(14, 859)
        btnFeeds.Margin = New Padding(4, 5, 4, 5)
        btnFeeds.Name = "btnFeeds"
        btnFeeds.Size = New Size(342, 95)
        btnFeeds.TabIndex = 9
        btnFeeds.Text = "Incident Feeds"
        btnFeeds.UseVisualStyleBackColor = False
        ' 
        ' btnIncidentCategory
        ' 
        btnIncidentCategory.BackColor = Color.White
        btnIncidentCategory.FlatAppearance.BorderSize = 0
        btnIncidentCategory.Font = New Font("Arial Narrow", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnIncidentCategory.ForeColor = Color.Black
        btnIncidentCategory.Location = New Point(14, 730)
        btnIncidentCategory.Margin = New Padding(4, 5, 4, 5)
        btnIncidentCategory.Name = "btnIncidentCategory"
        btnIncidentCategory.Size = New Size(342, 95)
        btnIncidentCategory.TabIndex = 8
        btnIncidentCategory.Text = "Incident Category"
        btnIncidentCategory.UseVisualStyleBackColor = False
        ' 
        ' btnCreateSecurityPatrol
        ' 
        btnCreateSecurityPatrol.BackColor = Color.White
        btnCreateSecurityPatrol.FlatAppearance.BorderSize = 0
        btnCreateSecurityPatrol.Font = New Font("Arial Narrow", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCreateSecurityPatrol.ForeColor = Color.Black
        btnCreateSecurityPatrol.Location = New Point(14, 605)
        btnCreateSecurityPatrol.Margin = New Padding(4, 5, 4, 5)
        btnCreateSecurityPatrol.Name = "btnCreateSecurityPatrol"
        btnCreateSecurityPatrol.Size = New Size(342, 95)
        btnCreateSecurityPatrol.TabIndex = 7
        btnCreateSecurityPatrol.Text = "Create Security Patrol"
        btnCreateSecurityPatrol.UseVisualStyleBackColor = False
        ' 
        ' AdminDashboard
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1751, 976)
        Controls.Add(Panel1)
        MainMenuStrip = MenuStrip1
        Margin = New Padding(4)
        Name = "AdminDashboard"
        Text = "AdminDashboard"
        panelLeft.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(pbxNotify, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelWithUC As Panel
    Friend WithEvents btnRegister As Button
    Friend WithEvents panelLeft As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ManageSecurityPatrolToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManagePatrolTeamsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewPatrolTeamsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdatePatrolTeamToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeletePatrolTeamToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnCreateCampuses As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pbxNotify As PictureBox
    Friend WithEvents lblNotify As Label
    Friend WithEvents btnFeeds As Button
    Friend WithEvents btnIncidentCategory As Button
    Friend WithEvents btnCreateSecurityPatrol As Button
End Class
