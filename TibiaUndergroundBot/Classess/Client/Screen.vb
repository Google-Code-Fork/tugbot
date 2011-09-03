Public Class Screen
    Private Client As Client
    Dim Ox As Integer
    Dim Oy As Integer
    Dim Oh As Integer
    Dim Ow As Integer
    Dim Ob As Integer
    Dim OldFrame As Double
    Private CurrentLevel As Integer = 0
    Private LevelSpyPointer As Integer = 0

    Public XRayEnabled As Boolean = False
    Public LightEnabled = False

    Private Nops() As Byte = {&H90, &H90, &H90, &H90, &H90, &H90}
    Private DefaultSpy1 As Byte()
    Private DefaultSpy2 As Byte()
    Private DefaultSpy3 As Byte()
    Private oldXray1 As Short = 0
    Private oldXray2 As Short = 0

    Public Sub New(ByVal C As Client)
        Me.Client = C
    End Sub

#Region "Align"
    Public Function AlignTop(ByVal x As Double, ByVal y As Double, ByRef align As DisplayText.TextAlign) As Location
        Dim Adr As UInteger
        Dim ScreenW, ScreenH As UShort
        Dim RetLoc As New Location
        Dim Size As Byte

        x += 7 : x -= Client.Self.X
        y += 5 : y -= Client.Self.Y

        Adr = TClient.ReadUInt(TClient.Addresses.Client.ScreenRect)
        Adr = TClient.ReadUInt(Adr + TClient.Addresses.Client.ScreenY + &H4)
        ScreenW = TClient.ReadInt(Adr + TClient.Addresses.Client.ScreenWidth)
        ScreenH = TClient.ReadInt(Adr + TClient.Addresses.Client.ScreenHeight)

        Size = ScreenW \ 13

        Dim sX As Integer = TClient.ReadInt(Adr + TClient.Addresses.Client.ScreenX)
        RetLoc.x = x * Size + sX
        align = DisplayText.TextAlign.Center

        If RetLoc.x > sX + ScreenW Then
            RetLoc.x = sX + ScreenW
            align = DisplayText.TextAlign.Right
        ElseIf RetLoc.x < sX Then
            RetLoc.x = sX
            align = DisplayText.TextAlign.Left
        End If

        RetLoc.y = TClient.ReadInt(Adr + TClient.Addresses.Client.ScreenY)

        Return RetLoc
    End Function

    Public Function AlignBottom(ByVal x As Double, ByVal y As Double, ByRef align As DisplayText.TextAlign) As Location
        Dim Adr As UInteger
        Dim ScreenW, ScreenH As UShort
        Dim RetLoc As New Location
        Dim Size As Byte

        x += 7 : x -= Client.Self.X
        y += 5 : y -= Client.Self.Y

        Adr = TClient.ReadUInt(TClient.Addresses.Client.ScreenRect)
        Adr = TClient.ReadUInt(Adr + TClient.Addresses.Client.ScreenY + &H4)
        ScreenW = TClient.ReadInt(Adr + TClient.Addresses.Client.ScreenWidth)
        ScreenH = TClient.ReadInt(Adr + TClient.Addresses.Client.ScreenHeight)

        Size = ScreenW \ 13

        Dim sX As Integer = TClient.ReadInt(Adr + TClient.Addresses.Client.ScreenX)
        RetLoc.x = x * Size + sX
        align = DisplayText.TextAlign.Center

        If RetLoc.x > sX + ScreenW Then
            RetLoc.x = sX + ScreenW
            align = DisplayText.TextAlign.Right
        ElseIf RetLoc.x < sX Then
            RetLoc.x = sX
            align = DisplayText.TextAlign.Left
        End If

        RetLoc.y = TClient.ReadInt(Adr + TClient.Addresses.Client.ScreenY) + ScreenH - 12

        Return RetLoc
    End Function

    Public Function AlignLeft(ByVal x As Double, ByVal y As Double, ByRef align As DisplayText.TextAlign) As Location
        Dim Adr As UInteger
        Dim ScreenW, ScreenH As UShort
        Dim RetLoc As New Location
        Dim Size As Byte

        x += 7 : x -= Client.Self.X
        y += 5 : y -= Client.Self.Y

        Adr = TClient.ReadUInt(TClient.Addresses.Client.ScreenRect)
        Adr = TClient.ReadUInt(Adr + TClient.Addresses.Client.ScreenY + &H4)
        ScreenW = TClient.ReadInt(Adr + TClient.Addresses.Client.ScreenWidth)
        ScreenH = TClient.ReadInt(Adr + TClient.Addresses.Client.ScreenHeight)

        Size = ScreenW \ 13

        RetLoc.x = TClient.ReadInt(Adr + TClient.Addresses.Client.ScreenX)

        Dim Sy As Integer = TClient.ReadInt(Adr + TClient.Addresses.Client.ScreenY)
        RetLoc.y = y * Size + Sy
        align = DisplayText.TextAlign.Left

        If RetLoc.y > Sy + ScreenH - 12 Then
            RetLoc.y = Sy + ScreenH - 12
        ElseIf RetLoc.y < Sy Then
            RetLoc.y = Sy
        End If

        Return RetLoc
    End Function

    Public Function AlignRight(ByVal x As Double, ByVal y As Double, ByRef align As DisplayText.TextAlign) As Location
        Dim Adr As UInteger
        Dim ScreenW, ScreenH As UShort
        Dim RetLoc As New Location
        Dim Size As Byte

        x += 7 : x -= Client.Self.X
        y += 5 : y -= Client.Self.Y

        Adr = TClient.ReadUInt(TClient.Addresses.Client.ScreenRect)
        Adr = TClient.ReadUInt(Adr + TClient.Addresses.Client.ScreenY + &H4)
        ScreenW = TClient.ReadInt(Adr + TClient.Addresses.Client.ScreenWidth)
        ScreenH = TClient.ReadInt(Adr + TClient.Addresses.Client.ScreenHeight)

        Size = ScreenW \ 13

        RetLoc.x = ScreenW + TClient.ReadInt(Adr + TClient.Addresses.Client.ScreenX)

        Dim Sy As Integer = TClient.ReadInt(Adr + TClient.Addresses.Client.ScreenY)
        RetLoc.y = y * Size + Sy
        align = DisplayText.TextAlign.Right

        If RetLoc.y > Sy + ScreenH - 12 Then
            RetLoc.y = Sy + ScreenH - 12
        ElseIf RetLoc.y < Sy Then
            RetLoc.y = Sy
        End If

        Return RetLoc
    End Function
