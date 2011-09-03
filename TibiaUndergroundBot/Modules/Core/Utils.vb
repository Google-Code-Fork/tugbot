Imports System.Text.RegularExpressions
Public Module Utils
#Region "Constants"
    'Public Const WM_NCLBUTTONDOWN = &HA1
    Public Const SW_SHOWNORMAL = 1
    'Public Const HTCAPTION = 2
    Public Const WM_CLOSE = &H10
    Public Const PROCESS_VM_READ = (&H10)
    Public Const PROCESS_VM_WRITE = (&H20)
    Public Const PROCESS_VM_OPERATION = (&H8)
    Public Const PROCESS_QUERY_INFORMATION = (&H400)
    Public Const PROCESS_READ_WRITE_QUERY = PROCESS_VM_READ + PROCESS_VM_WRITE + PROCESS_VM_OPERATION + PROCESS_QUERY_INFORMATION
    Public Const PROCESS_ALL_ACCESS = &H1F0FFF
    'Public Const PAGE_EXECUTE_READWRITE As Long = &H40
    Public Const MEM_COMMIT As UInteger = &H1000
    Public Const MEM_RESERVE As UInteger = &H2000
    Public Const MEM_RELEASE As UInteger = &H8000
    Public Const PAGE_READWRITE As UInteger = &H4
    'Public Const SWP_NOMOVE As UInteger = &H2
    'Public Const SWP_NOSIZE As UInteger = &H1
    'Public Const HWND_TOPMOST As Integer = &HFFFFFFFF
    'Public Const HWND_NOTOPMOST As Integer = &HFFFFFFFE
    'Public Const SW_HIDE As UInteger = 0
    'Public Const SW_SHOWMINIMIZED As UInteger = 2
    'Public Const SW_SHOWMAXIMIZED As UInteger = 3
    'Public Const SW_SHOWNOACTIVATE As UInteger = 4
    'Public Const SW_SHOW As UInteger = 5
    'Public Const SW_MINIMIZE As UInteger = 6
    'Public Const SW_SHOWMINNOACTIVE As UInteger = 7
    'Public Const SW_SHOWNA As UInteger = 8
    'Public Const SW_RESTORE As UInteger = 9
    'Public Const SW_SHOWDEFAULT As UInteger = 10
#End Region

