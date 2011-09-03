Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO.Pipes

Public Class Pipes
    Implements IDisposable
#Region "Variables"
    Private pipe As NamedPipeServerStream
    Private buffer As Byte() = New Byte(20000) {}
    Private name As String = String.Empty
#End Region

#Region "Events"
    Public Event Connected()
    Public Event ReceivedData(ByVal packet As Byte())

    Public Event ListenError()

    Public Event Disconnected()
#End Region

    ''' <summary>
    ''' Creates a Pipe to interact with an injected DLL or another program.
    ''' </summary>
    Public Sub New(ByVal name As String)
        Try
            pipe = New NamedPipeServerStream(name, PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous)
            pipe.BeginWaitForConnection(New AsyncCallback(AddressOf BeginWaitForConnection), Nothing)
        Catch ex As Exception
            RaiseEvent ListenError()
        End Try
    End Sub

    ''' <summary>
    ''' Returns the status of the pipe connection.
    ''' </summary>
    Public ReadOnly Property isConnected() As Boolean
        Get
            Return pipe.IsConnected
        End Get
    End Property


    Private Sub BeginWaitForConnection(ByVal ar As IAsyncResult)
        If pipe Is Nothing Then Exit Sub
        pipe.EndWaitForConnection(ar)
        If pipe.IsConnected Then
            ' Call OnConnected asynchronously
            RaiseEvent Connected()
            pipe.BeginRead(buffer, 0, buffer.Length, New AsyncCallback(AddressOf BeginRead), Nothing)
        End If
    End Sub

    Private Sub BeginRead(ByVal ar As IAsyncResult)
        If pipe Is Nothing Then Exit Sub
        pipe.EndRead(ar)
        ' Call OnReceive asynchronously
        Try
            RaiseEvent ReceivedData(buffer)
ReTry:
            pipe.BeginRead(buffer, 0, buffer.Length, New AsyncCallback(AddressOf BeginRead), Nothing)
        Catch ex As Exception
            GoTo ReTry
        End Try
    End Sub

    ''' <summary>
    ''' Sends packet to the destination.
    ''' </summary>
    Public Sub Send(ByVal packet As Byte())
        Try
            'If HooksInjected And TClient.Status <> 8 Then Throw New Exception("shit shouldnt be sending data")
            pipe.Write(packet, 0, packet.Length)
        Catch ex As Exception
            RaiseEvent Disconnected()
        End Try
    End Sub


#Region "Dispose"
    Private disposed As Boolean = False
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Overloads Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposed Then
            If disposing Then
                ReDim buffer(0)
                pipe.Disconnect()
                pipe.Dispose()
                pipe = Nothing

            End If

            disposed = True
        End If
    End Sub
#End Region
End Class