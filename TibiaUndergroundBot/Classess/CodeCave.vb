Public Class CodeCave
    Dim CaveBytes(5000) As Byte
    Dim CaveLen As Integer = 0

    Public Enum OPCodes As Byte
        PushEBP = &H55
        PushEDI = &H57
        PushAD = &H60
        PushFD = &H9C

        PopEBX = &H5B
        PopFD = &H9D
        PopAD = &H61

        Nop = &H90
    End Enum

#Region "OP Codes"
    Public Sub AddOp(ByVal OPCode As OPCodes)
        Dim B As Byte() = {OPCode, OPCodes.Nop, OPCodes.Nop, OPCodes.Nop}
        Array.Copy(B, 0, CaveBytes, CaveLen, 4)
        CaveLen += 4
    End Sub

    Public Sub Push(ByVal Arg As Integer)
        Dim B As Byte() = {&H68, 0, 0, 0}
        Array.Copy(B, 0, CaveBytes, CaveLen, 4)
        CaveLen += 4
        Array.Copy(BitConverter.GetBytes(Arg), 0, CaveBytes, CaveLen, 4)
        CaveLen += 4
    End Sub

    Public Sub MovEAX(ByVal Arg As Integer)
        Dim B As Byte() = {&HA1, 0, 0, 0}
        Array.Copy(B, 0, CaveBytes, CaveLen, 4)
        CaveLen += 4
        Array.Copy(BitConverter.GetBytes(Arg), 0, CaveBytes, CaveLen, 4)
        CaveLen += 4
    End Sub

    Public Sub MovEBX(ByVal Arg As Integer)
        Dim B As Byte() = {&HBB, 0, 0, 0}
        Array.Copy(B, 0, CaveBytes, CaveLen, 4)
        CaveLen += 4
        Array.Copy(BitConverter.GetBytes(Arg), 0, CaveBytes, CaveLen, 4)
        CaveLen += 4
    End Sub

    Public Sub CallEAX()
        Array.Copy(BitConverter.GetBytes(CInt(&HFFD0)), 0, CaveBytes, CaveLen, 4)
        CaveLen += 4
    End Sub

    Public Sub JmpEBX()
        Array.Copy(BitConverter.GetBytes(CInt(&HFFE3)), 0, CaveBytes, CaveLen, 4)
        CaveLen += 4
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property Length()
        Get
            Return CaveLen + 1
        End Get
    End Property
#End Region

#Region "Methods"
    Private Function AllocMem(ByVal PID As UInt32) As Integer
        Dim hProcess As IntPtr = OpenProcess(PROCESS_ALL_ACCESS, 0, PID)
        Return VirtualAllocEx(hProcess, IntPtr.Zero, Me.Length, MEM_COMMIT Or MEM_RESERVE, PAGE_READWRITE)
    End Function

    Public Function InjectCode(ByVal HWND As IntPtr) As Integer
        Dim TempPID As UInteger
        GetWindowThreadProcessId(HWND, TempPID)
        Return InjectCode(TempPID)
    End Function

    Public Function InjectCode(ByVal HWND As IntPtr, ByVal Address As Integer) As Integer
        Dim TempPID As UInteger
        GetWindowThreadProcessId(HWND, TempPID)
        Return InjectCode(TempPID, Address)
    End Function

    Public Function InjectCode(ByVal pid As UInt32) As Integer
        Return InjectCode(pid, AllocMem(pid))
    End Function

    Public Function InjectCode(ByVal pid As UInt32, ByVal Address As Integer) As Integer
        Dim ByteToWrite(Me.Length) As Byte
        Array.Copy(CaveBytes, ByteToWrite, Me.Length)
        TClient.WriteBytes(Address, ByteToWrite)

        Return Address
    End Function
#End Region



    'Private Function Prepare() As Boolean
    '    Dim ret As Boolean = True
    '    Dim builder As New ArrayList()
    '    For i As Integer = 0 To argCount - 1
    '        'push dword ptr ds:[ebx]
    '        builder.AddRange(New Byte() {&HFF, &H33})
    '        If i <> argCount - 1 Then
    '            'add ebx,4
    '            builder.AddRange(New Byte() {&H83, &HC3, &H4})
    '        End If
    '    Next
    '    'mov ebx, tibiaFunctionAddress
    '    builder.Add(CByte(&HBB))
    '    builder.AddRange(BitConverter.GetBytes(tibiaFunctionAddress))
    '    'call ebx
    '    builder.AddRange(New Byte() {&HFF, &HD3})
    '    'push 0
    '    builder.AddRange(New Byte() {&H6A, &H0})
    '    'mov ebx, exitThreadAddress
    '    builder.Add(CByte(&HBB))
    '    builder.AddRange(BitConverter.GetBytes(exitThreadAddress))
    '    'call ebx
    '    builder.AddRange(New Byte() {&HFF, &HD3})

    '    code = DirectCast(builder.ToArray(GetType(Byte)), Byte())

    '    'allocating memory for the code's bytes
    '    myFunctionAddress = WinApi.VirtualAllocEx(tibiaHandle, IntPtr.Zero, CUInt(code.Length), WinApi.MEM_COMMIT Or WinApi.MEM_RESERVE, WinApi.PAGE_EXECUTE_READWRITE)
    '    If myFunctionAddress IsNot Nothing Then
    '        'effectivelly writing it to memory
    '        If WinApi.WriteProcessMemory(tibiaHandle, myFunctionAddress, code, CUInt(code.Length), nOut) Then
    '            'allocating memory for the arguments
    '            argsAddress = WinApi.VirtualAllocEx(tibiaHandle, IntPtr.Zero, CUInt(4) * argCount, WinApi.MEM_COMMIT Or WinApi.MEM_RESERVE, WinApi.PAGE_EXECUTE_READWRITE)

    '            Return argsAddress IsNot Nothing
    '        Else
    '            Return False

    '        End If
    '    Else
    '        Return False
    '    End If
    'End Function


End Class
