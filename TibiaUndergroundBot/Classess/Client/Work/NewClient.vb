Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.ComponentModel

Partial Public Class Client
    Implements IDisposable
    Public Event ClientClosed()
    Public Event ClientOpened()

    Public Sub New(ByVal WindowHandle As IntPtr)
        Me.WindowHandle = WindowHandle
        GetWindowThreadProcessId(Me.WindowHandle, Me.ProcessID)
        Me.Ver = GetWindowVersion(ProcessID)
        Me.p = System.Diagnostics.Process.GetProcessById(Me.ProcessID)
    End Sub

    Public Sub New(ByVal WindowHandle As IntPtr, ByVal processid As Integer)
        Me.WindowHandle = WindowHandle
        Me.ProcessID = processid
        Me.Ver = GetWindowVersion(ProcessID)
        Me.p = System.Diagnostics.Process.GetProcessById(Me.ProcessID)
    End Sub

    Public Sub Attach()
        Me.Ver = GetWindowVersion(ProcessID)

        Me.Map = New Map()

        Me.ClientTimer = New Timer(New TimerCallback(AddressOf CheckClient), Nothing, 0, 200)

        Me.Hook = New TibiaHook(WindowHandle)

        Me.Containers = New Containers(Me)

        'Me.Profile = New PlayerProfile(Me)

        Me.hProcess = OpenProcess(PROCESS_READ_WRITE_QUERY, False, Me.ProcessID)
    End Sub

   

#Region "Dispose"
    Private disposed As Boolean = False
    Private hasraisedclose As Boolean = False
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)

        GC.SuppressFinalize(Me)
    End Sub

    Private Overloads Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposed Then
            If disposing Then
                For i As Byte = 0 To 4
                    Try
                        Me.Hook.Dispose()
                    Catch
                    End Try
                    Try
                        Me.ClientTimer.Dispose()
                    Catch
                    End Try
                    Try
                        Me.Map = Nothing
                        Me.Containers = Nothing
                        Me.Screen = Nothing
                        Me.Hook = Nothing
                    Catch
                    End Try
                Next
            End If

            disposed = True
        End If
    End Sub
#End Region

End Class
