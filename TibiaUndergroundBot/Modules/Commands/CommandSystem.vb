Public Module CommandSystem
    Public Delegate Sub CmdExec(ByVal Runner As CommandRunner, ByVal Command As String, ByVal CheckThread As Boolean)
    Public CommandText As New List(Of String)
    Public CommandLoop As Integer = 0
    Public Delegate Function CommandCallback(ByVal Args As String()) As String
    Public CommandFunctions As New Dictionary(Of String, CommandCallback)
    Public FlagFunctions As New Dictionary(Of String, CommandCallback)

    Public Sub InitializeCommands()
        CommandFunctions.Add("say", New CommandCallback(AddressOf Say))
        CommandFunctions.Add("use", New CommandCallback(AddressOf Use))
        CommandFunctions.Add("exivalast", New CommandCallback(AddressOf ExivaLast))

        CommandFunctions.Add("spyup", New CommandCallback(AddressOf SpyUp))
        CommandFunctions.Add("spydown", New CommandCallback(AddressOf SpyDown))
        CommandFunctions.Add("spyclear", New CommandCallback(AddressOf SpyClear))

        CommandFunctions.Add("togglelooter", New CommandCallback(AddressOf ToggleLooter))
        CommandFunctions.Add("toggleattacker", New CommandCallback(AddressOf ToggleAttacker))
        CommandFunctions.Add("togglewalker", New CommandCallback(AddressOf ToggleWalker))

        CommandFunctions.Add("toggleidle", New CommandCallback(AddressOf ToggleIdle))
        CommandFunctions.Add("togglelight", New CommandCallback(AddressOf ToggleLight))
        CommandFunctions.Add("togglexray", New CommandCallback(AddressOf ToggleXRay))

        CommandFunctions.Add("pause", New CommandCallback(AddressOf Pause))
        CommandFunctions.Add("displaybot", New CommandCallback(AddressOf DisplayBot))

        CommandFunctions.Add("caveadd", New CommandCallback(AddressOf CaveAdd))

        CommandFunctions.Add("sprinteast", New CommandCallback(AddressOf DaskEast))
        CommandFunctions.Add("sprintwest", New CommandCallback(AddressOf DaskWest))
        CommandFunctions.Add("sprintnorth", New CommandCallback(AddressOf DaskNorth))
        CommandFunctions.Add("sprintsouth", New CommandCallback(AddressOf DaskSouth))

        CommandFunctions.Add("sendkeys", New CommandCallback(AddressOf SendKeys))
        CommandFunctions.Add("dequip", New CommandCallback(AddressOf Dequip))
        CommandFunctions.Add("equip", New CommandCallback(AddressOf Equip))
        CommandFunctions.Add("drop", New CommandCallback(AddressOf Drop))
        CommandFunctions.Add("openbp", New CommandCallback(AddressOf OpenBp))


        FlagFunctions.Add("-targethealthpercabove", New CommandCallback(AddressOf TargetHealthPercAbove))
        FlagFunctions.Add("-targhppcabv", New CommandCallback(AddressOf TargetHealthPercAbove))

        FlagFunctions.Add("-targethealthpercbelow", New CommandCallback(AddressOf TargetHealthPercBelow))
        FlagFunctions.Add("-targhppcblw", New CommandCallback(AddressOf TargetHealthPercBelow))

        FlagFunctions.Add("-hastarget", New CommandCallback(AddressOf HasTarget))

        FlagFunctions.Add("-healthpercabove", New CommandCallback(AddressOf HealthPercAbove))
        FlagFunctions.Add("-hppcabv", New CommandCallback(AddressOf HealthPercAbove))

        FlagFunctions.Add("-healthpercbelow", New CommandCallback(AddressOf HealthPercBelow))
        FlagFunctions.Add("-hppcblw", New CommandCallback(AddressOf HealthPercBelow))

        FlagFunctions.Add("-healthbelow", New CommandCallback(AddressOf HealthBelow))
        FlagFunctions.Add("-hpblw", New CommandCallback(AddressOf HealthBelow))

        FlagFunctions.Add("-healthabove", New CommandCallback(AddressOf HealthAbove))
        FlagFunctions.Add("-hpabv", New CommandCallback(AddressOf HealthAbove))

        FlagFunctions.Add("-manapercabove", New CommandCallback(AddressOf ManaPercAbove))
        FlagFunctions.Add("-mppcabv", New CommandCallback(AddressOf ManaPercAbove))

        FlagFunctions.Add("-manapercbelow", New CommandCallback(AddressOf ManaPercBelow))
        FlagFunctions.Add("-mppcblw", New CommandCallback(AddressOf ManaPercBelow))

        FlagFunctions.Add("-manabelow", New CommandCallback(AddressOf ManaBelow))
        FlagFunctions.Add("-mpblw", New CommandCallback(AddressOf ManaBelow))

        FlagFunctions.Add("-manaabove", New CommandCallback(AddressOf ManaAbove))
        FlagFunctions.Add("-mpabv", New CommandCallback(AddressOf ManaAbove))

        FlagFunctions.Add("-magabove", New CommandCallback(AddressOf MagAbove))
        FlagFunctions.Add("-magbelow", New CommandCallback(AddressOf MagBelow))

        FlagFunctions.Add("-drunk", New CommandCallback(AddressOf drunk))
    End Sub

