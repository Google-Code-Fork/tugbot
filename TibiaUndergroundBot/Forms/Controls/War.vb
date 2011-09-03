Public Class War
    Private Shadows Sub FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Visible = False
        Me.Refresh()
        e.Cancel = True
    End Sub

    Private Sub War_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()

        AddHandler TClient.AddedAlly, AddressOf Me.AddAlly
        AddHandler TClient.AddedEnemy, AddressOf Me.AddEnemy
        AddHandler TClient.CreatureAttacking, AddressOf Me.CreatureAttacking
        AddHandler TClient.ProjectileShot, AddressOf Me.ProjectileShot

        AddHandler TClient.CreatureDefaultSpeech, AddressOf CreatureSpeak
    End Sub

#Region "Handling creature squares"
    Public Delegate Sub Attacked(ByVal id As Integer)
    Public Sub CreatureAttacking(ByVal id As Integer)
        Dim Name As String = String.Empty
        Dim pack As New PacketBuilder
        Dim square As Byte = 0
        pack.AddByte(IncomingPacketType.CreatureSquare)
        pack.AddLong(id)

        If ShowTeamSquares.Checked Then
            TClient.Battlelist.Cache()
            For i = 1 To TClient.Battlelist.Length
                If TClient.Battlelist.ID(i) = id Then
                    Name = TClient.Battlelist.Name(i)
                    Exit For
                End If
            Next

            If AllyList.Items.Contains(Name) Then
                square = Client.TextColor.Crystal
            ElseIf EnemyList.Items.Contains(Name) Then
                square = Client.TextColor.Orange
            End If

            If Name.ToLower = TClient.LastExiva Then
                square = Client.TextColor.Gold
            End If
        End If

        pack.AddByte(square)
        TClient.Hook.SendPacketToClient(pack.GetPacket)

    End Sub

    Private Sub LastExiva_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LastExiva.Tick
        TClient.Battlelist.Cache()
        If TClient.LastExiva = Nothing Then Exit Sub
        Dim ID As Integer = TClient.Battlelist.ID(TClient.LastExiva)
        If ID <> 0 Then
            Dim pack As New PacketBuilder
            pack.AddByte(IncomingPacketType.CreatureSquare)
            pack.AddLong(ID)
            pack.AddByte(Client.TextColor.Gold)
            TClient.Hook.SendPacketToClient(pack.GetPacket)
        End If
    End Sub
#End Region

