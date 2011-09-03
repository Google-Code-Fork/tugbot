Imports System.Runtime.InteropServices

Public Module WinApi
    Public Const TOKEN_ADJUST_PRIVILEGES As Short = &H20S
    Public Const TOKEN_QUERY As Short = &H8S
    Public Const SE_PRIVILEGE_ENABLED As Short = &H2S

#Region "Privilege tokens"
    Public Structure LUID
        Dim UsedPart As Integer
        Dim IgnoredForNowHigh32BitPart As Integer
    End Structure
    Public Structure TOKEN_PRIVILEGES
        Dim PrivilegeCount As Integer
        Dim TheLuid As LUID
        Dim Attributes As Integer
    End Structure
    Public Declare Function LookupPrivilegeValue Lib "advapi32.dll" Alias "LookupPrivilegeValueA" ( _
    ByVal lpSystemName As String, _
    ByVal lpName As String, _
    ByRef lpLuid As LUID) As Integer

    Public Declare Function AdjustTokenPrivileges Lib "advapi32.dll" (ByVal TokenHandle As IntPtr, _
    ByVal DisableAllPrivileges As Boolean, _
    ByRef NewState As TOKEN_PRIVILEGES, _
    ByVal BufferLength As Integer, _
    ByRef PreviousState As TOKEN_PRIVILEGES, _
    ByRef ReturnLength As IntPtr) As Boolean

    Public Declare Function OpenProcessToken Lib "advapi32.dll" ( _
    ByVal ProcessHandle As IntPtr, _
    ByVal DesiredAccess As Integer, _
    ByRef TokenHandle As IntPtr _
) As Boolean
#End Region

#Region "MISC"
    <DllImport("kernel32.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True)> _
    Public Function GetProcAddress(ByVal hModule As IntPtr, ByVal procName As String) As IntPtr
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)> _
    Public Function GetModuleHandle(ByVal lpModuleName As String) As IntPtr
    End Function
    <DllImport("kernel32.dll")> _
    Public Function CreateRemoteThread(ByVal hProcess As IntPtr, ByVal lpThreadAttributes As IntPtr, ByVal dwStackSize As Integer, ByVal lpStartAddress As IntPtr, ByVal lpParameter As IntPtr, ByVal dwCreationFlags As UInteger, _
    ByVal lpThreadId As IntPtr) As IntPtr
    End Function

    Public Declare Function OpenProcess Lib "kernel32.dll" (ByVal dwDesiredAccess As UInteger, ByVal bInheritHandle As Integer, ByVal dwProcessId As UInteger) As IntPtr
    Public Declare Function CloseHandle Lib "kernel32.dll" (ByVal hHandle As IntPtr) As Boolean
    Public Declare Function ShellExecuteA Lib "shell32.dll" ( _
        ByVal hWnd As IntPtr, _
        ByVal lpOperation As String, _
        ByVal lpFile As String, _
        ByVal lpParameters As String, _
        ByVal lpDirectory As String, _
        ByVal nShowCmd As Integer) As IntPtr
    Public Declare Function VirtualAllocEx Lib "kernel32" (ByVal hProcess As Int32, ByVal lpAddress As Int32, ByRef dwSize As Int32, ByVal flAllocationType As Int32, ByVal flProtect As Int32) As Int32
    Public Declare Function VirtualFreeEx Lib "kernel32" (ByVal hProcess As Int32, ByVal lpAddress As Int32, ByVal dwSize As Int32, ByVal dwFreeType As Int32) As Boolean
    Public Declare Function GetProcAddress Lib "kernel32" (ByVal hModule As Int32, <MarshalAs(UnmanagedType.LPStr)> ByVal lpProcName As String) As Int32
    Public Declare Function GetTickCount Lib "kernel32" Alias "GetTickCount" () As Integer


    Declare Function GetCurrentProcess Lib "kernel32.dll" () As IntPtr
    Declare Function WaitForSingleObject Lib "kernel32" (ByVal hHandle As IntPtr, ByVal dwMilliseconds As Integer) As Integer
#End Region

