Public Enum WalkingDirection As Byte
    North = 0
    NorthEast = 1
    NorthWest = 2
    East = 3
    West = 4
    None = 5
    South = 6
    SouthEast = 7
    SouthWest = 8
End Enum


Partial Public Class Client
    Private CurrentKeepDirection As WalkingDirection = WalkingDirection.None
    Private LastKeepDistaceCreature As Integer

    Public Sub KeepDiagonal()

    End Sub


#Region "Keep distance"
    Public Sub KeepDistance()
        Dim I As Short

        If Not Self.HasTarget Then Exit Sub

        While Self.IsWalking
            Threading.Thread.Sleep(10)

        End While

        If LastKeepDistaceCreature <> Self.Target Then
            LastKeepDistaceCreature = Self.Target
            CurrentKeepDirection = WalkingDirection.None
        End If

        Battlelist.Cache()
        For B = 1 To TClient.Battlelist.Length
            If Battlelist.ID(B) = LastKeepDistaceCreature Then
                I = B
                GoTo Start
            End If
        Next
        LastKeepDistaceCreature = 0
        Exit Sub
Start:
        Select Case CurrentKeepDirection
            Case WalkingDirection.South
                ContinueDistanceSouth(I)
            Case WalkingDirection.SouthEast
                ContinueDistanceSouthEast(I)
            Case WalkingDirection.SouthWest
                ContinueDistanceSouthWest(I)
            Case WalkingDirection.North
                ContinueDistanceNorth(I)
            Case WalkingDirection.NorthEast
                ContinueDistanceNorthEast(I)
            Case WalkingDirection.NorthWest
                ContinueDistanceNorthWest(I)
            Case WalkingDirection.East
                ContinueDistanceEast(I)
            Case WalkingDirection.West
                ContinueDistanceWest(I)
            Case WalkingDirection.None
                If (Battlelist.X(I) > Self.X) And (Battlelist.Y(I) > Self.Y) Then
                    CurrentKeepDirection = WalkingDirection.NorthWest
                    ContinueDistanceNorthWest(I)
                ElseIf (Battlelist.X(I) > Self.X) And (Battlelist.Y(I) < Self.Y) Then
                    CurrentKeepDirection = WalkingDirection.SouthWest
                    ContinueDistanceSouthWest(I)
                ElseIf (Battlelist.X(I) < Self.X) And (Battlelist.Y(I) > Self.Y) Then
                    CurrentKeepDirection = WalkingDirection.NorthEast
                    ContinueDistanceNorthEast(I)
                ElseIf (Battlelist.X(I) < Self.X) And (Battlelist.Y(I) < Self.Y) Then
                    CurrentKeepDirection = WalkingDirection.SouthEast
                    ContinueDistanceSouthEast(I)
                ElseIf (Battlelist.X(I) = Self.X) And (Battlelist.Y(I) > Self.Y) Then
                    CurrentKeepDirection = WalkingDirection.North
                    ContinueDistanceNorth(I)
                ElseIf (Battlelist.X(I) < Self.X) And (Battlelist.Y(I) = Self.Y) Then
                    CurrentKeepDirection = WalkingDirection.East
                    ContinueDistanceEast(I)
                ElseIf (Battlelist.X(I) = Self.X) And (Battlelist.Y(I) < Self.Y) Then
                    CurrentKeepDirection = WalkingDirection.South
                    ContinueDistanceSouth(I)
                ElseIf (Battlelist.X(I) > Self.X) And (Battlelist.Y(I) = Self.Y) Then
                    CurrentKeepDirection = WalkingDirection.West
                    ContinueDistanceWest(I)
                End If
        End Select
    End Sub


    Private Sub ContinueDistanceNorth(ByVal i As Short)
        If Not KeepDistanceNorth(i) Then
            CurrentKeepDirection = WalkingDirection.NorthEast
            ContinueDistanceNorthEast(i)
        End If
    End Sub

    Private Sub ContinueDistanceNorthEast(ByVal i As Short)
        If Not KeepDistanceNorthEast(i) Then
            CurrentKeepDirection = WalkingDirection.East
            ContinueDistanceEast(i)
        End If
    End Sub

    Private Sub ContinueDistanceNorthWest(ByVal i As Short)
        If Not KeepDistanceNorthWest(i) Then
            CurrentKeepDirection = WalkingDirection.North
            ContinueDistanceNorth(i)
        End If
    End Sub

    Private Sub ContinueDistanceWest(ByVal i As Short)
        If Not KeepDistanceWest(i) Then
            CurrentKeepDirection = WalkingDirection.NorthWest
            ContinueDistanceNorthWest(i)
        End If
    End Sub

    Private Sub ContinueDistanceEast(ByVal i As Short)
        If Not KeepDistanceEast(i) Then
            CurrentKeepDirection = WalkingDirection.SouthEast
            ContinueDistanceSouthEast(i)
        End If
    End Sub

    Private Sub ContinueDistanceSouthEast(ByVal i As Short)
        If Not KeepDistanceSouthEast(i) Then
            CurrentKeepDirection = WalkingDirection.South
            ContinueDistanceSouth(i)
        End If
    End Sub

    Private Sub ContinueDistanceSouth(ByVal i As Short)
        If Not KeepDistanceSouth(i) Then
            CurrentKeepDirection = WalkingDirection.SouthWest
            ContinueDistanceSouthWest(i)
        End If
    End Sub

    Private Sub ContinueDistanceSouthWest(ByVal i As Short)
        If Not KeepDistanceSouthWest(i) Then
            CurrentKeepDirection = WalkingDirection.West
            ContinueDistanceWest(i)
        End If
    End Sub