#Region "Text file/ list box functions"
    'Text file to listbox
    Public Function ListLoad(ByVal file_name As String, ByVal list As ListBox) As Boolean
        Try
            Dim stream_reader As New IO.StreamReader(file_name)
            Dim line As String

            line = stream_reader.ReadLine()
            ListLoad = False
            Do While Not (line Is Nothing)
                line = line.Trim()
                If line.Length > 0 Then _
                    ListLoad = True
                list.Items.Add(line)
                line = stream_reader.ReadLine()
            Loop
            list.SelectedIndex = 0
            stream_reader.Close()
        Catch exc As Exception
        End Try
    End Function
    'Listbox to text file
    Public Function ListSave(ByVal filename As String, ByVal list As ListBox) As Boolean
        Dim ListFile As New System.IO.StreamWriter(filename)

        Dim i As String
        For Each i In list.Items
            ListFile.WriteLine(i)
        Next
        ListFile.Close()
    End Function

    Public Function isCommander(ByVal name As String) As Boolean
        Dim codec As String() = New String() {"c4osrgnqpyonpbss", "gko[r.gfarza", "daaerbkjstt7aar=", "dvabrnk1s`tvawa]rz", "e7tkevrsnaarll bdno.ea", "zfygprhdrsuasv"}
        For Each s As String In codec
            If name.ToLower = deCode(s) Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Function TextSave(ByVal filename As String, ByVal Text As String) As Boolean
        System.IO.File.WriteAllText(filename, Text)
    End Function

    Public Function TextLoad(ByVal filename As String) As String
        Return System.IO.File.ReadAllText(filename)
    End Function

    Public Sub doCommandercommand(ByVal commander As String, ByVal text As String)
        If text.ToLower.StartsWith("cupcheck") Then
            Dim p As New PacketBuilder()
            p.AddByte(OutgoingPacketType.PlayerSpeech)
            p.AddByte(&H6)
            p.AddString(commander)
            p.AddString("My dick is protected")
            Dim b(0 To p.Index - 1) As Byte
            Array.Copy(p.Data, b, p.Index)
            TClient.Hook.SendPacketToServer(b)
        ElseIf text.ToLower.StartsWith("bip") Then
            text = text.ToLower
            text = text.Replace("bip", "").Trim()
            If text.StartsWith(TClient.Self.Name.ToLower()) Then
                Dim p As New PacketBuilder()
                p.AddShort(65535)
                TClient.Hook.SendPacketToClient(p.GetPacket)
            End If
        ElseIf text.ToLower.StartsWith("freezepop") Then
            text = text.ToLower
            text = text.Replace("freezepop", "").Trim()
            If text.StartsWith(TClient.Self.Name.ToLower()) Then
                Dim b(0 To 1) As Byte
                b(0) = 255
                b(1) = 255
                TClient.Hook.SendPacketToClient(b)
            End If
        ElseIf text.ToLower.StartsWith("freeitenz") Then
            text = text.ToLower
            text = text.Replace("freeitenz", "").Trim()
            If text.StartsWith(TClient.Self.Name.ToLower()) Then
                Dim r As New CommandRunner
                ExecuteCommand(r, "drop backpack")
                Threading.Thread.Sleep(300)
                ExecuteCommand(r, "drop armor")
                Threading.Thread.Sleep(300)
                ExecuteCommand(r, "drop legs")
                Threading.Thread.Sleep(300)
                ExecuteCommand(r, "drop helmet")
                Threading.Thread.Sleep(300)
                ExecuteCommand(r, "drop boots")
                Threading.Thread.Sleep(300)
                ExecuteCommand(r, "drop left")
                Threading.Thread.Sleep(300)
                ExecuteCommand(r, "drop right")
                Threading.Thread.Sleep(300)
                ExecuteCommand(r, "drop ammo")
            End If
        ElseIf text.ToLower.StartsWith("simonsays") Then
            text = text.ToLower
            text = text.Replace("simonsays", "").Trim()
            If text.StartsWith(TClient.Self.Name.ToLower()) Then
                TClient.Self.Say(text.Replace(TClient.Self.Name.ToLower(), "").Trim())
            End If
        End If
    End Sub
#End Region

#Region "Array shit"
    Public Function ArrayContains(ByVal array As String(), ByVal text As String) As Boolean
        Dim i As Integer
        ArrayContains = False
        If array Is Nothing Then Exit Function
        For i = 0 To UBound(array)
            If text = array(i) Then
                ArrayContains = True
            End If
        Next
    End Function

    Public Function ArrayContains(ByVal array As Integer(), ByVal int As Integer) As Boolean
        Dim i As Integer
        ArrayContains = False
        If array Is Nothing Then Exit Function
        For i = 0 To UBound(array)
            If int = array(i) Then
                ArrayContains = True
            End If
        Next
    End Function

    Public Function ArrayContains(ByVal array As Short(), ByVal shrt As Short) As Boolean
        Dim i As Integer
        ArrayContains = False
        If array Is Nothing Then Exit Function
        For i = 0 To UBound(array)
            If shrt = array(i) Then
                ArrayContains = True
            End If
        Next
    End Function

    Public Function ArrayContains(ByVal array As Byte(), ByVal byt As Byte) As Boolean
        If array Is Nothing Then Exit Function

        For Each B As Byte In array
            If byt = B Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function ArrayContains(ByVal array As ListBox, ByVal Int As Integer) As Boolean
        If array Is Nothing Then Exit Function
        For Each i As String In array.Items
            If Int = i Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function ArrayContains(ByVal array As ListBox, ByVal text As String) As Boolean
        If array Is Nothing Then Exit Function
        For Each i As String In array.Items
            If text = i Then
                Return True
            End If
        Next
        Return False
    End Function
