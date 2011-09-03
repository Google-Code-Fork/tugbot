Public Class HotkeyStruct
    Public Ctrl As Boolean
    Public KeyCode As Keys
    Public Command As New CommandRunner
    Private _enabled As Boolean
    Public PressType As HotkeyPressType = HotkeyPressType.Press

    Public Property Enabled() As Boolean
        Get
            Return _enabled
        End Get
        Set(ByVal value As Boolean)
            _enabled = value
            If Not _enabled Then
                TClient.Hook.RemoveHotkey(KeyCode)
                Command.DisableCommand()
            Else
                TClient.Hook.AddHotkey(KeyCode)
            End If
        End Set
    End Property

    Public Sub InvokeCommand()
        Command.InvokeComand(ParseHotkeySelection(Me.Ctrl, Me.KeyCode))
    End Sub
End Class

Public Class CaveCommandStruct
    Public Command As New CommandRunner
    Private _enabled As Boolean
    Private Name As String

    Public Sub New(ByVal name As String)
        Me.Name = name
    End Sub


    Public Property Enabled() As Boolean
        Get
            Return _enabled
        End Get
        Set(ByVal value As Boolean)
            _enabled = value
            If Not _enabled Then
                Command.DisableCommand()
            Else
            End If
        End Set
    End Property

    Public Sub InvokeCommand()
        Command.InvokeComand(Name)
    End Sub
End Class
