Public Structure MapDistances
    Dim Tile As Short '= 168
    Dim Objects As Short '= 12
End Structure

Public Enum MapOffset
    ObjectsId = 4
    ObjectsData = 8
End Enum

Public Class Map
    Public MapDistance As New MapDistances

    Public Sub New()
        If TClient.Version = "8.40" Then
            MapDistance.Tile = 172
        Else
            MapDistance.Tile = 168
        End If

        MapDistance.Objects = 12
    End Sub

#Region "Internal Methods"
    Private Function GetTileObjectId(ByVal Pointer As UInteger, ByVal tile As Short, ByVal stack As Byte) As Integer
        Try
            Return TClient.ReadUInt(Pointer + (CUInt(tile) * CUInt(MapDistance.Tile)) + (CUInt(stack) * CUInt(MapDistance.Objects)) + MapOffset.ObjectsId)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return 0
        End Try
    End Function

    Private Function GetTileObjectData(ByVal Pointer As UInteger, ByVal tile As Short, ByVal stack As Byte) As Integer
        Try
            Return TClient.ReadUInt(Pointer + (CUInt(tile) * CUInt(MapDistance.Tile)) + (CUInt(stack) * CUInt(MapDistance.Objects)) + MapOffset.ObjectsData)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return 0
        End Try
    End Function

    Private Function GetTileObjectCount(ByVal Pointer As UInteger, ByVal TileNum As Short) As Byte
        Try
            Return TClient.ReadByte(Pointer + (CUInt(TileNum) * CUInt(MapDistance.Tile)))
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return 0
        End Try
    End Function

    Private Function LocalPosToTile(ByVal x As Integer, ByVal y As Integer, ByVal z As Integer) As Short
        Return CInt(x + y * 18 + z * 14 * 18)
    End Function

    Private Function getMapPointer() As UInteger
        Return TClient.ReadUInt(TClient.Addresses.Client.Map)
    End Function
#End Region

#Region "Methods"

#Region "Get Tile Position"
    Public Function GetLocalPosition(ByVal TileNum As Short) As Location
        Dim Ret As New Location
        Ret.z = CByte(TileNum \ (14 * 18))
        Ret.y = CInt((TileNum - Ret.z * 14 * 18) \ 18)
        Ret.x = CInt((TileNum - Ret.z * 14 * 18) - Ret.y * 18)
        Return Ret
    End Function

    Public Function GetGlobalPosition(ByVal TileNum As Short) As Location
        Dim SelfLocal As Location = GetLocalPosition(GetSelfTile)
        Dim TargLocal As Location = GetLocalPosition(TileNum)
        Dim Ret As New Location

        Ret.x = TClient.Self.X - (SelfLocal.x - TargLocal.x)
        Ret.y = TClient.Self.Y - (SelfLocal.y - TargLocal.y)
        Ret.z = TClient.Self.Z - (SelfLocal.z - TargLocal.z)

        Return Ret
    End Function

#End Region