#Region "Add Ally/Enemy events"
    Public Sub AddAlly(ByVal name As String)
        If Me.AllyList.Items.Contains(name) Then
            TClient.ShowStatusMessage("TUGBot -> """ & name & """ is already on your ally list!", 50)
        ElseIf Me.EnemyList.Items.Contains(name) Then
            TClient.ShowStatusMessage("TUGBot -> """ & name & """ cannot be both an enemy and an ally!", 50)
        Else
            Me.AllyList.Items.Add(name)
            If ShowTeamMarks.Checked Then
                TClient.Hook.AddCreatureText(0, name, -20, 0, Color.SkyBlue, 2, "(A)")
            End If
            TClient.ShowStatusMessage("TUGBot -> Allies -> Added " & name, 50)
            End If
    End Sub

    Public Sub AddEnemy(ByVal name As String)
        If Me.EnemyList.Items.Contains(name) Then
            TClient.ShowStatusMessage("TUGBot -> """ & name & """ is already on your enemy list!", 50)
        ElseIf Me.AllyList.Items.Contains(name) Then
            TClient.ShowStatusMessage("TUGBot -> """ & name & """ cannot be both an enemy and an ally!", 50)
        Else
            Me.EnemyList.Items.Add(name)
            If ShowTeamMarks.Checked Then
                TClient.Hook.AddCreatureText(0, name, -20, 0, Color.Red, 2, "(E)")
            End If
            TClient.ShowStatusMessage("TUGBot -> Enemies -> Added " & name, 50)
            End If
    End Sub

    Public Sub UpdateMarks()
        TClient.Hook.ClearCreatureTextAndDescription()
        If ShowTeamMarks.Checked Then
            TClient.Battlelist.Cache()
            For Each N As String In AllyList.Items
                TClient.Hook.AddCreatureText(0, N, -20, 0, Color.SkyBlue, 2, "(A)")
            Next

            For Each N As String In EnemyList.Items
                TClient.Hook.AddCreatureText(0, N, -20, 0, Color.Red, 2, "(E)")
            Next
        End If

        For Each P As TrainingPartner In Trainer.TrainList.Items
            If P.Num < 10 Then
                TClient.Hook.AddCreatureText(P.ID, "", -25, 0, Color.Silver, 2, "TP" & P.Num)
            Else
                TClient.Hook.AddCreatureText(P.ID, "", -30, 0, Color.Silver, 2, "TP" & P.Num)
            End If
        Next
    End Sub
#End Region

#Region "Ally context menu"
    Private Sub AddAllyPlayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAllyPlayer.Click
        Dim name As String = InputBox("Please enter the characters name.")
        If name = "" Then Exit Sub
        If Not Me.EnemyList.Items.Contains(name) AndAlso Not Me.AllyList.Items.Contains(name) Then
            Me.AllyList.Items.Add(name)
            TClient.ShowStatusMessage("TUGBot -> Allies -> Added " & name, 50)
        End If
        UpdateMarks()
    End Sub

    Private Sub AddAllyGuild_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAllyGuild.Click
        Dim Res As MsgBoxResult = MsgBox("When adding a full guild, the bot may freeze for a few seconds, possibly delaying the healer and other automatic functions. Make sure your in a safe place before adding an entire guild." & vbNewLine & "Also note, this only works with REAL TIBIA GUILDS." & vbNewLine & "If you would like to continue, hit ""ok"", if you would like to wait until your in a safe location, hit ""cancel""", MsgBoxStyle.OkCancel)
        If Res = MsgBoxResult.Cancel Then
            Exit Sub
        End If
        Dim name As String = InputBox("Please enter the guilds name.")
        If name = "" Then Exit Sub
        Website.GuildMembers(name, AddressOf RecievedAllyGuild)
    End Sub

    Public Sub RecievedAllyGuild(ByVal members As List(Of String))
        For Each C As String In members
            If C Is Nothing Or C = "" Then Continue For
            If Not Me.EnemyList.Items.Contains(C) AndAlso Not Me.AllyList.Items.Contains(C) Then
                Me.AllyList.Items.Add(C)
                Me.AllyList.Refresh()
            End If
        Next
        UpdateMarks()
    End Sub

    Private Sub RemoveSelectedAlly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveSelectedAlly.Click
        If AllyList.SelectedIndex <> -1 Then
            AllyList.Items.RemoveAt(AllyList.SelectedIndex)
        End If
        UpdateMarks()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        Dim res As MsgBoxResult = MsgBox("Are you sure you want to clear your list of allies?", MsgBoxStyle.YesNo)

        If res = MsgBoxResult.Yes Then
            AllyList.Items.Clear()
        End If
        UpdateMarks()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Main.SaveFile.Title = "Save Allies"
        Main.SaveFile.Filter = "TUGBot Team File (*.TBTL)|*.TBTL|All files (*.*)|*.*"

        If System.IO.Directory.Exists(Application.StartupPath & "\Quickload\Teams") Then
            Main.SaveFile.InitialDirectory = Application.StartupPath & "\Quickload\Teams"
        Else
            Main.SaveFile.InitialDirectory = Application.StartupPath
        End If
        Main.SaveFile.FileName = ""
        Main.SaveFile.ShowDialog()

        If Main.SaveFile.FileName = "" Then Exit Sub

        ListSave(Main.SaveFile.FileName, AllyList)
    End Sub

    Private Sub LoadAllyMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadAllyMenu.Click
        Main.LoadFile.Title = "Load Allies"
        Main.LoadFile.Filter = "TUGBot Team File (*.TBTL)|*.TBTL|All files (*.*)|*.*"

        If System.IO.Directory.Exists(Application.StartupPath & "\Quickload\Teams") Then
            Main.LoadFile.InitialDirectory = Application.StartupPath & "\Quickload\Teams"
        Else
            Main.LoadFile.InitialDirectory = Application.StartupPath
        End If
        Main.LoadFile.FileName = ""
        Main.LoadFile.ShowDialog()

        If Main.LoadFile.FileName = "" Then Exit Sub
        AllyList.Items.Clear()
        ListLoad(Main.LoadFile.FileName, AllyList)
    End Sub
