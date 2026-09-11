<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SecurityPatrolDashboard
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
        PanelWithNavButtons = New Panel()
        lblNotify2 = New Label()
        pbxNotify = New PictureBox()
        btnNoUse = New Button()
        btnHandleIncident = New Button()
        lblSecurityPatrol = New Label()
        MenuStrip1 = New MenuStrip()
        MoreOptionsToolStripMenuItem = New ToolStripMenuItem()
        AboutUsToolStripMenuItem = New ToolStripMenuItem()
        LOGOUTToolStripMenuItem = New ToolStripMenuItem()
        PanelWithUC = New Panel()
        Panel1 = New Panel()
        Label2 = New Label()
        Panel2 = New Panel()
        PictureBox1 = New PictureBox()
        lblNotify = New Label()
        Panel3 = New Panel()
        FlowLayoutPanelBackground = New FlowLayoutPanel()
        PanelWithNavButtons.SuspendLayout()
        CType(pbxNotify, ComponentModel.ISupportInitialize).BeginInit()
        MenuStrip1.SuspendLayout()
        PanelWithUC.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        FlowLayoutPanelBackground.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelWithNavButtons
        ' 
        PanelWithNavButtons.BackColor = Color.DarkRed
        PanelWithNavButtons.Controls.Add(lblNotify2)
        PanelWithNavButtons.Controls.Add(pbxNotify)
        PanelWithNavButtons.Controls.Add(btnNoUse)
        PanelWithNavButtons.Controls.Add(btnHandleIncident)
        PanelWithNavButtons.Controls.Add(lblSecurityPatrol)
        PanelWithNavButtons.Controls.Add(MenuStrip1)
        PanelWithNavButtons.Location = New Point(4, 4)
        PanelWithNavButtons.Margin = New Padding(4)
        PanelWithNavButtons.Name = "PanelWithNavButtons"
        PanelWithNavButtons.Size = New Size(2221, 101)
        PanelWithNavButtons.TabIndex = 29
        ' 
        ' lblNotify2
        ' 
        lblNotify2.AutoSize = True
        lblNotify2.BackColor = Color.Transparent
        lblNotify2.Font = New Font("Garamond", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblNotify2.ForeColor = Color.White
        lblNotify2.Location = New Point(628, 9)
        lblNotify2.Margin = New Padding(4, 0, 4, 0)
        lblNotify2.Name = "lblNotify2"
        lblNotify2.Size = New Size(69, 81)
        lblNotify2.TabIndex = 21
        lblNotify2.Text = "0"
        lblNotify2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pbxNotify
        ' 
        pbxNotify.Image = My.Resources.Resources.notify
        pbxNotify.Location = New Point(702, 15)
        pbxNotify.Margin = New Padding(4)
        pbxNotify.Name = "pbxNotify"
        pbxNotify.Size = New Size(71, 70)
        pbxNotify.SizeMode = PictureBoxSizeMode.StretchImage
        pbxNotify.TabIndex = 27
        pbxNotify.TabStop = False
        ' 
        ' btnNoUse
        ' 
        btnNoUse.BackColor = Color.Maroon
        btnNoUse.FlatAppearance.BorderSize = 0
        btnNoUse.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Bold)
        btnNoUse.ForeColor = Color.Transparent
        btnNoUse.Location = New Point(847, 15)
        btnNoUse.Margin = New Padding(4, 5, 4, 5)
        btnNoUse.Name = "btnNoUse"
        btnNoUse.Size = New Size(12, 81)
        btnNoUse.TabIndex = 22
        btnNoUse.UseVisualStyleBackColor = False
        ' 
        ' btnHandleIncident
        ' 
        btnHandleIncident.BackColor = Color.Maroon
        btnHandleIncident.FlatAppearance.BorderSize = 0
        btnHandleIncident.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Bold)
        btnHandleIncident.ForeColor = Color.Transparent
        btnHandleIncident.Location = New Point(1097, 25)
        btnHandleIncident.Margin = New Padding(4, 5, 4, 5)
        btnHandleIncident.Name = "btnHandleIncident"
        btnHandleIncident.Size = New Size(342, 60)
        btnHandleIncident.TabIndex = 21
        btnHandleIncident.Text = "Handle an Incident"
        btnHandleIncident.UseVisualStyleBackColor = False
        ' 
        ' lblSecurityPatrol
        ' 
        lblSecurityPatrol.AutoSize = True
        lblSecurityPatrol.BackColor = Color.Transparent
        lblSecurityPatrol.Font = New Font("Garamond", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSecurityPatrol.ForeColor = Color.White
        lblSecurityPatrol.Location = New Point(245, 30)
        lblSecurityPatrol.Margin = New Padding(4, 0, 4, 0)
        lblSecurityPatrol.Name = "lblSecurityPatrol"
        lblSecurityPatrol.Size = New Size(109, 31)
        lblSecurityPatrol.TabIndex = 19
        lblSecurityPatrol.Text = "Security"
        lblSecurityPatrol.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.BackColor = Color.Transparent
        MenuStrip1.Dock = DockStyle.Left
        MenuStrip1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {MoreOptionsToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New Padding(8, 2, 0, 2)
        MenuStrip1.Size = New Size(153, 101)
        MenuStrip1.TabIndex = 20
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' MoreOptionsToolStripMenuItem
        ' 
        MoreOptionsToolStripMenuItem.BackColor = Color.DarkSlateGray
        MoreOptionsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AboutUsToolStripMenuItem, LOGOUTToolStripMenuItem})
        MoreOptionsToolStripMenuItem.ForeColor = Color.White
        MoreOptionsToolStripMenuItem.Name = "MoreOptionsToolStripMenuItem"
        MoreOptionsToolStripMenuItem.Size = New Size(136, 29)
        MoreOptionsToolStripMenuItem.Text = "More Options"
        ' 
        ' AboutUsToolStripMenuItem
        ' 
        AboutUsToolStripMenuItem.BackColor = Color.DarkSlateGray
        AboutUsToolStripMenuItem.ForeColor = Color.White
        AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem"
        AboutUsToolStripMenuItem.Size = New Size(193, 34)
        AboutUsToolStripMenuItem.Text = "About Us"
        ' 
        ' LOGOUTToolStripMenuItem
        ' 
        LOGOUTToolStripMenuItem.BackColor = Color.DarkSlateGray
        LOGOUTToolStripMenuItem.ForeColor = Color.White
        LOGOUTToolStripMenuItem.Name = "LOGOUTToolStripMenuItem"
        LOGOUTToolStripMenuItem.Size = New Size(193, 34)
        LOGOUTToolStripMenuItem.Text = "LOGOUT"
        ' 
        ' PanelWithUC
        ' 
        PanelWithUC.BackColor = Color.WhiteSmoke
        PanelWithUC.Controls.Add(Panel1)
        PanelWithUC.Dock = DockStyle.Bottom
        PanelWithUC.Location = New Point(4, 113)
        PanelWithUC.Margin = New Padding(4)
        PanelWithUC.Name = "PanelWithUC"
        PanelWithUC.Size = New Size(2266, 1055)
        PanelWithUC.TabIndex = 30
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(Panel3)
        Panel1.Location = New Point(504, 97)
        Panel1.Margin = New Padding(4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(816, 564)
        Panel1.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Garamond", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.DarkRed
        Label2.Location = New Point(394, 55)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(394, 45)
        Label2.TabIndex = 20
        Label2.Text = "UnRead Notifications"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(PictureBox1)
        Panel2.Controls.Add(lblNotify)
        Panel2.Location = New Point(198, 106)
        Panel2.Margin = New Padding(4)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(380, 269)
        Panel2.TabIndex = 0
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.notify
        PictureBox1.Location = New Point(196, 36)
        PictureBox1.Margin = New Padding(4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(124, 142)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 26
        PictureBox1.TabStop = False
        ' 
        ' lblNotify
        ' 
        lblNotify.AutoSize = True
        lblNotify.BackColor = Color.Transparent
        lblNotify.Font = New Font("Garamond", 72F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblNotify.ForeColor = Color.DarkRed
        lblNotify.Location = New Point(96, 25)
        lblNotify.Margin = New Padding(4, 0, 4, 0)
        lblNotify.Name = "lblNotify"
        lblNotify.Size = New Size(136, 162)
        lblNotify.TabIndex = 20
        lblNotify.Text = "0"
        lblNotify.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.DarkSlateGray
        Panel3.Location = New Point(194, 142)
        Panel3.Margin = New Padding(4)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(148, 245)
        Panel3.TabIndex = 21
        ' 
        ' FlowLayoutPanelBackground
        ' 
        FlowLayoutPanelBackground.Controls.Add(PanelWithNavButtons)
        FlowLayoutPanelBackground.Controls.Add(PanelWithUC)
        FlowLayoutPanelBackground.Dock = DockStyle.Fill
        FlowLayoutPanelBackground.Location = New Point(0, 0)
        FlowLayoutPanelBackground.Margin = New Padding(4)
        FlowLayoutPanelBackground.Name = "FlowLayoutPanelBackground"
        FlowLayoutPanelBackground.Size = New Size(1770, 959)
        FlowLayoutPanelBackground.TabIndex = 3
        ' 
        ' SecurityPatrolDashboard
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1770, 959)
        Controls.Add(FlowLayoutPanelBackground)
        Margin = New Padding(4)
        Name = "SecurityPatrolDashboard"
        Text = "SecurityPatrolDashboard"
        PanelWithNavButtons.ResumeLayout(False)
        PanelWithNavButtons.PerformLayout()
        CType(pbxNotify, ComponentModel.ISupportInitialize).EndInit()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        PanelWithUC.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        FlowLayoutPanelBackground.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelWithNavButtons As Panel
    Friend WithEvents btnNoUse As Button
    Friend WithEvents btnHandleIncident As Button
    Friend WithEvents lblSecurityPatrol As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MoreOptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutUsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LOGOUTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PanelWithUC As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblNotify As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents FlowLayoutPanelBackground As FlowLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pbxNotify As PictureBox
    Friend WithEvents lblNotify2 As Label
End Class
