Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Collections.Generic
Public Class MiniMapViewer

    Public Event RegionShared(ByVal Rect1 As Location, ByVal Rect2 As Location)

    Public Enum ExivaDistance
        Far = 1
        VeryFar = 2
        Near = 3
    End Enum

    Public Enum DirectionalAngles 'decimal goes before last digit if we dotn divide by 10
        SE = 7426
        E = 6977
        NE = 6528
        N = 6079
        NW = 5627
        W = 5171
        SW = 4722
        S = 4273

        GlobalSweep = 449
    End Enum

    Public Class ExivaPlayer
        Public FromLoc As Location
        Public Distance As ExivaDistance
        Public Direction As DirectionalAngles
    End Class

    Private Exivas As New List(Of ExivaPlayer)

    Public HighlightContext As New ContextMenu()

#Region "Markers"
    Private DrawNames As Boolean = True
    Private DrawInfo As Boolean = True

    Private Allies As New Dictionary(Of String, Location)
    Private Enemies As New Dictionary(Of String, Location)

    Public Sub AddOrUpdateAlly(ByVal name As String, ByVal l As Location)
        If Allies.ContainsKey(name) Then
            Allies(name) = l
        Else
            Allies.Add(name, l)
        End If
    End Sub

    Public Sub AddOrUpdateEnemy(ByVal name As String, ByVal l As Location)
        If Enemies.ContainsKey(name) Then
            Enemies(name) = l
        Else
            Enemies.Add(name, l)
        End If
    End Sub

    Public Sub RemoveEnemy(ByVal name As String)
        If Enemies.ContainsKey(name) Then Enemies.Remove(name)
    End Sub

    Public Sub RemoveAlly(ByVal name As String)
        If Allies.ContainsKey(name) Then Allies.Remove(name)
    End Sub
#End Region

#Region "Player Rects"
    Public Class PlayerRect
        Public Pos1 As Location
        Public Pos2 As Location
    End Class

    Private ShareRects As New Dictionary(Of String, PlayerRect)
#End Region

#Region "Constants"
    Private Const MapFileDimension As Integer = 256
    Private Const FloorMax As Integer = 15
    Private Const FloorMin As Integer = 0
    Private Const MaskOT As String = "0??0??"
    Private Const MaskReal As String = "1??1??"
#End Region

#Region "Variables"
    Private FloorImages As Bitmap() = New Bitmap(FloorMax) {}

    Private LowerBounds As Point
    Private UpperBounds As Point

    Private DrawSize As System.Drawing.Size
    Private DrawPos As New Point(0, 0)

    Private CurrentZ As Integer = 7

    Private Loaded As Boolean = False

    Private m_directory As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Tibia\Automap\"

    Private Loading As Boolean = False
    Private LoadPercent As Byte = 0

    Private ZoomFactor As Double = 0.5

    Private mouseIsDown As Boolean = False
    Private rightIsDown As Boolean = False
    Private zoomRectStart As Location
    Private zoomRectEnd As Location
    Private Downpos As Point
#End Region

