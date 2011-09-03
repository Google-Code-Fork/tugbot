<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Alarms
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.GMMessageLogout = New System.Windows.Forms.CheckBox
        Me.SoulLogout = New System.Windows.Forms.CheckBox
        Me.SoulLogoutAmount = New System.Windows.Forms.NumericUpDown
        Me.PlayerLogoutAll = New System.Windows.Forms.CheckBox
        Me.PlayerLogout = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GMSafeAll = New System.Windows.Forms.CheckBox
        Me.PlayerSafeAll = New System.Windows.Forms.CheckBox
        Me.PlayerSafe = New System.Windows.Forms.CheckBox
        Me.GMSafe = New System.Windows.Forms.CheckBox
        Me.GroupBox14 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.AlarmSpeed = New System.Windows.Forms.TrackBar
        Me.Volumesd = New System.Windows.Forms.Label
        Me.AlarmVolume = New System.Windows.Forms.TrackBar
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.UseSiren = New System.Windows.Forms.RadioButton
        Me.UseTTs = New System.Windows.Forms.RadioButton
        Me.AlarmFilter = New System.Windows.Forms.CheckBox
        Me.EnemyFilter = New System.Windows.Forms.RadioButton
        Me.AllyFilter = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.OnlyPlayerAttack = New System.Windows.Forms.CheckBox
        Me.GmAlert = New System.Windows.Forms.CheckBox
        Me.PlayerAlert = New System.Windows.Forms.CheckBox
        Me.PlayerAlertAll = New System.Windows.Forms.CheckBox
        Me.HPLossAlert = New System.Windows.Forms.CheckBox
        Me.GMAlertAll = New System.Windows.Forms.CheckBox
        Me.AttackAlert = New System.Windows.Forms.CheckBox
        Me.DisconnectAlert = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CapAlert = New System.Windows.Forms.CheckBox
        Me.CapAlertCompare = New System.Windows.Forms.NumericUpDown
        Me.SoulAlert = New System.Windows.Forms.CheckBox
        Me.SoulAlertCompare = New System.Windows.Forms.NumericUpDown
        Me.HealthAlert = New System.Windows.Forms.CheckBox
        Me.ManaAlert = New System.Windows.Forms.CheckBox
        Me.ManaAlertCompare = New System.Windows.Forms.NumericUpDown
        Me.HealthAlertCompare = New System.Windows.Forms.NumericUpDown
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.IgnoreSpells = New System.Windows.Forms.CheckBox
        Me.GMMessageAlert = New System.Windows.Forms.CheckBox
        Me.PrivateMessageAlert = New System.Windows.Forms.CheckBox
        Me.DefaultMessageAlert = New System.Windows.Forms.CheckBox
        Me.StatusTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TTSSpeaker = New System.ComponentModel.BackgroundWorker
        Me.TTSAdder = New System.ComponentModel.BackgroundWorker
        Me.AlarmToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.AutoLog = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.SoulLogoutAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.AlarmSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AlarmVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.CapAlertCompare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoulAlertCompare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ManaAlertCompare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HealthAlertCompare, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox14)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(532, 346)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox6.Controls.Add(Me.GMMessageLogout)
        Me.GroupBox6.Controls.Add(Me.SoulLogout)
        Me.GroupBox6.Controls.Add(Me.SoulLogoutAmount)
        Me.GroupBox6.Controls.Add(Me.PlayerLogoutAll)
        Me.GroupBox6.Controls.Add(Me.PlayerLogout)
        Me.GroupBox6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox6.Location = New System.Drawing.Point(338, 68)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(190, 89)
        Me.GroupBox6.TabIndex = 27
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Autolog"
        '
        'GMMessageLogout
        '
        Me.GMMessageLogout.AutoSize = True
        Me.GMMessageLogout.Location = New System.Drawing.Point(9, 65)
        Me.GMMessageLogout.Name = "GMMessageLogout"
        Me.GMMessageLogout.Size = New System.Drawing.Size(112, 17)
        Me.GMMessageLogout.TabIndex = 9
        Me.GMMessageLogout.Tag = ""
        Me.GMMessageLogout.Text = "Red GM Message"
        Me.AlarmToolTip.SetToolTip(Me.GMMessageLogout, "Logout if a Gamemaster or Community Manager broadcasts in red.")
        Me.GMMessageLogout.UseVisualStyleBackColor = True
        '
        'SoulLogout
        '
        Me.SoulLogout.AutoSize = True
        Me.SoulLogout.Location = New System.Drawing.Point(9, 42)
        Me.SoulLogout.Name = "SoulLogout"
        Me.SoulLogout.Size = New System.Drawing.Size(82, 17)
        Me.SoulLogout.TabIndex = 20
        Me.SoulLogout.Tag = ""
        Me.SoulLogout.Text = "Soul Below:"
        Me.AlarmToolTip.SetToolTip(Me.SoulLogout, "Logout when your soul falls below the selected value.")
        Me.SoulLogout.UseVisualStyleBackColor = True
        '
        'SoulLogoutAmount
        '
        Me.SoulLogoutAmount.Location = New System.Drawing.Point(117, 41)
        Me.SoulLogoutAmount.Maximum = New Decimal(New Integer() {65534, 0, 0, 0})
        Me.SoulLogoutAmount.Name = "SoulLogoutAmount"
        Me.SoulLogoutAmount.Size = New System.Drawing.Size(68, 20)
        Me.SoulLogoutAmount.TabIndex = 21
        '
        'PlayerLogoutAll
        '
        Me.PlayerLogoutAll.AutoSize = True
        Me.PlayerLogoutAll.Location = New System.Drawing.Point(117, 19)
        Me.PlayerLogoutAll.Name = "PlayerLogoutAll"
        Me.PlayerLogoutAll.Size = New System.Drawing.Size(68, 17)
        Me.PlayerLogoutAll.TabIndex = 7
        Me.PlayerLogoutAll.Tag = ""
        Me.PlayerLogoutAll.Text = "All Floors"
        Me.AlarmToolTip.SetToolTip(Me.PlayerLogoutAll, "If ""Player Detected"" is checked, check all floors and not just the current one.")
        Me.PlayerLogoutAll.UseVisualStyleBackColor = True
        '
        'PlayerLogout
        '
        Me.PlayerLogout.AutoSize = True
        Me.PlayerLogout.Location = New System.Drawing.Point(9, 19)
        Me.PlayerLogout.Name = "PlayerLogout"
        Me.PlayerLogout.Size = New System.Drawing.Size(102, 17)
        Me.PlayerLogout.TabIndex = 6
        Me.PlayerLogout.Tag = ""
        Me.PlayerLogout.Text = "Player Detected"
        Me.AlarmToolTip.SetToolTip(Me.PlayerLogout, "Logout when a player is detected.")
        Me.PlayerLogout.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(338, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(190, 57)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "ALERTS TODO:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "GM Detected [audio, safe, loggout]"
        Me.Label1.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox1.Controls.Add(Me.GMSafeAll)
        Me.GroupBox1.Controls.Add(Me.PlayerSafeAll)
        Me.GroupBox1.Controls.Add(Me.PlayerSafe)
        Me.GroupBox1.Controls.Add(Me.GMSafe)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox1.Location = New System.Drawing.Point(338, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(190, 62)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Safe Mode"
        '
        'GMSafeAll
        '
        Me.GMSafeAll.AutoSize = True
        Me.GMSafeAll.Enabled = False
        Me.GMSafeAll.Location = New System.Drawing.Point(117, 19)
        Me.GMSafeAll.Name = "GMSafeAll"
        Me.GMSafeAll.Size = New System.Drawing.Size(68, 17)
        Me.GMSafeAll.TabIndex = 8
        Me.GMSafeAll.Tag = ""
        Me.GMSafeAll.Text = "All Floors"
        Me.AlarmToolTip.SetToolTip(Me.GMSafeAll, "If ""GM Detected"" is checked, check all floors and not just the current one.")
        Me.GMSafeAll.UseVisualStyleBackColor = True
        '
        'PlayerSafeAll
        '
        Me.PlayerSafeAll.AutoSize = True
        Me.PlayerSafeAll.Location = New System.Drawing.Point(117, 42)
        Me.PlayerSafeAll.Name = "PlayerSafeAll"
        Me.PlayerSafeAll.Size = New System.Drawing.Size(68, 17)
        Me.PlayerSafeAll.TabIndex = 7
        Me.PlayerSafeAll.Tag = ""
        Me.PlayerSafeAll.Text = "All Floors"
        Me.AlarmToolTip.SetToolTip(Me.PlayerSafeAll, "If ""Player Detected"" is checked, check all floors and not just the current one.")
        Me.PlayerSafeAll.UseVisualStyleBackColor = True
        '
        'PlayerSafe
        '
        Me.PlayerSafe.AutoSize = True
        Me.PlayerSafe.Location = New System.Drawing.Point(9, 42)
        Me.PlayerSafe.Name = "PlayerSafe"
        Me.PlayerSafe.Size = New System.Drawing.Size(102, 17)
        Me.PlayerSafe.TabIndex = 6
        Me.PlayerSafe.Tag = ""
        Me.PlayerSafe.Text = "Player Detected"
        Me.AlarmToolTip.SetToolTip(Me.PlayerSafe, "Pause the bot when a player is detected.")
        Me.PlayerSafe.UseVisualStyleBackColor = True
        '
        'GMSafe
        '
        Me.GMSafe.AutoSize = True
        Me.GMSafe.Enabled = False
        Me.GMSafe.Location = New System.Drawing.Point(9, 19)
        Me.GMSafe.Name = "GMSafe"
        Me.GMSafe.Size = New System.Drawing.Size(90, 17)
        Me.GMSafe.TabIndex = 5
        Me.GMSafe.Tag = ""
        Me.GMSafe.Text = "GM Detected"
        Me.AlarmToolTip.SetToolTip(Me.GMSafe, "Pause the bot when a Gamemaster or Community Manager is detected.")
        Me.GMSafe.UseVisualStyleBackColor = True
        '
        'GroupBox14
        '
        Me.GroupBox14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox14.Controls.Add(Me.GroupBox5)
        Me.GroupBox14.Controls.Add(Me.GroupBox4)
        Me.GroupBox14.Controls.Add(Me.GroupBox3)
        Me.GroupBox14.Controls.Add(Me.GroupBox2)
        Me.GroupBox14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox14.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(329, 339)
        Me.GroupBox14.TabIndex = 25
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Audio Alarm"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox5.Controls.Add(Me.GroupBox7)
        Me.GroupBox5.Controls.Add(Me.Panel2)
        Me.GroupBox5.Controls.Add(Me.AlarmFilter)
        Me.GroupBox5.Controls.Add(Me.EnemyFilter)
        Me.GroupBox5.Controls.Add(Me.AllyFilter)
        Me.GroupBox5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox5.Location = New System.Drawing.Point(6, 13)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(123, 252)
        Me.GroupBox5.TabIndex = 28
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Settings"
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox7.Controls.Add(Me.Label2)
        Me.GroupBox7.Controls.Add(Me.AlarmVolume)
        Me.GroupBox7.Controls.Add(Me.AlarmSpeed)
        Me.GroupBox7.Controls.Add(Me.Volumesd)
        Me.GroupBox7.Controls.Add(Me.CheckBox1)
        Me.GroupBox7.Controls.Add(Me.CheckBox2)
        Me.GroupBox7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox7.Location = New System.Drawing.Point(6, 134)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(111, 111)
        Me.GroupBox7.TabIndex = 27
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "TTS Options"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(6, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Speed"
        '
        'AlarmSpeed
        '
        Me.AlarmSpeed.AutoSize = False
        Me.AlarmSpeed.Enabled = False
        Me.AlarmSpeed.LargeChange = 1
        Me.AlarmSpeed.Location = New System.Drawing.Point(3, 75)
        Me.AlarmSpeed.Maximum = 5
        Me.AlarmSpeed.Minimum = 1
        Me.AlarmSpeed.Name = "AlarmSpeed"
        Me.AlarmSpeed.Size = New System.Drawing.Size(104, 30)
        Me.AlarmSpeed.TabIndex = 11
        Me.AlarmSpeed.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.AlarmSpeed.Value = 5
        '
        'Volumesd
        '
        Me.Volumesd.AutoSize = True
        Me.Volumesd.Location = New System.Drawing.Point(6, 16)
        Me.Volumesd.Name = "Volumesd"
        Me.Volumesd.Size = New System.Drawing.Size(42, 13)
        Me.Volumesd.TabIndex = 10
        Me.Volumesd.Text = "Volume"
        '
        'AlarmVolume
        '
        Me.AlarmVolume.AutoSize = False
        Me.AlarmVolume.LargeChange = 1
        Me.AlarmVolume.Location = New System.Drawing.Point(3, 32)
        Me.AlarmVolume.Maximum = 100
        Me.AlarmVolume.Minimum = 1
        Me.AlarmVolume.Name = "AlarmVolume"
        Me.AlarmVolume.Size = New System.Drawing.Size(104, 30)
        Me.AlarmVolume.TabIndex = 9
        Me.AlarmVolume.TickFrequency = 5
        Me.AlarmVolume.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.AlarmVolume.Value = 100
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(117, 19)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(68, 17)
        Me.CheckBox1.TabIndex = 8
        Me.CheckBox1.Tag = ""
        Me.CheckBox1.Text = "All Floors"
        Me.AlarmToolTip.SetToolTip(Me.CheckBox1, "If ""GM Detected"" is checked, check all floors and not just the current one.")
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(117, 42)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(68, 17)
        Me.CheckBox2.TabIndex = 7
        Me.CheckBox2.Tag = ""
        Me.CheckBox2.Text = "All Floors"
        Me.AlarmToolTip.SetToolTip(Me.CheckBox2, "If ""Player Detected"" is checked, check all floors and not just the current one.")
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.UseSiren)
        Me.Panel2.Controls.Add(Me.UseTTs)
        Me.Panel2.Location = New System.Drawing.Point(6, 87)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(107, 41)
        Me.Panel2.TabIndex = 10
        '
        'UseSiren
        '
        Me.UseSiren.AutoSize = True
        Me.UseSiren.Enabled = False
        Me.UseSiren.Location = New System.Drawing.Point(3, 1)
        Me.UseSiren.Name = "UseSiren"
        Me.UseSiren.Size = New System.Drawing.Size(49, 17)
        Me.UseSiren.TabIndex = 9
        Me.UseSiren.Text = "Siren"
        Me.AlarmToolTip.SetToolTip(Me.UseSiren, "Alert using a siren.")
        Me.UseSiren.UseVisualStyleBackColor = True
        '
        'UseTTs
        '
        Me.UseTTs.AutoSize = True
        Me.UseTTs.Checked = True
        Me.UseTTs.Location = New System.Drawing.Point(3, 24)
        Me.UseTTs.Name = "UseTTs"
        Me.UseTTs.Size = New System.Drawing.Size(102, 17)
        Me.UseTTs.TabIndex = 8
        Me.UseTTs.TabStop = True
        Me.UseTTs.Text = "Text To Speech"
        Me.AlarmToolTip.SetToolTip(Me.UseTTs, "Alert using text to speech.")
        Me.UseTTs.UseVisualStyleBackColor = True
        '
        'AlarmFilter
        '
        Me.AlarmFilter.AutoSize = True
        Me.AlarmFilter.Checked = True
        Me.AlarmFilter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AlarmFilter.Location = New System.Drawing.Point(9, 19)
        Me.AlarmFilter.Name = "AlarmFilter"
        Me.AlarmFilter.Size = New System.Drawing.Size(48, 17)
        Me.AlarmFilter.TabIndex = 7
        Me.AlarmFilter.Tag = ""
        Me.AlarmFilter.Text = "Filter"
        Me.AlarmToolTip.SetToolTip(Me.AlarmFilter, "Enable a filter to exclude certain players from setting off any player related al" & _
                "arms.")
        Me.AlarmFilter.UseVisualStyleBackColor = True
        '
        'EnemyFilter
        '
        Me.EnemyFilter.AutoSize = True
        Me.EnemyFilter.Location = New System.Drawing.Point(18, 35)
        Me.EnemyFilter.Name = "EnemyFilter"
        Me.EnemyFilter.Size = New System.Drawing.Size(89, 17)
        Me.EnemyFilter.TabIndex = 1
        Me.EnemyFilter.Text = "Enemies Only"
        Me.AlarmToolTip.SetToolTip(Me.EnemyFilter, "Exclude everyone who is not an enemy from player related alarms.")
        Me.EnemyFilter.UseVisualStyleBackColor = True
        '
        'AllyFilter
        '
        Me.AllyFilter.AutoSize = True
        Me.AllyFilter.Checked = True
        Me.AllyFilter.Location = New System.Drawing.Point(18, 54)
        Me.AllyFilter.Name = "AllyFilter"
        Me.AllyFilter.Size = New System.Drawing.Size(82, 17)
        Me.AllyFilter.TabIndex = 0
        Me.AllyFilter.TabStop = True
        Me.AllyFilter.Text = "Ignore Allies"
        Me.AlarmToolTip.SetToolTip(Me.AllyFilter, "Exclude allies from player related alarms.")
        Me.AllyFilter.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox4.Controls.Add(Me.OnlyPlayerAttack)
        Me.GroupBox4.Controls.Add(Me.GmAlert)
        Me.GroupBox4.Controls.Add(Me.PlayerAlert)
        Me.GroupBox4.Controls.Add(Me.PlayerAlertAll)
        Me.GroupBox4.Controls.Add(Me.HPLossAlert)
        Me.GroupBox4.Controls.Add(Me.GMAlertAll)
        Me.GroupBox4.Controls.Add(Me.AttackAlert)
        Me.GroupBox4.Controls.Add(Me.DisconnectAlert)
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox4.Location = New System.Drawing.Point(135, 13)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(188, 134)
        Me.GroupBox4.TabIndex = 28
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Event Alerts"
        '
        'OnlyPlayerAttack
        '
        Me.OnlyPlayerAttack.AutoSize = True
        Me.OnlyPlayerAttack.Checked = True
        Me.OnlyPlayerAttack.CheckState = System.Windows.Forms.CheckState.Checked
        Me.OnlyPlayerAttack.Location = New System.Drawing.Point(98, 19)
        Me.OnlyPlayerAttack.Name = "OnlyPlayerAttack"
        Me.OnlyPlayerAttack.Size = New System.Drawing.Size(84, 17)
        Me.OnlyPlayerAttack.TabIndex = 14
        Me.OnlyPlayerAttack.Tag = ""
        Me.OnlyPlayerAttack.Text = "Players Only"
        Me.AlarmToolTip.SetToolTip(Me.OnlyPlayerAttack, "If ""Attacked"" is checked, alert only when it is a player attacking.")
        Me.OnlyPlayerAttack.UseVisualStyleBackColor = True
        '
        'GmAlert
        '
        Me.GmAlert.AutoSize = True
        Me.GmAlert.Enabled = False
        Me.GmAlert.Location = New System.Drawing.Point(6, 88)
        Me.GmAlert.Name = "GmAlert"
        Me.GmAlert.Size = New System.Drawing.Size(90, 17)
        Me.GmAlert.TabIndex = 5
        Me.GmAlert.Tag = ""
        Me.GmAlert.Text = "GM Detected"
        Me.AlarmToolTip.SetToolTip(Me.GmAlert, "Alert when a Gamemaster or Community Manager is detected.")
        Me.GmAlert.UseVisualStyleBackColor = True
        '
        'PlayerAlert
        '
        Me.PlayerAlert.AutoSize = True
        Me.PlayerAlert.Location = New System.Drawing.Point(6, 111)
        Me.PlayerAlert.Name = "PlayerAlert"
        Me.PlayerAlert.Size = New System.Drawing.Size(102, 17)
        Me.PlayerAlert.TabIndex = 6
        Me.PlayerAlert.Tag = ""
        Me.PlayerAlert.Text = "Player Detected"
        Me.AlarmToolTip.SetToolTip(Me.PlayerAlert, "Alert when a player is detected.")
        Me.PlayerAlert.UseVisualStyleBackColor = True
        '
        'PlayerAlertAll
        '
        Me.PlayerAlertAll.AutoSize = True
        Me.PlayerAlertAll.Location = New System.Drawing.Point(114, 111)
        Me.PlayerAlertAll.Name = "PlayerAlertAll"
        Me.PlayerAlertAll.Size = New System.Drawing.Size(68, 17)
        Me.PlayerAlertAll.TabIndex = 7
        Me.PlayerAlertAll.Tag = ""
        Me.PlayerAlertAll.Text = "All Floors"
        Me.AlarmToolTip.SetToolTip(Me.PlayerAlertAll, "If ""Player Detected"" is checked, check all floors and not just the current one.")
        Me.PlayerAlertAll.UseVisualStyleBackColor = True
        '
        'HPLossAlert
        '
        Me.HPLossAlert.AutoSize = True
        Me.HPLossAlert.Location = New System.Drawing.Point(6, 65)
        Me.HPLossAlert.Name = "HPLossAlert"
        Me.HPLossAlert.Size = New System.Drawing.Size(66, 17)
        Me.HPLossAlert.TabIndex = 13
        Me.HPLossAlert.Tag = ""
        Me.HPLossAlert.Text = "HP Loss"
        Me.AlarmToolTip.SetToolTip(Me.HPLossAlert, "Alert when you lose health.")
        Me.HPLossAlert.UseVisualStyleBackColor = True
        '
        'GMAlertAll
        '
        Me.GMAlertAll.AutoSize = True
        Me.GMAlertAll.Enabled = False
        Me.GMAlertAll.Location = New System.Drawing.Point(114, 88)
        Me.GMAlertAll.Name = "GMAlertAll"
        Me.GMAlertAll.Size = New System.Drawing.Size(68, 17)
        Me.GMAlertAll.TabIndex = 8
        Me.GMAlertAll.Tag = ""
        Me.GMAlertAll.Text = "All Floors"
        Me.AlarmToolTip.SetToolTip(Me.GMAlertAll, "If ""GM Detected"" is checked, check all floors and not just the current one.")
        Me.GMAlertAll.UseVisualStyleBackColor = True
        '
        'AttackAlert
        '
        Me.AttackAlert.AutoSize = True
        Me.AttackAlert.Location = New System.Drawing.Point(6, 19)
        Me.AttackAlert.Name = "AttackAlert"
        Me.AttackAlert.Size = New System.Drawing.Size(69, 17)
        Me.AttackAlert.TabIndex = 12
        Me.AttackAlert.Tag = ""
        Me.AttackAlert.Text = "Attacked"
        Me.AlarmToolTip.SetToolTip(Me.AttackAlert, "Alert when attacked.")
        Me.AttackAlert.UseVisualStyleBackColor = True
        '
        'DisconnectAlert
        '
        Me.DisconnectAlert.AutoSize = True
        Me.DisconnectAlert.Location = New System.Drawing.Point(6, 42)
        Me.DisconnectAlert.Name = "DisconnectAlert"
        Me.DisconnectAlert.Size = New System.Drawing.Size(92, 17)
        Me.DisconnectAlert.TabIndex = 11
        Me.DisconnectAlert.Tag = ""
        Me.DisconnectAlert.Text = "Disconnected"
        Me.AlarmToolTip.SetToolTip(Me.DisconnectAlert, "Alert when the Tibia client disconnects.")
        Me.DisconnectAlert.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox3.Controls.Add(Me.CapAlert)
        Me.GroupBox3.Controls.Add(Me.CapAlertCompare)
        Me.GroupBox3.Controls.Add(Me.SoulAlert)
        Me.GroupBox3.Controls.Add(Me.SoulAlertCompare)
        Me.GroupBox3.Controls.Add(Me.HealthAlert)
        Me.GroupBox3.Controls.Add(Me.ManaAlert)
        Me.GroupBox3.Controls.Add(Me.ManaAlertCompare)
        Me.GroupBox3.Controls.Add(Me.HealthAlertCompare)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox3.Location = New System.Drawing.Point(135, 153)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(188, 112)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Status Alerts"
        '
        'CapAlert
        '
        Me.CapAlert.AutoSize = True
        Me.CapAlert.Location = New System.Drawing.Point(6, 88)
        Me.CapAlert.Name = "CapAlert"
        Me.CapAlert.Size = New System.Drawing.Size(80, 17)
        Me.CapAlert.TabIndex = 18
        Me.CapAlert.Tag = ""
        Me.CapAlert.Text = "Cap Below:"
        Me.AlarmToolTip.SetToolTip(Me.CapAlert, "Alert when your capacity falls below the selected value.")
        Me.CapAlert.UseVisualStyleBackColor = True
        '
        'CapAlertCompare
        '
        Me.CapAlertCompare.Location = New System.Drawing.Point(114, 87)
        Me.CapAlertCompare.Maximum = New Decimal(New Integer() {65534, 0, 0, 0})
        Me.CapAlertCompare.Name = "CapAlertCompare"
        Me.CapAlertCompare.Size = New System.Drawing.Size(68, 20)
        Me.CapAlertCompare.TabIndex = 19
        '
        'SoulAlert
        '
        Me.SoulAlert.AutoSize = True
        Me.SoulAlert.Location = New System.Drawing.Point(6, 65)
        Me.SoulAlert.Name = "SoulAlert"
        Me.SoulAlert.Size = New System.Drawing.Size(82, 17)
        Me.SoulAlert.TabIndex = 16
        Me.SoulAlert.Tag = ""
        Me.SoulAlert.Text = "Soul Below:"
        Me.AlarmToolTip.SetToolTip(Me.SoulAlert, "Alert when your soul falls below the selected value.")
        Me.SoulAlert.UseVisualStyleBackColor = True
        '
        'SoulAlertCompare
        '
        Me.SoulAlertCompare.Location = New System.Drawing.Point(114, 64)
        Me.SoulAlertCompare.Maximum = New Decimal(New Integer() {65534, 0, 0, 0})
        Me.SoulAlertCompare.Name = "SoulAlertCompare"
        Me.SoulAlertCompare.Size = New System.Drawing.Size(68, 20)
        Me.SoulAlertCompare.TabIndex = 17
        '
        'HealthAlert
        '
        Me.HealthAlert.AutoSize = True
        Me.HealthAlert.Location = New System.Drawing.Point(6, 19)
        Me.HealthAlert.Name = "HealthAlert"
        Me.HealthAlert.Size = New System.Drawing.Size(92, 17)
        Me.HealthAlert.TabIndex = 9
        Me.HealthAlert.Tag = ""
        Me.HealthAlert.Text = "Health Below:"
        Me.AlarmToolTip.SetToolTip(Me.HealthAlert, "Alert when your health falls below the selected value.")
        Me.HealthAlert.UseVisualStyleBackColor = True
        '
        'ManaAlert
        '
        Me.ManaAlert.AutoSize = True
        Me.ManaAlert.Location = New System.Drawing.Point(6, 42)
        Me.ManaAlert.Name = "ManaAlert"
        Me.ManaAlert.Size = New System.Drawing.Size(88, 17)
        Me.ManaAlert.TabIndex = 10
        Me.ManaAlert.Tag = ""
        Me.ManaAlert.Text = "Mana Below:"
        Me.AlarmToolTip.SetToolTip(Me.ManaAlert, "Alert when your mana falls below the selected value.")
        Me.ManaAlert.UseVisualStyleBackColor = True
        '
        'ManaAlertCompare
        '
        Me.ManaAlertCompare.Location = New System.Drawing.Point(114, 41)
        Me.ManaAlertCompare.Maximum = New Decimal(New Integer() {65534, 0, 0, 0})
        Me.ManaAlertCompare.Name = "ManaAlertCompare"
        Me.ManaAlertCompare.Size = New System.Drawing.Size(68, 20)
        Me.ManaAlertCompare.TabIndex = 15
        '
        'HealthAlertCompare
        '
        Me.HealthAlertCompare.Location = New System.Drawing.Point(114, 18)
        Me.HealthAlertCompare.Maximum = New Decimal(New Integer() {65534, 0, 0, 0})
        Me.HealthAlertCompare.Name = "HealthAlertCompare"
        Me.HealthAlertCompare.Size = New System.Drawing.Size(68, 20)
        Me.HealthAlertCompare.TabIndex = 14
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.Controls.Add(Me.IgnoreSpells)
        Me.GroupBox2.Controls.Add(Me.GMMessageAlert)
        Me.GroupBox2.Controls.Add(Me.PrivateMessageAlert)
        Me.GroupBox2.Controls.Add(Me.DefaultMessageAlert)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox2.Location = New System.Drawing.Point(6, 271)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(317, 64)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Message Alerts"
        '
        'IgnoreSpells
        '
        Me.IgnoreSpells.AutoSize = True
        Me.IgnoreSpells.Checked = True
        Me.IgnoreSpells.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IgnoreSpells.Location = New System.Drawing.Point(9, 19)
        Me.IgnoreSpells.Name = "IgnoreSpells"
        Me.IgnoreSpells.Size = New System.Drawing.Size(87, 17)
        Me.IgnoreSpells.TabIndex = 8
        Me.IgnoreSpells.Tag = ""
        Me.IgnoreSpells.Text = "Ignore Spells"
        Me.AlarmToolTip.SetToolTip(Me.IgnoreSpells, "Message alerts will ignore spells when this is checked.")
        Me.IgnoreSpells.UseVisualStyleBackColor = True
        '
        'GMMessageAlert
        '
        Me.GMMessageAlert.AutoSize = True
        Me.GMMessageAlert.BackColor = System.Drawing.Color.Transparent
        Me.GMMessageAlert.Location = New System.Drawing.Point(232, 42)
        Me.GMMessageAlert.Name = "GMMessageAlert"
        Me.GMMessageAlert.Size = New System.Drawing.Size(89, 17)
        Me.GMMessageAlert.TabIndex = 7
        Me.GMMessageAlert.Tag = ""
        Me.GMMessageAlert.Text = "GM Message"
        Me.AlarmToolTip.SetToolTip(Me.GMMessageAlert, "Alert if a Gamemaster or Community Manager broadcasts in red.")
        Me.GMMessageAlert.UseVisualStyleBackColor = False
        '
        'PrivateMessageAlert
        '
        Me.PrivateMessageAlert.AutoSize = True
        Me.PrivateMessageAlert.Location = New System.Drawing.Point(9, 42)
        Me.PrivateMessageAlert.Name = "PrivateMessageAlert"
        Me.PrivateMessageAlert.Size = New System.Drawing.Size(105, 17)
        Me.PrivateMessageAlert.TabIndex = 6
        Me.PrivateMessageAlert.Tag = ""
        Me.PrivateMessageAlert.Text = "Private Message"
        Me.AlarmToolTip.SetToolTip(Me.PrivateMessageAlert, "Alert if a player private messages you.")
        Me.PrivateMessageAlert.UseVisualStyleBackColor = True
        '
        'DefaultMessageAlert
        '
        Me.DefaultMessageAlert.AutoSize = True
        Me.DefaultMessageAlert.Location = New System.Drawing.Point(120, 42)
        Me.DefaultMessageAlert.Name = "DefaultMessageAlert"
        Me.DefaultMessageAlert.Size = New System.Drawing.Size(106, 17)
        Me.DefaultMessageAlert.TabIndex = 5
        Me.DefaultMessageAlert.Tag = ""
        Me.DefaultMessageAlert.Text = "Default Message"
        Me.AlarmToolTip.SetToolTip(Me.DefaultMessageAlert, "Alert if a message is said in default chat.")
        Me.DefaultMessageAlert.UseVisualStyleBackColor = True
        '
        'StatusTimer
        '
        Me.StatusTimer.Enabled = True
        Me.StatusTimer.Interval = 1000
        '
        'TTSSpeaker
        '
        '
        'AlarmToolTip
        '
        Me.AlarmToolTip.AutoPopDelay = 5000
        Me.AlarmToolTip.InitialDelay = 500
        Me.AlarmToolTip.ReshowDelay = 100
        '
        'AutoLog
        '
        Me.AutoLog.Enabled = True
        Me.AutoLog.Interval = 500
        '
        'Alarms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(532, 346)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Alarms"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "TUGBot - Alarms"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.SoulLogoutAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.AlarmSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AlarmVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.CapAlertCompare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoulAlertCompare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ManaAlertCompare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HealthAlertCompare, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents GmAlert As System.Windows.Forms.CheckBox
    Friend WithEvents ManaAlert As System.Windows.Forms.CheckBox
    Friend WithEvents HealthAlert As System.Windows.Forms.CheckBox
    Friend WithEvents GMAlertAll As System.Windows.Forms.CheckBox
    Friend WithEvents PlayerAlertAll As System.Windows.Forms.CheckBox
    Friend WithEvents PlayerAlert As System.Windows.Forms.CheckBox
    Friend WithEvents AttackAlert As System.Windows.Forms.CheckBox
    Friend WithEvents DisconnectAlert As System.Windows.Forms.CheckBox
    Friend WithEvents HPLossAlert As System.Windows.Forms.CheckBox
    Friend WithEvents ManaAlertCompare As System.Windows.Forms.NumericUpDown
    Friend WithEvents HealthAlertCompare As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GMSafeAll As System.Windows.Forms.CheckBox
    Friend WithEvents PlayerSafeAll As System.Windows.Forms.CheckBox
    Friend WithEvents PlayerSafe As System.Windows.Forms.CheckBox
    Friend WithEvents GMSafe As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PrivateMessageAlert As System.Windows.Forms.CheckBox
    Friend WithEvents DefaultMessageAlert As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents EnemyFilter As System.Windows.Forms.RadioButton
    Friend WithEvents AllyFilter As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents AlarmFilter As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents UseSiren As System.Windows.Forms.RadioButton
    Friend WithEvents UseTTs As System.Windows.Forms.RadioButton
    Friend WithEvents SoulAlert As System.Windows.Forms.CheckBox
    Friend WithEvents SoulAlertCompare As System.Windows.Forms.NumericUpDown
    Friend WithEvents GMMessageAlert As System.Windows.Forms.CheckBox
    Friend WithEvents CapAlert As System.Windows.Forms.CheckBox
    Friend WithEvents CapAlertCompare As System.Windows.Forms.NumericUpDown
    Friend WithEvents IgnoreSpells As System.Windows.Forms.CheckBox
    Friend WithEvents OnlyPlayerAttack As System.Windows.Forms.CheckBox
    Friend WithEvents StatusTimer As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TTSSpeaker As System.ComponentModel.BackgroundWorker
    Friend WithEvents TTSAdder As System.ComponentModel.BackgroundWorker
    Friend WithEvents AlarmToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents PlayerLogoutAll As System.Windows.Forms.CheckBox
    Friend WithEvents PlayerLogout As System.Windows.Forms.CheckBox
    Friend WithEvents GMMessageLogout As System.Windows.Forms.CheckBox
    Friend WithEvents SoulLogout As System.Windows.Forms.CheckBox
    Friend WithEvents SoulLogoutAmount As System.Windows.Forms.NumericUpDown
    Friend WithEvents AutoLog As System.Windows.Forms.Timer
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Volumesd As System.Windows.Forms.Label
    Friend WithEvents AlarmVolume As System.Windows.Forms.TrackBar
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AlarmSpeed As System.Windows.Forms.TrackBar
End Class
