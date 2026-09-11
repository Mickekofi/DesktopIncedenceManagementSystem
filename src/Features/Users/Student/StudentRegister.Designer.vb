<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StudentRegister
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
        txtPassword = New TextBox()
        Label2 = New Label()
        txtPasswordStrength = New Label()
        txtPhone = New TextBox()
        Label1 = New Label()
        btnSignUp = New Button()
        btnReload = New Button()
        Panel4 = New Panel()
        btnUploadPhoto = New Button()
        pbxProfilePhoto = New PictureBox()
        cmbCampus = New ComboBox()
        lbGender = New Label()
        lblfull_name = New Label()
        lbFullName = New Label()
        Panel5 = New Panel()
        Panel3 = New Panel()
        Panel2 = New Panel()
        lblPhotoPath = New Label()
        Label4 = New Label()
        Panel7 = New Panel()
        Label3 = New Label()
        Panel6 = New Panel()
        Panel1 = New Panel()
        Panel4.SuspendLayout()
        CType(pbxProfilePhoto, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        Panel7.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = SystemColors.ButtonHighlight
        txtPassword.Font = New Font("Garamond", 14.25F)
        txtPassword.Location = New Point(26, 692)
        txtPassword.Margin = New Padding(4, 5, 4, 5)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(792, 40)
        txtPassword.TabIndex = 76
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Garamond", 14.25F)
        Label2.Location = New Point(38, 1312)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.RightToLeft = RightToLeft.Yes
        Label2.Size = New Size(0, 33)
        Label2.TabIndex = 74
        ' 
        ' txtPasswordStrength
        ' 
        txtPasswordStrength.AutoSize = True
        txtPasswordStrength.Font = New Font("Garamond", 14.25F)
        txtPasswordStrength.Location = New Point(42, 1305)
        txtPasswordStrength.Margin = New Padding(4, 0, 4, 0)
        txtPasswordStrength.Name = "txtPasswordStrength"
        txtPasswordStrength.RightToLeft = RightToLeft.Yes
        txtPasswordStrength.Size = New Size(0, 33)
        txtPasswordStrength.TabIndex = 73
        ' 
        ' txtPhone
        ' 
        txtPhone.Font = New Font("Garamond", 14.25F)
        txtPhone.Location = New Point(26, 398)
        txtPhone.Margin = New Padding(4, 5, 4, 5)
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(792, 40)
        txtPhone.TabIndex = 72
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Garamond", 14.25F)
        Label1.Location = New Point(26, 636)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.RightToLeft = RightToLeft.Yes
        Label1.Size = New Size(298, 33)
        Label1.TabIndex = 70
        Label1.Text = "*Enter a New Password*"
        ' 
        ' btnSignUp
        ' 
        btnSignUp.BackColor = Color.DarkRed
        btnSignUp.Font = New Font("Garamond", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSignUp.ForeColor = Color.White
        btnSignUp.Location = New Point(26, 792)
        btnSignUp.Margin = New Padding(4, 5, 4, 5)
        btnSignUp.Name = "btnSignUp"
        btnSignUp.Size = New Size(296, 70)
        btnSignUp.TabIndex = 67
        btnSignUp.Text = "SignUp"
        btnSignUp.UseVisualStyleBackColor = False
        ' 
        ' btnReload
        ' 
        btnReload.BackColor = Color.Black
        btnReload.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnReload.ForeColor = Color.White
        btnReload.Location = New Point(348, 50)
        btnReload.Margin = New Padding(4, 5, 4, 5)
        btnReload.Name = "btnReload"
        btnReload.Size = New Size(156, 49)
        btnReload.TabIndex = 36
        btnReload.Text = "Refresh Page"
        btnReload.UseVisualStyleBackColor = False
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.White
        Panel4.Controls.Add(btnUploadPhoto)
        Panel4.Controls.Add(pbxProfilePhoto)
        Panel4.Location = New Point(902, 100)
        Panel4.Margin = New Padding(4, 5, 4, 5)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(345, 516)
        Panel4.TabIndex = 61
        ' 
        ' btnUploadPhoto
        ' 
        btnUploadPhoto.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnUploadPhoto.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUploadPhoto.ForeColor = Color.White
        btnUploadPhoto.Location = New Point(84, 448)
        btnUploadPhoto.Margin = New Padding(4, 5, 4, 5)
        btnUploadPhoto.Name = "btnUploadPhoto"
        btnUploadPhoto.Size = New Size(198, 49)
        btnUploadPhoto.TabIndex = 35
        btnUploadPhoto.Text = "Upload Profile"
        btnUploadPhoto.UseVisualStyleBackColor = False
        ' 
        ' pbxProfilePhoto
        ' 
        pbxProfilePhoto.BackColor = Color.White
        pbxProfilePhoto.Location = New Point(24, 51)
        pbxProfilePhoto.Margin = New Padding(4, 5, 4, 5)
        pbxProfilePhoto.Name = "pbxProfilePhoto"
        pbxProfilePhoto.Size = New Size(288, 368)
        pbxProfilePhoto.SizeMode = PictureBoxSizeMode.StretchImage
        pbxProfilePhoto.TabIndex = 0
        pbxProfilePhoto.TabStop = False
        ' 
        ' cmbCampus
        ' 
        cmbCampus.BackColor = SystemColors.Window
        cmbCampus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbCampus.Font = New Font("Garamond", 14.25F)
        cmbCampus.FormattingEnabled = True
        cmbCampus.Items.AddRange(New Object() {"Male", "Female"})
        cmbCampus.Location = New Point(26, 540)
        cmbCampus.Margin = New Padding(4, 5, 4, 5)
        cmbCampus.Name = "cmbCampus"
        cmbCampus.Size = New Size(792, 41)
        cmbCampus.TabIndex = 37
        ' 
        ' lbGender
        ' 
        lbGender.AutoSize = True
        lbGender.Font = New Font("Garamond", 14.25F)
        lbGender.Location = New Point(26, 485)
        lbGender.Margin = New Padding(4, 0, 4, 0)
        lbGender.Name = "lbGender"
        lbGender.RightToLeft = RightToLeft.Yes
        lbGender.Size = New Size(107, 33)
        lbGender.TabIndex = 11
        lbGender.Text = "Campus"
        ' 
        ' lblfull_name
        ' 
        lblfull_name.AutoSize = True
        lblfull_name.Font = New Font("Garamond", 14.25F)
        lblfull_name.Location = New Point(19, 10)
        lblfull_name.Margin = New Padding(4, 0, 4, 0)
        lblfull_name.Name = "lblfull_name"
        lblfull_name.RightToLeft = RightToLeft.Yes
        lblfull_name.Size = New Size(21, 33)
        lblfull_name.TabIndex = 5
        lblfull_name.Text = "!"
        ' 
        ' lbFullName
        ' 
        lbFullName.AutoSize = True
        lbFullName.Font = New Font("Garamond", 14.25F)
        lbFullName.Location = New Point(26, 219)
        lbFullName.Margin = New Padding(4, 0, 4, 0)
        lbFullName.Name = "lbFullName"
        lbFullName.RightToLeft = RightToLeft.Yes
        lbFullName.Size = New Size(134, 33)
        lbFullName.TabIndex = 2
        lbFullName.Text = "Full Name"
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.DarkRed
        Panel5.Location = New Point(874, 119)
        Panel5.Margin = New Padding(4, 5, 4, 5)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(321, 435)
        Panel5.TabIndex = 62
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.LightSeaGreen
        Panel3.Location = New Point(-85, 56)
        Panel3.Margin = New Padding(4, 5, 4, 5)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1705, 119)
        Panel3.TabIndex = 4
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.ButtonHighlight
        Panel2.Controls.Add(lblPhotoPath)
        Panel2.Controls.Add(Label4)
        Panel2.Controls.Add(Panel7)
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(txtPassword)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(txtPasswordStrength)
        Panel2.Controls.Add(txtPhone)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(btnSignUp)
        Panel2.Controls.Add(btnReload)
        Panel2.Controls.Add(Panel4)
        Panel2.Controls.Add(cmbCampus)
        Panel2.Controls.Add(lbGender)
        Panel2.Controls.Add(lbFullName)
        Panel2.Controls.Add(Panel5)
        Panel2.Controls.Add(Panel6)
        Panel2.Location = New Point(160, 56)
        Panel2.Margin = New Padding(4, 5, 4, 5)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1251, 1301)
        Panel2.TabIndex = 0
        ' 
        ' lblPhotoPath
        ' 
        lblPhotoPath.AutoSize = True
        lblPhotoPath.Font = New Font("Garamond", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPhotoPath.Location = New Point(874, 627)
        lblPhotoPath.Margin = New Padding(4, 0, 4, 0)
        lblPhotoPath.Name = "lblPhotoPath"
        lblPhotoPath.RightToLeft = RightToLeft.Yes
        lblPhotoPath.Size = New Size(12, 18)
        lblPhotoPath.TabIndex = 80
        lblPhotoPath.Text = "!"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Garamond", 14.25F)
        Label4.Location = New Point(26, 344)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.RightToLeft = RightToLeft.Yes
        Label4.Size = New Size(88, 33)
        Label4.TabIndex = 6
        Label4.Text = "Phone"
        ' 
        ' Panel7
        ' 
        Panel7.Controls.Add(lblfull_name)
        Panel7.Location = New Point(26, 265)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(792, 55)
        Panel7.TabIndex = 79
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Garamond", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(26, 41)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(316, 81)
        Label3.TabIndex = 77
        Label3.Text = "SIGN UP"
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.DarkRed
        Panel6.Location = New Point(15, 52)
        Panel6.Margin = New Padding(4)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(180, 89)
        Panel6.TabIndex = 78
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.BackColor = SystemColors.ButtonFace
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(Panel3)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(4, 5, 4, 5)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1924, 961)
        Panel1.TabIndex = 3
        ' 
        ' StudentRegister
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1924, 961)
        Controls.Add(Panel1)
        Margin = New Padding(4)
        Name = "StudentRegister"
        Text = "StudentRegister"
        Panel4.ResumeLayout(False)
        CType(pbxProfilePhoto, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPasswordStrength As Label
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSignUp As Button
    Friend WithEvents btnReload As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnUploadPhoto As Button
    Friend WithEvents pbxProfilePhoto As PictureBox
    Friend WithEvents cmbCampus As ComboBox
    Friend WithEvents lbGender As Label
    Friend WithEvents lblfull_name As Label
    Friend WithEvents lbFullName As Label
    Friend WithEvents Panel5 As Panel
    Protected WithEvents Panel3 As Panel
    Protected WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents lblPhotoPath As Label
End Class
