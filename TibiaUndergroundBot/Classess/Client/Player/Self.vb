Public Class Self
#Region "Variables"
    'Private Inventory As Inventory

    Public Enum Flags
        Poison = 1
        Fire = 2
        Energy = 4
        Drunk = 8
        ManaShield = 16
        Paralyze = 32
        Haste = 64
        Battle = 128
        Drown = 256
        Frozen = 512
        Dazzled = 1024
        Cursed = 2048
        Strengthened = 4096
        CannotLogoutOrEnterProtectionZone = 8192
        WithinProtectionZone = 16384
    End Enum
#End Region

    Public Sub New()
        'Inventory = New Inventory(Me.Client)
    End Sub

#Region "Declarations"
    'Public ReadOnly Property Items() As Inventory
    '    Get
    '        Return Me.Inventory
    '    End Get
    'End Property
#End Region

#Region "Port and IP"
    Public ReadOnly Property IP() As String
        Get
            Dim ID As Short = TClient.ReadShort(TClient.Addresses.Login.Selected)
            Dim Adr As Integer = TClient.ReadInt(TClient.Addresses.Login.CharList)
            Return TClient.ReadString(Adr + TClient.Addresses.Login.Step_Char * ID + TClient.Addresses.Login.OffsetIp)
        End Get
    End Property

    Public ReadOnly Property Port() As Integer
        Get
            Dim ID As Short = TClient.ReadShort(TClient.Addresses.Login.Selected)
            Dim Adr As Integer = TClient.ReadInt(TClient.Addresses.Login.CharList)
            Return TClient.ReadInt(Adr + TClient.Addresses.Login.Step_Char * ID + TClient.Addresses.Login.OffsetPort)
        End Get
    End Property
#End Region

#Region "Name, World and ID"
    Public ReadOnly Property World() As String
        Get
            Dim ID As Short = TClient.ReadShort(TClient.Addresses.Login.Selected)
            Dim Adr As Integer = TClient.ReadInt(TClient.Addresses.Login.CharList)
            Return TClient.ReadString(Adr + TClient.Addresses.Login.Step_Char * ID + TClient.Addresses.Login.OffsetServer)
        End Get
    End Property
    Public ReadOnly Property Name() As String
        Get
            If TClient.ReadInt(TClient.Addresses.Client.Connection) <> 8 Then
                Return "Logged out"
            End If

            Dim ID As Short = TClient.ReadShort(TClient.Addresses.Login.Selected)
            Dim Adr As Integer = TClient.ReadInt(TClient.Addresses.Login.CharList)
            Return TClient.ReadString(Adr + TClient.Addresses.Login.Step_Char * ID)
        End Get
    End Property

    Public ReadOnly Property CharList() As String()
        Get
            Dim S(TClient.Addresses.Login.Amount) As String
            Dim Adr As Integer = TClient.ReadInt(TClient.Addresses.Login.CharList)

            For I As Integer = 0 To TClient.Addresses.Login.Amount - 1
                S(I) = TClient.ReadString(Adr + TClient.Addresses.Login.Step_Char * I) & " (" & TClient.ReadString(Adr + (TClient.Addresses.Login.Step_Char * I) + TClient.Addresses.Login.OffsetServer) & ")"
            Next

            Return S
        End Get
    End Property

    Public ReadOnly Property Id() As Integer
        Get
            Return TClient.ReadInt(TClient.Addresses.Player.Id)
        End Get
    End Property
#End Region