#Region "Display Command Text"
    Public Sub AddCommandText(ByVal text As String)
        CommandText.Add(text)
        UpdateCommandText()
    End Sub

    Public Sub RemoveCommandText(ByVal text As String)
        Try
            CommandText.Remove(text)
        Catch
        End Try
        UpdateCommandText()
    End Sub

    Private Sub UpdateCommandText()
        Dim YOff As Integer = 0
        TClient.Hook.RemoveText("autocmd")
        For Each S As String In CommandText
            TClient.Hook.AddText(False, "", "autocmd", S, 5, 5 + YOff, Color.LightBlue)
            YOff += 13
        Next
    End Sub
#End Region

    Private Function DoCommand(ByVal a As Action) As Boolean
        Dim CheckRet As String = String.Empty
        For Each f As Flag In a.Flags
            If f.Command.ToLower = "-auto" Then Continue For
            If f.Command.ToLower = "-showas" Then Continue For

            If FlagFunctions.ContainsKey(f.Command.ToLower) Then

                CheckRet = FlagFunctions(f.Command.ToLower).Invoke(f.Args.ToArray)

                If CheckRet <> String.Empty Then
                    If CheckRet = "false" Then Return False : Exit For
                    TClient.DisplayTextMessage(Client.TextMessageColor.Red, "[" & a.bname & "] " & CheckRet)
                    Return False
                End If
            Else
                TClient.DisplayTextMessage(Client.TextMessageColor.Red, "[" & a.bname & "] Flag """ & f.Command & """ not recognized.")
                Return False
            End If
        Next


        If CommandFunctions.Keys.Contains(a.Command.ToLower) Then
            Try
                CheckRet = CommandFunctions(a.Command.ToLower).Invoke(a.Args.ToArray)
            Catch
                TClient.DisplayTextMessage(Client.TextMessageColor.Red, "[" & a.bname & "] Command " & a.Command & ": Unknown Error!")
                Return False
            End Try

            If CheckRet <> String.Empty Then
                TClient.DisplayTextMessage(Client.TextMessageColor.Red, "[" & a.bname & "] " & CheckRet)
                Return False
            End If
        Else
            TClient.DisplayTextMessage(Client.TextMessageColor.Red, "[" & a.bname & "] Command """ & a.Command & """ not recognized.")
            Return False
        End If

        Return True
    End Function

    Private Function TestCommand(ByVal a As Action) As Boolean
        Dim CheckRet As String = String.Empty
        For Each f As Flag In a.Flags
            If f.Command.ToLower = "-auto" Then Continue For
            If f.Command.ToLower = "-showas" Then Continue For

            If Not FlagFunctions.ContainsKey(f.Command.ToLower) Then
                TClient.DisplayTextMessage(Client.TextMessageColor.Red, "[" & a.bname & "] Flag """ & f.Command & """ not recognized.")
                Return False
            End If
        Next


        If CommandFunctions.Keys.Contains(a.Command.ToLower) Then
            Return True
        Else
            TClient.DisplayTextMessage(Client.TextMessageColor.Red, "[" & a.bname & "] Command """ & a.Command & """ not recognized.")
            Return False
        End If

        Return True
    End Function

#Region "Execute commands"
    Public Function ExecuteCommand(ByVal Runner As CommandRunner, ByVal Command As String) As Dictionary(Of TimedThread, String)
        Dim Cmd As CommandParser = CommandParser.ParseCommand(Command)
        Dim Tempret As New Dictionary(Of TimedThread, String)

        For Each A As Action In Cmd.Actions
            A.bname = Runner.BindName
            Dim tempthread As TimedThread = Nothing
            Dim temptext As String = Runner.BindName & ": " & A.fullString

            Dim skip As Boolean = False

            For Each f As Flag In A.Flags

                If f.Command.ToLower = "-showas" Then
                    If f.Args.Count = 0 Then
                        TClient.DisplayTextMessage(Client.TextMessageColor.Red, "[" & Runner.BindName & "] Flag ""-ShowAs"": not enough args!")
                        For Each k As TimedThread In Tempret.Keys
                            RemoveCommandText(Tempret(k))
                            k.Pause()
                            k = Nothing
                        Next
                        Return Nothing
                    ElseIf f.Args.Count > 1 Then
                        TClient.DisplayTextMessage(Client.TextMessageColor.Red, "[" & Runner.BindName & "] Flag ""-ShowAs"": too many enough args!")
                        For Each k As TimedThread In Tempret.Keys
                            RemoveCommandText(Tempret(k))
                            k.Pause()
                            k = Nothing
                        Next
                        Return Nothing
                    End If

                    temptext = Runner.BindName & ": " & f.Args(0)
                End If

                If f.Command.ToLower = "-auto" Then
                    If f.Args.Count = 0 Then
                        TClient.DisplayTextMessage(Client.TextMessageColor.Red, "[" & Runner.BindName & "] Flag ""-Auto"": not enough args!")
                        For Each k As TimedThread In Tempret.Keys
                            RemoveCommandText(Tempret(k))
                            k.Pause()
                            k = Nothing
                        Next
                        Return Nothing
                    ElseIf f.Args.Count > 1 Then
                        TClient.DisplayTextMessage(Client.TextMessageColor.Red, "[" & Runner.BindName & "] Flag ""-Auto"": too many enough args!")
                        For Each k As TimedThread In Tempret.Keys
                            RemoveCommandText(Tempret(k))
                            k.Pause()
                            k = Nothing
                        Next
                        Return Nothing
                    End If

                    tempthread = New TimedThread(ParseInteger(f.Args(0)), New TimedThread.RunThreadDelegate(AddressOf DoCommand), False, A)
                End If
            Next

            If Not TestCommand(A) Then
                For Each k As TimedThread In Tempret.Keys
                    RemoveCommandText(Tempret(k))
                    k.Pause()
                    k = Nothing
                Next

                Return Nothing
            End If

            If tempthread IsNot Nothing Then
                AddCommandText(temptext)
                tempthread.Start()
                Tempret.Add(tempthread, temptext)
            Else
                DoCommand(A)
            End If
        Next

        If Tempret.Keys.Count = 0 Then Return Nothing
        Return Tempret

        'For Each F As Flag In Cmd.Flags
        '    If F.Command.ToLower = "-auto" Then
        '        If ParseInteger(F.Arg) > 199 Then
        '            If Not Runner.IsAuto Then
        '                Runner.Thread.Pause()
        '                Runner.Thread.TickTime = ParseInteger(F.Arg)
        '                Runner.ShowText()
        '                Runner.Thread.Start()
        '                Runner.IsAuto = True
        '                Exit Function
        '            End If
        '        Else
        '            TClient.DisplayTextMessage(Client.TextMessageColor.Red, String.Format("[{0}] Flag ""{1}"" must be followed by a number value which is {2} or greater.", Runner.BindName, F.Command, 1))
        '            Runner.Thread.Pause()
        '            Runner.RemoveText()
        '            Exit Function
        '        End If
        '    End If
        'Next

        'For Each F As Flag In Cmd.Flags
        '    Select Case F.Command.ToLower
        '        Case "-safe"
        '            If Healing Then Exit Function
        '        Case "-hpbelow", "healthbelow"
        '            If ParseInteger(F.Arg) > 2 Then
        '                If Not TClient.Self.Health < ParseInteger(F.Arg) Then
        '                    Exit Function
        '                End If
        '            Else
        '                FlagRunnerError(Runner, F.Command, 2)
        '                Exit Function
        '            End If
        '        Case "-manabelow"
        '            If ParseInteger(F.Arg) > 2 Then
        '                If Not TClient.Self.Mana < ParseInteger(F.Arg) Then
        '                    Exit Function
        '                End If
        '            Else
        '                FlagRunnerError(Runner, F.Command, 2)
        '                Exit Function
        '            End If
        '        Case "-hpabove", "-healthabove"
        '            If ParseInteger(F.Arg) > 1 Then
        '                If Not TClient.Self.Health > ParseInteger(F.Arg) Then
        '                    Exit Function
        '                End If
        '            Else
        '                FlagRunnerError(Runner, F.Command, 1)
        '                Exit Function
        '            End If
        '        Case "-manaabove"
        '            If ParseInteger(F.Arg) > 1 Then
        '                If Not TClient.Self.Mana > ParseInteger(F.Arg) Then
        '                    Exit Function
        '                End If
        '            Else
        '                FlagRunnerError(Runner, F.Command, 1)
        '                Exit Function
        '            End If
        '        Case "-magbelow"
        '            If ParseInteger(F.Arg) > 1 Then
        '                If Not TClient.Self.MagicLevel > ParseInteger(F.Arg) Then
        '                    Exit Function
        '                End If
        '            Else
        '                FlagRunnerError(Runner, F.Command, 1)
        '                Exit Function
        '            End If
        '        Case "-magabove"
        '            If ParseInteger(F.Arg) > 1 Then
        '                If Not TClient.Self.MagicLevel > ParseInteger(F.Arg) Then
        '                    Exit Function
        '                End If
        '            Else
        '                FlagRunnerError(Runner, F.Command, 1)
        '                Exit Function
        '            End If
        '        Case "-auto"

        '        Case Else
        '            TClient.DisplayTextMessage(Client.TextMessageColor.Red, String.Format("[{0}] Flag ""{1}"" is not recognized.", Runner.BindName, F.Command))
        '            Runner.Thread.Pause()
        '            Runner.RemoveText()
        '    End Select
        'Next

        'For Each C As Action In Cmd.Actions
        '    If CommandFunctions.Keys.Contains(C.Command.ToLower) Then
        '        Try
        '            CmdRet = CommandFunctions(C.Command.ToLower).Invoke(C.Args.ToArray)
        '        Catch
        '            TClient.DisplayTextMessage(Client.TextMessageColor.Red, "[" & Runner.BindName & "] Command " & C.Command & ": Unknown Error!")
        '            Runner.Thread.Pause()
        '            Runner.RemoveText()
        '            Exit Function
        '        End Try

        '        If CmdRet <> String.Empty Then
        '            TClient.DisplayTextMessage(Client.TextMessageColor.Red, "[" & Runner.BindName & "] " & CmdRet)
        '            Runner.Thread.Pause()
        '            Runner.RemoveText()
        '            Exit Function
        '        End If
        '    Else
        '        TClient.DisplayTextMessage(Client.TextMessageColor.Red, "[" & Runner.BindName & "] Command """ & C.Command & """ not recognized.")
        '        Runner.Thread.Pause()
        '        Runner.RemoveText()
        '        Exit Function
        '    End If
        'Next
    End Function
#End Region

#Region "Command functions"
    Private Function Say(ByVal args As String()) As String
        If args.Length = 0 Then
            Return "Command ""Say"": not enough args!"
        ElseIf args.Length > 1 Then
            Return "Command ""Say"": too many args!"
        End If

        TClient.Self.Say(FormatSpell(args(0)))
        Return String.Empty
    End Function

    Public Function Use(ByVal args As String()) As String
        If args.Length < 1 Then
            Return "Command ""Use"": not enough args!"
        ElseIf args.Length > 2 Then
            Return "Command ""Use"": too many args!"
        End If

        If args.Length = 2 Then
            If ParseShort(FormatItem(args(1))) < 100 Then
                Return "Command ""Use"": arg """ & args(1) & """ must be an integer value greater than 99, or an item shortcut."
            End If

            Select Case args(0).ToLower
                Case "self"
                    TClient.Self.UseItemWithCreature(ParseShort(FormatItem(args(1))), TClient.Self.Id)
                Case "target"
                    TClient.Self.UseItemWithCreature(ParseShort(FormatItem(args(1))), TClient.Self.Target)
                Case Else
                    'TClient.Self.UseItemWithCreature(ParseShort(FormatItem(args(1))), TClient.Battlelist.ID(args(0)))
                    Return "Command ""Use"": arg """ & args(0) & """ is invalid for parameter 1. Please use ""Self"" or ""Target""."
            End Select
        ElseIf args.Length = 1 Then
            If ParseShort(FormatItem(args(0))) < 100 Then
                Return "Command ""Use"": arg """ & args(0) & """ is invalid for parameter 1. Please enter and item ID or shortcut."
            End If
            TClient.Self.UseItem(ParseShort(FormatItem(args(0))))
        Else
            Return "Command ""Use"": invalid amount of args!"
        End If

        Return String.Empty
    End Function

    Public Function ExivaLast(ByVal args As String()) As String
        If TClient.LastExiva = String.Empty Then
            Return "Command ""Exivalast"": You must manually exiva a player before activating this command!"
        End If
        TClient.Self.Say("Exiva """ & TClient.LastExiva)
        Return String.Empty
    End Function