#End Region

#Region "Size"
    Public Function GetSpriteSize() As Byte
        Dim Adr As UInteger
        Dim ScreenW As UShort

        Adr = Me.Client.ReadUInt(Client.Addresses.Client.ScreenRect)
        Adr = Me.Client.ReadUInt(Adr + Client.Addresses.Client.ScreenY + &H4)
        ScreenW = Me.Client.ReadInt(Adr + Client.Addresses.Client.ScreenWidth)

        Return ScreenW \ 15
    End Function

    Public Function GetCenterScreen() As Drawing.Point
        Dim Adr As Integer
        Dim ScreenX, ScreenY, ScreenW As Integer

        ReadMemory(Client.Addresses.Client.ScreenRect, Adr, 4)
        ReadMemory(Adr + Client.Addresses.Client.ScreenY + &H4, Adr, 4)
        ReadMemory(Adr + Client.Addresses.Client.ScreenX, ScreenX, 4)
        ReadMemory(Adr + Client.Addresses.Client.ScreenY, ScreenY, 4)
        ReadMemory(Adr + Client.Addresses.Client.ScreenWidth, ScreenW, 4)

        GetCenterScreen.X = ScreenX + (ScreenW \ 2) - Fix(GetScreenWidth() \ 2)
        GetCenterScreen.Y = ScreenY + 4
    End Function


    Public Function GetScreenWidth() As Integer
        Dim Adr As Integer
        Dim ScreenW As Integer

        ReadMemory(Client.Addresses.Client.ScreenRect, Adr, 4)
        ReadMemory(Adr + Client.Addresses.Client.ScreenY + &H4, Adr, 4)
        ReadMemory(Adr + Client.Addresses.Client.ScreenWidth, ScreenW, 4)

        Return ScreenW \ 15
    End Function

    Public Function GetXOffset() As Integer
        Dim Rects As Rect = Client.Rect

        Return Rects.x2 - Rects.x1 - GetCenterScreen.X * 2
    End Function