#Region "Flags"
    Private Function Flag(ByVal Check As Flags) As Boolean
        Return (TClient.ReadInt(TClient.Addresses.Player.Status) And CInt(Check)) = CInt(Check)
    End Function

    Public ReadOnly Property Paralyzed() As Boolean
        Get
            Return Flag(Flags.Paralyze)
        End Get
    End Property

    Public ReadOnly Property Poisoned() As Boolean
        Get
            Return Flag(Flags.Poison)
        End Get
    End Property

    Public ReadOnly Property Hasted() As Boolean
        Get
            Return Flag(Flags.Haste)
        End Get
    End Property

    Public ReadOnly Property Cursed() As Boolean
        Get
            Return Flag(Flags.Cursed)
        End Get
    End Property

    Public ReadOnly Property Burnt() As Boolean
        Get
            Return Flag(Flags.Fire)
        End Get
    End Property

    Public ReadOnly Property Dazzled() As Boolean
        Get
            Return Flag(Flags.Dazzled)
        End Get
    End Property

    Public ReadOnly Property Drowning() As Boolean
        Get
            Return Flag(Flags.Drown)
        End Get
    End Property

    Public ReadOnly Property Drunk() As Boolean
        Get
            Return Flag(Flags.Drunk)
        End Get
    End Property

    Public ReadOnly Property Energized() As Boolean
        Get
            Return Flag(Flags.Energy)
        End Get
    End Property

    Public ReadOnly Property Frozen() As Boolean
        Get
            Return Flag(Flags.Frozen)
        End Get
    End Property

    Public ReadOnly Property Battle() As Boolean
        Get
            Return Flag(Flags.Battle)
        End Get
    End Property

    Public ReadOnly Property MagicShield() As Boolean
        Get
            Return Flag(Flags.Manashield)
        End Get
    End Property
#End Region

    'FINISH HAS TARGET AND DIRECTION ONCE BLSIT DONE
#Region "Target and direction"
    Public ReadOnly Property HasTarget(Optional ByVal cache As Boolean = True) As Boolean
        Get
            If Me.Target <= 0 Then Return False
            If cache Then TClient.Battlelist.Cache()
            For i = 1 To TClient.Battlelist.Length
                If TClient.Battlelist.ID(i) = Me.Target Then
                    If TClient.Battlelist.IsVisible(i) Then
                        Return True
                    End If
                End If
            Next

            Return False
        End Get
    End Property

    Public ReadOnly Property Target() As Integer
        Get
            Return TClient.ReadInt(TClient.Addresses.Player.Target)
        End Get
    End Property

    Public ReadOnly Property Direction() As Integer
        Get
            TClient.Battlelist.Cache()
            For i = 1 To TClient.Battlelist.Length
                If TClient.Battlelist.ID(i) = Me.Id Then
                    Return TClient.Battlelist.Direction(i)
                End If
            Next
        End Get
    End Property
#End Region

#Region "Magic Level, Cap, Soul, Stamina"
    Public ReadOnly Property MagicLevel() As Integer
        Get
            Return TClient.ReadInt(TClient.Addresses.Player.MagicLevel)
        End Get
    End Property
    Public ReadOnly Property Soul() As Integer
        Get
            Return TClient.ReadInt(TClient.Addresses.Player.Soul)
        End Get
    End Property
    Public ReadOnly Property Cap() As Integer
        Get
            Return CInt(TClient.ReadInt(TClient.Addresses.Player.Capacity) \ 100)
        End Get
    End Property
    Public ReadOnly Property Stamina() As Integer
        Get
            Return TClient.ReadInt(TClient.Addresses.Player.Stamina)
        End Get
    End Property
#End Region

#Region "inventory"
    Public ReadOnly Property SlotID(ByVal SlotNumber As Enums.Slots) As Integer
        Get
            Return TClient.ReadInt(TClient.Addresses.Player.HeadSlot + ((SlotNumber - 1) * 12))
        End Get
    End Property

    Public ReadOnly Property SlotCount(ByVal SlotNumber As Byte) As Integer
        Get
            Return TClient.ReadInt(TClient.Addresses.Player.HeadSlot + ((SlotNumber - 1) * 12) + 4)
        End Get
    End Property
#End Region

    'FIX
#Region "Skills"
    Public ReadOnly Property Skills() As Structures.Skills
        Get
            Return Nothing 'Player.Skills
        End Get
    End Property
#End Region

#Region "Level/Exp"
    Public ReadOnly Property Exp() As Integer
        Get
            Return TClient.ReadInt(TClient.Addresses.Player.Experience)
        End Get
    End Property
    Public ReadOnly Property Level() As Integer
        Get
            Return TClient.ReadInt(TClient.Addresses.Player.Level)
        End Get
    End Property
#End Region

