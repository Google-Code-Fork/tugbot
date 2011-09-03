Imports System.Threading
Imports System.Runtime.InteropServices
Partial Public Class Client
    Public Event AddedWaypoint(ByVal type As String)
    Dim hProcess As IntPtr
    Public p As System.Diagnostics.Process
    Public Enum ToggleFuncs
        XRay
        Light
        Attacker
        Looter
        Walker
        Idle
    End Enum
    Public Event FunctionToggled(ByVal ToggleFuncs As ToggleFuncs, ByVal OnOff As Boolean)

#Region "Sub-Classess"
    Public WithEvents Hook As TibiaHook
    Public Battlelist As New BattleList(Me)
    Public Map As Map
    Public Screen As New Screen(Me)
    Public Containers As Containers
#End Region

#Region "Variables"
    Private Ver As String
    Private WindowHandle As IntPtr
    Private ProcessID As Integer
    Private Indx As Integer
    Public ClientTimer As Timer

    Private IsHdn As Boolean = False
#End Region

#Region "Checking for client open"
    Public Sub CheckClient()
        If p.HasExited Then
            Closed()
        End If
    End Sub
#End Region

#Region "Window Properties"
    'Title
    Public Property Title() As String
        Get
            'Dim length As Integer = GetWindowTextLength(WindowHandle) + 1
            'Dim buf As String = Space$(length)

            'length = GetWindowText(WindowHandle.ToInt32, buf, length)
            'Return buf.Substring(0, length)

            Return p.MainWindowTitle
        End Get
        Set(ByVal value As String)
            Dim sb As New System.Text.StringBuilder(value)
            SetWindowText(WindowHandle, sb)
        End Set
    End Property

    'Rect
    Public ReadOnly Property Rect() As Rect
        Get
            GetWindowRect(WindowHandle, Rect)
        End Get
    End Property

    'Foreground
    Public Property IsTopMost() As Boolean
        Get
            If GetForegroundWindow = WindowHandle Then Return True
            Return False
        End Get
        Set(ByVal value As Boolean)
            If value = True Then
                SetForegroundWindow(WindowHandle)
            End If
        End Set
    End Property

    'Handle
    Public ReadOnly Property Handle() As IntPtr
        Get
            Return WindowHandle
        End Get
    End Property

    'PID
    Public ReadOnly Property Process() As IntPtr
        Get
            Return ProcessID
        End Get
    End Property

    'Visible
    Public Property Visible() As Boolean
        Get
            Return Not IsHdn
        End Get
        Set(ByVal value As Boolean)
            IsHdn = Not value
            If value Then
                ShowWindow(WindowHandle, WindowShowStyle.ShowNoActivate)
                Me.IsTopMost = True
            Else
                ShowWindow(WindowHandle, WindowShowStyle.Hide)
            End If
        End Set
    End Property
#End Region

#Region "Dialogs"
    Public ReadOnly Property IsDialogOpen() As Boolean
        Get
            If ReadInt(TAddresses.Client.DialogBegin) <> 0 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public ReadOnly Property DialogCaption() As String
        Get
            Dim TempPtr As Integer = ReadInt(TAddresses.Client.DialogBegin)
            If TempPtr <> 0 Then
                Return ReadString(TAddresses.Client.DialogCaption + TempPtr)
            Else
                Return ""
            End If
        End Get
    End Property
#End Region

#Region "Properties"
    Public ReadOnly Property Addresses() As Addresses
        Get
            Return TAddresses
        End Get
    End Property

    Public ReadOnly Property Self() As Self
        Get
            Return TPlayer
        End Get
    End Property

    Public ReadOnly Property Version() As String
        Get
            Return Ver
        End Get
    End Property

    Public ReadOnly Property Index() As Integer
        Get
            Return Indx
        End Get
    End Property

    Public ReadOnly Property Status() As Integer
        Get
            Return ReadInt(TAddresses.Client.Connection)
        End Get
    End Property
#End Region

