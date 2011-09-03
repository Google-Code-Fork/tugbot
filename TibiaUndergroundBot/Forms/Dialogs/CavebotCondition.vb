Imports System.Windows.Forms

Public Class CavebotCondition
    Private Sub CavebotCondition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TypeCompare.SelectedIndex = 0
        OperatorCompare.SelectedIndex = 0
        Main.SendToBack()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If FalseLabel.Text.Replace(" ", "") = "" Then Exit Sub
        If TrueLabel.Text.Replace(" ", "") = "" Then Exit Sub

        If TypeCompare.Text = "ItemCount.." Then
            Me.Visible = False
            Dim ItemName As String = InputBox("Input the name of an item to count. The name is the one that shows when you get the ""Using X of X <name>"" message")
            If ItemName.Replace(" ", "") = "" Then Me.Close() : Exit Sub
            ItemName = ItemName.Replace(" ", "_")

            Dim res As MsgBoxResult = MsgBox("If you would like the bot to use the item to count it, press yes. Otherwise press no." _
            & vbNewLine & "The bot will automatically count potions/runes as it uses them to heal, restore mana, or attack. Pressing yes is only reccomended for count items such as gold, to see how much has been looted.", MsgBoxStyle.YesNo, "Autocount?")
            If res = MsgBoxResult.Yes Then
                Dim ItemID As Integer = FormatItem(InputBox("Please enter the ItemID of the item to be counted. Item shortcuts are accepted."))
                If ItemID = 0 Then Me.Close() : Exit Sub
                CavebotWalker.WaypointTree.SelectedNode = CavebotWalker.WaypointTree.Nodes.Add("If CountC[" & ItemName & ";" & ItemID & "] " & OperatorCompare.Text & " " & ValueCompare.Value & " """ & TrueLabel.Text & """ else """ & FalseLabel.Text & """")
            Else
                CavebotWalker.WaypointTree.SelectedNode = CavebotWalker.WaypointTree.Nodes.Add("If Count[" & ItemName & "] " & OperatorCompare.Text & " " & ValueCompare.Value & " """ & TrueLabel.Text & """ else """ & FalseLabel.Text & """")
            End If
        Else
            CavebotWalker.WaypointTree.SelectedNode = CavebotWalker.WaypointTree.Nodes.Add("If " & TypeCompare.Text & " " & OperatorCompare.Text & " " & ValueCompare.Value & " """ & TrueLabel.Text & """ else """ & FalseLabel.Text & """")
        End If
            Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub CavebotCondition_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.Close()
    End Sub
End Class
