Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Collections.Generic

Public Module TibiaPathFinder
    Private PathFinder As New AStarPathFinder
    Private MapFileDimension As Integer = 256
    Private AutoMapPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Tibia\Automap\"

    Private Function GetMapFileName(ByVal x As UInteger, ByVal y As UInteger, ByVal z As UInteger) As String
        Return CInt(x \ MapFileDimension).ToString("000") + CInt(y \ MapFileDimension).ToString("000") + z.ToString("00") & ".map"
    End Function

    Private Function MapFileNameToLocation(ByVal fileName As String) As Location
        Dim l As New Location(0, 0, 0)
        If fileName.Length = 12 OrElse fileName.Length = 8 Then
            l.x = UInt32.Parse(fileName.Substring(0, 3)) * MapFileDimension
            l.y = UInt32.Parse(fileName.Substring(3, 3)) * MapFileDimension
            l.z = Byte.Parse(fileName.Substring(6, 2))
        End If
        Return l
    End Function

    Private Function LoadGrid() As Location
        Dim FName As String = GetMapFileName(TClient.Self.X, TClient.Self.Y, TClient.Self.Z)
        Dim TopLeft As Location = MapFileNameToLocation(FName)


        Using bs As New BufferedStream(New FileStream(AutoMapPath & FName, FileMode.Open))
            Dim barray As Byte() = New Byte(bs.Length) {}
            bs.Read(barray, 0, bs.Length)
            Dim pos As Integer = 65536

            For x As Integer = 0 To MapFileDimension - 1
                For y As Integer = 0 To MapFileDimension - 1
                    Dim b As Byte = barray(pos)

                    If x + TopLeft.x >= TClient.Self.X - 8 AndAlso x + TopLeft.x <= TClient.Self.X + 8 Then
                        If y + TopLeft.y >= TClient.Self.Y - 6 AndAlso y + TopLeft.y <= TClient.Self.Y + 6 Then
                            PathFinder.Grid((TopLeft.x + x + 8) - TClient.Self.X, (TopLeft.y + y + 6) - TClient.Self.Y) = ByteToNode(b)
                        End If
                    End If

                    pos += 1
                Next
            Next
        End Using
    End Function

    Public Function ByteToNode(ByVal b As Byte) As Byte
        Select Case b
            Case &HFF 'Not Walkale
                Return 0
            Case &HFA 'Unknown or empty
                Return 0
            Case Else 'walkable
                Return 1
        End Select
    End Function

    Public Function PathFound(ByVal Start As Location, ByVal [End] As Location)
        LoadGrid()
        Start = New Location(TClient.Self.X, TClient.Self.Y, TClient.Self.Z)
        [End] = New Location(TClient.Self.X + 6, TClient.Self.Y + 5, TClient.Self.Z)

        TClient.DisplayAnimatedText(Client.TextColor.Crystal, "Start", Start)
        TClient.DisplayAnimatedText(Client.TextColor.Red, "End", [End])

        Start = New Location((Start.x - TClient.Self.X) + 8, (Start.y - TClient.Self.Y) + 6, Start.z)
        [End] = New Location(([End].x - TClient.Self.X) + 8, ([End].y - TClient.Self.Y) + 6, [End].z)

        If PathFinder.FindPath(Start, [End]) Then
            TClient.DisplayTextMessage(Client.TextMessageColor.Green, "Found")
        End If


    End Function
End Module
