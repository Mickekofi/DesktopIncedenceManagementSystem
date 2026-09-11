<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_HandleIncidence
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
        lblFullName = New Label()
        Label2 = New Label()
        Label9 = New Label()
        btnInitiate = New Button()
        Label7 = New Label()
        cmbTaskStatus = New ComboBox()
        Panel6 = New Panel()
        Label6 = New Label()
        cmbUserName = New ComboBox()
        PanelInputBundle = New Panel()
        Panel8 = New Panel()
        lblCategory = New Label()
        Label11 = New Label()
        Panel7 = New Panel()
        lblStudentLocation = New Label()
        txtIncidentLocation = New TextBox()
        Panel4 = New Panel()
        btnUploadPhoto = New Button()
        pbxImageEvidence = New PictureBox()
        Panel5 = New Panel()
        Label5 = New Label()
        Label1 = New Label()
        txtDescription = New TextBox()
        Label4 = New Label()
        txtTitle = New TextBox()
        Label3 = New Label()
        PanelRedDesign = New Panel()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        Panel6.SuspendLayout()
        PanelInputBundle.SuspendLayout()
        Panel8.SuspendLayout()
        Panel7.SuspendLayout()
        Panel4.SuspendLayout()
        CType(pbxImageEvidence, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblFullName
        ' 
        lblFullName.AutoSize = True
        lblFullName.BackColor = Color.Transparent
        lblFullName.Font = New Font("Garamond", 13.8F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblFullName.ForeColor = Color.Black
        lblFullName.Location = New Point(229, 118)
        lblFullName.Margin = New Padding(4, 0, 4, 0)
        lblFullName.Name = "lblFullName"
        lblFullName.Size = New Size(239, 31)
        lblFullName.TabIndex = 41
        lblFullName.Text = "Prudent Bobie Desmond"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.White
        Label2.Location = New Point(28, 15)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(668, 61)
        Label2.TabIndex = 23
        Label2.Text = "Current Active Incident *Feeds"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.Black
        Label9.Location = New Point(12, 119)
        Label9.Margin = New Padding(4, 0, 4, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(193, 33)
        Label9.TabIndex = 39
        Label9.Text = "Student Name"
        ' 
        ' btnInitiate
        ' 
        btnInitiate.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnInitiate.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnInitiate.ForeColor = Color.White
        btnInitiate.Location = New Point(229, 301)
        btnInitiate.Margin = New Padding(4, 5, 4, 5)
        btnInitiate.Name = "btnInitiate"
        btnInitiate.Size = New Size(282, 61)
        btnInitiate.TabIndex = 36
        btnInitiate.Text = "Initiate"
        btnInitiate.UseVisualStyleBackColor = False
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.Black
        Label7.Location = New Point(12, 220)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(163, 33)
        Label7.TabIndex = 30
        Label7.Text = "Work Status"
        ' 
        ' cmbTaskStatus
        ' 
        cmbTaskStatus.BackColor = SystemColors.Info
        cmbTaskStatus.Font = New Font("Garamond", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbTaskStatus.ForeColor = Color.Red
        cmbTaskStatus.FormattingEnabled = True
        cmbTaskStatus.Items.AddRange(New Object() {"South Patrol Team", "North Patrol Team", "Central Patrol Team", "Ajumako Patrol Team"})
        cmbTaskStatus.Location = New Point(229, 214)
        cmbTaskStatus.Margin = New Padding(4, 5, 4, 5)
        cmbTaskStatus.Name = "cmbTaskStatus"
        cmbTaskStatus.Size = New Size(353, 44)
        cmbTaskStatus.TabIndex = 29
        cmbTaskStatus.Text = "--Select--"
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.WhiteSmoke
        Panel6.Controls.Add(lblFullName)
        Panel6.Controls.Add(Label9)
        Panel6.Controls.Add(btnInitiate)
        Panel6.Controls.Add(Label7)
        Panel6.Controls.Add(cmbTaskStatus)
        Panel6.Controls.Add(Label6)
        Panel6.Controls.Add(cmbUserName)
        Panel6.Location = New Point(4, 133)
        Panel6.Margin = New Padding(4)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(664, 712)
        Panel6.TabIndex = 7
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.Black
        Label6.Location = New Point(8, 46)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(198, 33)
        Label6.TabIndex = 28
        Label6.Text = "Index Number"
        ' 
        ' cmbUserName
        ' 
        cmbUserName.BackColor = SystemColors.Info
        cmbUserName.Font = New Font("Garamond", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbUserName.ForeColor = Color.Red
        cmbUserName.FormattingEnabled = True
        cmbUserName.Items.AddRange(New Object() {"Rape Case at Ghartey Hall", "Fight at Entrance", "Couples Fighting", "Theft in  the hall", "Fighting with taxi drivers", ""})
        cmbUserName.Location = New Point(229, 42)
        cmbUserName.Margin = New Padding(4, 5, 4, 5)
        cmbUserName.Name = "cmbUserName"
        cmbUserName.Size = New Size(413, 44)
        cmbUserName.TabIndex = 27
        cmbUserName.Text = "--Select--"
        ' 
        ' PanelInputBundle
        ' 
        PanelInputBundle.AutoScroll = True
        PanelInputBundle.BackColor = Color.White
        PanelInputBundle.Controls.Add(Panel8)
        PanelInputBundle.Controls.Add(Label11)
        PanelInputBundle.Controls.Add(Panel7)
        PanelInputBundle.Controls.Add(txtIncidentLocation)
        PanelInputBundle.Controls.Add(Panel4)
        PanelInputBundle.Controls.Add(Panel5)
        PanelInputBundle.Controls.Add(Label5)
        PanelInputBundle.Controls.Add(Label1)
        PanelInputBundle.Controls.Add(txtDescription)
        PanelInputBundle.Controls.Add(Label4)
        PanelInputBundle.Controls.Add(txtTitle)
        PanelInputBundle.Controls.Add(Label3)
        PanelInputBundle.Location = New Point(673, 98)
        PanelInputBundle.Margin = New Padding(4, 5, 4, 5)
        PanelInputBundle.Name = "PanelInputBundle"
        PanelInputBundle.Size = New Size(1075, 920)
        PanelInputBundle.TabIndex = 4
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.White
        Panel8.Controls.Add(lblCategory)
        Panel8.Location = New Point(52, 1277)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(939, 90)
        Panel8.TabIndex = 69
        ' 
        ' lblCategory
        ' 
        lblCategory.AutoSize = True
        lblCategory.BackColor = Color.Transparent
        lblCategory.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCategory.ForeColor = Color.Black
        lblCategory.Location = New Point(360, 17)
        lblCategory.Margin = New Padding(4, 0, 4, 0)
        lblCategory.Name = "lblCategory"
        lblCategory.Size = New Size(23, 33)
        lblCategory.TabIndex = 69
        lblCategory.Text = "!"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.Black
        Label11.Location = New Point(406, 1075)
        Label11.Margin = New Padding(4, 0, 4, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(226, 33)
        Label11.TabIndex = 68
        Label11.Text = "Student Location"
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = Color.White
        Panel7.Controls.Add(lblStudentLocation)
        Panel7.Location = New Point(36, 1124)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(939, 65)
        Panel7.TabIndex = 67
        ' 
        ' lblStudentLocation
        ' 
        lblStudentLocation.AutoSize = True
        lblStudentLocation.BackColor = Color.Transparent
        lblStudentLocation.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStudentLocation.ForeColor = Color.Black
        lblStudentLocation.Location = New Point(370, 12)
        lblStudentLocation.Margin = New Padding(4, 0, 4, 0)
        lblStudentLocation.Name = "lblStudentLocation"
        lblStudentLocation.Size = New Size(23, 33)
        lblStudentLocation.TabIndex = 69
        lblStudentLocation.Text = "!"
        ' 
        ' txtIncidentLocation
        ' 
        txtIncidentLocation.BackColor = Color.White
        txtIncidentLocation.Font = New Font("Garamond", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtIncidentLocation.ForeColor = SystemColors.ActiveCaptionText
        txtIncidentLocation.Location = New Point(36, 993)
        txtIncidentLocation.Margin = New Padding(4, 5, 4, 5)
        txtIncidentLocation.Multiline = True
        txtIncidentLocation.Name = "txtIncidentLocation"
        txtIncidentLocation.Size = New Size(939, 55)
        txtIncidentLocation.TabIndex = 66
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(btnUploadPhoto)
        Panel4.Controls.Add(pbxImageEvidence)
        Panel4.Location = New Point(328, 22)
        Panel4.Margin = New Padding(4, 5, 4, 5)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(382, 375)
        Panel4.TabIndex = 63
        ' 
        ' btnUploadPhoto
        ' 
        btnUploadPhoto.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnUploadPhoto.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUploadPhoto.ForeColor = Color.White
        btnUploadPhoto.Location = New Point(41, 300)
        btnUploadPhoto.Margin = New Padding(4, 5, 4, 5)
        btnUploadPhoto.Name = "btnUploadPhoto"
        btnUploadPhoto.Size = New Size(290, 49)
        btnUploadPhoto.TabIndex = 35
        btnUploadPhoto.Text = "Image Evidence "
        btnUploadPhoto.UseVisualStyleBackColor = False
        ' 
        ' pbxImageEvidence
        ' 
        pbxImageEvidence.BackColor = Color.White
        pbxImageEvidence.Location = New Point(20, 16)
        pbxImageEvidence.Margin = New Padding(4, 5, 4, 5)
        pbxImageEvidence.Name = "pbxImageEvidence"
        pbxImageEvidence.Size = New Size(325, 274)
        pbxImageEvidence.SizeMode = PictureBoxSizeMode.StretchImage
        pbxImageEvidence.TabIndex = 0
        pbxImageEvidence.TabStop = False
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.DarkRed
        Panel5.Location = New Point(302, 56)
        Panel5.Margin = New Padding(4, 5, 4, 5)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(321, 232)
        Panel5.TabIndex = 64
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.Black
        Label5.Location = New Point(434, 1228)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(127, 33)
        Label5.TabIndex = 34
        Label5.Text = "Category"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(406, 944)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(235, 33)
        Label1.TabIndex = 33
        Label1.Text = "Incident Location"
        ' 
        ' txtDescription
        ' 
        txtDescription.BackColor = Color.White
        txtDescription.Font = New Font("Garamond", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtDescription.ForeColor = SystemColors.ActiveCaptionText
        txtDescription.Location = New Point(36, 620)
        txtDescription.Margin = New Padding(4, 5, 4, 5)
        txtDescription.Multiline = True
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(939, 268)
        txtDescription.TabIndex = 31
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.Black
        Label4.Location = New Point(435, 565)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(160, 33)
        Label4.TabIndex = 30
        Label4.Text = "Description"
        ' 
        ' txtTitle
        ' 
        txtTitle.BackColor = Color.White
        txtTitle.Font = New Font("Garamond", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtTitle.ForeColor = SystemColors.ActiveCaptionText
        txtTitle.Location = New Point(36, 466)
        txtTitle.Margin = New Padding(4, 5, 4, 5)
        txtTitle.Multiline = True
        txtTitle.Name = "txtTitle"
        txtTitle.Size = New Size(939, 72)
        txtTitle.TabIndex = 15
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(474, 415)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(74, 33)
        Label3.TabIndex = 14
        Label3.Text = "Title"
        ' 
        ' PanelRedDesign
        ' 
        PanelRedDesign.BackColor = Color.DarkSlateGray
        PanelRedDesign.Location = New Point(646, 803)
        PanelRedDesign.Margin = New Padding(4, 5, 4, 5)
        PanelRedDesign.Name = "PanelRedDesign"
        PanelRedDesign.Size = New Size(27, 839)
        PanelRedDesign.TabIndex = 5
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.BackColor = SystemColors.Menu
        Panel1.Controls.Add(Panel6)
        Panel1.Controls.Add(PanelInputBundle)
        Panel1.Controls.Add(PanelRedDesign)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(Panel3)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(2251, 1014)
        Panel1.TabIndex = 3
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.DarkRed
        Panel2.Controls.Add(Label2)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 0)
        Panel2.Margin = New Padding(4)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(2225, 89)
        Panel2.TabIndex = 0
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.DarkRed
        Panel3.Location = New Point(12, 848)
        Panel3.Margin = New Padding(4, 5, 4, 5)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(644, 28)
        Panel3.TabIndex = 6
        ' 
        ' UC_HandleIncidence
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel1)
        Margin = New Padding(4)
        Name = "UC_HandleIncidence"
        Size = New Size(2251, 1014)
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        PanelInputBundle.ResumeLayout(False)
        PanelInputBundle.PerformLayout()
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        Panel4.ResumeLayout(False)
        CType(pbxImageEvidence, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblFullName As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnInitiate As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbTaskStatus As ComboBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbUserName As ComboBox
    Friend WithEvents PanelInputBundle As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents lblCategory As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents lblStudentLocation As Label
    Friend WithEvents txtIncidentLocation As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnUploadPhoto As Button
    Friend WithEvents pbxImageEvidence As PictureBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PanelRedDesign As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel

End Class
