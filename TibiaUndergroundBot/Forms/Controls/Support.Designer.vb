<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Support
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
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.ManaRestoreEnabled = New System.Windows.Forms.CheckBox
        Me.RestoreAtMana = New TUGBot.WaterMarkTextBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.PoisonSpell = New System.Windows.Forms.RadioButton
        Me.PoisonRune = New System.Windows.Forms.RadioButton
        Me.EnablePoison = New System.Windows.Forms.CheckBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.ParalyzeSpell = New TUGBot.WaterMarkTextBox
        Me.EnableParalyze = New System.Windows.Forms.CheckBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.EnableHealItem = New System.Windows.Forms.CheckBox
        Me.EnableSpellLo = New System.Windows.Forms.CheckBox
        Me.EnableSpellHi = New System.Windows.Forms.CheckBox
        Me.PotionHealth = New TUGBot.WaterMarkTextBox
        Me.ManaLo = New TUGBot.WaterMarkTextBox
        Me.HealthLo = New TUGBot.WaterMarkTextBox
        Me.SpellLo = New TUGBot.WaterMarkTextBox
        Me.ManaHi = New TUGBot.WaterMarkTextBox
        Me.HealthHi = New TUGBot.WaterMarkTextBox
        Me.SpellHi = New TUGBot.WaterMarkTextBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HealingPriorityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EnableDouble = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.PriorityType = New System.Windows.Forms.ToolStripComboBox
        Me.HealDelay = New System.Windows.Forms.ToolStripTextBox
        Me.HealingDelayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ItemTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SpellTimer = New System.Windows.Forms.Timer(Me.components)
        Me.BoxTimer = New System.Windows.Forms.Timer(Me.components)
        Me.PotionType = New TUGBot.WaterMarkTextBox
        Me.RestoreType = New TUGBot.WaterMarkTextBox
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.RestoreType)
        Me.GroupBox9.Controls.Add(Me.ManaRestoreEnabled)
        Me.GroupBox9.Controls.Add(Me.RestoreAtMana)
        Me.GroupBox9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox9.Location = New System.Drawing.Point(3, 176)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(304, 42)
        Me.GroupBox9.TabIndex = 24
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Mana Restore"
        '
        'ManaRestoreEnabled
        '
        Me.ManaRestoreEnabled.AutoSize = True
        Me.ManaRestoreEnabled.BackColor = System.Drawing.Color.Transparent
        Me.ManaRestoreEnabled.Location = New System.Drawing.Point(239, 18)
        Me.ManaRestoreEnabled.Name = "ManaRestoreEnabled"
        Me.ManaRestoreEnabled.Size = New System.Drawing.Size(59, 17)
        Me.ManaRestoreEnabled.TabIndex = 20
        Me.ManaRestoreEnabled.Text = "Enable"
        Me.ManaRestoreEnabled.UseVisualStyleBackColor = False
        '
        'RestoreAtMana
        '
        Me.RestoreAtMana.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.RestoreAtMana.Location = New System.Drawing.Point(4, 16)
        Me.RestoreAtMana.MaxLength = 5
        Me.RestoreAtMana.Name = "RestoreAtMana"
        Me.RestoreAtMana.Size = New System.Drawing.Size(67, 20)
        Me.RestoreAtMana.TabIndex = 18
        Me.RestoreAtMana.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RestoreAtMana.WaterMarkColor = System.Drawing.Color.Gray
        Me.RestoreAtMana.WaterMarkText = "Mana"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.PoisonSpell)
        Me.GroupBox8.Controls.Add(Me.PoisonRune)
        Me.GroupBox8.Controls.Add(Me.EnablePoison)
        Me.GroupBox8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox8.Location = New System.Drawing.Point(144, 125)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(163, 45)
        Me.GroupBox8.TabIndex = 25
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Cure Poison"
        '
        'PoisonSpell
        '
        Me.PoisonSpell.AutoSize = True
        Me.PoisonSpell.Checked = True
        Me.PoisonSpell.Location = New System.Drawing.Point(6, 19)
        Me.PoisonSpell.Name = "PoisonSpell"
        Me.PoisonSpell.Size = New System.Drawing.Size(48, 17)
        Me.PoisonSpell.TabIndex = 15
        Me.PoisonSpell.TabStop = True
        Me.PoisonSpell.Text = "Spell"
        Me.PoisonSpell.UseVisualStyleBackColor = True
        '
        'PoisonRune
        '
        Me.PoisonRune.AutoSize = True
        Me.PoisonRune.Location = New System.Drawing.Point(54, 19)
        Me.PoisonRune.Name = "PoisonRune"
        Me.PoisonRune.Size = New System.Drawing.Size(51, 17)
        Me.PoisonRune.TabIndex = 16
        Me.PoisonRune.TabStop = True
        Me.PoisonRune.Text = "Rune"
        Me.PoisonRune.UseVisualStyleBackColor = True
        '
        'EnablePoison
        '
        Me.EnablePoison.AutoSize = True
        Me.EnablePoison.BackColor = System.Drawing.Color.Transparent
        Me.EnablePoison.Location = New System.Drawing.Point(105, 20)
        Me.EnablePoison.Name = "EnablePoison"
        Me.EnablePoison.Size = New System.Drawing.Size(59, 17)
        Me.EnablePoison.TabIndex = 17
        Me.EnablePoison.Text = "Enable"
        Me.EnablePoison.UseVisualStyleBackColor = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.ParalyzeSpell)
        Me.GroupBox7.Controls.Add(Me.EnableParalyze)
        Me.GroupBox7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox7.Location = New System.Drawing.Point(3, 125)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(134, 45)
        Me.GroupBox7.TabIndex = 23
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Cure Paralyze"
        '
        'ParalyzeSpell
        '
        Me.ParalyzeSpell.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ParalyzeSpell.Location = New System.Drawing.Point(4, 17)
        Me.ParalyzeSpell.MaxLength = 30
        Me.ParalyzeSpell.Name = "ParalyzeSpell"
        Me.ParalyzeSpell.Size = New System.Drawing.Size(67, 20)
        Me.ParalyzeSpell.TabIndex = 13
        Me.ParalyzeSpell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ParalyzeSpell.WaterMarkColor = System.Drawing.Color.Gray
        Me.ParalyzeSpell.WaterMarkText = "Spell"
        '
        'EnableParalyze
        '
        Me.EnableParalyze.AutoSize = True
        Me.EnableParalyze.BackColor = System.Drawing.Color.Transparent
        Me.EnableParalyze.Location = New System.Drawing.Point(77, 19)
        Me.EnableParalyze.Name = "EnableParalyze"
        Me.EnableParalyze.Size = New System.Drawing.Size(59, 17)
        Me.EnableParalyze.TabIndex = 14
        Me.EnableParalyze.Text = "Enable"
        Me.EnableParalyze.UseVisualStyleBackColor = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.PotionType)
        Me.GroupBox6.Controls.Add(Me.EnableHealItem)
        Me.GroupBox6.Controls.Add(Me.EnableSpellLo)
        Me.GroupBox6.Controls.Add(Me.EnableSpellHi)
        Me.GroupBox6.Controls.Add(Me.PotionHealth)
        Me.GroupBox6.Controls.Add(Me.ManaLo)
        Me.GroupBox6.Controls.Add(Me.HealthLo)
        Me.GroupBox6.Controls.Add(Me.SpellLo)
        Me.GroupBox6.Controls.Add(Me.ManaHi)
        Me.GroupBox6.Controls.Add(Me.HealthHi)
        Me.GroupBox6.Controls.Add(Me.SpellHi)
        Me.GroupBox6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox6.Location = New System.Drawing.Point(3, 27)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(304, 92)
        Me.GroupBox6.TabIndex = 22
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Healing"
        '
        'EnableHealItem
        '
        Me.EnableHealItem.AutoSize = True
        Me.EnableHealItem.Location = New System.Drawing.Point(239, 69)
        Me.EnableHealItem.Name = "EnableHealItem"
        Me.EnableHealItem.Size = New System.Drawing.Size(59, 17)
        Me.EnableHealItem.TabIndex = 11
        Me.EnableHealItem.Text = "Enable"
        Me.EnableHealItem.UseVisualStyleBackColor = True
        '
        'EnableSpellLo
        '
        Me.EnableSpellLo.AutoSize = True
        Me.EnableSpellLo.Location = New System.Drawing.Point(239, 43)
        Me.EnableSpellLo.Name = "EnableSpellLo"
        Me.EnableSpellLo.Size = New System.Drawing.Size(59, 17)
        Me.EnableSpellLo.TabIndex = 8
        Me.EnableSpellLo.Text = "Enable"
        Me.EnableSpellLo.UseVisualStyleBackColor = True
        '
        'EnableSpellHi
        '
        Me.EnableSpellHi.AutoSize = True
        Me.EnableSpellHi.Location = New System.Drawing.Point(239, 16)
        Me.EnableSpellHi.Name = "EnableSpellHi"
        Me.EnableSpellHi.Size = New System.Drawing.Size(59, 17)
        Me.EnableSpellHi.TabIndex = 4
        Me.EnableSpellHi.Text = "Enable"
        Me.EnableSpellHi.UseVisualStyleBackColor = True
        '
        'PotionHealth
        '
        Me.PotionHealth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.PotionHealth.Location = New System.Drawing.Point(181, 67)
        Me.PotionHealth.MaxLength = 5
        Me.PotionHealth.Name = "PotionHealth"
        Me.PotionHealth.Size = New System.Drawing.Size(48, 20)
        Me.PotionHealth.TabIndex = 10
        Me.PotionHealth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.PotionHealth.WaterMarkColor = System.Drawing.Color.Gray
        Me.PotionHealth.WaterMarkText = "Health"
        '
        'ManaLo
        '
        Me.ManaLo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ManaLo.Location = New System.Drawing.Point(181, 41)
        Me.ManaLo.MaxLength = 5
        Me.ManaLo.Name = "ManaLo"
        Me.ManaLo.Size = New System.Drawing.Size(48, 20)
        Me.ManaLo.TabIndex = 7
        Me.ManaLo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ManaLo.WaterMarkColor = System.Drawing.Color.Gray
        Me.ManaLo.WaterMarkText = "Mana"
        '
        'HealthLo
        '
        Me.HealthLo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.HealthLo.Location = New System.Drawing.Point(126, 41)
        Me.HealthLo.MaxLength = 5
        Me.HealthLo.Name = "HealthLo"
        Me.HealthLo.Size = New System.Drawing.Size(49, 20)
        Me.HealthLo.TabIndex = 6
        Me.HealthLo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.HealthLo.WaterMarkColor = System.Drawing.Color.Gray
        Me.HealthLo.WaterMarkText = "Health"
        '
        'SpellLo
        '
        Me.SpellLo.AutoCompleteCustomSource.AddRange(New String() {"Exura", "Exura Gran", "Exura Vita", "Exura San", "Exana Mort"})
        Me.SpellLo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.SpellLo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.SpellLo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.SpellLo.Location = New System.Drawing.Point(4, 41)
        Me.SpellLo.MaxLength = 30
        Me.SpellLo.Name = "SpellLo"
        Me.SpellLo.Size = New System.Drawing.Size(116, 20)
        Me.SpellLo.TabIndex = 5
        Me.SpellLo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SpellLo.WaterMarkColor = System.Drawing.Color.Gray
        Me.SpellLo.WaterMarkText = "Spell Lo"
        '
        'ManaHi
        '
        Me.ManaHi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ManaHi.Location = New System.Drawing.Point(181, 13)
        Me.ManaHi.MaxLength = 5
        Me.ManaHi.Name = "ManaHi"
        Me.ManaHi.Size = New System.Drawing.Size(48, 20)
        Me.ManaHi.TabIndex = 3
        Me.ManaHi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ManaHi.WaterMarkColor = System.Drawing.Color.Gray
        Me.ManaHi.WaterMarkText = "Mana"
        '
        'HealthHi
        '
        Me.HealthHi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.HealthHi.Location = New System.Drawing.Point(126, 13)
        Me.HealthHi.MaxLength = 5
        Me.HealthHi.Name = "HealthHi"
        Me.HealthHi.Size = New System.Drawing.Size(49, 20)
        Me.HealthHi.TabIndex = 2
        Me.HealthHi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.HealthHi.WaterMarkColor = System.Drawing.Color.Gray
        Me.HealthHi.WaterMarkText = "Health"
        '
        'SpellHi
        '
        Me.SpellHi.AutoCompleteCustomSource.AddRange(New String() {"Exura", "Exura Gran", "Exura Vita", "Exura San", "Exana Mort"})
        Me.SpellHi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.SpellHi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.SpellHi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.SpellHi.Location = New System.Drawing.Point(4, 13)
        Me.SpellHi.MaxLength = 30
        Me.SpellHi.Name = "SpellHi"
        Me.SpellHi.Size = New System.Drawing.Size(116, 20)
        Me.SpellHi.TabIndex = 1
        Me.SpellHi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SpellHi.WaterMarkColor = System.Drawing.Color.Gray
        Me.SpellHi.WaterMarkText = "Spell Hi"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.HealDelay, Me.HealingDelayToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(311, 27)
        Me.MenuStrip1.TabIndex = 28
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HealingPriorityToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 23)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'HealingPriorityToolStripMenuItem
        '
        Me.HealingPriorityToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnableDouble, Me.ToolStripSeparator1, Me.PriorityType})
        Me.HealingPriorityToolStripMenuItem.Name = "HealingPriorityToolStripMenuItem"
        Me.HealingPriorityToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.HealingPriorityToolStripMenuItem.Text = "Healing Priority"
        '
        'EnableDouble
        '
        Me.EnableDouble.CheckOnClick = True
        Me.EnableDouble.Name = "EnableDouble"
        Me.EnableDouble.Size = New System.Drawing.Size(310, 22)
        Me.EnableDouble.Text = "Double Healing"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(307, 6)
        '
        'PriorityType
        '
        Me.PriorityType.AutoSize = False
        Me.PriorityType.Items.AddRange(New Object() {"Healing Spell -> Healing Item -> Mana Restore", "Healing Item -> Healing Spell -> Mana Restore", "Healing Spell -> Mana Restore -> Healing Item", "Healing Item -> Mana Restore -> Healing Spell", "Mana Restore -> Healing Spell -> Healing Item", "Mana Restore -> Healing Item -> Healing Spell"})
        Me.PriorityType.Name = "PriorityType"
        Me.PriorityType.Size = New System.Drawing.Size(250, 23)
        '
        'HealDelay
        '
        Me.HealDelay.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.HealDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HealDelay.Margin = New System.Windows.Forms.Padding(1, 0, 8, 0)
        Me.HealDelay.Name = "HealDelay"
        Me.HealDelay.Size = New System.Drawing.Size(50, 23)
        Me.HealDelay.Text = "1500"
        Me.HealDelay.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'HealingDelayToolStripMenuItem
        '
        Me.HealingDelayToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.HealingDelayToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.HealingDelayToolStripMenuItem.Enabled = False
        Me.HealingDelayToolStripMenuItem.Name = "HealingDelayToolStripMenuItem"
        Me.HealingDelayToolStripMenuItem.Size = New System.Drawing.Size(95, 23)
        Me.HealingDelayToolStripMenuItem.Text = "Healing Delay:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.GroupBox8)
        Me.Panel1.Controls.Add(Me.GroupBox7)
        Me.Panel1.Controls.Add(Me.GroupBox9)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(311, 223)
        Me.Panel1.TabIndex = 29
        '
        'ItemTimer
        '
        Me.ItemTimer.Enabled = True
        Me.ItemTimer.Interval = 200
        '
        'SpellTimer
        '
        Me.SpellTimer.Enabled = True
        Me.SpellTimer.Interval = 2
        '
        'BoxTimer
        '
        Me.BoxTimer.Interval = 10
        '
        'PotionType
        '
        Me.PotionType.AutoCompleteCustomSource.AddRange(New String() {"Exura", "Exura Gran", "Exura Vita", "Exura San", "Exana Mort"})
        Me.PotionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.PotionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.PotionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.PotionType.Location = New System.Drawing.Point(4, 66)
        Me.PotionType.MaxLength = 30
        Me.PotionType.Name = "PotionType"
        Me.PotionType.Size = New System.Drawing.Size(171, 20)
        Me.PotionType.TabIndex = 12
        Me.PotionType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.PotionType.WaterMarkColor = System.Drawing.Color.Gray
        Me.PotionType.WaterMarkText = "Item [ID/Shortcut]"
        '
        'RestoreType
        '
        Me.RestoreType.AutoCompleteCustomSource.AddRange(New String() {"Exura", "Exura Gran", "Exura Vita", "Exura San", "Exana Mort"})
        Me.RestoreType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.RestoreType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.RestoreType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.RestoreType.Location = New System.Drawing.Point(77, 16)
        Me.RestoreType.MaxLength = 30
        Me.RestoreType.Name = "RestoreType"
        Me.RestoreType.Size = New System.Drawing.Size(152, 20)
        Me.RestoreType.TabIndex = 13
        Me.RestoreType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RestoreType.WaterMarkColor = System.Drawing.Color.Gray
        Me.RestoreType.WaterMarkText = "Potion [ID/Shortcut]"
        '
        'Support
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(311, 223)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Support"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TUGBot - Support"
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents ManaRestoreEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents RestoreAtMana As TUGBot.WaterMarkTextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents PoisonSpell As System.Windows.Forms.RadioButton
    Friend WithEvents PoisonRune As System.Windows.Forms.RadioButton
    Friend WithEvents EnablePoison As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents ParalyzeSpell As TUGBot.WaterMarkTextBox
    Friend WithEvents EnableParalyze As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents EnableHealItem As System.Windows.Forms.CheckBox
    Friend WithEvents EnableSpellLo As System.Windows.Forms.CheckBox
    Friend WithEvents EnableSpellHi As System.Windows.Forms.CheckBox
    Friend WithEvents PotionHealth As TUGBot.WaterMarkTextBox
    Friend WithEvents ManaLo As TUGBot.WaterMarkTextBox
    Friend WithEvents HealthLo As TUGBot.WaterMarkTextBox
    Friend WithEvents SpellLo As TUGBot.WaterMarkTextBox
    Friend WithEvents ManaHi As TUGBot.WaterMarkTextBox
    Friend WithEvents HealthHi As TUGBot.WaterMarkTextBox
    Friend WithEvents SpellHi As TUGBot.WaterMarkTextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HealingPriorityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PriorityType As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents EnableDouble As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ItemTimer As System.Windows.Forms.Timer
    Friend WithEvents SpellTimer As System.Windows.Forms.Timer
    Friend WithEvents HealDelay As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents HealingDelayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BoxTimer As System.Windows.Forms.Timer
    Friend WithEvents RestoreType As TUGBot.WaterMarkTextBox
    Friend WithEvents PotionType As TUGBot.WaterMarkTextBox
End Class