#Region "Keep Distance North"
    Private Function KeepDistanceNorth(ByVal i As Short) As Boolean
        Dim GotoLoc As New Location : GotoLoc.x = 0 : GotoLoc.y = 0
        With Me.Map
            Dim Tile As Short = .GetSelfTile
            If Not .TileIsBlocking(Tile, Battlelist.X(i) + 1, Battlelist.Y(i) - 2, Battlelist.Z(i)) Then
                GotoLoc.x = 1
                GotoLoc.y = -2
            Else
                GoTo leavewith
            End If

            If Not .TileIsBlocking(Tile, Battlelist.X(i) + 1, Battlelist.Y(i) - 3, Battlelist.Z(i)) Then
                GotoLoc.x = 1
                GotoLoc.y = -3
            End If
        End With
LeaveWith:
        If Not GotoLoc.x = 0 And Not GotoLoc.y = 0 Then
            Self.WalkTo(Battlelist.X(i) + GotoLoc.x, Battlelist.Y(i) + GotoLoc.y, Battlelist.Z(i))
            Return True
        Else
            Return False
        End If
    End Function

    Private Function KeepDistanceNorthEast(ByVal i As Short) As Boolean
        Dim GotoLoc As New Location : GotoLoc.x = 0 : GotoLoc.y = 0
        With Me.Map
            Dim Tile As Short = .GetSelfTile
            If Not .TileIsBlocking(Tile, Battlelist.X(i) + 2, Battlelist.Y(i) - 2, Battlelist.Z(i)) Then
                GotoLoc.x = 2
                GotoLoc.y = -2
            Else
                GoTo leavewith
            End If

            If Not .TileIsBlocking(Tile, Battlelist.X(i) + 2, Battlelist.Y(i) - 3, Battlelist.Z(i)) Then
                GotoLoc.x = 2
                GotoLoc.y = -3
            ElseIf .TileIsBlocking(Tile, Battlelist.X(i) + 3, Battlelist.Y(i) - 2, Battlelist.Z(i)) Then
                GotoLoc.x = 3
                GotoLoc.y = -2
            Else
                GoTo leavewith
            End If

            If Not .TileIsBlocking(Tile, Battlelist.X(i) + 3, Battlelist.Y(i) - 3, Battlelist.Z(i)) Then
                GotoLoc.x = 3
                GotoLoc.y = -3
            End If
        End With