#Region "Health/Mana"
    Public ReadOnly Property Health() As Integer
        Get
            Return TClient.ReadInt(TClient.Addresses.Player.Health)
        End Get
    End Property
    Public ReadOnly Property MaxHealth() As Integer
        Get
            Return TClient.ReadInt(TClient.Addresses.Player.MaxHealth)
        End Get
    End Property
    Public ReadOnly Property Mana() As Integer
        Get
            Return TClient.ReadInt(TClient.Addresses.Player.Mana)
        End Get
    End Property
    Public ReadOnly Property MaxMana() As Integer
        Get
            Return TClient.ReadInt(TClient.Addresses.Player.MaxMana)
        End Get
    End Property
#End Region

#Region "Position"
    Public ReadOnly Property X() As Integer
        Get
            Return TClient.ReadInt(TClient.Addresses.Player.X)
        End Get
    End Property
    Public ReadOnly Property Y() As Integer
        Get
            Return TClient.ReadInt(TClient.Addresses.Player.Y)
        End Get
    End Property
    Public ReadOnly Property Z() As Integer
        Get
            Return TClient.ReadInt(TClient.Addresses.Player.Z)
        End Get
    End Property
#End Region

    'Moving and shit
#Region "Goto, Stop Moving, Adjecent, attack"
    Public Sub WalkTo(ByVal X As Integer, ByVal Y As Integer, ByVal Z As Byte)
        'If CurrentlyLooting() Then StopMoving() : Exit Sub
        Dim MeId As Integer = Me.Id
        Dim OffSet As Byte
        TClient.Battlelist.Cache()
        For i As Byte = 1 To TClient.Battlelist.Length
            If TClient.Battlelist.ID(i) = MeId Then
                OffSet = i - 1
                Exit For
            End If
        Next


        TClient.WriteInt(TClient.Addresses.Player.GotoX, X)
        TClient.WriteInt(TClient.Addresses.Player.GotoY, Y)
        TClient.WriteInt(TClient.Addresses.Player.GotoZ, Z)

        TClient.WriteInt(TClient.Addresses.Battlelist.Start + _
        OffSet * TClient.Addresses.Battlelist.Step + TClient.Addresses.Battlelist.IsWalking, 1)
    End Sub

    Public Sub StopMoving()
        TClient.Hook.StopActions()
        For i = 1 To 10
            System.Threading.Thread.Sleep(5)
            Application.DoEvents()
        Next
        TClient.WriteInt(TClient.Addresses.Player.GotoX, Me.X)
        TClient.WriteInt(TClient.Addresses.Player.GotoY, Me.Y)
        TClient.WriteInt(TClient.Addresses.Player.GotoZ, Me.Z)
    End Sub

    Public Function IsWalking() As Boolean
        Dim MeId As Integer = Me.Id
        Dim OffSet As Byte
        TClient.Battlelist.Cache()
        For i As Byte = 1 To TClient.Battlelist.Length
            If TClient.Battlelist.ID(i) = MeId Then
                OffSet = i - 1
                Exit For
            End If
        Next

        Return TClient.ReadInt(TClient.Addresses.Battlelist.Start + _
        OffSet * TClient.Addresses.Battlelist.Step + TClient.Addresses.Battlelist.IsWalking) >= 1
    End Function

    Public Function IsAdjecentTo(ByVal x As Integer, ByVal y As Integer, ByVal z As Byte) As Boolean

        If Me.Z = z Then
            If Math.Abs(Me.X - x) <= 1 Then
                If Math.Abs(Me.Y - y) <= 1 Then
                    Return True
                End If
            End If
        End If

        Return False
    End Function

    Public Function IsOnPos(ByVal x As Integer, ByVal y As Integer, ByVal z As Byte) As Boolean
        If Me.X = x And Me.Y = y And Me.Z = z Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub Attack(ByVal CreatureID As Integer)
        TClient.WriteInt(TClient.Addresses.Player.Target, CreatureID)
        TClient.Hook.Attack(CreatureID)
    End Sub
#End Region

    'FIX ALL