#End Region

#Region "Enemy context menu"
    Private Sub AddEnemyPlayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEnemyPlayer.Click
        Dim name As String = InputBox("Please enter the characters name.")
        If name = "" Then Exit Sub
        If Not Me.EnemyList.Items.Contains(name) AndAlso Not Me.AllyList.Items.Contains(name) Then
            Me.EnemyList.Items.Add(name)
            TClient.ShowStatusMessage("TUGBot -> Enemies -> Added " & name, 50)
        End If
        UpdateMarks()
    End Sub

    Private Sub AddEnemyGuild_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEnemyGuild.Click
        Dim Res As MsgBoxResult = MsgBox("When adding a full guild, the bot may freeze for a few seconds, possibly delaying the healer and other automatic functions. Make sure your in a safe place before adding an entire guild." & vbNewLine & "Also note, this only works with REAL TIBIA GUILDS." & vbNewLine & "If you would like to continue, hit ""ok"", if you would like to wait until your in a safe location, hit ""cancel""", MsgBoxStyle.OkCancel)
        If Res = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        Dim name As String = InputBox("Please enter the guilds name.")
        If name = "" Then Exit Sub
        Website.GuildMembers(name, AddressOf RecievedEnemyGuild)
        UpdateMarks()
    End Sub

    Public Sub RecievedEnemyGuild(ByVal members As List(Of String))
        For Each C As String In members
            If C Is Nothing Or C = "" Then Continue For
            If Not Me.EnemyList.Items.Contains(C) AndAlso Not Me.AllyList.Items.Contains(C) Then
                Me.EnemyList.Items.Add(C)
                Me.EnemyList.Refresh()
            End If
        Next
        UpdateMarks()
    End Sub

    Private Sub RemoveEnemyPlayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveEnemyPlayer.Click
        If EnemyList.SelectedIndex <> -1 Then
            EnemyList.Items.RemoveAt(EnemyList.SelectedIndex)
        End If
        UpdateMarks()
    End Sub

    Private Sub ClearEnemyList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearEnemyList.Click
        Dim res As MsgBoxResult = MsgBox("Are you sure you want to clear your list of enemies?", MsgBoxStyle.YesNo)

        If res = MsgBoxResult.Yes Then
            EnemyList.Items.Clear()
        End If
        UpdateMarks()
    End Sub

    Private Sub SaveEnemyList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveEnemyList.Click
        Main.SaveFile.Title = "Save Enemies"
        Main.SaveFile.Filter = "TUGBot Team File (*.TBTL)|*.TBTL|All files (*.*)|*.*"

        If System.IO.Directory.Exists(Application.StartupPath & "\Quickload\Teams") Then
            Main.SaveFile.InitialDirectory = Application.StartupPath & "\Quickload\Teams"
        Else
            Main.SaveFile.InitialDirectory = Application.StartupPath
        End If
        Main.SaveFile.FileName = ""
        Main.SaveFile.ShowDialog()

        If Main.SaveFile.FileName = "" Then Exit Sub

        ListSave(Main.SaveFile.FileName, EnemyList)
    End Sub

    Private Sub LoadEnemyMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadEnemyMenu.Click
        Main.LoadFile.Title = "Load Enemies"
        Main.LoadFile.Filter = "TUGBot Team File (*.TBTL)|*.TBTL|All files (*.*)|*.*"

        If System.IO.Directory.Exists(Application.StartupPath & "\Quickload\Teams") Then
            Main.LoadFile.InitialDirectory = Application.StartupPath & "\Quickload\Teams"
        Else
            Main.LoadFile.InitialDirectory = Application.StartupPath
        End If
        Main.LoadFile.FileName = ""
        Main.LoadFile.ShowDialog()

        If Main.LoadFile.FileName = "" Then Exit Sub
        EnemyList.Items.Clear()
        ListLoad(Main.LoadFile.FileName, EnemyList)
    End Sub
#End Region

    Private Sub PotionType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PotionType.TextChanged
        PotionType.Text = FormatItem(PotionType.Text)
    End Sub