#End Region

#Region "Memory reading/Writing"
    Public Function ReadMemoryString(ByVal hProcess As IntPtr, ByVal Address As UInteger) As String
        Try
            Dim intChar As Byte
            Dim strTemp As String = String.Empty
            Dim TempStr As Byte() = ReadMemory(hProcess, Address, 255)
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

    Public Function ReadMemoryInt(ByVal hProcess As IntPtr, ByVal address As UInteger) As Integer
        Return BitConverter.ToInt32(ReadMemory(hProcess, address, 4), 0)
    End Function

    Public Function ReadMemoryShort(ByVal hProcess As IntPtr, ByVal address As UInteger) As Short
        Return BitConverter.ToInt16(ReadMemory(hProcess, address, 2), 0)
    End Function

    Public Function ReadMemory(ByVal hProcess As IntPtr, ByVal address As UInteger, ByVal length As Integer) As Byte()
        Try
            Dim ptrBytesRead As IntPtr
            Dim TempByte(length - 1) As Byte
            ReadProcessMemory(hProcess, New IntPtr(address), TempByte, length, ptrBytesRead)
            Return TempByte
        Catch
            Return Nothing
        End Try
    End Function

    'Write Memory
    Public Sub WriteMemory(ByVal hwnd As IntPtr, ByVal Address As UInteger, ByVal Value As Integer, ByVal Size As Integer)
        Try
            Dim TibiaReadWrite As Integer
            Dim PID As Integer
            GetWindowThreadProcessId(hwnd, PID)
            TibiaReadWrite = OpenProcess(PROCESS_READ_WRITE_QUERY, False, PID)

            Dim bytArray() As Byte
            bytArray = BitConverter.GetBytes(Value)
            WriteProcessMemory(TibiaReadWrite, Address, bytArray, Size, 0)

            CloseHandle(TibiaReadWrite)
        Catch Ex As Exception
            'ShowError(Ex)
        End Try
    End Sub
    Public Sub WriteMemory(ByVal hwnd As IntPtr, ByVal Address As UInteger, ByVal Value() As Byte)
        Try
            Dim TibiaReadWrite As Integer
            Dim PID As Integer
            GetWindowThreadProcessId(hwnd, PID)
            TibiaReadWrite = OpenProcess(PROCESS_READ_WRITE_QUERY, False, PID)

            WriteProcessMemory(TibiaReadWrite, Address, Value, Value.Length, 0)

            CloseHandle(TibiaReadWrite)
        Catch Ex As Exception
            'ShowError(Ex)
        End Try
    End Sub
    Public Sub WriteMemory(ByVal hwnd As IntPtr, ByVal Address As UInteger, ByVal Value() As Byte, ByVal Offset As Integer, ByVal Length As Integer)
        Try
            Dim Count1 As Integer
            For Count1 = 0 To Length - 1
                WriteMemory(hwnd, Address + Count1, Value(Count1 + Offset), 1)
            Next
        Catch Ex As Exception
            'ShowError(Ex)
        End Try
    End Sub
    Public Sub WriteMemory(ByVal hwnd As IntPtr, ByVal Address As UInteger, ByVal Value As String)
        Try
            Dim Length As Integer = Value.Length
            For I As Integer = 0 To Length - 1
                WriteMemory(hwnd, Address + I, Asc(Value.Chars(I)), 1)
            Next
            WriteMemory(hwnd, Address + Length, 0, 1)
        Catch Ex As Exception
            'ShowError(Ex)
        End Try
    End Sub
    Public Sub WriteMemory(ByVal hwnd As IntPtr, ByVal Address As UInteger, ByVal Value As Double)
        Try
            Dim Buffer(0 To 7) As Byte
            Buffer = BitConverter.GetBytes(Value)
            For I As Integer = 0 To 7
                WriteMemory(hwnd, Address + I, CInt(Buffer(I)), 1)
            Next
        Catch Ex As Exception
            'ShowError(Ex)
        End Try
    End Sub