#End Region

#Region "World/Wide views"
    Public Sub WideView(ByVal enable As Boolean)
        Dim Rect As Structures.Rect = Client.Rect
        Dim Screen_Rect As Integer
        Dim valuex As Integer = Rect.x2
        Dim valuey As Integer = Rect.y2 - Rect.y1
        Dim HCheck As Integer

        Screen_Rect = Client.ReadInt(Client.Addresses.Client.ScreenRect)
        Screen_Rect = Client.ReadInt(Screen_Rect + Client.Addresses.Client.ScreenY + &H4)

        If enable = True Then
            HCheck = Client.ReadInt(Screen_Rect + Client.Addresses.Client.ScreenHeight)
            If Oh + 7 <> HCheck Then
                Ox = Client.ReadInt(Screen_Rect + Client.Addresses.Client.ScreenX)
                Oy = Client.ReadInt(Screen_Rect + Client.Addresses.Client.ScreenY)
                Ow = Client.ReadInt(Screen_Rect + Client.Addresses.Client.ScreenHeight)
                Oy = Client.ReadInt(Screen_Rect + Client.Addresses.Client.ScreenWidth)

                Client.WriteInt(Screen_Rect + Client.Addresses.Client.ScreenX, 2)
                Client.WriteInt(Screen_Rect + Client.Addresses.Client.ScreenY, Oy - 3)
                Client.WriteInt(Screen_Rect + Client.Addresses.Client.ScreenWidth, (Rect.x2 - Rect.x1) - GetXOffset())
                Client.WriteInt(Screen_Rect + Client.Addresses.Client.ScreenHeight, Oh + 7)
            End If
        Else
            Client.WriteInt(Screen_Rect + Client.Addresses.Client.ScreenX, Ox)
            Client.WriteInt(Screen_Rect + Client.Addresses.Client.ScreenY, Oy)
            Client.WriteInt(Screen_Rect + Client.Addresses.Client.ScreenWidth, Ow)
            Client.WriteInt(Screen_Rect + Client.Addresses.Client.ScreenHeight, Oh)
            Ox = 0
            Oy = 0
            Ow = 0
            Oh = 0
        End If
    End Sub

    Public Sub WorldView(ByVal enable As Boolean)
        Dim Rect As Structures.Rect = Client.Rect
        Dim Screen_Rect As Integer
        Dim valuex As Integer = Rect.x2
        Dim valuey As Integer = Rect.y2 - Rect.y1
        Dim HCheck As Integer
        Dim Bar As Integer

        Screen_Rect = Client.ReadInt(Client.Addresses.Client.ScreenRect)
        Screen_Rect = Client.ReadInt(Screen_Rect + Client.Addresses.Client.ScreenY + &H4)

        Bar = Client.ReadInt(Client.Addresses.Client.ScreenBar)

        If enable = True Then
            HCheck = Client.ReadInt(Screen_Rect + Client.Addresses.Client.ScreenHeight)
            If HCheck <> (Rect.y2 - Rect.y1) - 38 Then
                Ox = Client.ReadInt(Screen_Rect + Client.Addresses.Client.ScreenX)
                Oy = Client.ReadInt(Screen_Rect + Client.Addresses.Client.ScreenY)
                Ow = Client.ReadInt(Screen_Rect + Client.Addresses.Client.ScreenHeight)
                Oy = Client.ReadInt(Screen_Rect + Client.Addresses.Client.ScreenWidth)
                Ob = Client.ReadInt(Bar + &H70)

                Client.WriteInt(Bar + &H70, 0)
                Client.WriteInt(Screen_Rect + Client.Addresses.Client.ScreenX, 0)
                Client.WriteInt(Screen_Rect + Client.Addresses.Client.ScreenY, 0)
                Client.WriteInt(Screen_Rect + Client.Addresses.Client.ScreenWidth, (Rect.x2 - Rect.x1))
                Client.WriteInt(Screen_Rect + Client.Addresses.Client.ScreenHeight, (Rect.y2 - Rect.y1) - 38)
            End If
        Else
            Client.WriteInt(Screen_Rect + Client.Addresses.Client.ScreenX, Ox)
            Client.WriteInt(Screen_Rect + Client.Addresses.Client.ScreenY, Oy)
            Client.WriteInt(Screen_Rect + Client.Addresses.Client.ScreenWidth, Ow)
            Client.WriteInt(Screen_Rect + Client.Addresses.Client.ScreenHeight, Oh)
            Client.WriteInt(Bar + &H70, Ob)
            Ox = 0
            Oy = 0
            Ow = 0
            Oh = 0
            Ob = 0
        End If
    End Sub
