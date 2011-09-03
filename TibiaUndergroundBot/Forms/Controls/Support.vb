Public Class Support
    Public UpdatePriorityShit As Boolean = True
    Public HealPriority As HealPriorities
    Public Enum HealPriorities As Byte
        SpellItemMana = 0
        ItemSpellMana = 1
        ManaSpellItem = 2
        ManaItemSpell = 3
        SpellManaItem = 4
        ItemManaSpell = 5

        DoubleHealItemMana = 6
        DoubleHealManaItem = 7
    End Enum

    Private Shadows Sub FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Visible = False
        e.Cancel = True
    End Sub


#Region "Healing"
    'SPELL HI
    Private Sub SpellHi_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SpellHi.TextChanged
        SpellHi.Text = FormatSpell(SpellHi.Text)
    End Sub
    Private Sub HealthHi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HealthHi.LostFocus
        If ParseShort(HealthHi.Text) <> 0 Then
            HealthHi.Text = ParseShort(HealthHi.Text)
        Else
            HealthHi.Text = ""
        End If
    End Sub
    Private Sub ManaHi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManaHi.LostFocus
        If ParseShort(ManaHi.Text) <> 0 Then
            ManaHi.Text = ParseShort(ManaHi.Text)
        Else
            ManaHi.Text = ""
        End If
    End Sub

    'SPELL LO
    Private Sub SpellLo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpellLo.TextChanged
        SpellLo.Text = FormatSpell(SpellLo.Text)
    End Sub
    Private Sub HealthLo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HealthLo.LostFocus
        If ParseShort(HealthLo.Text) <> 0 Then
            HealthLo.Text = ParseShort(HealthLo.Text)
        Else
            HealthLo.Text = ""
        End If
    End Sub
    Private Sub ManaLo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManaLo.LostFocus
        If ParseShort(ManaLo.Text) <> 0 Then
            ManaLo.Text = ParseShort(ManaLo.Text)
        Else
            ManaLo.Text = ""
        End If
    End Sub

    Private Sub PotionHealth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PotionHealth.LostFocus
        If ParseShort(PotionHealth.Text) <> 0 Then
            PotionHealth.Text = ParseShort(PotionHealth.Text)
        Else
            PotionHealth.Text = ""
        End If
    End Sub

    'DELAY AND CHECK BOXES
    Private Sub HealDelay_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles HealDelay.LostFocus
        HealDelay.Text = ParseShort(HealDelay.Text)
        If HealDelay.Text < 500 Then HealDelay.Text = 500
    End Sub
    Private Sub EnableSpellHi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableSpellHi.CheckedChanged

        If SpellHi.Text = "" And EnableSpellHi.Checked Then
            EnableSpellHi.Checked = False
            Exit Sub
        End If

        SpellHi.Enabled = Not EnableSpellHi.Checked
        HealthHi.Enabled = Not EnableSpellHi.Checked
        ManaHi.Enabled = Not EnableSpellHi.Checked
    End Sub
    Private Sub EnableSpellLo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableSpellLo.CheckedChanged

        If SpellLo.Text = "" And EnableSpellLo.Checked Then
            EnableSpellLo.Checked = False
            Exit Sub
        End If

        SpellLo.Enabled = Not EnableSpellLo.Checked
        HealthLo.Enabled = Not EnableSpellLo.Checked
        ManaLo.Enabled = Not EnableSpellLo.Checked
    End Sub
    Private Sub EnableHealItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableHealItem.CheckedChanged
        If FormatItem(PotionType.Text) = 0 OrElse PotionType.Text = "" OrElse PotionType.Text = Nothing Then EnableHealItem.Checked = False
        PotionHealth.Enabled = Not EnableHealItem.Checked
        PotionType.Enabled = Not EnableHealItem.Checked
    End Sub

    'CURE PARA
    Private Sub ParalyzeSpell_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParalyzeSpell.TextChanged
        ParalyzeSpell.Text = FormatSpell(ParalyzeSpell.Text)
    End Sub
    Private Sub EnableParalyze_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableParalyze.CheckedChanged

        If ParalyzeSpell.Text = "" And EnableParalyze.Checked Then
            EnableParalyze.Checked = False
            Exit Sub
        End If

        ParalyzeSpell.Enabled = Not EnableParalyze.Checked
    End Sub

    'CURE POISON
    Private Sub EnablePoison_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnablePoison.CheckedChanged
        PoisonSpell.Enabled = Not EnablePoison.Checked
        PoisonRune.Enabled = Not EnablePoison.Checked
    End Sub

    'MANA RESTORE
    Private Sub RestoreAtMana_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreAtMana.LostFocus
        If ParseShort(RestoreAtMana.Text) <> 0 Then
            RestoreAtMana.Text = ParseShort(RestoreAtMana.Text)
        Else
            RestoreAtMana.Text = ""
        End If
    End Sub
    Private Sub ManaRestoreEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManaRestoreEnabled.CheckedChanged
        If FormatItem(RestoreType.Text) = 0 OrElse RestoreType.Text = "" OrElse RestoreType.Text = Nothing Then ManaRestoreEnabled.Checked = False
        RestoreAtMana.Enabled = Not ManaRestoreEnabled.Checked
        RestoreType.Enabled = Not ManaRestoreEnabled.Checked
    End Sub
