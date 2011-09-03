'Imports System
'Imports System.Windows.Forms
'Imports System.IO
'Imports System.Drawing
'Imports System.Drawing.Imaging
'Imports System.Collections.Generic
'Public Class MapViewer
'    Inherits Panel

'#Region "Events"
'    Public Event Centered(ByVal l As Location)
'#End Region

'#Region "Constants"
'    Private Const MapFileDimension As Integer = 256
'    Private Const FloorMax As Integer = 15
'    Private Const FloorMin As Integer = 0
'    Private Const MaskOT As String = "0??0??"
'    Private Const MaskReal As String = "1??1??"
'#End Region

'#Region "Settings"
'    ' Public Delegates
'    Public Delegate Sub MapFloorToImagePercentCallback(ByVal percentageComplete As Integer)

'    ' Public Settings
'    Private m_drawCrosshair As Boolean = True
'    Private m_drawCoors As Boolean = True
'    Private m_openTibiaMaps As Boolean = False
'    Private m_directory As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Tibia\Automap\"
'    'Private m_markers As New List(Of NavPosition)()


'    Private _drawNames As Boolean
'    Private _allFloors As Boolean

'    Public Property DrawNames() As Boolean
'        Get
'            Return _drawNames
'        End Get
'        Set(ByVal value As Boolean)
'            _drawNames = value
'        End Set
'    End Property

'    Public Property AllNameFloors() As Boolean
'        Get
'            Return _allFloors
'        End Get
'        Set(ByVal value As Boolean)
'            _allFloors = value
'        End Set
'    End Property

'    Public Property DrawCrosshair() As Boolean
'        Get
'            Return m_drawCrosshair
'        End Get
'        Set(ByVal value As Boolean)
'            m_drawCrosshair = value
'        End Set
'    End Property

'    Public Property DrawCoors() As Boolean
'        Get
'            Return m_drawCoors
'        End Get
'        Set(ByVal value As Boolean)
'            m_drawCoors = value
'        End Set
'    End Property

'    Public Property OpenTibiaMaps() As Boolean
'        Get
'            Return m_openTibiaMaps
'        End Get
'        Set(ByVal value As Boolean)
'            m_openTibiaMaps = value
'        End Set
'    End Property

'    Public Property Directory() As String
'        Get
'            Return m_directory
'        End Get
'        Set(ByVal value As String)
'            m_directory = value
'        End Set
'    End Property

'    'Public Property Markers() As List(Of NavPosition)
'    '    Get
'    '        Return m_markers
'    '    End Get
'    '    Set(ByVal value As List(Of NavPosition))
'    '        m_markers = value
'    '    End Set
'    'End Property
'#End Region

'#Region "Private Variables"
'    Private canDrawPercentBar As Boolean = False
'    Private percent As Integer = 0
'    Private mapBoundary As Rectangle
'    Private currentZ As Integer = 7
'    Private floorImages As Bitmap() = New Bitmap(FloorMax) {}
'    Private startingPos As Point
'    Private imagePos As New Point(0, 0)
'    Private imageSize As Size
'    Private mapImage As Image
'    Private zoomFactor As Double = 1
'#End Region

'#Region "Constructor"
'    Public Sub New()
'        ' Set the value of the double-buffering style bits to true.
'        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)

'        Me.UpdateStyles()

'        'm_markers = New List(Of NavPosition)()
'    End Sub
'#End Region

'#Region "Handlers"
'    Protected Overloads Overrides Sub OnCreateControl()
'        MyBase.OnCreateControl()
'        'm_markers = New List(Of NavPosition)()
'    End Sub
'    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
'        MyBase.OnKeyDown(e)
'    End Sub

'    Protected Overloads Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
'        Zoom(If((e.Delta > 0), 2, 0.5))
'        Invalidate()
'    End Sub

'    Protected Overloads Overrides Sub OnMouseDoubleClick(ByVal e As MouseEventArgs)
'        SetMapCenter(PointToMapCoors(New Point(e.X, e.Y)))
'        Invalidate()
'    End Sub