#Region "Methods"
    'Public Sub Logout(ByVal force As Boolean)
    '    Logouts(force)
    'End Sub
    'Public Sub Follow()
    '    If XTea Is Nothing Then Exit Sub
    '    If OnSend IsNot Nothing Then
    '        OnSend.BeginInvoke(FollowCreature, Nothing, Nothing)
    '    End If
    'End Sub

    'Public Sub NpcTalk(ByVal text As String)
    '    Dim Packet As New PacketBuilder(&H96)
    '    Packet.AddByte(&H4)
    '    Packet.AddString(text)
    '    If XTea Is Nothing Then Exit Sub
    '    If OnSend IsNot Nothing Then
    '        OnSend.BeginInvoke(Encryption.Xtea.Encrypt(Packet.GetPacket, XTea, True), Nothing, Nothing)
    '    End If
    'End Sub

    Public Sub MoveFromContainerToSlot(ByVal id As Short, ByVal count As Byte, ByVal container As Byte, ByVal spot As Byte, ByVal slot As Slots)
        Dim From As ItemLocation = ItemLocation.FromContainer(container, spot)
        Dim Too As ItemLocation = ItemLocation.FromSlot(slot)
        TClient.Hook.MoveItem(id, count, From, Too)
        From = Nothing
        Too = Nothing
    End Sub

    Public Sub MoveFromContainerToContainer(ByVal id As Short, ByVal count As Byte, ByVal cont1 As Byte, ByVal spot1 As Byte, ByVal cont2 As Byte, ByVal spot2 As Byte)
        Dim From As ItemLocation = ItemLocation.FromContainer(cont1, spot1)
        Dim Too As ItemLocation = ItemLocation.FromContainer(cont2, spot2)
        TClient.Hook.MoveItem(id, count, From, Too)
        From = Nothing
        Too = Nothing
    End Sub

    Public Sub MoveFromGroundToGround(ByVal id As Short, ByVal count As Byte, ByVal Loc1 As Location, ByVal stack As Byte, ByVal Loc2 As Location)
        Dim From As ItemLocation = ItemLocation.FromLocation(Loc1, stack)
        Dim Too As ItemLocation = ItemLocation.FromLocation(loc2, 1)
        TClient.Hook.MoveItem(id, count, From, Too)
        From = Nothing
        Too = Nothing
    End Sub

    Public Sub MoveFromContainerToGround(ByVal id As Short, ByVal count As Byte, ByVal cont As Byte, ByVal spot As Byte, ByVal stack As Byte, ByVal Loc2 As Location)
        Dim From As ItemLocation = ItemLocation.FromContainer(cont, spot)
        Dim Too As ItemLocation = ItemLocation.FromLocation(Loc2, 1)
        TClient.Hook.MoveItem(id, count, From, Too)
        From = Nothing
        Too = Nothing
    End Sub

    Public Sub Say(ByVal text As String)
        TClient.Hook.Speak(text, SelfSpeechType.Say)
    End Sub

    Public Sub Yell(ByVal text As String)
        TClient.Hook.Speak(text, SelfSpeechType.Yell)
    End Sub

    Public Sub Whisper(ByVal text As String)
        TClient.Hook.Speak(text, SelfSpeechType.Whisper)
    End Sub

    Public Sub NPCSay(ByVal text As String)
        TClient.Hook.Speak(text, SelfSpeechType.NPC)
    End Sub

    Public Sub UseItemWithCreature(ByVal ItemID As Integer, ByVal creatureID As Integer)
        TClient.Hook.UseItemWithCreature(CShort(ItemID), creatureID)
    End Sub

    Public Sub UseItem(ByVal ItemID As Integer)
        TClient.Hook.UseItem(CShort(ItemID))
    End Sub

    Public Sub UseItemFromInventory(ByVal container As Short, ByVal slot As Short, ByVal ItemID As Integer)
        TClient.Hook.UseItemFromInventory(container, slot, CShort(ItemID))
    End Sub

    Public Sub UseItemFromGround(ByVal x As Integer, ByVal y As Integer, ByVal z As Integer, ByVal itemid As Integer, ByVal stack As Byte, ByVal count As Short)
        TClient.Hook.UseItemFromGround(x, y, CByte(z), CShort(itemid), CByte(stack), CShort(count))
    End Sub

    Public Sub UseItemWithGround(ByVal GroundX As Integer, ByVal GroundY As Integer, ByVal GroundZ As Byte, ByVal UseID As Short, ByVal UseWithID As Integer, ByVal GroundStack As Byte)
        TClient.Hook.UseItemWithGround(GroundX, GroundY, GroundZ, UseID, UseWithID, GroundStack)
    End Sub
#End Region

End Class
