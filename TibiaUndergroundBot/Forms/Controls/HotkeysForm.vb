Public Class HotkeysForm

    Private Shadows Sub FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Visible = False
        e.Cancel = True
    End Sub

    Private Sub HotkeysForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        Me.Refresh()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()


        HotkeyPanel00.ConfigureHotkey(True, ConstantFromKeyCode(Keys.Subtract), "spydown", HotkeyPressType.Press)
        HotkeyPanel01.ConfigureHotkey(True, ConstantFromKeyCode(Keys.Add), "spyup", HotkeyPressType.Press)
        HotkeyPanel02.ConfigureHotkey(True, ConstantFromKeyCode(Keys.Home), "togglelight", HotkeyPressType.Press)
        HotkeyPanel03.ConfigureHotkey(True, ConstantFromKeyCode(Keys.End), "togglexray", HotkeyPressType.Press)
        HotkeyPanel04.ConfigureHotkey(True, ConstantFromKeyCode(Keys.PageDown), "exivalast", HotkeyPressType.Press)
        HotkeyPanel05.ConfigureHotkey(True, ConstantFromKeyCode(Keys.Pause), "pause", HotkeyPressType.Press)
        HotkeyPanel06.ConfigureHotkey(True, ConstantFromKeyCode(Keys.F12), "displaybot", HotkeyPressType.Press)
    End Sub

    Private Sub HotkeyBut2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class