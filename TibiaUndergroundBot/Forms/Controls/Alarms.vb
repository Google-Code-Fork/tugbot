Imports SpeechLib
Public Class Alarms
    Public LastHealth As Integer

#Region "Text To Speech"
    Public WithEvents vox As New SpVoice
    Public CurrentAlarm As String

    Private Sub TTSSpeaker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles TTSSpeaker.DoWork
        If CurrentAlarm <> "" Then
            vox.Speak(CurrentAlarm.Replace(vbNullChar, ""))
        End If
    End Sub
#End Region

#Region "Form events"
    Private Sub Alarms_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Visible = False
        Me.Refresh()
        e.Cancel = True
    End Sub

    Private Sub Alarms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()

        vox.Rate = 1
        AlarmVolume.Value = vox.Volume

        AddHandler TClient.CreatureAttacking, AddressOf Attacked

        AddHandler TClient.CreaturePrivateSpeak, AddressOf PrivateMessage
        AddHandler TClient.CreatureDefaultSpeech, AddressOf DefaultMessage
        AddHandler TClient.GameMasterSpeak, AddressOf GMMessage

        AddHandler TClient.CreatureHealthUpdated, AddressOf LossHP
    End Sub
#End Region

#Region "Filter"
    Private Sub AlarmFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlarmFilter.CheckedChanged
        AllyFilter.Enabled = AlarmFilter.Checked
        EnemyFilter.Enabled = AlarmFilter.Checked
    End Sub

    Private Function PassesFilter(ByVal name As String) As Boolean
        If Not AlarmFilter.Checked Then Return True
        If AllyFilter.Checked And Not War.AllyList.Items.Contains(name) Then Return True
        If EnemyFilter.Checked And War.EnemyList.Items.Contains(name) Then Return True
        Return False
    End Function

    Private Function PassSpellFilter(ByVal text As String)
        If IgnoreSpells.Checked Then
            If IsSpell(text) Then Return False
        End If
        Return True
    End Function
#End Region

#Region "Event alarms"
    Private Sub Attacked(ByVal id As Integer)
        If OnlyPlayerAttack.Checked Then
            If id < &H40000000 And AttackAlert.Checked Then
                TClient.Battlelist.Cache()
                Dim Pos As Integer = TClient.Battlelist.PosByID(id)
                If PassesFilter(TClient.Battlelist.Name(Pos)) Then
                    Alert("Player " & TClient.Battlelist.Name(Pos) & " is attacking you")
                End If
            End If
        Else
            If id < &H40000000 And AttackAlert.Checked Then
                TClient.Battlelist.Cache()
                Dim Pos As Integer = TClient.Battlelist.PosByID(id)
                If PassesFilter(TClient.Battlelist.Name(Pos)) Then
                    Alert("Player " & TClient.Battlelist.Name(Pos) & " is attacking you")
                End If
            ElseIf AttackAlert.Checked Then
                TClient.Battlelist.Cache()
                Dim Pos As Integer = TClient.Battlelist.PosByID(id)
                Alert("A " & TClient.Battlelist.Name(Pos) & " is attacking you")
            End If
        End If
    End Sub

    Private Sub PrivateMessage(ByVal sender As String, ByVal level As Integer, ByVal message As String)
        If PrivateMessageAlert.Checked Then
            If sender <> TClient.Self.Name Then
                If PassesFilter(sender) Then
                    If PassSpellFilter(message) Then
                        Alert(sender & " has private messaged you")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub DefaultMessage(ByVal sender As String, ByVal level As Integer, ByVal message As String)
        If DefaultMessageAlert.Checked Then
            If sender <> TClient.Self.Name Then
                If PassesFilter(sender) Then
                    If PassSpellFilter(message) Then
                        Alert(sender & " has spoken in default")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GMMessage(ByVal sender As String, ByVal message As String)
        If GMMessageAlert.Checked Then
            Alert(sender & " said " & message)
        End If

        If GMMessageLogout.Checked Then
            TClient.Hook.Logout()
        End If
    End Sub

    Private Sub LossHP(ByVal id As Integer, ByVal health As Byte, ByVal oldhealth As Byte)
        If id <> TClient.Self.Id OrElse Not HPLossAlert.Checked Then Exit Sub
        Dim hp As Integer = TClient.Self.Health
        If hp < LastHealth Then
            Alert("You lost " & LastHealth - hp & " health")
            LastHealth = hp
        ElseIf hp > LastHealth Then
            'Reset health 
            LastHealth = hp
        End If
    End Sub
#End Region

#Region "Checkboxes"
    Private Sub HPLossAlert_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HPLossAlert.CheckedChanged
        LastHealth = TClient.Self.Health
    End Sub

    Private Sub AttackAlert_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttackAlert.CheckedChanged
        OnlyPlayerAttack.Enabled = Not AttackAlert.Checked
    End Sub

    Private Sub CapAlert_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapAlert.CheckedChanged
        CapAlertCompare.Enabled = Not CapAlert.Checked
    End Sub

    Private Sub ManaAlert_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManaAlert.CheckedChanged
        ManaAlertCompare.Enabled = Not ManaAlert.Checked
    End Sub

    Private Sub SoulAlert_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoulAlert.CheckedChanged
        SoulAlertCompare.Enabled = Not SoulAlert.Checked
    End Sub

    Private Sub HealthAlert_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HealthAlert.CheckedChanged
        HealthAlertCompare.Enabled = Not HealthAlert.Checked
    End Sub

    Private Sub SoulLogout_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoulLogout.CheckedChanged
        SoulLogoutAmount.Enabled = Not SoulLogout.Checked
    End Sub

    Private Sub PlayerAlert_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayerAlert.CheckedChanged
        PlayerAlertAll.Enabled = Not PlayerAlert.Checked
    End Sub

    Private Sub PlayerSafe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayerSafe.CheckedChanged
        PlayerSafeAll.Enabled = Not PlayerSafe.Checked
    End Sub

    Private Sub PlayerLogout_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayerLogout.CheckedChanged
        PlayerLogoutAll.Enabled = Not PlayerLogout.Checked
    End Sub

    Private Sub GmAlert_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GmAlert.CheckedChanged
        GMAlertAll.Enabled = Not GMSafe.Checked
    End Sub

    Private Sub GMSafe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GMSafe.CheckedChanged
        GMSafeAll.Enabled = Not GMSafe.Checked
    End Sub
