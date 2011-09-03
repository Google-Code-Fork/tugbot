Public Class CavebotLooter
    Public LootThread As New TimedThread(300, New TimedThread.RunThreadDelegate(AddressOf Loot), False)
    Public Bodies As New Dictionary(Of Byte, Body)

    Public Class Body
        Public Position As Location
        Public CorpseID As Short
        Public BagOpen As Boolean = False
        Public Time As Integer
        Public BagPos As Byte = 0
        Public lastFoodCount As Byte = 0
        Public BaGID As Short

        Public Sub New(ByVal pos As Location, ByVal ID As Integer, ByVal Distance As Integer)
            Position = pos
            CorpseID = ID
            lastFoodCount = 255
            Dim Delay As Integer = Distance * 500 - (Distance * 100)
            If Delay < 0 Then Delay = 500
            Time = GetTickCount + Delay
        End Sub

        Public Function Open() As Byte
            Dim OpenAt As Byte = TClient.Containers.GetFreeSlot - 1

            TClient.Hook.UseItemFromGround(Position.x, Position.y, Position.z, CorpseID, Position.Stack, OpenAt)
            Return OpenAt + 1
        End Function
    End Class

    Public Sub TileCorpseAdded(ByVal CorpseID As Short, ByVal pos As Location)
        If EnableLooter.Checked And Not TClient.Paused Then
            Dim distance As Integer = Math.Sqrt((Math.Abs(pos.y - TClient.Self.Y) ^ 2) + (Math.Abs(pos.x - TClient.Self.X)))

            If Not TClient.Paused Then
                If CaveBotAttacker.EnableFollow.Checked Then
                    TClient.Hook.Follow(False)
                End If
                SyncLock Bodies
                    Dim B As New Body(pos, CorpseID, distance)
                    Dim i As Byte = B.Open
                    If Not Bodies.ContainsKey(i) Then
                        TClient.DelayTime = 1500
                        TClient.DelayStart = GetTickCount()
                        CaveBotAttacker.TargettingTimer.Interval += 600
                        Bodies.Add(i, B)
                        LastBodyOpen = GetTickCount
                    End If
                End SyncLock
            End If

        End If
    End Sub

    Public Function Check() As String
        If EnableLooter.Checked Then Return "On"
        Return "Off"
    End Function

#Region "Load form"
    Private Sub CavebotLooter_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        e.Cancel = True
    End Sub

    Private Sub CavebotLooter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        Me.Refresh()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()
        LootThread.Start()

        AddHandler TClient.FunctionToggled, AddressOf Toggled
    End Sub
#End Region

#Region "Toggle"
    Public Sub Toggled(ByVal Type As Client.ToggleFuncs, ByVal OnOff As Boolean)
        If Type = Client.ToggleFuncs.Looter Then
            EnableLooter.Checked = Not EnableLooter.Checked
        End If
    End Sub

#End Region

#Region "Run Looter"
    Public Function CheckBodyStatus(ByVal Num As Byte) As Boolean
        Dim ret As Boolean = Bodies(Num).CorpseID = TClient.Containers(Num).Id OrElse _
        (Bodies(Num).BagOpen AndAlso ArrayContains(BagIDArray, TClient.Containers(Num).Id))
        Return ret
    End Function
    Public Function CheckContainerStatus(ByVal id As Short) As Boolean
        Dim d As New DatItem(id)
        'before i was checking is pickupavble
        Return Not d.GetFlag(DatItem.Flag.IsCorpse) AndAlso d.GetFlag(DatItem.Flag.IsPickupable)
    End Function
    Public Sub Loot(ByVal actionz As Action)
        If Not TClient.Status = 8 Then System.Threading.Thread.Sleep(1500) : Exit Sub
        Dim Item As ContainerItem
        TClient.Containers.Cache()
        SyncLock Bodies
