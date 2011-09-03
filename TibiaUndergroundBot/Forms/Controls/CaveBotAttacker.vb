Public Class CaveBotAttacker
    Public LastTarget As UInt32
    Public LastTargetTime As Integer
    Public TargetHealthPerc As Byte

    Public IgnoreCreatures As New List(Of Int32)
    Public NPCS As New List(Of Int32)

    'Public AllEnabled As Boolean = True
    'Public PriorityEnabled As Boolean = False
    'Public AttackBitch As Boolean = False


    Public CurrentFollow As Boolean = False
    Public DoFollow As Boolean = True

    Private Sub CaveBotAttacker_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        e.Cancel = True
    End Sub

    Private Sub CaveBotAttacker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Visible = False
        Me.Refresh()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()

        TargetList.Items.Add(New AdvancedTarget("Other Creatures"))


        AddHandler TClient.CreatureAttacking, AddressOf Attacked
        'AddHandler TClient.TryAttack, AddressOf TryAttack
        AddHandler TClient.FunctionToggled, AddressOf Toggled
    End Sub

#Region "Toggle"
    Public Sub Toggled(ByVal Type As Client.ToggleFuncs, ByVal OnOff As Boolean)
        If Type = Client.ToggleFuncs.Attacker Then
            EnableAttacker.Checked = Not EnableAttacker.Checked
        End If
    End Sub
#End Region

    Public Function Check() As String
        If Not EnableAttacker.Checked Then Return "Off"
        Return "On"
    End Function

#Region "Attacker"

    Public Sub Attacked(ByVal CreatureID As Integer)
        If Not TClient.Self.HasTarget AndAlso EnableAggresive.Checked AndAlso EnableAttacker.Checked Then
            FoundCreatureToAttack(CreatureID)

            If Not TClient.Paused Then
                If Not CurrentlyLooting() AndAlso EnableFollow.Checked Then
                    TClient.Hook.Follow()
                End If
            End If
        End If
    End Sub

    Public Sub FoundCreatureToAttack(ByVal ID As Integer)
        If Not TClient.Paused Then
            TClient.Battlelist.Cache()
            Dim Pos As Integer = TClient.Battlelist.PosByID(ID)

            If Pos <> 0 Then
                If CurrentlyLooting() Then
                    If Not TClient.Self.IsAdjecentTo(TClient.Battlelist.X(Pos), TClient.Battlelist.Y(Pos), TClient.Battlelist.Z(Pos)) Then
                        Exit Sub
                    End If
                End If
            Else
                If CurrentlyLooting() Then Exit Sub
            End If


            'If DoFollow Then TClient.Hook.Follow()
            TClient.Self.Attack(ID)
            LastTargetTime = GetTickCount : LastTarget = ID : TargetHealthPerc = TClient.Battlelist.Health(Pos)

            If Pos <> 0 Then
                TClient.TargetPosition = New Location(TClient.Battlelist.X(Pos), TClient.Battlelist.Y(Pos), TClient.Battlelist.Z(Pos))
            End If
        End If
    End Sub

    Private Sub TargettingTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TargettingTimer.Tick
        If TargettingTimer.Interval = 666 Then TargettingTimer.Interval = 1600 : Exit Sub
        TargettingTimer.Interval = 1000
        If EnableAttacker.Checked AndAlso TClient.Status = 8 Then

            TClient.Battlelist.Cache()
            If EnableAll.Checked Then
                TargetAll()

                If Not TClient.Paused Then
                    If Not CurrentlyLooting() AndAlso EnableFollow.Checked Then
                        TClient.Hook.Follow()
                    End If
                End If
            ElseIf EnableAdvanced.Checked Then
                If CurrentFollow And Not TClient.Paused Then
                    TClient.Hook.Follow()
                End If
                TargetPriority()
            End If

            If TClient.Self.HasTarget(False) Then

                If TClient.CurrentStatusMessage.ToLower.Contains("you may not attack this person") Then
                    TClient.ShowStatusMessage("", 0)
                    If Not NPCS.Contains(TClient.Self.Target) Then
                        NPCS.Add(TClient.Self.Target)
                        TClient.WriteInt(TClient.Addresses.Player.Target, 0)
                    End If
                End If

                Try
                    If EnableTimeout.Checked Then
                        If GetTickCount - LastTargetTime > Timeout.Value * 1000 AndAlso TClient.Self.Target = LastTarget Then
                            Dim pos As Integer = TClient.Battlelist.PosByID(TClient.Self.Target)
                            If TClient.Battlelist.Health(pos) >= TargetHealthPerc - 3 Then
                                IgnoreCreatures.Add(LastTarget)
                                TClient.WriteInt(TClient.Addresses.Player.Target, 0)
                            End If
                        End If
                    End If
                Catch
                End Try

            End If
        End If
    End Sub

    Private Sub TryAttack()
        If EnableAttacker.Checked Then
            If EnableAll.Checked Then
                TargetAll()
            ElseIf EnableAdvanced.Checked Then
                TargetPriority()
            End If
        End If
    End Sub

