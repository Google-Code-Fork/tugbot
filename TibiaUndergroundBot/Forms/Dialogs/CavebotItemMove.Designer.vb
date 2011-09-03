<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CavebotItemMove
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
        Me.Cont = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DropId = New TUGBot.WaterMarkTextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Add = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Cont
        '
        Me.Cont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cont.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cont.FormattingEnabled = True
        Me.Cont.ItemHeight = 13
        Me.Cont.Items.AddRange(New Object() {"Backpack 1", "Backpack 2", "Backpack 3", "Backpack 4", "Backpack 5", "Backpack 6", "Backpack 7", "Backpack 8", "Backpack 9"})
        Me.Cont.Location = New System.Drawing.Point(59, 32)
        Me.Cont.Name = "Cont"
        Me.Cont.Size = New System.Drawing.Size(136, 21)
        Me.Cont.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "Drop Item"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(0, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "From"
        '
        'DropId
        '
        Me.DropId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.DropId.Location = New System.Drawing.Point(59, 6)
        Me.DropId.MaxLength = 5
        Me.DropId.Name = "DropId"
        Me.DropId.Size = New System.Drawing.Size(136, 20)
        Me.DropId.TabIndex = 1
        Me.DropId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.DropId.WaterMarkColor = System.Drawing.Color.Gray
        Me.DropId.WaterMarkText = "Item [ID/shortcut]"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(116, 59)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(79, 20)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Add
        '
        Me.Add.Location = New System.Drawing.Point(3, 59)
        Me.Add.Name = "Add"
        Me.Add.Size = New System.Drawing.Size(107, 20)
        Me.Add.TabIndex = 3
        Me.Add.Text = "Add Move Item"
        Me.Add.UseVisualStyleBackColor = True
        '
        'CavebotItemMove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(199, 81)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Add)
        Me.Controls.Add(Me.DropId)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cont)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "CavebotItemMove"
        Me.Text = "Add Item Move"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cont As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DropId As TUGBot.WaterMarkTextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Add As System.Windows.Forms.Button
End Class