ReMove:
            For Each k As Integer In Bodies.Keys
                If TClient.Containers(k).IsOpen = 0 AndAlso GetTickCount - Bodies(k).Time > 1000 Then
                    'Its closed and we've spent too long waiting for it to open, bb
                    Bodies.Remove(k)
                    GoTo remove
                ElseIf Not CheckBodyStatus(k) AndAlso TClient.Containers(k).IsOpen = 1 Then
                    'New container tooks its place, bb
                    Bodies.Remove(k)
                    GoTo remove
                ElseIf GetTickCount - Bodies(k).Time > 5000 AndAlso TClient.Containers(k).IsOpen = 1 Then
                    'we've been trying to loot for 5 seconds.
                    'something is wrong, not sure what
                    'no cap? no room? idk but close it
                    Bodies.Remove(k)
                    GoTo remove
                End If
            Next

            For ContainerNum As Byte = 1 To 16
                If Not TClient.Containers(ContainerNum).IsOpen = 1 Then Continue For
                If EnableLooter.Checked AndAlso Bodies.ContainsKey(ContainerNum) AndAlso CheckBodyStatus(ContainerNum) Then
                    If TClient.Paused Then Continue For

                    'Is a body or a bag from the body
                    If TClient.Containers(ContainerNum).NumberOfItems = 0 Then
                        'empty, close it
                        Dim Packet As New PacketBuilder(IncomingPacketType.ContainerClose)
                        Packet.AddByte(ContainerNum - 1)
                        TClient.Hook.SendPacketToClient(Packet.GetPacket)
                        Bodies.Remove(ContainerNum)
                        'Done. lets restart
                        Exit Sub
                    End If

                    For Spot As Byte = 1 To TClient.Containers(ContainerNum).NumberOfItems
                        'Try to loot it
                        Item = TClient.Containers(ContainerNum).Item(Spot)
                        If Item Is Nothing Then Continue For

                        If LootItem(Item) AndAlso Not TClient.CurrentStatusMessage.ToLower.Contains("object is too heavy") Then
                            'Item looted, lets restart
                            TClient.DelayTime = 500
                            TClient.DelayStart = GetTickCount()
                            Exit Sub
                        ElseIf ArrayContains(FoodArray, Item.ID) AndAlso Item.Count < Bodies(ContainerNum).lastFoodCount AndAlso Not TClient.CurrentStatusMessage.ToLower.Contains("you are full") Then
                            'We got ourselves some food bro
                            Item.Use()
                            Bodies(ContainerNum).lastFoodCount = Item.Count
                            'yum, lets retart
                            TClient.DelayTime = 500
                            TClient.DelayStart = GetTickCount()
                            Exit Sub
                        Else
                            'Not looting, not eating. We got a bag?
                            If ArrayContains(BagIDArray, Item.ID) Then
                                'Its a bag
                                Bodies(ContainerNum).BagPos = Spot
                                Bodies(ContainerNum).BaGID = Item.ID
                            End If
                        End If

                        'Unable to do anything with this item.
                        'If its the last one and we have no bag, lets close it
                        If Spot = TClient.Containers(ContainerNum).NumberOfItems AndAlso Bodies(ContainerNum).BagPos = 0 Then
                            Dim Packet As New PacketBuilder(IncomingPacketType.ContainerClose)
                            Packet.AddByte(ContainerNum - 1)
                            TClient.Hook.SendPacketToClient(Packet.GetPacket)
                            Bodies.Remove(ContainerNum)
                            'Done. lets restart
                            Exit Sub
                        End If
                    Next

                    If Bodies(ContainerNum).BagPos <> 0 And Not Bodies(ContainerNum).BagOpen Then
                        'Its a bag
                        TClient.DelayTime = 800
                        TClient.DelayStart = GetTickCount()
                        System.Threading.Thread.Sleep(500)
                        Bodies(ContainerNum).BagOpen = True
                        TClient.Hook.UseItemFromInventory(ContainerNum - 1, Bodies(ContainerNum).BagPos - 1, Bodies(ContainerNum).BaGID, ContainerNum - 1)
                        'bag open, lets restart
                        Exit Sub
                    End If
                ElseIf Not TClient.Containers(ContainerNum).Name.StartsWith("[") AndAlso TClient.Containers(ContainerNum).IsOpen = 1 AndAlso Not Bodies.ContainsKey(ContainerNum) _
                AndAlso CheckContainerStatus(TClient.Containers(ContainerNum).Id) AndAlso Not (TClient.Containers(ContainerNum).Name.ToLower.Contains("dead") AndAlso _
                    Not TClient.Containers(ContainerNum).Name.ToLower.Contains("slain")) Then
                    'Backpack, lets label it
                    Dim Packet As New PacketBuilder(IncomingPacketType.ContainerOpen)
                    Packet.AddByte(ContainerNum - 1) 'Container number
                    Packet.AddInt(TClient.Containers(ContainerNum).Id) 'Container ITEM ID
                    Packet.AddString("[" & ContainerNum & "] " & TClient.Containers(ContainerNum).Name) 'Container Name
                    Packet.AddByte(TClient.Containers(ContainerNum).Size) 'Container Size
                    Packet.AddByte(TClient.Containers(ContainerNum).HasParent) 'Has Parent
                    Packet.AddByte(TClient.Containers(ContainerNum).NumberOfItems) 'Item count

                    Dim Dats As DatItem = Nothing

                    For a As Byte = 1 To TClient.Containers(ContainerNum).NumberOfItems
                        Item = TClient.Containers(ContainerNum).Item(a)
                        If Item Is Nothing Then Continue For
                        Packet.AddInt(Item.ID) 'Item id
                        Dats = New DatItem(Item.ID)
                        If Dats.HasExtraByte Then
                            Packet.AddByte(Item.Count) 'Count
                        End If
                    Next

                    Dats = Nothing
                    TClient.Hook.SendPacketToClient(Packet.GetPacket)

                    'Done, lets restart
                    Exit Sub
                ElseIf EnableLooter.Checked AndAlso (TClient.Containers(ContainerNum).Name.ToLower.Contains("dead") OrElse _
                    TClient.Containers(ContainerNum).Name.ToLower.Contains("slain")) Then
                    'Not a corpse that was opened by bot, but still a corpse
                    'Lets be cool and try to loot shit, but not eat food
                    'And not open any bags
                    If TClient.Paused Then Continue For
                    For Spot As Byte = 1 To TClient.Containers(ContainerNum).NumberOfItems
                        'Try to loot it
                        Item = TClient.Containers(ContainerNum).Item(Spot)
                        If Item Is Nothing Then Continue For
                        If LootItem(Item) Then
                            'Item looted, lets restart
                            Threading.Thread.Sleep(200)
                            Exit Sub
                        End If
                    Next

                End If
            Next
        End SyncLock

        If autoStack Then
            For ContainerNum As Byte = 1 To 16
                If Not TClient.Containers(ContainerNum).IsOpen = 1 Then Continue For
                If Not TClient.Containers(ContainerNum).Name.StartsWith("[") Then Continue For

                Dim R As New System.Random
                Dim LeftOff As Byte
                Dim NewItem As ContainerItem = Nothing
                Dim Dats As DatItem = Nothing

                For a As Byte = 1 To TClient.Containers(ContainerNum).NumberOfItems
                    Item = TClient.Containers(ContainerNum).Item(a)
                    If Item Is Nothing Then Continue For
                    Dats = New DatItem(Item.ID)
                    If R.Next(1, 3) = 2 AndAlso Item.Count < 100 AndAlso Dats.GetFlag(DatItem.Flag.IsStackable) Then
                        NewItem = Item
                        LeftOff = a
                        Exit For
                    End If
                Next

                If NewItem IsNot Nothing Then
                    For a As Byte = LeftOff To TClient.Containers(ContainerNum).NumberOfItems
                        Item = TClient.Containers(ContainerNum).Item(a)
                        If Item Is Nothing Then Continue For
                        If a <> LeftOff AndAlso Item.Count < 100 AndAlso Item.ID = NewItem.ID Then
                            Item.MoveToContainer(ContainerNum, LeftOff)
                            Threading.Thread.Sleep(500)
                            Exit Sub
                        End If
                    Next
                End If
            Next
        End If

        'Try
        '    TClient.TryToAttack()
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
    End Sub

    Public Function LootItem(ByVal item As ContainerItem) As Boolean
        'item.ID
        Dim TempID As Short
        For Each I As ListViewItem In LootList.Items
            TempID = FormatItem(I.Text)
            If TempID = item.ID Then
                Select Case I.SubItems(1).Text.ToLower
                    Case "arrow slot"
                        item.MoveToSlot(Slots.Ammo)
                        Return True
                    Case "right hand"
                        item.MoveToSlot(Slots.RightHand)
                        Return True
                    Case "left hand"
                        item.MoveToSlot(Slots.LeftHand)
                        Return True
                    Case Else
                        If I.SubItems(1).Text.ToLower.StartsWith("backpack") Then
                            Dim FindBP As Byte = FindBackpack(CByte(I.SubItems(1).Text.Split(" ")(1)))
                            If FindBP > 0 Then
                                Dim BestSlot As Byte = FindBestSlot(FindBP, item.ID)
                                If BestSlot > 0 Then 'Put the shit in the slot
                                    item.MoveToContainer(FindBP, BestSlot)
                                    Return True
                                Else 'Open the next BP the person has
                                    Dim CheckItem As ContainerItem = TClient.Containers(FindBP).Item(TClient.Containers(FindBP).NumberOfItems)
                                    If CheckItem Is Nothing Then Return False
                                    If New DatItem(CheckItem.ID).GetFlag(DatItem.Flag.IsContainer) Then
                                        TClient.Hook.UseItemFromInventory(FindBP - 1, TClient.Containers(FindBP).NumberOfItems - 1, CheckItem.ID, FindBP - 1)
                                        For LP = 1 To 20
                                            System.Threading.Thread.Sleep(10)
                                            Application.DoEvents()
                                        Next
                                        Return True
                                    End If
                                    Return False
                                End If
                            End If
                        End If
                End Select
            End If
        Next
    End Function

    Public Function FindBackpack(ByVal BPNum As Byte) As Byte
        For i = 1 To 16
            If TClient.Containers(i).IsOpen = 1 AndAlso TClient.Containers(i).Name.StartsWith("[" & BPNum & "]") Then
                Return i
            End If
        Next
        Return 0
    End Function

    Public Function FindBestSlot(ByVal BPNum As Byte, ByVal itemID As Short) As Byte
        'Try to find a slot with the same item and less than 100 count
        For a = 1 To TClient.Containers(BPNum).NumberOfItems
            If TClient.Containers(BPNum).Item(a).ID = itemID Then
                If TClient.Containers(BPNum).Item(a).Count < 100 AndAlso New DatItem(itemID).HasExtraByte Then
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
#End Region