'    Protected Overloads Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
'        Select Case e.Button
'            Case MouseButtons.Left
'                startingPos.X = e.X
'                startingPos.Y = e.Y
'                Exit Select
'            Case MouseButtons.Middle
'                Exit Select
'        End Select
'    End Sub

'    Protected Overloads Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
'        If e.Button = MouseButtons.Left Then
'            imagePos.X += e.X - startingPos.X
'            imagePos.Y += e.Y - startingPos.Y
'            startingPos.X = e.X
'            startingPos.Y = e.Y
'            Invalidate()

'            RaiseEvent Centered(GetMapCenter)
'        End If
'    End Sub

'    Protected Overloads Overrides Sub OnPaint(ByVal e As PaintEventArgs)
'        RedrawMap(e.Graphics)
'    End Sub

'    Protected Overloads Overrides Sub OnResize(ByVal e As EventArgs)
'        Invalidate()
'    End Sub
'#End Region

'#Region "Static Methods"
'    ''' <summary>
'    ''' Get the boundary coordinates of an array of map files
'    ''' </summary>
'    ''' <param name="mapFiles"></param>
'    ''' <returns></returns>
'    Private Shared Function GetBoundary(ByVal mapFiles As FileInfo()) As Rectangle
'        Dim left As Integer = 0
'        Dim right As Integer = 0
'        Dim top As Integer = 0
'        Dim bottom As Integer = 0
'        Dim first As Boolean = True
'        For Each mapFile As FileInfo In mapFiles
'            Dim l As Location = MapFileNameToLocation(mapFile.Name)
'            If first Then
'                left = InlineAssignHelper(right, l.x)
'                top = InlineAssignHelper(bottom, l.y)
'                first = False
'            Else
'                If l.x < left Then
'                    left = l.x
'                ElseIf l.x > right Then
'                    right = l.x
'                End If

'                If l.y < top Then
'                    top = l.y
'                ElseIf l.y > bottom Then
'                    bottom = l.y
'                End If
'            End If
'        Next
'        Return New Rectangle(left, top, (right - left) + MapFileDimension, (bottom - top) + MapFileDimension)
'    End Function

'    ''' <summary>
'    ''' Get a map file name from coordinates
'    ''' </summary>
'    ''' <param name="directory"></param>
'    ''' <param name="x"></param>
'    ''' <param name="y"></param>
'    ''' <param name="z"></param>
'    ''' <returns></returns>
'    Private Shared Function GetMapFileName(ByVal directory As String, ByVal x As UInteger, ByVal y As UInteger, ByVal z As UInteger) As String
'        Return directory + CInt(x \ MapFileDimension).ToString("000") + CInt(y \ MapFileDimension).ToString("000") + z.ToString("00") & ".map"
'    End Function

'    ''' <summary>
'    ''' Convert a map file name to a location
'    ''' </summary>
'    ''' <param name="fileName"></param>
'    ''' <returns></returns>
'    Private Shared Function MapFileNameToLocation(ByVal fileName As String) As Location
'        Dim l As New Location(0, 0, 0)
'        If fileName.Length = 12 OrElse fileName.Length = 8 Then
'            l.x = UInt32.Parse(fileName.Substring(0, 3)) * MapFileDimension
'            l.y = UInt32.Parse(fileName.Substring(3, 3)) * MapFileDimension
'            l.z = Byte.Parse(fileName.Substring(6, 2))
'        End If
'        Return l
'    End Function

'    ''' <summary>
'    ''' Read a map file into an image
'    ''' </summary>
'    ''' <param name="path"></param>
'    ''' <returns></returns>
'    Public Shared Function MapFileToImage(ByVal path As String) As Image
'        ' All map files are 256 x 256
'        Dim bitmap As New Bitmap(MapFileDimension, MapFileDimension)

'        ' Make sure the file actually exists
'        If File.Exists(path) Then
'            ' Open the file in a BufferedStream
'            Using bs As New BufferedStream(New FileStream(path, FileMode.Open))
'                ' Each map file contains this many pixels
'                Dim array As Byte() = New Byte(65535) {}

