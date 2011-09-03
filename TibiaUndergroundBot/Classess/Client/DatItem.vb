Public Class DatItem
    Private id As Int32
    Private addr As UInt32
    Private add As Integer = -1

    Public Sub New(ByVal itemId As Int32)
        Dim baseAddr As UInt32 = TClient.ReadUInt(TAddresses.Client.DatPointer)
        If TAddresses.oldDat Then
            Me.addr = TClient.ReadUInt(baseAddr + 8) + (&H4C + 4) * (itemId - 100)
            add = 0
        Else
            Me.addr = TClient.ReadUInt(baseAddr + 8) + (&H4C) * (itemId - 100)
        End If
        id = itemId
    End Sub

#Region "Properties"
    Public ReadOnly Property Addrs() As UInteger
        Get
            Return addr
        End Get
    End Property
    Public ReadOnly Property ItemId() As UInteger
        Get
            Return id
        End Get
    End Property
    Public ReadOnly Property unKnownFirst() As UInteger
        Get
            Return TClient.ReadInt(addr)
        End Get
    End Property
    Public Property Width() As Int32
        Get
            Return TClient.ReadInt(addr + TAddresses.DatItem.Width * 4)
        End Get
        Set(ByVal value As Int32)
            TClient.WriteInt(addr + TAddresses.DatItem.Width * 4, value)
        End Set
    End Property
    Public Property Height() As Int32
        Get
            Return TClient.ReadInt(addr + TAddresses.DatItem.Height * 4)
        End Get
        Set(ByVal value As Int32)
            TClient.WriteInt(addr + TAddresses.DatItem.Height * 4, value)
        End Set
    End Property
    Public Property Unknown1() As Int32
        Get
            Return 0 'TClient.ReadInt(addr + TAddresses.DatItem.Unknown1 * 4)
        End Get
        Set(ByVal value As Int32)
            'TClient.WriteInt(addr + TAddresses.DatItem.Unknown1 * 4, value)
        End Set
    End Property
    Public Property Layers() As Int32
        Get
            Return TClient.ReadInt(addr + TAddresses.DatItem.Layers * 4)
        End Get
        Set(ByVal value As Int32)
            TClient.WriteInt(addr + TAddresses.DatItem.Layers * 4, value)
        End Set
    End Property
    Public Property PatternX() As Int32
        Get
            Return TClient.ReadInt(addr + TAddresses.DatItem.PatternX * 4)
        End Get
        Set(ByVal value As Int32)
            TClient.WriteInt(addr + TAddresses.DatItem.PatternX * 4, value)
        End Set
    End Property
    Public Property PatternY() As Int32
        Get
            Return TClient.ReadInt(addr + TAddresses.DatItem.PatternY * 4)
        End Get
        Set(ByVal value As Int32)
            TClient.WriteInt(addr + TAddresses.DatItem.PatternY * 4, value)
        End Set
    End Property
    Public Property PatternDepth() As Int32
        Get
            Return TClient.ReadInt(addr + TAddresses.DatItem.PatternDepth * 4)
        End Get
        Set(ByVal value As Int32)
            TClient.WriteInt(addr + TAddresses.DatItem.PatternDepth * 4, value)
        End Set
    End Property
    Public Property Phase() As Int32
        Get
            Return TClient.ReadInt(addr + TAddresses.DatItem.Phase * 4)
        End Get
        Set(ByVal value As Int32)
            TClient.WriteInt(addr + TAddresses.DatItem.Phase * 4, value)
        End Set
    End Property
    Public Property Sprites() As Int32
        Get
            Return TClient.ReadInt(addr + TAddresses.DatItem.Sprites * 4)
        End Get
        Set(ByVal value As Int32)
            TClient.WriteInt(addr + TAddresses.DatItem.Sprites * 4, value)
        End Set
    End Property
    Public Property Flags() As Int32
        Get
            Return TClient.ReadInt(addr + TAddresses.DatItem.Flags * 4)
        End Get
        Set(ByVal value As Int32)
            TClient.WriteInt(addr + TAddresses.DatItem.Flags * 4, value)
        End Set
    End Property
    Public Property WalkSpeed() As Int32
        Get
            Return TClient.ReadInt(addr + TAddresses.DatItem.WalkSpeed * 4)
        End Get
        Set(ByVal value As Int32)
            TClient.WriteInt(addr + TAddresses.DatItem.WalkSpeed * 4, value)
        End Set
    End Property
    Public Property TextLimit() As Int32
        Get
            Return TClient.ReadInt(addr + TAddresses.DatItem.TextLimit * 4)
        End Get
        Set(ByVal value As Int32)
            TClient.WriteInt(addr + TAddresses.DatItem.TextLimit * 4, value)
        End Set
    End Property
    Public Property LightRadius() As Int32
        Get
            Return TClient.ReadInt(addr + TAddresses.DatItem.LightRadius * 4)
        End Get
        Set(ByVal value As Int32)
            TClient.WriteInt(addr + TAddresses.DatItem.LightRadius * 4, value)
        End Set
    End Property
    Public Property LightColor() As Int32
        Get
            Return TClient.ReadInt(addr + TAddresses.DatItem.LightColor * 4)
        End Get
        Set(ByVal value As Int32)
            TClient.WriteInt(addr + TAddresses.DatItem.LightColor * 4, value)
        End Set
    End Property
    Public Property ShiftX() As Int32
        Get
            Return TClient.ReadInt(addr + TAddresses.DatItem.ShiftX * 4)
        End Get
        Set(ByVal value As Int32)
            TClient.WriteInt(addr + TAddresses.DatItem.ShiftX * 4, value)
        End Set
    End Property
    Public Property ShiftY() As Int32
        Get
            Return TClient.ReadInt(addr + TAddresses.DatItem.ShiftY * 4)
        End Get
        Set(ByVal value As Int32)
            TClient.WriteInt(addr + TAddresses.DatItem.ShiftY * 4, value)
        End Set
    End Property
    Public Property WalkHeight() As Int32
        Get
            Return TClient.ReadInt(addr + TAddresses.DatItem.WalkHeight * 4)
        End Get
        Set(ByVal value As Int32)
            TClient.WriteInt(addr + TAddresses.DatItem.WalkHeight * 4, value)
        End Set
    End Property
    Public Property Automap() As Int32
        Get
            Return TClient.ReadInt(addr + TAddresses.DatItem.Automap * 4)
        End Get
        Set(ByVal value As Int32)
            TClient.WriteInt(addr + TAddresses.DatItem.Automap * 4, value)
        End Set
    End Property

