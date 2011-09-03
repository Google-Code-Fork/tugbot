Public Class Addresses
#Region "Pipe"
    Public PrintName As Integer
    Public PrintFPS As Integer
    Public ShowFPS As Integer
    Public PrintTextFunc As Integer
    Public NopFPS As Integer

    Public AddContextMenuFunc As Integer
    Public OnClickContextMenu As Integer
    Public SetOutfitContextMenu As Integer
    Public PartyActionContextMenu As Integer
    Public CopyNameContextMenu As Integer
    Public TradeContextMenu As Integer
    Public OnClickContextMenuVF As Integer
    Public VipListContextMenu As Integer

    Public AttackContextMenuFunc As Integer

    Public OnClickVipMenu As Integer
    Public OnClickVipMenuVF As Integer

    Public RenderItem As Integer
    Public DrawGui As Integer

    Public SendMessages As Integer

    Public Send As Integer
    Public Peek As Integer
    Public PeekFrom As Integer
    Public ConsoleContextMenu As Integer
    Public OnClickConsoleMenu As Integer
    Public OnClickConsoleMenuVF As Integer

    Public ClickPlayerId As Integer
    Public ClickItemId As Integer
    Public ClickPlayerName As Integer

    Public MoveObject As Integer
    Public UseObjectWithCreature As Integer
    Public UseObjectWithGround As Integer
    Public UseObjectFromGround As Integer

    Public VipNameHook As Integer
    Public VipNameFunc As Integer

    Public ParserFunc As Integer
    Public GetNextPacketFunc As Integer
    Public RecvStreamPtr As Integer

    Public SpinNorth As Integer
    Public SpinSouth As Integer
    Public SpinEast As Integer
    Public SpinWest As Integer

    Public Attack As Integer

    Public FollowFunc As Integer

    Public StopActions As Integer

    Public FollowState As Integer

    Public Logout As Integer

    Public Buy As Integer
    Public Sell As Integer

    Public CreatePacket As Integer
    Public PacketAddByte As Integer
    Public PacketSend As Integer