#Region "Target All"
    Public Sub TargetAll()
        If Not TClient.Self.HasTarget(False) Then
            For Range As Integer = 1 To 5

                For i As Integer = 1 To TClient.Battlelist.Length
                    If Not TClient.Battlelist.IsPlayer(i) Then
                        If TClient.Battlelist.IsVisible(i, Range) Then
                            If Not IgnoreCreatures.Contains(TClient.Battlelist.ID(i)) AndAlso _
                            Not NPCS.Contains(TClient.Battlelist.ID(i)) Then
                                If TClient.Battlelist.Z(i) = TClient.Self.Z Then
                                    FoundCreatureToAttack(TClient.Battlelist.ID(i))
                                    Exit Sub
                                End If
                            End If
                        ElseIf Not TClient.Battlelist.IsVisible(i) Then 'Not visible, if its an ignore creature we'll remove it
                            If IgnoreCreatures.Contains(TClient.Battlelist.ID(i)) Then
                                IgnoreCreatures.Remove(TClient.Battlelist.ID(i))
                                Exit Sub
                            End If
                        End If
                    End If
                Next

            Next
        End If
    End Sub
#End Region

#Region "Priotity"
    Private Function NameContaines(ByVal name As String, ByVal names As String) As Boolean
        Dim S As String() = names.Split(",")

        For Each N As String In S
            If N.ToLower.Trim = name.ToLower Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Sub TargetPriority()
        If TClient.Self.HasTarget Then
            Dim Name As String = TClient.Battlelist.Name(TClient.Battlelist.PosByID(TClient.Self.Target))
            For Each tC As AdvancedTarget In TargetList.Items
                If NameContaines(Name, tC.Name) Then
                    CurrentStrikeSpell = tC.StrikeSpell
                    CurrentStrikeMana = tC.StrikeMana
                    CurrentStrikeHealthPercent = tC.StrikeHealth

                    CurrentRuneHealth = tC.RuneHealth
                    CurrentRuneID = FormatItem(tC.RuneID)

                    RuneStrikeType = tC.MagicType
                End If
            Next
        Else
            CurrentStrikeSpell = ""
            CurrentStrikeMana = 0
            CurrentStrikeHealthPercent = 0

            CurrentRuneHealth = 0
            CurrentRuneID = 0

            RuneStrikeType = MagicAttackType.None

            Dim LastHighestPriorityPos As Byte = 0
            Dim LastPriority As AttackPriority = AttackPriority.Ignore
            Dim IgnoreNames As String = ""
            Dim Follow As Boolean
            Dim ignoreOthers As Boolean = False
            For i As Integer = 1 To TClient.Battlelist.Length
                For Each t As AdvancedTarget In TargetList.Items

                    If t.Priority = AttackPriority.Ignore Then
                        If t.Name.ToLower = "other creatures" Then
                            ignoreOthers = True
                        Else
                            IgnoreNames += t.Name & ","
                        End If
                    End If

                    If NameContaines(TClient.Battlelist.Name(i), t.Name) Then

                        If Not TClient.Battlelist.IsPlayer(i) AndAlso TClient.Battlelist.IsVisible(i) Then
                            If Math.Abs(TClient.Battlelist.X(i) - TClient.Self.X) <= t.Proximity AndAlso Math.Abs(TClient.Battlelist.Y(i) - TClient.Self.Y) <= t.Proximity Then

                                If Not IgnoreCreatures.Contains(TClient.Battlelist.ID(i)) AndAlso _
                                Not NPCS.Contains(TClient.Battlelist.ID(i)) Then
                                    If t.Priority > LastPriority Then
                                        CurrentStrikeSpell = t.StrikeSpell
                                        CurrentStrikeMana = t.StrikeMana
                                        CurrentStrikeHealthPercent = t.StrikeHealth

                                        CurrentRuneHealth = t.RuneHealth
                                        CurrentRuneID = FormatItem(t.RuneID)

                                        RuneStrikeType = t.MagicType


                                        LastPriority = t.Priority

                                        Follow = (t.FollowMode = FollowMode.Follow)
                                        LastHighestPriorityPos = i
                                        CurrentFollow = Follow
                                    End If
                                End If

                            End If
                        End If

                    End If
                Next
            Next

            If LastHighestPriorityPos <> 0 Then
                TClient.Hook.Follow(Follow)
                FoundCreatureToAttack(TClient.Battlelist.ID(LastHighestPriorityPos))
                Exit Sub
            ElseIf Not ignoreOthers Then
                For Each tsC As AdvancedTarget In TargetList.Items
                    If tsC.Name.ToLower = "other creatures" Then
                        CurrentStrikeSpell = tsC.StrikeSpell
                        CurrentStrikeMana = tsC.StrikeMana
                        CurrentStrikeHealthPercent = tsC.StrikeHealth

                        CurrentRuneHealth = tsC.RuneHealth
                        CurrentRuneID = FormatItem(tsC.RuneID)

                        RuneStrikeType = tsC.MagicType
                        Follow = (tsC.FollowMode = FollowMode.Follow)
                        CurrentFollow = Follow
                        Exit For
                    End If
                Next

                For i As Integer = 1 To TClient.Battlelist.Length
                    If Not NameContaines(TClient.Battlelist.Name(i), IgnoreNames) Then
                        If Not TClient.Battlelist.IsPlayer(i) AndAlso TClient.Battlelist.IsVisible(i) Then
                            If Not IgnoreCreatures.Contains(TClient.Battlelist.ID(i)) AndAlso _
                               Not NPCS.Contains(TClient.Battlelist.ID(i)) Then
                                TClient.Hook.Follow(Follow)
                                FoundCreatureToAttack(TClient.Battlelist.ID(i))
                                Exit Sub
                            End If
                        End If
                    End If
                Next
            End If
        End If
    End Sub
