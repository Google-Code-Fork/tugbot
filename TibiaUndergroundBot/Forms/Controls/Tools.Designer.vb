<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tools
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
        Me.GroupBox14 = New System.Windows.Forms.GroupBox
        Me.ShowIds = New System.Windows.Forms.CheckBox
        Me.ShowHealPercent = New System.Windows.Forms.CheckBox
        Me.FrameRate = New System.Windows.Forms.CheckBox
        Me.FieldWalker = New System.Windows.Forms.CheckBox
        Me.OpenPitfalls = New System.Windows.Forms.CheckBox
        Me.ReplaceTrees = New System.Windows.Forms.CheckBox
        Me.EnableLight = New System.Windows.Forms.CheckBox
        Me.EnableXray = New System.Windows.Forms.CheckBox
        Me.AntiIdle = New System.Windows.Forms.CheckBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TradeWatchEnable = New System.Windows.Forms.CheckBox
        Me.TextToWatch = New TUGBot.WaterMarkTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.AutoStack = New System.Windows.Forms.CheckBox
        Me.EatFood = New System.Windows.Forms.CheckBox
        Me.EnableFishing = New System.Windows.Forms.CheckBox
        Me.IdleTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FoodTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FrameRateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FoodEater = New System.ComponentModel.BackgroundWorker
        Me.Fisher = New System.ComponentModel.BackgroundWorker
        Me.FishingTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FurnitureWalker = New System.Windows.Forms.CheckBox
        Me.GroupBox14.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox14
        '
        Me.GroupBox14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox14.Controls.Add(Me.FurnitureWalker)
        Me.GroupBox14.Controls.Add(Me.ShowIds)
        Me.GroupBox14.Controls.Add(Me.ShowHealPercent)
        Me.GroupBox14.Controls.Add(Me.FrameRate)
        Me.GroupBox14.Controls.Add(Me.FieldWalker)
        Me.GroupBox14.Controls.Add(Me.OpenPitfalls)
        Me.GroupBox14.Controls.Add(Me.ReplaceTrees)
        Me.GroupBox14.Controls.Add(Me.EnableLight)
        Me.GroupBox14.Controls.Add(Me.EnableXray)
        Me.GroupBox14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox14.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(227, 133)
        Me.GroupBox14.TabIndex = 24
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Tag = "<div class=""header""><br/></div>"
        Me.GroupBox14.Text = "Hacks"
        '
        'ShowIds
        '
        Me.ShowIds.AutoSize = True
        Me.ShowIds.Location = New System.Drawing.Point(9, 88)
        Me.ShowIds.Name = "ShowIds"
        Me.ShowIds.Size = New System.Drawing.Size(139, 17)
        Me.ShowIds.TabIndex = 84
        Me.ShowIds.Text = "Show Item IDs On Look"
        Me.ToolTip1.SetToolTip(Me.ShowIds, "Show the item ID of items after the green text when they are looked at. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Note:" & _
                " Looking around very fast can cause this to give the wrong item IDs. You should " & _
                "look at one item at a time.")
        Me.ShowIds.UseVisualStyleBackColor = True
        '
        'ShowHealPercent
        '
        Me.ShowHealPercent.AutoSize = True
        Me.ShowHealPercent.Location = New System.Drawing.Point(9, 111)
        Me.ShowHealPercent.Name = "ShowHealPercent"
        Me.ShowHealPercent.Size = New System.Drawing.Size(214, 17)
        Me.ShowHealPercent.TabIndex = 5
        Me.ShowHealPercent.Text = "Show Healing Percent Above Creatures"
        Me.ToolTip1.SetToolTip(Me.ShowHealPercent, "Show blue numbers above a creatures head representing the percent of health they " & _
                "healed, if they healed more than 1 percent of health.")
        Me.ShowHealPercent.UseVisualStyleBackColor = True
        '
        'FrameRate
        '
        Me.FrameRate.AutoSize = True
        Me.FrameRate.Enabled = False
        Me.FrameRate.Location = New System.Drawing.Point(151, 88)
        Me.FrameRate.Name = "FrameRate"
        Me.FrameRate.Size = New System.Drawing.Size(73, 17)
        Me.FrameRate.TabIndex = 6
        Me.FrameRate.Text = "Framerate"
        Me.ToolTip1.SetToolTip(Me.FrameRate, "Reduce the clients framerate to 1 when minimized, to reduce CPU usage dramaticall" & _
                "y.")
        Me.FrameRate.UseVisualStyleBackColor = True
        Me.FrameRate.Visible = False
        '
        'FieldWalker
        '
        Me.FieldWalker.AutoSize = True
        Me.FieldWalker.Location = New System.Drawing.Point(9, 65)
        Me.FieldWalker.Name = "FieldWalker"
        Me.FieldWalker.Size = New System.Drawing.Size(98, 17)
        Me.FieldWalker.TabIndex = 4
        Me.FieldWalker.Text = "Walk On Fields"
        Me.ToolTip1.SetToolTip(Me.FieldWalker, "Walk over fire, poison, and energy fields with map click or cave walker.")
        Me.FieldWalker.UseVisualStyleBackColor = True
        '
        'OpenPitfalls
        '
        Me.OpenPitfalls.AutoSize = True
        Me.OpenPitfalls.Location = New System.Drawing.Point(108, 19)
        Me.OpenPitfalls.Name = "OpenPitfalls"
        Me.OpenPitfalls.Size = New System.Drawing.Size(85, 17)
        Me.OpenPitfalls.TabIndex = 1
        Me.OpenPitfalls.Text = "Open Pitfalls"
        Me.ToolTip1.SetToolTip(Me.OpenPitfalls, "Make all hidden pitfalls show as their opened state. This can only be undone be r" & _
                "estarting your client.")
        Me.OpenPitfalls.UseVisualStyleBackColor = True
        '
        'ReplaceTrees
        '
        Me.ReplaceTrees.AutoSize = True
        Me.ReplaceTrees.Location = New System.Drawing.Point(108, 42)
        Me.ReplaceTrees.Name = "ReplaceTrees"
        Me.ReplaceTrees.Size = New System.Drawing.Size(96, 17)
        Me.ReplaceTrees.TabIndex = 3
        Me.ReplaceTrees.Text = "Replace Trees"
        Me.ToolTip1.SetToolTip(Me.ReplaceTrees, "Make large trees small to reveal hidden items and lootbags. This can only be undo" & _
                "ne be restarting your client.")
        Me.ReplaceTrees.UseVisualStyleBackColor = True
        '
        'EnableLight
        '
        Me.EnableLight.AutoSize = True
        Me.EnableLight.Location = New System.Drawing.Point(9, 42)
        Me.EnableLight.Name = "EnableLight"
        Me.EnableLight.Size = New System.Drawing.Size(68, 17)
        Me.EnableLight.TabIndex = 2
        Me.EnableLight.Text = "Full Light"
        Me.ToolTip1.SetToolTip(Me.EnableLight, "Fully light up the screen to see clearly in dark dungeons.")
        Me.EnableLight.UseVisualStyleBackColor = True
        '
        'EnableXray
        '
        Me.EnableXray.AutoSize = True
        Me.EnableXray.Location = New System.Drawing.Point(9, 19)
        Me.EnableXray.Name = "EnableXray"
        Me.EnableXray.Size = New System.Drawing.Size(55, 17)
        Me.EnableXray.TabIndex = 0
        Me.EnableXray.Text = "X-Ray"
        Me.ToolTip1.SetToolTip(Me.EnableXray, "Show names of creatures on all visible floors.")
        Me.EnableXray.UseVisualStyleBackColor = True
        '
        'AntiIdle
        '
        Me.AntiIdle.AutoSize = True
        Me.AntiIdle.Location = New System.Drawing.Point(108, 19)
        Me.AntiIdle.Name = "AntiIdle"
        Me.AntiIdle.Size = New System.Drawing.Size(64, 17)
        Me.AntiIdle.TabIndex = 6
        Me.AntiIdle.Text = "Anti-Idle"
        Me.ToolTip1.SetToolTip(Me.AntiIdle, "Prevent yourself from being kicked from game due to no activity.")
        Me.AntiIdle.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox14)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(235, 280)
        Me.Panel1.TabIndex = 25
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.Controls.Add(Me.TradeWatchEnable)
        Me.GroupBox2.Controls.Add(Me.TextToWatch)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox2.Location = New System.Drawing.Point(3, 209)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(227, 67)
        Me.GroupBox2.TabIndex = 83
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = "<div class=""header""><br/></div>"
        Me.GroupBox2.Text = "Trade Watcher"
        '
        'TradeWatchEnable
        '
        Me.TradeWatchEnable.AutoSize = True
        Me.TradeWatchEnable.Location = New System.Drawing.Point(6, 45)
        Me.TradeWatchEnable.Name = "TradeWatchEnable"
        Me.TradeWatchEnable.Size = New System.Drawing.Size(134, 17)
        Me.TradeWatchEnable.TabIndex = 1
        Me.TradeWatchEnable.Text = "Enable Trade Watcher"
        Me.ToolTip1.SetToolTip(Me.TradeWatchEnable, "When Trade channel is open, display a red broadcast of any message in trade conta" & _
                "ining one or more of the key phrases.")
        Me.TradeWatchEnable.UseVisualStyleBackColor = True
        '
        'TextToWatch
        '
        Me.TextToWatch.Location = New System.Drawing.Point(6, 19)
        Me.TextToWatch.Name = "TextToWatch"
        Me.TextToWatch.Size = New System.Drawing.Size(215, 20)
        Me.TextToWatch.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.TextToWatch, "A list of key phrases to watch for in trade channel. Seperate them by commas.")
        Me.TextToWatch.WaterMarkColor = System.Drawing.Color.Gray
        Me.TextToWatch.WaterMarkText = "Key Phrases [Seperate with commas]"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox1.Controls.Add(Me.AutoStack)
        Me.GroupBox1.Controls.Add(Me.AntiIdle)
        Me.GroupBox1.Controls.Add(Me.EatFood)
        Me.GroupBox1.Controls.Add(Me.EnableFishing)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox1.Location = New System.Drawing.Point(3, 137)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(227, 66)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "<div class=""header""><br/></div>"
        Me.GroupBox1.Text = "Autos"
        '
        'AutoStack
        '
        Me.AutoStack.AutoSize = True
        Me.AutoStack.Location = New System.Drawing.Point(108, 42)
        Me.AutoStack.Name = "AutoStack"
        Me.AutoStack.Size = New System.Drawing.Size(79, 17)
        Me.AutoStack.TabIndex = 83
        Me.AutoStack.Text = "Auto Stack"
        Me.ToolTip1.SetToolTip(Me.AutoStack, "Automatically stack items such as fish or gold.")
        Me.AutoStack.UseVisualStyleBackColor = True
        '
        'EatFood
        '
        Me.EatFood.AutoSize = True
        Me.EatFood.Location = New System.Drawing.Point(9, 42)
        Me.EatFood.Name = "EatFood"
        Me.EatFood.Size = New System.Drawing.Size(69, 17)
        Me.EatFood.TabIndex = 1
        Me.EatFood.Text = "Eat Food"
        Me.ToolTip1.SetToolTip(Me.EatFood, "Automatically eat food.")
        Me.EatFood.UseVisualStyleBackColor = True
        '
        'EnableFishing
        '
        Me.EnableFishing.AutoSize = True
        Me.EnableFishing.Location = New System.Drawing.Point(9, 19)
        Me.EnableFishing.Name = "EnableFishing"
        Me.EnableFishing.Size = New System.Drawing.Size(70, 17)
        Me.EnableFishing.TabIndex = 0
        Me.EnableFishing.Text = "Auto Fish"
        Me.ToolTip1.SetToolTip(Me.EnableFishing, "Automatically catch fish.")
        Me.EnableFishing.UseVisualStyleBackColor = True
        '
        'IdleTimer
        '
        Me.IdleTimer.Interval = 200
        '
        'FoodTimer
        '
        Me.FoodTimer.Interval = 45000
        '
        'FrameRateTimer
        '
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 6000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'FoodEater
        '
        '
        'Fisher
        '
        '
        'FishingTimer
        '
        Me.FishingTimer.Enabled = True
        Me.FishingTimer.Interval = 1000
        '
        'FurnitureWalker
        '
        Me.FurnitureWalker.AutoSize = True
        Me.FurnitureWalker.Location = New System.Drawing.Point(108, 65)
        Me.FurnitureWalker.Name = "FurnitureWalker"
        Me.FurnitureWalker.Size = New System.Drawing.Size(112, 17)
        Me.FurnitureWalker.TabIndex = 85
        Me.FurnitureWalker.Text = "Walk On Furniture"
        Me.ToolTip1.SetToolTip(Me.FurnitureWalker, "Walk over fire, poison, and energy fields with map click or cave walker.")
        Me.FurnitureWalker.UseVisualStyleBackColor = True
        '
        'Tools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(235, 280)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Tools"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TUGBot - Tools"
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents ShowHealPercent As System.Windows.Forms.CheckBox
    Friend WithEvents FieldWalker As System.Windows.Forms.CheckBox
    Friend WithEvents OpenPitfalls As System.Windows.Forms.CheckBox
    Friend WithEvents ReplaceTrees As System.Windows.Forms.CheckBox
    Friend WithEvents EnableLight As System.Windows.Forms.CheckBox
    Friend WithEvents EnableXray As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents AntiIdle As System.Windows.Forms.CheckBox
    Friend WithEvents IdleTimer As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents EatFood As System.Windows.Forms.CheckBox
    Friend WithEvents EnableFishing As System.Windows.Forms.CheckBox
    Friend WithEvents FrameRate As System.Windows.Forms.CheckBox
    Friend WithEvents FoodTimer As System.Windows.Forms.Timer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextToWatch As TUGBot.WaterMarkTextBox
    Friend WithEvents TradeWatchEnable As System.Windows.Forms.CheckBox
    Friend WithEvents FrameRateTimer As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents FoodEater As System.ComponentModel.BackgroundWorker
    Friend WithEvents Fisher As System.ComponentModel.BackgroundWorker
    Friend WithEvents FishingTimer As System.Windows.Forms.Timer
    Friend WithEvents ShowIds As System.Windows.Forms.CheckBox
    Friend WithEvents AutoStack As System.Windows.Forms.CheckBox
    Friend WithEvents FurnitureWalker As System.Windows.Forms.CheckBox
End Class
