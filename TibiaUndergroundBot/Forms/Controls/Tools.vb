Public Class Tools

    Private Shadows Sub FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Visible = False
        Me.Refresh()
        e.Cancel = True
    End Sub

    Private Sub Tools_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()
        'EatFrom.SelectedIndex = 0

        AddHandler TClient.CreatureHealthUpdated, AddressOf CreatureHealthUpdated
        AddHandler TClient.FunctionToggled, AddressOf Toggled
        AddHandler TClient.TradeChannelSpeak, AddressOf TradeChannelSpeak
    End Sub


#Region "Trade Watcher"
    Public Sub TradeChannelSpeak(ByVal name As String, ByVal level As Integer, ByVal text As String)
        If name.ToLower <> TClient.Self.Name.ToLower AndAlso IsWatchedTradeMessage(text) Then
            TClient.DisplayTextMessage(Client.TextMessageColor.Red, name & " [" & level & "]: [Trade] " & text)
            'TClient.BrodcastMessage(name, "[Trade]" & Chr(10) & text, level)
        End If
    End Sub

    Public Function IsWatchedTradeMessage(ByVal text As String) As Boolean
        If TradeWatchEnable.Checked Then
            Dim Texts As String() = Split(TextToWatch.Text.ToLower, ",")
            For Each S As String In Texts
                If text.ToLower.Contains(S) Then
                    Return True
                End If
            Next
        End If
    End Function

    Private Sub TradeWatchEnable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TradeWatchEnable.CheckedChanged
        If TextToWatch.Text = String.Empty Then Exit Sub
        TextToWatch.Enabled = Not TradeWatchEnable.Checked
    End Sub
#End Region

#Region "Toggle"
    Public Sub Toggled(ByVal Type As Client.ToggleFuncs, ByVal OnOff As Boolean)
        Select Case Type
            Case Client.ToggleFuncs.Idle
                AntiIdle.Checked = OnOff
            Case Client.ToggleFuncs.XRay
                EnableXray.Checked = OnOff
            Case Client.ToggleFuncs.Light
                EnableLight.Checked = OnOff
        End Select
    End Sub
#End Region

#Region "Replace Trees and Open Pitfalls"
    Private Sub OpenPitfalls_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenPitfalls.CheckedChanged
        If OpenPitfalls.Checked = True Then
            OpenPitfalls.Enabled = False
            For j As Integer = LBound(ClosedPitfallArray) To UBound(ClosedPitfallArray)
                Dim d As New DatItem(ClosedPitfallArray(j))
                d.Sprites = New DatItem(ClosedPitfallArray(j)).Sprites
            Next
            TClient.ShowStatusMessage("TUGBot -> Pitfalls Opened", 50)
            TClient.PitsDone = True
        End If

    End Sub

    Private Sub ReplaceTrees_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceTrees.CheckedChanged
        If ReplaceTrees.Checked = True Then
            ReplaceTrees.Enabled = False
            For j As Integer = LBound(TreeArray) To UBound(TreeArray)
                Dim d As New DatItem(TreeArray(j))
                d.Height = 1
                d.Width = 1
                d.Sprites = New DatItem(3682).Sprites
            Next
            TClient.TreesDone = True
            TClient.ShowStatusMessage("TUGBot -> Trees Replaced", 50)
        End If

    End Sub
#End Region

#Region "Walk on Fields/Furniture"
    Private Sub FieldWalker_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FieldWalker.CheckedChanged
        TClient.CanWalkOnFields = FieldWalker.Checked
        If FieldWalker.Checked = True Then
            For j As Integer = LBound(FieldArray) To UBound(FieldArray)
                Dim d As New DatItem(FieldArray(j))
                d.SetFlag(DatItem.Flag.BlocksPath, False)
            Next
            TClient.ShowStatusMessage("TUGBot -> Magic Field Walking Enabled", 50)
        Else
            For j As Integer = LBound(FieldArray) To UBound(FieldArray)
                Dim d As New DatItem(FieldArray(j))
                d.SetFlag(DatItem.Flag.BlocksPath, True)
            Next
            TClient.ShowStatusMessage("TUGBot -> Magic Field Walking Disabled", 50)
        End If
    End Sub

    Private Sub FurnitureWalker_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FurnitureWalker.CheckedChanged
        TClient.CanWalkOnFields = FieldWalker.Checked
        If FurnitureWalker.Checked = True Then
            For j As Integer = LBound(BlockingItemArray) To UBound(BlockingItemArray)
                Dim d As New DatItem(BlockingItemArray(j))
                d.SetFlag(DatItem.Flag.BlocksPath, False)
            Next
            TClient.ShowStatusMessage("TUGBot -> Furniture Field Walking Enabled", 50)
        Else
            For j As Integer = LBound(BlockingItemArray) To UBound(BlockingItemArray)
                Dim d As New DatItem(BlockingItemArray(j))
                d.SetFlag(DatItem.Flag.BlocksPath, True)
            Next
            TClient.ShowStatusMessage("TUGBot -> Furniture Walking Disabled", 50)
        End If
    End Sub
#End Region

#Region "XRay and Light"
    Private Sub EnableXray_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableXray.CheckedChanged
        If EnableXray.Checked Then
            TClient.Screen.XRay(True)
        Else
            TClient.Screen.XRay(False)
        End If
    End Sub

    Private Sub EnableLight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableLight.CheckedChanged
        If EnableLight.Checked Then
            TClient.Screen.LightHack(True)
        Else
            TClient.Screen.LightHack(False)
        End If
    End Sub
