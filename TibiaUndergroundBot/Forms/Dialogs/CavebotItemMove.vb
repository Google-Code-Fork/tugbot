Public Class CavebotItemMove

    Private Sub CavebotItemMove_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cont.SelectedIndex = 0
        Main.SendToBack()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub CavebotItemMove_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.Close()
    End Sub

    Private Sub Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add.Click
        If FormatItem(DropId.Text) = 0 Then MsgBox("Invalid item ID or shortcut.") : Exit Sub

        CavebotWalker.WaypointTree.SelectedNode = CavebotWalker.WaypointTree.Nodes.Add(CavebotWalker.MoveAction & " " & Cont.SelectedIndex + 1 & " " & DropId.Text)
        Me.Close()
    End Sub
End Class