#Region "spy"
    Public Function SpyUp(ByVal args As String()) As String
        TClient.Screen.LevelSpyUp()
        Return String.Empty
    End Function

    Public Function SpyDown(ByVal args As String()) As String
        TClient.Screen.LevelSpyDown()
        Return String.Empty
    End Function

    Public Function SpyClear(ByVal args As String()) As String
        TClient.Screen.LevelSpyCenter()
        Return String.Empty
    End Function
#End Region

#Region "toggle"
    Public Function ToggleLooter(ByVal args As String()) As String
        TClient.ToggleFunction(Client.ToggleFuncs.Looter)
        Return String.Empty
    End Function

    Public Function ToggleAttacker(ByVal args As String()) As String
        TClient.ToggleFunction(Client.ToggleFuncs.Attacker)
        Return String.Empty
    End Function

    Public Function ToggleWalker(ByVal args As String()) As String
        TClient.ToggleFunction(Client.ToggleFuncs.Walker)
        Return String.Empty
    End Function

    Public Function ToggleIdle(ByVal args As String()) As String
        TClient.ToggleFunction(Client.ToggleFuncs.Idle)
        Return String.Empty
    End Function

    Public Function ToggleLight(ByVal args As String()) As String
        TClient.ToggleFunction(Client.ToggleFuncs.Light, Not TClient.Screen.LightEnabled)
        Return String.Empty
    End Function

    Public Function ToggleXRay(ByVal args As String()) As String
        TClient.ToggleFunction(Client.ToggleFuncs.XRay, Not TClient.Screen.XRayEnabled)
        Return String.Empty
    End Function

    Public Function Pause(ByVal args As String()) As String
        TClient.Paused = Not TClient.Paused

        If TClient.Paused Then
            TClient.Self.StopMoving()
            TClient.ShowStatusMessage("TUGBot -> All Automatic Actions Paused", 50)
        Else
            TClient.ShowStatusMessage("TUGBot -> All Automatic Actions Resumed", 50)
        End If

        Return String.Empty
    End Function

    Public Function DisplayBot(ByVal args As String()) As String
        Main.Visible = Not Main.Visible
        Return String.Empty
    End Function
