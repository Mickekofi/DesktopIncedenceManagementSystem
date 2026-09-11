<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StudentDashBoard
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
        pbxNotify = New PictureBox()
        lblNotify = New Label()
        btnFileIncident = New Button()
        lblFullName = New Label()
        MenuStrip1 = New MenuStrip()
        MoreOptionsToolStripMenuItem = New ToolStripMenuItem()
        AboutUsToolStripMenuItem = New ToolStripMenuItem()
        LOGOUTToolStripMenuItem = New ToolStripMenuItem()
        PanelWithUC = New Panel()
        FlowLayoutPanelBackground = New FlowLayoutPanel()
        PanelWithNavButtons.SuspendLayout()
        CType(pbxNotify, ComponentModel.ISupportInitialize).BeginInit()
        MenuStrip1.SuspendLayout()
        FlowLayoutPanelBackground.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelWithNavButtons
        ' 
        PanelWithNavButtons.BackColor = Color.DarkRed
        PanelWithNavButtons.Controls.Add(pbxNotify)
        PanelWithNavButtons.Controls.Add(lblNotify)
        PanelWithNavButtons.Controls.Add(btnFileIncident)
        PanelWithNavButtons.Controls.Add(lblFullName)
        PanelWithNavButtons.Controls.Add(MenuStrip1)
        PanelWithNavButtons.Location = New Point(4, 4)
        PanelWithNavButtons.Margin = New Padding(4)
        PanelWithNavButtons.Name = "PanelWithNavButtons"
        PanelWithNavButtons.Size = New Size(2221, 99)
        PanelWithNavButtons.TabIndex = 29
        ' 
        ' pbxNotify
        ' 
        pbxNotify.Image = My.Resources.Resources.notify
        pbxNotify.Location = New Point(812, 15)
        pbxNotify.Margin = New Padding(4)
        pbxNotify.Name = "pbxNotify"
        pbxNotify.Size = New Size(88, 78)
        pbxNotify.SizeMode = PictureBoxSizeMode.StretchImage
        pbxNotify.TabIndex = 25
        pbxNotify.TabStop = False
        ' 
        ' lblNotify
        ' 
        lblNotify.AutoSize = True
        lblNotify.BackColor = Color.Transparent
        lblNotify.Font = New Font("Garamond", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblNotify.ForeColor = Color.White
        lblNotify.Location = New Point(739, 14)
        lblNotify.Margin = New Padding(4, 0, 4, 0)
        lblNotify.Name = "lblNotify"
        lblNotify.Size = New Size(69, 81)
        lblNotify.TabIndex = 24
        lblNotify.Text = "0"
        lblNotify.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnFileIncident
        ' 
        btnFileIncident.BackColor = Color.Maroon
        btnFileIncident.FlatAppearance.BorderSize = 0
        btnFileIncident.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Bold)
        btnFileIncident.ForeColor = Color.Transparent
        btnFileIncident.Location = New Point(998, 26)
        btnFileIncident.Margin = New Padding(4, 5, 4, 5)
        btnFileIncident.Name = "btnFileIncident"
        btnFileIncident.Size = New Size(342, 60)
        btnFileIncident.TabIndex = 21
        btnFileIncident.Text = "File an Incident"
        btnFileIncident.UseVisualStyleBackColor = False
        ' 
        ' lblFullName
        ' 
        lblFullName.AutoSize = True
        lblFullName.BackColor = Color.Transparent
        lblFullName.Font = New Font("Garamond", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblFullName.ForeColor = Color.White
        lblFullName.Location = New Point(200, 55)
        lblFullName.Margin = New Padding(4, 0, 4, 0)
        lblFullName.Name = "lblFullName"
        lblFullName.Size = New Size(89, 31)
        lblFullName.TabIndex = 19
        lblFullName.Text = "USER"
        lblFullName.TextAlign = ContentAlignment.MiddleCenter
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
        MenuStrip1.Size = New Size(153, 99)
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
        PanelWithUC.Dock = DockStyle.Bottom
        PanelWithUC.Location = New Point(4, 111)
        PanelWithUC.Margin = New Padding(4)
        PanelWithUC.Name = "PanelWithUC"
        PanelWithUC.Size = New Size(2266, 1055)
        PanelWithUC.TabIndex = 30
        ' 
        ' FlowLayoutPanelBackground
        ' 
        FlowLayoutPanelBackground.Controls.Add(PanelWithNavButtons)
        FlowLayoutPanelBackground.Controls.Add(PanelWithUC)
        FlowLayoutPanelBackground.Dock = DockStyle.Fill
        FlowLayoutPanelBackground.Location = New Point(0, 0)
        FlowLayoutPanelBackground.Margin = New Padding(4)
        FlowLayoutPanelBackground.Name = "FlowLayoutPanelBackground"
        FlowLayoutPanelBackground.Size = New Size(1924, 945)
        FlowLayoutPanelBackground.TabIndex = 1
        ' 
        ' StudentDashBoard
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1924, 945)
        Controls.Add(FlowLayoutPanelBackground)
        Margin = New Padding(4)
        Name = "StudentDashBoard"
        Text = "StudentDashBoard"
        PanelWithNavButtons.ResumeLayout(False)
        PanelWithNavButtons.PerformLayout()
        CType(pbxNotify, ComponentModel.ISupportInitialize).EndInit()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        FlowLayoutPanelBackground.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelWithNavButtons As Panel
    Friend WithEvents lblFullName As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MoreOptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutUsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LOGOUTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PanelWithUC As Panel
    Friend WithEvents FlowLayoutPanelBackground As FlowLayoutPanel
    Friend WithEvents btnFileIncident As Button
    Friend WithEvents lblNotify As Label
    Friend WithEvents pbxNotify As PictureBox
End Class