LeaveWith:
        If Not GotoLoc.x = 0 And Not GotoLoc.y = 0 Then
            Self.WalkTo(Battlelist.X(i) + GotoLoc.x, Battlelist.Y(i) + GotoLoc.y, Battlelist.Z(i))
            Return True
        Else
            Return False
        End If
    End Function

    Private Function KeepDistanceNorthWest(ByVal i As Short) As Boolean
        Dim GotoLoc As New Location : GotoLoc.x = 0 : GotoLoc.y = 0
        With Me.Map
            Dim Tile As Short = .GetSelfTile
            If Not .TileIsBlocking(Tile, Battlelist.X(i) - 2, Battlelist.Y(i) - 2, Battlelist.Z(i)) Then
                GotoLoc.x = -2
                GotoLoc.y = -2
            Else
                GoTo leavewith
            End If

            If Not .TileIsBlocking(Tile, Battlelist.X(i) - 2, Battlelist.Y(i) - 3, Battlelist.Z(i)) Then
                GotoLoc.x = -2
                GotoLoc.y = -3
            ElseIf Not .TileIsBlocking(Tile, Battlelist.X(i) - 3, Battlelist.Y(i) - 2, Battlelist.Z(i)) Then
                GotoLoc.x = -3
                GotoLoc.y = -2
            Else
                GoTo leavewith
            End If

            If Not .TileIsBlocking(Tile, Battlelist.X(i) - 3, Battlelist.Y(i) - 3, Battlelist.Z(i)) Then
                GotoLoc.x = -3
                GotoLoc.y = -3
            End If
        End With
LeaveWith:
        If Not GotoLoc.x = 0 And Not GotoLoc.y = 0 Then
            Self.WalkTo(Battlelist.X(i) + GotoLoc.x, Battlelist.Y(i) + GotoLoc.y, Battlelist.Z(i))
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "Keep distance West/East"
    Private Function KeepDistanceEast(ByVal i As Short) As Boolean
        Dim GotoLoc As New Location : GotoLoc.x = 0 : GotoLoc.y = 0
        With Me.Map
            Dim Tile As Short = .GetSelfTile
            If Not .TileIsBlocking(Tile, Battlelist.X(i) + 2, Battlelist.Y(i) + 1, Battlelist.Z(i)) Then
                GotoLoc.x = 2
                GotoLoc.y = 1
            Else
                GoTo leavewith
            End If

            If Not .TileIsBlocking(Tile, Battlelist.X(i) + 3, Battlelist.Y(i) + 1, Battlelist.Z(i)) Then
                GotoLoc.x = 3
                GotoLoc.y = 1
            End If
        End With
LeaveWith:
        If Not GotoLoc.x = 0 And Not GotoLoc.y = 0 Then
            Self.WalkTo(Battlelist.X(i) + GotoLoc.x, Battlelist.Y(i) + GotoLoc.y, Battlelist.Z(i))
            Return True
        Else
            Return False
        End If
    End Function

    Private Function KeepDistanceWest(ByVal i As Short) As Boolean
        Dim GotoLoc As New Location : GotoLoc.x = 0 : GotoLoc.y = 0
        With Me.Map
            Dim Tile As Short = .GetSelfTile
            If Not .TileIsBlocking(Tile, Battlelist.X(i) - 2, Battlelist.Y(i) - 1, Battlelist.Z(i)) Then
                GotoLoc.x = -2
                GotoLoc.y = -1
            Else
                GoTo leavewith
            End If

            If Not .TileIsBlocking(Tile, Battlelist.X(i) - 3, Battlelist.Y(i) - 1, Battlelist.Z(i)) Then
                GotoLoc.x = -3
                GotoLoc.y = -1
            End If
        End With
