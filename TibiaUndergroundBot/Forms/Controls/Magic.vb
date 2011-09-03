Public Class Magic

#Region "Form events"
    Private Shadows Sub FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Visible = False
        e.Cancel = True
    End Sub

    Private Sub Magic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        Me.Refresh()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()

        For Each K As String In SpellShortcuts.Keys
            Me.ManaTrainSpell.AutoCompleteCustomSource.Add("{" & K & "}")
        Next
        Me.ManaTrainSpell.AutoCompleteMode = AutoCompleteMode.Suggest
        Me.ManaTrainSpell.AutoCompleteSource = AutoCompleteSource.CustomSource

        RuneMakerType.SelectedIndex = 0

    End Sub
#End Region

#Region "mana train"
    Private Sub EnableManaTrain_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableManaTrain.CheckedChanged
        If FormatSpell(ManaTrainSpell.Text) = "" Or ManaTrainSpell.Text Is Nothing Then EnableManaTrain.Checked = False
        If ParseShort(TrainAtMana.Text) = 0 Or TrainAtMana.Text Is Nothing Then EnableManaTrain.Checked = False

        TrainAtMana.Enabled = Not EnableManaTrain.Checked
        ManaTrainSpell.Enabled = Not EnableManaTrain.Checked
    End Sub

    Private Sub TrainAtMana_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrainAtMana.LostFocus
        If ParseShort(TrainAtMana.Text) <> 0 Then
            TrainAtMana.Text = ParseShort(TrainAtMana.Text)
        Else
            TrainAtMana.Text = ""
        End If
    End Sub
#End Region

    
    Private Sub Magic_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        BoxTimer.Start()
    End Sub

    Private Sub BoxTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoxTimer.Tick
        ManaTrainSpell.Focus()
        Refresh()
        System.Threading.Thread.Sleep(5)
        TrainAtMana.Focus()
        BoxTimer.Stop()
    End Sub

    Private Sub ManaTrainSpell_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


#Region "Make Runes"
    Public BlankR As Integer = BlankRune

    Private Sub RuneMakerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RuneMakerType.SelectedIndexChanged
        If RuneMakerType.SelectedIndex = 1 Then
            BlankR = Spear
        Else
            BlankR = BlankRune
        End If
    End Sub

    Private Sub EnableRuneMaker_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableRuneMaker.CheckedChanged
        If FormatSpell(RuneSpell.Text) = "" Or RuneSpell.Text Is Nothing Then EnableManaTrain.Checked = False
        If ParseShort(RuneMana.Text) = 0 Or RuneMana.Text Is Nothing Then EnableManaTrain.Checked = False

        RuneMana.Enabled = Not EnableRuneMaker.Checked
        RuneSoul.Enabled = Not EnableRuneMaker.Checked
        RuneSpell.Enabled = Not EnableRuneMaker.Checked
        RuneMakerType.Enabled = Not EnableRuneMaker.Checked
    End Sub

    Private Sub RuneMana_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RuneMana.TextChanged
        If ParseShort(RuneMana.Text) <> 0 Then
            RuneMana.Text = ParseShort(RuneMana.Text)
        Else
            RuneMana.Text = ""
        End If
    End Sub

    Private Sub RuneMakeTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RuneMakeTimer.Tick
        If Not EnableRuneMaker.Checked Then Exit Sub
        If TClient.Paused Then Exit Sub
        If TClient.Self.Mana >= ParseInteger(RuneMana.Text) And TClient.Self.Soul >= ParseInteger(RuneSoul.Text) Then
            If Not RuneMakeThread.IsBusy Then RuneMakeThread.RunWorkerAsync()
        End If
    End Sub

    Private Sub RuneMakeThread_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RuneMakeThread.DoWork
Restart:
        Dim Item As ContainerItem = Nothing
        Dim Container As Byte
        Dim ManyLoops As Integer = 0

        For i As Byte = 1 To 16
            If TClient.Containers(i).IsOpen = 1 Then
                For a = 1 To TClient.Containers(i).NumberOfItems
                    Item = TClient.Containers(i).Item(a)
                    If Item Is Nothing Then Continue For

                    If Item.ID = 3147 Then
                        Container = i - 1
                        GoTo Found
                    End If
                Next
                Item = Nothing
            End If
        Next

Found:
        If Item Is Nothing Then Exit Sub
        Dim AmmoID As Integer = TClient.Self.SlotID(Enums.Slots.Ammo)
        Dim AmmoCount As Integer = TClient.Self.SlotCount(Enums.Slots.Ammo)
        Dim HandID As Integer = TClient.Self.SlotID(Enums.Slots.LeftHand)
        Dim HandCount As Integer = TClient.Self.SlotCount(Enums.Slots.LeftHand)
        If AmmoID > 99 And HandID > 99 Then
            TClient.DisplayTextMessage(Client.TextMessageColor.Red, "Please empty your arrow slot, then reactive the rune maker.")
            EnableRuneMaker.Checked = False
            Exit Sub
        Else

            If HandID > 99 Then
                TClient.Hook.MoveItem(HandID, HandCount, ItemLocation.FromSlot(Slots.LeftHand), ItemLocation.FromSlot(Slots.Ammo))
                Threading.Thread.Sleep(800)
            End If

            Item.MoveToSlot(Slots.LeftHand)
            Threading.Thread.Sleep(800)

            HandID = TClient.Self.SlotID(Enums.Slots.LeftHand)
            HandCount = TClient.Self.SlotCount(Enums.Slots.LeftHand)

            Do While HandID < 100 And ManyLoops < 5
                HandID = TClient.Self.SlotID(Enums.Slots.LeftHand)
                HandCount = TClient.Self.SlotCount(Enums.Slots.LeftHand)
                Threading.Thread.Sleep(500)
                ManyLoops += 1
            Loop

            If ManyLoops = 5 Then ManyLoops = 0 : GoTo Restart

            TClient.Self.Say(RuneSpell.Text)
            Threading.Thread.Sleep(1500)

            HandID = TClient.Self.SlotID(Enums.Slots.LeftHand)
            If HandID < 100 Then Exit Sub

            While HandID > 99
                TClient.Hook.MoveItem(HandID, HandCount, ItemLocation.FromSlot(Slots.LeftHand), ItemLocation.FromContainer(Container, 0))
                Threading.Thread.Sleep(1500)
                HandID = TClient.Self.SlotID(Enums.Slots.LeftHand)
                HandCount = TClient.Self.SlotCount(Enums.Slots.LeftHand)
            End While

            Threading.Thread.Sleep(500)

            AmmoID = TClient.Self.SlotID(Enums.Slots.Ammo)
            AmmoCount = TClient.Self.SlotCount(Enums.Slots.Ammo)
            If AmmoID < 100 Then Exit Sub

            AmmoID = TClient.Self.SlotID(Enums.Slots.Ammo)
            While AmmoID > 99
                TClient.Hook.MoveItem(AmmoID, AmmoCount, ItemLocation.FromSlot(Slots.Ammo), ItemLocation.FromSlot(Slots.LeftHand))
                Threading.Thread.Sleep(1500)
                AmmoID = TClient.Self.SlotID(Enums.Slots.Ammo)
                AmmoCount = TClient.Self.SlotCount(Enums.Slots.Ammo)
            End While
        End If

    End Sub

#End Region
End Class