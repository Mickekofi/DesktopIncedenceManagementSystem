<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_History
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
        Panel = New Panel()
        PanelWithDgv = New Panel()
        dgvHistory = New DataGridView()
        PanelWithCrudButtons = New Panel()
        Button2 = New Button()
        Label2 = New Label()
        PanelWithSearch = New Panel()
        cmbDateRange = New ComboBox()
        Label10 = New Label()
        cmbStatusFilter = New ComboBox()
        Label1 = New Label()
        btnSearch = New Button()
        Panel1.SuspendLayout()
        Panel.SuspendLayout()
        PanelWithDgv.SuspendLayout()
        CType(dgvHistory, ComponentModel.ISupportInitialize).BeginInit()
        PanelWithCrudButtons.SuspendLayout()
        PanelWithSearch.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(Panel)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(4, 5, 4, 5)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1539, 1006)
        Panel1.TabIndex = 7
        ' 
        ' Panel
        ' 
        Panel.AutoScroll = True
        Panel.BackColor = Color.White
        Panel.Controls.Add(PanelWithDgv)
        Panel.Controls.Add(PanelWithCrudButtons)
        Panel.Controls.Add(PanelWithSearch)
        Panel.Dock = DockStyle.Fill
        Panel.Location = New Point(0, 0)
        Panel.Margin = New Padding(4, 5, 4, 5)
        Panel.Name = "Panel"
        Panel.Size = New Size(1539, 1006)
        Panel.TabIndex = 2
        ' 
        ' PanelWithDgv
        ' 
        PanelWithDgv.Controls.Add(dgvHistory)
        PanelWithDgv.Dock = DockStyle.Bottom
        PanelWithDgv.Location = New Point(0, 336)
        PanelWithDgv.Margin = New Padding(4)
        PanelWithDgv.Name = "PanelWithDgv"
        PanelWithDgv.Size = New Size(1535, 809)
        PanelWithDgv.TabIndex = 30
        ' 
        ' dgvHistory
        ' 
        dgvHistory.BackgroundColor = Color.WhiteSmoke
        dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvHistory.Location = New Point(4, 9)
        dgvHistory.Margin = New Padding(4)
        dgvHistory.Name = "dgvHistory"
        dgvHistory.RowHeadersWidth = 51
        dgvHistory.Size = New Size(1333, 804)
        dgvHistory.TabIndex = 0
        ' 
        ' PanelWithCrudButtons
        ' 
        PanelWithCrudButtons.BackColor = Color.WhiteSmoke
        PanelWithCrudButtons.Controls.Add(Button2)
        PanelWithCrudButtons.Controls.Add(Label2)
        PanelWithCrudButtons.Dock = DockStyle.Top
        PanelWithCrudButtons.Location = New Point(0, 0)
        PanelWithCrudButtons.Margin = New Padding(4, 5, 4, 5)
        PanelWithCrudButtons.Name = "PanelWithCrudButtons"
        PanelWithCrudButtons.Size = New Size(1535, 90)
        PanelWithCrudButtons.TabIndex = 29
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.DarkRed
        Button2.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.White
        Button2.Location = New Point(1032, 5)
        Button2.Margin = New Padding(4, 5, 4, 5)
        Button2.Name = "Button2"
        Button2.Size = New Size(342, 74)
        Button2.TabIndex = 38
        Button2.Text = "Export Transactions"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.DarkRed
        Label2.Location = New Point(36, 0)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(440, 61)
        Label2.TabIndex = 22
        Label2.Text = "My Reports History"
        ' 
        ' PanelWithSearch
        ' 
        PanelWithSearch.BackColor = Color.WhiteSmoke
        PanelWithSearch.Controls.Add(btnSearch)
        PanelWithSearch.Controls.Add(Label1)
        PanelWithSearch.Controls.Add(cmbStatusFilter)
        PanelWithSearch.Controls.Add(cmbDateRange)
        PanelWithSearch.Controls.Add(Label10)
        PanelWithSearch.Location = New Point(4, 89)
        PanelWithSearch.Margin = New Padding(4, 5, 4, 5)
        PanelWithSearch.Name = "PanelWithSearch"
        PanelWithSearch.Size = New Size(1531, 247)
        PanelWithSearch.TabIndex = 27
        ' 
        ' cmbDateRange
        ' 
        cmbDateRange.BackColor = SystemColors.Info
        cmbDateRange.Font = New Font("Garamond", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbDateRange.ForeColor = Color.Red
        cmbDateRange.FormattingEnabled = True
        cmbDateRange.Location = New Point(204, 28)
        cmbDateRange.Margin = New Padding(4, 5, 4, 5)
        cmbDateRange.Name = "cmbDateRange"
        cmbDateRange.Size = New Size(282, 44)
        cmbDateRange.TabIndex = 27
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.Transparent
        Label10.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.Black
        Label10.Location = New Point(36, 32)
        Label10.Margin = New Padding(4, 0, 4, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(149, 33)
        Label10.TabIndex = 18
        Label10.Text = "Filter Date"
        ' 
        ' cmbStatusFilter
        ' 
        cmbStatusFilter.BackColor = SystemColors.Info
        cmbStatusFilter.Font = New Font("Garamond", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbStatusFilter.ForeColor = Color.Red
        cmbStatusFilter.FormattingEnabled = True
        cmbStatusFilter.Location = New Point(204, 102)
        cmbStatusFilter.Margin = New Padding(4, 5, 4, 5)
        cmbStatusFilter.Name = "cmbStatusFilter"
        cmbStatusFilter.Size = New Size(282, 44)
        cmbStatusFilter.TabIndex = 28
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(32, 113)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(164, 33)
        Label1.TabIndex = 29
        Label1.Text = "Filter Status"
        ' 
        ' btnSearch
        ' 
        btnSearch.BackColor = Color.DarkRed
        btnSearch.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSearch.ForeColor = Color.White
        btnSearch.Location = New Point(204, 173)
        btnSearch.Margin = New Padding(4, 5, 4, 5)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(241, 52)
        btnSearch.TabIndex = 39
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = False
        ' 
        ' UC_History
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel1)
        Margin = New Padding(4)
        Name = "UC_History"
        Size = New Size(1539, 1006)
        Panel1.ResumeLayout(False)
        Panel.ResumeLayout(False)
        PanelWithDgv.ResumeLayout(False)
        CType(dgvHistory, ComponentModel.ISupportInitialize).EndInit()
        PanelWithCrudButtons.ResumeLayout(False)
        PanelWithCrudButtons.PerformLayout()
        PanelWithSearch.ResumeLayout(False)
        PanelWithSearch.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvApplicants As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel As Panel
    Friend WithEvents PanelWithCrudButtons As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents PanelWithSearch As Panel
    Friend WithEvents cmbDateRange As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents PanelWithDgv As Panel
    Friend WithEvents dgvHistory As DataGridView
    Friend WithEvents cmbStatusFilter As ComboBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents Label1 As Label

End Class
