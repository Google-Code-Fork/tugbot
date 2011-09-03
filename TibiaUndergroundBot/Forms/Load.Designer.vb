<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Load
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Load))
        Me.UserName = New System.Windows.Forms.Label
        Me.SerialKey = New System.Windows.Forms.Label
        Me.LoadLabel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'UserName
        '
        Me.UserName.AutoSize = True
        Me.UserName.BackColor = System.Drawing.Color.Transparent
        Me.UserName.ForeColor = System.Drawing.Color.White
        Me.UserName.Location = New System.Drawing.Point(460, 173)
        Me.UserName.Name = "UserName"
        Me.UserName.Size = New System.Drawing.Size(80, 13)
        Me.UserName.TabIndex = 0
        Me.UserName.Text = "User Name: {0}"
        '
        'SerialKey
        '
        Me.SerialKey.AutoSize = True
        Me.SerialKey.BackColor = System.Drawing.Color.Transparent
        Me.SerialKey.ForeColor = System.Drawing.Color.White
        Me.SerialKey.Location = New System.Drawing.Point(460, 186)
        Me.SerialKey.Name = "SerialKey"
        Me.SerialKey.Size = New System.Drawing.Size(80, 13)
        Me.SerialKey.TabIndex = 1
        Me.SerialKey.Text = "Serial Key:   {0}"
        '
        'LoadLabel
        '
        Me.LoadLabel.AutoSize = True
        Me.LoadLabel.BackColor = System.Drawing.Color.Transparent
        Me.LoadLabel.ForeColor = System.Drawing.Color.White
        Me.LoadLabel.Location = New System.Drawing.Point(6, 180)
        Me.LoadLabel.Name = "LoadLabel"
        Me.LoadLabel.Size = New System.Drawing.Size(76, 13)
        Me.LoadLabel.TabIndex = 2
        Me.LoadLabel.Text = "Loading.. {0}%"
        '
        'Load
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.TUGBot.My.Resources.Resources.FlamelessBanner
        Me.ClientSize = New System.Drawing.Size(641, 200)
        Me.Controls.Add(Me.LoadLabel)
        Me.Controls.Add(Me.SerialKey)
        Me.Controls.Add(Me.UserName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Load"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Load"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UserName As System.Windows.Forms.Label
    Friend WithEvents SerialKey As System.Windows.Forms.Label
    Friend WithEvents LoadLabel As System.Windows.Forms.Label
End Class
