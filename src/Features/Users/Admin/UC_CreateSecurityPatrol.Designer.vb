<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_CreateSecurityPatrol
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        PanelInputBundle = New Panel()
        btnCreate = New Button()
        lblpass = New Label()
        txtPassword = New TextBox()
        cmbSelectCampus = New ComboBox()
        Create = New Label()
        Selects = New Label()
        txtUsername = New TextBox()
        Label3 = New Label()
        PanelRedDesign = New Panel()
        Panel2 = New Panel()
        Label2 = New Label()
        Panel3 = New Panel()
        txtFullName = New TextBox()
        Label1 = New Label()
        Panel1.SuspendLayout()
        PanelInputBundle.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.BackColor = SystemColors.Menu
        Panel1.Controls.Add(PanelInputBundle)
        Panel1.Controls.Add(PanelRedDesign)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(Panel3)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(2255, 1011)
        Panel1.TabIndex = 0
        ' 
        ' PanelInputBundle
        ' 
        PanelInputBundle.BackColor = Color.White
        PanelInputBundle.Controls.Add(txtFullName)
        PanelInputBundle.Controls.Add(Label1)
        PanelInputBundle.Controls.Add(btnCreate)
        PanelInputBundle.Controls.Add(lblpass)
        PanelInputBundle.Controls.Add(txtPassword)
        PanelInputBundle.Controls.Add(cmbSelectCampus)
        PanelInputBundle.Controls.Add(Create)
        PanelInputBundle.Controls.Add(Selects)
        PanelInputBundle.Controls.Add(txtUsername)
        PanelInputBundle.Controls.Add(Label3)
        PanelInputBundle.Location = New Point(281, 150)
        PanelInputBundle.Margin = New Padding(4, 5, 4, 5)
        PanelInputBundle.Name = "PanelInputBundle"
        PanelInputBundle.Size = New Size(784, 861)
        PanelInputBundle.TabIndex = 4
        ' 
        ' btnCreate
        ' 
        btnCreate.BackColor = Color.DarkSlateGray
        btnCreate.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCreate.ForeColor = Color.LavenderBlush
        btnCreate.Location = New Point(19, 745)
        btnCreate.Margin = New Padding(4, 5, 4, 5)
        btnCreate.Name = "btnCreate"
        btnCreate.Size = New Size(341, 68)
        btnCreate.TabIndex = 29
        btnCreate.Text = "Create"
        btnCreate.UseVisualStyleBackColor = False
        ' 
        ' lblpass
        ' 
        lblpass.AutoSize = True
        lblpass.BackColor = Color.Transparent
        lblpass.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblpass.ForeColor = Color.Black
        lblpass.Location = New Point(19, 382)
        lblpass.Margin = New Padding(4, 0, 4, 0)
        lblpass.Name = "lblpass"
        lblpass.Size = New Size(145, 33)
        lblpass.TabIndex = 28
        lblpass.Text = "*password"
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = Color.Ivory
        txtPassword.Font = New Font("Garamond", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtPassword.ForeColor = SystemColors.ActiveCaptionText
        txtPassword.Location = New Point(16, 438)
        txtPassword.Margin = New Padding(4, 5, 4, 5)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(726, 48)
        txtPassword.TabIndex = 27
        ' 
        ' cmbSelectCampus
        ' 
        cmbSelectCampus.BackColor = SystemColors.Info
        cmbSelectCampus.Font = New Font("Garamond", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbSelectCampus.ForeColor = Color.Red
        cmbSelectCampus.FormattingEnabled = True
        cmbSelectCampus.Items.AddRange(New Object() {"South Campus", "Central Campus", "North Campus", "Ajumako Campus"})
        cmbSelectCampus.Location = New Point(19, 614)
        cmbSelectCampus.Margin = New Padding(4, 5, 4, 5)
        cmbSelectCampus.Name = "cmbSelectCampus"
        cmbSelectCampus.Size = New Size(726, 44)
        cmbSelectCampus.TabIndex = 26
        cmbSelectCampus.Text = "--Select--"
        ' 
        ' Create
        ' 
        Create.AutoSize = True
        Create.BackColor = Color.Transparent
        Create.Font = New Font("Arial Rounded MT Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Create.ForeColor = Color.Red
        Create.Location = New Point(19, 19)
        Create.Margin = New Padding(4, 0, 4, 0)
        Create.Name = "Create"
        Create.Size = New Size(393, 51)
        Create.TabIndex = 15
        Create.Text = "Security Account"
        ' 
        ' Selects
        ' 
        Selects.AutoSize = True
        Selects.BackColor = Color.Transparent
        Selects.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Selects.ForeColor = Color.Black
        Selects.Location = New Point(19, 559)
        Selects.Margin = New Padding(4, 0, 4, 0)
        Selects.Name = "Selects"
        Selects.Size = New Size(212, 33)
        Selects.TabIndex = 16
        Selects.Text = "*Select Campus"
        ' 
        ' txtUsername
        ' 
        txtUsername.BackColor = Color.Ivory
        txtUsername.Font = New Font("Garamond", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtUsername.ForeColor = SystemColors.ActiveCaptionText
        txtUsername.Location = New Point(19, 305)
        txtUsername.Margin = New Padding(4, 5, 4, 5)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(726, 48)
        txtUsername.TabIndex = 15
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(16, 254)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(216, 33)
        Label3.TabIndex = 14
        Label3.Text = "Patrol username"
        ' 
        ' PanelRedDesign
        ' 
        PanelRedDesign.BackColor = Color.DarkSlateGray
        PanelRedDesign.Location = New Point(260, 281)
        PanelRedDesign.Margin = New Padding(4, 5, 4, 5)
        PanelRedDesign.Name = "PanelRedDesign"
        PanelRedDesign.Size = New Size(680, 685)
        PanelRedDesign.TabIndex = 5
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.DarkRed
        Panel2.Controls.Add(Label2)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 0)
        Panel2.Margin = New Padding(4)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(2255, 89)
        Panel2.TabIndex = 0
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
        Label2.Size = New Size(666, 61)
        Label2.TabIndex = 23
        Label2.Text = "Create Campus Patrol Security"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.DarkRed
        Panel3.Location = New Point(0, 254)
        Panel3.Margin = New Padding(4, 5, 4, 5)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(283, 28)
        Panel3.TabIndex = 6
        ' 
        ' txtFullName
        ' 
        txtFullName.BackColor = Color.Ivory
        txtFullName.Font = New Font("Garamond", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtFullName.ForeColor = SystemColors.ActiveCaptionText
        txtFullName.Location = New Point(19, 176)
        txtFullName.Margin = New Padding(4, 5, 4, 5)
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(726, 48)
        txtFullName.TabIndex = 31
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Garamond", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(16, 121)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(229, 33)
        Label1.TabIndex = 30
        Label1.Text = "Patrol Full Name"
        ' 
        ' UC_CreateSecurityPatrol
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel1)
        Margin = New Padding(4)
        Name = "UC_CreateSecurityPatrol"
        Size = New Size(2255, 1011)
        Panel1.ResumeLayout(False)
        PanelInputBundle.ResumeLayout(False)
        PanelInputBundle.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelInputBundle As Panel
    Friend WithEvents lblpass As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents cmbSelectCampus As ComboBox
    Friend WithEvents Create As Label
    Friend WithEvents Selects As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PanelRedDesign As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnCreate As Button
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents Label1 As Label

End Class
