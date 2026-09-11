<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Notification
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
        PanelBackground = New Panel()
        PanelWithDgv = New Panel()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        PanelWithSearch = New Panel()
        Label2 = New Label()
        cmbIncidentStatus = New ComboBox()
        lba = New Label()
        cmbSelectIncident = New ComboBox()
        Panel2 = New Panel()
        Label6 = New Label()
        Label1 = New Label()
        Panel1 = New Panel()
        dgvNotification = New DataGridView()
        PanelBackground.SuspendLayout()
        PanelWithDgv.SuspendLayout()
        FlowLayoutPanel1.SuspendLayout()
        PanelWithSearch.SuspendLayout()
        Panel2.SuspendLayout()
        Panel1.SuspendLayout()
        CType(dgvNotification, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PanelBackground
        ' 
        PanelBackground.Controls.Add(PanelWithDgv)
        PanelBackground.Dock = DockStyle.Fill
        PanelBackground.Location = New Point(0, 0)
        PanelBackground.Margin = New Padding(4)
        PanelBackground.Name = "PanelBackground"
        PanelBackground.Size = New Size(1350, 1259)
        PanelBackground.TabIndex = 3
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
        PanelWithDgv.Size = New Size(1350, 1259)
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
        FlowLayoutPanel1.Size = New Size(1350, 1259)
        FlowLayoutPanel1.TabIndex = 0
        ' 
        ' PanelWithSearch
        ' 
        PanelWithSearch.BackColor = Color.White
        PanelWithSearch.Controls.Add(Label2)
        PanelWithSearch.Controls.Add(cmbIncidentStatus)
        PanelWithSearch.Controls.Add(lba)
        PanelWithSearch.Controls.Add(cmbSelectIncident)
        PanelWithSearch.Controls.Add(Panel2)
        PanelWithSearch.Controls.Add(Label1)
        PanelWithSearch.Location = New Point(4, 5)
        PanelWithSearch.Margin = New Padding(4, 5, 4, 5)
        PanelWithSearch.Name = "PanelWithSearch"
        PanelWithSearch.Size = New Size(1337, 226)
        PanelWithSearch.TabIndex = 28
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(518, 92)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(308, 33)
        Label2.TabIndex = 81
        Label2.Text = "*Filter Incidence Status"
        ' 
        ' cmbIncidentStatus
        ' 
        cmbIncidentStatus.Font = New Font("Garamond", 14.25F, FontStyle.Bold)
        cmbIncidentStatus.ForeColor = Color.DarkSlateGray
        cmbIncidentStatus.FormattingEnabled = True
        cmbIncidentStatus.Location = New Point(518, 142)
        cmbIncidentStatus.Margin = New Padding(4, 5, 4, 5)
        cmbIncidentStatus.Name = "cmbIncidentStatus"
        cmbIncidentStatus.Size = New Size(458, 41)
        cmbIncidentStatus.TabIndex = 80
        ' 
        ' lba
        ' 
        lba.AutoSize = True
        lba.BackColor = Color.Transparent
        lba.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lba.ForeColor = Color.Black
        lba.Location = New Point(31, 92)
        lba.Margin = New Padding(4, 0, 4, 0)
        lba.Name = "lba"
        lba.Size = New Size(233, 33)
        lba.TabIndex = 79
        lba.Text = "*Select Incidence"
        ' 
        ' cmbSelectIncident
        ' 
        cmbSelectIncident.Font = New Font("Garamond", 14.25F, FontStyle.Bold)
        cmbSelectIncident.ForeColor = Color.DarkSlateGray
        cmbSelectIncident.FormattingEnabled = True
        cmbSelectIncident.Location = New Point(31, 142)
        cmbSelectIncident.Margin = New Padding(4, 5, 4, 5)
        cmbSelectIncident.Name = "cmbSelectIncident"
        cmbSelectIncident.Size = New Size(458, 41)
        cmbSelectIncident.TabIndex = 78
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
        Label6.Size = New Size(402, 51)
        Label6.TabIndex = 68
        Label6.Text = "Notification Panel"
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
        ' Panel1
        ' 
        Panel1.Controls.Add(dgvNotification)
        Panel1.Location = New Point(4, 240)
        Panel1.Margin = New Padding(4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1337, 970)
        Panel1.TabIndex = 30
        ' 
        ' dgvNotification
        ' 
        dgvNotification.BackgroundColor = Color.White
        dgvNotification.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvNotification.Location = New Point(4, 4)
        dgvNotification.Margin = New Padding(4)
        dgvNotification.Name = "dgvNotification"
        dgvNotification.RowHeadersWidth = 51
        dgvNotification.Size = New Size(1329, 902)
        dgvNotification.TabIndex = 0
        ' 
        ' UC_Notification
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(PanelBackground)
        Margin = New Padding(4)
        Name = "UC_Notification"
        Size = New Size(1350, 1259)
        PanelBackground.ResumeLayout(False)
        PanelWithDgv.ResumeLayout(False)
        FlowLayoutPanel1.ResumeLayout(False)
        PanelWithSearch.ResumeLayout(False)
        PanelWithSearch.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel1.ResumeLayout(False)
        CType(dgvNotification, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelBackground As Panel
    Friend WithEvents PanelWithDgv As Panel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents PanelWithSearch As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents lbll As Label
    Friend WithEvents txtIncidentCategoryName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAddCategory As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvNotification As DataGridView
    Friend WithEvents lba As Label
    Friend WithEvents cmbSelectIncident As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbIncidentStatus As ComboBox

End Class
