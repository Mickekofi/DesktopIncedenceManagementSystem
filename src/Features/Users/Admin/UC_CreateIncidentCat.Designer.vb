<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_CreateIncidentCat
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
        txtIncidentCategoryName = New TextBox()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        PanelWithSearch = New Panel()
        txtSearch = New TextBox()
        Panel2 = New Panel()
        Label6 = New Label()
        btnDelete = New Button()
        Label2 = New Label()
        lbll = New Label()
        cmbIncidentSeverity = New ComboBox()
        Label1 = New Label()
        btnAddCategory = New Button()
        Panel1 = New Panel()
        dgvIncidentCat = New DataGridView()
        PanelWithDgv = New Panel()
        PanelBackground = New Panel()
        Qu = New Label()
        FlowLayoutPanel1.SuspendLayout()
        PanelWithSearch.SuspendLayout()
        Panel2.SuspendLayout()
        Panel1.SuspendLayout()
        CType(dgvIncidentCat, ComponentModel.ISupportInitialize).BeginInit()
        PanelWithDgv.SuspendLayout()
        PanelBackground.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtIncidentCategoryName
        ' 
        txtIncidentCategoryName.BackColor = SystemColors.ButtonHighlight
        txtIncidentCategoryName.Font = New Font("Garamond", 14.25F)
        txtIncidentCategoryName.Location = New Point(45, 128)
        txtIncidentCategoryName.Margin = New Padding(4, 5, 4, 5)
        txtIncidentCategoryName.Name = "txtIncidentCategoryName"
        txtIncidentCategoryName.Size = New Size(461, 40)
        txtIncidentCategoryName.TabIndex = 67
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.Controls.Add(PanelWithSearch)
        FlowLayoutPanel1.Controls.Add(Panel1)
        FlowLayoutPanel1.Dock = DockStyle.Fill
        FlowLayoutPanel1.Location = New Point(0, 0)
        FlowLayoutPanel1.Margin = New Padding(4)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(1347, 705)
        FlowLayoutPanel1.TabIndex = 0
        ' 
        ' PanelWithSearch
        ' 
        PanelWithSearch.BackColor = Color.White
        PanelWithSearch.Controls.Add(Qu)
        PanelWithSearch.Controls.Add(txtSearch)
        PanelWithSearch.Controls.Add(Panel2)
        PanelWithSearch.Controls.Add(btnDelete)
        PanelWithSearch.Controls.Add(Label2)
        PanelWithSearch.Controls.Add(lbll)
        PanelWithSearch.Controls.Add(txtIncidentCategoryName)
        PanelWithSearch.Controls.Add(cmbIncidentSeverity)
        PanelWithSearch.Controls.Add(Label1)
        PanelWithSearch.Controls.Add(btnAddCategory)
        PanelWithSearch.Location = New Point(4, 5)
        PanelWithSearch.Margin = New Padding(4, 5, 4, 5)
        PanelWithSearch.Name = "PanelWithSearch"
        PanelWithSearch.Size = New Size(1337, 386)
        PanelWithSearch.TabIndex = 28
        ' 
        ' txtSearch
        ' 
        txtSearch.BackColor = SystemColors.ButtonHighlight
        txtSearch.Font = New Font("Garamond", 14.25F)
        txtSearch.Location = New Point(634, 128)
        txtSearch.Margin = New Padding(4, 5, 4, 5)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(386, 40)
        txtSearch.TabIndex = 76
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.DarkRed
        Panel2.Controls.Add(Label6)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1337, 72)
        Panel2.TabIndex = 75
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
        Label6.Size = New Size(421, 51)
        Label6.TabIndex = 68
        Label6.Text = "Create A Category"
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.DarkRed
        btnDelete.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDelete.ForeColor = Color.LavenderBlush
        btnDelete.Location = New Point(281, 279)
        btnDelete.Margin = New Padding(4, 5, 4, 5)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(225, 59)
        btnDelete.TabIndex = 73
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(45, 191)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(169, 32)
        Label2.TabIndex = 71
        Label2.Text = "Rank Severity"
        ' 
        ' lbll
        ' 
        lbll.AutoSize = True
        lbll.BackColor = Color.Transparent
        lbll.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbll.ForeColor = Color.Black
        lbll.Location = New Point(48, 85)
        lbll.Margin = New Padding(4, 0, 4, 0)
        lbll.Name = "lbll"
        lbll.Size = New Size(81, 32)
        lbll.TabIndex = 69
        lbll.Text = "Name"
        ' 
        ' cmbIncidentSeverity
        ' 
        cmbIncidentSeverity.Font = New Font("Garamond", 14.25F, FontStyle.Bold)
        cmbIncidentSeverity.ForeColor = Color.DarkSlateGray
        cmbIncidentSeverity.FormattingEnabled = True
        cmbIncidentSeverity.Location = New Point(48, 228)
        cmbIncidentSeverity.Margin = New Padding(4, 5, 4, 5)
        cmbIncidentSeverity.Name = "cmbIncidentSeverity"
        cmbIncidentSeverity.Size = New Size(458, 41)
        cmbIncidentSeverity.TabIndex = 65
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.DarkSlateGray
        Label1.Location = New Point(389, 46)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(0, 38)
        Label1.TabIndex = 62
        ' 
        ' btnAddCategory
        ' 
        btnAddCategory.BackColor = Color.FromArgb(CByte(0), CByte(64), CByte(64))
        btnAddCategory.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAddCategory.ForeColor = Color.LavenderBlush
        btnAddCategory.Location = New Point(48, 279)
        btnAddCategory.Margin = New Padding(4, 5, 4, 5)
        btnAddCategory.Name = "btnAddCategory"
        btnAddCategory.Size = New Size(225, 59)
        btnAddCategory.TabIndex = 60
        btnAddCategory.Text = "Add Category"
        btnAddCategory.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(dgvIncidentCat)
        Panel1.Location = New Point(4, 400)
        Panel1.Margin = New Padding(4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1337, 970)
        Panel1.TabIndex = 30
        ' 
        ' dgvIncidentCat
        ' 
        dgvIncidentCat.BackgroundColor = Color.White
        dgvIncidentCat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvIncidentCat.Location = New Point(4, 5)
        dgvIncidentCat.Margin = New Padding(4)
        dgvIncidentCat.Name = "dgvIncidentCat"
        dgvIncidentCat.RowHeadersWidth = 51
        dgvIncidentCat.Size = New Size(1329, 938)
        dgvIncidentCat.TabIndex = 0
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
        PanelWithDgv.Size = New Size(1347, 705)
        PanelWithDgv.TabIndex = 4
        ' 
        ' PanelBackground
        ' 
        PanelBackground.Controls.Add(PanelWithDgv)
        PanelBackground.Dock = DockStyle.Fill
        PanelBackground.Location = New Point(0, 0)
        PanelBackground.Margin = New Padding(4)
        PanelBackground.Name = "PanelBackground"
        PanelBackground.Size = New Size(1347, 705)
        PanelBackground.TabIndex = 2
        ' 
        ' Qu
        ' 
        Qu.AutoSize = True
        Qu.BackColor = Color.Transparent
        Qu.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Qu.ForeColor = Color.Black
        Qu.Location = New Point(634, 86)
        Qu.Margin = New Padding(4, 0, 4, 0)
        Qu.Name = "Qu"
        Qu.Size = New Size(112, 33)
        Qu.TabIndex = 77
        Qu.Text = "*Search"
        ' 
        ' UC_CreateIncidentCat
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(PanelBackground)
        Name = "UC_CreateIncidentCat"
        Size = New Size(1347, 705)
        FlowLayoutPanel1.ResumeLayout(False)
        PanelWithSearch.ResumeLayout(False)
        PanelWithSearch.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel1.ResumeLayout(False)
        CType(dgvIncidentCat, ComponentModel.ISupportInitialize).EndInit()
        PanelWithDgv.ResumeLayout(False)
        PanelBackground.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvIncidentCat As DataGridView
    Friend WithEvents txtIncidentCategoryName As TextBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents PanelWithSearch As Panel
    Friend WithEvents cmbIncidentSeverity As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAddCategory As Button
    Friend WithEvents PanelWithDgv As Panel
    Friend WithEvents PanelBackground As Panel
    Friend WithEvents lbll As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Qu As Label

End Class