'                ' Read all of them at once (much faster than byte by byte) into an array
'                bs.Read(array, 0, 65536)

'                ' Loop through the array
'                Dim index As Integer = 0
'                For x As Integer = 0 To MapFileDimension - 1
'                    For y As Integer = 0 To MapFileDimension - 1
'                        Dim b As Byte = array(index)

'                        ' Set the pixel on the bitmap, converting the byte a color
'                        bitmap.SetPixel(x, y, ByteToColor(b))
'                        index += 1
'                    Next
'                Next
'            End Using
'        End If

'        Return bitmap
'    End Function

'    ''' <summary>
'    ''' Convert a map file byte to a color
'    ''' </summary>
'    ''' <param name="b"></param>
'    ''' <returns></returns>
'    Public Shared Function ByteToColor(ByVal b As Byte) As Color
'        Select Case b
'            Case &HC
'                ' Foliage, dark green
'                Return Color.FromArgb(0, &H66, 0)
'            Case &H18
'                ' Grass, green
'                Return Color.FromArgb(0, &HCC, 0)
'            Case &H1E
'                ' Swamp, bright green
'                Return Color.FromArgb(0, &HFF, 0)
'            Case &H28
'                ' Water, blue
'                Return Color.FromArgb(&H33, 0, &HCC)
'            Case &H56
'                ' Stone wall, dark grey
'                Return Color.FromArgb(&H66, &H66, &H66)
'            Case &H72
'                ' Not sure, maroon
'                Return Color.FromArgb(&H99, &H33, 0)
'            Case &H79
'                ' Dirt, brown
'                Return Color.FromArgb(&H99, &H66, &H33)
'            Case &H81
'                ' Paths, tile floors, other floors
'                Return Color.FromArgb(&H99, &H99, &H99)
'            Case &HB3
'                ' Ice, light blue
'                Return Color.FromArgb(&HCC, &HFF, &HFF)
'            Case &HBA
'                ' Walls, red
'                Return Color.FromArgb(&HFF, &H33, 0)
'            Case &HC0
'                ' Lava, orange
'                Return Color.FromArgb(&HFF, &H66, 0)
'            Case &HCF
'                ' Sand, tan
'                Return Color.FromArgb(&HFF, &HCC, &H99)
'            Case &HD2
'                ' Ladder, yellow
'                Return Color.FromArgb(&HFF, &HFF, 0)
'            Case 0
'                ' Nothing, black
'                Return Color.Black
'            Case Else
'                ' Unknown, white
'                'this.Text = "" + b;
'                Return Color.White
'        End Select
'    End Function
'#End Region

'#Region "Map File Loading"
'    Private Sub Percret(ByVal percentage As Integer)
'        Me.percent = percentage
'        Invalidate()
'    End Sub

'    ''' <summary>
'    ''' Load the map into the picturebox at the currentZ level.
'    ''' Uses two level caching: the generated bitmap is saved as
'    ''' a png file in the map directory, and the Bitmap object
'    ''' is saved in memory.
'    ''' </summary>
'    Public Sub LoadMap()
'        Dim image As Bitmap
'        ' Check if the image is already in memory
'        If floorImages(currentZ) IsNot Nothing Then
'            image = floorImages(currentZ)
'        Else
'            Dim dir As String = m_directory

'            ' Open the directory
'            Dim di As New DirectoryInfo(dir)

'            ' Get all the map files
'            Dim mapFiles As FileInfo() = di.GetFiles((If(m_openTibiaMaps, MaskOT, MaskReal)) + currentZ.ToString("00") & ".map")

'            ' Find the boundary
'            Dim r As Rectangle = GetBoundary(mapFiles)
'            mapBoundary = r

'            Dim imageFileName As String = dir + CInt(r.Left \ MapFileDimension).ToString("000") + CInt(r.Top \ MapFileDimension).ToString("000") + currentZ.ToString("00") & ".png"

