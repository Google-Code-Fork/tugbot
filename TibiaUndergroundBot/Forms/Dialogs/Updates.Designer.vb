<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Updates
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
        Me.components = New System.ComponentModel.Container
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.UpdatesText = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Install = New System.Windows.Forms.Button
        Me.NoInstall = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 50
        '
        'UpdatesText
        '
        Me.UpdatesText.BackColor = System.Drawing.SystemColors.Control
        Me.UpdatesText.Location = New System.Drawing.Point(2, 27)
        Me.UpdatesText.Multiline = True
        Me.UpdatesText.Name = "UpdatesText"
        Me.UpdatesText.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.UpdatesText.Size = New System.Drawing.Size(286, 186)
        Me.UpdatesText.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(2, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(285, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Update Found"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Install
        '
        Me.Install.Location = New System.Drawing.Point(2, 219)
        Me.Install.Name = "Install"
        Me.Install.Size = New System.Drawing.Size(141, 23)
        Me.Install.TabIndex = 2
        Me.Install.Text = "Install Update"
        Me.Install.UseVisualStyleBackColor = True
        '
        'NoInstall
        '
        Me.NoInstall.Location = New System.Drawing.Point(146, 219)
        Me.NoInstall.Name = "NoInstall"
        Me.NoInstall.Size = New System.Drawing.Size(141, 23)
        Me.NoInstall.TabIndex = 3
        Me.NoInstall.Text = "Dont Install Update"
        Me.NoInstall.UseVisualStyleBackColor = True
        '
        'Updates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(290, 244)
        Me.Controls.Add(Me.NoInstall)
        Me.Controls.Add(Me.Install)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.UpdatesText)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Updates"
        Me.ShowInTaskbar = False
        Me.Text = "Updates"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents UpdatesText As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Install As System.Windows.Forms.Button
    Friend WithEvents NoInstall As System.Windows.Forms.Button
End Class
