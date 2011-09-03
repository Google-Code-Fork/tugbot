Imports System.Runtime.InteropServices
Imports System.ComponentModel
Public Class TibiaHook
    Implements IDisposable

    Public Event HookInjected()
    Public Event ContextMenuClicked(ByVal EventID As Integer)
    Public Event CreatureSpeak(ByVal name As String, ByVal level As Integer, ByVal text As String, ByVal type As Byte, ByVal Channel As Integer)
    Public Event ProjectileShot(ByVal FromPos As Location, ByVal ToPos As Location, ByVal Type As ProjectileType)
    Public Event HookInjectFailed()
    Public Event UnHooked()

    'Private WithEvents listenSocket As Winsock
    Private WithEvents socket As New Winsock
    Dim WithEvents P As Pipes
    Dim HwnD As IntPtr

    Public Sub New(ByVal HwNd As IntPtr)
        Dim PipePid As IntPtr
        Me.HwnD = HwNd
        GetWindowThreadProcessId(HwNd, PipePid)

        P = New Pipes("TUGBot" & PipePid.ToString)

        While P Is Nothing
            Threading.Thread.Sleep(1)
        End While

        'Inject(PipePid, Application.StartupPath & "\TUGHook.dll")

        'InjectDLLWithCave(PipePid, Application.StartupPath & "\TUGHook.dll", &H56E2D9)

        If Not Inject(PipePid, Application.StartupPath & "\TUGHook.dll") Then
            'MsgBox("TUGBot failed to inject the DLL into Tibias process! Please try again." & vbNewLine & "If your running on Vista, make sure both TUGBot and Tibia are run as admin." & vbNewLine & "If this problem persists, please contact the TUGBot team.")
            'End
            'Application.Exit()
        End If

        'listenSocket = New Winsock(1234)
        'listenSocket.Listen()
        'messageSend(SetConstant(&H44, 1234)) 'Packet send

        'Threading.Thread.Sleep(500)
        'socket.Connect("127.0.0.1", 1234)
    End Sub

    Public Sub Send(ByVal data As Byte())
        'Static lastsend As Integer = GetTickCount()
        'While GetTickCount() - lastsend < 20
        '    Threading.Thread.Sleep(1)
        'End While
        'lastsend = GetTickCount()
        P.Send(data)
    End Sub

    Private Sub P_Connected() Handles P.Connected
        Send(SetConstant(&H1, TClient.Addresses.PrintName)) 'PrintName
        Send(SetConstant(&H2, TClient.Addresses.PrintFPS)) 'PrintFPS
        Send(SetConstant(&H3, TClient.Addresses.ShowFPS)) 'Show FPS
        Send(SetConstant(&H4, TClient.Addresses.PrintTextFunc)) 'PrintTextFunc
        Send(SetConstant(&H5, TClient.Addresses.NopFPS)) 'NopFPS
        Send(SetConstant(&H6, TClient.Addresses.AddContextMenuFunc)) 'AddContextMenuFunc
        Send(SetConstant(&H7, TClient.Addresses.OnClickContextMenu)) 'OnClickContextMenu
        Send(SetConstant(&H8, TClient.Addresses.SetOutfitContextMenu)) 'SetOutfitContextMenu
        Send(SetConstant(&H9, TClient.Addresses.PartyActionContextMenu)) 'PartyActionContextMenu
        Send(SetConstant(&HA, TClient.Addresses.CopyNameContextMenu)) 'CopyNameContextMenu
        Send(SetConstant(&HC, TClient.Addresses.TradeContextMenu)) 'TradeContextMenu
        Send(SetConstant(&HB, TClient.Addresses.OnClickContextMenuVF)) 'OnClickContextMenuVF
        Send(SetConstant(&HD, TClient.Addresses.RenderItem)) 'RenderItem

        Send(SetConstant(&HE, TClient.Addresses.DrawGui)) 'DrawGUI

        Send(SetConstant(&HF, TClient.Addresses.VipListContextMenu)) 'VipContextMenu

        Send(SetConstant(&H10, TClient.Addresses.SendMessages)) 'Self Speak

        Send(SetConstant(&H11, TClient.Addresses.OnClickVipMenuVF)) 'OnClickVipMenuVF
        Send(SetConstant(&H12, TClient.Addresses.OnClickVipMenu)) 'OnClickVipMenu
        Send(SetConstant(&H13, TClient.Addresses.ConsoleContextMenu)) 'Console Context menu
        Send(SetConstant(&H14, TClient.Addresses.OnClickConsoleMenu)) 'Console Context menu on click
        Send(SetConstant(&H15, TClient.Addresses.OnClickConsoleMenuVF)) 'Console Context menu on click VF

        Send(SetConstant(&H16, TClient.Addresses.Peek)) 'Peek Message


        Send(SetConstant(&H17, TClient.Addresses.UseObjectFromGround)) '&H406280 'Use from ground

        Send(SetConstant(&H18, TClient.Addresses.MoveObject)) 'Move Object

        Send(SetConstant(&H21, TClient.Addresses.UseObjectWithCreature)) 'Use Object with creature

        Send(SetConstant(&H22, TClient.Addresses.UseObjectWithGround)) '&H406470 'Use Object with ground
        Send(SetConstant(&H23, TClient.Addresses.VipNameFunc)) '&H54EEA0 'Get VIP Name Function
        Send(SetConstant(&H24, TClient.Addresses.VipNameHook)) '&H4528AF 'Get VIP hook

        Send(SetConstant(&H25, TClient.Addresses.Client.Connection)) 'Connection

        Send(SetConstant(&H26, TClient.Addresses.ParserFunc)) 'FUNC_PARSER
        Send(SetConstant(&H27, TClient.Addresses.GetNextPacketFunc)) 'CALL_GET_NEXT_PACKET
        Send(SetConstant(&H28, TClient.Addresses.RecvStreamPtr)) ' ADDR_RECV_STREAM
        Send(SetConstant(&H29, TClient.Addresses.SpinNorth)) ' Spin north
        Send(SetConstant(&H30, TClient.Addresses.SpinSouth)) ' * south
        Send(SetConstant(&H31, TClient.Addresses.SpinEast)) ' * east
        Send(SetConstant(&H32, TClient.Addresses.SpinWest)) ' * west

        Send(SetConstant(&H33, TClient.Addresses.Attack)) 'attack

        Send(SetConstant(&H34, TClient.Addresses.FollowFunc)) 'Follwo Func

        Send(SetConstant(&H35, TClient.Addresses.StopActions)) 'Stop func

        Send(SetConstant(&H36, TClient.Addresses.Logout)) 'Logout func
        Send(SetConstant(&H37, TClient.Addresses.Battlelist.Step)) 'Logout func

        Send(SetConstant(&H38, TClient.Addresses.AttackContextMenuFunc)) 'attack menu func

        Send(SetConstant(&H39, TClient.Addresses.Buy)) 'Buy
        Send(SetConstant(&H40, TClient.Addresses.Sell)) 'Sell
        Send(SetConstant(&H41, TClient.Addresses.CreatePacket)) 'Packet create header
        Send(SetConstant(&H42, TClient.Addresses.PacketAddByte)) 'Packet add byte
        Send(SetConstant(&H43, TClient.Addresses.PacketSend)) 'Packet send

        Send(InjectDisplay(True))

        'pz display BG
        AddBackgroundRect(5000, 5000, 0, 0, 50)
        'status panel BG
        AddBackgroundRect(5000, 5000, 0, 0, 75)
        'lagbar
        AddGUI(127, 5000, 5000, 100, 15, 1)
        AddGUI(128, 5000, 5000, 100, 15, 2)

        'Separators
        AddGUI(27, 5000, 5000, 100, 15, 3)
        AddGUI(27, 5000, 5000, 100, 15, 4)
        AddGUI(27, 5000, 5000, 100, 15, 5)
        AddGUI(27, 5000, 5000, 100, 15, 6)

        AddContextMenu(Client.ContextEventType.AddAllyVip, "Add As Ally", MType.VipCopyName, True)
        AddContextMenu(Client.ContextEventType.AddEnemyVip, "Add As Enemy", MType.VipCopyName, False)

        AddContextMenu(Client.ContextEventType.AddAlly, "Add As Ally", MType.ScreenParty, True)
        AddContextMenu(Client.ContextEventType.AddEnemy, "Add As Enemy", MType.ScreenParty, False)

        AddContextMenu(Client.ContextEventType.ShowProfile, "Show Profile", MType.ScreenParty, True)

        AddContextMenu(Client.ContextEventType.ItemId, "Show Item Number", MType.ItemTrade, True)
        AddContextMenu(Client.ContextEventType.Exiva, "Exiva", MType.VipCopyName, True)

        AddContextMenu(Client.ContextEventType.TrainingPartner, "Add As Training Partner", MType.Attack, True)

        RaiseEvent HookInjected()
    End Sub

    Private Sub P_Disconnected() Handles P.Disconnected
        RaiseEvent UnHooked()
    End Sub

    Private Sub P_ListenError() Handles P.ListenError
        RaiseEvent HookInjectFailed()
    End Sub

    Public Sub UninjectHooks()
        Send(InjectDisplay(False))
    End Sub

    Public Sub InjectCheck()
        Dim pack As New PacketBuilder(PipePacketType.InjectCheck)
        Me.Send(pack.GetPacket)
    End Sub

    Public Sub SendPacketToServer(ByVal packet As Byte())
        Dim pack As New PacketBuilder(PipePacketType.SendPacketToServer)
        pack.AddShort(packet.Length)
        pack.AddBytes(packet)
        Me.Send(pack.GetPacket)
    End Sub