'            ' Check if we have an image file previously generated
'            If File.Exists(imageFileName) Then
'                image = DirectCast(Bitmap.FromFile(imageFileName), Bitmap)
'            Else
'                image = MapFloorToImage(dir, currentZ, AddressOf Percret)
'                image.Save(imageFileName, ImageFormat.Png)
'            End If
'            floorImages(currentZ) = image
'        End If

'        ' Draw the bitmap on the picture box
'        If imageSize.Width = 0 Then
'            imageSize = image.Size
'        End If
'        mapImage = image
'        SetMapCenter(GetMapCenter)
'        Invalidate()
'    End Sub

'    Public Sub LoadFull()
'        Dim r As Rectangle = New Rectangle(0, 0, 65535, 65535)
'        Dim img As New Bitmap(r.Width, r.Height)
'        'Directory shit
'        Dim dir As String = m_directory
'        Dim di As New DirectoryInfo(dir)
'        Dim mapFiles As FileInfo()
'        Dim array As Byte()
'        'Boundaries
'        Dim l As Location
'        Dim index As Integer

'        For Floor = FloorMin To FloorMax
'            img = New Bitmap(r.Width, r.Height)
'            mapFiles = di.GetFiles("??????" & Floor.ToString("00") & ".map")
'            array = New Byte(65535) {}
'            index = 0

'            For Each mapFile As FileInfo In mapFiles
'                Using bs As New BufferedStream(New FileStream(mapFile.FullName, FileMode.Open))
'                    l = MapFileNameToLocation(mapFile.Name)
'                    ' Read all of them at once (much faster than byte by byte) into an array
'                    bs.Read(array, 0, 65536)
'                    For x = 0 To MapFileDimension - 1
'                        For y = 0 To MapFileDimension - 1
'                            img.SetPixel(l.x + x, l.y + y, ByteToColor(array(index)))
'                            index += 1
'                        Next
'                    Next
'                End Using
'            Next
'            ' Find the boundary
'            'Dim r As Rectangle = GetBoundary(mapFiles)
'            'mapBoundary = r
'            'image = MapFloorToImage(dir, L, AddressOf Percret)
'            floorImages(Floor) = img
'        Next
'        currentZ = 7
'        ' Draw the bitmap on the picture box
'        If imageSize.Width = 0 Then
'            imageSize = floorImages(currentZ).Size
'        End If

'        mapImage = floorImages(currentZ)
'        SetMapCenter(GetMapCenter)
'        Invalidate()
'    End Sub

'    ''' <summary>
'    ''' Get an image of the entire map on the specified floor
'    ''' </summary>
'    ''' <param name="dir"></param>
'    ''' <param name="floor"></param>
'    ''' <returns></returns>
'    Public Function MapFloorToImage(ByVal dir As String, ByVal floor As Integer) As Bitmap
'        Return MapFloorToImage(dir, floor, Nothing)
'    End Function

'    ''' <summary>
'    ''' Get an image of the entire map on the specified floor
'    ''' </summary>
'    ''' <param name="dir"></param>
'    ''' <param name="floor"></param>
'    ''' <param name="callback"></param>
'    ''' <returns></returns>
'    Public Function MapFloorToImage(ByVal dir As String, ByVal floor As Integer, ByVal callback As MapFloorToImagePercentCallback) As Bitmap
'        ' Open the directory
'        Dim di As New DirectoryInfo(dir)

'        ' Get all the map files
'        Dim mapFiles As FileInfo() = di.GetFiles((If(m_openTibiaMaps, MaskOT, MaskReal)) + floor.ToString("00") & ".map")

'        ' Find the boundary
'        Dim r As Rectangle = GetBoundary(mapFiles)

'        ' Create a new bitmap big enough to hold all the map
'        Dim b As New Bitmap(r.Width, r.Height)

'        ' Get the graphics object to draw on the image
'        Dim g As Graphics = Graphics.FromImage(b)

