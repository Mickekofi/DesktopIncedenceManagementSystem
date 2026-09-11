<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_EntrollStudents
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
        Panel1 = New Panel()
        Pnl = New Panel()
        dgvStudents = New DataGridView()
        PanelWithDgv = New Panel()
        dgvApplicants = New DataGridView()
        PanelWithCrudButtons = New Panel()
        Label2 = New Label()
        PanelWithSearch = New Panel()
        btnDelete = New Button()
        Panel2 = New Panel()
        lblFilePath = New Label()
        btnUpload = New Button()
        PictureBox1 = New PictureBox()
        PanelWithData = New Panel()
        txtIndexNumberSearch = New TextBox()
        Qu = New Label()
        Panel1.SuspendLayout()
        Pnl.SuspendLayout()
        CType(dgvStudents, ComponentModel.ISupportInitialize).BeginInit()
        PanelWithDgv.SuspendLayout()
        CType(dgvApplicants, ComponentModel.ISupportInitialize).BeginInit()
        PanelWithCrudButtons.SuspendLayout()
        PanelWithSearch.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(Pnl)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(4, 5, 4, 5)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1546, 1009)
        Panel1.TabIndex = 6
        ' 
        ' Pnl
        ' 
        Pnl.AutoScroll = True
        Pnl.BackColor = Color.White
        Pnl.Controls.Add(dgvStudents)
        Pnl.Controls.Add(PanelWithDgv)
        Pnl.Controls.Add(PanelWithCrudButtons)
        Pnl.Controls.Add(PanelWithSearch)
        Pnl.Dock = DockStyle.Fill
        Pnl.Location = New Point(0, 0)
        Pnl.Margin = New Padding(4, 5, 4, 5)
        Pnl.Name = "Pnl"
        Pnl.Size = New Size(1546, 1009)
        Pnl.TabIndex = 2
        ' 
        ' dgvStudents
        ' 
        dgvStudents.BackgroundColor = Color.WhiteSmoke
        dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvStudents.Location = New Point(0, 310)
        dgvStudents.Margin = New Padding(4)
        dgvStudents.Name = "dgvStudents"
        dgvStudents.RowHeadersWidth = 51
        dgvStudents.Size = New Size(1368, 699)
        dgvStudents.TabIndex = 0
        ' 
        ' PanelWithDgv
        ' 
        PanelWithDgv.AutoScroll = True
        PanelWithDgv.AutoSize = True
        PanelWithDgv.Controls.Add(dgvApplicants)
        PanelWithDgv.Dock = DockStyle.Bottom
        PanelWithDgv.Location = New Point(0, 1009)
        PanelWithDgv.Margin = New Padding(4)
        PanelWithDgv.Name = "PanelWithDgv"
        PanelWithDgv.Size = New Size(1546, 0)
        PanelWithDgv.TabIndex = 30
        ' 
        ' dgvApplicants
        ' 
        dgvApplicants.BackgroundColor = Color.Black
        dgvApplicants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvApplicants.Dock = DockStyle.Fill
        dgvApplicants.Location = New Point(0, 0)
        dgvApplicants.Margin = New Padding(4)
        dgvApplicants.Name = "dgvApplicants"
        dgvApplicants.RowHeadersWidth = 51
        dgvApplicants.Size = New Size(1546, 0)
        dgvApplicants.TabIndex = 0
        ' 
        ' PanelWithCrudButtons
        ' 
        PanelWithCrudButtons.BackColor = Color.DarkRed
        PanelWithCrudButtons.Controls.Add(Label2)
        PanelWithCrudButtons.Dock = DockStyle.Top
        PanelWithCrudButtons.Location = New Point(0, 0)
        PanelWithCrudButtons.Margin = New Padding(4, 5, 4, 5)
        PanelWithCrudButtons.Name = "PanelWithCrudButtons"
        PanelWithCrudButtons.Size = New Size(1546, 76)
        PanelWithCrudButtons.TabIndex = 29
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.White
        Label2.Location = New Point(38, 9)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(579, 61)
        Label2.TabIndex = 22
        Label2.Text = "Student Enrollment Portal"
        ' 
        ' PanelWithSearch
        ' 
        PanelWithSearch.BackColor = Color.WhiteSmoke
        PanelWithSearch.Controls.Add(btnDelete)
        PanelWithSearch.Controls.Add(Panel2)
        PanelWithSearch.Controls.Add(PanelWithData)
        PanelWithSearch.Controls.Add(txtIndexNumberSearch)
        PanelWithSearch.Controls.Add(Qu)
        PanelWithSearch.Location = New Point(0, 76)
        PanelWithSearch.Margin = New Padding(4, 5, 4, 5)
        PanelWithSearch.Name = "PanelWithSearch"
        PanelWithSearch.Size = New Size(1546, 238)
        PanelWithSearch.TabIndex = 27
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.DarkRed
        btnDelete.Font = New Font("Garamond", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDelete.ForeColor = Color.LavenderBlush
        btnDelete.Location = New Point(20, 168)
        btnDelete.Margin = New Padding(4, 5, 4, 5)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(165, 46)
        btnDelete.TabIndex = 6
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(lblFilePath)
        Panel2.Controls.Add(btnUpload)
        Panel2.Controls.Add(PictureBox1)
        Panel2.Location = New Point(712, 24)
        Panel2.Margin = New Padding(4)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(656, 198)
        Panel2.TabIndex = 28
        ' 
        ' lblFilePath
        ' 
        lblFilePath.AutoSize = True
        lblFilePath.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblFilePath.Location = New Point(89, 31)
        lblFilePath.Margin = New Padding(4, 0, 4, 0)
        lblFilePath.Name = "lblFilePath"
        lblFilePath.Size = New Size(434, 38)
        lblFilePath.TabIndex = 2
        lblFilePath.Text = "File:/Upload_Applicats_with_Excell"
        ' 
        ' btnUpload
        ' 
        btnUpload.BackColor = Color.DarkRed
        btnUpload.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUpload.ForeColor = Color.LavenderBlush
        btnUpload.Location = New Point(21, 96)
        btnUpload.Margin = New Padding(4, 5, 4, 5)
        btnUpload.Name = "btnUpload"
        btnUpload.Size = New Size(341, 68)
        btnUpload.TabIndex = 3
        btnUpload.Text = "UPLOAD"
        btnUpload.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Location = New Point(21, 24)
        PictureBox1.Margin = New Padding(4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(60, 46)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        ' 
        ' PanelWithData
        ' 
        PanelWithData.Location = New Point(4, 234)
        PanelWithData.Margin = New Padding(4)
        PanelWithData.Name = "PanelWithData"
        PanelWithData.Size = New Size(1351, 677)
        PanelWithData.TabIndex = 31
        ' 
        ' txtIndexNumberSearch
        ' 
        txtIndexNumberSearch.BackColor = Color.GhostWhite
        txtIndexNumberSearch.Font = New Font("Garamond", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtIndexNumberSearch.ForeColor = SystemColors.ActiveCaptionText
        txtIndexNumberSearch.Location = New Point(20, 125)
        txtIndexNumberSearch.Margin = New Padding(4, 5, 4, 5)
        txtIndexNumberSearch.Name = "txtIndexNumberSearch"
        txtIndexNumberSearch.Size = New Size(600, 39)
        txtIndexNumberSearch.TabIndex = 27
        ' 
        ' Qu
        ' 
        Qu.AutoSize = True
        Qu.BackColor = Color.Transparent
        Qu.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Qu.ForeColor = Color.Black
        Qu.Location = New Point(20, 84)
        Qu.Margin = New Padding(4, 0, 4, 0)
        Qu.Name = "Qu"
        Qu.Size = New Size(329, 33)
        Qu.TabIndex = 19
        Qu.Text = "Search By Index Number"
        ' 
        ' UC_EntrollStudents
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel1)
        Margin = New Padding(4)
        Name = "UC_EntrollStudents"
        Size = New Size(1546, 1009)
        Panel1.ResumeLayout(False)
        Pnl.ResumeLayout(False)
        Pnl.PerformLayout()
        CType(dgvStudents, ComponentModel.ISupportInitialize).EndInit()
        PanelWithDgv.ResumeLayout(False)
        CType(dgvApplicants, ComponentModel.ISupportInitialize).EndInit()
        PanelWithCrudButtons.ResumeLayout(False)
        PanelWithCrudButtons.PerformLayout()
        PanelWithSearch.ResumeLayout(False)
        PanelWithSearch.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Pnl As Panel
    Friend WithEvents PanelWithCrudButtons As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PanelWithSearch As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblFilePath As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnUpload As Button
    Friend WithEvents txtIndexNumberSearch As TextBox
    Friend WithEvents Qu As Label
    Friend WithEvents PanelWithDgv As Panel
    Friend WithEvents dgvApplicants As DataGridView
    Friend WithEvents PanelWithData As Panel
    Friend WithEvents dgvStudents As DataGridView
    Friend WithEvents btnDelete As Button

End Class
