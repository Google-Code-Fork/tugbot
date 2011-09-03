<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CavebotTradeSession
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
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.AddBuy = New System.Windows.Forms.Button
        Me.BuyCount = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.BuyId = New TUGBot.WaterMarkTextBox
        Me.BuyIgnoreCap = New System.Windows.Forms.CheckBox
        Me.BuyWithBackPacks = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.AddSale = New System.Windows.Forms.Button
        Me.SellCount = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.SellId = New TUGBot.WaterMarkTextBox
        Me.EqSale = New System.Windows.Forms.CheckBox
        Me.AddTradeSession = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.GroupBox8.SuspendLayout()
        CType(Me.BuyCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SellCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(2, 8)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(205, 186)
        Me.ListBox1.TabIndex = 0
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.AddBuy)
        Me.GroupBox8.Controls.Add(Me.BuyCount)
        Me.GroupBox8.Controls.Add(Me.Label1)
        Me.GroupBox8.Controls.Add(Me.BuyId)
        Me.GroupBox8.Controls.Add(Me.BuyIgnoreCap)
        Me.GroupBox8.Controls.Add(Me.BuyWithBackPacks)
        Me.GroupBox8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox8.Location = New System.Drawing.Point(213, 8)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(165, 117)
        Me.GroupBox8.TabIndex = 26
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Add Purchase"
        '
        'AddBuy
        '
        Me.AddBuy.Location = New System.Drawing.Point(112, 91)
        Me.AddBuy.Name = "AddBuy"
        Me.AddBuy.Size = New System.Drawing.Size(47, 20)
        Me.AddBuy.TabIndex = 5
        Me.AddBuy.Text = "Add"
        Me.AddBuy.UseVisualStyleBackColor = True
        '
        'BuyCount
        '
        Me.BuyCount.Location = New System.Drawing.Point(58, 91)
        Me.BuyCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.BuyCount.Name = "BuyCount"
        Me.BuyCount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BuyCount.Size = New System.Drawing.Size(48, 20)
        Me.BuyCount.TabIndex = 4
        Me.BuyCount.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Amount:"
        '
        'BuyId
        '
        Me.BuyId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BuyId.Location = New System.Drawing.Point(7, 65)
        Me.BuyId.MaxLength = 5
        Me.BuyId.Name = "BuyId"
        Me.BuyId.Size = New System.Drawing.Size(152, 20)
        Me.BuyId.TabIndex = 2
        Me.BuyId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.BuyId.WaterMarkColor = System.Drawing.Color.Gray
        Me.BuyId.WaterMarkText = "Item [ID/shortcut]"
        '
        'BuyIgnoreCap
        '
        Me.BuyIgnoreCap.AutoSize = True
        Me.BuyIgnoreCap.Location = New System.Drawing.Point(6, 42)
        Me.BuyIgnoreCap.Name = "BuyIgnoreCap"
        Me.BuyIgnoreCap.Size = New System.Drawing.Size(100, 17)
        Me.BuyIgnoreCap.TabIndex = 1
        Me.BuyIgnoreCap.Text = "Ignore Capacity"
        Me.BuyIgnoreCap.UseVisualStyleBackColor = True
        '
        'BuyWithBackPacks
        '
        Me.BuyWithBackPacks.AutoSize = True
        Me.BuyWithBackPacks.Location = New System.Drawing.Point(6, 19)
        Me.BuyWithBackPacks.Name = "BuyWithBackPacks"
        Me.BuyWithBackPacks.Size = New System.Drawing.Size(126, 17)
        Me.BuyWithBackPacks.TabIndex = 0
        Me.BuyWithBackPacks.Text = "Buy With Backpacks"
        Me.BuyWithBackPacks.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AddSale)
        Me.GroupBox1.Controls.Add(Me.SellCount)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.SellId)
        Me.GroupBox1.Controls.Add(Me.EqSale)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox1.Location = New System.Drawing.Point(213, 131)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(165, 93)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Sale"
        '
        'AddSale
        '
        Me.AddSale.Location = New System.Drawing.Point(111, 68)
        Me.AddSale.Name = "AddSale"
        Me.AddSale.Size = New System.Drawing.Size(47, 20)
        Me.AddSale.TabIndex = 5
        Me.AddSale.Text = "Add"
        Me.AddSale.UseVisualStyleBackColor = True
        '
        'SellCount
        '
        Me.SellCount.Location = New System.Drawing.Point(57, 68)
        Me.SellCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SellCount.Name = "SellCount"
        Me.SellCount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SellCount.Size = New System.Drawing.Size(48, 20)
        Me.SellCount.TabIndex = 4
        Me.SellCount.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Amount:"
        '
        'SellId
        '
        Me.SellId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.SellId.Location = New System.Drawing.Point(6, 42)
        Me.SellId.MaxLength = 5
        Me.SellId.Name = "SellId"
        Me.SellId.Size = New System.Drawing.Size(152, 20)
        Me.SellId.TabIndex = 2
        Me.SellId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SellId.WaterMarkColor = System.Drawing.Color.Gray
        Me.SellId.WaterMarkText = "Item [ID/shortcut]"
        '
        'EqSale
        '
        Me.EqSale.AutoSize = True
        Me.EqSale.Location = New System.Drawing.Point(6, 19)
        Me.EqSale.Name = "EqSale"
        Me.EqSale.Size = New System.Drawing.Size(113, 17)
        Me.EqSale.TabIndex = 0
        Me.EqSale.Text = "Sell From EQ Slots"
        Me.EqSale.UseVisualStyleBackColor = True
        '
        'AddTradeSession
        '
        Me.AddTradeSession.Location = New System.Drawing.Point(2, 200)
        Me.AddTradeSession.Name = "AddTradeSession"
        Me.AddTradeSession.Size = New System.Drawing.Size(125, 20)
        Me.AddTradeSession.TabIndex = 28
        Me.AddTradeSession.Text = "Add Trade Session"
        Me.AddTradeSession.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(133, 200)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(74, 20)
        Me.Button3.TabIndex = 29
        Me.Button3.Text = "Cancel"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'CavebotTradeSession
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 225)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.AddTradeSession)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "CavebotTradeSession"
        Me.Text = "Add Trade Session"
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.BuyCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.SellCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents BuyIgnoreCap As System.Windows.Forms.CheckBox
    Friend WithEvents BuyWithBackPacks As System.Windows.Forms.CheckBox
    Friend WithEvents BuyId As TUGBot.WaterMarkTextBox
    Friend WithEvents BuyCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AddBuy As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents AddSale As System.Windows.Forms.Button
    Friend WithEvents SellCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SellId As TUGBot.WaterMarkTextBox
    Friend WithEvents EqSale As System.Windows.Forms.CheckBox
    Friend WithEvents AddTradeSession As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
