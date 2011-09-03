Public Class CavebotTradeSession

    Private Sub CavebotItemMove_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.SendToBack()
    End Sub

    Private Sub CavebotItemMove_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.Close()
    End Sub


    Private Sub AddBuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBuy.Click
        If FormatItem(BuyId.Text) = 0 Then Exit Sub

        Dim Command As String = "Buy "

        If BuyWithBackPacks.Checked Then
            Command += "WithBps "
        Else
            Command += "WithoutBps "
        End If

        If BuyIgnoreCap.Checked Then
            Command += "CapIgnore "
        Else
            Command += "CapConsider "
        End If

        Command += FormatItem(BuyId.Text) & " "
        Command += CStr(BuyCount.Value)


        BuyId.Text = ""

        ListBox1.Items.Add(Command)
    End Sub

    Private Sub AddSale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddSale.Click
        If FormatItem(SellId.Text) = 0 Then Exit Sub

        Dim Command As String = "Sell "

        If EqSale.Checked Then
            Command += "IncludeEQ "
        Else
            Command += "IgnoreEQ "
        End If

        Command += FormatItem(SellId.Text) & " "
        Command += CStr(SellCount.Value)

        SellId.Text = ""

        ListBox1.Items.Add(Command)
    End Sub

    Private Sub AddTradeSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddTradeSession.Click
        If ListBox1.Items.Count = 0 Then MsgBox("You must add at least 1 sale or purchase.") : Exit Sub
        Dim N As New TreeNode("TradeSession")

        For Each s As String In ListBox1.Items
            N.Nodes.Add(s)
        Next

        CavebotWalker.WaypointTree.SelectedNode = CavebotWalker.WaypointTree.Nodes(CavebotWalker.WaypointTree.Nodes.Add(N))
        CavebotWalker.WaypointTree.SelectedNode.Expand()
        Me.Close()
    End Sub
End Class