#Region "Memory"
#Region "Read"
    Public Function ReadDouble(ByVal address As UInteger) As Double
        Return BitConverter.ToDouble(ReadMemory(hProcess, address, 8), 0)
    End Function

    Public Function ReadInt(ByVal address As UInteger) As Integer
        Return BitConverter.ToInt32(ReadMemory(hProcess, address, 4), 0)
    End Function

    Public Function ReadShort(ByVal address As UInteger) As Short
        Return BitConverter.ToInt16(ReadMemory(hProcess, address, 2), 0)
    End Function

    Public Function ReadUInt(ByVal address As UInteger) As UInteger
        Return BitConverter.ToUInt32(ReadMemory(hProcess, address, 4), 0)
    End Function

    Public Function ReadUShort(ByVal address As UInteger) As UShort
        Return BitConverter.ToUInt16(ReadMemory(hProcess, address, 2), 0)
    End Function

    Public Function ReadBytes(ByVal address As UInteger, ByVal length As Integer) As Byte()
        Return ReadMemory(hProcess, address, length)
    End Function

    Public Function ReadByte(ByVal address As UInteger) As Byte
        Return ReadBytes(address, 1)(0)
    End Function

    Public Function ReadString(ByVal Address As UInteger) As String
        Try
            Dim intChar As Byte
            Dim strTemp As String = String.Empty
            Dim TempStr As Byte() = ReadBytes(Address, 255)
            For i = 0 To 254
                intChar = TempStr(i)
                If intChar <> 0 Then
                    strTemp = strTemp & Chr(intChar)
                Else
                    Exit For
                End If
            Next
            Return strTemp
        Catch
            Return ""
        End Try
    End Function
#End Region

#Region "Write"
    Public Sub WriteDouble(ByVal address As UInteger, ByVal value As Double)
        WriteMemory(Handle, address, value)
    End Sub

    Public Sub WriteInt(ByVal address As UInteger, ByVal value As Integer)
        WriteMemory(Handle, address, value, 4)
    End Sub

    Public Sub WriteShort(ByVal address As UInteger, ByVal value As Short)
        WriteMemory(Handle, address, value, 2)
    End Sub

    Public Sub WriteBytes(ByVal address As UInteger, ByVal value As Byte())
        WriteMemory(Handle, address, value)
    End Sub

    Public Sub WriteByte(ByVal address As UInteger, ByVal value As Byte)
        WriteMemory(Handle, address, value, 1)
    End Sub

    Public Sub WriteString(ByVal address As UInteger, ByVal value As String)
        Dim TempByte(value.Length) As Byte
        For I As Integer = 0 To value.Length - 1
            TempByte(I) = Asc(value.Chars(I))
        Next
        WriteBytes(address, TempByte)
    End Sub
#End Region

    Public Sub WriteNops(ByRef Address As Long, ByRef NOPS As Integer)
        Dim i, j As Integer
        For i = 1 To NOPS Step 1
            Dim NOP As Byte
            NOP = &H90
            WriteMemory(Me.Handle, Address + j, NOP, 1)
            j = j + 1
        Next i
    End Sub
#End Region

#Region "Show"
    Public Sub ShowStatusMessage(ByRef text As String, ByRef DisplayTime As Integer)
        If CDbl(TClient.Version) >= CDbl("8.61") Then
            Dim Packet As New PacketBuilder(IncomingPacketType.StatusMessage)
            Packet.AddByte(&H14)
            Packet.AddString(text)
            Me.Hook.SendPacketToClient(Packet.GetPacket)
        Else
            WriteInt(Addresses.Client.StatusTime, DisplayTime)
            WriteString(Addresses.Client.StatusText, text)
        End If
    End Sub

    Public Function CurrentStatusMessage() As String
        Return ReadString(Addresses.Client.StatusText)
    End Function
#End Region