#Region "Loading Map Files"
    Private Shared Function MapFileNameToLocation(ByVal fileName As String) As Location
        Dim l As New Location(0, 0, 0)
        If fileName.Length = 12 OrElse fileName.Length = 8 Then
            l.x = UInt32.Parse(fileName.Substring(0, 3)) * MapFileDimension
            l.y = UInt32.Parse(fileName.Substring(3, 3)) * MapFileDimension
            l.z = Byte.Parse(fileName.Substring(6, 2))
        End If
        Return l
    End Function

    Public Function GetLowerBounds(ByVal FileNames As FileInfo()) As Point
        Dim LowestX As Integer = Nothing
        Dim LowestY As Integer = Nothing

        Dim TempL As Location
        For Each mapFile As FileInfo In FileNames
            TempL = MapFileNameToLocation(mapFile.Name)

            If LowestX = Nothing OrElse LowestY = Nothing Then
                LowestX = TempL.x
                LowestY = TempL.y
            End If

            If TempL.x < LowestX Then LowestX = TempL.x
            If TempL.y < LowestY Then LowestY = TempL.y
        Next

        Return New Point(LowestX, LowestY)
    End Function

    Public Function GetUpperBounds(ByVal FileNames As FileInfo()) As Point
        Dim HighestX As Integer = Nothing
        Dim HighestY As Integer = Nothing

        Dim TempL As Location
        For Each mapFile As FileInfo In FileNames
            TempL = MapFileNameToLocation(mapFile.Name)

            If HighestX = Nothing OrElse HighestY = Nothing Then
                HighestX = TempL.x
                HighestY = TempL.y
            End If

            If TempL.x > HighestX Then HighestX = TempL.x
            If TempL.y > HighestY Then HighestY = TempL.y
        Next

        Return New Point(HighestX + MapFileDimension, HighestY + MapFileDimension)
    End Function

    Public Sub LoadMap()
        Dim di As New DirectoryInfo(m_directory)
        Dim mapFiles As FileInfo() = di.GetFiles(MaskReal & "??" & ".map")

        LowerBounds = GetLowerBounds(mapFiles)
        UpperBounds = GetUpperBounds(mapFiles)

        For i As Integer = FloorMin To FloorMax
            FloorImages(i) = Nothing
        Next

        DrawSize = New Drawing.Size((UpperBounds.X - LowerBounds.X) * ZoomFactor, (UpperBounds.Y - LowerBounds.Y) * ZoomFactor)

        UpdateMap()

        AddHandler HighlightContext.MenuItems.Add("Zoom To").Click, AddressOf MenuClick
        AddHandler HighlightContext.MenuItems.Add("Share Region").Click, AddressOf MenuClick


        Dim TempP As New ExivaPlayer
        TempP.FromLoc = New Location(LowerBounds.X + 600, LowerBounds.Y + 1300, 7)
        TempP.Direction = DirectionalAngles.N
        TempP.Distance = ExivaDistance.Far

        Exivas.Add(TempP)


        TempP = New ExivaPlayer
        TempP.FromLoc = New Location(LowerBounds.X + 600, LowerBounds.Y + 950, 7)
        TempP.Direction = DirectionalAngles.S
        TempP.Distance = ExivaDistance.Far

        Exivas.Add(TempP)

        TempP = New ExivaPlayer
        TempP.FromLoc = New Location(LowerBounds.X + 500, LowerBounds.Y + 1400, 7)
        TempP.Direction = DirectionalAngles.N
        TempP.Distance = ExivaDistance.VeryFar

        Exivas.Add(TempP)

        Dim TempS As New PlayerRect
        TempS.Pos1 = New Location(LowerBounds.X + 600, LowerBounds.Y + 950, 7)
        TempS.Pos2 = New Location(LowerBounds.X + 640, LowerBounds.Y + 1020, 7)

        ShareRects.Add("DarkstaR", TempS)


        TempS = New PlayerRect
        TempS.Pos1 = New Location(LowerBounds.X + 800, LowerBounds.Y + 1300, 7)
        TempS.Pos2 = New Location(LowerBounds.X + 870, LowerBounds.Y + 1380, 7)

        ShareRects.Add("Smokie", TempS)


        'TempP = New ExivaPlayer
        'TempP.FromLoc = New Location(LowerBounds.X + 800, LowerBounds.Y + 1150, 7)
        'TempP.Direction = DirectionalAngles.W
        'TempP.Distance = ExivaDistance.Far

        'Exivas.Add(TempP)

        DrawPos = GlobalLocToCenterDisplayPoint(New Location(LowerBounds.X + (UpperBounds.X - LowerBounds.X) \ 2, LowerBounds.Y + (UpperBounds.Y - LowerBounds.Y) \ 2, CurrentZ))

        Loaded = True
    End Sub

    Public Sub UpdateMap()
        If FloorImages(CurrentZ) Is Nothing Then
            FloorImages(CurrentZ) = New Bitmap(UpperBounds.X - LowerBounds.X, UpperBounds.Y - LowerBounds.Y)
            Dim AsyncLoad As MethodInvoker = New MethodInvoker(AddressOf LoadMapFloor)
            AsyncLoad.BeginInvoke(Nothing, Nothing)
        Else
            Invalidate()
        End If
    End Sub

    Private Sub LoadMapFloor()
        LoadMapFloor(CurrentZ)
    End Sub

    Public Sub LoadMapFloor(ByVal Floor As Integer)
        Dim di As New DirectoryInfo(m_directory)
        Dim mapFiles As FileInfo() = di.GetFiles(MaskReal & Floor.ToString("00") & ".map")

        Dim TempGraphics As Graphics
        FloorImages(Floor) = New Bitmap(UpperBounds.X - LowerBounds.X, UpperBounds.Y - LowerBounds.Y)
        TempGraphics = Graphics.FromImage(FloorImages(Floor))


        Loading = True
        Dim count As Integer = 0
        LoadPercent = 0
        For Each mapFile As FileInfo In mapFiles
            count += 1
            Dim FileLocation As Location = MapFileNameToLocation(mapFile.Name)
            TempGraphics.DrawImage(MapFileToImage(m_directory & mapFile.Name), GlobalLocToMapPoint(FileLocation))
            LoadPercent = CalculatePercent(100, mapFiles.Count, count)
            Invalidate()
        Next
        LoadPercent = 100
        System.Threading.Thread.Sleep(300)
        Invalidate()
        Loading = False

        Invalidate()
    End Sub

    Public Function MapFileToImage(ByVal filename As String) As Bitmap
        Dim Ret As New Bitmap(MapFileDimension, MapFileDimension)

        Using bs As New BufferedStream(New FileStream(filename, FileMode.Open))
            ' Each map file contains this many pixels
            Dim array As Byte() = New Byte(65535) {}

            ' Read all of them at once (much faster than byte by byte) into an array
            bs.Read(array, 0, 65536)

            ' Loop through the array
            Dim index As Integer = 0
            For x As Integer = 0 To MapFileDimension - 1
                For y As Integer = 0 To MapFileDimension - 1
                    Dim b As Byte = array(index)

                    ' Set the pixel on the bitmap, converting the byte a color
                    Ret.SetPixel(x, y, ByteToColor(b))
                    index += 1
                Next
            Next
        End Using

        Return Ret
    End Function

    Public Function ColorToGrayScale(ByVal c As Color) As Color
        'Dim luma As Integer = CInt(c.R * 0.3 + c.G * 0.59 + c.B * 0.11)
        'Dim luma As Integer = CInt(c.R + c.G + c.B) * 0.95
        'Dim luma As Integer = CInt(c.R * 0.31 + c.G * 0.65 + c.B * 0.15)
        'Return Color.FromArgb(Math.Min(luma, 255), Math.Min(luma, 255), Math.Min(luma, 255))

        Dim outRed As Integer = CInt(c.R * 0.55 + c.G * 0.21 + c.B * 0.21)
        Dim outGreen As Integer = CInt(c.R * 0.21 + c.G * 0.55 + c.B * 0.21)
        Dim OutBlue As Integer = CInt(c.R * 0.21 + c.G * 0.21 + c.B * 0.55)
        Return Color.FromArgb(Math.Min(outRed, 255), Math.Min(outGreen, 255), Math.Min(OutBlue, 255))
    End Function

    Public Function ByteToColor(ByVal b As Byte) As Color
        Select Case b
            Case &HC
                ' Foliage, dark green
                Return ColorToGrayScale(Color.FromArgb(0, &H66, 0))
            Case &H18
                ' Grass, green
                Return ColorToGrayScale(Color.FromArgb(0, &HCC, 0))
            Case &H1E
                ' Swamp, bright green
                Return ColorToGrayScale(Color.FromArgb(0, &HFF, 0))
            Case &H28
                ' Water, blue
                Return Color.FromArgb(&H33, 0, &HCC)
            Case &H56
                ' Stone wall, dark grey
                Return ColorToGrayScale(Color.FromArgb(&H66, &H66, &H66))
            Case &H72
                ' Not sure, maroon
                Return ColorToGrayScale(Color.FromArgb(&H99, &H33, 0))
            Case &H79
                ' Dirt, brown
                Return ColorToGrayScale(Color.FromArgb(&H99, &H66, &H33))
            Case &H81
                ' Paths, tile floors, other floors
                Return ColorToGrayScale(Color.FromArgb(&H99, &H99, &H99))
            Case &HB3
                ' Ice, light blue
                Return ColorToGrayScale(Color.FromArgb(&HCC, &HFF, &HFF))
            Case &HBA
                ' Walls, red
                Return ColorToGrayScale(Color.FromArgb(&HFF, &H33, 0))
            Case &HC0
                ' Lava, orange
                Return ColorToGrayScale(Color.FromArgb(&HFF, &H66, 0))
            Case &HCF
                ' Sand, tan
                Return ColorToGrayScale(Color.FromArgb(&HFF, &HCC, &H99))
            Case &HD2
                ' Ladder, yellow
                Return ColorToGrayScale(Color.FromArgb(&HFF, &HFF, 0))
            Case 0
                ' Nothing, black
                Return Color.Black
            Case Else
                ' Unknown, white
                'this.Text = "" + b;
                Return Color.White
        End Select
    End Function
