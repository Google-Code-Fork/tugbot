<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HotkeyPanel
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
        Me.Button = New System.Windows.Forms.TextBox
        Me.Enable = New System.Windows.Forms.CheckBox
        Me.Command = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Press = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.Down = New System.Windows.Forms.RadioButton
        Me.Up = New System.Windows.Forms.RadioButton
        Me.UpDown = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'Button
        '
        Me.Button.AutoCompleteCustomSource.AddRange(New String() {"Exura", "Exura Gran", "Exura Vita", "Exura San", "Exana Mort"})
        Me.Button.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Button.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Button.Location = New System.Drawing.Point(52, 0)
        Me.Button.Name = "Button"
        Me.Button.Size = New System.Drawing.Size(63, 20)
        Me.Button.TabIndex = 112
        Me.Button.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Enable
        '
        Me.Enable.AutoSize = True
        Me.Enable.Location = New System.Drawing.Point(3, 2)
        Me.Enable.Name = "Enable"
        Me.Enable.Size = New System.Drawing.Size(47, 17)
        Me.Enable.TabIndex = 115
        Me.Enable.Text = "Key:"
        Me.Enable.UseVisualStyleBackColor = True
        '
        'Command
        '
        Me.Command.AutoCompleteCustomSource.AddRange(New String() {"Exura", "Exura Gran", "Exura Vita", "Exura San", "Exana Mort"})
        Me.Command.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Command.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Command.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Command.Location = New System.Drawing.Point(184, 0)
        Me.Command.Name = "Command"
        Me.Command.Size = New System.Drawing.Size(185, 20)
        Me.Command.TabIndex = 113
        Me.Command.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(121, 3)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(57, 13)
        Me.Label26.TabIndex = 114
        Me.Label26.Text = "Command:"
        '
        'Press
        '
        Me.Press.AutoSize = True
        Me.Press.Checked = True
        Me.Press.Location = New System.Drawing.Point(52, 21)
        Me.Press.Name = "Press"
        Me.Press.Size = New System.Drawing.Size(68, 17)
        Me.Press.TabIndex = 116
        Me.Press.TabStop = True
        Me.Press.Text = "Keypress"
        Me.Press.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "Activate:"
        '
        'Down
        '
        Me.Down.AutoSize = True
        Me.Down.Location = New System.Drawing.Point(124, 21)
        Me.Down.Name = "Down"
        Me.Down.Size = New System.Drawing.Size(69, 17)
        Me.Down.TabIndex = 118
        Me.Down.TabStop = True
        Me.Down.Text = "Keydown"
        Me.Down.UseVisualStyleBackColor = True
        '
        'Up
        '
        Me.Up.AutoSize = True
        Me.Up.Location = New System.Drawing.Point(198, 21)
        Me.Up.Name = "Up"
        Me.Up.Size = New System.Drawing.Size(55, 17)
        Me.Up.TabIndex = 119
        Me.Up.TabStop = True
        Me.Up.Text = "Keyup"
        Me.Up.UseVisualStyleBackColor = True
        '
        'UpDown
        '
        Me.UpDown.AutoSize = True
        Me.UpDown.Location = New System.Drawing.Point(259, 21)
        Me.UpDown.Name = "UpDown"
        Me.UpDown.Size = New System.Drawing.Size(110, 17)
        Me.UpDown.TabIndex = 120
        Me.UpDown.Text = "Keydown / Keyup"
        Me.UpDown.UseVisualStyleBackColor = True
        '
        'HotkeyPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UpDown)
        Me.Controls.Add(Me.Up)
        Me.Controls.Add(Me.Down)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Press)
        Me.Controls.Add(Me.Button)
        Me.Controls.Add(Me.Enable)
        Me.Controls.Add(Me.Command)
        Me.Controls.Add(Me.Label26)
        Me.Name = "HotkeyPanel"
        Me.Size = New System.Drawing.Size(369, 40)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button As System.Windows.Forms.TextBox
    Friend WithEvents Enable As System.Windows.Forms.CheckBox
    Friend WithEvents Command As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Press As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Down As System.Windows.Forms.RadioButton
    Friend WithEvents Up As System.Windows.Forms.RadioButton
    Friend WithEvents UpDown As System.Windows.Forms.RadioButton

End Class