#Region "Parse Commands"

    Public Function ParseCommand(ByVal command As String) As Boolean
        Dim CompareCommand As String = command.ToLower
        Dim Args As String()

        'spy
        If CompareCommand.StartsWith("spy ") And CompareCommand <> "spy " Then
            Args = Split(CompareCommand, " ")
            Select Case Args(1)
                Case "up", "+"
                    Return Screen.LevelSpyUp
                Case "down", "-"
                    Return Screen.LevelSpyDown
                Case "clear", "center", "none"
                    Return Screen.LevelSpyCenter
                Case "check"
                    Screen.LevelSpyMessage()
                    Return False
            End Select
            'toggle
        ElseIf CompareCommand.StartsWith("toggle ") And CompareCommand <> "toggle " Then
            Args = Split(CompareCommand, " ")
            Select Case Args(1)
                Case "light"
                    RaiseEvent FunctionToggled(ToggleFuncs.Light, Not Screen.LightEnabled)
                    Return False
                Case "xray", "x-ray"
                    RaiseEvent FunctionToggled(ToggleFuncs.XRay, Not Screen.XRayEnabled)
                    Return False
                Case "walker"
                    RaiseEvent FunctionToggled(ToggleFuncs.Walker, False)
                    Return False
                Case "attacker"
                    RaiseEvent FunctionToggled(ToggleFuncs.Attacker, False)
                    Return False
                Case "looter"
                    RaiseEvent FunctionToggled(ToggleFuncs.Looter, False)
                    Return False
                Case "idle"
                    RaiseEvent FunctionToggled(ToggleFuncs.Idle, False)
                    Return False
                Case "pause", "status"
                    Paused = Not Paused
                    If Paused Then
                        Self.StopMoving()
                        ShowStatusMessage("TUGBot -> All Automatic Actions Paused", 50)
                    Else
                        ShowStatusMessage("TUGBot -> All Automatic Actions Resumed", 50)
                    End If
                    Return False
                Case "view"
                    If Args.Length = 3 Then
                        Select Case Args(2)
                            Case "self", "client", "tibia"
                                If Me.Visible Then
                                    Me.Visible = False
                                Else
                                    Me.Visible = True
                                End If
                        End Select
                    End If
            End Select
            'say
        ElseIf CompareCommand.StartsWith("say ") And CompareCommand <> "say " Then
            command = command.Remove(0, 4)
            Self.Say(FormatSpell(command))
            Return False
            'Use
        ElseIf CompareCommand.StartsWith("use ") And CompareCommand <> "use " Then
            Args = Split(CompareCommand, " ")
            If Args.Length = 3 Then
                Select Case Args(1)
                    Case "target"
                        Self.UseItemWithCreature(FormatItem(Args(2)), Self.Target)
                        Return False
                    Case "self"
                        Self.UseItemWithCreature(FormatItem(Args(2)), Self.Id)
                        Return False
                End Select
            End If
        ElseIf CompareCommand.StartsWith("dolua") Then
            'Args = Split(CompareCommand, " ")
            'If Args.Length >= 2 Then
            '    command = command.Remove(0, 6 + Args(1).Length)
            '    For Each L As LuaScript In Scripter.LuaScripts
            '        L.CustomEvent(Args(1), command.Split(","))
            '    Next
            '    Return False
            'End If
        ElseIf CompareCommand = "exivalast" Then
            Me.Self.Say("Exiva """ & LastExiva)
            Return False
        ElseIf CompareCommand.StartsWith("caveadd") Then
            Args = Split(CompareCommand, " ")
            If Args.Length = 2 Then
                RaiseEvent AddedWaypoint(Args(1))
                Return False
            End If
        End If

        ShowStatusMessage("TUGBot -> Command """ & command & """ is not recognized.", 50)
        Return True
    End Function


    Public Sub ToggleFunction(ByVal T As ToggleFuncs, Optional ByVal OnOff As Boolean = False)
        RaiseEvent FunctionToggled(T, OnOff)
    End Sub
#End Region

    Public Function CheckStatus() As String
        If Paused Then Return "Paused"
        Return "Running"
    End Function
End Class
