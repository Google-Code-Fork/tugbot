Imports System.ComponentModel

Public Class HotkeyPanel
    Private _KeyNum As Integer = 0

    Public Property KeyNum() As Integer
        Get
            Return _KeyNum
        End Get
        Set(ByVal value As Integer)
            _KeyNum = value
        End Set
    End Property

    Public Property HotkeyCommand() As String
        Get
            Return Command.Text
        End Get
        Set(ByVal value As String)
            Command.Text = value
        End Set
    End Property

    Public Sub ConfigureHotkey(ByVal Enabled As Boolean, ByVal KeyArgs As String, ByVal Command As String, ByVal PressType As HotkeyPressType)
        Button_KeyDown(Nothing, KeyArgsFromConstant(KeyArgs))

        HotkeyCommand = Command

        Select Case PressType
            Case HotkeyPressType.Down
                Down.Checked = True
            Case HotkeyPressType.Up
                Up.Checked = True
            Case HotkeyPressType.UpDown
                UpDown.Checked = True
            Case HotkeyPressType.Press
                Press.Checked = True
        End Select

        Enable.Checked = Enabled
    End Sub

    Private Sub ChangeKeyType() 'Handles Press.CheckedChanged, Up.CheckedChanged, Down.CheckedChanged, UpDown.CheckedChanged
        If Hotkey.Hotkey(_KeyNum) Is Nothing Then Exit Sub
        If Down.Checked Then
            Hotkey.Hotkey(_KeyNum).PressType = HotkeyPressType.Down
        ElseIf Up.Checked Then
            Hotkey.Hotkey(_KeyNum).PressType = HotkeyPressType.Up
        ElseIf UpDown.Checked Then
            Hotkey.Hotkey(_KeyNum).PressType = HotkeyPressType.UpDown
        ElseIf Press.Checked Then
            Hotkey.Hotkey(_KeyNum).PressType = HotkeyPressType.Press
        End If
    End Sub

    Private Sub Button_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button.KeyDown
        Dim Ret As String = ParseHotkeySelection(e)
        If Ret <> "" Then
            Button.Text = Ret
            Hotkey.Hotkey(_KeyNum).KeyCode = e.KeyCode
            Hotkey.Hotkey(_KeyNum).Ctrl = e.Control
        Else
            'Button.Text = "NILL"
        End If
    End Sub

    Private Sub Command_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command.TextChanged
        If Hotkey.Hotkey(_KeyNum) Is Nothing Then Exit Sub
        Hotkey.Hotkey(_KeyNum).Command.CommandString = Command.Text
    End Sub

    Private Sub Enable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Enable.CheckedChanged
        If Enable.Checked And (Button.Text = "NILL" Or Command.Text = "") Then Enable.Checked = False : Exit Sub

        Hotkey.Hotkey(_KeyNum).Enabled = Enable.Checked

        Command.Enabled = Not Enable.Checked
        Button.Enabled = Not Enable.Checked

        Press.Enabled = Not Enable.Checked
        Up.Enabled = Not Enable.Checked
        Down.Enabled = Not Enable.Checked
        UpDown.Enabled = Not Enable.Checked
    End Sub

    Private Sub Press_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Press.CheckedChanged
        ChangeKeyType()
    End Sub

    Private Sub HotkeyPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