#End Region

#End Region

#Region "Checkbox"
    Private Sub EnableAttacker_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableAttacker.CheckedChanged
        EnableAll.Enabled = Not EnableAttacker.Checked
        EnableAdvanced.Enabled = Not EnableAttacker.Checked
        EnableAggresive.Enabled = Not EnableAttacker.Checked
        EnableFollow.Enabled = Not EnableAttacker.Checked
        TargetList.Enabled = Not EnableAttacker.Checked
        AttackerProperties.Enabled = Not EnableAttacker.Checked
        Timeout.Enabled = Not EnableAttacker.Checked
        EnableTimeout.Enabled = Not EnableAttacker.Checked
    End Sub

    Private Sub EnableFollow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableFollow.CheckedChanged
        DoFollow = EnableFollow.Checked
    End Sub
#End Region

#Region "Priority"
    Private Function HasPriority(ByVal Pos As UInt32) As Boolean
        If Not TClient.Self.HasTarget(False) Then Return True 'Not attacking anything, so why not attack

        Dim CurrentTargetName As String = String.Empty
        Dim TestTargetName As String = TClient.Battlelist.Name(Pos)
        Dim CurrentTargetLevel As Byte = 0
        Dim CurrentTestLevel As Byte = 0

        Dim TargLoc As Byte = 0
        Dim TestLoc As Byte = Pos

        'Get current target name
        For i = 1 To TClient.Battlelist.Length
            If TClient.Battlelist.ID(i) = TClient.Self.Target Then
                CurrentTargetName = TClient.Battlelist.Name(i)
                TargLoc = i
                Exit For
            End If
        Next
        If TargLoc = TestLoc Then Return False

        If CurrentTargetName.ToLower = TestTargetName.ToLower Then Return False 'Same creature

        'Test the very high priority
        For Each tC As AdvancedTarget In TargetList.Items
            If tC.Priority = AttackPriority.VeryHigh Then
                If NameContaines(CurrentTargetName, tC.Name) Then
                    CurrentTargetLevel = 3
                End If

                If NameContaines(TestTargetName, tC.Name) Then
                    CurrentTestLevel = 3
                End If
            ElseIf tC.Priority = AttackPriority.High Then
                If NameContaines(CurrentTargetName, tC.Name) Then
                    CurrentTargetLevel = 2
                End If

                If NameContaines(TestTargetName, tC.Name) Then
                    CurrentTestLevel = 2
                End If
            ElseIf tC.Priority = AttackPriority.Average Then
                If NameContaines(CurrentTargetName, tC.Name) Then
                    CurrentTargetLevel = 1
                End If

                If NameContaines(TestTargetName, tC.Name) Then
                    CurrentTestLevel = 1
                End If
            End If
        Next
        'Compare
        If CurrentTestLevel > CurrentTargetLevel AndAlso TClient.Battlelist.Health(TargLoc) > 15 Then Return True 'Higher priority, attack
        If CurrentTestLevel < CurrentTargetLevel Then Return False 'Lower priority, ignore

        Return FindWeakestLink(TestLoc, TargLoc) 'Same priority

    End Function

    Public Function FindWeakestLink(ByVal ComparePos As Byte, ByVal CurrentPos As Byte) As Boolean
        'Return true if the Compare creature is stronger
        Dim TestThreatLevel As Byte = 0
        Dim CurrentThreatLevel As Byte = 0

        If TClient.Battlelist.Health(ComparePos) > TClient.Battlelist.Health(CurrentPos) Then
            TestThreatLevel += 1
        Else
            CurrentThreatLevel += 1
        End If

        If TClient.Battlelist.Speed(ComparePos) > TClient.Battlelist.Speed(CurrentPos) Then
            TestThreatLevel += 1
        Else
            CurrentThreatLevel += 1
        End If

        If TClient.Self.IsAdjecentTo(TClient.Battlelist.X(ComparePos), TClient.Battlelist.Y(ComparePos), TClient.Battlelist.Z(ComparePos)) Then
            TestThreatLevel += 1
        End If

        If TClient.Self.IsAdjecentTo(TClient.Battlelist.X(CurrentPos), TClient.Battlelist.Y(CurrentPos), TClient.Battlelist.Z(CurrentPos)) Then
            CurrentThreatLevel += 1
        End If

        If Math.Abs((TClient.Self.X - TClient.Battlelist.X(ComparePos)) + (TClient.Self.Y - TClient.Battlelist.Y(ComparePos))) _
        > Math.Abs((TClient.Self.X - TClient.Battlelist.X(CurrentPos)) + (TClient.Self.Y - TClient.Battlelist.Y(CurrentPos))) Then
            TestThreatLevel += 1
        Else
            CurrentThreatLevel += 1
        End If

        Return TestThreatLevel > CurrentThreatLevel
    End Function
