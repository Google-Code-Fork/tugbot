Public Class CommandRunner
    Public CommandString As String
    Public BindName As String
    Public Threads As Dictionary(Of TimedThread, String)

    Public Sub New()

    End Sub

    Public Sub DisableCommand()
        If Threads Is Nothing Then Exit Sub
        For Each K As TimedThread In Threads.Keys
            RemoveCommandText(Threads(K))
            K.Pause()
            K = Nothing
        Next
        Threads = Nothing
    End Sub

    Public Sub InvokeComand(ByVal BindName As String)
        Me.BindName = BindName
        DoCommand()
    End Sub

    Public Sub DoCommand()
        If Threads IsNot Nothing Then DisableCommand() : Exit Sub
        Threads = ExecuteCommand(Me, CommandString)
    End Sub
End Class
