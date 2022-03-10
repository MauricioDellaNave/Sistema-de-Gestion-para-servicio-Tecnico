<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Splash
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CNetHelpProvider.SetHelpKeyword(Me.Button1, "Pantallas Interfaz_Form_Splash.htm#Splash_Button1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.Button1, System.Windows.Forms.HelpNavigator.Topic)
        Me.Button1.Location = New System.Drawing.Point(349, 255)
        Me.Button1.Name = "Button1"
        Me.CNetHelpProvider.SetShowHelp(Me.Button1, True)
        Me.Button1.Size = New System.Drawing.Size(188, 29)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "&Salir del Sistema"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CNetHelpProvider.SetHelpKeyword(Me.Button2, "Pantallas Interfaz_Form_Splash.htm#Splash_Button2")
        Me.CNetHelpProvider.SetHelpNavigator(Me.Button2, System.Windows.Forms.HelpNavigator.Topic)
        Me.Button2.Location = New System.Drawing.Point(349, 221)
        Me.Button2.Name = "Button2"
        Me.CNetHelpProvider.SetShowHelp(Me.Button2, True)
        Me.Button2.Size = New System.Drawing.Size(187, 28)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "&Restaurar Base de Datos"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        '
        'CNetHelpProvider
        '
        Me.CNetHelpProvider.HelpNamespace = "Pantallas Interfaz.chm"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CNetHelpProvider.SetHelpKeyword(Me.PictureBox1, "Pantallas Interfaz_Form_Splash.htm#Splash_PictureBox1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.PictureBox1, System.Windows.Forms.HelpNavigator.Topic)
        Me.PictureBox1.Image = Global.Sistema_de_Gestion_Tecnica.My.Resources.Resources.Splash
        Me.PictureBox1.Location = New System.Drawing.Point(-3, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.CNetHelpProvider.SetShowHelp(Me.PictureBox1, True)
        Me.PictureBox1.Size = New System.Drawing.Size(552, 355)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.WaitOnLoad = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.Navy
        Me.ProgressBar1.Location = New System.Drawing.Point(4, 274)
        Me.ProgressBar1.MarqueeAnimationSpeed = 1
        Me.ProgressBar1.Maximum = 5000
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(319, 19)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 4
        '
        'Splash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(548, 354)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.CNetHelpProvider.SetHelpKeyword(Me, "Pantallas Interfaz_Form_Splash.htm")
        Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.Name = "Splash"
        Me.CNetHelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Bienvenido al Sistema SIGT 2008 "
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