#Region "Combobox's and numericUpDowns on list view... Huge Mess"
    Private PrioItem As ListViewItem.ListViewSubItem

    Private Sub cbListViewCombo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbListViewCombo.KeyPress
        ' Verify that the user presses ESC.
        Select Case (e.KeyChar)
            Case ChrW(CType(Keys.Escape, Integer))
                ' Reset the original text value, and then hide the ComboBox.
                CType(sender, ComboBox).Text = PrioItem.Text
                CType(sender, ComboBox).Visible = False

            Case ChrW(CType(Keys.Enter, Integer))
                ' Hide the ComboBox.
                CType(sender, ComboBox).Visible = False
        End Select

    End Sub

    Private Sub cbListViewCombo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbListViewCombo.Leave
        ' Set text of ListView item to match the ComboBox.
        PrioItem.Text = CType(sender, ComboBox).Text

        ' Hide the ComboBox.
        CType(sender, ComboBox).Visible = False

    End Sub

    Private Sub cbListViewCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbListViewCombo.SelectedIndexChanged
        ' Set text of ListView item to match the ComboBox.
        PrioItem.Text = CType(sender, ComboBox).Text

        ' Hide the ComboBox.
        CType(sender, ComboBox).Visible = False
    End Sub

    Private Sub AttackPriorityList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LootList.MouseDown
        cbListViewCombo.Visible = False
    End Sub


    Private Sub AttackPriorityList_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LootList.MouseUp
        ' Get the item on the row that is clicked.
        Dim ClN As Byte = 1
        Dim ShowCombo As ComboBox = cbListViewCombo

        Try
            PrioItem = Me.LootList.GetItemAt(e.X, e.Y).SubItems(1)
        Catch
        End Try

        If (PrioItem Is Nothing) Then Exit Sub
        If Not PrioItem.Bounds.Left <= e.X Then Exit Sub
        If (PrioItem.Bounds.Top + PrioItem.Bounds.Height) < e.Y Then Exit Sub


        If (PrioItem Is Nothing) Then Exit Sub

        ' Make sure that an item is clicked.
        If Not (PrioItem Is Nothing) Then
            ' Get the bounds of the item that is clicked.
            Dim ClickedItem As Rectangle = PrioItem.Bounds

            ' Verify that the column is completely scrolled off to the left.
            If ((ClickedItem.Left + Me.LootList.Columns(ClN).Width) < 0) Then
                ' If the cell is out of view to the left, do nothing.
                Return

                ' Verify that the column is partially scrolled off to the left.
            ElseIf (ClickedItem.Left < 0) Then
                ' Determine if column extends beyond right side of ListView.
                If ((Me.LootList.Columns(ClN).Width) > Me.LootList.Width) Then
                    ' Set width of column to match width of ListView.
                    ClickedItem.Width = Me.LootList.Width
                    ClickedItem.X = 0
                    For I As Byte = 0 To ClN - 1
                        ClickedItem.X += Me.LootList.Columns(I).Width
                    Next
                Else
                    ' Right side of cell is in view.
                    ClickedItem.Width = Me.LootList.Columns(ClN).Width + ClickedItem.Left
                    ClickedItem.X = 2
                    For I As Byte = 0 To ClN - 1
                        ClickedItem.X += Me.LootList.Columns(I).Width
                    Next
                End If

            ElseIf (Me.LootList.Columns(ClN).Width > Me.LootList.Width) Then
                ClickedItem.Width = Me.LootList.Width

            Else
                ClickedItem.Width = Me.LootList.Columns(ClN).Width
                ClickedItem.X = 2
                For I As Byte = 0 To ClN - 1
                    ClickedItem.X += Me.LootList.Columns(I).Width
                Next
            End If

            ' Adjust the top to account for the location of the ListView.
            ClickedItem.Y += Me.LootList.Top + 2
            ClickedItem.X += Me.LootList.Left

            ' Assign calculated bounds to the ComboBox.
            ShowCombo.Bounds = ClickedItem

            ' Set default text for ComboBox to match the item that is clicked.
            ShowCombo.Text = PrioItem.Text

            ' Display the ComboBox, and make sure that it is on top with focus.
            ShowCombo.Visible = True
            ShowCombo.BringToFront()
            ShowCombo.Focus()
        End If

    End Sub