#Region "Packet utils"
    Public Function SetConstant(ByVal Type As Byte, ByVal value As UInteger) As Byte()
        Dim pack As New PacketBuilder(PipePacketType.SetConstant)
        pack.AddByte(Type)
        pack.AddLong(value)
        SetConstant = pack.GetPacket
    End Function
    Private Function InjectDisplay(ByVal y As Boolean) As Byte()
        Dim pack As New PacketBuilder(PipePacketType.InjectDisplay)
        If y Then pack.AddByte(1) Else pack.AddByte(0)
        InjectDisplay = pack.GetPacket
    End Function
#End Region

#Region "Add"
    Public Sub AddItem(ByVal id As Integer, ByVal x As Integer, ByVal y As Integer, ByVal size As Integer, ByVal text As String, ByVal color As Color)
        Dim pack As New PacketBuilder(&HC)
        pack.AddInt(0)

        pack.AddInt(size)
        pack.AddInt(1)

        pack.AddInt(x)
        pack.AddInt(y)
        pack.AddInt(color.R)
        pack.AddInt(color.G)
        pack.AddInt(color.B)
        pack.AddString(text)

        pack.AddInt(1) 'Number of items
        pack.AddInt(id) 'Add the overlay
        pack.AddShort(0)
        pack.AddShort(0)
        pack.AddShort(1) 'count

        Me.Send(pack.GetPacket)
    End Sub

    Public Sub AddItems(ByVal Bs As List(Of ButtonStruct), ByVal size As Short, ByVal clear As Boolean)
        Dim pack As New PacketBuilder(&HC)

        If clear Then 'Determines wether or not to clear the list
            pack.AddInt(1)
        Else
            pack.AddInt(0)
        End If

        pack.AddInt(size) 'Size of buttons
        pack.AddInt(Bs.Count) 'Count of buttons were adding

        For Each B As ButtonStruct In Bs
            pack.AddInt(B.LocationX)
            pack.AddInt(B.LocationY)
            pack.AddInt(B.TextColor.R)
            pack.AddInt(B.TextColor.G)
            pack.AddInt(B.TextColor.B)
            pack.AddString(FormatDisplayString(B.Text))

            'Normally, here is where we would loop through the list of item IDs
            'This is just a test
            pack.AddInt(B.OverlayItems.Count + 1) 'Number of items
            pack.AddInt(B.UnderlayID) 'Add the overlay
            pack.AddShort(0)
            pack.AddShort(0)
            pack.AddShort(B.Count) 'count

            'Now that we have the overlay, add the other items
            For Each I As ItemDisplay In B.OverlayItems
                pack.AddInt(I.DisplayID)
                pack.AddShort(I.PosOffsetX)
                pack.AddShort(I.PosOffsetY)
                pack.AddShort(I.Count)
            Next
        Next

        Me.Send(pack.GetPacket)
        'Bs.Reverse()
    End Sub

    Public Sub AddGUI(ByVal id As Integer, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, Optional ByVal Index As Integer = 1)
        Dim pack As New PacketBuilder(PipePacketType.AddGui)
        pack.AddInt(id)
        pack.AddInt(Index)
        pack.AddInt(x)
        pack.AddInt(y)
        pack.AddInt(w)
        pack.AddInt(h)

        Me.Send(pack.GetPacket)
    End Sub

    Public Sub AddText(ByVal Clear As Boolean, ByVal clearname As String, ByVal name As String, ByVal text As String, ByVal x As Integer, ByVal y As Integer, ByVal Color As Color, Optional ByVal Border As Boolean = True, Optional ByVal Center As Boolean = False)
        Dim pack As New PacketBuilder(PipePacketType.DisplayText)

        If Clear = True Then pack.AddByte(1) Else pack.AddByte(0)
        pack.AddString(clearname)

        pack.AddInt(1)
        pack.AddString(name)
        pack.AddInt(x)
        pack.AddInt(y)
        pack.AddInt(Color.R)
        pack.AddInt(Color.G)
        pack.AddInt(Color.B)
        If Border Then
            pack.AddInt(2)
        Else
            pack.AddInt(1)
        End If
        If Not Center Then
            pack.AddInt(0)
        Else
            pack.AddInt(1)
        End If
        pack.AddString(text)

        Me.Send(pack.GetPacket)
    End Sub

    Public Sub AddText(ByVal Clear As Boolean, ByVal clearname As String, ByVal L As List(Of DisplayText), Optional ByVal Right As Boolean = False)
        Dim pack As New PacketBuilder(PipePacketType.DisplayText)

        If Clear = True Then pack.AddByte(1) Else pack.AddByte(0)
        pack.AddString(clearname)

        pack.AddInt(L.Count)
        For Each I As DisplayText In L
            pack.AddString(I.Name)
            pack.AddInt(I.X)
            pack.AddInt(I.Y)
            pack.AddInt(I.color.R)
            pack.AddInt(I.color.G)
            pack.AddInt(I.color.B)
            pack.AddInt(2)
            If Not Right Then
                pack.AddInt(I.Align)
            Else
                pack.AddInt(2)
            End If
            pack.AddString(I.text)
        Next

        Me.Send(pack.GetPacket)
    End Sub



    Public Sub AddContextMenu(ByVal EventId As Integer, ByVal MenuText As String, ByVal Type As MType, ByVal HasSeparator As Boolean)
        Dim p As New PacketBuilder(PipePacketType.AddMenu)
        p.AddLong(EventId)
        p.AddString(MenuText)
        p.AddByte(CByte(Type))
        p.AddByte(Convert.ToByte(HasSeparator))

        Me.Send(p.GetPacket())
    End Sub

    Public Sub AddCreatureText(ByVal creatureID As Integer, ByVal creatureName As String, ByVal x As Integer, ByVal y As Integer, ByVal color As Color, ByVal font As Integer, ByVal text As String)
        Dim p As New PacketBuilder(PipePacketType.CreatureText)
        p.AddLong(creatureID)
        p.AddString(creatureName)
        p.AddShort(x)
        p.AddShort(y)
        p.AddInt(color.R)
        p.AddInt(color.G)
        p.AddInt(color.B)
        p.AddInt(CInt(font))
        p.AddString(text)

        Me.Send(p.GetPacket)
    End Sub

    Public Sub AddCreatureDescription(ByVal creatureID As Integer, ByVal creatureName As String, ByVal color As Color, ByVal font As Integer, ByVal text As String)
        Dim p As New PacketBuilder(PipePacketType.CreatureText)
        p.AddLong(creatureID)
        p.AddString(creatureName)
        p.AddShort(666)
        p.AddShort(666)
        p.AddInt(color.R)
        p.AddInt(color.G)
        p.AddInt(color.B)
        p.AddInt(CInt(font))
        p.AddString(text)

        Me.Send(p.GetPacket)
    End Sub

    Public Sub AddBackgroundRect(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, Optional ByVal startindex As Integer = 0)
        AddGUI(60, x, y, w, h, startindex) 'middle
        startindex += 1
        AddGUI(58, x, y - 5, w, 5, startindex) 'top
        startindex += 1
        AddGUI(59, x, y + h, w, 5, startindex) 'bottom
        startindex += 1
        AddGUI(56, x - 5, y, 5, h, startindex) 'left
        startindex += 1
        AddGUI(57, x + w, y, 5, h, startindex) 'Right
        startindex += 1
        AddGUI(52, x - 5, y - 5, 5, 5, startindex) 'TopLeft
        startindex += 1
        AddGUI(53, x + w, y - 5, 5, 5, startindex) 'TopRight
        startindex += 1
        AddGUI(54, x - 5, y + h, 5, 5, startindex) 'Bottom Left
        startindex += 1
        AddGUI(55, x + w, y + h, 5, 5, startindex) 'Bottom Right
    End Sub

    Public Sub UpdateBackgroundRect(ByVal startindex As Integer, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer)
        UpdateGUI(startindex, 60, x, y, w, h) 'middle
        startindex += 1
        UpdateGUI(startindex, 58, x, y - 5, w, 5) 'top
        startindex += 1
        UpdateGUI(startindex, 59, x, y + h, w, 5) 'bottom
        startindex += 1
        UpdateGUI(startindex, 56, x - 5, y, 5, h) 'left
        startindex += 1
        UpdateGUI(startindex, 57, x + w, y, 5, h) 'Right
        startindex += 1
        UpdateGUI(startindex, 52, x - 5, y - 5, 5, 5) 'TopLeft
        startindex += 1
        UpdateGUI(startindex, 53, x + w, y - 5, 5, 5) 'TopRight
        startindex += 1
        UpdateGUI(startindex, 54, x - 5, y + h, 5, 5) 'Bottom Left
        startindex += 1
        UpdateGUI(startindex, 55, x + w, y + h, 5, 5) 'Bottom Right
    End Sub
