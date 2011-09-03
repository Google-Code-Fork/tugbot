Module BotSettings
    'TODO
    'Cavewalker, Attacker, Alarm, Icons
    Private Settings As New List(Of Setting)
    Public Delegate Sub HKDel(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    Public Sub InitializeSettings()
        'WAR
        Settings.Add(New Setting(War.SioAt, "SioFriendAt"))
        Settings.Add(New Setting(War.SioMana, "SioFriendMana"))
        Settings.Add(New Setting(War.PotionType, "FriendHealingType"))
        Settings.Add(New Setting(War.UseItem, "FriendHealingWithItem"))
        Settings.Add(New Setting(War.EnableAllyHealer, "FriendHealingEnabled"))
        Settings.Add(New Setting(War.ShowTeamMarks, "TeamMarks"))
        Settings.Add(New Setting(War.ShowTeamSquares, "TeamSquares"))

        Settings.Add(New Setting(War.LeaderSpellName, "SpellComboLeader"))
        Settings.Add(New Setting(War.ComboAtSpell, "SpellComboAt"))
        Settings.Add(New Setting(War.ComboWithSpell, "SpellComboWith"))
        Settings.Add(New Setting(War.ComboAtMana, "SpellComboMana"))
        Settings.Add(New Setting(War.EnableSpellCombo, "UseSpellCombo"))

        'TOOLS
        Settings.Add(New Setting(Tools.EnableXray, "XRay"))
        Settings.Add(New Setting(Tools.OpenPitfalls, "Pitfalls"))
        Settings.Add(New Setting(Tools.EnableLight, "Light"))
        Settings.Add(New Setting(Tools.ReplaceTrees, "Trees"))
        Settings.Add(New Setting(Tools.FieldWalker, "Fields"))
        Settings.Add(New Setting(Tools.FrameRate, "FrameRate"))
        Settings.Add(New Setting(Tools.ShowHealPercent, "ShowHealPercent"))
        Settings.Add(New Setting(Tools.ShowIds, "ShowLookIDS"))
        Settings.Add(New Setting(Tools.EnableFishing, "Fishing"))
        Settings.Add(New Setting(Tools.AntiIdle, "AntiIdle"))
        Settings.Add(New Setting(Tools.EatFood, "EatFood"))
        Settings.Add(New Setting(Tools.TextToWatch, "TradeWatchText"))
        Settings.Add(New Setting(Tools.TradeWatchEnable, "TradeWatch"))
        Settings.Add(New Setting(Tools.AutoStack, "AutoStack"))

        'SUPPORT
        Settings.Add(New Setting(Support.SpellHi, "SpellHi"))
        Settings.Add(New Setting(Support.ManaHi, "ManaHi"))
        Settings.Add(New Setting(Support.HealthHi, "HealthHi"))
        Settings.Add(New Setting(Support.EnableSpellHi, "EnableHi"))
        Settings.Add(New Setting(Support.SpellLo, "SpellLo"))
        Settings.Add(New Setting(Support.ManaLo, "ManaLo"))
        Settings.Add(New Setting(Support.HealthLo, "HealthLo"))
        Settings.Add(New Setting(Support.PotionHealth, "ItemHealth"))
        Settings.Add(New Setting(Support.EnableHealItem, "ItemHealing"))
        Settings.Add(New Setting(Support.PotionType, "PotionType"))
        Settings.Add(New Setting(Support.EnableSpellLo, "EnableLo"))
        Settings.Add(New Setting(Support.ParalyzeSpell, "ParaSpell"))
        Settings.Add(New Setting(Support.EnableParalyze, "CurePara"))
        Settings.Add(New Setting(Support.PoisonRune, "PoisonRune"))
        Settings.Add(New Setting(Support.PoisonSpell, "PoisonSpell"))
        Settings.Add(New Setting(Support.EnablePoison, "CurePoison"))
        Settings.Add(New Setting(Support.RestoreAtMana, "RestoreMana"))
        Settings.Add(New Setting(Support.RestoreType, "ManaType"))
        Settings.Add(New Setting(Support.ManaRestoreEnabled, "ManaRestore"))

        'MAGIC
        Settings.Add(New Setting(Magic.ManaTrainSpell, "TrainingSpell"))
        Settings.Add(New Setting(Magic.TrainAtMana, "TrainingMana"))
        Settings.Add(New Setting(Magic.EnableManaTrain, "ManaTraining"))
        Settings.Add(New Setting(Magic.RuneMana, "RuneMana"))
        Settings.Add(New Setting(Magic.RuneSoul, "RuneSoul"))
        Settings.Add(New Setting(Magic.RuneMakerType, "RuneType"))
        Settings.Add(New Setting(Magic.RuneSpell, "RuneSpell"))
        Settings.Add(New Setting(Magic.EnableRuneMaker, "RuneMaking"))

        'Alarms
        Settings.Add(New Setting(Alarms.AlarmVolume, "AlarmVolume"))

        Settings.Add(New Setting(Alarms.AlarmFilter, "FilterAlarms"))
        Settings.Add(New Setting(Alarms.EnemyFilter, "EnemyFilter"))
        Settings.Add(New Setting(Alarms.AllyFilter, "AllyFilter"))
        Settings.Add(New Setting(Alarms.UseTTs, "AlarmTTS"))
        Settings.Add(New Setting(Alarms.UseSiren, "AlarmSiren"))

        Settings.Add(New Setting(Alarms.IgnoreSpells, "FilterSpell"))
        Settings.Add(New Setting(Alarms.DefaultMessageAlert, "DefaultMessageAlarm"))
        Settings.Add(New Setting(Alarms.PrivateMessageAlert, "PrivateMessageAlarm"))
        Settings.Add(New Setting(Alarms.GMMessageAlert, "GMMessageAlarm"))

        Settings.Add(New Setting(Alarms.AttackAlert, "AttackAlarm"))
        Settings.Add(New Setting(Alarms.OnlyPlayerAttack, "FilterNonPlayers"))
        Settings.Add(New Setting(Alarms.DisconnectAlert, "DisconnectAlarm"))
        Settings.Add(New Setting(Alarms.HPLossAlert, "HPLossAlarm"))
        Settings.Add(New Setting(Alarms.GmAlert, "GMAlarm"))
        Settings.Add(New Setting(Alarms.GMAlertAll, "GMAlarmAll"))
        Settings.Add(New Setting(Alarms.PlayerAlert, "PlayerAlarm"))
        Settings.Add(New Setting(Alarms.PlayerAlertAll, "PlayerAlarmAll"))

        Settings.Add(New Setting(Alarms.HealthAlert, "HealthAlarm"))
        Settings.Add(New Setting(Alarms.HealthAlertCompare, "HealthAlarmValue"))
        Settings.Add(New Setting(Alarms.ManaAlert, "ManaAlarm"))
        Settings.Add(New Setting(Alarms.ManaAlertCompare, "ManaAlarmValue"))
        Settings.Add(New Setting(Alarms.SoulAlert, "SoulAlarm"))
        Settings.Add(New Setting(Alarms.SoulAlertCompare, "SoulAlarmValue"))
        Settings.Add(New Setting(Alarms.CapAlert, "CapAlarm"))
        Settings.Add(New Setting(Alarms.CapAlertCompare, "CapAlarmValue"))

        Settings.Add(New Setting(Alarms.GMSafe, "GMSafe"))
        Settings.Add(New Setting(Alarms.GMSafeAll, "GMSafeAll"))
        Settings.Add(New Setting(Alarms.PlayerSafe, "PlayerSafe"))
        Settings.Add(New Setting(Alarms.PlayerSafeAll, "PlayerSafeAll"))
        Settings.Add(New Setting(Alarms.PlayerLogout, "PlayerLogout"))
        Settings.Add(New Setting(Alarms.PlayerLogoutAll, "PlayerLogoutAll"))
        Settings.Add(New Setting(Alarms.SoulLogout, "SoulLogout"))
        Settings.Add(New Setting(Alarms.SoulLogoutAmount, "SoulLogoutAll"))
        Settings.Add(New Setting(Alarms.GMMessageLogout, "GMMessageLogout"))

        'Walker
        Settings.Add(New Setting(CavebotWalker.UseElvenhairRope, "ElvenhairRope"))
        Settings.Add(New Setting(CavebotWalker.UseLightShovel, "LightShovel"))

        'Hotkeys
        Settings.Add(New Setting(HotkeysForm.HotkeyPanel00, ""))
        Settings.Add(New Setting(HotkeysForm.HotkeyPanel01, ""))
        Settings.Add(New Setting(HotkeysForm.HotkeyPanel02, ""))
        Settings.Add(New Setting(HotkeysForm.HotkeyPanel03, ""))
        Settings.Add(New Setting(HotkeysForm.HotkeyPanel04, ""))
        Settings.Add(New Setting(HotkeysForm.HotkeyPanel05, ""))
        Settings.Add(New Setting(HotkeysForm.HotkeyPanel06, ""))
        Settings.Add(New Setting(HotkeysForm.HotkeyPanel07, ""))
        Settings.Add(New Setting(HotkeysForm.HotkeyPanel08, ""))
        Settings.Add(New Setting(HotkeysForm.HotkeyPanel09, ""))
        Settings.Add(New Setting(HotkeysForm.HotkeyPanel10, ""))
        Settings.Add(New Setting(HotkeysForm.HotkeyPanel11, ""))
        Settings.Add(New Setting(HotkeysForm.HotkeyPanel12, ""))
        Settings.Add(New Setting(HotkeysForm.HotkeyPanel13, ""))
        Settings.Add(New Setting(HotkeysForm.HotkeyPanel14, ""))
        Settings.Add(New Setting(HotkeysForm.HotkeyPanel15, ""))
        Settings.Add(New Setting(HotkeysForm.HotkeyPanel16, ""))



        'HUD
        Settings.Add(New Setting(HeadsUpDisplay.SpellTimerEnable, "SpellTimers"))
        Settings.Add(New Setting(HeadsUpDisplay.ShowExpEnable, "ExpPerHour"))
        Settings.Add(New Setting(HeadsUpDisplay.ShowTargetEnable, "Target"))
        Settings.Add(New Setting(HeadsUpDisplay.ShowPingEnable, "Ping"))
        Settings.Add(New Setting(HeadsUpDisplay.ShowDmgPSEnable, "DamagePerSecond"))
        Settings.Add(New Setting(HeadsUpDisplay.StatusPanelX, "StatusPanelX"))
        Settings.Add(New Setting(HeadsUpDisplay.StatusPanelY, "StatusPanelY"))
        Settings.Add(New Setting(HeadsUpDisplay.EnableStatusPanel, "StatusPanel"))
    End Sub

    Public Sub SaveSettings(ByVal Num As Byte)
        If Not IO.File.Exists(Application.StartupPath & "\Config.ini") Then MsgBox("Cannot find Config.ini!", MsgBoxStyle.Critical, "Error!") : Exit Sub
        Dim Ini As New iniFile(Application.StartupPath & "\Config.ini")

        For Each [Set] As Setting In Settings

            If [Set].Control.GetType().Name = "HotkeyPanel" Then
                Dim h As HotkeyPanel = CType([Set].Control, HotkeyPanel)

                Ini.WriteString("TUGBotSet#" & Num, _
                                "HotkeyEnable" & h.KeyNum + 1, CStr(h.Enable.Checked))
                Ini.WriteString("TUGBotSet#" & Num, _
                                "HotkeyButton" & h.KeyNum + 1, h.Button.Text)
                Ini.WriteString("TUGBotSet#" & Num, _
                                "HotkeyPressType" & h.KeyNum + 1, CInt(Hotkey.Hotkey(h.KeyNum).PressType))
                Ini.WriteString("TUGBotSet#" & Num, _
                                "HotkeyCommand" & h.KeyNum + 1, h.Command.Text)
            Else
                Ini.WriteString("TUGBotSet#" & Num, [Set].Name, [Set].Value)
            End If
        Next
    End Sub

    Public Sub ClearSettings(ByVal Num As Byte)
        If Not IO.File.Exists(Application.StartupPath & "\Config.ini") Then MsgBox("Cannot find Config.ini!", MsgBoxStyle.Critical, "Error!") : Exit Sub
        Dim Ini As New iniFile(Application.StartupPath & "\Config.ini")

        For Each [Set] As Setting In Settings
            If [Set].Control.GetType().Name = "HotkeyPanel" Then
                Dim h As HotkeyPanel = CType([Set].Control, HotkeyPanel)

                Ini.WriteString("TUGBotSet#" & Num, _
                                "HotkeyEnable" & h.KeyNum + 1, "")
                Ini.WriteString("TUGBotSet#" & Num, _
                                "HotkeyButton" & h.KeyNum + 1, "")
                Ini.WriteString("TUGBotSet#" & Num, _
                                "HotkeyPressType" & h.KeyNum + 1, "")
                Ini.WriteString("TUGBotSet#" & Num, _
                                "HotkeyCommand" & h.KeyNum + 1, "")
            Else
                Ini.WriteString("TUGBotSet#" & Num, [Set].Name, "")
            End If
        Next
    End Sub

    Public Sub LoadSettings(ByVal Num As Byte)
        If Not IO.File.Exists(Application.StartupPath & "\Config.ini") Then MsgBox("Cannot find Config.ini!", MsgBoxStyle.Critical, "Error!") : Exit Sub
        Dim Ini As New iniFile(Application.StartupPath & "\Config.ini")

        For Each [Set] As Setting In Settings
            If [Set].Control.GetType().Name = "HotkeyPanel" Then
                Dim h As HotkeyPanel = CType([Set].Control, HotkeyPanel)
                Dim Enabled As String = Ini.GetString("TUGBotSet#" & Num, _
                                        "HotkeyEnable" & h.KeyNum + 1, "False")
                Dim Button As String = Ini.GetString("TUGBotSet#" & Num, _
                                        "HotkeyButton" & h.KeyNum + 1, "")
                Dim PressType As String = Ini.GetString("TUGBotSet#" & Num, _
                                        "HotkeyPressType" & h.KeyNum + 1, "1")
                Dim Command As String = Ini.GetString("TUGBotSet#" & Num, _
                                        "HotkeyCommand" & h.KeyNum + 1, "")

                [Set].Value = Enabled & "," & Button & "," & PressType & "," & Command
            Else
                [Set].Value = Ini.GetString("TUGBotSet#" & Num, [Set].Name, "")
            End If
        Next
    End Sub

    Public Class Setting
        Private _Control As Control
        Private _Name As String

        Public ReadOnly Property Control() As Control
            Get
                Return _Control
            End Get
        End Property

        Public ReadOnly Property Name() As String
            Get
                Return _Name
            End Get
        End Property

        Public Property Value() As String
            Get
                Select Case Control.GetType().Name
                    Case "ComboBox"
                        Return CStr(CType(Control, ComboBox).Text)
                    Case "CheckBox"
                        Return CStr(CType(Control, CheckBox).Checked)
                    Case "RaidoButton"
                        Return CStr(CType(Control, RadioButton).Checked)
                    Case "TextBox", "WaterMarkTextBox"
                        Return CStr(CType(Control, TextBox).Text)
                    Case "NumericUpDown"
                        Return CStr(CType(Control, NumericUpDown).Value)
                    Case "TrackBar"
                        Return CStr(CType(Control, TrackBar).Value)
                    Case "HotkeyPanel"
                        Dim h As HotkeyPanel = CType(Control, HotkeyPanel)
                        Return CStr(h.Enable.Checked) & "," & h.Button.Text & "," & CInt(Hotkey.Hotkey(h.KeyNum).PressType) & "," & h.Command.Text
                    Case Else
                        Return ""
                End Select
            End Get
            Set(ByVal value As String)
                'If value = "" Then Exit Property
                Select Case Control.GetType().Name
                    Case "ComboBox"
                        CType(Control, ComboBox).Text = CStr(value)
                        Control.Invalidate()
                    Case "CheckBox"
                        If value = "" Then CType(Control, CheckBox).Checked = False : Exit Property
                        CType(Control, CheckBox).Checked = CBool(value)
                    Case "RaidoButton"
                        If value = "" Then Exit Property
                        CType(Control, RadioButton).Checked = CBool(value)
                    Case "TextBox", "WaterMarkTextBox"
                        CType(Control, TextBox).Text = CStr(value)
                    Case "NumericUpDown"
                        If value = "" Then Exit Property
                        CType(Control, NumericUpDown).Value = CStr(value)
                    Case "TrackBar"
                        If value = "" Then Exit Property
                        CType(Control, TrackBar).Value = CStr(value)
                    Case "HotkeyPanel"
                        Dim d As Char() = {","}
                        Dim Splits As String() = value.Split(d, 4)

                        Dim h As HotkeyPanel = CType(Control, HotkeyPanel)
                        h.Enable.Checked = CBool(Splits(0))
                        h.ConfigureHotkey(CBool(Splits(0)), Splits(1), Splits(3), CInt(Splits(2)))
                End Select
            End Set
        End Property

        Public Sub New(ByVal C As Control, ByVal name As String)
            _Control = C
            _Name = name
        End Sub
    End Class
End Module
