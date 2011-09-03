<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class War
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
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.EnemyList = New System.Windows.Forms.ListBox
        Me.EnemyMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddEnemyPlayer = New System.Windows.Forms.ToolStripMenuItem
        Me.AddEnemyGuild = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.RemoveEnemyPlayer = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.ClearEnemyList = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.SaveEnemyList = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadEnemyMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.TeamMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddAllyPlayer = New System.Windows.Forms.ToolStripMenuItem
        Me.AddAllyGuild = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.RemoveSelectedAlly = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadAllyMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.AllyList = New System.Windows.Forms.ListBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.EnableAllyHealer = New System.Windows.Forms.CheckBox
        Me.PotionType = New System.Windows.Forms.TextBox
        Me.UseItem = New System.Windows.Forms.CheckBox
        Me.SioMana = New System.Windows.Forms.NumericUpDown
        Me.UseSio = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SioAt = New System.Windows.Forms.NumericUpDown
        Me.ShowTeamMarks = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ShowTeamSquares = New System.Windows.Forms.CheckBox
        Me.LastExiva = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LeaderRuneName = New System.Windows.Forms.TextBox
        Me.EnableSpellCombo = New System.Windows.Forms.CheckBox
        Me.ComboAtMana = New System.Windows.Forms.NumericUpDown
        Me.ComboWithSpell = New TUGBot.WaterMarkTextBox
        Me.ComboAtSpell = New TUGBot.WaterMarkTextBox
        Me.LeaderSpellName = New TUGBot.WaterMarkTextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RuneMakerType = New System.Windows.Forms.ComboBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox5.SuspendLayout()
        Me.EnemyMenu.SuspendLayout()
        Me.TeamMenu.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SioMana, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SioAt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ComboAtMana, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.EnemyList)
        Me.GroupBox5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox5.Location = New System.Drawing.Point(159, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(151, 187)
        Me.GroupBox5.TabIndex = 6
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Enemies"
        '
        'EnemyList
        '
        Me.EnemyList.ContextMenuStrip = Me.EnemyMenu
        Me.EnemyList.FormattingEnabled = True
        Me.EnemyList.Location = New System.Drawing.Point(6, 19)
        Me.EnemyList.Name = "EnemyList"
        Me.EnemyList.Size = New System.Drawing.Size(137, 160)
        Me.EnemyList.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.EnemyList, "A list of enemies, used for many Warbot related features.")
        '
        'EnemyMenu
        '
        Me.EnemyMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddEnemyPlayer, Me.AddEnemyGuild, Me.ToolStripSeparator4, Me.RemoveEnemyPlayer, Me.ToolStripSeparator5, Me.ClearEnemyList, Me.ToolStripSeparator6, Me.SaveEnemyList, Me.LoadEnemyMenu})
        Me.EnemyMenu.Name = "TeamMenu"
        Me.EnemyMenu.Size = New System.Drawing.Size(165, 154)
        '
        'AddEnemyPlayer
        '
        Me.AddEnemyPlayer.Name = "AddEnemyPlayer"
        Me.AddEnemyPlayer.Size = New System.Drawing.Size(164, 22)
        Me.AddEnemyPlayer.Text = "Add Player.."
        '
        'AddEnemyGuild
        '
        Me.AddEnemyGuild.Name = "AddEnemyGuild"
        Me.AddEnemyGuild.Size = New System.Drawing.Size(164, 22)
        Me.AddEnemyGuild.Text = "Add Guild.."
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(161, 6)
        '
        'RemoveEnemyPlayer
        '
        Me.RemoveEnemyPlayer.Name = "RemoveEnemyPlayer"
        Me.RemoveEnemyPlayer.Size = New System.Drawing.Size(164, 22)
        Me.RemoveEnemyPlayer.Text = "Remove Selected"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(161, 6)
        '
        'ClearEnemyList
        '
        Me.ClearEnemyList.Name = "ClearEnemyList"
        Me.ClearEnemyList.Size = New System.Drawing.Size(164, 22)
        Me.ClearEnemyList.Text = "Clear List"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(161, 6)
        '
        'SaveEnemyList
        '
        Me.SaveEnemyList.Name = "SaveEnemyList"
        Me.SaveEnemyList.Size = New System.Drawing.Size(164, 22)
        Me.SaveEnemyList.Text = "Save List.."
        '
        'LoadEnemyMenu
        '
        Me.LoadEnemyMenu.Name = "LoadEnemyMenu"
        Me.LoadEnemyMenu.Size = New System.Drawing.Size(164, 22)
        Me.LoadEnemyMenu.Text = "Load List.."
        '
        'TeamMenu
        '
        Me.TeamMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddAllyPlayer, Me.AddAllyGuild, Me.ToolStripSeparator1, Me.RemoveSelectedAlly, Me.ToolStripSeparator2, Me.ClearToolStripMenuItem, Me.ToolStripSeparator3, Me.SaveToolStripMenuItem, Me.LoadAllyMenu})
        Me.TeamMenu.Name = "TeamMenu"
        Me.TeamMenu.Size = New System.Drawing.Size(165, 154)
        '
        'AddAllyPlayer
        '
        Me.AddAllyPlayer.Name = "AddAllyPlayer"
        Me.AddAllyPlayer.Size = New System.Drawing.Size(164, 22)
        Me.AddAllyPlayer.Text = "Add Player.."
        '
        'AddAllyGuild
        '
        Me.AddAllyGuild.Name = "AddAllyGuild"
        Me.AddAllyGuild.Size = New System.Drawing.Size(164, 22)
        Me.AddAllyGuild.Text = "Add Guild.."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(161, 6)
        '
        'RemoveSelectedAlly
        '
        Me.RemoveSelectedAlly.Name = "RemoveSelectedAlly"
        Me.RemoveSelectedAlly.Size = New System.Drawing.Size(164, 22)
        Me.RemoveSelectedAlly.Text = "Remove Selected"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(161, 6)
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.ClearToolStripMenuItem.Text = "Clear List"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(161, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.SaveToolStripMenuItem.Text = "Save List.."
        '
        'LoadAllyMenu
        '
        Me.LoadAllyMenu.Name = "LoadAllyMenu"
        Me.LoadAllyMenu.Size = New System.Drawing.Size(164, 22)
        Me.LoadAllyMenu.Text = "Load List.."
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.AllyList)
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox4.Location = New System.Drawing.Point(2, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(151, 187)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Allies"
        '
        'AllyList
        '
        Me.AllyList.ContextMenuStrip = Me.TeamMenu
        Me.AllyList.FormattingEnabled = True
        Me.AllyList.Location = New System.Drawing.Point(6, 19)
        Me.AllyList.Name = "AllyList"
        Me.AllyList.Size = New System.Drawing.Size(137, 160)
        Me.AllyList.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.AllyList, "A list of allies, used for many Warbot related features")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.EnableAllyHealer)
        Me.GroupBox1.Controls.Add(Me.PotionType)
        Me.GroupBox1.Controls.Add(Me.UseItem)
        Me.GroupBox1.Controls.Add(Me.SioMana)
        Me.GroupBox1.Controls.Add(Me.UseSio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.SioAt)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox1.Location = New System.Drawing.Point(2, 193)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(190, 111)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ally Healer"
        '
        'EnableAllyHealer
        '
        Me.EnableAllyHealer.AutoSize = True
        Me.EnableAllyHealer.Location = New System.Drawing.Point(9, 89)
        Me.EnableAllyHealer.Name = "EnableAllyHealer"
        Me.EnableAllyHealer.Size = New System.Drawing.Size(112, 17)
        Me.EnableAllyHealer.TabIndex = 9
        Me.EnableAllyHealer.Text = "Enable Ally Healer"
        Me.ToolTip1.SetToolTip(Me.EnableAllyHealer, "Enable automatic ally healing.")
        Me.EnableAllyHealer.UseVisualStyleBackColor = True
        '
        'PotionType
        '
        Me.PotionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.PotionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.PotionType.Enabled = False
        Me.PotionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.PotionType.Location = New System.Drawing.Point(76, 64)
        Me.PotionType.MaxLength = 30
        Me.PotionType.Name = "PotionType"
        Me.PotionType.Size = New System.Drawing.Size(108, 20)
        Me.PotionType.TabIndex = 8
        Me.PotionType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.PotionType, "The item ID to heal with.")
        '
        'UseItem
        '
        Me.UseItem.AutoSize = True
        Me.UseItem.Enabled = False
        Me.UseItem.Location = New System.Drawing.Point(9, 66)
        Me.UseItem.Name = "UseItem"
        Me.UseItem.Size = New System.Drawing.Size(69, 17)
        Me.UseItem.TabIndex = 4
        Me.UseItem.Text = "Item - ID:"
        Me.ToolTip1.SetToolTip(Me.UseItem, "Enable healing with an item.")
        Me.UseItem.UseVisualStyleBackColor = True
        '
        'SioMana
        '
        Me.SioMana.Location = New System.Drawing.Point(116, 42)
        Me.SioMana.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.SioMana.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.SioMana.Name = "SioMana"
        Me.SioMana.Size = New System.Drawing.Size(68, 20)
        Me.SioMana.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.SioMana, "The mana you must have before casting Exura Sio.")
        Me.SioMana.Value = New Decimal(New Integer() {140, 0, 0, 0})
        '
        'UseSio
        '
        Me.UseSio.AutoSize = True
        Me.UseSio.Checked = True
        Me.UseSio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UseSio.Enabled = False
        Me.UseSio.Location = New System.Drawing.Point(9, 43)
        Me.UseSio.Name = "UseSio"
        Me.UseSio.Size = New System.Drawing.Size(110, 17)
        Me.UseSio.TabIndex = 2
        Me.UseSio.Text = "Exura Sio - Mana:"
        Me.UseSio.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Heal When Health % Below:"
        '
        'SioAt
        '
        Me.SioAt.Location = New System.Drawing.Point(150, 16)
        Me.SioAt.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.SioAt.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.SioAt.Name = "SioAt"
        Me.SioAt.Size = New System.Drawing.Size(34, 20)
        Me.SioAt.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.SioAt, "If an ally has health below this percent, heal them.")
        Me.SioAt.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'ShowTeamMarks
        '
        Me.ShowTeamMarks.AutoSize = True
        Me.ShowTeamMarks.BackColor = System.Drawing.Color.Transparent
        Me.ShowTeamMarks.Location = New System.Drawing.Point(9, 19)
        Me.ShowTeamMarks.Name = "ShowTeamMarks"
        Me.ShowTeamMarks.Size = New System.Drawing.Size(85, 17)
        Me.ShowTeamMarks.TabIndex = 15
        Me.ShowTeamMarks.Text = "Team Marks"
        Me.ToolTip1.SetToolTip(Me.ShowTeamMarks, "Show a blue ""(A)"" by ally names and a red ""(E)"" by enemy names.")
        Me.ShowTeamMarks.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ShowTeamSquares)
        Me.GroupBox2.Controls.Add(Me.ShowTeamMarks)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox2.Location = New System.Drawing.Point(198, 193)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(112, 62)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Identifiers"
        '
        'ShowTeamSquares
        '
        Me.ShowTeamSquares.AutoSize = True
        Me.ShowTeamSquares.BackColor = System.Drawing.Color.Transparent
        Me.ShowTeamSquares.Location = New System.Drawing.Point(9, 42)
        Me.ShowTeamSquares.Name = "ShowTeamSquares"
        Me.ShowTeamSquares.Size = New System.Drawing.Size(95, 17)
        Me.ShowTeamSquares.TabIndex = 16
        Me.ShowTeamSquares.Text = "Team Squares"
        Me.ToolTip1.SetToolTip(Me.ShowTeamSquares, "Change the blacksquare colors of allies and enemies, and show a yellow square aro" & _
                "und the last person you casted ""Exiva"" on.")
        Me.ShowTeamSquares.UseVisualStyleBackColor = False
        '
        'LastExiva
        '
        Me.LastExiva.Interval = 500
        '
        'LeaderRuneName
        '
        Me.LeaderRuneName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.LeaderRuneName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.LeaderRuneName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LeaderRuneName.Location = New System.Drawing.Point(6, 19)
        Me.LeaderRuneName.MaxLength = 30
        Me.LeaderRuneName.Name = "LeaderRuneName"
        Me.LeaderRuneName.Size = New System.Drawing.Size(133, 20)
        Me.LeaderRuneName.TabIndex = 9
        Me.LeaderRuneName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.LeaderRuneName, "The item ID to heal with.")
        '
        'EnableSpellCombo
        '
        Me.EnableSpellCombo.AutoSize = True
        Me.EnableSpellCombo.Location = New System.Drawing.Point(9, 136)
        Me.EnableSpellCombo.Name = "EnableSpellCombo"
        Me.EnableSpellCombo.Size = New System.Drawing.Size(121, 17)
        Me.EnableSpellCombo.TabIndex = 10
        Me.EnableSpellCombo.Text = "Enable Spell Combo"
        Me.ToolTip1.SetToolTip(Me.EnableSpellCombo, "Enable automatic ally healing.")
        Me.EnableSpellCombo.UseVisualStyleBackColor = True
        '
        'ComboAtMana
        '
        Me.ComboAtMana.Location = New System.Drawing.Point(92, 111)
        Me.ComboAtMana.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.ComboAtMana.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.ComboAtMana.Name = "ComboAtMana"
        Me.ComboAtMana.Size = New System.Drawing.Size(47, 20)
        Me.ComboAtMana.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.ComboAtMana, "The mana you must have before casting Exura Sio.")
        Me.ComboAtMana.Value = New Decimal(New Integer() {140, 0, 0, 0})
        '
        'ComboWithSpell
        '
        Me.ComboWithSpell.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboWithSpell.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboWithSpell.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ComboWithSpell.Location = New System.Drawing.Point(45, 84)
        Me.ComboWithSpell.MaxLength = 30
        Me.ComboWithSpell.Name = "ComboWithSpell"
        Me.ComboWithSpell.Size = New System.Drawing.Size(94, 20)
        Me.ComboWithSpell.TabIndex = 14
        Me.ComboWithSpell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.ComboWithSpell, "The item ID to heal with.")
        Me.ComboWithSpell.WaterMarkColor = System.Drawing.Color.Gray
        Me.ComboWithSpell.WaterMarkText = "Spell/Shortcut"
        '
        'ComboAtSpell
        '
        Me.ComboAtSpell.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboAtSpell.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboAtSpell.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ComboAtSpell.Location = New System.Drawing.Point(45, 58)
        Me.ComboAtSpell.MaxLength = 30
        Me.ComboAtSpell.Name = "ComboAtSpell"
        Me.ComboAtSpell.Size = New System.Drawing.Size(94, 20)
        Me.ComboAtSpell.TabIndex = 12
        Me.ComboAtSpell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.ComboAtSpell, "The item ID to heal with.")
        Me.ComboAtSpell.WaterMarkColor = System.Drawing.Color.Gray
        Me.ComboAtSpell.WaterMarkText = "Spell"
        '
        'LeaderSpellName
        '
        Me.LeaderSpellName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.LeaderSpellName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.LeaderSpellName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LeaderSpellName.Location = New System.Drawing.Point(9, 32)
        Me.LeaderSpellName.MaxLength = 30
        Me.LeaderSpellName.Name = "LeaderSpellName"
        Me.LeaderSpellName.Size = New System.Drawing.Size(130, 20)
        Me.LeaderSpellName.TabIndex = 9
        Me.LeaderSpellName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.LeaderSpellName, "The item ID to heal with.")
        Me.LeaderSpellName.WaterMarkColor = System.Drawing.Color.Gray
        Me.LeaderSpellName.WaterMarkText = "Player Name"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RuneMakerType)
        Me.GroupBox3.Controls.Add(Me.LeaderRuneName)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox3.Location = New System.Drawing.Point(316, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(145, 139)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rune Combo Bot"
        '
        'RuneMakerType
        '
        Me.RuneMakerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RuneMakerType.FormattingEnabled = True
        Me.RuneMakerType.Items.AddRange(New Object() {"Rune", "Spear"})
        Me.RuneMakerType.Location = New System.Drawing.Point(6, 45)
        Me.RuneMakerType.Name = "RuneMakerType"
        Me.RuneMakerType.Size = New System.Drawing.Size(133, 21)
        Me.RuneMakerType.TabIndex = 24
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.ComboAtMana)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.EnableSpellCombo)
        Me.GroupBox6.Controls.Add(Me.ComboWithSpell)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.ComboAtSpell)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.LeaderSpellName)
        Me.GroupBox6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox6.Location = New System.Drawing.Point(316, 145)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(145, 159)
        Me.GroupBox6.TabIndex = 25
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Spell Combo Bot"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "If Mana Above:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Say:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Says:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "When Player:"
        '
        'War
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(464, 307)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "War"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TUGBot - War"
        Me.GroupBox5.ResumeLayout(False)
        Me.EnemyMenu.ResumeLayout(False)
        Me.TeamMenu.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.SioMana, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SioAt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ComboAtMana, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents EnemyList As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents AllyList As System.Windows.Forms.ListBox
    Friend WithEvents TeamMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddAllyPlayer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddAllyGuild As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RemoveSelectedAlly As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents UseItem As System.Windows.Forms.CheckBox
    Friend WithEvents SioMana As System.Windows.Forms.NumericUpDown
    Friend WithEvents UseSio As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SioAt As System.Windows.Forms.NumericUpDown
    Friend WithEvents EnableAllyHealer As System.Windows.Forms.CheckBox
    Friend WithEvents PotionType As System.Windows.Forms.TextBox
    Friend WithEvents EnemyMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddEnemyPlayer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddEnemyGuild As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RemoveEnemyPlayer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ClearEnemyList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveEnemyList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadAllyMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadEnemyMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowTeamMarks As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ShowTeamSquares As System.Windows.Forms.CheckBox
    Friend WithEvents LastExiva As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents LeaderRuneName As System.Windows.Forms.TextBox
    Friend WithEvents RuneMakerType As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents EnableSpellCombo As System.Windows.Forms.CheckBox
    Friend WithEvents ComboWithSpell As TUGBot.WaterMarkTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboAtSpell As TUGBot.WaterMarkTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LeaderSpellName As TUGBot.WaterMarkTextBox
    Friend WithEvents ComboAtMana As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