#End Region

#Region "Clear"
    Public Sub ClearItems()
        Dim pack As New PacketBuilder(PipePacketType.ClearItems)
        Me.Send(pack.GetPacket)
    End Sub

    Public Sub ClearGUI()
        Dim pack As New PacketBuilder(PipePacketType.ClearGui)
        Me.Send(pack.GetPacket)
    End Sub

    Public Sub ClearText()
        Dim pack As New PacketBuilder(PipePacketType.RemoveAllText)
        Me.Send(pack.GetPacket)
    End Sub

    Public Sub ClearCreatureTextAndDescription()
        Dim pack As New PacketBuilder(PipePacketType.ClearCreatureText)
        Me.Send(pack.GetPacket)
    End Sub

    Public Sub ClearContextMenus()
        Dim pack As New PacketBuilder(PipePacketType.ClearContextMenus)
        Me.Send(pack.GetPacket)
    End Sub
#End Region

#Region "Update"
    Public Sub UpdateGUI(ByVal index As Integer, ByVal id As Integer, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer)
        Dim pack As New PacketBuilder(PipePacketType.UpdateGui)
        pack.AddInt(id)
        pack.AddInt(index)
        pack.AddInt(x)
        pack.AddInt(y)
        pack.AddInt(w)
        pack.AddInt(h)

        Me.Send(pack.GetPacket)
    End Sub

    Public Sub UpdateItem(ByVal id As Integer, ByVal x As Integer, ByVal y As Integer, ByVal size As Integer, ByVal text As String, ByVal color As Color)
        Dim pack As New PacketBuilder(PipePacketType.UpdateItem)
        pack.AddInt(id)
        pack.AddInt(1)
        pack.AddInt(x)
        pack.AddInt(y)
        pack.AddInt(size)
        pack.AddInt(color.R)
        pack.AddInt(color.G)
        pack.AddInt(color.B)
        pack.AddString(text)
        Me.Send(pack.GetPacket)
    End Sub

    Public Sub UpdateCreatureText(ByVal creatureId As Integer, ByVal creatureName As String, ByVal x As Integer, ByVal y As Integer, ByVal text As String)
        Dim p As New PacketBuilder(PipePacketType.UpdateCreatureText)

        p.AddLong(creatureId)
        p.AddString(creatureName)
        p.AddShort(x)
        p.AddShort(y)
        p.AddString(text)

        Me.Send(p.GetPacket)
    End Sub

    Public Sub UpdateCreatureDescription(ByVal creatureId As Integer, ByVal creatureName As String, ByVal text As String)
        Dim p As New PacketBuilder(PipePacketType.UpdateCreatureText)

        p.AddLong(creatureId)
        p.AddString(creatureName)
        p.AddShort(666)
        p.AddShort(666)
        p.AddString(text)

        Me.Send(p.GetPacket)
    End Sub
