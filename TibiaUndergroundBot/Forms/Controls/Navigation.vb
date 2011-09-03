Public Class Navigation
    Private WithEvents NavSocket As Winsock
    'Private NavChars As New List(Of NavPosition)

    Public NavigationThread As New TimedThread(200, New TimedThread.RunThreadDelegate(AddressOf RunNav), False)

#Region "Form events"
    Private Sub Navigation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Visible = False
        Me.Refresh()
        e.Cancel = True
    End Sub

    Private Sub Navigation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Visible = False
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()
        MiniMapViewer1.LoadMap()
    End Sub
#End Region

#Region "Connect/Disconnect"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectNav.Click
        If ConnectNav.Text = "Connect" Then
            'NavSocket = New Winsock(NavIp.Text, NavPort.Text)
            'NavSocket.Connect(NavIp.Text, NavPort.Text)

            'ConnectNav.Text = "Disconnect"
            'NavIp.Enabled = False
            'NavPassword.Enabled = False
            'NavPort.Enabled = False
            NavigationThread.Start()
        Else
            NavSocket.Dispose()
            ConnectNav.Text = "Connect"
            NavIp.Enabled = True
            NavPassword.Enabled = True
            NavPort.Enabled = True
        End If
    End Sub

    Private Sub NavSocket_Connected(ByVal sender As Winsock) Handles NavSocket.Connected
        Dim Pack As New PacketBuilder(&H1)
        Pack.AddString(NavPassword.Text)
        NavSocket.Send(Pack.GetPacket)
        NavigationThread.Start()
    End Sub

    Private Sub NavSocket_Disconnected(ByVal sender As Winsock) Handles NavSocket.Disconnected
        NavigationThread.Pause()
        TClient.Hook.RemoveText("nav")

        'SyncLock NavChars
        'NavChars.Clear()
        'End SyncLock

        ConnectNav.Text = "Connect"
        NavIp.Enabled = True
        NavPassword.Enabled = True
        NavPort.Enabled = True
    End Sub
#End Region

#Region "Incoming packets"
    Private Sub NavSocket_DataArrival(ByVal sender As Winsock, ByVal BytesTotal As Integer) Handles NavSocket.DataArrival
        Dim buffer(BytesTotal) As Byte
        Try
            sender.GetData(buffer)
            ParsePosition(buffer)
        Catch
        End Try
    End Sub

    Public Sub ParsePosition(ByVal array As Byte())
        'Dim Pos As New NavPosition
        'Pos.X = BitConverter.ToInt32(array, 3)
        'Pos.Y = BitConverter.ToInt32(array, 7)
        'Pos.Z = array(11)
        'Pos.Name = ByteToString(array, 14)

        'NavCritical.Enter()
        'For Each I As NavPosition In NavChars
        '    If I.Name = Pos.Name Then
        '        Try
        '            NavChars.Remove(I)
        '        Catch
        '        End Try
        '        Exit For
        '    End If
        'Next
        'NavChars.Add(Pos)
        'NavCritical.Leave()
    End Sub

    Private Function ByteToString(ByVal buffer As Byte(), ByVal start As Integer) As String
        Dim L As Short = buffer.Length - start
        Dim s As String = System.Text.Encoding.ASCII.GetString(buffer, start, L)
        Return s
    End Function
#End Region