'        ' Set the background to be black
'        g.Clear(Color.Black)

'        ' Keep track of how far along we are
'        Dim total As Integer = mapFiles.Length

'        ' Loop through the map files and draw them onto the bitmap
'        For Each mapFile As FileInfo In mapFiles
'            Dim l As Location = MapFileNameToLocation(mapFile.Name)
'            If l.z = floor Then
'                g.DrawImage(MapFileToImage(dir + mapFile.Name), l.x - r.Left, l.y - r.Top)
'            End If
'        Next

'        Return b
'    End Function
'#End Region

'#Region "Level"
'    ''' <summary>
'    ''' Move down a level
'    ''' </summary>
'    Public Sub LevelUp()
'        If currentZ > FloorMin Then
'            currentZ -= 1
'            Dim center As Location = GetMapCenter()
'            LoadMap()
'            SetMapCenter(center)
'        End If
'    End Sub

'    ''' <summary>
'    ''' Move up a level
'    ''' </summary>
'    Public Sub LevelDown()
'        If currentZ < FloorMax Then
'            currentZ += 1
'            Dim center As Location = GetMapCenter()
'            LoadMap()
'            SetMapCenter(center)
'        End If
'    End Sub

'    ''' <summary>
'    ''' Set the level of the map
'    ''' </summary>
'    ''' <param name="z"></param>
'    Public Sub SetLevel(ByVal z As Integer)
'        If z <> currentZ AndAlso (currentZ < FloorMax OrElse currentZ > FloorMin) Then
'            Dim center As Location = GetMapCenter()
'            currentZ = z
'            LoadMap()
'            SetMapCenter(center)
'        End If
'    End Sub
'#End Region

'#Region "Zoom"
'    ''' <summary>
'    ''' Set the zoom factor for the map
'    ''' </summary>
'    ''' <param name="factor"></param>
'    Public Sub Zoom(ByVal factor As Double)
'        If zoomFactor * factor > 4 Or zoomFactor * factor < 0.05 Then
'            Exit Sub
'        End If

'        Dim center As Location = GetMapCenter()
'        'Dim center As Location = GetMapCenter()

'        zoomFactor *= factor
'        imageSize.Height *= factor
'        imageSize.Width *= factor

'        SetMapCenter(center)
'    End Sub
'#End Region

'#Region "Redraw Map"
'    Private ArrowOffsetAdd As Integer = 1
'    Private ArrowPhase As Integer = 0
'    ''' <summary>
'    ''' Redraw the map (no background redraw)
'    ''' </summary>
'    Private Sub RedrawMap(ByVal g As Graphics)
'        RedrawMap(True, g)
'    End Sub

'    ''' <summary>
'    ''' Redraw the map
'    ''' </summary>
'    ''' <param name="clear">if true clears the background first (produces a flicker)</param>
'    ''' <param name="g"></param>
'    Private Sub RedrawMap(ByVal clear As Boolean, ByVal g As Graphics)
'        If mapImage Is Nothing Then
'            Exit Sub
'        End If

'        If clear Then
'            g.Clear(Color.Black)
'        End If

'        g.DrawImage(mapImage, New Rectangle(imagePos, imageSize))

'        If m_drawCrosshair Then
'            DrawCrosshairs(MapCoorsToPoint(TClient.Self.X, TClient.Self.Y), g)
'        End If

'        If m_drawCoors Then
'            DrawCoordinates(g)
'        End If

'        If ArrowPhase = 2 Then
'            ArrowOffsetAdd = -1
'        ElseIf ArrowPhase = 0 Then
'            ArrowOffsetAdd = 1
'        End If

'        ArrowPhase += ArrowOffsetAdd

'        'If m_markers IsNot Nothing Then
'        '    For Each mc As NavPosition In m_markers
'        '        DrawMarker(mc.Location, mc.Name, Color.WhiteSmoke, Color.Black, Color.WhiteSmoke, Color.Black, g)
'        '    Next
'        'End If

'        DrawCenterPointer(g)
'    End Sub
'#End Region