#End Region

#Region "X-Ray"
    Public Function XRay(ByVal Enabled As Boolean) As Boolean
        If Enabled = True Then
            XRayEnabled = True
            If oldXray1 = 0 Then
                oldXray1 = Client.ReadShort(Client.Addresses.Client.NameSpy1)
                oldXray2 = Client.ReadShort(Client.Addresses.Client.NameSpy2)
            End If
            Client.WriteNops(Client.Addresses.Client.NameSpy1, 2)
            Client.WriteNops(Client.Addresses.Client.NameSpy2, 2)
            Client.ShowStatusMessage("TUGBot -> X-Ray - > On", 50)
        Else
            XRayEnabled = False
            Client.WriteShort(Client.Addresses.Client.NameSpy1, oldXray1)
            Client.WriteShort(Client.Addresses.Client.NameSpy2, oldXray2)
            Client.ShowStatusMessage("TUGBot -> X-Ray - > Off", 50)
        End If
    End Function
#End Region

#Region "Light"
    Public Function LightHack(ByVal enabled As Boolean) As Boolean
        If enabled = True Then
            LightEnabled = True
            Client.WriteNops(Client.Addresses.Client.LightNop, 2)
            Client.WriteByte(Client.Addresses.Client.LightAmount, 255)
            Client.ShowStatusMessage("TUGBot -> Light - > On", 50)
        Else
            LightEnabled = False
            Client.WriteShort(Client.Addresses.Client.LightNop, 1406)
            Client.WriteByte(Client.Addresses.Client.LightAmount, 128)
            Client.ShowStatusMessage("TUGBot -> Light - > Off", 50)
        End If
    End Function
#End Region

#Region "Framerate"
    Public Sub Framerate(ByVal [on] As Boolean)
        Dim begin As Integer
        begin = TClient.ReadInt(TClient.Addresses.Client.FrameratePoint)
        If [on] Then
            OldFrame = TClient.ReadDouble(begin + TClient.Addresses.Client.FramerateLimit)
            TClient.WriteDouble(begin + TClient.Addresses.Client.FramerateLimit, Math.Round((1110 / 1) - 5, 1))
        Else
            TClient.WriteDouble(begin + TClient.Addresses.Client.FramerateLimit, Math.Round((1110 / OldFrame) - 5, 1))
        End If
    End Sub
#End Region