#End Region

    Public Player As New AdrPlayer
    Public Battlelist As New AdrBattle
    Public Login As New AdrLogin
    Public Container As New AdrContainer
    Public Client As New AdrClient

    Public oldDat As Boolean




    Public Sub New(ByVal [Version] As String)
        If [Version] = "8.57" OrElse [Version] = "8.55" OrElse [Version] = "8.54" OrElse [Version] = "8.53" OrElse [Version] = "8.52" OrElse [Version] = "8.50" Then
            oldDat = True
        Else
            If [Version] <> "8.60" AndAlso [Version] <> "8.61" AndAlso [Version] <> "8.62" Then
                Player.extraOffset = 4
                Battlelist.Characters = 1300
            End If

            oldDat = False
        End If


        Player.Experience = BaseExp([Version])
        Player.Z = BaseZ([Version])
        Player.HeadSlot = BaseHead([Version])
        Player.Target = BaseTarget([Version])

        Battlelist.Start = BaseBattle([Version])
        Battlelist.[Step] = BaseBattleStep([Version])

        Login.CharList = BaseCharList([Version])
        Login.Amount = BaseCharCount([Version])
        Login.Selected = BaseCharSelected([Version])

        Container.Start = BaseContainer([Version])

        Client.DatPointer = BaseDat([Version])

        Client.Map = BaseMap([Version])

        Client.Connection = BaseConnection([Version])

        Client.NameSpy1 = BaseName1([Version])
        Client.NameSpy2 = BaseName2([Version])

        Client.XTea = BaseXtea([Version])

        Client.LevelSpy1 = BaseLevel1([Version])
        Client.LevelSpy2 = BaseLevel2([Version])
        Client.LevelSpy3 = BaseLevel3([Version])
        Client.LevelSpyPtr = BaseLevelPtr([Version])

        If BaseLevelAdd([Version]) > 0 Then
            Client.LevelSpyAdd = BaseLevelAdd([Version])
        Else
            Client.LevelSpyAdd = &H2A88
        End If

        Client.StatusText = BaseStatusBar([Version])
        If [Version] = "8.60" OrElse [Version] = "8.57" OrElse [Version] = "8.55" OrElse [Version] = "8.54" OrElse [Version] = "8.53" OrElse [Version] = "8.52" OrElse [Version] = "8.50" Then
            Client.StatusTime = BaseStatusBar([Version]) - 4
        Else
            Client.StatusTime = BaseStatusBar([Version]) - 8
        End If

        Client.LightNop = BaseLightNop([Version])
        Client.LightAmount = BaseLightAmount([Version])

        Client.ScreenRect = BaseScreenRect([Version])
        Client.ScreenBar = BaseScreenBar([Version])

        Client.FrameratePoint = BaseFramRate([Version])

        Client.DialogBegin = BaseDialog([Version])

        Client.Starttime = BaseStart([Version])

        Client.FollowMode = BaseFollowState([Version])

        Me.PrintName = AddressConstants.PrintName([Version])
        Me.PrintFPS = AddressConstants.PrintFPS([Version])
        Me.ShowFPS = AddressConstants.ShowFPS([Version])
        Me.PrintTextFunc = AddressConstants.PrintTextFunc([Version])
        Me.NopFPS = AddressConstants.NopFPS([Version])

        Me.AddContextMenuFunc = AddressConstants.AddContextMenuFunc([Version])
        Me.OnClickContextMenu = AddressConstants.OnClickContextMenu([Version])
        Me.SetOutfitContextMenu = AddressConstants.SetOutfitContextMenu([Version])
        Me.PartyActionContextMenu = AddressConstants.PartyActionContextMenu([Version])
        Me.CopyNameContextMenu = AddressConstants.CopyNameContextMenu([Version])
        Me.TradeContextMenu = AddressConstants.TradeContextMenu([Version])
        Me.OnClickContextMenuVF = AddressConstants.OnClickContextMenuVF([Version])

        Me.VipListContextMenu = AddressConstants.VipListContextMenu([Version])

        Me.OnClickVipMenu = AddressConstants.OnClickVipMenu([Version])
        Me.OnClickVipMenuVF = AddressConstants.OnClickVipMenuVF([Version])

        Me.RenderItem = BaseRender([Version])
        Me.DrawGui = BaseGui([Version])
        Me.SendMessages = AddressConstants.SendMessage([Version])

        Me.Send = BaseSend([Version])
        Me.Peek = BasePeek([Version])
        Me.PeekFrom = PeekCallFrom([Version])
        Me.ConsoleContextMenu = AddressConstants.ConsoleContextMenu([Version])
        Me.OnClickConsoleMenu = AddressConstants.OnClickConsoleMenu([Version])
        Me.OnClickConsoleMenuVF = AddressConstants.OnClickConsoleMenuVF([Version])

        Me.MoveObject = AddressConstants.MoveObject([Version])

        Me.ClickItemId = AddressConstants.ClickItemId([Version])
        Me.ClickPlayerId = AddressConstants.ClickPlayerId([Version])
        Me.ClickPlayerName = AddressConstants.ClickPlayerName([Version])

        Me.UseObjectWithCreature = AddressConstants.UseObjectWithCreature([Version])
        Me.UseObjectWithGround = AddressConstants.UseObjectWithGround([Version])
        Me.UseObjectFromGround = AddressConstants.UseObjectFromGround([Version])

        Me.VipNameHook = AddressConstants.VipNameHook([Version])
        Me.VipNameFunc = AddressConstants.VipNameFunc([Version])


        Me.ParserFunc = AddressConstants.BaseParserFunc([Version])
        Me.GetNextPacketFunc = AddressConstants.BaseGetNextPacketFunc([Version])
        Me.RecvStreamPtr = AddressConstants.BaseRecvStreamPtr([Version])

        Me.SpinNorth = AddressConstants.BaseSpinNorth([Version])
        Me.SpinSouth = AddressConstants.BaseSpinSouth([Version])
        Me.SpinEast = AddressConstants.BaseSpinEast([Version])
        Me.SpinWest = AddressConstants.BaseSpinWest([Version])

        Me.Attack = AddressConstants.BaseAttack([Version])
        Me.FollowFunc = AddressConstants.BaseFollowFunc([Version])
        Me.FollowState = AddressConstants.BaseFollowState([Version])
        Me.StopActions = AddressConstants.BaseStopActions([Version])
        Me.Logout = AddressConstants.BaseLoggout([Version])

        Me.AttackContextMenuFunc = AddressConstants.AttackContextMenu([Version])

        Me.Buy = AddressConstants.BaseBuy([Version])
        Me.Sell = AddressConstants.BaseSell([Version])

        Me.CreatePacket = AddressConstants.BaseCreatePacket([Version])
        Me.PacketAddByte = AddressConstants.BaseAddBytePacket([Version])
        Me.PacketSend = AddressConstants.BaseSendPacket([Version])
        Player.Initialize()
        Battlelist.Initialize()
        Container.Initialize()
    End Sub

    Public Function DatItem() As Structures.DatItems
        DatItem.Width = 0
        DatItem.Height = 1
        DatItem.Unknown1 = 2
        DatItem.Layers = 3
        DatItem.PatternX = 4
        DatItem.PatternY = 5
        DatItem.PatternDepth = 6
        DatItem.Phase = 7
        DatItem.Sprites = 8
        DatItem.Flags = 9
        DatItem.WalkSpeed = 10
        DatItem.TextLimit = 11 ' If it is readable/writable
        DatItem.LightRadius = 12
        DatItem.LightColor = 13
        DatItem.ShiftX = 14
        DatItem.ShiftY = 15
        DatItem.WalkHeight = 16
        DatItem.Automap = 17 ' Minimap color
        DatItem.LensHelp = 18 'Help
        DatItem.Help.IsLadder = &H44C
        DatItem.Help.IsSewer = &H44D
        DatItem.Help.IsDoor = &H450
        DatItem.Help.IsDoorWithLock = &H451
        DatItem.Help.IsRopeSpot = &H44E
        DatItem.Help.IsSwitch = &H44F
        DatItem.Help.IsStairs = &H452
        DatItem.Help.IsMailbox = &H453
        DatItem.Help.IsDepot = &H454
        DatItem.Help.IsTrash = &H455
        DatItem.Help.IsHole = &H456
        DatItem.Help.HasSpecialDescription = &H457
        DatItem.Help.IsReadOnly = &H458
        'Flags
    End Function
End Class