'#Region "Coordinate Helpers"
'    ''' <summary>
'    ''' Convert Tibia coordinates to a point on the map
'    ''' </summary>
'    ''' <param name="x"></param>
'    ''' <param name="y"></param>
'    ''' <returns></returns>
'    Public Function MapCoorsToPoint(ByVal x As Integer, ByVal y As Integer) As Point
'        Return MapCoorsToPoint(New Location(x, y, currentZ))
'    End Function

'    ''' <summary>
'    ''' Convert a Tibia Location to a point on the map
'    ''' </summary>
'    ''' <param name="l"></param>
'    ''' <returns></returns>
'    Public Function MapCoorsToPoint(ByVal l As Location) As Point
'        Dim x As Integer = l.x
'        Dim y As Integer = l.y
'        Dim newX As Integer = CInt(((x - mapBoundary.Left) * zoomFactor)) + imagePos.X
'        Dim newY As Integer = CInt(((y - mapBoundary.Top) * zoomFactor)) + imagePos.Y

'        Return New Point(newX, newY)
'    End Function

'    ''' <summary>
'    ''' Convert a point on the map to a Tibia location
'    ''' </summary>
'    ''' <param name="p"></param>
'    ''' <returns></returns>
'    Public Function PointToMapCoors(ByVal p As Point) As Location
'        Dim newX As Integer = CInt(((p.X - imagePos.X) / zoomFactor + mapBoundary.Left))
'        Dim newY As Integer = CInt(((p.Y - imagePos.Y) / zoomFactor + mapBoundary.Top))

'        Return New Location(newX, newY, currentZ)
'    End Function

'    ''' <summary>
'    ''' Get the point at the center of the picturebox
'    ''' </summary>
'    ''' <returns></returns>
'    Public Function GetMapCenterPoint() As Point
'        Dim x As Integer = Width / 2
'        Dim y As Integer = Height / 2

'        Return New Point(x, y)
'    End Function

'    ''' <summary>
'    ''' Set the center of the map to a Tibia Location
'    ''' </summary>
'    ''' <param name="l"></param>
'    Public Sub SetMapCenter(ByVal l As Location)
'        Dim center As Point = GetMapCenterPoint()

'        Dim newX As Integer = CInt(((l.x - mapBoundary.Left) * zoomFactor * -1 + center.X))
'        Dim newY As Integer = CInt(((l.y - mapBoundary.Top) * zoomFactor * -1 + center.Y))

'        imagePos.X = newX
'        imagePos.Y = newY
'        RaiseEvent Centered(l)
'        Invalidate()
'    End Sub

'    ''' <summary>
'    ''' Get the center of the map in Tibia Coordinates
'    ''' </summary>
'    ''' <returns></returns>
'    Public Function GetMapCenter() As Location
'        Return PointToMapCoors(GetMapCenterPoint())
'    End Function


'    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
'        target = value
'        Return value
'    End Function
'#End Region

'#Region "Draw Helpers"
'    ''' <summary>
'    ''' Draw crosshairs at the specified point
'    ''' </summary>
'    ''' <param name="x"></param>
'    ''' <param name="y"></param>
'    ''' <param name="g"></param>
'    Private Sub DrawCrosshairs(ByVal x As Integer, ByVal y As Integer, ByVal g As Graphics)
'        DrawCrosshairs(New Point(x, y), g)
'    End Sub

'    ''' <summary>
'    ''' Draw crosshairs at the specified point
'    ''' </summary>
'    ''' <param name="p"></param>
'    ''' <param name="g"></param>
'    Private Sub DrawCrosshairs(ByVal p As Point, ByVal g As Graphics)
'        Dim x As Integer = p.X
'        Dim y As Integer = p.Y

'        ' Draw the vertical line
'        g.DrawLine(New Pen(Color.White, 2), New Point(x - 5, y), New Point(x + 5, y))
'        ' Draw the horizontal line
'        g.DrawLine(New Pen(Color.White, 2), New Point(x, y - 5), New Point(x, y + 5))
'    End Sub

