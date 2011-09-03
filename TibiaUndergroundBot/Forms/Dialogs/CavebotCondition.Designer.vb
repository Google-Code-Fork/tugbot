<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CavebotCondition
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
        Me.FalseLabel = New System.Windows.Forms.TextBox
        Me.Label59 = New System.Windows.Forms.Label
        Me.TrueLabel = New System.Windows.Forms.TextBox
        Me.Label58 = New System.Windows.Forms.Label
        Me.ValueCompare = New System.Windows.Forms.NumericUpDown
        Me.OperatorCompare = New System.Windows.Forms.ComboBox
        Me.TypeCompare = New System.Windows.Forms.ComboBox
        Me.Label57 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.ValueCompare, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FalseLabel
        '
        Me.FalseLabel.Location = New System.Drawing.Point(113, 33)
        Me.FalseLabel.MaxLength = 20
        Me.FalseLabel.Name = "FalseLabel"
        Me.FalseLabel.Size = New System.Drawing.Size(64, 20)
        Me.FalseLabel.TabIndex = 92
        Me.FalseLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(3, 36)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(108, 13)
        Me.Label59.TabIndex = 94
        Me.Label59.Text = "If else then goto label"
        '
        'TrueLabel
        '
        Me.TrueLabel.Location = New System.Drawing.Point(310, 7)
        Me.TrueLabel.MaxLength = 20
        Me.TrueLabel.Name = "TrueLabel"
        Me.TrueLabel.Size = New System.Drawing.Size(64, 20)
        Me.TrueLabel.TabIndex = 91
        Me.TrueLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(223, 9)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(81, 13)
        Me.Label58.TabIndex = 93
        Me.Label58.Text = "Then goto label"
        '
        'ValueCompare
        '
        Me.ValueCompare.Location = New System.Drawing.Point(158, 7)
        Me.ValueCompare.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.ValueCompare.Name = "ValueCompare"
        Me.ValueCompare.Size = New System.Drawing.Size(59, 20)
        Me.ValueCompare.TabIndex = 90
        Me.ValueCompare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ValueCompare.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'OperatorCompare
        '
        Me.OperatorCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OperatorCompare.FormattingEnabled = True
        Me.OperatorCompare.Items.AddRange(New Object() {"=", ">", "<"})
        Me.OperatorCompare.Location = New System.Drawing.Point(113, 6)
        Me.OperatorCompare.Name = "OperatorCompare"
        Me.OperatorCompare.Size = New System.Drawing.Size(39, 21)
        Me.OperatorCompare.TabIndex = 89
        '
        'TypeCompare
        '
        Me.TypeCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TypeCompare.FormattingEnabled = True
        Me.TypeCompare.Items.AddRange(New Object() {"Health", "Mana", "Cap", "Soul", "Level", "Exp", "ItemCount.."})
        Me.TypeCompare.Location = New System.Drawing.Point(22, 6)
        Me.TypeCompare.Name = "TypeCompare"
        Me.TypeCompare.Size = New System.Drawing.Size(85, 21)
        Me.TypeCompare.TabIndex = 88
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(3, 9)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(13, 13)
        Me.Label57.TabIndex = 87
        Me.Label57.Text = "If"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(183, 33)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 20)
        Me.Button1.TabIndex = 96
        Me.Button1.Text = "Add Conditional"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(295, 32)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(79, 20)
        Me.Button2.TabIndex = 97
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CavebotCondition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 57)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.FalseLabel)
        Me.Controls.Add(Me.Label59)
        Me.Controls.Add(Me.TrueLabel)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.ValueCompare)
        Me.Controls.Add(Me.OperatorCompare)
        Me.Controls.Add(Me.TypeCompare)
        Me.Controls.Add(Me.Label57)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CavebotCondition"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Conditional Statement"
        CType(Me.ValueCompare, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FalseLabel As System.Windows.Forms.TextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents TrueLabel As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents ValueCompare As System.Windows.Forms.NumericUpDown
    Friend WithEvents OperatorCompare As System.Windows.Forms.ComboBox
    Friend WithEvents TypeCompare As System.Windows.Forms.ComboBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