#End Region

#Region "Remove"
    Public Sub RemoveCreatureText(ByVal creatureId As Integer, ByVal creatureName As String)
        Dim p As New PacketBuilder(PipePacketType.RemoveCreatureText)

        p.AddLong(creatureId)
        p.AddString(creatureName)

        Me.Send(p.GetPacket)
    End Sub

    Public Sub RemoveCreatureDescription(ByVal creatureId As Integer, ByVal creatureName As String)
        Dim p As New PacketBuilder(PipePacketType.RemoveCreatureText)

        p.AddLong(creatureId)
        p.AddString(creatureName)

        Me.Send(p.GetPacket)
    End Sub

    Public Sub RemoveContextMenu(ByVal EventId As Integer, ByVal MenuText As String, ByVal Type As MType, ByVal HasSeparator As Boolean)
        Dim p As New PacketBuilder(PipePacketType.RemoveMenu)
        p.AddLong(EventId)
        p.AddString(MenuText)
        p.AddByte(CByte(Type))
        p.AddByte(Convert.ToByte(HasSeparator))
        Me.Send(p.GetPacket)
    End Sub

    Public Sub RemoveText(ByVal TextName As String)
        Dim p As New PacketBuilder(PipePacketType.RemoveText)
        p.AddString(TextName)

        Me.Send(p.GetPacket())
    End Sub