'    Private Sub DrawCenterPointer(ByVal g As Graphics)
'        Dim L As Point = New System.Drawing.Point(Me.Width \ 2, Me.Height \ 2)

'        ' Draw the vertical line
'        DrawStraitDashedLine(New Pen(Color.White, 1), New Point(L.X - Me.Width \ 2, L.Y), New Point(L.X + Me.Width \ 2, L.Y), g)
'        g.DrawLine(New Pen(Color.White, 1), New Point(L.X - 5, L.Y), New Point(L.X + 5, L.Y))
'        ' Draw the horizontal line
'        DrawStraitDashedLine(New Pen(Color.White, 1), New Point(L.X, L.Y - Me.Height \ 2), New Point(L.X, L.Y + Me.Height \ 2), g)
'        g.DrawLine(New Pen(Color.White, 1), New Point(L.X, L.Y - 5), New Point(L.X, L.Y + 5))
'    End Sub

'    Private Sub DrawStraitDashedLine(ByVal Penz As Pen, ByVal L1 As Point, ByVal L2 As Point, ByVal G As Graphics)

'        If Math.Abs(L2.X - L1.X) > Math.Abs(L2.Y - L1.Y) Then
'            For x = L1.X To L2.X Step 3
'                G.DrawLine(Penz, x, L1.Y, x + 1, L2.Y)
'            Next
'        Else
'            For y = L1.Y To L2.Y Step 3
'                G.DrawLine(Penz, L1.X, y, L2.X, y + 1)
'            Next
'        End If

'    End Sub

'    ''' <summary>
'    ''' Draw the current coordinates of the center point in the upper right corner
'    ''' </summary>
'    Private Sub DrawCoordinates(ByVal g As Graphics)
'        Dim l As Location = GetMapCenter()

'        Dim font As New Font("Tahoma", 10, FontStyle.Bold)
'        Dim rect As New Rectangle(Width - 120, 0, 120, font.Height)

'        ' g.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), rect);
'        g.FillRectangle(Brushes.Black, rect)

'        Dim sf As New StringFormat()
'        sf.Alignment = StringAlignment.Center
'        g.DrawString(("" & l.x & ", ") + l.y, font, Brushes.White, rect, sf)
'    End Sub

'    ''' <summary>
'    ''' Draw a marker with the default colors.
'    ''' </summary>
'    ''' <param name="l"></param>
'    ''' <param name="text"></param>
'    ''' <param name="g"></param>
'    Private Sub DrawMarker(ByVal l As Location, ByVal text As String, ByVal g As Graphics)
'        DrawMarker(l, text, Color.Yellow, Color.Black, g)
'    End Sub

'    ''' <summary>
'    ''' Draw a marker with the default text fill and outline colors.
'    ''' </summary>
'    ''' <param name="l"></param>
'    ''' <param name="text"></param>
'    ''' <param name="markerFill"></param>
'    ''' <param name="markerOutline"></param>
'    ''' <param name="g"></param>
'    Private Sub DrawMarker(ByVal l As Location, ByVal text As String, ByVal markerFill As Color, ByVal markerOutline As Color, ByVal g As Graphics)
'        DrawMarker(l, text, markerFill, markerOutline, Color.White, Color.Black, _
'         g)
'    End Sub

'    ''' <summary>
'    ''' Draw a marker given the specifications.
'    ''' </summary>
'    ''' <param name="l"></param>
'    ''' <param name="text"></param>
'    ''' <param name="markerFill"></param>
'    ''' <param name="markerOutline"></param>
'    ''' <param name="textFill"></param>
'    ''' <param name="textOutline"></param>
'    ''' <param name="g"></param>
'    Private Sub DrawMarker(ByVal l As Location, ByVal text As String, ByVal markerFill As Color, ByVal markerOutline As Color, ByVal textFill As Color, ByVal textOutline As Color, ByVal g As Graphics)
'        If _drawNames Then
'            ' Convert to Tibia coors
'            Dim p As Point = MapCoorsToPoint(l)

