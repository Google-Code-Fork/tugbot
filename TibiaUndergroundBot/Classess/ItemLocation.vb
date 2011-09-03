Public Class ItemLocation
    Public type As ItemLocationType
    Public container As Byte
    Public position As Byte
    Public groundLocation As Location
    Public stackOrder As Byte
    Public slot As Slots

    Public Shared Function FromSlot(ByVal s As Slots) As ItemLocation
        Dim loc As New ItemLocation()
        loc.type = ItemLocationType.Slot
        loc.slot = s
        Return loc
    End Function

    Public Shared Function FromContainer(ByVal container As Byte, ByVal position As Byte) As ItemLocation
        Dim loc As New ItemLocation()
        loc.type = ItemLocationType.Container
        loc.container = container
        loc.position = position
        loc.stackOrder = position
        Return loc
    End Function

    Public Shared Function FromLocation(ByVal location As Location, ByVal stack As Byte) As ItemLocation
        Dim loc As New ItemLocation()
        loc.type = ItemLocationType.Ground
        loc.groundLocation = location
        loc.stackOrder = stack
        Return loc
    End Function

    Public Shared Function FromLocation(ByVal location As Location) As ItemLocation
        Return FromLocation(location, 1)
    End Function

    ''' <summary>
    ''' Return a blank item location for packets (FF FF 00 00 00)
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function FromHotkey() As ItemLocation
        Return FromSlot(Slots.None)
    End Function

    Public Function ToBytes() As Byte()
        Dim bytes As Byte() = New Byte(4) {}

        Select Case type
            Case ItemLocationType.Container
                bytes(0) = &HFF
                bytes(1) = &HFF
                bytes(2) = CByte((&H40 + container))
                bytes(3) = &H0
                bytes(4) = position
                Exit Select
            Case ItemLocationType.Slot
                bytes(0) = &HFF
                bytes(1) = &HFF
                bytes(2) = CByte(slot)
                bytes(3) = &H0
                bytes(4) = &H0
                Exit Select
            Case ItemLocationType.Ground
                bytes(0) = BitConverter.GetBytes(groundLocation.x)(0) 'LongToByte(groundLocation.x, 1) 
                bytes(1) = BitConverter.GetBytes(groundLocation.x)(1)
                bytes(2) = BitConverter.GetBytes(groundLocation.y)(0)
                bytes(3) = BitConverter.GetBytes(groundLocation.y)(1)
                bytes(4) = CByte(groundLocation.z)
                Exit Select
        End Select


        Return bytes
    End Function

    Public Function ToLocation() As Location
        Dim newPos As New Location()

        Select Case type
            Case ItemLocationType.Container
                newPos.x = &HFFFF
                newPos.y = CInt(BitConverter.ToUInt16(New Byte() {CByte((&H40 + container)), &H0}, 0))
                newPos.z = CInt(position)
                Exit Select
            Case ItemLocationType.Slot
                newPos.x = &HFFFF
                newPos.y = CInt(BitConverter.ToUInt16(New Byte() {CByte(slot), &H0}, 0))
                newPos.z = 0
                Exit Select
            Case ItemLocationType.Ground
                newPos = groundLocation
                Exit Select
        End Select

        Return newPos
    End Function
End Class
