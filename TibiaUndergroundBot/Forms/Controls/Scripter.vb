Public Class Scripter
    Public LuaScripts As New List(Of LuaScript)
    Public ScriptCount As Short
    Public ScriptFile As String

    Private Shadows Sub FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Visible = False
        e.Cancel = True
    End Sub


#Region "Scripter"

#Region "Running, Stopping, Viewing Script"
    Private Sub ScripterHeader_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ScripterHeader.ColumnClick
        If e.Column = 2 Then
            ' RunScript(Scint.Text)
        End If
        If e.Column = 1 Then
            ScriptLoadMenu.Show(Me, MousePosition - Me.Location)
        End If
    End Sub

    Private Sub ViewCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewCode.Click
        Dim text As String = String.Empty

        'For Each l As LuaScript In Me.LuaScripts
        '    If l.ID = CShort(Split(Split(RunningScripts.Text, "(")(1), ")")(0)) Then
        '        text = l.Code
        '    End If
        'Next

        'If (Scint.Text <> text And Scint.Text <> "") Then
        'Select Case MsgBox("Would you like to save the current script first?", MsgBoxStyle.YesNoCancel)
        'Case MsgBoxResult.Yes
        'Call SaveScript_Click(text, EventArgs.Empty)
        'Scint.Text = text
        'Case MsgBoxResult.No
        'Scint.Text = text
        'End Select
        'End If
    End Sub

    Private Sub StopScriptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopScriptToolStripMenuItem.Click
        Try
            'For Each l As LuaScript In Me.LuaScripts
            '    If l.ID = CShort(Split(Split(RunningScripts.Text, "(")(1), ")")(0)) Then
            '        l.KillScript()
            '    End If
            'Next
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "Fancy shit for the columns on the scripter"
    Private Sub ScripterHeader_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles ScripterHeader.ColumnWidthChanged
        If e.ColumnIndex = 0 Then
            If ScripterHeader.Columns(0).Width > 45 Then
                ScripterHeader.Columns(0).Width = 45
                Exit Sub
            End If
        End If

        If e.ColumnIndex = 1 Then
            If ScripterHeader.Columns(1).Width <> 331 - ScripterHeader.Columns(0).Width Then
                ScripterHeader.Columns(1).Width = 331 - ScripterHeader.Columns(0).Width
            End If
        End If
    End Sub

    Private Sub ScripterHeader_ColumnWidthChanging(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles ScripterHeader.ColumnWidthChanging
        If e.ColumnIndex = 0 Then
            If e.NewWidth > 45 Then
                e.Cancel = True
                ScripterHeader.Columns(0).Width = 45
                Exit Sub
            End If
            'Scint.Margins(0).Width = e.NewWidth + 1
            ScripterHeader.Columns(1).Width = 331 - e.NewWidth
        End If
    End Sub
#End Region

#Region "Other Buttons"
    Private Sub ErrorList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ErrorList.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ErrorClear.Enabled = True
            ErrorCopy.Enabled = True
            If ErrorList.Items.Count = 0 Then ErrorClear.Enabled = False
            If ErrorList.SelectedIndex = -1 Then ErrorCopy.Enabled = False
            ErrorMenu.Show(ErrorList, e.Location)
        End If
    End Sub
    Private Sub ErrorClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ErrorClear.Click
        ErrorList.Items.Clear()
    End Sub
    Private Sub ErrorCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ErrorCopy.Click
        Clipboard.SetText(ErrorList.Text)
    End Sub
    Private Sub ScriptStop_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ScriptStop.Opening
        StopScriptToolStripMenuItem.Enabled = True
        If RunningScripts.SelectedIndex = -1 Then
            StopScriptToolStripMenuItem.Enabled = False
        End If
    End Sub
#End Region

#Region "Saving and loading"
    Private Sub SaveScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveScript.Click
        Main.SaveFile.Title = "Save Script"
        Main.SaveFile.Filter = "LUA Script Files (*.LUA)|*.LUA|All files (*.*)|*.*"
        Main.SaveFile.InitialDirectory = Application.StartupPath & "\" & "Scripts"
        Main.SaveFile.FileName = ""
        Main.SaveFile.ShowDialog(Me)
        If Main.SaveFile.FileName <> "" Then
            'TextSave(Main.SaveFile.FileName, Scint.Text)
            Me.ScriptFile = Main.SaveFile.FileName
        End If

        Try
            'Scint.Text = sender
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadScript.Click
        Main.LoadFile.Title = "Load Script"
        Main.LoadFile.Filter = "LUA Script Files (*.LUA)|*.LUA|All files (*.*)|*.*"
        Main.LoadFile.InitialDirectory = Application.StartupPath & "\" & "Scripts"
        Main.LoadFile.FileName = ""
        Main.LoadFile.ShowDialog(Me)
        If Main.LoadFile.FileName <> "" Then
            'Scint.Text = TextLoad(Main.LoadFile.FileName)
            Me.ScriptFile = Main.LoadFile.FileName
        End If
    End Sub
#End Region

#End Region

#Region "Run, Finalize, Handle Errors"
    Public Sub RunScript(ByVal Script As String)
        Dim s() As String = Split(ScriptFile, "\")

        Me.RunningScripts.Items.Add("(" & ScriptCount & ") " & s(UBound(s)))

        'Dim L As New LuaScript(Script, ScriptCount, s(UBound(s)))
        'L.ErrorOccured = New LuaScript.ErrorFunc(AddressOf HandleScriptErrors)
        'L.Finished = New LuaScript.FinishedFunc(AddressOf FinalizeScript)

        'LuaScripts.Add(L)

        ScriptCount += 1
    End Sub


    Public Sub HandleScriptErrors(ByVal id As Integer, ByVal er As String, ByVal Script As String)
        For Each l As LuaScript In LuaScripts
            'If l.ID = id Then
            'l.KillScript()
            'LuaScripts.Remove(l)
            'End If
        Next

        Try
            For Each i As String In Me.RunningScripts.Items
                If CInt(Split(Split(i, "(")(1), ")")(0)) = id Then
                    Me.RunningScripts.Items.RemoveAt(Me.RunningScripts.FindString(i))
                    Me.ErrorList.Items.Add("(" & id & ") " & Script & ": " & er)
                    Exit Sub
                End If
            Next
        Catch ex As Exception
            ErrorList.Items.Add("(" & id & ") " & Script & ": Unknown Error Occured")
        End Try
    End Sub

    Public Sub FinalizeScript(ByVal id As Integer)
        For Each l As LuaScript In LuaScripts
            'If l.ID = id Then
            '    l.KillScript()
            '    LuaScripts.Remove(l)
            'End If
        Next

        Try
            For Each i As String In Me.RunningScripts.Items
                If CInt(Split(Split(i, "(")(1), ")")(0)) = id Then
                    Me.RunningScripts.Items.RemoveAt(Me.RunningScripts.FindString(i))
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
#End Region


    Public Sub CreatureSpeak(ByVal Name As String, ByVal level As Integer, ByVal text As String)
        For Each L As LuaScript In LuaScripts
            'L.CreatureSayEvent(Name, text)
        Next
    End Sub

    Private Sub Scripter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        Me.Refresh()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()
        AddHandler TClient.CreatureDefaultSpeech, AddressOf CreatureSpeak
    End Sub

    Private Sub ErrorList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ErrorList.SelectedIndexChanged

    End Sub
End Class