#End Region

#Region "Healing Priority"
    Private Sub EnableDouble_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableDouble.Click
        If (Not PriorityType.SelectedIndex = 3 And Not PriorityType.SelectedIndex = 5) And EnableDouble.Checked Then
            PriorityType.SelectedIndex = 3
        Else
            SetHealingPriority()
        End If
    End Sub

    Private Sub PriorityType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PriorityType.SelectedIndexChanged
        SetHealingPriority()
    End Sub

    Public Sub SetHealingPriority()

        If UpdatePriorityShit = False Then Exit Sub
        If EnableDouble.Checked Then
            If PriorityType.SelectedIndex = 5 Then 'mana item spell
                HealPriority = HealPriorities.DoubleHealManaItem
            ElseIf PriorityType.SelectedIndex = 3 Then 'item mana spell
                HealPriority = HealPriorities.DoubleHealItemMana
            Else
                PriorityType.SelectedIndex = 3
                HealPriority = HealPriorities.DoubleHealItemMana
            End If
        Else
            If PriorityType.SelectedIndex = 5 Then 'MIS
                HealPriority = HealPriorities.ManaItemSpell
            ElseIf PriorityType.SelectedIndex = 3 Then 'IMS
                HealPriority = HealPriorities.ItemManaSpell
            ElseIf PriorityType.SelectedIndex = 1 Then 'ISM
                HealPriority = HealPriorities.ItemSpellMana
            ElseIf PriorityType.SelectedIndex = 0 Then 'SIM
                HealPriority = HealPriorities.SpellItemMana
            ElseIf PriorityType.SelectedIndex = 2 Then 'SMI
                HealPriority = HealPriorities.SpellManaItem
            ElseIf PriorityType.SelectedIndex = 4 Then 'MSI
                HealPriority = HealPriorities.ManaSpellItem
            End If
        End If
    End Sub
