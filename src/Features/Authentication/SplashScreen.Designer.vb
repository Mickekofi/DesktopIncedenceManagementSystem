<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen))
        Timer1 = New Timer(components)
        PictureBox1 = New PictureBox()
        PanelBackground = New Panel()
        Panel3 = New Panel()
        Panel2 = New Panel()
        Panel1 = New Panel()
        Label2 = New Label()
        lblPercentage = New Label()
        ProgressBar1 = New ProgressBar()
        Timer2 = New Timer(components)
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        PanelBackground.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Timer1
        ' 
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.White
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(225, 39)
        PictureBox1.Margin = New Padding(4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(502, 454)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 3
        PictureBox1.TabStop = False
        ' 
        ' PanelBackground
        ' 
        PanelBackground.BackColor = Color.White
        PanelBackground.Controls.Add(Panel3)
        PanelBackground.Controls.Add(Panel2)
        PanelBackground.Controls.Add(Panel1)
        PanelBackground.Dock = DockStyle.Fill
        PanelBackground.Location = New Point(0, 0)
        PanelBackground.Margin = New Padding(4)
        PanelBackground.Name = "PanelBackground"
        PanelBackground.Size = New Size(1025, 735)
        PanelBackground.TabIndex = 0
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.DarkRed
        Panel3.Location = New Point(75, 41)
        Panel3.Margin = New Padding(4)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(32, 156)
        Panel3.TabIndex = 8
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Black
        Panel2.Location = New Point(140, 41)
        Panel2.Margin = New Padding(4)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(32, 338)
        Panel2.TabIndex = 7
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(lblPercentage)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(ProgressBar1)
        Panel1.Location = New Point(13, 4)
        Panel1.Margin = New Padding(4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(954, 801)
        Panel1.TabIndex = 5
        ' 
        ' Label2
        ' 
        Label2.BackColor = Color.Transparent
        Label2.CausesValidation = False
        Label2.Font = New Font("Bahnschrift Condensed", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label2.Location = New Point(25, 520)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(929, 88)
        Label2.TabIndex = 6
        Label2.Text = "Incidence Management System"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblPercentage
        ' 
        lblPercentage.BackColor = Color.Transparent
        lblPercentage.CausesValidation = False
        lblPercentage.Font = New Font("Bahnschrift Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPercentage.ForeColor = Color.Black
        lblPercentage.Location = New Point(652, 633)
        lblPercentage.Margin = New Padding(4, 0, 4, 0)
        lblPercentage.Name = "lblPercentage"
        lblPercentage.Size = New Size(75, 38)
        lblPercentage.TabIndex = 5
        lblPercentage.Text = "0"
        lblPercentage.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.BackColor = Color.Black
        ProgressBar1.ForeColor = Color.Red
        ProgressBar1.Location = New Point(202, 633)
        ProgressBar1.Margin = New Padding(4, 5, 4, 5)
        ProgressBar1.Minimum = 10
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(525, 39)
        ProgressBar1.Style = ProgressBarStyle.Continuous
        ProgressBar1.TabIndex = 4
        ProgressBar1.Value = 10
        ' 
        ' Timer2
        ' 
        ' 
        ' SplashScreen
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        ClientSize = New Size(1025, 735)
        ControlBox = False
        Controls.Add(PanelBackground)
        Margin = New Padding(4)
        Name = "SplashScreen"
        StartPosition = FormStartPosition.CenterScreen
        Text = "SplashScreen"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        PanelBackground.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PanelBackground As Panel
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblPercentage As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Timer2 As Timer
End Class