#End Region

    Public Function CaveAdd(ByVal args As String()) As String
        If args.Length < 1 Then
            Return "Command ""CaveAdd"": not enough args! Commands have changed in the past updates, make sure that your parameter is wrapped in quotation marks! Example: CaveAdd ""Ground"""
        ElseIf args.Length > 2 Then
            Return "Command ""CaveAdd"": too many args!"
        End If
        Return CavebotWalker.add(args(0))
    End Function

#Region "dash"
    Private Delegate Sub DP(ByVal p As Byte())
    Dim MPack As New DP(AddressOf DelayPacket)
    Public Dashwarned As Boolean = False
    Public Function DaskEast(ByVal args As String()) As String
        Warndash()
        TClient.Hook.SendPacketToServer(New Byte() {OutgoingPacketType.MoveRight})
        MPack.BeginInvoke(New Byte() {OutgoingPacketType.MoveRight}, Nothing, Nothing)
        Return String.Empty
    End Function

    Public Function DaskWest(ByVal args As String()) As String
        Warndash()
        TClient.Hook.SendPacketToServer(New Byte() {OutgoingPacketType.MoveLeft})
        MPack.BeginInvoke(New Byte() {OutgoingPacketType.MoveLeft}, Nothing, Nothing)
        Return String.Empty
    End Function

    Public Function DaskNorth(ByVal args As String()) As String
        Warndash()
        TClient.Hook.SendPacketToServer(New Byte() {OutgoingPacketType.MoveUp})
        MPack.BeginInvoke(New Byte() {OutgoingPacketType.MoveUp}, Nothing, Nothing)
        Return String.Empty
    End Function

    Public Function DaskSouth(ByVal args As String()) As String
        Warndash()
        TClient.Hook.SendPacketToServer(New Byte() {OutgoingPacketType.MoveDown})
        MPack.BeginInvoke(New Byte() {OutgoingPacketType.MoveDown}, Nothing, Nothing)
        Return String.Empty
    End Function

    Private Sub Warndash()
        If Not Dashwarned Then
            TClient.DisplayTextMessage(Client.TextMessageColor.Red, "Its is believed that Sprint is one of the most easily detected functions, so use it at your own risk. It may increase the possibility of getting banned.")
            Dashwarned = True
        End If
    End Sub

    Private Sub DelayPacket(ByVal p As Byte())

        For i = 1 To 3
            Threading.Thread.Sleep(50)
            TClient.Hook.SendPacketToServer(p)
        Next
    End Sub