#End Region

    Private Sub Support_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        Me.Refresh()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()


        For Each K As String In ItemShortcuts.Keys
            Me.PotionType.AutoCompleteCustomSource.Add("{" & K & "}")
        Next
        Me.RestoreType.AutoCompleteCustomSource = Me.PotionType.AutoCompleteCustomSource
        Me.RestoreType.AutoCompleteMode = AutoCompleteMode.Suggest
        Me.RestoreType.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.PotionType.AutoCompleteMode = AutoCompleteMode.Suggest
        Me.PotionType.AutoCompleteSource = AutoCompleteSource.CustomSource

        Me.PriorityType.SelectedIndex = 0
        SetHealingPriority()
    End Sub

    Private Sub ItemTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemTimer.Tick
        If TClient.Paused OrElse TClient.Status <> 8 Then Exit Sub

        ItemTimer.Interval = 200
        Select Case HealPriority
            Case HealPriorities.DoubleHealItemMana
                DoubleItemMana()
            Case HealPriorities.DoubleHealManaItem
                DoubleManaItem()
        End Select
    End Sub

    Private Sub SpellTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpellTimer.Tick
        If TClient.Paused OrElse TClient.Status <> 8 Then Exit Sub
        Healing = True
        SpellTimer.Interval = 200

        Select Case HealPriority
            Case HealPriorities.ItemManaSpell
                ItemManaSpell()
            Case HealPriorities.ItemSpellMana
                ItemSpellMana()
            Case HealPriorities.ManaItemSpell
                ManaItemSpell()
            Case HealPriorities.ManaSpellItem
                ManaSpellItem()
            Case HealPriorities.SpellItemMana
                SpellItemMana()
            Case HealPriorities.SpellManaItem
                SpellManaItem()
            Case HealPriorities.DoubleHealItemMana Or HealPriorities.DoubleHealManaItem
                DoubleSpells()
            Case Else
                SpellItemMana()
        End Select

        If SpellTimer.Interval = 200 Then

            If War.EnableAllyHealer.Checked Then
                TClient.Battlelist.Cache()
                If War.UseSio.Checked Then
                    For i As Integer = 1 To TClient.Battlelist.Length
                        If TClient.Battlelist.IsPlayer(i) AndAlso _
                        War.AllyList.Items.Contains(TClient.Battlelist.Name(i)) Then
                            If TClient.Battlelist.Health(i) < War.SioAt.Value AndAlso _
                            TClient.Self.Mana >= War.SioMana.Value Then
                                TClient.Self.Say("Exura Sio """ & TClient.Battlelist.Name(i))
                                SpellTimer.Interval = Me.HealDelay.Text
                            End If
                        End If
                    Next
                End If
            End If

            If CaveBotAttacker.EnableAdvanced.Checked AndAlso CaveBotAttacker.EnableAttacker.Checked Then
                If RuneStrikeType = MagicAttackType.Rune Then
                    TClient.Battlelist.Cache()
                    Dim Pos As Integer = TClient.Battlelist.PosByID(TClient.Self.Target)
                    If TClient.Battlelist.Health(Pos) >= CurrentRuneHealth Then
                        TClient.Self.UseItemWithCreature(CurrentRuneID, TClient.Self.Target)
                        SpellTimer.Interval = Me.HealDelay.Text
                    End If
                ElseIf RuneStrikeType = MagicAttackType.Strike Then
                    If CurrentStrikeMana <= TClient.Self.Mana Then
                        TClient.Battlelist.Cache()
                        Dim Pos As Integer = TClient.Battlelist.PosByID(TClient.Self.Target)
                        If TClient.Battlelist.Health(Pos) >= CurrentStrikeHealthPercent Then
                            TClient.Self.Say(CurrentStrikeSpell)
                            SpellTimer.Interval = Me.HealDelay.Text
                        End If
                    End If
                End If
            End If
        End If

        If SpellTimer.Interval = 200 Then
            Healing = False
        End If
    End Sub