#End Region

#Region "Other drawing shit"
    Public Sub DrawSlidingMeshRect(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal slideadd As Integer)
        Dim X1 As Integer = x
        Dim Ca As Integer = slideadd
        AddGUI(60, X1, y, slideadd, h, 16) 'middle
        Threading.Thread.Sleep(5)
        AddGUI(58, X1, y - 5, slideadd, 5, 17) 'top
        Threading.Thread.Sleep(5)
        AddGUI(59, X1, y + h, slideadd, 5, 18) 'bottom
        Threading.Thread.Sleep(5)


        For i = 0 To w \ 2 \ slideadd
            UpdateGUI(16, 60, X1, y, Ca, h) 'middle
            Threading.Thread.Sleep(2)
            UpdateGUI(17, 58, X1, y - 5, Ca, 5) 'top
            Threading.Thread.Sleep(2)
            UpdateGUI(18, 59, X1, y + h, Ca, 5) 'bottom

            X1 -= slideadd
            Ca += slideadd * 2
            Threading.Thread.Sleep(17)
        Next

        ClearGUI()
        AddBackgroundRect(x - w \ 2, y, w, h)
    End Sub

    Public Sub DrawSlidingItemMenu(ByVal x As Integer, ByVal y As Integer, ByVal Width As Integer, ByVal Size As Integer, ByVal slideadd As Integer, ByVal IList As List(Of DisplayItem))
        Dim T As Integer = 0
        Dim X1 As Integer = x - Size \ 2 + Size
        Dim X2 As Integer = x + Size \ 2 - Size

        For Each i As DisplayItem In IList
            AddItem(i.id, x, y, Size, i.text, i.color)
            Threading.Thread.Sleep(5)
        Next

        For b = 0 To Width \ 2 \ slideadd
            T = 2
            For Each i As DisplayItem In IList
                If T = 2 Then T = 0 : Continue For
                If T = 0 Then
                    UpdateItem(i.id, X1, y, Size, i.text, i.color)
                    T = 1
                Else
                    UpdateItem(i.id, X2, y, Size, i.text, i.color)
                    T = 0
                End If
                Threading.Thread.Sleep(1)
            Next
            X1 -= slideadd
            X2 += slideadd
            Threading.Thread.Sleep(20)
        Next
    End Sub
#End Region