#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Z As Byte = TClient.Map.GetLocalPosition(TClient.Map.GetSelfTile).z
        For t = 0 To 2015
            If TClient.Map.GetLocalPosition(t).z = Z Then
                If TClient.Map.TileIsBlocking(t) Then
                    TClient.DisplayAnimatedText(Client.TextColor.Red, "Blocks", TClient.Map.GetGlobalPosition(t))
                Else
                    TClient.DisplayAnimatedText(Client.TextColor.Blue, "Not", TClient.Map.GetGlobalPosition(t))
                End If
            Else
                System.Threading.Thread.Sleep(5)
                TClient.DisplayAnimatedText(Client.TextColor.Green, "Found", TClient.Map.GetGlobalPosition(t))
            End If
        Next
    End Sub

    Private Sub NewCreature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewCreature.Click
        TargetList.Items.Add(New AdvancedTarget("New Creature"))
    End Sub

    Private Sub ClearCreatures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearCreatures.Click
        TargetList.Items.Clear()
        TargetList.Items.Add(New AdvancedTarget("Other Creatures"))
        AttackerProperties.SelectedObject = Nothing
    End Sub

    Private Sub AttackerContextMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles AttackerContextMenu.Opening
        Try
            DeleteCreature.Enabled = _
            Not TargetList.SelectedItem Is Nothing AndAlso _
            CType(TargetList.SelectedItem, AdvancedTarget).Name.ToLower <> "other creatures"
        Catch
            DeleteCreature.Enabled = False
        End Try
    End Sub

    Private Sub DeleteCreature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteCreature.Click
        Try
            If CType(TargetList.SelectedItem, AdvancedTarget).Name.ToLower <> "other creatures" Then
                TargetList.Items.Remove(TargetList.SelectedItem)
            End If
        Catch ex As Exception
        End Try
    End Sub



    Public Sub SaveAttackFile(ByVal path As String)
        Dim ListFile As New System.IO.StreamWriter(path)
        ListFile.WriteLine("AdvancedAttackerFile v2.0")

        For Each tC As AdvancedTarget In TargetList.Items
            ListFile.WriteLine(tC.Name)

            ListFile.WriteLine(CInt(tC.Priority))
            ListFile.WriteLine(CInt(tC.FollowMode))
            ListFile.WriteLine(tC.Proximity)
            ListFile.WriteLine(CInt(tC.MagicType))

            ListFile.WriteLine(tC.StrikeSpell)
            ListFile.WriteLine(tC.StrikeMana)
            ListFile.WriteLine(tC.StrikeHealth)

            ListFile.WriteLine(tC.RuneID)
            ListFile.WriteLine(tC.RuneHealth)
        Next
        ListFile.Close()
    End Sub

    Public Sub LoadAttackFile(ByVal path As String)
        Dim stream_reader As New IO.StreamReader(path)
        Dim First As String

        If stream_reader.ReadLine() = "AdvancedAttackerFile v2.0" Then
            TargetList.Items.Clear()
            First = stream_reader.ReadLine()
            Do While Not (First Is Nothing)
                Dim TempC As New AdvancedTarget(First)
                TempC.Priority = stream_reader.ReadLine()
                TempC.FollowMode = stream_reader.ReadLine()
                TempC.Proximity = stream_reader.ReadLine()
                TempC.MagicType = stream_reader.ReadLine()

                TempC.StrikeSpell = stream_reader.ReadLine()
                TempC.StrikeMana = stream_reader.ReadLine()
                TempC.StrikeHealth = stream_reader.ReadLine()

                TempC.RuneID = stream_reader.ReadLine()
                TempC.RuneHealth = stream_reader.ReadLine()

                TargetList.Items.Add(TempC)
                First = stream_reader.ReadLine()
            Loop
        Else
            MsgBox("You are trying to use an attack file no longer supported by TUGBot.")
        End If


        stream_reader.Close()
    End Sub

    Private Sub SaveAttacks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAttacks.Click
        Main.SaveFile.Title = "Save Advanced Attacker Configuration"
        Main.SaveFile.Filter = "TUGBot Attacker File (*.TBAT)|*.TBAT|All files (*.*)|*.*"

        If System.IO.Directory.Exists(Application.StartupPath & "\Quickload\AdvacnedAttacker") Then
            Main.SaveFile.InitialDirectory = Application.StartupPath & "\Quickload\AdvacnedAttacker"
        Else
            Main.SaveFile.InitialDirectory = Application.StartupPath
        End If
        Main.SaveFile.FileName = ""
        Main.SaveFile.ShowDialog()

        If Main.SaveFile.FileName = "" Then Exit Sub
        SaveAttackFile(Main.SaveFile.FileName)
    End Sub

    Private Sub LoadAttacks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadAttacks.Click
        Main.LoadFile.Title = "Load Advanced Attacker Configuration"
        Main.LoadFile.Filter = "TUGBot Attacker File (*.TBAT)|*.TBAT|All files (*.*)|*.*"

        If System.IO.Directory.Exists(Application.StartupPath & "\Quickload\AdvacnedAttacker") Then
            Main.LoadFile.InitialDirectory = Application.StartupPath & "\Quickload\AdvacnedAttacker"
        Else
            Main.LoadFile.InitialDirectory = Application.StartupPath
        End If
        Main.LoadFile.FileName = ""
        Main.LoadFile.ShowDialog()

        If Main.LoadFile.FileName = "" Then Exit Sub
        LoadAttackFile(Main.LoadFile.FileName)
    End Sub


