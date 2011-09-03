Public Class CMap
    Public MapDistance As New MapDistances
    Dim Data() As Byte
    Dim DatReader As DatItem

    Public Sub New()
        If TClient.Version = "8.40" Then
            MapDistance.Tile = 172
        Else
            MapDistance.Tile = 168
        End If

        ReDim Data(0 To 2015 * MapDistance.Tile)
        MapDistance.Objects = 12
    End Sub

    Public Sub Cache()
        SyncLock Data
            Data = TClient.ReadBytes(TClient.Addresses.Battlelist.Start, Data.Length)
        End SyncLock
    End Sub

    Private Function GetBytes(ByVal start As Integer, ByVal length As Integer) As Byte()
        Dim BArray(length) As Byte
        SyncLock Data
            Array.Copy(Data, start, BArray, 0, length)
        End SyncLock
        Return BArray
    End Function



#Region "Internal Methods"
    Public Function GetTileObjectId(ByVal tile As Short, ByVal stack As Byte) As Integer
        Try
            Return BitConverter.ToInt16(GetBytes((CUInt(tile) * CUInt(MapDistance.Tile)) + (CUInt(stack) * CUInt(MapDistance.Objects)) + MapOffset.ObjectsId, 2), 0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return 0
        End Try
    End Function

    Public Function GetTileObjectData(ByVal tile As Short, ByVal stack As Byte) As Integer
        Try
            Return BitConverter.ToInt16(GetBytes((CUInt(tile) * CUInt(MapDistance.Tile)) + (CUInt(stack) * CUInt(MapDistance.Objects)) + MapOffset.ObjectsData, 2), 0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return 0
        End Try
    End Function

    Private Function GetTileObjectCount(ByVal TileNum As Short) As Byte
        Try
            Return BitConverter.ToInt16(GetBytes((CUInt(TileNum) * CUInt(MapDistance.Tile)), 2), 0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return 0
        End Try
    End Function

    Private Function LocalPosToTile(ByVal x As Integer, ByVal y As Integer, ByVal z As Integer) As Short
        Return CInt(x + y * 18 + z * 14 * 18)
    End Function
#End Region

    Public Function GetTileID(ByVal TileNum As Short) As Short
        If TileNum < 0 Then Return 0

        Return CShort(GetTileObjectId(TileNum, 0))
    End Function

    Public Function GetTileObjects(ByVal TileNum As Integer) As List(Of TileObject)
        Dim Stack As Byte = Data(CUInt(MapDistance.Tile) * CUInt(TileNum))

        If Stack <= 1 Then Return New List(Of TileObject)

        Dim TempObj As TileObject
        Dim RetList As New List(Of TileObject)
        For I As Integer = 1 To Stack - 1
            TempObj = New TileObject
            TempObj.Id = GetTileObjectId(TileNum, I)
            TempObj.Data = GetTileObjectData(TileNum, I)
            RetList.Add(TempObj)
        Next

        Return RetList
    End Function

#Region "Get Tile Position"
    Public Function GetLocalPosition(ByVal TileNum As Short) As Location
        Dim Ret As New Location
        Ret.z = CInt(TileNum / (14 * 18))
        Ret.y = CInt((TileNum - Ret.z * 14 * 18) / 18)
        Ret.x = CInt((TileNum - Ret.z * 14 * 18) - Ret.y * 18)
        Return Ret
    End Function

    Public Function GetGlobalPosition(ByVal TileNum As Short) As Location
        Dim SelfLocal As Location = GetLocalPosition(GetSelfTile)
        Dim TargLocal As Location = GetLocalPosition(TileNum)
        Dim Ret As New Location

        Ret.x = TClient.Self.X - (SelfLocal.x - TargLocal.x)
        Ret.y = TClient.Self.Y - (SelfLocal.y - TargLocal.y)
        Ret.z = TClient.Self.Z - CInt(SelfLocal.z) - CInt(TargLocal.z)

        Return Ret
    End Function
#End Region

#Region "Get Tile"
    Public Function GetTile(ByVal x As Integer, ByVal y As Integer, ByVal z As Integer) As Integer
        Dim SelfTileLoc As Location = GetLocalPosition(GetSelfTile)
        Return LocalPosToTile(SelfTileLoc.x - (TClient.Self.X - x), _
                              SelfTileLoc.y - (TClient.Self.Y - y), _
                              SelfTileLoc.z - (TClient.Self.Z - z))
    End Function

    Public Function GetTile(ByVal SelfTile As Short, ByVal x As Integer, ByVal y As Integer, ByVal z As Integer) As Integer
        Dim SelfTileLoc As Location = GetLocalPosition(SelfTile)

        Return LocalPosToTile(SelfTileLoc.x - (TClient.Self.X - x), _
                              SelfTileLoc.y - (TClient.Self.Y - y), _
                              SelfTileLoc.z - (TClient.Self.Z - z))
    End Function

    Public Function LocalPosToTileNum(ByVal x As Integer, ByVal y As Integer, ByVal z As Integer) As Short
        Return Fix((x + (z * 14 * 18) + (y * 18)))
    End Function

    Public Function GetSelfTile() As Short 'Get the tile the player is standing on
        Dim StackSize As Byte
        Dim SelfID As Integer = TClient.Self.Id

        For i As Short = 0 To 2015
            StackSize = Data(CUInt(MapDistance.Tile) * CUInt(i))
            If StackSize > 1 Then
                For E As Byte = 0 To StackSize - 1
                    If GetTileObjectId(i, E) = 99 Then
                        If GetTileObjectData(i, E) = SelfID Then
                            Return i
                        End If
                    End If
                Next
            End If
        Next

        Return 0
    End Function

    Public Function GetTilesOnSameFloor() As List(Of Short)
        Dim PlayerTile As Short = GetSelfTile()
        Dim TileList As New List(Of Short)
        Dim z As Integer = GetLocalPosition(PlayerTile).z
        Dim startNumber As Short = LocalPosToTileNum(0, 0, z)
        Dim endNumber As Short = LocalPosToTileNum(0, 0, z + 1)

        For i As UInteger = startNumber To endNumber - 1
            TileList.Add(i)
        Next

        Return TileList
    End Function

    Public Function GetFishyTiles() As List(Of Short)
        Dim StackSize As Byte
        Dim TempList As New List(Of Short)

        For i As Short = 0 To 2015
            StackSize = Data(CUInt(MapDistance.Tile) * CUInt(i))
            If StackSize > 1 Then
                For E As Byte = 0 To StackSize - 1
                    If 4597 <= GetTileObjectId(i, E) <= 4602 Then
                        TempList.Add(i)
                    End If
                Next
            End If
        Next

        Return TempList
    End Function
#End Region


    Public Function TileIsBlocking(ByVal tilenum As Integer) As Boolean
        DatReader = New DatItem(GetTileID(tilenum))

        If DatReader.GetFlag(DatItem.Flag.WalkSpeed) = 0 Or DatReader.GetFlag(DatItem.Flag.Floorchange) = True Then
            Return True
        End If

        For Each I As TileObject In GetTileObjects(tilenum)
            If I.Id < 100 Then
                Return True
            End If

            DatReader = New DatItem(I.Id)
            If DatReader.GetFlag(DatItem.Flag.Blocking) = True Or DatReader.GetFlag(DatItem.Flag.Floorchange) = True Then
                Return True
            End If
        Next

        Return False
    End Function
End Class