#End Region

#Region "Flags"
    Public Enum Flag As UInt32
        WalkSpeed = 0
        TopOrder1 = 1
        TopOrder2 = 2
        TopOrder3 = 3
        IsContainer = 4
        IsStackable = 5
        IsCorpse = 6
        IsUsable = 7
        isRune = 8
        IsWritable = 9
        IsReadable = 10
        IsFluidContainer = 11
        IsSplash = 12
        Blocking = 13
        IsImmovable = 14
        BlocksMissiles = 15
        BlocksPath = 16
        IsPickupable = 17
        IsHangable = 18
        IsHangableHorizontal = 19
        IsHangableVertizcal = 20
        IsRotatable = 21
        IsLightSource = 22
        Floorchange = 23
        IsShifted = 24
        HasHeight = 25
        IsLayer = 26
        IsIdleAnimation = 27
        HasAutoMapColor = 28
        HasHelpLens = 29
        IsGround = 30
    End Enum
    'Public Function GetFlag(ByVal flag As Flag) As Boolean
    'Return (Flags And CInt(flag)) = CInt(flag)
    'End Function

    Public Function GetFlag(ByVal flag As UInt32) As Boolean
        If flag > 8 Then flag += add
        flag = 2 ^ flag
        Return (Flags And CUInt(flag)) = CUInt(flag)
    End Function

    Public Sub SetFlag(ByVal flag As Flag, ByVal [on] As Boolean)
        If flag > 8 Then flag += add
        flag = 2 ^ flag
        If [on] Then
            Flags = Flags Or CInt(flag)
        Else
            Flags = Flags And Not CInt(flag)
        End If
    End Sub
#End Region

#Region "Composite Properties"
    Public Function HasExtraByte() As Boolean
        Return GetFlag(DatItem.Flag.IsStackable) _
        OrElse GetFlag(DatItem.Flag.IsSplash) _
        OrElse GetFlag(DatItem.Flag.IsFluidContainer)
    End Function
#End Region
End Class