#Region "Property window and list"
    Private Sub TargetList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TargetList.SelectedIndexChanged
        TargetList.DisplayMember = "DisplayName"
        TargetList.Refresh()
        If TargetList.SelectedItem IsNot Nothing Then
            If CType(TargetList.SelectedItem, AdvancedTarget).Name.ToLower <> "other creatures" Then
                AttackerProperties.SelectedObject = TargetList.SelectedItem
            Else
                AttackerProperties.SelectedObject = TargetList.SelectedItem
                'AttackerProperties.SelectedObject = Nothing
            End If
        End If
    End Sub

    Private Sub AttackerProperties_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles AttackerProperties.PropertyValueChanged
        If TargetList.SelectedIndex = -1 Then AttackerProperties.SelectedObject = Nothing : Exit Sub
        If TargetList.SelectedIndex = 0 AndAlso Not CType(AttackerProperties.SelectedObject, AdvancedTarget).Name.ToLower = "other creatures" Then
            AttackerProperties.SelectedObject = Nothing
            AttackerProperties.SelectedObject = TargetList.SelectedItem
            CType(AttackerProperties.SelectedObject, AdvancedTarget).Name = "Other Creatures"
            TargetList.DisplayMember = "DisplayName"
            TargetList.Refresh()
        Else
            TargetList.Items(TargetList.SelectedIndex) = CType(AttackerProperties.SelectedObject, AdvancedTarget)
            TargetList.DisplayMember = "DisplayName"
            TargetList.Refresh()
        End If
    End Sub
#End Region
End Class