Imports System
Public NotInheritable Class Main
    Private WithEvents m_trayIcon As New System.Windows.Forms.NotifyIcon
    Private WithEvents TrayIconMenu As New ContextMenu

#Region "TUGBot menu"
    Private Sub HideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideToolStripMenuItem.Click
        Me.Visible = False
        HideWindows()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Dim Res As Microsoft.VisualBasic.MsgBoxResult = MsgBox("Closing TUGBot will also close the controlled Tibia client. Are you sure you want to proceed?", MsgBoxStyle.YesNo)

        If Res = MsgBoxResult.No Then
            Exit Sub
        End If

        m_trayIcon.Visible = False
        KillProcess(TClient.Process)
        End
    End Sub
#End Region

#Region "Tray Icon"
    Public Sub CMenuClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ClickedItem As MenuItem = CType(sender, MenuItem)
        'create the submenu based on whatever selection is being made, mnuSelection

        Select Case ClickedItem.Text
            Case "Hide TUGBot", "Show TUGBot"
                If Me.Visible Then
                    Me.Visible = False
                    HideWindows()
                Else
                    Me.Visible = True
                    Me.Refresh()
                End If
            Case "Hide Tibia", "Show Tibia"
                TClient.Visible = Not TClient.Visible
            Case "Close TUGBot"
                Dim Res As Microsoft.VisualBasic.MsgBoxResult = MsgBox("Closing TUGBot will also close the controlled Tibia client. Are you sure you want to proceed?", MsgBoxStyle.YesNo)

                If Res = MsgBoxResult.No Then
                    Exit Select
                End If

                m_trayIcon.Visible = False
                KillProcess(TClient.Process)
                TClient.Hook.UninjectHooks()
                End
            Case Else
        End Select

        ClickedItem = Nothing
    End Sub

    Private Sub m_trayIcon_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_trayIcon.DoubleClick
        If Me.Visible Then
            Me.Visible = False
        Else
            Me.Visible = True
            Me.Refresh()
        End If
    End Sub

    Private Sub TrayIconMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrayIconMenu.Popup
        TrayIconMenu.MenuItems.Clear()
        Dim newitem As MenuItem

        'Show/hide bot

        If TClient.Visible Then
            newitem = New MenuItem("Hide Tibia")
        Else
            newitem = New MenuItem("Show Tibia")
        End If

        AddHandler newitem.Click, AddressOf CMenuClick
        TrayIconMenu.MenuItems.Add(newitem)

        If Me.Visible Then
            newitem = New MenuItem("Hide TUGBot")
        Else
            newitem = New MenuItem("Show TUGBot")
        End If

        AddHandler newitem.Click, AddressOf CMenuClick
        TrayIconMenu.MenuItems.Add(newitem)

        'Close bot
        newitem = New MenuItem("Close TUGBot")
        AddHandler newitem.Click, AddressOf CMenuClick
        TrayIconMenu.MenuItems.Add(newitem)
    End Sub
#End Region

    Public Sub HideWindows()
        For Each fi As FormInfo In Forms
            fi.Form.Hide()
        Next
    End Sub

    Public Sub ClientClosed()
        m_trayIcon.Visible = False

        Application.Exit()
        Dim PCheck As Integer
        GetWindowThreadProcessId(Me.Handle, PCheck)
        KillProcess(PCheck)
    End Sub

    Public Sub ClientOpened()
        AddHandler TClient.ClientClosed, AddressOf ClientClosed
    End Sub