#Region "Get Tile Info"
    Public Function GetTileID(ByVal TileNum As Short) As Short
        If TileNum < 0 Then Return 0
        Return GetTileObjectId(TileNum, 0)
    End Function

    Public Function GetTileObjectID(ByVal TileNum As Short, ByVal Stack As Short) As Integer
        Dim ret As Integer = GetTileObjectID(getMapPointer, TileNum, Stack)
        Return GetTileObjectID(getMapPointer, TileNum, Stack)
    End Function

    Public Function GetTileObjectData(ByVal TileNum As Short, ByVal Stack As Short) As Integer
        GetTileObjectData(getMapPointer, TileNum, Stack)
    End Function

    Public Function GetTileObjectCount(ByVal TileNum As Short) As Short
        GetTileObjectCount(getMapPointer(), TileNum)
    End Function

    Public Function GetTileObjects(ByVal TileNum As Integer) As List(Of TileObject)
        Dim Stack As Byte = GetTileObjectCount(TileNum)
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

    Public Function TileIsBlocking(ByVal tilenum As Integer) As Boolean
        Dim Dats As New DatItem(GetTileID(tilenum))

        If Dats.GetFlag(DatItem.Flag.WalkSpeed) = 0 Or Dats.GetFlag(DatItem.Flag.Floorchange) = True Then
            Return True
        End If

        For Each I As TileObject In GetTileObjects(tilenum)
            If I.Id = 99 Then
                Return True
            End If

            Dats = New DatItem(I.Id)
            If Dats.GetFlag(DatItem.Flag.Blocking) = True Or Dats.GetFlag(DatItem.Flag.Floorchange) = True Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Function TilesAreBlocking(ByVal tiles As List(Of Short)) As Boolean
        Dim Dats As DatItem

        For Each TileNum As Short In tiles
            Dats = New DatItem(GetTileID(TileNum))
            If Dats.GetFlag(DatItem.Flag.WalkSpeed) = 0 Or Dats.GetFlag(DatItem.Flag.Floorchange) = True Then
                Return True
            End If

            For Each I As TileObject In GetTileObjects(TileNum)
                If I.Id < 100 Then
                    Return True
                End If

                Dats = New DatItem(I.Id)
                If Dats.GetFlag(DatItem.Flag.Blocking) = True Or Dats.GetFlag(DatItem.Flag.Floorchange) = True Then
                    Return True
                End If
            Next
        Next

        Return False
    End Function

    Public Function TileIsBlocking(ByVal x As Integer, ByVal y As Integer, ByVal z As Integer) As Boolean
        Dim TileNum As Short = GetTile(z, y, z)
        Dim Dats As New DatItem(GetTileID(TileNum))

        If Dats.GetFlag(DatItem.Flag.WalkSpeed) = 0 Or Dats.GetFlag(DatItem.Flag.Floorchange) _
        Or Dats.GetFlag(DatItem.Flag.Blocking) Then
            Return True
        End If

        For Each I As TileObject In GetTileObjects(TileNum)
            If I.Id < 100 Then
                Return True
            End If

            Dats = New DatItem(I.Id)
            If Dats.GetFlag(DatItem.Flag.Blocking) Or Dats.GetFlag(DatItem.Flag.Floorchange) _
            Or Dats.GetFlag(DatItem.Flag.BlocksPath) Or Dats.GetFlag(DatItem.Flag.WalkSpeed) = 0 Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Function TileIsBlocking(ByVal SelfTile As Short, ByVal x As Integer, ByVal y As Integer, ByVal z As Integer) As Boolean
        Dim TileNum As Short = GetTile(SelfTile, z, y, z)
        Dim Dats As New DatItem(GetTileID(TileNum))

        If Dats.GetFlag(DatItem.Flag.WalkSpeed) = 0 OrElse Dats.GetFlag(DatItem.Flag.Floorchange) _
        OrElse Dats.GetFlag(DatItem.Flag.Blocking) Then
            Return True
        End If

        For Each I As TileObject In GetTileObjects(TileNum)
            If I.Id < 100 And I.Data <> TClient.Self.Id Then
                Return True
            End If

            Dats = New DatItem(I.Id)
            If Dats.GetFlag(DatItem.Flag.Blocking) OrElse Dats.GetFlag(DatItem.Flag.Floorchange) _
            OrElse Dats.GetFlag(DatItem.Flag.BlocksPath) Then
                Return True
            End If
        Next

        Return False
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

    Public Function GetCreatureTile(ByVal CreatureId As Integer) As Short 'Get the tile any creature is stading on
        Dim StackSize As Byte
        Dim MapBegins As UInteger = getMapPointer()

        For i As Short = 0 To 2015
            StackSize = GetTileObjectCount(MapBegins, i)
            If StackSize > 1 Then
                For E As Byte = 0 To StackSize - 1
                    If GetTileObjectId(MapBegins, i, E) = 99 Then
                        If GetTileObjectData(MapBegins, i, E) = CreatureId Then
                            Return i
                            Exit Function
                        End If
                    End If
                Next
            End If
        Next
    End Function

    Public Function GetSelfTile() As Short 'Get the tile the player is standing on
        Dim StackSize As Byte
        Dim MapBegins As UInteger = getMapPointer()
        Dim SelfID As Integer = TClient.Self.Id

        For i As Short = 0 To 2015
            StackSize = GetTileObjectCount(MapBegins, i)
            If StackSize > 1 Then
                For E As Byte = 0 To StackSize - 1
                    If GetTileObjectId(MapBegins, i, E) = 99 Then
                        If GetTileObjectData(MapBegins, i, E) = SelfID Then
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
        Dim MapBegins As UInteger = getMapPointer()
        Dim TempList As New List(Of Short)

        For i As Short = 0 To 2015
            StackSize = Me.GetTileObjectCount(MapBegins, i)
            If StackSize > 1 Then
                For E As Byte = 0 To StackSize - 1
                    If 4597 <= GetTileObjectId(MapBegins, i, E) AndAlso GetTileObjectId(MapBegins, i, E) <= 4602 Then
                        TempList.Add(i)
                    End If
                Next
            End If
        Next

        Return TempList
    End Function