#Region "Level Spy"
    Private RoofsRemoved As Boolean
    Public Function LevelSpyUp()

        If RoofsRemoved Then
            RoofsRemoved = False
            DisableLevelSpy()
            Client.ShowStatusMessage("TUGBot -> Level Spy - > Replaced Roofs", 50)
            Return False
        End If

        ShowNames(True)
        EnableLevelSpy()
        If ShowFloor(CurrentLevel + 1) Then
            CurrentLevel += 1
        End If

        If CurrentLevel = 0 Then
            DisableLevelSpy()
            ShowNames(False)
        End If

        LevelSpyMessage()
        Return False
    End Function

    Public Function LevelSpyDown()
        EnableLevelSpy()
        'Normally if current level is 0, we disable level spy, but here we are at
        'Ground floor and enable it, then show floor 0 to hide roofs
        If CurrentLevel = 0 AndAlso Client.Self.Z = 7 Then
            ShowFloor(0)
            RoofsRemoved = True
            Client.ShowStatusMessage("TUGBot -> Level Spy - > Removed Roofs", 50)
        Else
            ShowNames(True)
            If ShowFloor(CurrentLevel - 1) Then
                CurrentLevel -= 1
            End If
            'We disable it sinec current floor is 0 and we ARENT on ground floor
            If CurrentLevel = 0 Then
                DisableLevelSpy()
                ShowNames(False)
            End If
            LevelSpyMessage()
        End If
        Return False
    End Function

    Public Function LevelSpyCenter()
        DisableLevelSpy()
        ShowNames(False)
        LevelSpyMessage()
        Return False
    End Function

    Public Sub LevelSpyMessage()
        If CurrentLevel > 0 Then
            Client.ShowStatusMessage("TUGBot -> Level Spy - > Default + " & CurrentLevel, 50)
        ElseIf CurrentLevel = 0 Then
            Client.ShowStatusMessage("TUGBot -> Level Spy - > Default", 50)
        Else
            Client.ShowStatusMessage("TUGBot -> Level Spy - > Default - " & CurrentLevel * -1, 50)
        End If
    End Sub

    Private Sub EnableLevelSpy()
        'Nop the shit
        Static first As Boolean = True
        If first Then
            DefaultSpy1 = TClient.ReadBytes(TClient.Addresses.Client.LevelSpy1, 6)
            DefaultSpy2 = TClient.ReadBytes(TClient.Addresses.Client.LevelSpy2, 6)
            DefaultSpy3 = TClient.ReadBytes(TClient.Addresses.Client.LevelSpy3, 6)
            first = False
        End If
        TClient.WriteBytes(TClient.Addresses.Client.LevelSpy1, Nops)
        TClient.WriteBytes(TClient.Addresses.Client.LevelSpy2, Nops)
        TClient.WriteBytes(TClient.Addresses.Client.LevelSpy3, Nops)
        'Get the pointer
        LevelSpyPointer = TClient.ReadUInt(TClient.Addresses.Client.LevelSpyPtr)
        LevelSpyPointer += 28
        LevelSpyPointer = TClient.ReadUInt(LevelSpyPointer)
        LevelSpyPointer += TClient.Addresses.Client.LevelSpyAdd
    End Sub

    Private Sub DisableLevelSpy()
        'Default the shit
        ShowFloor(0)
        CurrentLevel = 0
        TClient.WriteBytes(TClient.Addresses.Client.LevelSpy1, DefaultSpy1)
        TClient.WriteBytes(TClient.Addresses.Client.LevelSpy2, DefaultSpy2)
        TClient.WriteBytes(TClient.Addresses.Client.LevelSpy3, DefaultSpy3)
    End Sub

    Private Function ShowFloor(ByVal floor As Integer) As Boolean
        Dim playerZ As Integer = TClient.Self.Z
        If playerZ <= 7 Then
            'We are above ground, so floor HAS TO BE OVER 0, since we cant see under
            If playerZ - floor >= 0 AndAlso playerZ - floor <= 7 Then
                'When writing the level, we subtract our current level from 7.
                'When above ground, the "level map" will store floor 7 as 0,
                TClient.WriteInt(LevelSpyPointer, 7 - playerZ + floor)
                Return True
            End If
        Else
            'Underground, so show 2 floor up and 2 down, making sure not to show any past 16
            If floor >= -2 AndAlso floor <= 2 AndAlso playerZ - floor < 16 Then
                TClient.WriteInt(LevelSpyPointer, 2 + floor)
                Return True
            End If
        End If

        'We were either trying to spy too high or trying to spy too low. Return false
        Return False
    End Function

    Private Sub ShowNames(ByVal [on] As Boolean)
        Static oldXray1, oldXray2 As Short
        If [on] Then
            If XRayEnabled = False Then
                If oldXray1 = 0 Then
                    oldXray1 = Client.ReadShort(Client.Addresses.Client.NameSpy1)
                    oldXray2 = Client.ReadShort(Client.Addresses.Client.NameSpy2)
                End If
                Client.WriteNops(Client.Addresses.Client.NameSpy1, 2)
                Client.WriteNops(Client.Addresses.Client.NameSpy2, 2)
            End If
        Else
            If XRayEnabled = False Then
                Client.WriteShort(Client.Addresses.Client.NameSpy1, oldXray1)
                Client.WriteShort(Client.Addresses.Client.NameSpy2, oldXray2)
            End If
        End If
    End Sub
#End Region

    Public Function SpyFloor() As String
        Return CurrentLevel.ToString
    End Function

    Public Function XRayCheck() As String
        If XRayEnabled Then Return "On"
        Return "Off"
    End Function

    Public Function LightCheck() As String
        If LightEnabled Then Return "On"
        Return "Off"
    End Function
End Class