#Region "Initialize"
    Private Sub TitleTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TitleTimer.Tick
        SetTitle()

        'TClient.KeepDistance()
    End Sub

    Public Sub SetTitle()
        Me.Text = String.Format("TUGBot v" & Application.ProductVersion.Remove(Application.ProductVersion.Length - 2) & " [{0}]", TClient.Self.Name)

        If TClient.ReadInt(TClient.Addresses.Client.Connection) <> 8 Then
            If Icons.EnableButtons.Checked Then
                Icons.EnableButtons.Checked = False
            End If
        End If
    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If AutoUpdatesEnabled Then AutoUpdateYesNo.Checked = True

        'Client shit
        AddHandler TClient.ClientOpened, AddressOf ClientOpened
        'Attach the hook
        TClient.Attach()
        'Create Self
        TPlayer = New Self
        System.Threading.Thread.Sleep(1000)

        If TClient.Process = 0 Then MsgBox("Unknown error when trying to attach to the Tibia client", MsgBoxStyle.Critical) : End
        If Not HasInjectedDLL(TClient.Process) Then MsgBox(GlobalVariables.PipeError, MsgBoxStyle.Critical) : End


        SetTitle()
        'Load the bot
        Dim L As New Load

        FormBack = Me.BackColor
        ControlBack = Me.BackColor
        Textcolor = Me.ForeColor

        Me.Visible = False

        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()

        OpenWar.Enabled = False
        OpenWalker.Enabled = False
        OpenAttacker.Enabled = False
        OpenScripter.Enabled = False
        CheckForIllegalCrossThreadCalls = False

        If Not Registered AndAlso NotRegistered AndAlso Thirdcheck <> &HFF Then
            'Disable all premium features in there
        ElseIf Not Registered OrElse NotRegistered OrElse Thirdcheck <> &HFF Then
            MsgBox("It looks like you tried to crack TUGBot and you failed. Sorry, the program will close now")
            Application.Exit()
            End
        End If

        'Load
        L.Show()
        L.Refresh()


        'Load shortcuts and rets
        L.LoadLabel.Text = "Loading Shortcuts..."
        L.LoadLabel.Refresh()
        LoadShortcuts()
        InitializeRets()
        InitializeCommands()

        Threading.Thread.Sleep(120)
        'end

        'Load Forms
        ReDim Hotkey.Hotkey(0 To 16)
        For i = 0 To 16
            Hotkey.Hotkey(i) = New HotkeyStruct()
        Next
        LoadTUGBotForms(L)
        'end

        'Skin
        L.LoadLabel.Text = "Loading Skin..."
        L.LoadLabel.Refresh()

        If StartSkin <> "Default" And IO.File.Exists(StartSkin) Then
            LoadSkinFromFile(StartSkin)
        End If


        L.LoadLabel.Text = "Initializing Threads..."

        L.LoadLabel.Refresh()
        Threading.Thread.Sleep(1000)

        L.Visible = False
        L.Dispose()

        'Init Tray Icon
        m_trayIcon.Icon = Me.Icon
        m_trayIcon.Visible = True
        m_trayIcon.ContextMenu = TrayIconMenu

        'Close everything
        SettingExpand_Click(Nothing, Nothing)
        SettingNum_TabIndexChanged(Nothing, Nothing)
        'AdvExpand_Click(Nothing, Nothing)
        'CaveExpand_Click(Nothing, Nothing)
        'ShortExpand_Click(Nothing, Nothing)

        'Initialize the settings system thing
        InitializeSettings()
        'show me, hide form1
        Me.Visible = True
        Me.Invalidate()

        AddHandler TClient.KeyDown, AddressOf Client_KeyDown
        AddHandler TClient.KeyUp, AddressOf Client_KeyUp
        AddHandler TClient.KeyPress, AddressOf Client_KeyPress
        AddHandler TClient.MouseAction, AddressOf MouseAction

        'TClient.Hook.Send(TClient.Hook.SetConstant(&H44, Me.Handle))
        TitleTimer.Start()
        InjectCheck.Start()
    End Sub

#End Region

#Region "De-initialize"
    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub
#End Region