#Region "Double healing"
    Public Sub DoubleItemMana()
        If Me.EnableHealItem.Checked And TClient.Self.Health <= ParseInteger(Me.PotionHealth.Text) Then
            If FormatItem(Me.PotionType.Text) > 100 Then
                TClient.Self.UseItemWithCreature(FormatItem(Me.PotionType.Text), TClient.Self.Id)
                ItemTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        If Me.ManaRestoreEnabled.Checked And TClient.Self.Mana <= ParseInteger(Me.RestoreAtMana.Text) Then
            If FormatItem(Me.RestoreType.Text) > 100 Then
                TClient.Self.UseItemWithCreature(FormatItem(Me.RestoreType.Text), TClient.Self.Id)
                ItemTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        If Me.EnablePoison.Checked And TClient.Self.Poisoned Then
            If Me.PoisonRune.Checked Then
                TClient.Self.UseItemWithCreature(3153, TClient.Self.Id)
                ItemTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If
    End Sub

    Public Sub DoubleManaItem()
        If Me.ManaRestoreEnabled.Checked And TClient.Self.Mana <= ParseInteger(Me.RestoreAtMana.Text) Then
            If FormatItem(Me.RestoreType.Text) > 100 Then
                TClient.Self.UseItemWithCreature(FormatItem(Me.RestoreType.Text), TClient.Self.Id)
                ItemTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        If Me.EnableHealItem.Checked And TClient.Self.Health <= ParseInteger(Me.PotionHealth.Text) Then
            If FormatItem(Me.PotionType.Text) > 100 Then
                TClient.Self.UseItemWithCreature(FormatItem(Me.PotionType.Text), TClient.Self.Id)
                ItemTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        If Me.EnablePoison.Checked And TClient.Self.Poisoned Then
            If Me.PoisonRune.Checked Then
                TClient.Self.UseItemWithCreature(3153, TClient.Self.Id)
                ItemTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If
    End Sub

    Public Sub DoubleSpells()
        'Heal spells
        If Me.EnableSpellLo.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.HealthLo.Text) Then 'Compare to Lo health
            If TClient.Self.Mana >= Me.ManaLo.Text Then 'Compare to Lo mana
                TClient.Self.Say(Me.SpellLo.Text)
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        ElseIf Me.EnableSpellHi.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.HealthHi.Text) Then 'Compare to Hi health
            If TClient.Self.Mana >= Me.ManaHi.Text Then 'Compare to Hi mana
                TClient.Self.Say(Me.SpellHi.Text)
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        'Cure para
        If Me.EnableParalyze.Checked AndAlso TClient.Self.Paralyzed Then
            TClient.Self.Say(Me.ParalyzeSpell.Text)
            SpellTimer.Interval = Me.HealDelay.Text
            Exit Sub
        End If

        'Poison spell
        If Me.EnablePoison.Checked AndAlso TClient.Self.Poisoned Then
            If Not Me.PoisonRune.Checked Then
                TClient.Self.Say("Exana pox")
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        'Mana train
        If Magic.EnableManaTrain.Checked AndAlso TClient.Self.Mana >= Magic.TrainAtMana.Text Then
            If Magic.ManaTrainSpell.Text <> "" Then
                TClient.Self.Say(Magic.ManaTrainSpell.Text)
                SpellTimer.Interval = Me.HealDelay.Text
            End If
        End If
    End Sub
#End Region