#Region "Send~"
    Public Sub Spin(ByVal dir As Direction)
        Dim p As New PacketBuilder(PipePacketType.Spin)
        p.AddByte(dir)
        Me.Send(p.GetPacket)
    End Sub

    Public Sub Attack(ByVal CharID As Int32)
        Dim p As New PacketBuilder(PipePacketType.Attack)
        p.AddLong(CharID)
        Me.Send(p.GetPacket)
    End Sub

    Public Sub Speak(ByVal text As String, ByVal type As SelfSpeechType)
        Dim p As New PacketBuilder(PipePacketType.SelfSpeak)
        p.AddInt(CShort(type))
        p.AddString(text)

        Me.Send(p.GetPacket)
    End Sub

    Public Sub MoveItem(ByVal id As Integer, ByVal count As Integer, ByVal LocFrom As ItemLocation, ByVal LocTo As ItemLocation)
        Dim p As New PacketBuilder(PipePacketType.MoveItem)
        Dim Lf As Location = LocFrom.ToLocation
        Dim Lt As Location = LocTo.ToLocation
        p.AddInt(Lf.x)
        p.AddInt(Lf.y)
        p.AddInt(Lf.z)
        p.AddInt(id)
        p.AddInt(LocFrom.stackOrder)
        p.AddInt(Lt.x)
        p.AddInt(Lt.y)
        p.AddInt(Lt.z)
        If count = 0 Then count = 1
        p.AddInt(count)
        Me.Send(p.GetPacket)
    End Sub

    Public Sub OpenMainBackpack()
        Dim p As New PacketBuilder(PipePacketType.UseType2)
        If TClient.Self.SlotID(Slots.Backpack) > 99 Then
            p.AddInt(&HFFFF)
            p.AddInt(Slots.Backpack)
            p.AddInt(0)
            p.AddInt(TClient.Self.SlotID(Slots.Backpack))
            p.AddByte(0)
            p.AddLong(TClient.Containers.GetFreeSlot - 1)
            Me.Send(p.GetPacket)
        End If
    End Sub

    Public Sub UseItemWithCreature(ByVal itemid As Short, ByVal creatureid As Integer)
        Dim p As New PacketBuilder(PipePacketType.UseType1)
        p.AddInt(65535)
        p.AddInt(0)
        p.AddInt(0)
        p.AddInt(itemid)
        p.AddByte(0)
        p.AddLong(creatureid)

        Me.Send(p.GetPacket)
    End Sub

    Public Sub UseItemFromInventory(ByVal Cont As Integer, ByVal Spot As Byte, ByVal itemid As Short)
        Dim p As New PacketBuilder(PipePacketType.UseType2)
        p.AddInt(&HFFFF)
        p.AddInt(Cont + &H40)
        p.AddInt(Spot)
        p.AddInt(itemid)
        p.AddByte(Spot)
        p.AddLong(1)

        Me.Send(p.GetPacket)
    End Sub

    Public Sub UseItemFromInventory(ByVal Cont As Integer, ByVal Spot As Byte, ByVal itemid As Short, ByVal count As Byte)
        Dim p As New PacketBuilder(PipePacketType.UseType2)
        p.AddInt(&HFFFF)
        p.AddInt(Cont + &H40)
        p.AddInt(Spot)
        p.AddInt(itemid)
        p.AddByte(Spot)
        p.AddLong(count)

        Me.Send(p.GetPacket)
    End Sub

    Public Sub UseItem(ByVal itemid As Short)
        Dim p As New PacketBuilder(PipePacketType.UseType2)
        p.AddInt(&HFFFF)
        p.AddInt(0)
        p.AddInt(0)
        p.AddInt(itemid)
        p.AddByte(0)
        p.AddLong(0)
        Me.Send(p.GetPacket)
    End Sub

    Public Sub UseItemFromGround(ByVal x As Integer, ByVal y As Integer, ByVal z As Byte, ByVal itemid As Short, ByVal stack As Byte, ByVal count As Short)
        Dim p As New PacketBuilder(PipePacketType.UseType2)
        p.AddInt(x)
        p.AddInt(y)
        p.AddInt(z)
        p.AddInt(itemid)
        p.AddByte(stack)
        p.AddInt(count)
        Me.Send(p.GetPacket)
    End Sub

    Public Sub UseItemWithGround(ByVal GroundX As Integer, ByVal GroundY As Integer, ByVal GroundZ As Byte, ByVal UseID As Short, ByVal UseWithID As Integer, ByVal GroundStack As Byte)
        Dim p As New PacketBuilder(PipePacketType.UseType3)
        p.AddInt(65535)
        p.AddInt(0)
        p.AddInt(0)
        p.AddInt(UseID)
        p.AddByte(0)
        p.AddInt(GroundX)
        p.AddInt(GroundY)
        p.AddInt(GroundZ)
        p.AddInt(UseWithID)
        p.AddByte(GroundStack)
        p.AddInt(TClient.Self.X)
        p.AddInt(TClient.Self.Y)
        p.AddInt(TClient.Self.Z)

        Me.Send(p.GetPacket)
    End Sub

    Public Sub Follow(Optional ByVal [Follow] As Boolean = True)
        Dim p As New PacketBuilder(PipePacketType.Follow)
        If [Follow] Then
            If TClient.ReadInt(TClient.Addresses.FollowState) = 1 Then
                Exit Sub
            End If

            TClient.WriteInt(TClient.Addresses.FollowState, 1)
            p.AddByte(1)
        Else
            If TClient.ReadInt(TClient.Addresses.FollowState) = 0 Then
                Exit Sub
            End If

            TClient.WriteInt(TClient.Addresses.FollowState, 0)
            p.AddByte(0)
        End If

        Me.Send(p.GetPacket)
    End Sub

    Public Sub StopActions()
        Dim p As New PacketBuilder(PipePacketType.StopActions)
        p.AddByte(1)
        Me.Send(p.GetPacket)
    End Sub

    Public Sub Logout()
        Dim p As New PacketBuilder(PipePacketType.Logout)
        p.AddByte(1)
        Me.Send(p.GetPacket)
    End Sub


    Public Sub BuyItem(ByVal ID As Short, ByVal count As Byte, ByVal withbackpack As Boolean, ByVal ignorecap As Boolean)
        Dim p As New PacketBuilder(PipePacketType.BuyItem)
        p.AddInt(ID)
        p.AddByte(0)
        p.AddByte(count)
        If withbackpack Then
            p.AddByte(1)
        Else
            p.AddByte(0)
        End If
        If ignorecap Then
            p.AddByte(1)
        Else
            p.AddByte(0)
        End If

        Me.Send(p.GetPacket)
    End Sub

    Public Sub SellItem(ByVal ID As Short, ByVal count As Byte, ByVal SellEQ As Boolean)
        Dim p As New PacketBuilder(PipePacketType.SellItem)
        p.AddInt(ID)
        p.AddByte(0)
        p.AddByte(count)
        If SellEQ Then
            p.AddByte(1)
        Else
            p.AddByte(0)
        End If

        Me.Send(p.GetPacket)
    End Sub

    Public Sub ShowOutput()
        Dim p As New PacketBuilder(PipePacketType.ShowOutput)
        Me.Send(p.GetPacket)
    End Sub