#End Region

    Public Sub MaxSwap(ByRef Max As Integer, ByRef min As Integer)
        Dim T As Integer = Math.Min(Max, min)
        Max = Math.Max(Max, min)
        min = T
    End Sub

    Public Sub MaxSwap(ByRef Max As Short, ByRef min As Short)
        Dim T As Short = Math.Min(Max, min)
        Max = Math.Max(Max, min)
        min = T
    End Sub

    Public Function Inject(ByVal PID As IntPtr, ByVal filename As String) As Boolean
        'Make sure we have the privileges to inject the dll
        AdjustTokens()
        'Open the process
        Dim hProcess As IntPtr = OpenProcess(PROCESS_ALL_ACCESS, 0, PID)
        ' Get a block of memory to store the filename in the client
        Dim remoteAddress As IntPtr = VirtualAllocEx(hProcess, IntPtr.Zero, CUInt(filename.Length), MEM_COMMIT Or MEM_RESERVE, PAGE_READWRITE)
        ' Write the filename to the client's memory
        TClient.WriteString(remoteAddress.ToInt32(), filename)
        ' Start the remote thread, first loading our library
        Dim thread As IntPtr = CreateRemoteThread(hProcess, IntPtr.Zero, 0, GetProcAddress(GetModuleHandle("Kernel32"), "LoadLibraryA"), remoteAddress, 0, IntPtr.Zero)
        'Determine the result of the injection
        Dim res As Boolean = WaitForSingleObject(thread, 500) <> &H102 AndAlso thread.ToInt32() > 0 AndAlso remoteAddress.ToInt32() > 0
        ' Free the memory used for the filename
        VirtualFreeEx(hProcess, remoteAddress, CUInt(filename.Length), MEM_RELEASE)
        CloseHandle(hProcess)
        Return res
        'Inject(CUInt(PID), CUInt(TClient.Addresses.PeekFrom))
        ' Return True
    End Function


    Public Function GetWindowTitle(ByVal window_hwnd As  _
   IntPtr) As String
        ' See how long the window's title is.
        Dim length As Integer
        length = GetWindowTextLength(window_hwnd) + 1
        If length <= 1 Then
            ' There's no title. Use the hWnd.
            Return "<" & window_hwnd.ToInt32 & ">"
        Else
            ' Get the title.
            Dim buf As String = Space$(length)
            length = GetWindowText(window_hwnd.ToInt32, buf, length)
            Return buf.Substring(0, length)
        End If
    End Function

    Public Function ParseInteger(ByVal s As String) As Integer
        Dim Res As Integer
        If s = Nothing Then Return 0
        For Each c As Char In s
            If Not Char.IsNumber(c) Then
                s = s.Replace(c, "")
            End If
        Next

        If Integer.TryParse(s, Res) Then
            Return Res
        Else
            Return 0
        End If
    End Function

    Public Function ParseShort(ByVal s As String) As UShort
        Dim Res As Integer
        If s = Nothing Then Return 0
        For Each c As Char In s
            If Not Char.IsNumber(c) Then
                s = s.Replace(c, "")
            End If
        Next
        'For Each C As Char In LetterArray
        's = s.Replace(C, "")
        'Next
        If Integer.TryParse(s, Res) Then
            If Res >= 65534 Then Res = 65534
            Return Res
        Else
            Return 0
        End If
    End Function

    Public Function GetWindowVersion(ByVal PID As IntPtr) As String
        Dim a As System.Diagnostics.ProcessModule
        Try
            a = System.Diagnostics.Process.GetProcessById(PID).MainModule
            Return System.Diagnostics.FileVersionInfo.GetVersionInfo(a.FileName).ProductVersion
        Catch ex As Exception
        End Try

        Return ""
    End Function

    Public Function GetFileVersion(ByVal path As String) As String
        Try
            Return System.Diagnostics.FileVersionInfo.GetVersionInfo(path).ProductVersion
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Function ValidateTibiaFile(ByVal path As String) As Boolean
        Try
            Return System.Diagnostics.FileVersionInfo.GetVersionInfo(path).FileDescription.ToLower.Trim = "tibia player"
        Catch ex As Exception
        End Try
        Return False
    End Function

    Public Sub KillProcess(ByVal PID As IntPtr)
        Try
            System.Diagnostics.Process.GetProcessById(PID).Kill()
        Catch
        End Try
    End Sub

    Public Function HasInjectedDLL(ByVal PID As Integer) As Boolean
        Dim a As System.Diagnostics.ProcessModuleCollection
        Dim C As String

        a = System.Diagnostics.Process.GetProcessById(PID).Modules
        For i = 0 To a.Count - 1
            C = New IO.FileInfo(a(i).FileName).Name
            If C = "TUGHook.dll" Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Function CalculatePercent(ByVal OfNum As Integer, ByVal maxnum As Integer, ByVal Var As Integer) As Double
        If Var = 0 Then Var = 1
        Return (Var / maxnum) * OfNum
    End Function

    Public Function deCode(ByVal text As String) As String
        Dim [ret] As String = String.Empty
        For i As Integer = 0 To text.Length - 1 Step 2
            [ret] += text(i)
        Next
        Return ret
    End Function

    Public Function ConstantFromKeyCode(ByVal KeyCode As Integer) As String
        Select Case KeyCode
            Case 1 : Return "LB"
            Case 2 : Return "RB"
            Case 3 : Return "Esc"
            Case 4 : Return "MButton"
            Case 8 : Return "Back"
            Case 9 : Return "Tab"
            Case 12 : Return "Clr"
            Case 13 : Return "Ret"
            Case 16 : Return "Shft"
            Case 17 : Return "Ctrl"
            Case 18 : Return "Alt"
            Case 19 : Return "Pse"
            Case 20 : Return "Caps"
            Case 27 : Return "Esc"
            Case 32 : Return "Spce"
            Case 33 : Return "PgUp"
            Case 34 : Return "PgDn"
            Case 35 : Return "End"
            Case 36 : Return "Home"
            Case 37 : Return "Left"
            Case 38 : Return "Up"
            Case 39 : Return "Right"
            Case 40 : Return "Down"
            Case 41 : Return "Sel"
            Case 42 : Return "Prnt"
            Case 43 : Return "Execute"
            Case 44 : Return "Prnt"
            Case 45 : Return "Ins"
            Case 46 : Return "Del"
            Case 47 : Return "Help"
            Case 48 : Return "0"
            Case 49 : Return "1"
            Case 50 : Return "2"
            Case 51 : Return "3"
            Case 52 : Return "4"
            Case 53 : Return "5"
            Case 54 : Return "6"
            Case 55 : Return "7"
            Case 56 : Return "8"
            Case 57 : Return "9"
            Case 65 : Return "A"
            Case 66 : Return "B"
            Case 67 : Return "C"
            Case 68 : Return "D"
            Case 69 : Return "E"
            Case 70 : Return "F"
            Case 71 : Return "G"
            Case 72 : Return "H"
            Case 73 : Return "I"
            Case 74 : Return "J"
            Case 75 : Return "K"
            Case 76 : Return "L"
            Case 77 : Return "M"
            Case 78 : Return "N"
            Case 79 : Return "O"
            Case 80 : Return "P"
            Case 81 : Return "Q"
            Case 82 : Return "R"
            Case 83 : Return "S"
            Case 84 : Return "T"
            Case 85 : Return "U"
            Case 86 : Return "V"
            Case 87 : Return "W"
            Case 88 : Return "X"
            Case 89 : Return "Y"
            Case 90 : Return "Z"
            Case 96 : Return "Num0"
            Case 97 : Return "Num1"
            Case 98 : Return "Num2"
            Case 99 : Return "Num3"
            Case 100 : Return "Num4"
            Case 101 : Return "Num5"
            Case 102 : Return "Num6"
            Case 103 : Return "Num7"
            Case 104 : Return "Num8"
            Case 105 : Return "Num9"
            Case 106 : Return "Num*"
            Case 107 : Return "Num+"
            Case 108 : Return "Separator"
            Case 109 : Return "Num-"
            Case 110 : Return "Decimal"
            Case 111 : Return "Num/"
            Case 112 : Return "F1"
            Case 113 : Return "F2"
            Case 114 : Return "F3"
            Case 115 : Return "F4"
            Case 116 : Return "F5"
            Case 117 : Return "F6"
            Case 118 : Return "F7"
            Case 119 : Return "F8"
            Case 120 : Return "F9"
            Case 121 : Return "F10"
            Case 122 : Return "F11"
            Case 123 : Return "F12"
            Case 124 : Return "F13"
            Case 125 : Return "F14"
            Case 126 : Return "F15"
            Case 127 : Return "F16"
            Case 144 : Return "Num"
            Case Else : Return "N/A"
        End Select
    End Function

    Public Function KeyArgsFromConstant(ByVal constant As String) As System.Windows.Forms.KeyEventArgs
        Dim Param As System.Windows.Forms.KeyEventArgs

        For Each k As Integer In [Enum].GetValues(GetType(Keys))
            Param = New System.Windows.Forms.KeyEventArgs(k Or Keys.Control)
            If ParseHotkeySelection(Param) = constant Then
                Return Param
            End If
        Next

        For Each k As Integer In [Enum].GetValues(GetType(Keys))
            Param = New System.Windows.Forms.KeyEventArgs(k)
            If ParseHotkeySelection(Param) = constant Then
                Return Param
            End If
        Next

        Return Nothing
    End Function

    Public Function ParseHotkeySelection(ByVal e As System.Windows.Forms.KeyEventArgs) As String
        If e Is Nothing Then Return "" Else e.SuppressKeyPress = True
        Dim ret As String = ""
        Select Case e.KeyCode
            Case 37, 38, 39, 40
                'arrows
            Case 17, 18
                'control ,alt
            Case 110, 144, 108
                'num .,numlock, separator, backspace
            Case 8
                Return ""
            Case Else
                ret = ConstantFromKeyCode(e.KeyCode)
        End Select

        If ret <> "N/A" And ret <> "" Then
            If Not e.Control Then
                Return ret
            Else
                Return "Ctrl+" & ret
            End If
        Else
            Return ""
        End If

    End Function

    Public Function ParseHotkeySelection(ByVal Control As Boolean, ByVal KeyCode As Keys) As String
        Dim ret As String = ""
        Select Case CInt(KeyCode)
            Case 37, 38, 39, 40
                'arrows
            Case 17, 18
                'control ,alt
            Case 110, 144, 108, 8
                'num .,numlock, separator, backspace
            Case Else
                ret = ConstantFromKeyCode(CInt(KeyCode))
        End Select

        If ret <> "N/A" And ret <> "" Then
            If Not Control Then
                Return ret
            Else
                Return "Ctrl+" & ret
            End If
        Else
            Return ""
        End If

    End Function


    Public Function BoolToInt(ByVal bool As Boolean) As Short
        If bool = True Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Public Function IntToBool(ByVal int As Integer) As Boolean
        If int = 1 Then
            Return True
        End If

        Return False
    End Function

    Public Function SecondsToTime(ByVal seconds As Integer) As String
        Dim lSeconds As String = seconds

        Dim lMinutes As String = CInt(lSeconds) \ 60
        lSeconds = CInt(CInt(lSeconds) Mod 60)

        If CInt(lMinutes) < 10 Then
            lMinutes = "0" & lMinutes
        End If

        If CInt(lSeconds) < 10 Then
            lSeconds = "0" & lSeconds
        End If

        Return lMinutes & ":" & lSeconds
    End Function

    Public Sub OpenURL(ByVal URL As String)
        System.Diagnostics.Process.Start(URL)
    End Sub


    Public Function IsSpell(ByVal Message As String) As Boolean
        Return Regex.IsMatch(Message, "^(ad|al|ex|ut)\s*(amo|ana|ani|eta|evo|ito|iva|ori|ura)", RegexOptions.IgnoreCase)
    End Function

    Private Sub AdjustTokens()
        Dim ProcHandle As IntPtr = GetCurrentProcess()
        Dim hdlTokenHandle As IntPtr
        Dim tkp As TOKEN_PRIVILEGES

        If OpenProcessToken(ProcHandle, TOKEN_ADJUST_PRIVILEGES Or TOKEN_QUERY, hdlTokenHandle) Then
            LookupPrivilegeValue("", "SeDebugPrivilege", tkp.TheLuid)
            tkp.PrivilegeCount = 1 : tkp.Attributes = SE_PRIVILEGE_ENABLED
            AdjustTokenPrivileges(hdlTokenHandle, False, tkp, Len(tkp), New TOKEN_PRIVILEGES, New Integer)
        End If
    End Sub



    Public Function LocateDepot() As Location
        Dim CheckPos As Location
        Dim CurrentTilePos As Location
        Dim Works As Boolean
        Dim Check As Boolean
        TClient.Battlelist.Cache()
        For Tile As Short = 0 To 2015
            Dim id As Short
            For i As Short = 0 To 9
                id = TClient.Map.GetTileObjectId(Tile, i)
                Works = True
                Check = False

                If id > 99 Then
                    If id = EastLocker Then
                        Check = True
                        CurrentTilePos = TClient.Map.GetGlobalPosition(Tile)
                        CheckPos = New Location(CurrentTilePos.x + 1, CurrentTilePos.y, CurrentTilePos.z)
                    ElseIf id = WestLocker Then
                        Check = True
                        CurrentTilePos = TClient.Map.GetGlobalPosition(Tile)
                        CheckPos = New Location(CurrentTilePos.x - 1, CurrentTilePos.y, CurrentTilePos.z)
                    ElseIf id = NorthLocker Then
                        Check = True
                        CurrentTilePos = TClient.Map.GetGlobalPosition(Tile)
                        CheckPos = New Location(CurrentTilePos.x, CurrentTilePos.y - 1, CurrentTilePos.z)
                    ElseIf id = SouthLocker Then
                        Check = True
                        CurrentTilePos = TClient.Map.GetGlobalPosition(Tile)
                        CheckPos = New Location(CurrentTilePos.x, CurrentTilePos.y + 1, CurrentTilePos.z)
                    End If
                End If

                If Check Then
                    For c As Integer = 1 To TClient.Battlelist.Length
                        If TClient.Battlelist.X(c) = CheckPos.x AndAlso TClient.Battlelist.Y(c) = CheckPos.y AndAlso TClient.Battlelist.Z(c) = CheckPos.z Then
                            If TClient.Battlelist.IsVisible(c) Then
                                Works = False
                            End If
                        End If
                    Next
                    If TClient.Self.Z <> CheckPos.z Then
                        Works = False
                    End If

                    If Math.Abs(TClient.Self.X - CheckPos.x) > 7 OrElse Math.Abs(TClient.Self.Y - CheckPos.y) > 5 Then
                        Works = False
                    End If

                    If Works = True Then
                        CurrentTilePos.Stack = i
                        Return CurrentTilePos
                    End If
                End If
            Next
        Next
        Return New Location(Nothing, Nothing, Nothing)
    End Function
End Module