'            ' Anti-aliased for nice effect
'            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

'            ' The text font
'            Dim font As New Font("Tahoma", 8, FontStyle.Regular)

'            ' The rectangle to hold the text
'            Dim rect As Rectangle

'            If l.z > Me.currentZ And _allFloors Then 'lower floor
'                Dim points As Point() = _
'            {New Point(p.X - 3, p.Y - ArrowPhase - 15), _
'             New Point(p.X + 3, p.Y - ArrowPhase - 15), _
'             New Point(p.X + 3, p.Y - ArrowPhase - 10), _
'             New Point(p.X + 7, p.Y - ArrowPhase - 10), _
'             New Point(p.X, p.Y - ArrowPhase), _
'             New Point(p.X - 7, p.Y - ArrowPhase - 10), _
'             New Point(p.X - 3, p.Y - ArrowPhase - 10)}

'                g.FillPolygon(New SolidBrush(markerFill), points)
'                g.DrawPolygon(New Pen(markerOutline), points)

'                rect = New Rectangle(p.X + 5, p.Y - font.Height - 5, 200, font.Height)
'            ElseIf l.z < Me.currentZ And _allFloors Then 'higher floor
'                Dim points As Point() = _
'            {New Point(p.X - 3, p.Y + ArrowPhase + 15), _
'             New Point(p.X + 3, p.Y + ArrowPhase + 15), _
'             New Point(p.X + 3, p.Y + ArrowPhase + 10), _
'             New Point(p.X + 7, p.Y + ArrowPhase + 10), _
'             New Point(p.X, p.Y + ArrowPhase), _
'             New Point(p.X - 7, p.Y + ArrowPhase + 10), _
'             New Point(p.X - 3, p.Y + ArrowPhase + 10)}

'                g.FillPolygon(New SolidBrush(markerFill), points)
'                g.DrawPolygon(New Pen(markerOutline), points)
'                rect = New Rectangle(p.X + 5, p.Y + font.Height - 5, 200, font.Height)
'            ElseIf l.z = Me.currentZ Then 'same floor
'                g.FillEllipse(New SolidBrush(markerFill), p.X - 6, p.Y - 6, 12, 12)
'                g.DrawEllipse(New Pen(markerOutline), p.X - 6, p.Y - 6, 12, 12)
'                rect = New Rectangle(p.X + 6, p.Y - 6, 200, font.Height)
'            End If

'            ' Center the text
'            Dim sf As New StringFormat()
'            sf.Alignment = StringAlignment.Near

'            ' Draw the outlined text
'            DrawOutlinedText(text, font, New SolidBrush(textFill), New SolidBrush(textOutline), rect, sf, g)
'        End If
'    End Sub

'    ''' <summary>
'    ''' Draw the specified text with an outline
'    ''' </summary>
'    ''' <param name="text"></param>
'    ''' <param name="font"></param>
'    ''' <param name="fill"></param>
'    ''' <param name="outline"></param>
'    ''' <param name="rect"></param>
'    ''' <param name="sf"></param>
'    ''' <param name="g"></param>
'    Private Sub DrawOutlinedText(ByVal text As String, ByVal font As Font, ByVal fill As Brush, ByVal outline As Brush, ByVal rect As Rectangle, ByVal sf As StringFormat, _
'     ByVal g As Graphics)
'        ' Draw the outline by offsetting the rectangle
'        rect.Offset(-1, -1)
'        g.DrawString(text, font, outline, rect, sf)
'        rect.Offset(2, 0)
'        g.DrawString(text, font, outline, rect, sf)
'        rect.Offset(0, 2)
'        g.DrawString(text, font, outline, rect, sf)
'        rect.Offset(-2, 0)
'        g.DrawString(text, font, outline, rect, sf)

'        ' Return to the original position and draw the fill
'        rect.Offset(1, -1)
'        g.DrawString(text, font, fill, rect, sf)
'    End Sub
'#End Region
'End Class