#End Region

#Region "Dispose"
    Private disposed As Boolean = False

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Overloads Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposed Then
            If disposing Then
                'P.Dispose()
                'P = Nothing
            End If

            disposed = True
        End If
    End Sub
#End Region

    Public Delegate Sub hotkeyaddition(ByVal b As Byte)
    Public Sub AddHotkey(ByVal key As Byte)
        Dim m As New hotkeyaddition(AddressOf AddHotkeyAsync)
        m.BeginInvoke(key, Nothing, Nothing)
    End Sub

    Private Sub AddHotkeyAsync(ByVal key As Byte)
        'Do While TClient.Status <> 8
        '    Threading.Thread.Sleep(500)
        'Loop
        Dim pack As New PacketBuilder(PipePacketType.AddKey)
        pack.AddByte(key)
        Me.Send(pack.GetPacket)
    End Sub

    Public Sub RemoveHotkey(ByVal key As Byte)
        Dim pack As New PacketBuilder(PipePacketType.RemoveKey)
        pack.AddByte(key)
        Me.Send(pack.GetPacket)
    End Sub

    Public Sub SendPacketToClient(ByVal packet As Byte())
        Dim P As New PacketBuilder(PipePacketType.SendPacketToClient)
        P.AddBytes(packet)
        Me.Send(P.GetPacket)
    End Sub

    Private PressedKeys As New List(Of Byte)
    Public Sub OnPipeReceive(ByVal packet As Byte()) Handles P.ReceivedData
        Select Case CType(packet(2), PipeIncomingType)
            Case PipeIncomingType.OnClickContextMenu
                RaiseEvent ContextMenuClicked(BitConverter.ToUInt16(packet, 3))
            Case PipeIncomingType.PlayerSay
                'Dim Pack As New PacketBuilder(packet, 2)
                'Pack.GetByte()
                'RaiseEvent CreatureSpeak(Pack.GetString, Pack.GetString)
            Case PipeIncomingType.VIPClickName
                Dim Pack As New PacketBuilder(packet, 2)
                Pack.GetByte()
                TClient.VipPlayer = Pack.GetString
            Case PipeIncomingType.IncomingPacket
                'Packet(3) is where the incoming packet actually starts, so
                '(3) = Type
                '(3+)  = Data
                Select Case CType(packet(3), IncomingPacketType)
                    Case IncomingPacketType.StatusMessage 'Text message
                        Dim len As Short = BitConverter.ToInt16(packet, 5)
                        Dim str As String = System.Text.Encoding.ASCII.GetString(packet, 7, len)
                        TClient.TextMessageRecieved(packet(4), str)
                    Case IncomingPacketType.CreatureHealth 'Creature health
                        Dim id As Integer = BitConverter.ToInt32(packet, 4)
                        Dim hp As Byte = packet(8)
                        TClient.CreatureUpdatedHealth(id, hp)
                    Case IncomingPacketType.CreatureSquare 'Creature Square
                        Dim id As Integer = BitConverter.ToInt32(packet, 4)
                        Dim square As Byte = packet(8)

                        If square = 0 Then
                            TClient.CreatureAttack(id)
                        End If
                    Case IncomingPacketType.TileAddThing 'Tile add thing
                        Dim Pos As New ULocation(BitConverter.ToUInt16(packet, 4), _
                        BitConverter.ToUInt16(packet, 6), packet(8))
                        Dim Stack As Byte = packet(9)
                        Dim ThingID As Short = BitConverter.ToInt16(packet, 10)

                        If ThingID = &H61 OrElse ThingID = &H62 Then

                        ElseIf ThingID = &H63 Then

                        Else 'Added an item
                            Dim Dats As New DatItem(ThingID)
                            If Dats.GetFlag(DatItem.Flag.IsCorpse) OrElse Dats.GetFlag(DatItem.Flag.IsContainer) Then
                                Dim p As Location = Pos.ToLocation
                                TClient.TileCorpseAdded(ThingID, p, Stack)
                            End If
                            Dats = Nothing
                        End If
                    Case IncomingPacketType.CreatureSpeak
                        Dim pos As Integer = 4
                        'unknown, 4 bytes, ignored
                        pos += 4
                        'Sender name
                        Dim namelen As Short = BitConverter.ToInt16(packet, pos)
                        pos += 2
                        Dim name As String = System.Text.Encoding.ASCII.GetString(packet, pos, namelen)
                        pos += namelen

                        'sender level, 2 bytes
                        Dim level As Integer = BitConverter.ToInt16(packet, pos)
                        pos += 2
                        'Speech type, byte, needed
                        Dim sType As Byte = packet(pos)
                        Dim CHID As Short
                        pos += 1

                        If CDbl(TClient.Version) >= CDbl("8.61") Then
                            Select Case sType
                                Case SpeechTypePost861.Say, SpeechTypePost861.Whisper, SpeechTypePost861.Yell
                                    pos += 5
                                Case SpeechTypePost861.ChannelYellow, SpeechTypePost861.ChannelWhite
                                    'channel id
                                    CHID = BitConverter.ToInt16(packet, pos)
                                    pos += 2
                            End Select
                        Else
                            Select Case sType
                                Case SpeechTypePre861.Say, SpeechTypePre861.Whisper, SpeechTypePre861.Yell
                                    pos += 5
                                Case SpeechTypePre861.ChannelYellow, SpeechTypePre861.ChannelWhite
                                    'channel id
                                    CHID = BitConverter.ToInt16(packet, pos)
                                    pos += 2
                            End Select
                        End If

                        'message
                        Dim msglen As Short = BitConverter.ToInt16(packet, pos)
                        pos += 2
                        Dim msg As String = System.Text.Encoding.ASCII.GetString(packet, pos, msglen)
                        pos += msglen

                        RaiseEvent CreatureSpeak(name, level, msg, sType, CHID)
                    Case IncomingPacketType.Projectile
                        Dim PosFrom As New ULocation(BitConverter.ToUInt16(packet, 4), _
                            BitConverter.ToUInt16(packet, 6), packet(8))

                        Dim PosTo As New ULocation(BitConverter.ToUInt16(packet, 9), _
                            BitConverter.ToUInt16(packet, 11), packet(13))

                        Dim PType As ProjectileType = CType(packet(14), ProjectileType)

                        RaiseEvent ProjectileShot(PosFrom.ToLocation, PosTo.ToLocation, PType)
                End Select
            Case PipeIncomingType.ShopOpen
                ShopWindowOpen = True
            Case PipeIncomingType.ShopClose
                ShopWindowOpen = False
            Case PipeIncomingType.KeyDown
                Select Case CType(packet(3), Keys)
                    Case Keys.ControlKey
                        ControlPressed = True
                        Exit Sub
                    Case Keys.ShiftKey
                        ShiftPressed = True
                        Exit Sub
                End Select

                If Not PressedKeys.Contains(packet(3)) Then
                    TClient._KeyDown(packet(3))
                    TClient._KeyPress(packet(3))
                    PressedKeys.Add(packet(3))
                Else
                    TClient._KeyPress(packet(3))
                End If

            Case PipeIncomingType.KeyUP
                Select Case CType(packet(3), Keys)
                    Case Keys.ControlKey
                        ControlPressed = False
                        Exit Sub
                    Case Keys.ShiftKey
                        ShiftPressed = False
                        Exit Sub
                End Select

                If PressedKeys.Contains(packet(3)) Then
                    PressedKeys.Remove(packet(3))
                End If
                TClient._KeyUp(packet(3))
            Case PipeIncomingType.MouseAction
                Dim pos As Integer = 3
                Dim ActionType As Short = BitConverter.ToInt16(packet, pos)
                pos += 2
                Dim x As Short = BitConverter.ToInt16(packet, pos)
                pos += 2
                Dim y As Short = BitConverter.ToInt16(packet, pos)
                pos += 2

                If ActionType = ClickType.LeftDown Then MouseLeftDown = True
                If ActionType = ClickType.LeftUp Then MouseLeftDown = False

                TClient._MouseAction(ActionType, x, y)
            Case PipeIncomingType.ConfirmCheck
                LastInjectCheck = GetTickCount
        End Select
    End Sub
End Class