#Region "Nav Display"
    Private Sub RunNav(ByVal a As Action)
        '        Dim TextList As New List(Of DisplayText)
        '        Dim px As UShort = TClient.Self.X : Dim py As UShort = TClient.Self.Y : Dim pz As Byte = TClient.Self.Z
        '        Dim Pack As New PacketBuilder(&H2)
        '        Dim TLoc As New System.Drawing.PointF(0, 0)
        '        Dim CharInfo As NavInfo
        '        Dim Al As DisplayText.TextAlign
        '        Dim tempy As Integer = 0
        '        Dim Edge As ScreenEdge

        '        If px = 0 Then Exit Sub
        '        Pack.AddLong(px + 10)
        '        Pack.AddLong(py + 270)
        '        Pack.AddByte(pz)
        '        Pack.AddString(TClient.Self.Name)

        '        Try
        '            NavSocket.Send(Pack.GetPacket)
        '        Catch
        '        End Try

        '        'Try
        '        NavCritical.Enter()
        '        For Each L As NavPosition In NavChars
        '            If EdgeCollisionDetect(New System.Drawing.Point(px, py), _
        '                                    New System.Drawing.Point(L.X, L.Y), _
        '                                    New System.Drawing.Point(px - 7, py - 5), _
        '                                    New System.Drawing.Point(px - 7, py + 5), _
        '                                    New System.Drawing.Point(px + 7, py - 5), _
        '                                    New System.Drawing.Point(px + 7, py + 5), _
        '                                    TLoc, Edge) Then
        '                Select Case Edge
        '                    Case ScreenEdge.Bottom
        '                        CharInfo = New NavInfo(TClient.Screen.AlignBottom(TLoc.X, TLoc.Y, Al), px, py, L.X, L.Y, L.Name, L.Z, pz)
        '                    Case ScreenEdge.Left
        '                        CharInfo = New NavInfo(TClient.Screen.AlignLeft(TLoc.X, TLoc.Y, Al), px, py, L.X, L.Y, L.Name, L.Z, pz)
        '                    Case ScreenEdge.Right
        '                        CharInfo = New NavInfo(TClient.Screen.AlignRight(TLoc.X, TLoc.Y, Al), px, py, L.X, L.Y, L.Name, L.Z, pz)
        '                    Case ScreenEdge.Top
        '                        CharInfo = New NavInfo(TClient.Screen.AlignTop(TLoc.X, TLoc.Y, Al), px, py, L.X, L.Y, L.Name, L.Z, pz)
        '                End Select
        '                TextList.Add(New DisplayText("nav", CharInfo.ToString, _
        'Math.Abs(CharInfo.PrintLocation.x), Math.Abs(CharInfo.PrintLocation.y + tempy), Color.Orange, Al))

        '            End If
        '        Next
        '        'Catch ex As Exception
        '        'MsgBox(ex.ToString)
        '        'End Try

        '        'MapViewer1.Markers = NavChars
        '        'MapViewer1.Invalidate()
        '        NavCritical.Leave()
        '        TClient.Hook.AddText(True, "nav", TextList)
    End Sub

    Public Enum ScreenEdge
        Top = 0
        Right = 1
        Bottom = 2
        Left = 3
    End Enum

    'TL is to left, BL bottom right, ect of the rectangle
    'Line start and line end are the points the line runs between
    'Will return true if the lines intersect somewhere with the recangle, and the last arg will be the returned point of intersection
    Private Function EdgeCollisionDetect(ByVal lineStart As Drawing.Point, ByVal LineEnd As Drawing.Point, ByVal TL As Drawing.Point, ByVal BL As Drawing.Point, ByVal TR As Drawing.Point, ByVal BR As Drawing.Point, ByRef ret As Drawing.PointF, ByRef Edge As ScreenEdge) As Boolean
        'Check with bottom left line and bottom right line
        If LineCollisionDetect(BL, BR, lineStart, LineEnd, ret) Then
            Edge = ScreenEdge.Bottom
            Return True
        End If

        'Check with top left line and bottom left line
        If LineCollisionDetect(TL, BL, lineStart, LineEnd, ret) Then
            Edge = ScreenEdge.Left
            Return True
        End If

        'Check with top left line and top right line
        If LineCollisionDetect(TL, TR, lineStart, LineEnd, ret) Then
            Edge = ScreenEdge.Top
            Return True
        End If

        'Check with top right line and bottom right line
        If LineCollisionDetect(TR, BR, lineStart, LineEnd, ret) Then
            Edge = ScreenEdge.Right
            Return True
        End If

        Return False 'No intersection, which means the line segment stays inside the rect
    End Function

    Public Function LineCollisionDetect(ByVal Line1Start As PointF, ByVal Line1End As PointF, ByVal Line2Start As PointF, ByVal Line2End As PointF, ByRef result As PointF) As Boolean
        Dim d As Single = ((Line1End.X - Line1Start.X) * (Line2End.Y - Line2Start.Y)) - ((Line1End.Y - Line1Start.Y) * (Line2End.X - Line2Start.X))
        If d = 0 Then Return False 'Paralell lines

        Dim b As Single = ((Line1Start.Y - Line2Start.Y) * (Line2End.X - Line2Start.X)) - ((Line1Start.X - Line2Start.X) * (Line2End.Y - Line2Start.Y))
        Dim r1 As Single = b / d

        Dim nb As Single = ((Line1Start.Y - Line2Start.Y) * (Line1End.X - Line1Start.X)) - ((Line1Start.X - Line2Start.X) * (Line1End.Y - Line1Start.Y))
        Dim r2 As Single = nb / d

        If (r1 < 0 OrElse r1 > 1) OrElse (r2 < 0 OrElse r2 > 1) Then
            Return False
        End If

        result.X = Line1Start.X + (r1 * (Line1End.X - Line1Start.X))
        result.Y = Line1Start.Y + (r1 * (Line1End.Y - Line1Start.Y))
        Return True
    End Function
#End Region

#Region "Controls for the map viewer"
    Private Sub CurrentFloor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrentFloor.CheckedChanged
        'MapViewer1.AllNameFloors = AllFloors.Checked
    End Sub

    Private Sub AllFloors_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllFloors.CheckedChanged
        'MapViewer1.AllNameFloors = AllFloors.Checked
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        'MapViewer1.DrawNames = True
    End Sub


#End Region

    'Private Sub MapViewer1_Centered(ByVal l As Structures.Location) Handles MapViewer1.Centered
    '    LabelPos.Text = String.Format("{0}, {1}, {2}", l.x, l.y, l.z)
    'End Sub
End Class

Public Class NavInfo
    Private name As String
    Private z As Short
    Private Distance As UShort
    Private selfx As UShort
    Private selfy As UShort
    Private loc As Location
    Public PrintLocation As Location

    Public Sub New(ByVal PrintLoc As Location, ByVal Startlocx As UShort, ByVal StartLocY As UShort, ByVal EndlocX As UShort, ByVal EndLocY As UShort, ByVal Name As String, ByVal NavCharz As Byte, ByVal selfz As Byte)
        Me.PrintLocation = PrintLoc
        Me.z = CInt(NavCharz) - CInt(selfz)
        Me.name = Name
        Me.selfx = Startlocx
        Me.selfy = StartLocY

        loc = New Location(EndlocX, EndLocY, NavCharz)

        Me.Distance = CUShort(Math.Abs(Math.Sqrt( _
                                       (CInt(Startlocx) - CInt(EndlocX)) ^ 2 + _
                                        (CInt(StartLocY) - CInt(EndLocY)) ^ 2)))
    End Sub

    Public ReadOnly Property RealLocation() As Location
        Get
            Return loc
        End Get
    End Property

    Public Overrides Function ToString() As String
        Dim TempZ As String = ""
        If z <> 0 Then
            If z < 0 Then
                TempZ = " -" & z * -1
            Else
                TempZ = " +" & z
            End If
        End If

        Return name & " [D" & Distance & TempZ & "]"
    End Function

End Class