#End Region

#Region "Update creature health"
    Public Sub CreatureHealthUpdated(ByVal cid As Integer, ByVal health As Byte, ByVal oldhealth As Byte)
        If cid = TClient.Self.Target Then
            If GetTickCount - TClient.DelayStart > TClient.DelayTime Then
                TClient.DelayStart = GetTickCount
                TClient.DelayTime = 300
            Else
                TClient.DelayTime += 300
            End If
        End If
        If ShowHealPercent.Checked Then
            Dim i As Integer = TClient.Battlelist.PosByID(cid)
            If CInt(health) - CInt(oldhealth) > 1 Then
                TClient.DisplayAnimatedText(Client.TextColor.Crystal, _
                "+" & CInt(health) - TClient.Battlelist.Health(i) & "%", _
                New Location(TClient.Battlelist.X(i), TClient.Battlelist.Y(i), TClient.Battlelist.Z(i)))
            End If
        End If
    End Sub
#End Region

#Region "Anti Idle"
    Private Sub AntiIdle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AntiIdle.CheckedChanged
        If AntiIdle.Checked Then
            IdleTimer.Interval = 200
            IdleTimer.Start()
        Else
            IdleTimer.Stop()
        End If
    End Sub

    Private Sub IdleTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IdleTimer.Tick
        If TClient.Paused Then Exit Sub
        Dim Dir As Byte
        Dim Interval As New System.Random
        TClient.Battlelist.Cache()


        For i = 1 To TClient.Battlelist.Length
            If TClient.Battlelist.ID(i) = TClient.Self.Id Then
                Dir = TClient.Battlelist.Direction(i)
                Exit For
            End If
        Next

        'If Dir <> 2 Then TClient.Hook.Spin(2) Else TClient.Hook.Spin(1)
        TClient.Hook.Spin(Dir)
        IdleTimer.Interval = Interval.Next(60000, 600000) - Interval.Next(1000, 50000)
    End Sub
#End Region

#Region "Eat Food"
    Private Sub FoodTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FoodTimer.Tick
        If TClient.Paused Then Exit Sub
        'Dim rand As New System.Random
        FoodTimer.Interval = 45000 'rand.Next(56000, 145000) - rand.Next(666, 26969)
        If Not FoodEater.IsBusy Then FoodEater.RunWorkerAsync()
    End Sub

    Private Sub FoodEater_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles FoodEater.DoWork
        Dim Item As ContainerItem
        Dim ItemCount As Integer = 8
        'If EatFrom.Text.ToLower.Contains("backpack") Then
        For i = 1 To 16
            If TClient.Containers(i).IsOpen Then
                'If TClient.Containers(i).Name.ToLower.Replace("bp", "backpack") = EatFrom.Text.ToLower Then
                For a = 1 To TClient.Containers(i).NumberOfItems
                    Item = TClient.Containers(i).Item(a)
                    If Item Is Nothing Then Continue For
                    If Item.Count < 8 Then
                        ItemCount = Item.Count
                    Else
                        ItemCount = 8
                    End If
                    If ArrayContains(FoodArray, Item.ID) Then
                        For C = 0 To ItemCount - 1
                            Item.Use()
                            System.Threading.Thread.Sleep(200)
                        Next
                        Exit Sub
                    End If
                Next
                'End If
            End If
        Next
    End Sub

    Private Sub EatFood_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EatFood.CheckedChanged
        If EatFood.Checked Then FoodTimer.Start() : Exit Sub
        FoodTimer.Stop()
    End Sub
#End Region

#Region "Fishing"
    Private Sub FishingTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FishingTimer.Tick
        If TClient.Paused Then Exit Sub
        If TClient.Self.Cap < 5 Then Exit Sub
        If Not EnableFishing.Checked Then Exit Sub
        If Not Fisher.IsBusy Then Fisher.RunWorkerAsync()
    End Sub

    Private Sub Fisher_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Fisher.DoWork
        Dim Rand As New System.Random
retry:
        Dim RandX As Integer = Rand.Next(-7, 7)
        Dim Randy As Integer = Rand.Next(-5, 5)

        Dim T As Integer = TClient.Map.GetTile(TClient.Self.X + RandX, TClient.Self.Y + Randy, TClient.Self.Z)
        Dim I As Integer = TClient.Map.GetTileObjectId(T, 0)
        If 4597 <= I AndAlso I <= 4602 Then
            If I < 100 Then GoTo retry
            TClient.Self.UseItemWithGround(TClient.Self.X + RandX, TClient.Self.Y + Randy, TClient.Self.Z, _
            FishingRod, I, 0)
        Else
            GoTo retry
        End If
    End Sub
#End Region

    Private Sub FrameRate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrameRate.CheckedChanged

    End Sub

    Private Sub FrameRateTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrameRateTimer.Tick
        If IsIconic(TClient.Handle) And FrameRate.Checked Then
            TClient.Screen.Framerate(True)
        Else
            TClient.Screen.Framerate(False)
        End If
    End Sub

    Private Sub ShowIds_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowIds.CheckedChanged
        TClient.ShowLookIDS = ShowIds.Checked
    End Sub

    Private Sub AutoStack_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoStack.CheckedChanged
        GlobalVariables.autoStack = AutoStack.Checked
    End Sub

End Class