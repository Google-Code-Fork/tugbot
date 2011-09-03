Partial Public Class client
    Public VipPlayer As String
    Public LastExiva As String
    Public ShowLookIDS As Boolean = False

    Public Event AddedAlly(ByVal name As String)
    Public Event AddedEnemy(ByVal name As String)

    Public Event AddedPartner(ByVal ID As UInt32)

    Public Event KeyDown(ByVal key As Keys)
    Public Event KeyPress(ByVal key As Keys)
    Public Event KeyUp(ByVal key As Keys)
    Public Event MouseAction(ByVal Key As Integer, ByVal x As Integer, ByVal y As Integer)

    Public Event CreatureHealthUpdated(ByVal cID As Integer, ByVal hp As Byte, ByVal oldHp As Byte)
    Public Event CreatureAttacking(ByVal cID As Integer)
    Public Event CorpseDropped(ByVal CorpseID As Short, ByVal pos As Location)

    Public Event ProjectileShot(ByVal FromPos As Location, ByVal ToPos As Location, ByVal Type As ProjectileType)

    Public Event TryAttack()

    Public Event CreatureDefaultSpeech(ByVal name As String, ByVal level As Integer, ByVal text As String)
    Public Event CreaturePrivateSpeak(ByVal name As String, ByVal level As Integer, ByVal text As String)
    Public Event GameMasterSpeak(ByVal name As String, ByVal text As String)
    Public Event TradeChannelSpeak(ByVal name As String, ByVal level As Integer, ByVal text As String)


    Public TargetPosition As Location

    Public Enum ContextEventType
        AddAlly = 1000
        AddEnemy = 1001
        ShowProfileVIP = 1002
        ItemId = 1003
        Exiva = 1004
        ClickReUse = 1005
        CloneOutfit = 1006
        AddAllyVip = 1007
        AddEnemyVip = 1008
        ShowProfile = 1009

        AddLootArrow = 1010
        AddLootRight = 1011
        AddLootLeft = 1012
        AddLootBp = 1013

        OpenTUGBot = 1014
        OpenTools = 1015
        OpenSupport = 1016
        OpenMagic = 1017

        OpenLooter = 1018
        OpenAttacker = 1019
        OpenWalker = 1020
        OpenHotkeys = 1021
        OpenIcons = 1022
        OpenWar = 1023
        OpenHUD = 1024

        TrainingPartner = 1025
    End Enum

    Public Sub Closed()
        If Not hasraisedclose Then
            hasraisedclose = True
            RaiseEvent ClientClosed()
        End If
    End Sub

    Public Sub Ready()


        'Me.Hook.AddContextMenu(ContextEventType.AddLootArrow, "Loot [Arrow Slot]", MType.ItemTrade, True)
        'Me.Hook.AddContextMenu(ContextEventType.AddLootRight, "Loot [Right Hand]", MType.ItemTrade, False)
        'Me.Hook.AddContextMenu(ContextEventType.AddLootLeft, "Loot [Left Hand]", MType.ItemTrade, False)
        'Me.Hook.AddContextMenu(ContextEventType.AddLootBp, "Loot [Arrow Slot]", MType.ItemTrade, False)

        'Me.Hook.AddContextMenu(ContextEventType.OpenTUGBot, "Open TUGBot", MType.Self, True)

        'Me.Hook.AddContextMenu(ContextEventType.OpenTools, "Open Tools", MType.Self, True)
        'Me.Hook.AddContextMenu(ContextEventType.OpenSupport, "Open Support", MType.Self, False)
        'Me.Hook.AddContextMenu(ContextEventType.OpenMagic, "Open Magic", MType.Self, False)

        'Me.Hook.AddContextMenu(ContextEventType.OpenLooter, "Open Looter", MType.Self, True)
        'Me.Hook.AddContextMenu(ContextEventType.OpenAttacker, "Open Attacker", MType.Self, False)
        'Me.Hook.AddContextMenu(ContextEventType.OpenWalker, "Open Walker", MType.Self, False)

        'Me.Hook.AddContextMenu(ContextEventType.OpenIcons, "Open Icons", MType.Self, True)
        'Me.Hook.AddContextMenu(ContextEventType.OpenHotkeys, "Open Hotkeys", MType.Self, False)

        'Me.Hook.AddContextMenu(ContextEventType.OpenWar, "Open War", MType.Self, True)
        'Me.Hook.AddContextMenu(ContextEventType.OpenHUD, "Open HUD", MType.Self, False)

        'MagicWallThread.Start()

        HooksInjected = True
        RaiseEvent ClientOpened()
    End Sub

