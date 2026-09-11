<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_ViewPatrolTeams
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        dgvSecurityPatrolTeam = New DataGridView()
        PanelBackground = New Panel()
        PanelWithDgv = New Panel()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        PanelWithSearch = New Panel()
        btnDelete = New Button()
        cmbFilterCampuses = New ComboBox()
        Panel1 = New Panel()
        txtSearch = New TextBox()
        Qu = New Label()
        CType(dgvSecurityPatrolTeam, ComponentModel.ISupportInitialize).BeginInit()
        PanelBackground.SuspendLayout()
        PanelWithDgv.SuspendLayout()
        FlowLayoutPanel1.SuspendLayout()
        PanelWithSearch.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvSecurityPatrolTeam
        ' 
        dgvSecurityPatrolTeam.BackgroundColor = Color.White
        dgvSecurityPatrolTeam.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSecurityPatrolTeam.Location = New Point(4, 4)
        dgvSecurityPatrolTeam.Margin = New Padding(4)
        dgvSecurityPatrolTeam.Name = "dgvSecurityPatrolTeam"
        dgvSecurityPatrolTeam.RowHeadersWidth = 51
        dgvSecurityPatrolTeam.Size = New Size(1386, 880)
        dgvSecurityPatrolTeam.TabIndex = 0
        ' 
        ' PanelBackground
        ' 
        PanelBackground.Controls.Add(PanelWithDgv)
        PanelBackground.Dock = DockStyle.Fill
        PanelBackground.Location = New Point(0, 0)
        PanelBackground.Margin = New Padding(4)
        PanelBackground.Name = "PanelBackground"
        PanelBackground.Size = New Size(1417, 694)
        PanelBackground.TabIndex = 1
        ' 
        ' PanelWithDgv
        ' 
        PanelWithDgv.AutoScroll = True
        PanelWithDgv.BackColor = Color.White
        PanelWithDgv.Controls.Add(FlowLayoutPanel1)
        PanelWithDgv.Dock = DockStyle.Fill
        PanelWithDgv.Location = New Point(0, 0)
        PanelWithDgv.Margin = New Padding(4, 5, 4, 5)
        PanelWithDgv.Name = "PanelWithDgv"
        PanelWithDgv.Size = New Size(1417, 694)
        PanelWithDgv.TabIndex = 4
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.Controls.Add(PanelWithSearch)
        FlowLayoutPanel1.Controls.Add(Panel1)
        FlowLayoutPanel1.Dock = DockStyle.Fill
        FlowLayoutPanel1.Location = New Point(0, 0)
        FlowLayoutPanel1.Margin = New Padding(4)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(1417, 694)
        FlowLayoutPanel1.TabIndex = 0
        ' 
        ' PanelWithSearch
        ' 
        PanelWithSearch.BackColor = Color.White
        PanelWithSearch.Controls.Add(Qu)
        PanelWithSearch.Controls.Add(txtSearch)
        PanelWithSearch.Controls.Add(btnDelete)
        PanelWithSearch.Controls.Add(cmbFilterCampuses)
        PanelWithSearch.Location = New Point(4, 5)
        PanelWithSearch.Margin = New Padding(4, 5, 4, 5)
        PanelWithSearch.Name = "PanelWithSearch"
        PanelWithSearch.Size = New Size(1390, 178)
        PanelWithSearch.TabIndex = 28
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.Red
        btnDelete.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDelete.ForeColor = Color.LavenderBlush
        btnDelete.Location = New Point(983, 15)
        btnDelete.Margin = New Padding(4, 5, 4, 5)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(372, 59)
        btnDelete.TabIndex = 60
        btnDelete.Text = "DELETE"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' cmbFilterCampuses
        ' 
        cmbFilterCampuses.Font = New Font("Garamond", 14.25F, FontStyle.Bold)
        cmbFilterCampuses.ForeColor = Color.DarkSlateGray
        cmbFilterCampuses.FormattingEnabled = True
        cmbFilterCampuses.Location = New Point(531, 25)
        cmbFilterCampuses.Margin = New Padding(4, 5, 4, 5)
        cmbFilterCampuses.Name = "cmbFilterCampuses"
        cmbFilterCampuses.Size = New Size(386, 41)
        cmbFilterCampuses.TabIndex = 59
        cmbFilterCampuses.Text = "--select Campus--"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(dgvSecurityPatrolTeam)
        Panel1.Location = New Point(4, 192)
        Panel1.Margin = New Padding(4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1404, 940)
        Panel1.TabIndex = 29
        ' 
        ' txtSearch
        ' 
        txtSearch.BackColor = SystemColors.ButtonHighlight
        txtSearch.Font = New Font("Garamond", 14.25F)
        txtSearch.Location = New Point(531, 115)
        txtSearch.Margin = New Padding(4, 5, 4, 5)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(386, 40)
        txtSearch.TabIndex = 77
        ' 
        ' Qu
        ' 
        Qu.AutoSize = True
        Qu.BackColor = Color.Transparent
        Qu.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Qu.ForeColor = Color.Black
        Qu.Location = New Point(411, 115)
        Qu.Margin = New Padding(4, 0, 4, 0)
        Qu.Name = "Qu"
        Qu.Size = New Size(112, 33)
        Qu.TabIndex = 78
        Qu.Text = "*Search"
        ' 
        ' UC_ViewPatrolTeams
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(PanelBackground)
        Name = "UC_ViewPatrolTeams"
        Size = New Size(1417, 694)
        CType(dgvSecurityPatrolTeam, ComponentModel.ISupportInitialize).EndInit()
        PanelBackground.ResumeLayout(False)
        PanelWithDgv.ResumeLayout(False)
        FlowLayoutPanel1.ResumeLayout(False)
        PanelWithSearch.ResumeLayout(False)
        PanelWithSearch.PerformLayout()
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvSecurityPatrolTeam As DataGridView
    Friend WithEvents PanelBackground As Panel
    Friend WithEvents PanelWithDgv As Panel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents PanelWithSearch As Panel
    Friend WithEvents btnDelete As Button
    Friend WithEvents cmbFilterCampuses As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Qu As Label

End Class
