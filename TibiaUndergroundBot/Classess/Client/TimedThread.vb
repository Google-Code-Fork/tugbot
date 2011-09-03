Imports System.Threading
Imports System.ComponentModel
Public Class TimedThread
    Implements IDisposable
    Private ThreadTimer As Timer
    Private WithEvents Bg As New BackgroundWorker
    Private Delay As Integer
    Private Running As Boolean = True
    Private act As Action

    Public Delegate Sub RunThreadDelegate(ByVal a As Action)
    Public RunThread As RunThreadDelegate

    Public Property TickTime() As Integer
        Get
            Return Delay
        End Get
        Set(ByVal value As Integer)
            Delay = value
            ThreadTimer.Change(0, Delay)
        End Set
    End Property

    Private Sub DoWork()
        If Not Running Then Exit Sub
        If Not Bg.IsBusy Then
            Try
                Bg.RunWorkerAsync()
            Catch
            End Try
        End If
    End Sub

    Public ReadOnly Property IsRunning()
        Get
            Return Running
        End Get
    End Property

    Public Sub New(ByVal Ticks As Integer, ByVal callback As RunThreadDelegate, Optional ByVal Run As Boolean = True, Optional ByVal action As Action = Nothing)
        Running = Run
        Bg.WorkerSupportsCancellation = True
        RunThread = callback
        Delay = Ticks
        act = action
        ThreadTimer = New Timer(New TimerCallback(AddressOf DoWork), Nothing, 0, Delay)
    End Sub

    Public Sub Sleep(ByVal Ticks As Integer)
        ThreadTimer.Change(Ticks, Delay)
    End Sub

    Public Sub Start()
        Running = True
    End Sub

    Public Sub Pause()
        Running = False
    End Sub
    Private Sub Bg_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Bg.DoWork
        If RunThread Is Nothing Then ThreadTimer.Dispose() : Pause() : Exit Sub

        RunThread(act)
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
                Pause()
                RunThread = Nothing

                Bg.Dispose()
                Bg = Nothing


                ThreadTimer.Dispose()
                ThreadTimer = Nothing
            End If

            disposed = True
        End If
    End Sub
#End Region
End Class

'Public Class TimedThread
'    Private Running As Boolean
'    Private _Time As Integer
'    Private _Sleep As Integer = 0
'    Public Delegate Sub RunThreadDelegate()

'    Public Property TickTime()
'        Get
'            Return _Time
'        End Get
'        Set(ByVal value)
'            _Time = value
'        End Set
'    End Property

'    Public ReadOnly Property IsRunning()
'        Get
'            Return Running
'        End Get
'    End Property

'    Public Sub Sleep(ByVal Ticks As Integer)
'        _Sleep = Ticks
'    End Sub

'    Public Sub Start()
'        Running = True
'    End Sub

'    Public Sub Pause()
'        Running = False
'    End Sub

'    Sub New(ByVal Ticks As Integer, ByVal action As System.Action, Optional ByVal Run As Boolean = True)
'        _Time = Ticks
'        Running = Run
'        Dim myDelegate As New System.Action(Of System.Action)(AddressOf AddTaskDelay)
'        'myDelegate.DynamicInvoke(action)
'        myDelegate.BeginInvoke(action, Nothing, Nothing)
'    End Sub

'    Private Sub AddTaskDelay(ByVal action As System.Action)
'        If action IsNot Nothing Then
'            While True
'                If Running Then
'                    System.Threading.Thread.Sleep(_Time)
'                    action.Invoke()
'                    System.Threading.Thread.Sleep(_Sleep)
'                    _Sleep = 0
'                End If
'            End While
'        End If
'    End Sub
'End Class