#Region "Handle Keystrokes"
    Public Delegate Sub HKDo()
    Public Sub Client_KeyDown(ByVal key As Keys)
        If GetForegroundWindow = TClient.Handle Then
            For Each H As HotkeyStruct In Hotkey.Hotkey
                If H.PressType = HotkeyPressType.Down OrElse H.PressType = HotkeyPressType.UpDown Then
                    If H.KeyCode = key AndAlso H.Ctrl = ControlPressed AndAlso H.Enabled Then
                        'H.InvokeCommand()
                        Me.Invoke(New HKDo(AddressOf H.InvokeCommand))
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub Client_KeyUp(ByVal key As Keys)
        If GetForegroundWindow = TClient.Handle Then
            For Each H As HotkeyStruct In Hotkey.Hotkey
                If H.PressType = HotkeyPressType.Up OrElse H.PressType = HotkeyPressType.UpDown Then
                    If H.KeyCode = key AndAlso H.Ctrl = ControlPressed AndAlso H.Enabled Then
                        'H.InvokeCommand()
                        Me.Invoke(New HKDo(AddressOf H.InvokeCommand))
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub Client_KeyPress(ByVal key As Keys)
        If GetForegroundWindow = TClient.Handle Then
            For Each H As HotkeyStruct In Hotkey.Hotkey
                If H.PressType = HotkeyPressType.Press Then
                    If H.KeyCode = key AndAlso H.Ctrl = ControlPressed AndAlso H.Enabled Then
                        'H.InvokeCommand()
                        Me.Invoke(New HKDo(AddressOf H.InvokeCommand))
                    End If
                End If
            Next
        End If
    End Sub

#End Region

#Region "Handle mouse"
    Dim AlreadyDragging As Boolean = False
    Public Delegate Sub MouseActionDel(ByVal key As Integer, ByVal x As Integer, ByVal y As Integer)
    Public Sub MouseAction(ByVal key As Integer, ByVal x As Integer, ByVal y As Integer)
        Me.BeginInvoke(New MouseActionDel(AddressOf _MouseAction), New Object() {key, x, y})
    End Sub

    Private Sub _MouseAction(ByVal key As Integer, ByVal x As Integer, ByVal y As Integer)
        If ButtonsEnabled Then
            'LEFTCLICKS
            If key = CInt(ClickType.LeftDown) AndAlso Not ShiftPressed Then
                'FixCoords(TClient.Handle, x, y)
                For Each B As ButtonStruct In Buttons
                    If B.RegionContains(x, y) Then
                        B.InvokeLeft()
                        TClient.Hook.AddText(True, "shad", "shad", FormatDisplayString(B.Text), B.LocationX + (ButtonSize / 2), B.LocationY + ButtonSize - 6, Color.White, False, True)
                        Exit For
                    End If
                Next
                'RIGHTCLICKS
            ElseIf key = CInt(ClickType.RightDown) AndAlso Not ShiftPressed Then
                'FixCoords(TClient.Handle, x, y)
                For Each B As ButtonStruct In Buttons
                    If B.RegionContains(x, y) Then
                        B.InvokeRight()
                        TClient.Hook.AddText(True, "shad", "shad", FormatDisplayString(B.Text), B.LocationX + (ButtonSize / 2), B.LocationY + ButtonSize - 6, Color.White, False, True)
                        Exit For
                    End If
                Next
                'MOVES
            ElseIf key = CInt(ClickType.LeftDown) AndAlso ShiftPressed Then

                For Each B As ButtonStruct In Buttons
                    If B.HasHover And B.Draggable Then
                        If Not AlreadyDragging Then
                            Dim NB As ButtonStruct = B
                            NB.IsDragging = True
                            AlreadyDragging = True
                            NB.DragX = UIntValue(x - B.LocationX)
                            NB.DragY = UIntValue(y - B.LocationY)
                            Buttons.Item(Buttons.IndexOf(B)) = NB
                            Exit For
                        End If
                    End If
                Next

            ElseIf key = CInt(ClickType.Move) Then
                For Each B As ButtonStruct In Buttons
                    If B.RegionContains(x, y) Then
                        'DRAG
                        If B.Draggable Then
                            If B.IsDragging AndAlso MouseLeftDown Then
                                Dim NB As ButtonStruct = B
                                NB.LocationX = UIntValue(x - B.DragX)
                                NB.LocationY = UIntValue(y - B.DragY)
                                NB.HasHover = False
                                Buttons.Item(Buttons.IndexOf(B)) = NB
                                TClient.Hook.RemoveText("shad")
                                AlreadyDragging = True
                                Call Icons.PrintButtonTimer_Tick(Nothing, Nothing)
                                Exit For
                            ElseIf B.IsDragging AndAlso (Not ShiftPressed OrElse Not MouseLeftDown) Then
                                Dim NB As ButtonStruct = B
                                NB.IsDragging = False
                                AlreadyDragging = False
                                NB.DragX = 0
                                NB.DragY = 0
                                Buttons.Item(Buttons.IndexOf(B)) = NB
                                Exit For
                            ElseIf AlreadyDragging Then
                                Continue For
                            End If
                        End If

                        'HOVER
                        If Not B.HasHover Then
                            Dim NB As ButtonStruct = B
                            NB.HasHover = True
                            Buttons.Item(Buttons.IndexOf(B)) = NB
                            TClient.Hook.AddText(False, "", "shad", FormatDisplayString(B.Text), B.LocationX + (ButtonSize / 2), B.LocationY + ButtonSize - 6, Color.White, False, True)
                            Exit Sub
                        Else
                            Exit Sub
                        End If
                    End If

                    If B.HasHover Then
                        'Remove the shadow
                        TClient.Hook.RemoveText("shad")
                        'Chage button hover status
                        Dim NB As ButtonStruct = B
                        NB.HasHover = False
                        Buttons.Item(Buttons.IndexOf(B)) = NB
                        Exit Sub
                    End If
                Next
            End If
        End If

    End Sub

    Public Sub FixCoords(ByVal client As IntPtr, ByRef x As Integer, ByRef y As Integer)
        Dim P As New Point
        P.X = x
        P.Y = y
        ScreenToClient(client, P)
        x = P.X
        y = P.Y
    End Sub

    Public Function UIntValue(ByVal value As Integer) As UInteger
        If value < 0 Then Return 0 Else Return value
    End Function

    Public Function InvertColor(ByVal c As System.Drawing.Color) As System.Drawing.Color
        Dim clr As Color = Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B)
        Return clr
    End Function
