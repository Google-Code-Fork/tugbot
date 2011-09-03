Imports System.Xml
Public Class CavebotWalker
    Public CaveBotThread As New TimedThread(1200, New TimedThread.RunThreadDelegate(AddressOf RunCaveBot), False)
    Private CurrentWaypoint As Short = 0

#Region "Load Form"
    Private Shadows Sub FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Hide()
        e.Cancel = True
    End Sub

    Private Sub Cavebot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        Me.Refresh()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()

        AddHandler TClient.AddedWaypoint, AddressOf add
        AddHandler TClient.FunctionToggled, AddressOf Toggled
    End Sub
#End Region

#Region "Toggle"
    Public Sub Toggled(ByVal Type As Client.ToggleFuncs, ByVal OnOff As Boolean)
        If Type = Client.ToggleFuncs.Walker Then
            CaveWalkEnable.Checked = Not CaveWalkEnable.Checked
        End If
    End Sub
#End Region

    Public Function Check() As String
        If CaveWalkEnable.Checked Then Return "On"
        Return "Off"
    End Function

#Region "Follow"
    Dim HasCounted As Boolean = False
    Dim UseThisShovel As Short = Shovel
    Dim UseThisRope As Short = Rope

    Private Sub CaveWalkEnable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CaveWalkEnable.CheckedChanged
        If WaypointTree.Nodes.Count <= 1 Then CaveWalkEnable.Checked = False

        UseLightShovel.Enabled = Not CaveWalkEnable.Checked
        UseElvenhairRope.Enabled = Not CaveWalkEnable.Checked
        WaypointTree.Enabled = Not CaveWalkEnable.Checked
        If Not WaypointTree.SelectedNode Is Nothing Then
            CurrentWaypoint = WaypointTree.SelectedNode.Index
        End If


        If CaveWalkEnable.Checked Then
            CaveBotThread.Start()
            For Each N As TreeNode In WaypointTree.Nodes
                If N.Text.StartsWith("CMD ") Then
                    Dim Tempcmd As New CaveCommandStruct("Walker " & WaypointTree.Nodes.IndexOf(N))
                    Tempcmd.Command.CommandString = N.Text.Remove(0, 4)
                    Tempcmd.Enabled = True
                    N.Tag = Tempcmd
                End If
            Next
        Else
            For Each N As TreeNode In WaypointTree.Nodes
                If N.Text.StartsWith("CMD ") Then
                    CType(N.Tag, CaveCommandStruct).Enabled = False
                    N.Tag = Nothing
                End If
            Next
            CaveBotThread.Pause()
        End If
    End Sub

    Public Function CanWalk() As Boolean
        'If the box isnt checked, return false
        If Not CaveWalkEnable.Checked Then CaveBotThread.Pause() : Return False
        'If we have a target, then return false
        While TClient.Self.HasTarget
            System.Threading.Thread.Sleep(500)
            Return False
        End While
        'If we are currently walking, return false
        If TClient.Self.IsWalking Then Return False
        'If the client is paused, then return false
        If TClient.Paused Then Return False
        'If looting, return false
        While CurrentlyLooting()
            System.Threading.Thread.Sleep(500)
            Return False
        End While
        'If 1 or no waypoints, return false
        If WaypointTree.Nodes.Count <= 1 Then Exit Function

        'Return true cause we've met all the conditions to walk
        Return True
    End Function

    Private Sub RunCaveBot(ByVal actionz As Action)