LeaveWith:
        If Not GotoLoc.x = 0 And Not GotoLoc.y = 0 Then
            Self.WalkTo(Battlelist.X(i) + GotoLoc.x, Battlelist.Y(i) + GotoLoc.y, Battlelist.Z(i))
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "Keep Distance South"
    Private Function KeepDistanceSouth(ByVal i As Short) As Boolean
        Dim GotoLoc As New Location : GotoLoc.x = 0 : GotoLoc.y = 0
        With Me.Map
            Dim Tile As Short = .GetSelfTile
            If Not .TileIsBlocking(Tile, Battlelist.X(i) - 1, Battlelist.Y(i) + 2, Battlelist.Z(i)) Then
                GotoLoc.x = -1
                GotoLoc.y = 2
            Else
                GoTo leavewith
            End If

            If Not .TileIsBlocking(Tile, Battlelist.X(i) - 1, Battlelist.Y(i) + 3, Battlelist.Z(i)) Then
                GotoLoc.x = -1
                GotoLoc.y = 3
            End If
        End With
LeaveWith:
        If Not GotoLoc.x = 0 And Not GotoLoc.y = 0 Then
            Self.WalkTo(Battlelist.X(i) + GotoLoc.x, Battlelist.Y(i) + GotoLoc.y, Battlelist.Z(i))
            Return True
        Else
            Return False
        End If
    End Function

    Private Function KeepDistanceSouthEast(ByVal i As Short) As Boolean
        Dim GotoLoc As New Location : GotoLoc.x = 0 : GotoLoc.y = 0
        With Me.Map
            Dim Tile As Short = .GetSelfTile
            If Not .TileIsBlocking(Tile, Battlelist.X(i) + 2, Battlelist.Y(i) + 2, Battlelist.Z(i)) Then
                GotoLoc.x = 2
                GotoLoc.y = 2
            Else
                GoTo leavewith
            End If

            If Not .TileIsBlocking(Tile, Battlelist.X(i) + 2, Battlelist.Y(i) + 3, Battlelist.Z(i)) Then
                GotoLoc.x = 2
                GotoLoc.y = 3
            ElseIf Not .TileIsBlocking(Tile, Battlelist.X(i) + 3, Battlelist.Y(i) + 2, Battlelist.Z(i)) Then
                GotoLoc.x = 3
                GotoLoc.y = 2
            Else
                GoTo leavewith
            End If

            If Not .TileIsBlocking(Tile, Battlelist.X(i) + 3, Battlelist.Y(i) + 3, Battlelist.Z(i)) Then
                GotoLoc.x = 3
                GotoLoc.y = 3
            End If
        End With
LeaveWith:
        If Not GotoLoc.x = 0 And Not GotoLoc.y = 0 Then
            Self.WalkTo(Battlelist.X(i) + GotoLoc.x, Battlelist.Y(i) + GotoLoc.y, Battlelist.Z(i))
            Return True
        Else
            Return False
        End If
    End Function

    Private Function KeepDistanceSouthWest(ByVal i As Short) As Boolean
        Dim GotoLoc As New Location : GotoLoc.x = 0 : GotoLoc.y = 0
        With Me.Map
            Dim Tile As Short = .GetSelfTile
            If Not .TileIsBlocking(Tile, Battlelist.X(i) - 2, Battlelist.Y(i) + 2, Battlelist.Z(i)) Then
                GotoLoc.x = -2
                GotoLoc.y = 2
            Else
                GoTo leavewith
            End If

            If Not .TileIsBlocking(Tile, Battlelist.X(i) - 2, Battlelist.Y(i) + 3, Battlelist.Z(i)) Then
                GotoLoc.x = -2
                GotoLoc.y = 3
            ElseIf Not .TileIsBlocking(Tile, Battlelist.X(i) - 3, Battlelist.Y(i) + 2, Battlelist.Z(i)) Then
                GotoLoc.x = -3
                GotoLoc.y = 2
            Else
                GoTo leavewith
            End If

            If Not .TileIsBlocking(Tile, Battlelist.X(i) - 3, Battlelist.Y(i) + 3, Battlelist.Z(i)) Then
                GotoLoc.x = -3
                GotoLoc.y = 3
            End If
        End With


LeaveWith:
        If Not GotoLoc.x = 0 And Not GotoLoc.y = 0 Then
            Self.WalkTo(Battlelist.X(i) + GotoLoc.x, Battlelist.Y(i) + GotoLoc.y, Battlelist.Z(i))
            Return True
        Else
            Return False
        End If
    End Function
#End Region
#End Region
End Class