#End Region

    Private Sub EnableLooter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableLooter.CheckedChanged
        LootList.Enabled = Not EnableLooter.Checked
        RemoveHandler TClient.CorpseDropped, AddressOf TileCorpseAdded
        AddHandler TClient.CorpseDropped, AddressOf TileCorpseAdded
    End Sub

#Region "Context Menus"
    Public CachedShortscuts As Boolean = False
    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        Dim res As MsgBoxResult = MsgBox("Are you sure you want to delete your entire loot list?", MsgBoxStyle.YesNo)
        If res = MsgBoxResult.Yes Then
            LootList.Items.Clear()
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Try
            LootList.Items.Remove(LootList.SelectedItems(0))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LooterContextMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles LooterContextMenu.Opening
        If Not CachedShortscuts Then
            For Each I As String In ItemShortcuts.Keys
                AddHandler AddItemContext.DropDownItems.Add("{" & I & "}").Click, AddressOf IAdd
            Next
            CachedShortscuts = True
        End If
    End Sub

    Public Sub IAdd(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim itemid As String = CType(sender, ToolStripItem).Text
        If FormatItem(itemid) <> 0 Then
            Dim I As New ListViewItem(itemid)
            I.SubItems.Add("Backpack 1")
            LootList.Items.Add(I)
        End If
    End Sub

    Private Sub CustomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomToolStripMenuItem.Click
        Dim itemid As String = InputBox("Enter the item ID or shortcut.")
        If FormatItem(itemid) <> 0 Then
            Dim I As New ListViewItem(itemid)
            I.SubItems.Add("Backpack 1")
            LootList.Items.Add(I)
        End If
    End Sub
#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TClient.Hook.Follow()
    End Sub

    Public Sub SaveLootFile(ByVal path As String)
        Dim CurrentID As String
        Dim LootTo As String
        Dim ListFile As New System.IO.StreamWriter(path)


        For Each I As ListViewItem In LootList.Items
            CurrentID = I.Text
            LootTo = I.SubItems(1).Text
            ListFile.WriteLine(I.Text)
            ListFile.WriteLine(LootTo)
        Next
        ListFile.Close()
    End Sub

    Public Sub LoadLootFile(ByVal path As String)
        Dim stream_reader As New IO.StreamReader(path)
        Dim ItemID, LootTo As String
        Dim tempI As ListViewItem
        LootList.Items.Clear()

        ItemID = stream_reader.ReadLine()
        Do While Not (ItemID Is Nothing)
            LootTo = stream_reader.ReadLine()
            tempI = New ListViewItem(ItemID)
            tempI.SubItems.Add(LootTo)
            LootList.Items.Add(tempI)
            ItemID = stream_reader.ReadLine()
        Loop


        stream_reader.Close()
    End Sub

    Private Sub LootSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LootSave.Click
        Main.SaveFile.Title = "Save Looter Configuration"
        Main.SaveFile.Filter = "TUGBot Loot File (*.TBLT)|*.TBLT|All files (*.*)|*.*"

        If System.IO.Directory.Exists(Application.StartupPath & "\Quickload\Looter") Then
            Main.SaveFile.InitialDirectory = Application.StartupPath & "\Quickload\Looter"
        Else
            Main.SaveFile.InitialDirectory = Application.StartupPath
        End If
        Main.SaveFile.FileName = ""
        Main.SaveFile.ShowDialog()

        If Main.SaveFile.FileName = "" Then Exit Sub
        SaveLootFile(Main.SaveFile.FileName)
    End Sub

    Private Sub LootLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LootLoad.Click
        Main.LoadFile.Title = "Load Looter Configuration"
        Main.LoadFile.Filter = "TUGBot Loot File (*.TBLT)|*.TBLT|All files (*.*)|*.*"

        If System.IO.Directory.Exists(Application.StartupPath & "\Quickload\Waypoints") Then
            Main.LoadFile.InitialDirectory = Application.StartupPath & "\Quickload\Waypoints"
        Else
            Main.LoadFile.InitialDirectory = Application.StartupPath
        End If
        Main.LoadFile.FileName = ""
        Main.LoadFile.ShowDialog()

        If Main.LoadFile.FileName = "" Then Exit Sub
        LoadLootFile(Main.LoadFile.FileName)
    End Sub
End Class