#Region "Check boxes"
    Private Sub EnableAllyHealer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableAllyHealer.CheckedChanged
        SioMana.Enabled = Not EnableAllyHealer.Checked
        SioAt.Enabled = Not EnableAllyHealer.Checked
    End Sub

    Private Sub ShowTeamMarks_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowTeamMarks.CheckedChanged
        TClient.Hook.ClearCreatureTextAndDescription()
        If ShowTeamMarks.Checked Then
            TClient.Battlelist.Cache()
            For Each N As String In AllyList.Items
                TClient.Hook.AddCreatureText(0, N, -20, 0, Color.SkyBlue, 2, "(A)")
            Next

            For Each N As String In EnemyList.Items
                TClient.Hook.AddCreatureText(0, N, -20, 0, Color.Red, 2, "(E)")
            Next
        End If

        For Each P As TrainingPartner In Trainer.TrainList.Items
            If P.Num < 10 Then
                TClient.Hook.AddCreatureText(P.ID, "", -25, 0, Color.Silver, 2, "TP" & P.Num)
            Else
                TClient.Hook.AddCreatureText(P.ID, "", -30, 0, Color.Silver, 2, "TP" & P.Num)
            End If
        Next
    End Sub

    Private Sub ShowTeamSquares_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowTeamSquares.CheckedChanged
        If ShowTeamSquares.Checked Then
            LastExiva.Start()
        Else
            LastExiva.Stop()
        End If
    End Sub
#End Region

#Region "Combobot Spells"
    Private Sub EnableSpellCombo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableSpellCombo.CheckedChanged
        If LeaderSpellName.Text.Trim = "" And EnableSpellCombo.Checked Then
            EnableSpellCombo.Checked = False
            Exit Sub
        End If

        If ComboAtSpell.Text.Trim = "" And EnableSpellCombo.Checked Then
            EnableSpellCombo.Checked = False
            Exit Sub
        End If

        If FormatSpell(ComboWithSpell.Text).Trim = "" And EnableSpellCombo.Checked Then
            EnableSpellCombo.Checked = False
            Exit Sub
        End If

        LeaderSpellName.Enabled = Not EnableSpellCombo.Checked
        ComboAtSpell.Enabled = Not EnableSpellCombo.Checked
        ComboWithSpell.Enabled = Not EnableSpellCombo.Checked
        ComboAtMana.Enabled = Not EnableSpellCombo.Checked
    End Sub

    Private Sub CreatureSpeak(ByVal name As String, ByVal level As Integer, ByVal spell As String)
        If EnableSpellCombo.Checked Then
            If Not Healing Then
                If TClient.Self.Mana > ComboAtMana.Value Then
                    If name.ToLower = LeaderSpellName.Text.ToLower Then
                        If spell.Trim.ToLower = ComboAtSpell.Text.Trim.ToLower Then
                            TClient.Self.Say(FormatSpell(ComboWithSpell.Text))
                        End If
                    End If
                End If
            End If
        End If
    End Sub
#End Region

#Region "Combobot runes"
    Public ComboArray As Byte() = {}

    Private Sub ProjectileShot(ByVal FromPos As Location, ByVal ToPos As Location, ByVal Type As ProjectileType)
        If FromPos.z = TClient.Self.Z And ToPos.z = TClient.Self.Z Then
            If Type = ProjectileType.IceSmall Then

                TClient.Battlelist.Cache()
                Dim Attacked As Integer
                Dim Aggreser As Integer = FindPlayerOnPos(FromPos)

                If Aggreser = 0 Then Exit Sub

                If TClient.Battlelist.Name(Aggreser).ToLower = LeaderRuneName.Text.ToLower Then

                    Attacked = FindPlayerOnPos(ToPos)

                    If Attacked <> 0 Then

                    End If
                End If
            End If
        End If
    End Sub

    Private Function FindPlayerOnPos(ByVal Pos As Location) As Integer
        Dim blpos As Integer = 0
        Dim Count As Integer = 0

        For i As Integer = 1 To TClient.Battlelist.Length
            If Pos.x = TClient.Battlelist.X(i) Then
                If Pos.y = TClient.Battlelist.Y(i) Then
                    If Pos.z = TClient.Battlelist.Z(i) Then
                        blpos = i
                        Count += 1
                    End If
                End If
            End If
        Next

        If Count = 1 Then
            Return blpos
        Else
            Return 0
        End If

    End Function
#End Region

End Class