ReStart:
        System.Threading.Thread.Sleep(100)
        'Make sure we can walk
        If Not CanWalk() OrElse TClient.Status <> 8 Then System.Threading.Thread.Sleep(700) : Exit Sub
        'Determine the current waypoint
        If CurrentWaypoint >= WaypointTree.Nodes.Count Then CurrentWaypoint = 0
        WaypointTree.SelectedNode = WaypointTree.Nodes.Item(CurrentWaypoint)
        Dim W As String() = WaypointTree.Nodes.Item(CurrentWaypoint).Text.Split(" ")


        Select Case W(0)
            Case "Ground" 'Ground
                If CheckAdjecency(W(1), W(2), W(3), WaypointTree.SelectedNode.Nodes) Then
                    CurrentWaypoint += 1
                    GoTo ReStart
                ElseIf ParseShort(W(3)) <> TClient.Self.Z Then
                    CurrentWaypoint += 1
                    GoTo ReStart
                Else
                    ToGround(W(1), W(2), CByte(W(3)), WaypointTree.SelectedNode.Nodes)
                End If
            Case "Stairs" 'Stairs
                If ParseShort(W(3)) <> TClient.Self.Z Then
                    CurrentWaypoint += 1
                    GoTo ReStart
                Else
                    TClient.Self.WalkTo(ParseInteger(W(1)), ParseInteger(W(2)), CByte(W(3)))
                End If
            Case "Hole" 'Hole
                If ParseShort(W(3)) <> TClient.Self.Z Then
                    CurrentWaypoint += 1
                    GoTo ReStart
                ElseIf TClient.Self.X = ParseInteger(W(1)) AndAlso TClient.Self.Y = ParseInteger(W(2)) Then
                    TClient.Self.WalkTo(ParseInteger(W(1)), ParseInteger(W(2)) + 1, CByte(W(3)))
                    System.Threading.Thread.Sleep(2500)
                    Dim T As Integer = TClient.Map.GetTile(ParseInteger(W(1)), ParseInteger(W(2)), CByte(W(3)))
                    ClearTile(T)

                    Dim I As Integer

                    For Stack As Integer = 1 To 9
                        I = TClient.Map.GetTileObjectId(T, 9 - Stack)

                        If I <> 0 And New DatItem(I).GetFlag(DatItem.Flag.IsImmovable) Then
                            TClient.Self.UseItemWithGround(ParseInteger(W(1)), ParseInteger(W(2)), CByte(W(3)), _
                                                                            UseThisShovel, I, 10 - Stack)
                            System.Threading.Thread.Sleep(2500)
                            Exit Sub
                        End If
                    Next
                Else
                    TClient.Self.WalkTo(ParseInteger(W(1)), ParseInteger(W(2)), CByte(W(3)))
                End If
            Case "Sewer"
                If ParseShort(W(3)) <> TClient.Self.Z Then
                    CurrentWaypoint += 1
                    GoTo ReStart
                ElseIf CheckAdjecency(W(1), W(2), W(3), Nothing) Then
                    Dim T As Integer = TClient.Map.GetTile(ParseInteger(W(1)), ParseInteger(W(2)), CByte(W(3)))
                    Dim I As Integer
                    ClearTile(T)

                    For cnt As Integer = 1 To 9
                        I = TClient.Map.GetTileObjectId(T, cnt)
                        If I = SewerGrate Then
                            TClient.Self.UseItemFromGround(ParseInteger(W(1)), ParseInteger(W(2)), CByte(W(3)), I, cnt, 1)
                            Exit For
                        End If
                    Next

                Else
                    TClient.Self.WalkTo(ParseInteger(W(1)), ParseInteger(W(2)), CByte(W(3)))
                End If
            Case "Ladder" 'Ladder
                If ParseShort(W(3)) <> TClient.Self.Z Then
                    CurrentWaypoint += 1
                    GoTo ReStart
                ElseIf CheckAdjecency(W(1), W(2), W(3), Nothing) Then
                    Dim T As Integer = TClient.Map.GetTile(ParseInteger(W(1)), ParseInteger(W(2)), CByte(W(3)))
                    Dim I As Integer

                    For Stack As Integer = 1 To 9
                        I = TClient.Map.GetTileObjectId(T, Stack)

                        If ArrayContains(LadderArray, I) Then
                            TClient.Self.UseItemFromGround(ParseInteger(W(1)), ParseInteger(W(2)), CByte(W(3)), I, Stack, 1)
                            Exit Sub
                        End If
                    Next

                    CurrentWaypoint += 1
                    GoTo ReStart
                Else
                    TClient.Self.WalkTo(ParseInteger(W(1)), ParseInteger(W(2)), CByte(W(3)))
                End If
            Case "Rope" 'Rope
                If ParseShort(W(3)) <> TClient.Self.Z Then
                    CurrentWaypoint += 1
                    GoTo ReStart
                ElseIf TClient.Self.IsOnPos(ParseInteger(W(1)), ParseInteger(W(2)), CByte(W(3))) Then
                    Dim T As Integer = TClient.Map.GetTile(ParseInteger(W(1)), ParseInteger(W(2)), CByte(W(3)))
                    Dim I As Integer = TClient.Map.GetTileObjectId(T, 0)
                    TClient.Self.UseItemWithGround(ParseInteger(W(1)), ParseInteger(W(2)), CByte(W(3)), _
                    UseThisRope, I, 0)
                Else
                    TClient.Self.WalkTo(ParseInteger(W(1)), ParseInteger(W(2)), CByte(W(3)))
                End If
            Case "Label" 'Skip over labels
                CurrentWaypoint += 1
                GoTo ReStart
            Case "Yell", "Say", "Whisper", "NPCSay" 'Speak
                Dim Text As String
                For x = 1 To W.Length - 1
                    Text = Text & " " & W(x)
                Next
                Text = Text.TrimStart
                Select Case W(0)
                    Case "Say"
                        TClient.Self.Say(Text)
                    Case "Whisper"
                        TClient.Self.Whisper(Text)
                    Case "Yell"
                        TClient.Self.Yell(Text)
                    Case "NPCSay"
                        TClient.Self.NPCSay(Text)
                End Select
                CurrentWaypoint += 1
                System.Threading.Thread.Sleep(400)
                Exit Sub
            Case "If" 'If statement"
                Dim Value As Integer
                Dim Label As String
                Dim Result As Boolean
                Select Case W(1)
                    Case "Health"
                        Value = TClient.Self.Health
                    Case "Mana"
                        Value = TClient.Self.Mana
                    Case "Cap"
                        Value = TClient.Self.Cap
                    Case "Soul"
                        Value = TClient.Self.Soul
                    Case "Level"
                        Value = TClient.Self.Level
                    Case "Exp"
                        Value = TClient.Self.Exp
                    Case Else
                        If W(1).StartsWith("CountC") Then
                            If Not HasCounted Then
                                Dim ID As Short = ParseShort(W(1).Split(";")(1).Replace("]", ""))
                                TClient.Hook.UseItem(ID)
                                HasCounted = True
                                TClient.DelayTime = 1000
                                TClient.DelayStart = GetTickCount
                                Exit Sub
                            Else
                                Dim ItemName As String = W(1).Remove(0, 7).Split(";")(0)
                                Value = GetItemCount(W(1).Remove(0, 7).Split(";")(0)) + 1
                                HasCounted = False
                            End If
                        ElseIf W(1).StartsWith("Count") Then
                            Value = GetItemCount(W(1).Remove(0, 6).Replace("]", ""))
                        End If
                End Select

                Select Case W(2)
                    Case ">"
                        Result = Value > ParseInteger(W(3))
                    Case "="
                        Result = Value = ParseInteger(W(3))
                    Case "<"
                        Result = Value < ParseInteger(W(3))
                End Select

                If Result = True Then
                    Label = W(4)
                Else
                    Label = W(6)
                End If

                Value = FindLabel(Label)
                If Value = -1 Then
                    CurrentWaypoint += 1
                    TClient.DisplayTextMessage(Client.TextMessageColor.Red, _
                    "Cavebot could not find the label " & Label & _
                    ", which the conditional statement """ & WaypointTree.Nodes.Item(CurrentWaypoint - 1).Text & """ suggested it go to.")
                Else
                    CurrentWaypoint = Value
                End If

                GoTo ReStart
            Case "Goto"
                Dim Value As Integer
                Value = FindLabel(W(1))
                If Value = -1 Then
                    CurrentWaypoint += 1
                    TClient.DisplayTextMessage(Client.TextMessageColor.Red, _
                    "Cavebot could not find the label " & W(1) & _
                    ", which the waypoints suggested it go to.")
                Else
                    CurrentWaypoint = Value
                End If

                GoTo ReStart
            Case "Delay"
                Dim Start As Integer = GetTickCount

                While GetTickCount - Start < ParseInteger(W(1))
                    If Not CaveWalkEnable.Checked Then CaveBotThread.Pause() : Exit Sub
                    System.Threading.Thread.Sleep(100)
                End While

                CurrentWaypoint += 1
                GoTo ReStart
            Case "OpenLocalDepot"
                If FindDepotContainerID() = 0 Then 'No locker open
                    Dim L As Location = LocateDepot()
                    If L.x <> Nothing Then
                        Dim id As Integer = TClient.Map.GetTileObjectId(TClient.Map.GetTile(L.x, L.y, L.z), L.Stack)
                        TClient.Hook.UseItemFromGround(L.x, L.y, CByte(L.z), id, L.Stack, TClient.Containers.GetFreeSlot)
                        System.Threading.Thread.Sleep(1000)
                    End If

                    GoTo ReStart
                Else 'locker is open
                    CurrentWaypoint += 1
                    GoTo ReStart
                End If
            Case "MoveToDepot"
                Dim FromContainer As String = "[" & W(1) & "]"
                Dim id As Short = FormatItem(W(2))
                Dim Item As ContainerItem
                Dim DpID As Byte

ReDoDp:
                For i = 1 To 16
                    If TClient.Containers(i).IsOpen = 1 Then
                        If TClient.Containers(i).Name.ToLower.StartsWith(FromContainer.ToLower) Then

                            For a = 1 To TClient.Containers(i).NumberOfItems
                                Item = TClient.Containers(i).Item(a)
                                If Item Is Nothing Then Continue For

                                If Item.ID = id Then
                                    'Were moving to depot now
                                    DpID = FindDepotContainerID()

                                    If DpID = 0 Then
                                        'dp isnt open
                                        GoTo ReStart
                                    Else
                                        Item.MoveToContainer(DpID, FindBestSlot(DpID, id))
                                        System.Threading.Thread.Sleep(700)
                                        GoTo redodp
                                    End If
                                End If
                            Next

                        End If
                    End If
                Next

                CurrentWaypoint += 1
                GoTo ReStart
            Case "MoveToGround"
                Dim FromContainer As String = "[" & W(1) & "]"
                Dim id As Short = FormatItem(W(2))
                Dim Item As ContainerItem

ReDo:
                For i = 1 To 16
                    If TClient.Containers(i).IsOpen = 1 Then
                        If TClient.Containers(i).Name.ToLower.StartsWith(FromContainer.ToLower) Then

                            For a = 1 To TClient.Containers(i).NumberOfItems
                                Item = TClient.Containers(i).Item(a)
                                If Item Is Nothing Then Continue For

                                If Item.ID = id Then
                                    'Were moving to ground now
                                    Item.MoveToGround(New Location(TClient.Self.X, TClient.Self.Y, TClient.Self.Z))
                                    System.Threading.Thread.Sleep(700)
                                    GoTo ReDo
                                End If
                            Next

                        End If
                    End If
                Next

                CurrentWaypoint += 1
                GoTo ReStart
            Case "TradeSession"
                TClient.Self.NPCSay("Hi")
                System.Threading.Thread.Sleep(700)
                TClient.Self.NPCSay("Trade")
                System.Threading.Thread.Sleep(500)

                Dim Loops As Integer = 0
                While Loops < 5 And Not ShopWindowOpen
                    System.Threading.Thread.Sleep(500)
                    Loops += 1
                End While

                If Not ShopWindowOpen Then
                    'shop window didnt open after 2.5 seconds
                    Exit Sub
                End If

                Dim SplitSale As String()
                For Each Sale As TreeNode In WaypointTree.SelectedNode.Nodes
                    SplitSale = Sale.Text.Split(" ")
                    Select Case SplitSale(0)
                        Case "Sell"
                            Dim SellEQ As Boolean
                            Dim ID As Short = FormatItem(SplitSale(2))
                            Dim Count As Byte = SplitSale(3)

                            If SplitSale(1) = "IncludeEQ" Then
                                SellEQ = True
                            Else
                                SellEQ = False
                            End If

                            TClient.Hook.SellItem(ID, Count, SellEQ)
                        Case "Buy"
                            Dim BuyBps As Boolean
                            Dim ConsiderCap As Boolean
                            Dim ID As Short = FormatItem(SplitSale(3))
                            Dim Count As Byte = SplitSale(4)

                            If SplitSale(1) = "WithBps" Then
                                BuyBps = True
                            Else
                                BuyBps = False
                            End If

                            If SplitSale(2) = "CapConsider" Then
                                ConsiderCap = True
                            Else
                                ConsiderCap = False
                            End If

                            TClient.Hook.BuyItem(ID, Count, BuyBps, Not ConsiderCap)
                    End Select

                    System.Threading.Thread.Sleep(700)
                Next

                CurrentWaypoint += 1
                GoTo ReStart
            Case "Door"
                Dim Pos As New Location(ParseInteger(W(1)), ParseInteger(W(2)), CByte(W(3)))

                If Pos.z <> TClient.Self.Z Then
                    CurrentWaypoint += 1
                    GoTo ReStart
                ElseIf Math.Abs(TClient.Self.X - Pos.x) <= 7 AndAlso Math.Abs(TClient.Self.Y - Pos.y) <= 5 Then
                    Dim T As Integer = TClient.Map.GetTile(Pos.x, Pos.y, Pos.z)
                    Dim I As Integer

                    For Stack As Integer = 1 To 9
                        I = TClient.Map.GetTileObjectId(T, 9 - Stack)

                        If ArrayContains(ClosedDoorArray, I) Then
                            TClient.Self.UseItemFromGround(Pos.x, Pos.y, Pos.z, I, 10 - Stack, 1)
                            CurrentWaypoint += 1
                            GoTo ReStart
                        End If
                    Next

                    CurrentWaypoint += 1
                    GoTo ReStart
                Else
                    TClient.DisplayTextMessage(Client.TextMessageColor.Red, "You must be on screen of the door you wish to open. Please set a ground waypoint by the door.")
                End If
            Case "KeyDoor"
                Dim Key As Short = ParseShort(W(1))
                Dim Pos As New Location(ParseInteger(W(2)), ParseInteger(W(3)), CByte(W(4)))

                If Pos.z <> TClient.Self.Z Then
                    CurrentWaypoint += 1
                    GoTo ReStart
                ElseIf Math.Abs(TClient.Self.X - Pos.x) <= 7 AndAlso Math.Abs(TClient.Self.Y - Pos.y) <= 5 Then
                    Dim T As Integer = TClient.Map.GetTile(Pos.x, Pos.y, Pos.z)
                    Dim I As Integer

                    For Stack As Integer = 1 To 9
                        I = TClient.Map.GetTileObjectId(T, 9 - Stack)

                        If ArrayContains(ClosedDoorArray, I) Then
                            TClient.Self.UseItemWithGround(Pos.x, Pos.y, Pos.z, Key, I, 10 - Stack)
                            CurrentWaypoint += 1
                            GoTo ReStart
                        End If
                    Next

                    CurrentWaypoint += 1
                    GoTo ReStart
                Else
                    TClient.DisplayTextMessage(Client.TextMessageColor.Red, "You must be on screen of the door you wish to open. Please set a ground waypoint by the door.")
                End If
            Case "CMD"
                CType(WaypointTree.Nodes.Item(CurrentWaypoint).Tag, CaveCommandStruct).InvokeCommand()
                CurrentWaypoint += 1
                System.Threading.Thread.Sleep(1500)
                Exit Sub
            Case Else
                Exit Sub 'WaypointType.Action 'Actions
                'Select Case W.Action.Type
                '    Case ActionType.Delay 'Delay
                '        If W.Action.ArgS = "minutes" Then
                '            DelayTime = W.Action.ArgI * 1000 * 60
                '        Else
                '            DelayTime = W.Action.ArgI * 1000
                '        End If
                '        DelayStart = GetTickCount
                '        CurrentWaypoint += 1
                '        GoTo ReStart
                '    Case ActionType.Drop 'Drop items
                '        'TO BE DONE
                '    Case ActionType.Face 'Face
                '        'TO BE DONE
                '    Case ActionType.Loggout 'Loggout
                '        'TO BE DONE
                '    Case ActionType.Speech 'Speak
                '        Select Case CType(W.Action.ArgI, SelfSpeechType)
                '            Case SelfSpeechType.Say
                '                Self.Say(W.Action.ArgS)
                '            Case SelfSpeechType.Whisper
                '                Self.Whisper(W.Action.ArgS)
                '            Case SelfSpeechType.Yell
                '                Self.Yell(W.Action.ArgS)
                '        End Select
                '        CurrentWaypoint += 1
                '        Exit Sub
                'End Select
        End Select
    End Sub

    Public Function FindDepotContainerID() As Byte
        For i = 1 To 16
            If TClient.Containers(i).IsOpen = 1 AndAlso TClient.Containers(i).Name = "Locker" Then
                Return i
            End If
        Next
        Return 0
    End Function

    Public Function FindBestSlot(ByVal BPNum As Byte, ByVal itemID As Short) As Byte
        'Try to find a slot with the same item and less than 100 count
        For a = 1 To TClient.Containers(BPNum).NumberOfItems
            If TClient.Containers(BPNum).Item(a).ID = itemID Then
                If TClient.Containers(BPNum).Item(a).Count < 100 Then
                    Return a
                End If
            End If
        Next

        'No spot found to stack on. Check if there is room left in the bp, if so then
        'Stack on a spot with no container to keep it in the same BP
        If TClient.Containers(BPNum).NumberOfItems < TClient.Containers(BPNum).Size Then
            Dim Dats As New DatItem(TClient.Containers(BPNum).Item(1).ID)
            If Not Dats.GetFlag(DatItem.Flag.IsContainer) Then
                Return 1
            Else
                Return TClient.Containers(BPNum).NumberOfItems + 1
            End If
        End If

        'Return 0, meaning we open a new bp
        Return 0
    End Function

    Private Sub ClearTile(ByVal TileNum As Integer)
ReRun:
        Dim Dats As DatItem
        Dim id As Integer
        For i As Byte = 1 To 9
            id = TClient.Map.GetTileObjectId(TileNum, i)
            If id = 0 Then Continue For
            Dats = New DatItem(id)
            If Not Dats.GetFlag(DatItem.Flag.IsImmovable) And Dats.ItemId > 99 Then
                If Dats.GetFlag(DatItem.Flag.Blocking) Then 'Troughs and plants
                ElseIf Dats.GetFlag(DatItem.Flag.Blocking) Then 'Boxes, parcels, possibly fields
                ElseIf Dats.GetFlag(DatItem.Flag.IsStackable) Then 'Stacable items
                    TClient.Self.MoveFromGroundToGround(Dats.ItemId, _
                                    1, _
                                    TClient.Map.GetGlobalPosition(TileNum), i, _
                                    New Location(TClient.Self.X, TClient.Self.Y, TClient.Self.Z))
                Else 'other items
                    TClient.Self.MoveFromGroundToGround(Dats.ItemId, 1, _
                                    TClient.Map.GetGlobalPosition(TileNum), i, _
                                    New Location(TClient.Self.X, TClient.Self.Y, TClient.Self.Z))
                End If
                System.Threading.Thread.Sleep(1500)
            End If
        Next
    End Sub

    Private Sub ToGround(ByVal x As Integer, ByVal y As Integer, ByVal z As Byte, ByVal nodes As TreeNodeCollection)
        If nodes IsNot Nothing AndAlso nodes.Count > 0 Then
            Dim rnd As New System.Random
            Dim N As String = nodes(rnd.Next(0, nodes.Count - 1)).Text

            If N.StartsWith("Node") Then
                Dim TempSplit As String() = N.Split(" ")
                TClient.Self.WalkTo(x + ParseInteger(TempSplit(1)), y + ParseInteger(TempSplit(2)), z)
                Exit Sub
            End If
        End If

        TClient.Self.WalkTo(ParseInteger(x), ParseInteger(y), z)
    End Sub

    Private Function CheckAdjecency(ByVal x As Integer, ByVal y As Integer, ByVal z As Byte, ByVal nodes As TreeNodeCollection) As Boolean
        If TClient.Self.IsAdjecentTo(ParseInteger(x), ParseInteger(y), z) Then
            Return True
        End If

        If nodes IsNot Nothing Then
            Dim TempSplit As String()
            For Each n As TreeNode In nodes
                If n.Text.StartsWith("Node") Then
                    TempSplit = n.Text.Split(" ")
                    If TClient.Self.IsAdjecentTo _
                    (x + ParseShort(TempSplit(1)), y + ParseInteger(TempSplit(2)), z) Then
                        Return True
                    End If
                End If
            Next
        End If
        Return False
    End Function

    Public Function FindLabel(ByVal label As String) As Integer
        For Each n As TreeNode In WaypointTree.Nodes
            If n.Text.ToLower = "label " & label.ToLower Then
                Return n.Index
            End If
        Next

        Return -1
    End Function
#End Region

#Region "Save/load"
    Private Sub WaypointSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaypointSave.Click
        Main.SaveFile.Title = "Save Waypoints"
        Main.SaveFile.Filter = "TUGBot Waypoint File (*.TBWP)|*.TBWP|All files (*.*)|*.*"

        If System.IO.Directory.Exists(Application.StartupPath & "\Quickload\Cave Walker") Then
            Main.SaveFile.InitialDirectory = Application.StartupPath & "\Quickload\Cave Walker"
        Else
            Main.SaveFile.InitialDirectory = Application.StartupPath
        End If
        Main.SaveFile.FileName = ""
        Main.SaveFile.ShowDialog()

        If Main.SaveFile.FileName = "" Then Exit Sub

        Dim ListFile As New System.IO.StreamWriter(Main.SaveFile.FileName)

        For Each i As TreeNode In WaypointTree.Nodes
            ListFile.WriteLine(i.Text)
            For Each node As TreeNode In i.Nodes
                ListFile.WriteLine("--" & node.Text)
            Next
        Next
        ListFile.Close()
    End Sub

    Private Sub WaypointLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaypointLoad.Click
        Main.LoadFile.Title = "Load Waypoints"
        Main.LoadFile.Filter = "TUGBot Waypoint File (*.TBWP)|*.TBWP|All files (*.*)|*.*"

        If System.IO.Directory.Exists(Application.StartupPath & "\Quickload\Waypoints") Then
            Main.LoadFile.InitialDirectory = Application.StartupPath & "\Quickload\Waypoints"
        Else
            Main.LoadFile.InitialDirectory = Application.StartupPath
        End If
        Main.LoadFile.FileName = ""
        Main.LoadFile.ShowDialog()

        If Main.LoadFile.FileName = "" Then Exit Sub

        LoadWaypoints(Main.LoadFile.FileName)
    End Sub

    Public Sub LoadWaypoints(ByVal file As String)
        Dim stream_reader As New IO.StreamReader(file)
        Dim line As String

        line = stream_reader.ReadLine()
        WaypointTree.Nodes.Clear()
        Do While Not (line Is Nothing)
            line = line.Trim()
            If line.Length > 0 Then
                If Not line.StartsWith("--") Then
                    WaypointTree.Nodes.Add(line)
                Else
                    WaypointTree.Nodes(WaypointTree.Nodes.Count - 1).Nodes.Add(line.Remove(0, 2))
                    WaypointTree.Nodes(WaypointTree.Nodes.Count - 1).Expand()
                End If
            End If
            line = stream_reader.ReadLine()
        Loop
        stream_reader.Close()
    End Sub
#End Region

#Region "Context Menu"
    Public Function PositionOffsetToString(ByVal offx As Integer, ByVal offy As Integer, ByVal offz As Integer) As String
        Return TClient.Self.X + offx & " " & TClient.Self.Y + offy & " " & TClient.Self.Z + offz
    End Function

#Region "misc"
    Private Sub WaypointAddCondition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaypointAddCondition.Click
        CavebotCondition.Show(Me)
    End Sub

    Private Sub WaypointAddLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaypointAddLabel.Click
        Dim Labeladd As String = InputBox("Please input a label name.")
        Dim NewLabelAdd As String = Labeladd.Replace(" ", "").Replace("""", "").Replace("'", "")
        If NewLabelAdd = "" Then Exit Sub
        If FindLabel("""" & NewLabelAdd & """") <> -1 Then Exit Sub
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Label """ & NewLabelAdd & """")

        If NewLabelAdd <> Labeladd Then
            MsgBox("The label has been added as """ & NewLabelAdd & """", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub WaypointAddGoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaypointAddGoto.Click
        Dim Labeladd As String = InputBox("Please input the label name which you want to goto.")
        Dim NewLabelAdd As String = Labeladd.Replace(" ", "").Replace("""", "").Replace("'", "")
        If NewLabelAdd = "" Then Exit Sub
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Goto """ & NewLabelAdd & """")
    End Sub

    Private Sub DoorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoorToolStripMenuItem.Click
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Door " & PositionOffsetToString(0, 0, 0))
    End Sub

    Private Sub KeyDoorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeyDoorToolStripMenuItem.Click
        Dim key As String = FormatItem(InputBox("Please enter the ItemID or shortcut of the key."))
        If key = 0 Then Exit Sub

        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("KeyDoor " & key & " " & PositionOffsetToString(0, 0, 0))
    End Sub
#End Region

#Region "Ground"
    Public Sub WaypointAddGround_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaypointAddGround.Click
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Ground " & PositionOffsetToString(0, 0, 0))
    End Sub

    Public Sub WaypointAddNode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaypointAddNode.Click
        If WaypointTree.SelectedNode IsNot Nothing Then
            Dim W As String() = WaypointTree.SelectedNode.Text.Split(" ")
            If Not W(0).StartsWith("Ground") Then MsgBox("You must select a ground waypoint on the waypoint list before adding a node.") : Exit Sub

            Dim X As Integer = ParseInteger(W(1))
            Dim y As Integer = ParseInteger(W(2))
            Dim z As Integer = ParseInteger(W(3))

            If Math.Abs(TClient.Self.X - X) <= 7 And Math.Abs(TClient.Self.Y - y) <= 5 And TClient.Self.Z = z Then
                WaypointTree.SelectedNode.Nodes.Add("Node " & TClient.Self.X - X & " " & TClient.Self.Y - y)
                WaypointTree.SelectedNode.Expand()
            Else
                MsgBox("You must be somewhere on the screen of the ground waypoint which you would like to add a node too.")
            End If
        End If
    End Sub
#End Region

#Region "Stairs"
    Public Sub WaypointAddUpstairs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaypointAddUpstairs.Click
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Stairs " & PositionOffsetToString(0, 1, 1))
    End Sub

    Public Sub WaypointAddDownstairs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaypointAddDownstairs.Click
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Stairs " & PositionOffsetToString(0, -1, -1))
    End Sub
#End Region

#Region "Floor Change"
    Public Sub WaypointAddLadder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaypointAddLadder.Click
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Ladder " & PositionOffsetToString(0, -1, 1))
    End Sub

    Public Sub WaypointAddHole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaypointAddHole.Click
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Hole " & PositionOffsetToString(0, 0, -1))
    End Sub

    Private Sub WaypointAddSewer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaypointAddSewer.Click
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Sewer " & PositionOffsetToString(0, 0, -1))
    End Sub

    Public Sub WaypointAddRope_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaypointAddRope.Click
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Rope " & PositionOffsetToString(0, -1, 1))
    End Sub
#End Region

#Region "Actions"
    Public MoveAction As String = ""
    Private Sub WaypointAddSay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaypointAddSay.Click
        Dim Labeladd As String = InputBox("Please input the text which you want to say.")
        If Labeladd.Replace(" ", "") = "" Or Labeladd Is Nothing Then Exit Sub
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Say " & Labeladd)
    End Sub

    Private Sub WaypointAddNPCSay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaypointAddNPCSay.Click
        Dim Labeladd As String = InputBox("Please input the text which you want to say in NPC channel.")
        If Labeladd.Replace(" ", "") = "" Or Labeladd Is Nothing Then Exit Sub
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("NPCSay " & Labeladd)
    End Sub


    Private Sub DelayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelayToolStripMenuItem.Click
        Dim Labeladd As String = InputBox("Please enter an integer representing the amount of milliseconds you would like to delay for.")
        If Labeladd.Replace(" ", "") = "" Or Labeladd Is Nothing Then Exit Sub
        If ParseInteger(Labeladd) <> 0 Then
            WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Delay " & ParseInteger(Labeladd))
        End If
    End Sub

    Private Sub FindAndOpenDepotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindAndOpenDepotToolStripMenuItem.Click
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("OpenLocalDepot")
    End Sub


    Private Sub ToGroundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToGroundToolStripMenuItem.Click
        MoveAction = "MoveToGround"
        CavebotItemMove.Show(Me)
    End Sub

    Private Sub ToDepotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToDepotToolStripMenuItem.Click
        MoveAction = "MoveToDepot"
        CavebotItemMove.Show(Me)
    End Sub

    Private Sub TradeSessionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TradeSessionToolStripMenuItem.Click
        CavebotTradeSession.Show(Me)
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Dim Labeladd As String = InputBox("Please enter the command to be executed.")
        If Labeladd.Replace(" ", "") = "" Or Labeladd Is Nothing Then Exit Sub

        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("CMD " & Labeladd)
    End Sub
#End Region

#Region "Ramps"
    'NORTH
    Private Sub NorthUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NorthUp.Click
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Stairs " & PositionOffsetToString(0, 1, 1))
    End Sub
    Private Sub NorthDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NorthDown.Click
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Stairs " & PositionOffsetToString(0, -1, -1))
    End Sub
    'SOUTH
    Private Sub SouthUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SouthUp.Click
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Stairs " & PositionOffsetToString(0, -1, 1))
    End Sub
    Private Sub SouthDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SouthDown.Click
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Stairs " & PositionOffsetToString(0, 1, -1))
    End Sub
    'WEST
    Private Sub WestUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WestUp.Click
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Stairs " & PositionOffsetToString(1, 0, 1))
    End Sub
    Private Sub WestDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WestDown.Click
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Stairs " & PositionOffsetToString(-1, 0, -1))
    End Sub
    'EAST
    Private Sub EastUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EastUp.Click
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Stairs " & PositionOffsetToString(-1, 0, 1))
    End Sub
    Private Sub EastDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EastDown.Click
        WaypointTree.SelectedNode = WaypointTree.Nodes.Add("Stairs " & PositionOffsetToString(1, 0, -1))
    End Sub
#End Region

    Private Sub WaypointDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaypointDelete.Click
        If WaypointTree.SelectedNode IsNot Nothing AndAlso WaypointTree.SelectedNode.Text <> "Label ""Start""" Then
            WaypointTree.SelectedNode.Remove()
        End If
    End Sub

    Private Sub WaypointClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaypointClear.Click
        Dim res As MsgBoxResult = MsgBox("Are you sure you want to delete all of your waypoints?", MsgBoxStyle.YesNo)
        If res = MsgBoxResult.Yes Then
            WaypointTree.Nodes.Clear()
            WaypointTree.Nodes.Add("Label ""Start""")
        End If
    End Sub
#End Region

#Region "Add By Hotkeys"
    Private Delegate Sub AddWPDelegate(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Function add(ByVal Type As String) As String
        Select Case Type.ToLower
            Case "ground"
                Me.BeginInvoke(New AddWPDelegate(AddressOf WaypointAddGround_Click), Nothing, Nothing)
            Case "node"
                Me.BeginInvoke(New AddWPDelegate(AddressOf WaypointAddNode_Click), Nothing, Nothing)
            Case "upstairs"
                Me.BeginInvoke(New AddWPDelegate(AddressOf WaypointAddUpstairs_Click), Nothing, Nothing)
            Case "downstairs"
                Me.BeginInvoke(New AddWPDelegate(AddressOf WaypointAddDownstairs_Click), Nothing, Nothing)
            Case "ladder"
                Me.BeginInvoke(New AddWPDelegate(AddressOf WaypointAddLadder_Click), Nothing, Nothing)
            Case "hole"
                Me.BeginInvoke(New AddWPDelegate(AddressOf WaypointAddHole_Click), Nothing, Nothing)
            Case "rope"
                Me.BeginInvoke(New AddWPDelegate(AddressOf WaypointAddRope_Click), Nothing, Nothing)
            Case Else
                Return """Command ""CaveAdd"": """ & Type & """ must be one of the following: gound, node, upstairs, downstairs, ladder, hole, rope"
        End Select

        Return String.Empty
    End Function
#End Region

    Private Sub WaypointTree_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles WaypointTree.KeyDown
        If e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Subtract Then
            e.SuppressKeyPress = True
            e.Handled = True
        End If
    End Sub

    

    Private Sub WaypointTree_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WaypointTree.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim Selcnode As TreeNode = WaypointTree.GetNodeAt(e.X, e.Y)
            If Selcnode IsNot Nothing Then
                WaypointTree.SelectedNode = Selcnode
            End If
        End If
    End Sub

    Private Sub WaypointTree_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles WaypointTree.NodeMouseDoubleClick
        WaypointTree.ExpandAll()
    End Sub

    Private Sub UseLightShovel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseLightShovel.CheckedChanged
        If UseLightShovel.Checked Then
            UseThisShovel = LightShovel
        Else
            UseThisShovel = Shovel
        End If

    End Sub

    Private Sub UseElvenhairRope_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseElvenhairRope.CheckedChanged
        If UseElvenhairRope.Checked Then
            UseThisRope = ElvenhairRope
        Else
            UseThisRope = Rope
        End If
    End Sub


End Class