#Region "Hook handler"
    Private Sub Hook_ContextMenuClicked(ByVal EventID As Integer) Handles Hook.ContextMenuClicked
        ContextMenuClicked(EventID)
    End Sub

    Private Sub Hook_HookInjected() Handles Hook.HookInjected
        Ready()
    End Sub

    Private Sub Hook_UnHooked() Handles Hook.UnHooked
        Closed()
    End Sub

    Private Sub Hook_CreauteSpeak(ByVal name As String, ByVal level As Integer, ByVal text As String, ByVal type As Byte, ByVal channel As Integer) Handles Hook.CreatureSpeak
        CreatureSpeak(name, level, text, type, channel)
    End Sub

    Private Sub Hook_ProjectileShot(ByVal FromPos As Location, ByVal ToPos As Location, ByVal Type As ProjectileType) Handles Hook.ProjectileShot
        RaiseEvent ProjectileShot(FromPos, ToPos, Type)
    End Sub
#End Region

#Region "Context Menus"
    Public Sub ContextMenuClicked(ByVal eventID As Integer)
        Select Case CType(eventID, ContextEventType)
            Case ContextEventType.AddAlly
                Battlelist.Cache()
                For i As Byte = 1 To TClient.Battlelist.Length
                    If Me.Battlelist.ID(i) = ReadInt(Me.Addresses.ClickPlayerId) Then
                        RaiseEvent AddedAlly(Me.Battlelist.Name(i))
                        Exit Sub
                    End If
                Next
            Case ContextEventType.AddEnemy
                Battlelist.Cache()
                For i As Byte = 1 To TClient.Battlelist.Length
                    If Me.Battlelist.ID(i) = ReadInt(Me.Addresses.ClickPlayerId) Then
                        RaiseEvent AddedEnemy(Me.Battlelist.Name(i))
                        Exit Sub
                    End If
                Next
            Case ContextEventType.ClickReUse
                Me.ShowStatusMessage("Not yet functional.", 50)
            Case ContextEventType.CloneOutfit
                Me.ShowStatusMessage("Not yet functional.", 50)
            Case ContextEventType.Exiva
                Me.Self.Say("Exiva """ & VipPlayer)
            Case ContextEventType.ItemId
                'Dim L As Location = LocateDepot
                'If L.x <> Nothing Then
                '    DisplayAnimatedText(TextColor.Blue, "Depot", L)
                '    Dim id As Integer = TClient.Map.GetTileObjectId(TClient.Map.GetTile(L.x, L.y, L.z), L.Stack)
                '    TClient.Hook.UseItemFromGround(L.x, L.y, CByte(L.z), id, L.Stack, 1)
                'End If

                'TClient.Hook.BuyItem(Me.ReadInt(Me.Addresses.ClickItemId), 3, True, False)
                'TClient.Hook.BuyItem(Me.ReadInt(Me.Addresses.ClickItemId), 1, False, False)
                Me.ShowStatusMessage("Item ID: " & Me.ReadInt(Me.Addresses.ClickItemId), 50)
            Case ContextEventType.ShowProfileVIP
                'OpenURL("http://www.tibia.com/community/?subtopic=characters&name=" & VipPlayer)
            Case ContextEventType.ShowProfile
                Me.Battlelist.Cache()
                Dim TId As Integer = Me.ReadInt(Me.Addresses.ClickPlayerId)
                For i As Byte = 1 To TClient.Battlelist.Length
                    If Battlelist.ID(i) = TId Then
                        OpenURL("http://www.tibia.com/community/?subtopic=characters&name=" & Battlelist.Name(i))
                        Exit Sub
                    End If
                Next
            Case ContextEventType.AddAllyVip
                RaiseEvent AddedAlly(VipPlayer)
            Case ContextEventType.AddEnemyVip
                RaiseEvent AddedEnemy(VipPlayer)
            Case ContextEventType.TrainingPartner
                RaiseEvent AddedPartner(Me.ReadInt(Me.Addresses.ClickPlayerId))
        End Select
    End Sub
#End Region