#Region "Normal Healng"
    Public Sub SpellItemMana()
        'Heal spells
        If Me.EnableSpellLo.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.HealthLo.Text) Then 'Compare to Lo health
            If TClient.Self.Mana >= ParseInteger(Me.ManaLo.Text) Then 'Compare to Lo mana
                TClient.Self.Say(Me.SpellLo.Text)
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        ElseIf Me.EnableSpellHi.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.HealthHi.Text) Then 'Compare to Hi health
            If TClient.Self.Mana >= ParseInteger(Me.ManaHi.Text) Then 'Compare to Hi mana
                TClient.Self.Say(Me.SpellHi.Text)
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        'Cure para
        If Me.EnableParalyze.Checked AndAlso TClient.Self.Paralyzed Then
            TClient.Self.Say(Me.ParalyzeSpell.Text)
            SpellTimer.Interval = Me.HealDelay.Text
            Exit Sub
        End If

        'Healing potions
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.EnableHealItem.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.PotionHealth.Text) Then
                If FormatItem(Me.PotionType.Text) > 100 Then
                    TClient.Self.UseItemWithCreature(FormatItem(Me.PotionType.Text), TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Mana restore
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.ManaRestoreEnabled.Checked AndAlso TClient.Self.Mana <= ParseInteger(Me.RestoreAtMana.Text) Then
                If FormatItem(Me.RestoreType.Text) > 100 Then
                    TClient.Self.UseItemWithCreature(FormatItem(Me.RestoreType.Text), TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Poison spell
        If Me.EnablePoison.Checked AndAlso TClient.Self.Poisoned Then
            If Not Me.PoisonRune.Checked Then
                TClient.Self.Say("Exana pox")
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        'Poison Rune
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.EnablePoison.Checked AndAlso TClient.Self.Poisoned Then
                If Me.PoisonRune.Checked Then
                    TClient.Self.UseItemWithCreature(3153, TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Mana train
        If Magic.EnableManaTrain.Checked AndAlso TClient.Self.Mana >= Magic.TrainAtMana.Text Then
            If Magic.ManaTrainSpell.Text <> "" Then
                TClient.Self.Say(Magic.ManaTrainSpell.Text)
                SpellTimer.Interval = Me.HealDelay.Text
            End If
        End If
    End Sub

    Public Sub ItemSpellMana()
        'Healing potions
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.EnableHealItem.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.PotionHealth.Text) Then
                If FormatItem(Me.PotionType.Text) > 100 Then
                    TClient.Self.UseItemWithCreature(FormatItem(Me.PotionType.Text), TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Heal spells
        If Me.EnableSpellLo.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.HealthLo.Text) Then 'Compare to Lo health
            If TClient.Self.Mana >= Me.ManaLo.Text Then 'Compare to Lo mana
                TClient.Self.Say(Me.SpellLo.Text)
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        ElseIf Me.EnableSpellHi.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.HealthHi.Text) Then 'Compare to Hi health
            If TClient.Self.Mana >= Me.ManaHi.Text Then 'Compare to Hi mana
                TClient.Self.Say(Me.SpellHi.Text)
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        'Cure para
        If Me.EnableParalyze.Checked AndAlso TClient.Self.Paralyzed Then
            TClient.Self.Say(Me.ParalyzeSpell.Text)
            SpellTimer.Interval = Me.HealDelay.Text
            Exit Sub
        End If

        'Mana restore
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.ManaRestoreEnabled.Checked AndAlso TClient.Self.Mana <= ParseInteger(Me.RestoreAtMana.Text) Then
                If FormatItem(Me.RestoreType.Text) > 100 Then
                    TClient.Self.UseItemWithCreature(FormatItem(Me.RestoreType.Text), TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Poison spell
        If Me.EnablePoison.Checked AndAlso TClient.Self.Poisoned Then
            If Not Me.PoisonRune.Checked Then
                TClient.Self.Say("Exana pox")
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        'Poison Rune
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.EnablePoison.Checked AndAlso TClient.Self.Poisoned Then
                If Me.PoisonRune.Checked Then
                    TClient.Self.UseItemWithCreature(3153, TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Mana train
        If Magic.EnableManaTrain.Checked AndAlso TClient.Self.Mana >= Magic.TrainAtMana.Text Then
            If Magic.ManaTrainSpell.Text <> "" Then
                TClient.Self.Say(Magic.ManaTrainSpell.Text)
                SpellTimer.Interval = Me.HealDelay.Text
            End If
        End If
    End Sub

    Public Sub ManaSpellItem()
        'Mana restore
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.ManaRestoreEnabled.Checked AndAlso TClient.Self.Mana <= ParseInteger(Me.RestoreAtMana.Text) Then
                If FormatItem(Me.RestoreType.Text) > 100 Then
                    TClient.Self.UseItemWithCreature(FormatItem(Me.RestoreType.Text), TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Heal spells
        If Me.EnableSpellLo.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.HealthLo.Text) Then 'Compare to Lo health
            If TClient.Self.Mana >= Me.ManaLo.Text Then 'Compare to Lo mana
                TClient.Self.Say(Me.SpellLo.Text)
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        ElseIf Me.EnableSpellHi.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.HealthHi.Text) Then 'Compare to Hi health
            If TClient.Self.Mana >= Me.ManaHi.Text Then 'Compare to Hi mana
                TClient.Self.Say(Me.SpellHi.Text)
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        'Cure para
        If Me.EnableParalyze.Checked AndAlso TClient.Self.Paralyzed Then
            TClient.Self.Say(Me.ParalyzeSpell.Text)
            SpellTimer.Interval = Me.HealDelay.Text
            Exit Sub
        End If

        'Healing potions
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.EnableHealItem.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.PotionHealth.Text) Then
                If FormatItem(Me.PotionType.Text) > 100 Then
                    TClient.Self.UseItemWithCreature(FormatItem(Me.PotionType.Text), TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Poison spell
        If Me.EnablePoison.Checked AndAlso TClient.Self.Poisoned Then
            If Not Me.PoisonRune.Checked Then
                TClient.Self.Say("Exana pox")
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        'Poison Rune
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.EnablePoison.Checked AndAlso TClient.Self.Poisoned Then
                If Me.PoisonRune.Checked Then
                    TClient.Self.UseItemWithCreature(3153, TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Mana train
        If Magic.EnableManaTrain.Checked AndAlso TClient.Self.Mana >= Magic.TrainAtMana.Text Then
            If Magic.ManaTrainSpell.Text <> "" Then
                TClient.Self.Say(Magic.ManaTrainSpell.Text)
                SpellTimer.Interval = Me.HealDelay.Text
            End If
        End If
    End Sub

    Public Sub ManaItemSpell()
        'Mana restore
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.ManaRestoreEnabled.Checked AndAlso TClient.Self.Mana <= ParseInteger(Me.RestoreAtMana.Text) Then
                If FormatItem(Me.RestoreType.Text) > 100 Then
                    TClient.Self.UseItemWithCreature(FormatItem(Me.RestoreType.Text), TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Healing potions
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.EnableHealItem.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.PotionHealth.Text) Then
                If FormatItem(Me.PotionType.Text) > 100 Then
                    TClient.Self.UseItemWithCreature(FormatItem(Me.PotionType.Text), TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Heal spells
        If Me.EnableSpellLo.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.HealthLo.Text) Then 'Compare to Lo health
            If TClient.Self.Mana >= Me.ManaLo.Text Then 'Compare to Lo mana
                TClient.Self.Say(Me.SpellLo.Text)
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        ElseIf Me.EnableSpellHi.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.HealthHi.Text) Then 'Compare to Hi health
            If TClient.Self.Mana >= Me.ManaHi.Text Then 'Compare to Hi mana
                TClient.Self.Say(Me.SpellHi.Text)
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        'Cure para
        If Me.EnableParalyze.Checked AndAlso TClient.Self.Paralyzed Then
            TClient.Self.Say(Me.ParalyzeSpell.Text)
            SpellTimer.Interval = Me.HealDelay.Text
            Exit Sub
        End If

        'Poison spell
        If Me.EnablePoison.Checked AndAlso TClient.Self.Poisoned Then
            If Not Me.PoisonRune.Checked Then
                TClient.Self.Say("Exana pox")
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        'Poison Rune
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.EnablePoison.Checked AndAlso TClient.Self.Poisoned Then
                If Me.PoisonRune.Checked Then
                    TClient.Self.UseItemWithCreature(3153, TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Mana train
        If Magic.EnableManaTrain.Checked AndAlso TClient.Self.Mana >= Magic.TrainAtMana.Text Then
            If Magic.ManaTrainSpell.Text <> "" Then
                TClient.Self.Say(Magic.ManaTrainSpell.Text)
                SpellTimer.Interval = Me.HealDelay.Text
            End If
        End If
    End Sub

    Public Sub SpellManaItem()
        'Heal spells
        If Me.EnableSpellLo.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.HealthLo.Text) Then 'Compare to Lo health
            If TClient.Self.Mana >= Me.ManaLo.Text Then 'Compare to Lo mana
                TClient.Self.Say(Me.SpellLo.Text)
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        ElseIf Me.EnableSpellHi.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.HealthHi.Text) Then 'Compare to Hi health
            If TClient.Self.Mana >= Me.ManaHi.Text Then 'Compare to Hi mana
                TClient.Self.Say(Me.SpellHi.Text)
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        'Cure para
        If Me.EnableParalyze.Checked AndAlso TClient.Self.Paralyzed Then
            TClient.Self.Say(Me.ParalyzeSpell.Text)
            SpellTimer.Interval = Me.HealDelay.Text
            Exit Sub
        End If

        'Mana restore
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.ManaRestoreEnabled.Checked AndAlso TClient.Self.Mana <= ParseInteger(Me.RestoreAtMana.Text) Then
                If FormatItem(Me.RestoreType.Text) > 100 Then
                    TClient.Self.UseItemWithCreature(FormatItem(Me.RestoreType.Text), TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Healing potions
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.EnableHealItem.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.PotionHealth.Text) Then
                If FormatItem(Me.PotionType.Text) > 100 Then
                    TClient.Self.UseItemWithCreature(FormatItem(Me.PotionType.Text), TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Poison spell
        If Me.EnablePoison.Checked AndAlso TClient.Self.Poisoned Then
            If Not Me.PoisonRune.Checked Then
                TClient.Self.Say("Exana pox")
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        'Poison Rune
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.EnablePoison.Checked AndAlso TClient.Self.Poisoned Then
                If Me.PoisonRune.Checked Then
                    TClient.Self.UseItemWithCreature(3153, TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Mana train
        If Magic.EnableManaTrain.Checked AndAlso TClient.Self.Mana >= Magic.TrainAtMana.Text Then
            If Magic.ManaTrainSpell.Text <> "" Then
                TClient.Self.Say(Magic.ManaTrainSpell.Text)
                SpellTimer.Interval = Me.HealDelay.Text
            End If
        End If
    End Sub

    Public Sub ItemManaSpell()
        'Healing potions
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.EnableHealItem.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.PotionHealth.Text) Then
                If FormatItem(Me.PotionType.Text) > 100 Then
                    TClient.Self.UseItemWithCreature(FormatItem(Me.PotionType.Text), TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Mana restore
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.ManaRestoreEnabled.Checked AndAlso TClient.Self.Mana <= ParseInteger(Me.RestoreAtMana.Text) Then
                If FormatItem(Me.RestoreType.Text) > 100 Then
                    TClient.Self.UseItemWithCreature(FormatItem(Me.RestoreType.Text), TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Heal spells
        If Me.EnableSpellLo.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.HealthLo.Text) Then 'Compare to Lo health
            If TClient.Self.Mana >= Me.ManaLo.Text Then 'Compare to Lo mana
                TClient.Self.Say(Me.SpellLo.Text)
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        ElseIf Me.EnableSpellHi.Checked AndAlso TClient.Self.Health <= ParseInteger(Me.HealthHi.Text) Then 'Compare to Hi health
            If TClient.Self.Mana >= Me.ManaHi.Text Then 'Compare to Hi mana
                TClient.Self.Say(Me.SpellHi.Text)
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        'Cure para
        If Me.EnableParalyze.Checked AndAlso TClient.Self.Paralyzed Then
            TClient.Self.Say(Me.ParalyzeSpell.Text)
            SpellTimer.Interval = Me.HealDelay.Text
            Exit Sub
        End If

        'Poison spell
        If Me.EnablePoison.Checked AndAlso TClient.Self.Poisoned Then
            If Not Me.PoisonRune.Checked Then
                TClient.Self.Say("Exana pox")
                SpellTimer.Interval = Me.HealDelay.Text
                Exit Sub
            End If
        End If

        'Poison Rune
        If HealPriority <> HealPriorities.DoubleHealItemMana AndAlso HealPriority <> HealPriorities.DoubleHealManaItem Then
            If Me.EnablePoison.Checked AndAlso TClient.Self.Poisoned Then
                If Me.PoisonRune.Checked Then
                    TClient.Self.UseItemWithCreature(3153, TClient.Self.Id)
                    SpellTimer.Interval = Me.HealDelay.Text
                    Exit Sub
                End If
            End If
        End If

        'Mana train
        If Magic.EnableManaTrain.Checked AndAlso TClient.Self.Mana >= Magic.TrainAtMana.Text Then
            If Magic.ManaTrainSpell.Text <> "" Then
                TClient.Self.Say(Magic.ManaTrainSpell.Text)
                SpellTimer.Interval = Me.HealDelay.Text
            End If
        End If
    End Sub
#End Region

    Private Sub Support_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        BoxTimer.Start()
    End Sub

    Private Sub BoxTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoxTimer.Tick
        RestoreType.Focus()
        Refresh()
        System.Threading.Thread.Sleep(5)
        PotionType.Focus()
        Refresh()
        System.Threading.Thread.Sleep(5)
        SpellHi.Focus()
        Refresh()
        BoxTimer.Stop()
    End Sub
End Class