#End Region

#Region "Open windows"
    Public Delegate Sub OpenForm(ByVal owner As System.Windows.Forms.IWin32Window)

    Private Sub OpenToolsform(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenTools.Click, OpenHacks.Click
        If Not Tools.Visible Then
            Me.Invoke(New OpenForm(AddressOf Tools.Show), Me)
        End If
    End Sub

    Private Sub OpenMagicForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenMagic.Click, Button4.Click
        If Not Magic.Visible Then
            Me.Invoke(New OpenForm(AddressOf Magic.Show), Me)
        End If
    End Sub

    Private Sub OpenSupportForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenSupport.Click, Button6.Click
        If Not Support.Visible Then
            Me.Invoke(New OpenForm(AddressOf Support.Show), Me)
        End If
    End Sub

    Private Sub OpenWarForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenWar.Click, Button5.Click
        If Not War.Visible Then
            Me.Invoke(New OpenForm(AddressOf War.Show), Me)
        End If
    End Sub

    Private Sub OpenHUDForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenHUD.Click, Button2.Click
        If Not HeadsUpDisplay.Visible Then
            Me.Invoke(New OpenForm(AddressOf HeadsUpDisplay.Show), Me)
        End If
    End Sub

    Private Sub OpenIconsForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenIcons.Click, Button3.Click
        If Not Icons.Visible Then
            Me.Invoke(New OpenForm(AddressOf Icons.Show), Me)
        End If
    End Sub

    Private Sub OpenHotkeysForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenHotkeys.Click, Button8.Click
        If Not HotkeysForm.Visible Then
            Me.Invoke(New OpenForm(AddressOf HotkeysForm.Show), Me)
        End If
    End Sub

    Private Sub OpenScripterForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenScripter.Click, Button7.Click
        If Not Scripter.Visible Then
            Me.Invoke(New OpenForm(AddressOf Scripter.Show), Me)
        End If
    End Sub

    'cavebot
    Private Sub OpenWalkerForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenWalker.Click, Button9.Click
        If Not CavebotWalker.Visible Then
            Me.Invoke(New OpenForm(AddressOf CavebotWalker.Show), Me)
        End If
    End Sub

    Private Sub OpenAttackerForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenAttacker.Click, Button11.Click
        If Not CaveBotAttacker.Visible Then
            Me.Invoke(New OpenForm(AddressOf CaveBotAttacker.Show), Me)
        End If
    End Sub

    Private Sub OpenLooterForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        If Not CavebotLooter.Visible Then
            Me.Invoke(New OpenForm(AddressOf CavebotLooter.Show), Me)
        End If
    End Sub

    Private Sub ViewProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewProfile.Click
        If Not Profile.Visible Then
            Me.Invoke(New OpenForm(AddressOf Profile.Show), Me)
        End If
    End Sub

    Private Sub OpenNavForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If Not Navigation.Visible Then
            Navigation.Show() 'Me.Invoke(New OpenForm(AddressOf Navigation.Show), Me)
        End If
    End Sub

    Private Sub OpenAlarmsForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenAlarms.Click
        If Not Alarms.Visible Then
            Me.Invoke(New OpenForm(AddressOf Alarms.Show), Me)
        End If
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        If Not Trainer.Visible Then
            Me.Invoke(New OpenForm(AddressOf Trainer.Show), Me)
        End If
    End Sub
#End Region

#Region "Load files to quickload menus"
    Private Sub QuickLoadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuickLoadToolStripMenuItem.Click
        'Ally/Enemy
        If System.IO.Directory.Exists(Application.StartupPath & "\Quickload\Teams") Then
            Dim D As String() = System.IO.Directory.GetFiles(Application.StartupPath & "\Quickload\Teams")
            AllyLoad.DropDownItems.Clear()
            EnemyLoad.DropDownItems.Clear()

            For Each S As String In D
                If S.EndsWith(".TBTL", StringComparison.OrdinalIgnoreCase) Then
                    AddHandler AllyLoad.DropDownItems.Add(S.Split("\")(UBound(S.Split("\")))).Click, AddressOf LoadAllyFile
                    AddHandler EnemyLoad.DropDownItems.Add(S.Split("\")(UBound(S.Split("\")))).Click, AddressOf LoadEnemyFile
                End If
            Next
        End If

        'Icons
        If System.IO.Directory.Exists(Application.StartupPath & "\Quickload\Icons") Then
            Dim D As String() = System.IO.Directory.GetFiles(Application.StartupPath & "\Quickload\Icons")
            IconLoad.DropDownItems.Clear()

            For Each S As String In D
                If S.EndsWith(".TBIC", StringComparison.OrdinalIgnoreCase) Then
                    AddHandler IconLoad.DropDownItems.Add(S.Split("\")(UBound(S.Split("\")))).Click, AddressOf LoadIconFile
                End If
            Next
        End If

        'Waypoints
        If System.IO.Directory.Exists(Application.StartupPath & "\Quickload\Waypoints") Then
            Dim D As String() = System.IO.Directory.GetFiles(Application.StartupPath & "\Quickload\Waypoints")
            IconLoad.DropDownItems.Clear()

            For Each S As String In D
                If S.EndsWith(".TBWP", StringComparison.OrdinalIgnoreCase) Then
                    AddHandler WaypointLoad.DropDownItems.Add(S.Split("\")(UBound(S.Split("\")))).Click, AddressOf LoadWaypointFile
                End If
            Next
        End If

        'Looter
        If System.IO.Directory.Exists(Application.StartupPath & "\Quickload\Loot") Then
            Dim D As String() = System.IO.Directory.GetFiles(Application.StartupPath & "\Quickload\Loot")
            IconLoad.DropDownItems.Clear()

            For Each S As String In D
                If S.EndsWith(".TBLT", StringComparison.OrdinalIgnoreCase) Then
                    AddHandler LooterLoad.DropDownItems.Add(S.Split("\")(UBound(S.Split("\")))).Click, AddressOf LoadLootFile
                End If
            Next
        End If

        'Attacker
        If System.IO.Directory.Exists(Application.StartupPath & "\Quickload\AdvacnedAttacker") Then
            Dim D As String() = System.IO.Directory.GetFiles(Application.StartupPath & "\Quickload\AdvacnedAttacker")
            IconLoad.DropDownItems.Clear()

            For Each S As String In D
                If S.EndsWith(".TBAT", StringComparison.OrdinalIgnoreCase) Then
                    AddHandler AttackerLoad.DropDownItems.Add(S.Split("\")(UBound(S.Split("\")))).Click, AddressOf LoadAttackFile
                End If
            Next
        End If
    End Sub

    Private Sub LoadAllyFile(ByVal sender As System.Object, ByVal e As System.EventArgs)
        War.AllyList.Items.Clear()
        ListLoad(Application.StartupPath & "\Quickload\Teams\" & CType(sender, System.Windows.Forms.ToolStripItem).Text, War.AllyList)
        War.UpdateMarks()
    End Sub
    Private Sub LoadEnemyFile(ByVal sender As System.Object, ByVal e As System.EventArgs)
        War.EnemyList.Items.Clear()
        ListLoad(Application.StartupPath & "\Quickload\Teams\" & CType(sender, System.Windows.Forms.ToolStripItem).Text, War.EnemyList)
        War.UpdateMarks()
    End Sub
    Private Sub LoadIconFile(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Icons.ButtonsList.Items.Clear()
        Icons.LoadButtons(Application.StartupPath & "\Quickload\Icons\" & CType(sender, System.Windows.Forms.ToolStripItem).Text)
    End Sub
    Private Sub LoadWaypointFile(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Icons.ButtonsList.Items.Clear()
        CavebotWalker.LoadWaypoints(Application.StartupPath & "\Quickload\Waypoints\" & CType(sender, System.Windows.Forms.ToolStripItem).Text)
    End Sub
    Private Sub LoadLootFile(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Icons.ButtonsList.Items.Clear()
        CavebotLooter.LoadLootFile(Application.StartupPath & "\Quickload\Loot\" & CType(sender, System.Windows.Forms.ToolStripItem).Text)
    End Sub
    Private Sub LoadAttackFile(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Icons.ButtonsList.Items.Clear()
        CaveBotAttacker.LoadAttackFile(Application.StartupPath & "\Quickload\AdvacnedAttacker\" & CType(sender, System.Windows.Forms.ToolStripItem).Text)
    End Sub
#End Region

    Dim FormBack As Color
    Dim Textcolor As Color
    Dim ControlBack As Color
    Private Sub RemoveSkin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveSkin.Click
        ApplySkin(Nothing, FormBack, ControlBack, 255, 255, Textcolor)

        If Not IO.File.Exists(Application.StartupPath & "\Config.ini") Then MsgBox("Cannot find Config.ini!", MsgBoxStyle.Critical, "Error!") : Exit Sub
        Dim Ini As New iniFile(Application.StartupPath & "\Config.ini")
        Ini.WriteString("TUGBot", "Skin", "Default")
    End Sub
    Private Sub LoadSkin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadSkin.Click
        If Not IO.File.Exists(Application.StartupPath & "\Config.ini") Then MsgBox("Cannot find Config.ini!", MsgBoxStyle.Critical, "Error!") : Exit Sub
        LoadFile.Title = "Load Skin"
        LoadFile.Filter = "TUGBot Skin File (*.Tsf)|*.Tsf"
        LoadFile.FileName = ""
        LoadFile.ShowDialog(Me)

        Dim Ini As New iniFile(Application.StartupPath & "\Config.ini")

        If LoadFile.FileName <> "" Then
            Ini.WriteString("TUGBot", "Skin", LoadFile.FileName)
            Dim asr As System.IAsyncResult = Me.BeginInvoke(LoadSkinFromFile, LoadFile.FileName)
            'Hide forms
            HideWindows()
            Me.Visible = False

            'end the skin application and reshow me
            Me.EndInvoke(asr)
            Me.Visible = True
        End If
    End Sub


#Region "Tabs/Panels"
    Private CurrentSettingNumber As Integer = 1
    Public Sub FixPanels()
        CavePanel.Top = PanelNextLoc(GenPanel)
        ShortPanel.Top = PanelNextLoc(CavePanel)
        AdvancedPanel.Top = PanelNextLoc(ShortPanel)

        Me.Size = New System.Drawing.Size(Me.Width, AdvancedPanel.Bottom + MenuStrip2.Height)
    End Sub

    Public Function PanelNextLoc(ByVal P As Panel) As Integer
        Return P.Bottom
    End Function

    Private Sub GenExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenExpand.Click
        If GenExpand.Tag = 1 Then
            GenPanel.Size = New System.Drawing.Size(GenPanel.Size.Width, GenExpand.Size.Height)
            GenExpand.Tag = 0
        Else
            GenPanel.Size = New System.Drawing.Size(GenPanel.Size.Width, 148)
            GenExpand.Tag = 1
        End If
        FixPanels()
    End Sub

    Private Sub CaveExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CaveExpand.Click
        If CaveExpand.Tag = 1 Then
            CavePanel.Size = New System.Drawing.Size(GenPanel.Size.Width, GenExpand.Size.Height)
            CaveExpand.Tag = 0
        Else
            CavePanel.Size = New System.Drawing.Size(GenPanel.Size.Width, 148)
            CaveExpand.Tag = 1
        End If
        FixPanels()
    End Sub

    Private Sub ShortExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShortExpand.Click
        If ShortExpand.Tag = 1 Then
            ShortPanel.Size = New System.Drawing.Size(GenPanel.Size.Width, GenExpand.Size.Height)
            ShortExpand.Tag = 0
        Else
            ShortPanel.Size = New System.Drawing.Size(GenPanel.Size.Width, 98)
            ShortExpand.Tag = 1
        End If
        FixPanels()
    End Sub

    Private Sub AdvExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvExpand.Click
        If AdvExpand.Tag = 1 Then
            AdvancedPanel.Size = New System.Drawing.Size(GenPanel.Size.Width, GenExpand.Size.Height)
            AdvExpand.Tag = 0
        Else
            AdvancedPanel.Size = New System.Drawing.Size(GenPanel.Size.Width, 148)
            AdvExpand.Tag = 1
        End If
        FixPanels()
    End Sub

    Private Sub SettingExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingExpand.Click
        If SettingExpand.Tag = 1 Then
            SettingExpand.Tag = 0
            SettingExpand.Text = "Settings »"
            Me.Size = New System.Drawing.Size(243, Me.Height)
        Else
            SettingExpand.Tag = 1
            SettingExpand.Text = "Settings «"
            Me.Size = New System.Drawing.Size(427, Me.Height)
        End If
    End Sub

    Private Sub SaveSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveSettings.Click
        Dim udres As MsgBoxResult = MsgBox("Are you sure you want to overwrite your settings named" & SettingNames(SettingNum.SelectedIndex), MsgBoxStyle.YesNo)
        If udres = MsgBoxResult.No Then
            Exit Sub
        End If

        BotSettings.SaveSettings(CurrentSettingNumber)
    End Sub

    Private Sub LoadSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadSettings.Click
        BotSettings.LoadSettings(CurrentSettingNumber)
    End Sub

    Private Sub ClearSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearSettings.Click
        Dim udres As MsgBoxResult = MsgBox("Are you sure you want to clear your settings named" & SettingNames(SettingNum.SelectedIndex), MsgBoxStyle.YesNo)
        If udres = MsgBoxResult.No Then
            Exit Sub
        End If

        BotSettings.ClearSettings(CurrentSettingNumber)
    End Sub

    Private Sub SettingNum_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SettingNum.SelectedIndexChanged
        CurrentSettingNumber = SettingNum.SelectedIndex + 1
        ClearSettings.Text = "Clear " & SettingNames(SettingNum.SelectedIndex)
        SaveSettings.Text = "Save " & SettingNames(SettingNum.SelectedIndex)
        LoadSettings.Text = "Load " & SettingNames(SettingNum.SelectedIndex)
    End Sub


    Private Sub setSettingName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles setSettingName.Click
        If NewSetName.Text <> "" Then
            If Not IO.File.Exists(Application.StartupPath & "\Config.ini") Then MsgBox("Cannot find Config.ini!", MsgBoxStyle.Critical, "Error!") : End
            Dim Ini As New iniFile(Application.StartupPath & "\Config.ini")
            Ini.WriteString("TUGBot", "SettingName" & SettingNum.SelectedIndex, NewSetName.Text)
            SettingNames(SettingNum.SelectedIndex) = NewSetName.Text
            NewSetName.Text = ""
            SettingNum_TabIndexChanged(Nothing, Nothing)
        End If
    End Sub
#End Region

    Private Sub AutoUpdateYesNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoUpdateYesNo.CheckedChanged
        If Not IO.File.Exists(Application.StartupPath & "\Config.ini") Then MsgBox("Cannot find Config.ini!", MsgBoxStyle.Critical, "Error!") : End
        Dim Ini As New iniFile(Application.StartupPath & "\Config.ini")
        If AutoUpdateYesNo.Checked Then
            Ini.WriteString("TUGBot", "CheckForUpdates", "Yes")
        ElseIf Not AutoUpdateYesNo.Checked Then
            Ini.WriteString("TUGBot", "CheckForUpdates", "No")
        End If
    End Sub

    Private Sub LoginCheckYesNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginCheckYesNo.CheckedChanged
        If Not IO.File.Exists(Application.StartupPath & "\Config.ini") Then MsgBox("Cannot find Config.ini!", MsgBoxStyle.Critical, "Error!") : End
        Dim Ini As New iniFile(Application.StartupPath & "\Config.ini")
        If LoginCheckYesNo.Checked Then
            MsgBox("Disabling the login check may allow you to start the bot while logged in, but be warned that even though it is very rare, starting the bot while logged in can cause debugs.")
            Ini.WriteString("TUGBot", "DisableLoginCheck", "Yes")
        ElseIf Not LoginCheckYesNo.Checked Then
            Ini.WriteString("TUGBot", "DisableLoginCheck", "No")
        End If
    End Sub

    Private Sub InjectCheck_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InjectCheck.Tick


        If TClient.p.HasExited Then
            Application.Exit()
            End
        End If
#If DEBUG Then
            'Exit Sub
#End If

            'If LastInjectCheck = 0 Then
            '    TClient.Hook.InjectCheck()
            'Else
            '    Dim Lapse As Integer = GetTickCount - LastInjectCheck

            '    If Lapse > 2200 Then
            '        Dim Running As Integer = GetTickCount - BotStartTime
            '        If Running < 5000 Then
            '            For Each f As FormInfo In GlobalVariables.Forms
            '                f.Form.Hide()
            '            Next
            '            Me.Hide()
            '            MsgBox(PipeError)
            '            End
            '        Else
            '            For Each f As FormInfo In GlobalVariables.Forms
            '                f.Form.Hide()
            '            Next
            '            Me.Hide()
            '            MsgBox("Critical error in pipe connection! Please contact DarkstaR as give him the following code: 0x01: " & CInt(Running / 1000))
            '            End
            '        End If
            '    Else
            '        TClient.Hook.InjectCheck()
            '    End If
    End Sub
End Class