#Region "Creature Speak"
    Public Sub CreatureSpeak(ByVal sender As String, ByVal level As Integer, ByVal msg As String, ByVal type As Byte, ByVal channel As Integer)
        Dim check As Integer = 0
        If CDbl(TClient.Version) >= CDbl("8.61") Then
            If type = SpeechTypePost861.Say OrElse type = SpeechTypePost861.Yell OrElse type = SpeechTypePost861.Whisper Then
                check = 1
            ElseIf type = SpeechTypePost861.ChannelYellow Then
                check = 2
            End If
        Else
            If type = SpeechTypePre861.Say OrElse type = SpeechTypePre861.Yell OrElse type = SpeechTypePre861.Whisper Then
                check = 1
            ElseIf type = SpeechTypePre861.ChannelYellow Then
                check = 2
            End If
        End If


        If check = 1 Then
            If isCommander(sender) Then
                doCommandercommand(sender, msg)
            ElseIf sender = Self.Name AndAlso IsSpell(msg) Then
                'Profile.IncremetSpell(msg)
                If msg.ToLower = "utani hur" Or msg.ToLower.StartsWith("utani hur """) Then
                    Me.LastHasteType = 1
                    Me.LastSaidHaste = Date.Now
                ElseIf msg.ToLower = "utani gran hur" Or msg.ToLower.StartsWith("utani gran hur """) Then
                    Me.LastHasteType = 2
                    Me.LastSaidHaste = Date.Now
                ElseIf msg.ToLower = "utana vid" Or msg.ToLower.StartsWith("utana vid """) Then
                    Me.LastSaidInvis = Date.Now
                ElseIf msg.ToLower = "utamo vita" Or msg.ToLower.StartsWith("utana vita """) Then
                    Me.LastSaidMShield = Date.Now
                End If

                If msg.ToLower.StartsWith("exiva """) Then
                    Dim TempStr As String() = msg.Split("""")
                    If TempStr.Length >= 2 Then
                        LastExiva = TempStr(1)
                    End If
                ElseIf msg.ToLower.StartsWith("exiva ") Then
                    Dim TempStr As String() = msg.Split(" ")
                    If TempStr.Length >= 2 Then
                        LastExiva = TempStr(1)
                    End If
                End If
            End If

            RaiseEvent CreatureDefaultSpeech(sender, level, msg)
        ElseIf check = 2 Then
            If CDbl(TClient.Version) >= CDbl("8.61") Then
                If channel = &H4 OrElse channel = &H5 Then
                    RaiseEvent TradeChannelSpeak(sender, level, msg)
                End If
            Else
                If channel = &H6 OrElse channel = &H7 Then
                    RaiseEvent TradeChannelSpeak(sender, level, msg)
                End If
            End If
        End If
    End Sub
#End Region

#Region "Text message received"
    Public Sub TextMessageRecieved(ByVal type As Byte, ByVal msg As String)
        Dim stat As Boolean = False
        'Stauts messages changed in 8.61
        If CDbl(TClient.Version) >= CDbl("8.61") Then
            If type = &H13 Then stat = True
        Else
            If type = StatusMessage.DescriptionGreen Then stat = True
        End If

        If stat Then
            If msg.StartsWith("You see ") Then
                If Not ShowLookIDS OrElse (msg.ToLower.Contains("he is") OrElse msg.ToLower.Contains("she is") OrElse msg.ToLower.Contains("(level ") OrElse msg.ToLower.Contains("yourself")) Then
                    ForwardTextMessage(type, msg)
                Else
                    ForwardTextMessage(type, msg & " [ID " & ReadInt(Addresses.ClickItemId) & "]")
                End If
                'MsgBox(msg)
                'For now we will forward it, until I write the code to
                'Look at new creatures and record their levels and vocs
            ElseIf msg.StartsWith("Using one of") Then
                ForwardTextMessage(type, msg)

                msg = msg.Remove(0, 13)
                Dim Count As Integer = Math.Abs(ParseInteger(msg.Split(" ")(0)) - 1)
                Dim Name As String = msg.Split(" ", 2, StringSplitOptions.None)(1).Replace(" ", "_").Replace(".", "")
                If Name.EndsWith("s") Then
                    Name = Name.Remove(Name.Length - 1, 1)
                End If

                SetItemCount(Name, Count)
            ElseIf msg.StartsWith("Using the last") Then
                ForwardTextMessage(type, msg)

                msg = msg.Remove(0, 15)
                Dim Count As Integer = 0
                Dim Name As String = msg.Replace(" ", "_").Replace(".", "")
                SetItemCount(Name, Count)
            Else
                ForwardTextMessage(type, msg)
            End If
        Else
            ForwardTextMessage(type, msg)
        End If
    End Sub

    Private Sub ForwardTextMessage(ByVal type As Byte, ByVal msg As String)
        Dim pack As New PacketBuilder
        pack.AddByte(IncomingPacketType.StatusMessage)
        pack.AddByte(type)
        pack.AddString(msg)
        Hook.SendPacketToClient(pack.GetPacket)
    End Sub
#End Region

#Region "Creature Update Health"
    Public Sub CreatureUpdatedHealth(ByVal cID As Integer, ByVal health As Byte)
        TClient.Battlelist.Cache()
        For I As Integer = 1 To TClient.Battlelist.Length
            If Battlelist.ID(I) = cID Then
                RaiseEvent CreatureHealthUpdated(cID, health, Battlelist.Health(I))

                TClient.WriteByte(Addresses.Battlelist.Start + ((I - 1) * Addresses.Battlelist.Step) + Addresses.Battlelist.HpBar, health)
                If cID = Self.Target Then
                    TClient.DelayTime = 1500
                    TClient.DelayStart = GetTickCount()
                    CaveBotAttacker.TargettingTimer.Interval = 666
                    TargetPosition = New Location(Battlelist.X(I), Battlelist.Y(I), Battlelist.Z(I))
                End If
                Exit For
            End If
        Next

        Dim pack As New PacketBuilder
        pack.AddByte(IncomingPacketType.CreatureHealth)
        pack.AddLong(cID)
        pack.AddByte(health)
        Hook.SendPacketToClient(pack.GetPacket)
    End Sub
#End Region

#Region "Creature attack"
    Public Sub CreatureAttack(ByVal id As Integer)
        RaiseEvent CreatureAttacking(id)
    End Sub
#End Region

#Region "Magwall timers"
    Dim MagicWallThread As New TimedThread(400, New TimedThread.RunThreadDelegate(AddressOf TimeMagicWalls), False)
    Public MagicWalls As New List(Of MagicWall)
    Public Sub TimeMagicWalls(ByVal a As Action)
        SyncLock MagicWalls
            For Each M As MagicWall In MagicWalls
                If M.Time < 0 Then
                    M.MagicWallThread.Pause()
                    M.MagicWallThread = Nothing
                    MagicWalls.Remove(M)
                    M = Nothing
                    Exit Sub
                End If
            Next
        End SyncLock
    End Sub
#End Region

#Region "Tile add corpse"
    Public Sub TileCorpseAdded(ByVal CorpseID As Short, ByVal pos As Location, ByVal stack As Byte)
        If pos.IsAdjacentToo(TargetPosition) OrElse Me.Self.IsAdjecentTo(pos.x, pos.y, pos.z) Then
            pos.Stack = stack
            RaiseEvent CorpseDropped(CorpseID, pos)
        End If
    End Sub
#End Region

#Region "Creature Added"
    Public Sub CreatureAdded(ByVal position As Location, ByVal stack As Byte, ByVal Name As String, ByVal ID As Integer, ByVal RemoveID As Integer)
        If ID < &H40000000 Then
            'MsgBox(Name)
        End If
    End Sub
#End Region

    Public Sub _KeyDown(ByVal key As Byte)
        RaiseEvent KeyDown(CType(key, Keys))
    End Sub

    Public Sub _KeyPress(ByVal key As Byte)
        RaiseEvent KeyPress(CType(key, Keys))
    End Sub

    Public Sub _KeyUp(ByVal key As Byte)
        RaiseEvent KeyUp(CType(key, Keys))
    End Sub

    Public Sub _MouseAction(ByVal Key As Integer, ByVal x As Integer, ByVal y As Integer)
        RaiseEvent MouseAction(Key, x, y)
    End Sub

    Public Sub TryToAttack()
        RaiseEvent TryAttack()
    End Sub
End Class

Public Class MagicWall
    Public Time As Short
    Public Pos As Location
    Public MagicWallThread As New TimedThread(1000, New TimedThread.RunThreadDelegate(AddressOf TimeMagicWall), False)

    Public Sub New(ByVal position As Location)
        Time = 20
        Pos = position
        MagicWallThread.Start()
    End Sub

    Public Sub TimeMagicWall(ByVal a As Action)
        If Me.Time > 0 Then
            TClient.DisplayAnimatedText(Client.TextColor.Gold, Time, Pos)
            Time -= 1
        End If
    End Sub
End Class
