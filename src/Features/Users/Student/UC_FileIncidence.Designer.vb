<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_FileIncidence
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
        PanelInputBundle = New Panel()
        Label6 = New Label()
        txtLocation = New TextBox()
        PictureBox1 = New PictureBox()
        Panel4 = New Panel()
        btnUploadIncidentPhoto = New Button()
        pbxIncidentImage = New PictureBox()
        Panel5 = New Panel()
        Label5 = New Label()
        Label1 = New Label()
        cmbIncidentCategory = New ComboBox()
        txtDescription = New TextBox()
        Label4 = New Label()
        btnCreateIncident = New Button()
        cmbCampuses = New ComboBox()
        txtTitle = New TextBox()
        Label3 = New Label()
        PanelRedDesign = New Panel()
        Panel2 = New Panel()
        Label2 = New Label()
        Panel1.SuspendLayout()
        PanelInputBundle.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel4.SuspendLayout()
        CType(pbxIncidentImage, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.Controls.Add(PanelInputBundle)
        Panel1.Controls.Add(PanelRedDesign)
        Panel1.Controls.Add(Panel2)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(2249, 1002)
        Panel1.TabIndex = 1
        ' 
        ' PanelInputBundle
        ' 
        PanelInputBundle.AutoScroll = True
        PanelInputBundle.BackColor = Color.White
        PanelInputBundle.Controls.Add(Label6)
        PanelInputBundle.Controls.Add(txtLocation)
        PanelInputBundle.Controls.Add(PictureBox1)
        PanelInputBundle.Controls.Add(Panel4)
        PanelInputBundle.Controls.Add(Panel5)
        PanelInputBundle.Controls.Add(Label5)
        PanelInputBundle.Controls.Add(Label1)
        PanelInputBundle.Controls.Add(cmbIncidentCategory)
        PanelInputBundle.Controls.Add(txtDescription)
        PanelInputBundle.Controls.Add(Label4)
        PanelInputBundle.Controls.Add(btnCreateIncident)
        PanelInputBundle.Controls.Add(cmbCampuses)
        PanelInputBundle.Controls.Add(txtTitle)
        PanelInputBundle.Controls.Add(Label3)
        PanelInputBundle.Location = New Point(297, 115)
        PanelInputBundle.Margin = New Padding(4, 5, 4, 5)
        PanelInputBundle.Name = "PanelInputBundle"
        PanelInputBundle.Size = New Size(1061, 887)
        PanelInputBundle.TabIndex = 4
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.Black
        Label6.Location = New Point(401, 1073)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(204, 33)
        Label6.TabIndex = 67
        Label6.Text = "Exact Location"
        ' 
        ' txtLocation
        ' 
        txtLocation.BackColor = Color.Ivory
        txtLocation.Font = New Font("Garamond", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtLocation.ForeColor = SystemColors.ActiveCaptionText
        txtLocation.Location = New Point(68, 1120)
        txtLocation.Margin = New Padding(4, 5, 4, 5)
        txtLocation.Name = "txtLocation"
        txtLocation.Size = New Size(939, 48)
        txtLocation.TabIndex = 66
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.White
        PictureBox1.Image = My.Resources.Resources.logo
        PictureBox1.Location = New Point(4, 0)
        PictureBox1.Margin = New Padding(4, 5, 4, 5)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(290, 334)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 65
        PictureBox1.TabStop = False
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(btnUploadIncidentPhoto)
        Panel4.Controls.Add(pbxIncidentImage)
        Panel4.Location = New Point(328, 22)
        Panel4.Margin = New Padding(4, 5, 4, 5)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(328, 312)
        Panel4.TabIndex = 63
        ' 
        ' btnUploadIncidentPhoto
        ' 
        btnUploadIncidentPhoto.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnUploadIncidentPhoto.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUploadIncidentPhoto.ForeColor = Color.White
        btnUploadIncidentPhoto.Location = New Point(18, 259)
        btnUploadIncidentPhoto.Margin = New Padding(4, 5, 4, 5)
        btnUploadIncidentPhoto.Name = "btnUploadIncidentPhoto"
        btnUploadIncidentPhoto.Size = New Size(290, 49)
        btnUploadIncidentPhoto.TabIndex = 35
        btnUploadIncidentPhoto.Text = "Upload Image Evidence "
        btnUploadIncidentPhoto.UseVisualStyleBackColor = False
        ' 
        ' pbxIncidentImage
        ' 
        pbxIncidentImage.BackColor = Color.White
        pbxIncidentImage.Location = New Point(4, 6)
        pbxIncidentImage.Margin = New Padding(4, 5, 4, 5)
        pbxIncidentImage.Name = "pbxIncidentImage"
        pbxIncidentImage.Size = New Size(320, 245)
        pbxIncidentImage.SizeMode = PictureBoxSizeMode.StretchImage
        pbxIncidentImage.TabIndex = 0
        pbxIncidentImage.TabStop = False
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
        Label5.Location = New Point(372, 1216)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(321, 33)
        Label5.TabIndex = 34
        Label5.Text = "Select a related Category"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(346, 940)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(344, 33)
        Label1.TabIndex = 33
        Label1.Text = "Incident Campus Location"
        ' 
        ' cmbIncidentCategory
        ' 
        cmbIncidentCategory.BackColor = SystemColors.Info
        cmbIncidentCategory.Font = New Font("Garamond", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbIncidentCategory.ForeColor = Color.Red
        cmbIncidentCategory.FormattingEnabled = True
        cmbIncidentCategory.Items.AddRange(New Object() {"South Campus", "Central Campus", "North Campus", "Ajumako Campus"})
        cmbIncidentCategory.Location = New Point(54, 1279)
        cmbIncidentCategory.Margin = New Padding(4, 5, 4, 5)
        cmbIncidentCategory.Name = "cmbIncidentCategory"
        cmbIncidentCategory.Size = New Size(953, 44)
        cmbIncidentCategory.TabIndex = 32
        cmbIncidentCategory.Text = "--Select Category--"
        ' 
        ' txtDescription
        ' 
        txtDescription.BackColor = Color.Ivory
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
        ' btnCreateIncident
        ' 
        btnCreateIncident.BackColor = Color.DarkSlateGray
        btnCreateIncident.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCreateIncident.ForeColor = Color.LavenderBlush
        btnCreateIncident.Location = New Point(36, 1360)
        btnCreateIncident.Margin = New Padding(4, 5, 4, 5)
        btnCreateIncident.Name = "btnCreateIncident"
        btnCreateIncident.Size = New Size(341, 68)
        btnCreateIncident.TabIndex = 29
        btnCreateIncident.Text = "Create"
        btnCreateIncident.UseVisualStyleBackColor = False
        ' 
        ' cmbCampuses
        ' 
        cmbCampuses.BackColor = SystemColors.Info
        cmbCampuses.Font = New Font("Garamond", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbCampuses.ForeColor = Color.Red
        cmbCampuses.FormattingEnabled = True
        cmbCampuses.Items.AddRange(New Object() {"South Campus", "Central Campus", "North Campus", "Ajumako Campus"})
        cmbCampuses.Location = New Point(54, 994)
        cmbCampuses.Margin = New Padding(4, 5, 4, 5)
        cmbCampuses.Name = "cmbCampuses"
        cmbCampuses.Size = New Size(953, 44)
        cmbCampuses.TabIndex = 26
        cmbCampuses.Text = "--Select Campus--"
        ' 
        ' txtTitle
        ' 
        txtTitle.BackColor = Color.Ivory
        txtTitle.Font = New Font("Garamond", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtTitle.ForeColor = SystemColors.ActiveCaptionText
        txtTitle.Location = New Point(36, 466)
        txtTitle.Margin = New Padding(4, 5, 4, 5)
        txtTitle.Name = "txtTitle"
        txtTitle.Size = New Size(939, 48)
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
        PanelRedDesign.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        PanelRedDesign.Location = New Point(289, 107)
        PanelRedDesign.Margin = New Padding(4, 5, 4, 5)
        PanelRedDesign.Name = "PanelRedDesign"
        PanelRedDesign.Size = New Size(115, 115)
        PanelRedDesign.TabIndex = 5
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.WhiteSmoke
        Panel2.Controls.Add(Label2)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 0)
        Panel2.Margin = New Padding(4)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(2249, 89)
        Panel2.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.DarkRed
        Label2.Location = New Point(4, 11)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(387, 61)
        Label2.TabIndex = 23
        Label2.Text = "File an Incedence"
        ' 
        ' UC_FileIncidence
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel1)
        Margin = New Padding(4)
        Name = "UC_FileIncidence"
        Size = New Size(2249, 1002)
        Panel1.ResumeLayout(False)
        PanelInputBundle.ResumeLayout(False)
        PanelInputBundle.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel4.ResumeLayout(False)
        CType(pbxIncidentImage, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelInputBundle As Panel
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCreateIncident As Button
    Friend WithEvents cmbCampuses As ComboBox
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PanelRedDesign As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbIncidentCategory As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnUploadIncidentPhoto As Button
    Friend WithEvents pbxIncidentImage As PictureBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents txtLocation As TextBox

End Class