#End Region

#Region "Status Alarms"
    Private Sub StatusTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusTimer.Tick
        StatusTimer.Interval = 1000
        If TClient.ReadInt(TClient.Addresses.Client.Connection) = 8 Then
            If PlayerSafe.Checked Then
                Dim Players As Integer = DetectPlayers(PlayerSafeAll.Checked)
                If Players > 0 Then
                    TClient.Paused = True
                    TClient.Hook.StopActions()
                End If
            End If

            If PlayerAlert.Checked Then
                Dim Players As Integer = DetectPlayers(PlayerAlertAll.Checked)
                If Players > 0 Then
                    Alert(Players & " players detected")
                    StatusTimer.Interval = 2000
                End If
            End If

            If HealthAlert.Checked AndAlso TClient.Self.Health < HealthAlertCompare.Value Then
                Alert("Health Below " & HealthAlertCompare.Value)
                StatusTimer.Interval = 2000
            End If

            If ManaAlert.Checked AndAlso TClient.Self.Mana < ManaAlertCompare.Value Then
                Alert("Manna Below " & ManaAlertCompare.Value)
                StatusTimer.Interval = 2000
            End If

            If CapAlert.Checked AndAlso TClient.Self.Cap < CapAlertCompare.Value Then
                Alert("Capacity Below " & CapAlertCompare.Value)
                StatusTimer.Interval = 2000
            End If

            If SoulAlert.Checked AndAlso TClient.Self.Soul < SoulAlertCompare.Value Then
                Alert("Soul Below " & SoulAlertCompare.Value)
                StatusTimer.Interval = 2000
            End If
        ElseIf DisconnectAlert.Checked Then
            Alert("Disconnected")
            StatusTimer.Interval = 2000
        End If
    End Sub
#End Region

#Region "Detection Alarms"
    Public Function DetectPlayers(ByVal AllFloors As Boolean) As Integer
        Dim PlayerCount As Integer = 0
        TClient.Battlelist.Cache()
        If AllFloors Then 'All Floors
            For i = 1 To TClient.Battlelist.Length
                If TClient.Battlelist.IsPlayer(i) Then
                    If TClient.Battlelist.ID(i) <> TClient.Self.Id Then
                        If TClient.Battlelist.IsVisibleNoZ(i, 9) Then
                            If PassesFilter(TClient.Battlelist.Name(i)) Then
                                PlayerCount += 1
                            End If
                        End If
                    End If
                End If
            Next
        Else 'Current Floor
            For i = 1 To TClient.Battlelist.Length
                If TClient.Battlelist.IsPlayer(i) Then
                    If TClient.Battlelist.ID(i) <> TClient.Self.Id Then
                        If TClient.Battlelist.IsVisible(i, 9) Then
                            If PassesFilter(TClient.Battlelist.Name(i)) Then
                                PlayerCount += 1
                            End If
                        End If
                    End If
                End If
            Next
        End If

        Return PlayerCount
    End Function


    Private Sub AutoLog_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoLog.Tick
        If TClient.Paused Then Exit Sub
        If PlayerLogout.Checked Then
            If DetectPlayers(PlayerLogoutAll.Checked) > 0 Then
                TClient.Hook.Logout()
            End If
        End If

        If SoulLogout.Checked AndAlso TClient.Self.Soul < SoulLogoutAmount.Value Then
            TClient.Hook.Logout()
        End If
    End Sub

#End Region

    Public Sub Alert(ByVal alarm As String)
        If TTSSpeaker.IsBusy Then Exit Sub
        CurrentAlarm = alarm
        TTSSpeaker.RunWorkerAsync()
    End Sub


#Region "Volume"
    Dim LMsVol As Integer

    Private Sub AlarmVolume_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AlarmVolume.MouseDown
        LMsVol = vox.Volume
    End Sub

    Private Sub AlarmVolume_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AlarmVolume.KeyDown
        'LMsVol = vox.Volume
    End Sub

    Private Sub AlarmVolume_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AlarmVolume.KeyUp
        If vox.Volume > LMsVol Then
            Alert("Volume increased from " & LMsVol & " to " & vox.Volume)
        ElseIf vox.Volume < LMsVol Then
            Alert("Volume decreased from " & LMsVol & " to " & vox.Volume)
        End If
        LMsVol = vox.Volume
    End Sub

    Private Sub AlarmVolume_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AlarmVolume.MouseUp
        If vox.Volume > LMsVol Then
            Alert("Volume increased from " & LMsVol & " to " & vox.Volume)
        ElseIf vox.Volume < LMsVol Then
            Alert("Volume decreased from " & LMsVol & " to " & vox.Volume)
        End If
        LMsVol = vox.Volume
    End Sub

    Private Sub AlarmVolume_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlarmVolume.Scroll
        vox.Volume = AlarmVolume.Value
    End Sub

#End Region
End Class