#End Region

#Region "Zoom and positioning"
    Protected Overrides Sub OnMouseWheel(ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Delta > 0 Then
            Zoom(2)
        Else
            Zoom(0.5)
        End If
        'MyBase.OnMouseWheel(e)
    End Sub

    Protected Overrides Sub OnMouseClick(ByVal e As System.Windows.Forms.MouseEventArgs)
        Me.GetContainerControl.ActiveControl = Me
        MyBase.OnMouseClick(e)
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            mouseIsDown = True
            Downpos = e.Location
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            rightIsDown = True
            zoomRectStart = DisplayPointToGlobalLoc(e.Location)
            zoomRectEnd = DisplayPointToGlobalLoc(e.Location)
        End If
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            mouseIsDown = False
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            HighlightContext.Show(Me, e.Location)
            rightIsDown = False
        End If
        MyBase.OnMouseDown(e)
    End Sub

    Protected Sub MenuClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim I As MenuItem = CType(sender, MenuItem)
        If I.Text.ToLower = "zoom to" Then
            Dim factor As Double = 2

            If ZoomFactor * factor <= 20 Then
                Zoom(factor)
            End If


            Dim rectCenter As New Location
            MaxSwap(zoomRectEnd.x, zoomRectStart.x)
            MaxSwap(zoomRectEnd.y, zoomRectStart.y)
            rectCenter.x = zoomRectStart.x + (zoomRectEnd.x - zoomRectStart.x) \ 2
            rectCenter.y = zoomRectStart.y + (zoomRectEnd.y - zoomRectStart.y) \ 2

            DrawPos = GlobalLocToCenterDisplayPoint(rectCenter)
        ElseIf I.Text.ToLower = "Share Region" Then
            RaiseEvent RegionShared(zoomRectStart, zoomRectEnd)
        End If

        Me.GetContainerControl.ActiveControl = Me
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        If mouseIsDown Then
            Dim TempDrawPos As New Point(DrawPos.X - (Downpos.X - e.X), DrawPos.Y - (Downpos.Y - e.Y))

            If Me.DisplayRectangle.IntersectsWith(New Rectangle(TempDrawPos, DrawSize)) Then
                DrawPos = TempDrawPos
            End If

            Downpos = e.Location
        ElseIf rightIsDown Then
            zoomRectEnd = DisplayPointToGlobalLoc(e.Location)
        End If

        Me.Invalidate()
        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnPreviewKeyDown(ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.Add Then e.IsInputKey = True
        MyBase.OnPreviewKeyDown(e)
    End Sub

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case e.KeyChar
            Case "-"
                If CurrentZ = FloorMax Then Exit Select
                If Loading And FloorImages(CurrentZ + 1) Is Nothing Then Exit Select
                CurrentZ += 1
                UpdateMap()
            Case "+"
                If CurrentZ = FloorMin Then Exit Select
                If Loading And FloorImages(CurrentZ - 1) Is Nothing Then Exit Select
                CurrentZ -= 1
                UpdateMap()
        End Select

        MyBase.OnKeyPress(e)
    End Sub

    Public Sub Zoom(ByVal Factor As Double)
        If ZoomFactor * Factor > 20 Then Exit Sub
        If ZoomFactor * Factor < 0.12 Then Exit Sub
        Dim mapcenter As Location = DisplayPointToGlobalLoc(New Point(Me.Width \ 2, Me.Height \ 2))

        DrawSize.Width *= Factor
        DrawSize.Height *= Factor
        ZoomFactor *= Factor

        DrawPos = GlobalLocToCenterDisplayPoint(mapcenter)
        Invalidate()
    End Sub

    Private Function GlobalLocToCenterDisplayPoint(ByVal G As Location) As Point
        Dim P As Point = GlobalLocToDisplayPoint(G)
        Dim CenterX As Integer = Me.DrawPos.X + (Me.Width \ 2 - P.X)
        Dim Centery As Integer = Me.DrawPos.Y + (Me.Height \ 2 - P.Y)
        Return New Point(CenterX, Centery)
    End Function

    Private Function GlobalLocToDisplayPoint(ByVal G As Location) As Point
        Return New Point((G.x - LowerBounds.X) * ZoomFactor + DrawPos.X, (G.y - LowerBounds.Y) * ZoomFactor + DrawPos.Y)
    End Function

    Private Function GlobalLocToMapPoint(ByVal G As Location) As Point
        Return New Point((G.x - LowerBounds.X), (G.y - LowerBounds.Y))
    End Function

    Private Function DisplayPointToGlobalLoc(ByVal p As Point) As Location
        Return New Location(CDbl(p.X - DrawPos.X) / ZoomFactor + LowerBounds.X, CDbl(p.Y - DrawPos.Y) / ZoomFactor + LowerBounds.Y, CurrentZ)
    End Function
#End Region

#Region "Draw"
    Protected Overloads Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not Loaded Then Exit Sub
        e.Graphics.Clear(Color.Black)

        'Draw the map
        e.Graphics.DrawImage(FloorImages(CurrentZ), New Rectangle(DrawPos, DrawSize))

        'Triangulation
        Dim P As Point() = Triangulate()
        If Not P.Length = 0 Then
            e.Graphics.FillClosedCurve(New Pen(Color.FromArgb(90, 255, 10, 10)).Brush, P)
            e.Graphics.DrawClosedCurve(Pens.Red, P)
        End If

        'Shared Rects
        For Each Pl As String In ShareRects.Keys
            Dim Temp As PlayerRect = ShareRects(Pl)
            Dim ClickRect As New Rectangle
            ClickRect.Location = GlobalLocToDisplayPoint(Temp.Pos1)
            Dim Offsetpoint As Point = GlobalLocToDisplayPoint(Temp.Pos2)
            ClickRect.Width = Offsetpoint.X - ClickRect.X
            ClickRect.Height = Offsetpoint.Y - ClickRect.Y

            e.Graphics.FillRectangle(New Pen(Color.FromArgb(90, 255, 255, 10)).Brush, ClickRect)
            e.Graphics.DrawRectangle(Pens.Yellow, ClickRect)

            Dim TempMeasurement As Integer = e.Graphics.MeasureString(Pl & "'s share", Me.Font).Width
            If TempMeasurement < ClickRect.Width Then
                e.Graphics.DrawString(Pl & "'s share", Me.Font, Brushes.Gold, ClickRect)
            Else
                e.Graphics.DrawString(Pl & "'s share", Me.Font, Brushes.Gold, ClickRect.X, ClickRect.Y + ClickRect.Height + 3)
            End If
        Next


        'Selection
        If rightIsDown Then
            Dim ClickRect As New Rectangle
            ClickRect.Location = GlobalLocToDisplayPoint(zoomRectStart)
            Dim Offsetpoint As Point = GlobalLocToDisplayPoint(zoomRectEnd)
            MaxSwap(Offsetpoint.X, ClickRect.X)
            MaxSwap(Offsetpoint.Y, ClickRect.Y)
            ClickRect.Width = Offsetpoint.X - ClickRect.X
            ClickRect.Height = Offsetpoint.Y - ClickRect.Y

            e.Graphics.FillRectangle(New Pen(Color.FromArgb(90, 20, 10, 255)).Brush, ClickRect)
            e.Graphics.DrawRectangle(Pens.Blue, ClickRect)
        End If



        'Status text
        Dim DisplayString As String = ""
        If Loading Then
            DisplayString += "Loading Map Floor " & CurrentZ & " [" & LoadPercent & "%]" & vbNewLine
        End If

        DisplayString += "Current Zoom Ratio: " & Math.Round(ZoomFactor, 2) & ":1" & vbNewLine
        Dim center As Location = DisplayPointToGlobalLoc(New Point(Me.Width \ 2, Me.Height \ 2))
        DisplayString += "Map Center Position: " & center.x & " " & center.y & " " & CurrentZ & vbNewLine

        e.Graphics.DrawString(DisplayString, Me.Font, Brushes.DimGray, 3, 3)
        e.Graphics.DrawString(DisplayString, Me.Font, Brushes.WhiteSmoke, 2, 2)
    End Sub

    Public Function Triangulate() As Point()
        Dim Polys As New List(Of geoPolygon)

        For Each E As ExivaPlayer In Exivas
            Dim Angle1 As Double = E.Direction / 10
            Dim Angle2 As Double = (E.Direction / 10) + (DirectionalAngles.GlobalSweep / 10)
            Dim RadiusLow, RadiusHigh As Integer

            Select Case E.Distance
                Case ExivaDistance.Far
                    RadiusLow = 101
                    RadiusHigh = 275
                Case ExivaDistance.VeryFar
                    RadiusLow = 276
                    RadiusHigh = Math.Sqrt(Math.Abs((UpperBounds.X - LowerBounds.X) ^ 2 + (UpperBounds.Y - LowerBounds.Y) ^ 2))
                Case Else
                    RadiusLow = 5
                    RadiusHigh = 100
            End Select

            'Oder
            'Low radius, low angle point
            'High radius, low angle point
            'High radius, high angle point
            'High radius, Low angle point
            Dim Points As geoPoint() = New geoPoint() { _
            New geoPoint(E.FromLoc.x + Math.Cos(Angle1 * 0.01745) * RadiusLow, E.FromLoc.y + Math.Sin(Angle1 * 0.01745) * RadiusLow), _
            New geoPoint(E.FromLoc.x + Math.Cos(Angle1 * 0.01745) * RadiusHigh, E.FromLoc.y + Math.Sin(Angle1 * 0.01745) * RadiusHigh), _
            New geoPoint(E.FromLoc.x + Math.Cos(Angle2 * 0.01745) * RadiusHigh, E.FromLoc.y + Math.Sin(Angle2 * 0.01745) * RadiusHigh), _
            New geoPoint(E.FromLoc.x + Math.Cos(Angle2 * 0.01745) * RadiusLow, E.FromLoc.y + Math.Sin(Angle2 * 0.01745) * RadiusLow)}

            Polys.Add(New geoPolygon(Points))
        Next

        Dim LastOverlap As geoPolygon = Polys(0)
        For i = 1 To Polys.Count - 1
            LastOverlap = LastOverlap.Overlap(Polys(i))
        Next

        Dim DrawPoints As New List(Of Point)
        For i = 0 To LastOverlap.PointCount - 1
            DrawPoints.Add(GlobalLocToDisplayPoint(New Location(LastOverlap.GetPoint(i).X, LastOverlap.GetPoint(i).Y, 7, 0)))
        Next

        Return DrawPoints.ToArray
    End Function
#End Region


End Class
