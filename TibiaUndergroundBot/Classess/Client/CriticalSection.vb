Public Class CriticalSection
    Private running As Boolean = False
    Public Sub enter()
        While running = True
            Threading.Thread.Sleep(5)
        End While

        running = True
    End Sub
    Public Sub leave()
        running = False
    End Sub
End Class
