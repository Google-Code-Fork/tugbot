Public Class CheckPing
    Dim WithEvents sock As Winsock
    Dim Arrived As Boolean = False
    Dim TimeOut As Integer


    Public Sub New(ByVal ip As String, ByVal port As Integer, ByVal timeout As Integer)
        sock = New Winsock(ip, port)
        Me.TimeOut = timeout
    End Sub

    Public Function Test() As Integer
        Dim Time As Integer = GetTickCount
        Dim Ret As Integer = 0
        sock.Connect()

Redos:
        System.Threading.Thread.Sleep(1)
        Ret = GetTickCount - Time
        If Ret > TimeOut Then GoTo Ends
        If Arrived Then
            Return Ret
        Else
            GoTo ReDos
        End If

Ends:
        Return 0
    End Function


    Private Sub sock_DataArrival(ByVal sender As Winsock, ByVal BytesTotal As Integer) Handles sock.DataArrival
        Arrived = True
    End Sub
End Class
