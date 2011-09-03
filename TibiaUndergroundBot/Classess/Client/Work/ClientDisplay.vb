Partial Public Class Client
    Public LastID As UInt32

    Public Enum TextMessageColor
        Red
        Orange
        Blue
        White
        Green
    End Enum
    Public Sub DisplayTextMessage(ByVal Color As TextMessageColor, ByVal Message As String)
        Dim Packet As New PacketBuilder(IncomingPacketType.StatusMessage)

        If CDbl(TClient.Version) >= CDbl("8.61") Then
            Packet.AddByte(&H13)
        Else
            Select Case Color
                Case TextMessageColor.Orange
                    Packet.AddByte(StatusMessage.ConsoleOrange)
                Case TextMessageColor.Blue
                    Packet.AddByte(StatusMessage.ConsoleBlue)
                Case TextMessageColor.Red
                    Packet.AddByte(StatusMessage.ConsoleRed)
                Case TextMessageColor.White
                    Packet.AddByte(StatusMessage.EventAdvance)
                Case TextMessageColor.Green
                    Packet.AddByte(StatusMessage.DescriptionGreen)
            End Select
        End If

        Packet.AddString(Message)
        Me.Hook.SendPacketToClient(Packet.GetPacket)
    End Sub



    Public Enum TextColor As Byte
        Blue = 5
        Green = 30
        LightBlue = 35
        Crystal = 65
        Purple = 83
        Platinum = 89
        LightGrey = 129
        DarkRed = 144
        Red = 180
        Orange = 198
        Gold = 210
        White = 215
        None = 255
    End Enum

    Public Sub DisplayAnimatedText(ByVal color As TextColor, ByVal text As String, ByVal pos As Location)
        Dim Packet As New PacketBuilder(IncomingPacketType.AnimatedText)
        Packet.AddInt(pos.x)
        Packet.AddInt(pos.y)
        Packet.AddByte(pos.z)
        Packet.AddByte(CByte(color))
        Packet.AddString(text)
        Me.Hook.SendPacketToClient(Packet.GetPacket)
    End Sub

End Class