#End Region

    Public Function OpenBp(ByVal args As String()) As String
        TClient.Hook.OpenMainBackpack()
        Return String.Empty
    End Function

    Public Function Drop(ByVal args As String()) As String
        If args.Length < 1 Then
            Return "Command ""Drop"": not enough args!"
        ElseIf args.Length > 1 Then
            Return "Command ""Drop"": too many args!"
        End If

        Dim Slot As Slots = Nothing
        Dim ID As Short = 0
        Select Case args(0).ToLower
            Case "head", "helmet"
                Slot = Slots.Head
            Case "ammy", "neck", "amulet"
                Slot = Slots.Amulet
            Case "bp", "backpack", "back"
                Slot = Slots.Backpack
            Case "body", "armor", "arm"
                Slot = Slots.Body
            Case "legs", "pants"
                Slot = Slots.Legs
            Case "feet", "boots"
                Slot = Slots.Feet
            Case "ring"
                Slot = Slots.Ring
            Case "right", "righthand", "right hand"
                Slot = Slots.RightHand
            Case "left", "lefthand", "left hand"
                Slot = Slots.LeftHand
            Case "ammo", "arrow"
                Slot = Slots.Ammo
            Case Else
                ID = FormatItem(args(0))
        End Select

        If Slot = Nothing Then
            If ID > 99 Then
                Dim Item As ContainerItem
                For i As Byte = 1 To 16
                    If TClient.Containers(i).IsOpen = 1 Then
                        For a = 1 To TClient.Containers(i).NumberOfItems
                            Item = TClient.Containers(i).Item(a)
                            If Item Is Nothing Then Continue For
                            If Item.ID = ID Then
                                Item.MoveToGround(New Location(TClient.Self.X, TClient.Self.Y, TClient.Self.Z))
                                Return String.Empty
                            End If
                        Next
                    End If
                Next
            Else
                Return "Command ""Drop"": """ & args(1) & """ is invalid for parameter 2. Please specify an item id, shortcut, or eq slot name."
            End If
        Else
            ID = TClient.Self.SlotID(Slot)
            If ID > 99 Then
                TClient.Hook.MoveItem(ID, TClient.Self.SlotCount(Slot), ItemLocation.FromSlot(Slot), ItemLocation.FromLocation(New Location(TClient.Self.X, TClient.Self.Y, TClient.Self.Z)))
            End If
        End If

        Return String.Empty
    End Function

    Public Function Equip(ByVal args As String()) As String
        If args.Length < 2 Then
            Return "Command ""Dequip"": not enough args!"
        ElseIf args.Length > 3 Then
            Return "Command ""Dequip"": too many args!"
        End If

        Dim Slot As Slots
        Select Case args(0).ToLower
            Case "head", "helmet"
                Slot = Slots.Head
            Case "ammy", "neck", "amulet"
                Slot = Slots.Amulet
            Case "bp", "backpack", "back"
                Slot = Slots.Backpack
            Case "body", "armor", "arm"
                Slot = Slots.Body
            Case "legs", "pants"
                Slot = Slots.Legs
            Case "feet", "boots"
                Slot = Slots.Feet
            Case "ring"
                Slot = Slots.Ring
            Case "right", "righthand", "right hand"
                Slot = Slots.RightHand
            Case "left", "lefthand", "left hand"
                Slot = Slots.LeftHand
            Case "ammo", "arrow"
                Slot = Slots.Ammo
            Case Else
                Return "Command ""Dequip"": """ & args(0) & """ is invalid for parameter 1. Please use the name of an EQ slot."
        End Select


        If args.Length = 2 Then
            Dim Id As Short = FormatItem(args(1))
            If Id < 100 Then
                Return "Command ""Equip"": """ & args(1) & """ is invalid for parameter 2. Please specify an item id or shortcut."
            End If

            Dim Item As ContainerItem
            For i As Byte = 1 To 16
                If TClient.Containers(i).IsOpen = 1 Then
                    For a = 1 To TClient.Containers(i).NumberOfItems
                        Item = TClient.Containers(i).Item(a)
                        If Item Is Nothing Then Continue For
                        If Item.ID = Id Then
                            Item.MoveToSlot(Slot)
                            Return String.Empty
                        End If
                    Next
                End If
            Next
        Else
            Dim Id As Short = FormatItem(args(1))
            If Id < 100 Then
                Return "Command ""Equip"": """ & args(1) & """ is invalid for parameter 2. Please specify an item id or shortcut."
            End If

            Dim i As Short = ParseShort(args(2))
            If i = 0 OrElse i > 16 Then
                Return "Command ""Equip"": """ & args(1) & """ is invalid for parameter 2. Please specify a number between 1 and 16."
            End If

            Dim Item As ContainerItem

            If TClient.Containers(i).IsOpen = 1 Then
                For a = 1 To TClient.Containers(i).NumberOfItems
                    Item = TClient.Containers(i).Item(a)
                    If Item Is Nothing Then Continue For
                    If Item.ID = Id Then
                        Item.MoveToSlot(Slot)
                        Return String.Empty
                    End If
                Next
            Else
                Return "Command ""Equip"": container " & i & " is not open!"
            End If
        End If


        Return String.Empty
    End Function

    Public Function Dequip(ByVal args As String()) As String
        If args.Length < 2 Then
            Return "Command ""Dequip"": not enough args!"
        ElseIf args.Length > 2 Then
            Return "Command ""Dequip"": too many args!"
        End If

        Dim Slot As Slots
        Select Case args(0).ToLower
            Case "head", "helmet"
                Slot = Slots.Head
            Case "ammy", "neck", "amulet"
                Slot = Slots.Amulet
            Case "bp", "backpack", "back"
                Slot = Slots.Backpack
            Case "body", "armor", "arm"
                Slot = Slots.Body
            Case "legs", "pants"
                Slot = Slots.Legs
            Case "feet", "boots"
                Slot = Slots.Feet
            Case "ring"
                Slot = Slots.Ring
            Case "right", "righthand", "right hand"
                Slot = Slots.RightHand
            Case "left", "lefthand", "left hand"
                Slot = Slots.LeftHand
            Case "ammo", "arrow"
                Slot = Slots.Ammo
            Case Else
                Return "Command ""Dequip"": """ & args(0) & """ is invalid for parameter 1. Please use the name of an EQ slot."
        End Select

        If ParseShort(args(1)) = 0 OrElse ParseShort(args(1)) > 16 Then
            Return "Command ""Dequip"": """ & args(1) & """ is invalid for parameter 2. Please specify a number between 1 and 16."
        End If

        If TClient.Containers(ParseShort(args(1))).IsOpen Then
            Dim Id As Short = TClient.Self.SlotID(Slot)
            If Id > 99 Then
                TClient.Hook.MoveItem(Id, TClient.Self.SlotCount(Slot), ItemLocation.FromSlot(Slot), ItemLocation.FromContainer(ParseShort(args(1)) - 1, 0))
            End If
        Else
            Return "Command ""Dequip"": container " & ParseShort(args(1)) & " is not open!"
        End If

        Return String.Empty
    End Function

    Public Function SendKeys(ByVal args As String()) As String
        If GetForegroundWindow = TClient.Handle Then
            Try
                System.Windows.Forms.SendKeys.SendWait(args(0))
            Catch ex As Exception
                Return "Command ""SendKeys"":" & ex.ToString
            End Try
        Else
            Dim window As IntPtr = GetForegroundWindow
            SetForegroundWindow(TClient.Handle)
            Try
                While Not GetForegroundWindow = TClient.Handle
                    System.Threading.Thread.Sleep(2)
                End While
                System.Windows.Forms.SendKeys.SendWait(args(0))
            Catch ex As Exception
                SetForegroundWindow(window)
                Return "Command ""SendKeys"":" & ex.ToString
            End Try
            SetForegroundWindow(window)
        End If

        Return String.Empty
    End Function
#End Region

#Region "Flag functions"
    Public Function Drunk(ByVal args As String()) As String
        If args.Length = 0 Then
            Return "Flag ""-Drunk"": not enough args!"
        ElseIf args.Length > 1 Then
            Return "Command ""-TargetHealthPercAbove"": too many args!"
        End If

        If TClient.Self.HasTarget Then
            Dim pos As Integer = TClient.Battlelist.PosByID(TClient.Self.Target)
            If TClient.Battlelist.Health(pos) < ParseInteger(args(0)) Then Return "false"
        Else
            Return "false"
        End If

        Return String.Empty
    End Function

    Public Function TargetHealthPercAbove(ByVal args As String()) As String
        If args.Length = 0 Then
            Return "Flag ""-TargetHealthPercAbove"": not enough args!"
        ElseIf args.Length > 1 Then
            Return "Command ""-TargetHealthPercAbove"": too many args!"
        End If

        If TClient.Self.HasTarget Then
            Dim pos As Integer = TClient.Battlelist.PosByID(TClient.Self.Target)
            If TClient.Battlelist.Health(pos) < ParseInteger(args(0)) Then Return "false"
        Else
            Return "false"
        End If

        Return String.Empty
    End Function

    Public Function TargetHealthPercBelow(ByVal args As String()) As String
        If args.Length = 0 Then
            Return "Flag ""-TargetHealthPercBelow"": not enough args!"
        ElseIf args.Length > 1 Then
            Return "Command ""-TargetHealthPercBelow"": too many args!"
        End If

        If TClient.Self.HasTarget Then
            Dim pos As Integer = TClient.Battlelist.PosByID(TClient.Self.Target)
            If TClient.Battlelist.Health(pos) > ParseInteger(args(0)) Then Return "false"
        Else
            Return "false"
        End If

        Return String.Empty
    End Function

    Public Function HasTarget(ByVal args As String()) As String
        If args.Length > 1 Then
            Return "Command ""-HasTarget"": too many args!"
        End If

        If args.Length = 0 Then
            If Not TClient.Self.HasTarget Then Return "false"
        Else
            TClient.Battlelist.Cache()
            Dim pos As Integer = TClient.Battlelist.PosByID(TClient.Self.Target)
            If TClient.Battlelist.Name(pos).ToLower <> args(0).ToLower Then Return "false"
        End If

        Return String.Empty
    End Function

    Public Function HealthPercAbove(ByVal args As String()) As String
        If args.Length = 0 Then
            Return "Flag ""-HealthPercAbove"": not enough args!"
        ElseIf args.Length > 1 Then
            Return "Command ""-HealthPercAbove"": too many args!"
        End If

        If CalculatePercent(TClient.Self.MaxHealth, 100, TClient.Self.Health) < ParseShort(args(0)) Then Return "false"
        Return String.Empty
    End Function

    Public Function HealthPercBelow(ByVal args As String()) As String
        If args.Length = 0 Then
            Return "Flag ""-HealthPercBelow"": not enough args!"
        ElseIf args.Length > 1 Then
            Return "Command ""-HealthPercBelow"": too many args!"
        End If

        If CalculatePercent(TClient.Self.MaxHealth, 100, TClient.Self.Health) > ParseShort(args(0)) Then Return "false"
        Return String.Empty
    End Function

    Public Function HealthAbove(ByVal args As String()) As String
        If args.Length = 0 Then
            Return "Flag ""-HealthAbove"": not enough args!"
        ElseIf args.Length > 1 Then
            Return "Command ""-HealthAbove"": too many args!"
        End If

        If TClient.Self.Health < ParseShort(args(0)) Then Return "false"
        Return String.Empty
    End Function

    Public Function HealthBelow(ByVal args As String()) As String
        If args.Length = 0 Then
            Return "Flag ""-HealthBelow"": not enough args!"
        ElseIf args.Length > 1 Then
            Return "Command ""-HealthBelow"": too many args!"
        End If

        If TClient.Self.Health > ParseShort(args(0)) Then Return "false"
        Return String.Empty
    End Function

    Public Function ManaPercAbove(ByVal args As String()) As String
        If args.Length = 0 Then
            Return "Flag ""-ManaPercAbove"": not enough args!"
        ElseIf args.Length > 1 Then
            Return "Command ""-ManaPercAbove"": too many args!"
        End If

        If CalculatePercent(TClient.Self.MaxMana, 100, TClient.Self.Mana) < ParseShort(args(0)) Then Return "false"
        Return String.Empty
    End Function

    Public Function ManaPercBelow(ByVal args As String()) As String
        If args.Length = 0 Then
            Return "Flag ""-ManaPercBelow"": not enough args!"
        ElseIf args.Length > 1 Then
            Return "Command ""-ManaPercBelow"": too many args!"
        End If

        If CalculatePercent(TClient.Self.MaxMana, 100, TClient.Self.Mana) > ParseShort(args(0)) Then Return "false"
        Return String.Empty
    End Function

    Public Function ManaAbove(ByVal args As String()) As String
        If args.Length = 0 Then
            Return "Flag ""-ManaAbove"": not enough args!"
        ElseIf args.Length > 1 Then
            Return "Command ""-ManaAbove"": too many args!"
        End If

        If TClient.Self.Mana < ParseShort(args(0)) Then Return "false"
        Return String.Empty
    End Function

    Public Function ManaBelow(ByVal args As String()) As String
        If args.Length = 0 Then
            Return "Flag ""-ManaBelow"": not enough args!"
        ElseIf args.Length > 1 Then
            Return "Command ""-ManaBelow"": too many args!"
        End If

        If TClient.Self.Mana > ParseShort(args(0)) Then Return "false"
        Return String.Empty
    End Function

    Public Function MagBelow(ByVal args As String()) As String
        If args.Length = 0 Then
            Return "Flag ""-MagBelow"": not enough args!"
        ElseIf args.Length > 1 Then
            Return "Command ""-MagBelow"": too many args!"
        End If

        If TClient.Self.MagicLevel > ParseShort(args(0)) Then Return "false"
        Return String.Empty
    End Function

    Public Function MagAbove(ByVal args As String()) As String
        If args.Length = 0 Then
            Return "Flag ""-MagAbove"": not enough args!"
        ElseIf args.Length > 1 Then
            Return "Command ""-MagAbove"": too many args!"
        End If

        If TClient.Self.MagicLevel < ParseShort(args(0)) Then Return "false"
        Return String.Empty
    End Function

    Public Function Safe(ByVal args As String()) As String
        If args.Length = 0 Then
            Return "Flag ""-Safe"": not enough args!"
        ElseIf args.Length > 1 Then
            Return "Command ""-Safe"": too many args!"
        End If

        If Healing Then Return "false"
        Return String.Empty
    End Function




#End Region


End Module
