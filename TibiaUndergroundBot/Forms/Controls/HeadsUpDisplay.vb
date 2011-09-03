Public Class HeadsUpDisplay
    'PING
    Public PingAmount As Double

    'EXP
    Public InitExp As UInteger
    Public HourlyExp As UInteger
    Public StartExp As UInteger

    'Damage
    Public InitDamage As Short

    Private Sub HeadsUpDisplay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()
    End Sub

    Private Shadows Sub FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Visible = False
        Me.Refresh()
        e.Cancel = True
    End Sub

#Region "StatusPanel Checkbox"
    Private Sub EnableStatusPanel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableStatusPanel.CheckedChanged
        If EnableStatusPanel.Checked Then
            InitExp = 0
            StartExp = TClient.Self.Exp

            InitDamage = TClient.Self.Health
        Else
            TClient.Hook.UpdateBackgroundRect(75, 5000, 5000, 5, 5)
            TClient.Hook.RemoveText("sp")

            For i = 1 To 6
                TClient.Hook.UpdateGUI(i, 128, 5000, 5000, 1, 1)
            Next
        End If
    End Sub
#End Region

    Private Sub HourlyExp_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HourlyExpTimer.Tick
        If Not Me.ShowExpEnable.Checked Then Exit Sub
        Me.InitExp += 1
        Me.HourlyExp = Fix(((TClient.Self.Exp - Me.StartExp) / Me.InitExp) * 60 * 60)
    End Sub

    Public Sub CalculatePing()
        If Not Me.ShowPingEnable.Checked Then Exit Sub
        Try
            'Dim P As New CheckPing(Me.Self.IP, Me.Self.Port, 2000)
            'PingCriticalSection(index).Enter()
            'PingAmount(index) = P.Test
            'PingCriticalSection(index).Leave()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub StatusPanelDisplay_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusPanelDisplay.Tick
        If TClient.Status <> 8 Then Exit Sub
        Dim YLoc As Integer = Me.StatusPanelY.Value
        Dim TextList As New List(Of DisplayText)
        Dim TempColor As System.Drawing.Color

        If Me.EnableStatusPanel.Checked = False Then
            TClient.Hook.UpdateBackgroundRect(75, 5000, 5000, 5, 5)
            TClient.Hook.RemoveText("sp")

            For i = 1 To 6
                TClient.Hook.UpdateGUI(i, 128, 5000, 5000, 1, 1)
            Next

            Exit Sub
        End If
        'Ping
        If Me.ShowPingEnable.Checked Then

            If PingAmount <= 300 Then
                TempColor = Drawing.Color.Lime
            ElseIf PingAmount <= 400 Then
                TempColor = Drawing.Color.Yellow
            ElseIf PingAmount <= 500 Then
                TempColor = Drawing.Color.Orange
            ElseIf PingAmount <= 700 Then
                TempColor = Drawing.Color.DarkOrange
            Else
                TempColor = Drawing.Color.Red
            End If

            Dim pings As String = Fix(PingAmount).ToString
            If Fix(PingAmount) = 0 Then pings = "Unknown"
            TextList.Add(New DisplayText("sp", "Ping: " & pings, Me.StatusPanelX.Value + 95, YLoc + 2, TempColor))

            TextList.Add(New DisplayText("sp", "Good", Me.StatusPanelX.Value + 3, YLoc + 5, Color.Green))
            TextList.Add(New DisplayText("sp", "Bad", Me.StatusPanelX.Value + 65, YLoc + 5, Color.Red))
            TClient.Hook.UpdateGUI(1, 127, Me.StatusPanelX.Value, YLoc, 90, 11)

            If Fix(PingAmount) > 0 Then
                TClient.Hook.UpdateGUI(2, 128, Me.StatusPanelX.Value, YLoc, CalculatePercent(90, 1000, Fix(PingAmount)), 10)
            Else
                TClient.Hook.UpdateGUI(2, 128, Me.StatusPanelX.Value, YLoc, 45, 11)
            End If


            YLoc += 17

            TClient.Hook.UpdateGUI(5, 27, Me.StatusPanelX.Value, YLoc, 180, 1)
            YLoc += 7
        Else
            TClient.Hook.UpdateGUI(5, 27, 5000, 5000, 1, 1)
            TClient.Hook.UpdateGUI(1, 127, 5000, 5000, 90, 10)
            TClient.Hook.UpdateGUI(2, 127, 5000, 5000, 90, 10)
        End If

        'Spell Timers
        If Me.SpellTimerEnable.Checked Then
            Dim TempTime As New TimeSpan

            Dim HasteTime As Integer = 0
            Dim InvisTime As Integer = 0
            Dim MShieldTime As Integer = 0

            TempTime = Date.Now - TClient.LastSaidHaste
            Select Case TClient.LastHasteType
                Case 1
                    If TempTime.TotalMilliseconds < 33000 And TClient.Self.Hasted Then
                        HasteTime = 33 - TempTime.TotalSeconds
                    End If
                Case 2
                    If TempTime.TotalMilliseconds < 22000 And TClient.Self.Hasted Then
                        HasteTime = 22 - TempTime.TotalSeconds
                    End If
            End Select

            TempTime = Date.Now - TClient.LastSaidMShield
            If TempTime.TotalMilliseconds < 200000 And TClient.Self.MagicShield Then
                MShieldTime = 200 - TempTime.TotalSeconds
            End If

            TempTime = Date.Now - TClient.LastSaidInvis
            If TempTime.TotalMilliseconds < 200000 Then
                InvisTime = 200 - TempTime.TotalSeconds
            End If

            TextList.Add(New DisplayText("sp", "Haste: " & SecondsToTime(HasteTime), Me.StatusPanelX.Value, YLoc, Color.Brown))
            YLoc += 19

            TextList.Add(New DisplayText("sp", "Invisible: " & SecondsToTime(InvisTime), Me.StatusPanelX.Value, YLoc, Color.Blue))
            YLoc += 19

            TextList.Add(New DisplayText("sp", "Magic Shield: " & SecondsToTime(MShieldTime), Me.StatusPanelX.Value, YLoc, Color.SkyBlue))
            YLoc += 17

            TClient.Hook.UpdateGUI(3, 27, Me.StatusPanelX.Value, YLoc, 180, 1)
            YLoc += 7
        Else
            TClient.Hook.UpdateGUI(3, 27, 5000, 5000, 1, 1)
        End If

        'Target
        If Me.ShowTargetEnable.Checked Then
            TextList.Add(New DisplayText("sp", "Show Target: Under Construction", Me.StatusPanelX.Value, YLoc, Color.Red))
            YLoc += 17

            TClient.Hook.UpdateGUI(4, 27, Me.StatusPanelX.Value, YLoc, 180, 1)
            YLoc += 7
        Else
            TClient.Hook.UpdateGUI(4, 27, 5000, 5000, 1, 1)
        End If

        'Damage
        If Me.ShowDmgPSEnable.Checked Then
            TextList.Add(New DisplayText("sp", "Damage Per Second: " & InitDamage - TClient.Self.Health, Me.StatusPanelX.Value, YLoc, Color.DarkOrange))
            InitDamage = TClient.Self.Health

            YLoc += 17

            TClient.Hook.UpdateGUI(6, 27, Me.StatusPanelX.Value, YLoc, 180, 1)
            YLoc += 7
        Else
            TClient.Hook.UpdateGUI(6, 27, 5000, 5000, 1, 1)
        End If

        'Exp
        If Me.ShowExpEnable.Checked Then
            TextList.Add(New DisplayText("sp", "Hourly Exp: " & HourlyExp, Me.StatusPanelX.Value, YLoc, Color.White))
            YLoc += 15
        End If

        TClient.Hook.UpdateBackgroundRect(75, Me.StatusPanelX.Value, Me.StatusPanelY.Value, 180, YLoc - Me.StatusPanelY.Value)
        TClient.Hook.AddText(True, "sp", TextList)
    End Sub

    Private Sub ShowExpEnable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowExpEnable.CheckedChanged
        Me.StartExp = TClient.Self.Exp
    End Sub
End Class