#End Region

#End Region
End Class

#Region "Generate map packets"
'Protected Sub GetMapDescription(ByVal x As Integer, ByVal y As Integer, ByVal z As Integer, ByVal width As Integer, ByVal height As Integer, ByVal msg As PacketBuilder)
'    Dim skip As Integer = -1
'    Dim startz As Integer, endz As Integer, zstep As Integer = 0

'    If z > 7 Then
'        startz = z - 2
'        endz = Math.Min(16 - 1, z + 2)
'        zstep = 1
'    Else
'        startz = 7
'        endz = 0

'        zstep = -1
'    End If

'    Dim nz As Integer = startz
'    While nz <> endz + zstep
'        skip = GetFloorDescription(x, y, nz, width, height, z - nz, _
'         skip, msg)
'        nz += zstep
'    End While

'    If skip >= 0 Then
'        msg.AddByte(CByte(skip))
'        msg.AddByte(&HFF)
'    End If
'End Sub

'Protected Function GetFloorDescription(ByVal x As Integer, ByVal y As Integer, ByVal z As Integer, ByVal width As Integer, ByVal height As Integer, ByVal offset As Integer, _
' ByVal skip As Integer, ByVal msg As PacketBuilder) As Integer
'    Dim tile As Tile

'    For nx As Integer = 0 To width - 1
'        For ny As Integer = 0 To height - 1
'            tile = GetTile(New Location(x + nx + offset, y + ny + offset, z))
'            If tile IsNot Nothing Then
'                If skip >= 0 Then
'                    msg.AddByte(CByte(skip))
'                    msg.AddByte(&HFF)
'                End If
'                skip = 0


'                GetTileDescription(tile, msg)
'            Else
'                skip += 1
'                If skip = &HFF Then
'                    msg.AddByte(&HFF)
'                    msg.AddByte(&HFF)
'                    skip = -1
'                End If
'            End If
'        Next
'    Next
'    Return skip
'End Function

'Protected Sub GetTileDescription(ByVal tile As Tile, ByVal msg As PacketBuilder)
'    If tile IsNot Nothing Then
'        Dim objects As List(Of TileObject) = tile.Objects
'        objects.Insert(0, New TileObject(CInt(tile.Ground.Id), tile.Ground.Count, 0))

'        For Each o As TileObject In objects
'            If o.Id <= 0 Then
'                Exit Sub
'            ElseIf o.Id = &H61 OrElse o.Id = &H62 OrElse o.Id = &H63 Then
'                ' Add a creature
'                Dim c As Creature = Client.BattleList.GetCreatures().FirstOrDefault(Function(cr) cr.Id = o.Data)

'                If c Is Nothing Then
'                    Throw New Exception("Creature does not exist.")
'                End If

'                ' Add as unknown
'                msg.AddShort(CUShort(o.Id))

'                ' No need to remove a creature
'                msg.AddLong(0)

'                ' Add the creature id
'                msg.AddLong(CUInt(c.Id))

'                msg.AddString(c.Name)

'                msg.AddByte(CByte(c.HPBar))

'                msg.AddByte(CByte(c.Direction))

'                msg.AddOutfit(c.Outfit)

'                msg.AddByte(CByte(c.Light))

'                msg.AddByte(CByte(c.LightColor))

'                msg.AddShort(CUShort(c.WalkSpeed))

'                msg.AddByte(CByte(c.Skull))

'                msg.AddByte(CByte(c.Party))
'            ElseIf o.Id <= 9999 Then
'                ' Add an item
'                Dim item As New Item(Client, CUInt(o.Id), CByte(o.Data), "", ItemLocation.FromLocation(tile.Location, CByte(o.StackOrder)))

'                msg.AddUInt16(CUShort(o.Id))

'                Try
'                    If item.HasExtraByte Then
'                        msg.AddByte(item.Count)
'                    End If
'                Catch
'                End Try
'            End If
'        Next
'    End If
'End Sub
#End Region

