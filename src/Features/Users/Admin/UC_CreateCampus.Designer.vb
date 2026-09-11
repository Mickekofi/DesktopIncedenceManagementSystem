<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_CreateCampus
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
        PanelWithSearch = New Panel()
        Panel2 = New Panel()
        Label6 = New Label()
        btnDeleteCampus = New Button()
        lbll = New Label()
        txtCampusName = New TextBox()
        Label1 = New Label()
        btnAddCampus = New Button()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        Panel1 = New Panel()
        dgvCampuses = New DataGridView()
        PanelWithDgv = New Panel()
        PanelBackground = New Panel()
        PanelWithSearch.SuspendLayout()
        Panel2.SuspendLayout()
        FlowLayoutPanel1.SuspendLayout()
        Panel1.SuspendLayout()
        CType(dgvCampuses, ComponentModel.ISupportInitialize).BeginInit()
        PanelWithDgv.SuspendLayout()
        PanelBackground.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelWithSearch
        ' 
        PanelWithSearch.BackColor = Color.White
        PanelWithSearch.Controls.Add(Panel2)
        PanelWithSearch.Controls.Add(btnDeleteCampus)
        PanelWithSearch.Controls.Add(lbll)
        PanelWithSearch.Controls.Add(txtCampusName)
        PanelWithSearch.Controls.Add(Label1)
        PanelWithSearch.Controls.Add(btnAddCampus)
        PanelWithSearch.Dock = DockStyle.Top
        PanelWithSearch.Location = New Point(4, 5)
        PanelWithSearch.Margin = New Padding(4, 5, 4, 5)
        PanelWithSearch.Name = "PanelWithSearch"
        PanelWithSearch.Size = New Size(1442, 386)
        PanelWithSearch.TabIndex = 28
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.DarkRed
        Panel2.Controls.Add(Label6)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1442, 72)
        Panel2.TabIndex = 74
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Arial Rounded MT Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.White
        Label6.Location = New Point(42, 9)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(399, 51)
        Label6.TabIndex = 68
        Label6.Text = "Create A Campus"
        ' 
        ' btnDeleteCampus
        ' 
        btnDeleteCampus.BackColor = Color.DarkRed
        btnDeleteCampus.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDeleteCampus.ForeColor = Color.LavenderBlush
        btnDeleteCampus.Location = New Point(285, 242)
        btnDeleteCampus.Margin = New Padding(4, 5, 4, 5)
        btnDeleteCampus.Name = "btnDeleteCampus"
        btnDeleteCampus.Size = New Size(225, 59)
        btnDeleteCampus.TabIndex = 73
        btnDeleteCampus.Text = "Delete"
        btnDeleteCampus.UseVisualStyleBackColor = False
        ' 
        ' lbll
        ' 
        lbll.AutoSize = True
        lbll.BackColor = Color.Transparent
        lbll.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbll.ForeColor = Color.Black
        lbll.Location = New Point(48, 110)
        lbll.Margin = New Padding(4, 0, 4, 0)
        lbll.Name = "lbll"
        lbll.Size = New Size(81, 32)
        lbll.TabIndex = 69
        lbll.Text = "Name"
        ' 
        ' txtCampusName
        ' 
        txtCampusName.BackColor = SystemColors.ButtonHighlight
        txtCampusName.Font = New Font("Garamond", 14.25F)
        txtCampusName.Location = New Point(48, 158)
        txtCampusName.Margin = New Padding(4, 5, 4, 5)
        txtCampusName.Name = "txtCampusName"
        txtCampusName.Size = New Size(462, 40)
        txtCampusName.TabIndex = 67
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.DarkSlateGray
        Label1.Location = New Point(389, 46)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(0, 38)
        Label1.TabIndex = 62
        ' 
        ' btnAddCampus
        ' 
        btnAddCampus.BackColor = Color.FromArgb(CByte(0), CByte(64), CByte(64))
        btnAddCampus.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAddCampus.ForeColor = Color.LavenderBlush
        btnAddCampus.Location = New Point(42, 242)
        btnAddCampus.Margin = New Padding(4, 5, 4, 5)
        btnAddCampus.Name = "btnAddCampus"
        btnAddCampus.Size = New Size(225, 59)
        btnAddCampus.TabIndex = 60
        btnAddCampus.Text = "Add Campus"
        btnAddCampus.UseVisualStyleBackColor = False
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.Controls.Add(PanelWithSearch)
        FlowLayoutPanel1.Controls.Add(Panel1)
        FlowLayoutPanel1.Dock = DockStyle.Fill
        FlowLayoutPanel1.Location = New Point(0, 0)
        FlowLayoutPanel1.Margin = New Padding(4)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(1450, 741)
        FlowLayoutPanel1.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(dgvCampuses)
        Panel1.Location = New Point(4, 400)
        Panel1.Margin = New Padding(4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1337, 970)
        Panel1.TabIndex = 30
        ' 
        ' dgvCampuses
        ' 
        dgvCampuses.BackgroundColor = Color.White
        dgvCampuses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCampuses.Location = New Point(4, 5)
        dgvCampuses.Margin = New Padding(4)
        dgvCampuses.Name = "dgvCampuses"
        dgvCampuses.RowHeadersWidth = 51
        dgvCampuses.Size = New Size(1329, 938)
        dgvCampuses.TabIndex = 0
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
        PanelWithDgv.Size = New Size(1450, 741)
        PanelWithDgv.TabIndex = 4
        ' 
        ' PanelBackground
        ' 
        PanelBackground.Controls.Add(PanelWithDgv)
        PanelBackground.Dock = DockStyle.Fill
        PanelBackground.Location = New Point(0, 0)
        PanelBackground.Margin = New Padding(4)
        PanelBackground.Name = "PanelBackground"
        PanelBackground.Size = New Size(1450, 741)
        PanelBackground.TabIndex = 3
        ' 
        ' UC_CreateCampus
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(PanelBackground)
        Name = "UC_CreateCampus"
        Size = New Size(1450, 741)
        PanelWithSearch.ResumeLayout(False)
        PanelWithSearch.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        FlowLayoutPanel1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        CType(dgvCampuses, ComponentModel.ISupportInitialize).EndInit()
        PanelWithDgv.ResumeLayout(False)
        PanelBackground.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelWithSearch As Panel
    Friend WithEvents btnDeleteCampus As Button
    Friend WithEvents cmbSearch As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lbll As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCampusName As TextBox
    Friend WithEvents cmbIncidentSeverity As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAddCampus As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvCampuses As DataGridView
    Friend WithEvents PanelWithDgv As Panel
    Friend WithEvents PanelBackground As Panel
    Friend WithEvents Panel2 As Panel

End Class
