<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Panel1 = New Panel()
        Panel5 = New Panel()
        PictureBox1 = New PictureBox()
        Panel2 = New Panel()
        btnNoUse = New Button()
        Label3 = New Label()
        Panel6 = New Panel()
        Label1 = New Label()
        txtPassword = New TextBox()
        Username = New Label()
        btnLogin = New Button()
        txtUsername = New TextBox()
        Panel4 = New Panel()
        tmrFade = New Timer(components)
        Panel1.SuspendLayout()
        Panel5.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.AutoSize = True
        Panel1.BackColor = Color.WhiteSmoke
        Panel1.Controls.Add(Panel5)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(Panel4)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1924, 881)
        Panel1.TabIndex = 0
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.White
        Panel5.Controls.Add(PictureBox1)
        Panel5.Location = New Point(856, 29)
        Panel5.Margin = New Padding(4)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(495, 492)
        Panel5.TabIndex = 1
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(10, 18)
        PictureBox1.Margin = New Padding(4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(475, 458)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(btnNoUse)
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(Panel6)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(txtPassword)
        Panel2.Controls.Add(Username)
        Panel2.Controls.Add(btnLogin)
        Panel2.Controls.Add(txtUsername)
        Panel2.Location = New Point(435, 219)
        Panel2.Margin = New Padding(4)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1211, 995)
        Panel2.TabIndex = 0
        ' 
        ' btnNoUse
        ' 
        btnNoUse.Location = New Point(151, 622)
        btnNoUse.Margin = New Padding(4)
        btnNoUse.Name = "btnNoUse"
        btnNoUse.Size = New Size(12, 162)
        btnNoUse.TabIndex = 81
        btnNoUse.Text = "Button1"
        btnNoUse.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Garamond", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(495, 332)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(347, 81)
        Label3.TabIndex = 79
        Label3.Text = "User Login"
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.DarkRed
        Panel6.Location = New Point(484, 344)
        Panel6.Margin = New Padding(4)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(180, 89)
        Panel6.TabIndex = 80
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Garamond", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(231, 704)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(128, 31)
        Label1.TabIndex = 9
        Label1.Text = "Password"
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = SystemColors.Info
        txtPassword.Font = New Font("Garamond", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtPassword.Location = New Point(231, 766)
        txtPassword.Margin = New Padding(4)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(915, 44)
        txtPassword.TabIndex = 5
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' Username
        ' 
        Username.AutoSize = True
        Username.Font = New Font("Garamond", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Username.Location = New Point(231, 540)
        Username.Margin = New Padding(4, 0, 4, 0)
        Username.Name = "Username"
        Username.Size = New Size(135, 31)
        Username.TabIndex = 3
        Username.Text = "Username"
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.Firebrick
        btnLogin.Font = New Font("Garamond", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(231, 898)
        btnLogin.Margin = New Padding(4)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(519, 76)
        btnLogin.TabIndex = 2
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' txtUsername
        ' 
        txtUsername.BackColor = SystemColors.Info
        txtUsername.Font = New Font("Garamond", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtUsername.Location = New Point(231, 598)
        txtUsername.Margin = New Padding(4)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(915, 44)
        txtUsername.TabIndex = 1
        txtUsername.WordWrap = False
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.DarkRed
        Panel4.Location = New Point(409, 169)
        Panel4.Margin = New Padding(4)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(450, 586)
        Panel4.TabIndex = 2
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1924, 881)
        Controls.Add(Panel1)
        Margin = New Padding(4)
        Name = "Login"
        StartPosition = FormStartPosition.Manual
        Text = "Login"
        Panel1.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnLogin As Button
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Username As Label
    Friend WithEvents tmrFade As Timer
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnNoUse As Button
End Class