#Region "Memory"
    Public Declare Function WriteProcessMemory Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpBaseAddress As Int32, ByVal lpBuffer() As Byte, ByVal nSize As Int32, ByVal lpNumberOfBytesWritten As Int32) As Long

    <DllImport("kernel32.dll")> _
    Public Function ReadProcessMemory(ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, <[In](), Out()> ByVal buffer As Byte(), ByVal size As UInt32, ByRef lpNumberOfBytesRead As IntPtr) As Integer
    End Function
#End Region

#Region "Window"
    <DllImport("User32")> _
    Public Function ShowWindow(ByVal hwnd As IntPtr, ByVal nCmdShow As Integer) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Function PostMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    Public Declare Function GetDesktopWindow Lib "user32" () As IntPtr
    Public Declare Function GetWindowRect Lib "user32" (ByVal hwnd As IntPtr, ByRef rectangle As Rect) As Integer
    Public Declare Function GetForegroundWindow Lib "user32" () As IntPtr
    Public Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As IntPtr) As Boolean
    Public Declare Function GetWindowThreadProcessId Lib "user32" (ByVal hwnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer
    Public Declare Function SetWindowText Lib "user32" Alias "SetWindowTextA" (ByVal hwnd As IntPtr, ByVal lpString As System.Text.StringBuilder) As Integer
    Public Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Public Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" (ByVal parentHandle As IntPtr, _
                  ByVal childAfter As IntPtr, _
                  ByVal lclassName As String, _
                  ByVal windowTitle As String) As IntPtr

    <DllImport("user32.dll")> _
    Public Function IsIconic(ByVal hWnd As IntPtr) As Boolean
    End Function

    Public Declare Function GetWindowText Lib "user32" _
    Alias "GetWindowTextA" _
    (ByVal hwnd As Integer, _
    ByVal lpString As String, _
    ByVal cch As Integer) As Integer

    Public Declare Function GetWindowTextLength Lib "user32" Alias "GetWindowTextLengthA" (ByVal hwnd As IntPtr) As Integer
    Public Declare Function FlashWindow Lib "user32" (ByVal hwnd As IntPtr, ByVal bInvert As Integer) As Integer

    <DllImport("kernel32.dll", SetLastError:=True)> <PreserveSig()> _
    Public Function GetModuleFileName(<[In]()> ByVal hModule As IntPtr, <Out()> ByVal lpFilename As System.Text.StringBuilder, <[In]()> <MarshalAs(UnmanagedType.U4)> ByVal nSize As Integer) As UInteger
    End Function
#End Region

#Region "Hook"
    <DllImport("kernel32")> _
    Public Function GetCurrentThreadId() As IntPtr
    End Function



    Public Delegate Function KeyboardProcDelegate(ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer

    Public Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal idHook As Integer, ByVal lpfn As KeyboardProcDelegate, ByVal hmod As Integer, ByVal dwThreadId As Integer) As Integer

    Public Declare Function CallNextHookEx Lib "user32" (ByVal hHook As Integer, ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As KBDLLHOOKSTRUCT) As Integer

    Public Declare Function UnhookWindowsHookEx Lib "user32" (ByVal hHook As Integer) As Integer

    Public Declare Function ScreenToClient Lib "user32" (ByVal hWnd As IntPtr, ByRef lpPoint As Point) As Integer
#End Region

#Region ".INI File"
    ' API functions
    Public Declare Ansi Function GetPrivateProfileString _
    Lib "kernel32.dll" Alias "GetPrivateProfileStringA" _
    (ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, ByVal lpDefault As String, _
    ByVal lpReturnedString As System.Text.StringBuilder, _
    ByVal nSize As Integer, ByVal lpFileName As String) _
    As Integer

    Public Declare Ansi Function WritePrivateProfileString _
    Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
    (ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, ByVal lpString As String, _
    ByVal lpFileName As String) As Integer

    Public Declare Ansi Function GetPrivateProfileInt _
    Lib "kernel32.dll" Alias "GetPrivateProfileIntA" _
    (ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, ByVal nDefault As Integer, _
    ByVal lpFileName As String) As Integer

    Public Declare Ansi Function FlushPrivateProfileString _
    Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
    (ByVal lpApplicationName As Integer, _
    ByVal lpKeyName As Integer, ByVal lpString As Integer, _
    ByVal lpFileName As String) As Integer
#End Region

End Module
