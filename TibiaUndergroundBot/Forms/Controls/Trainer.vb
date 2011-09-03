Public Class Trainer
    Private TPCount As Integer = 1
    Private PrototypePartner As New TrainingPartner("", 0, 0)

    Private Shadows Sub Trainer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Visible = False
        e.Cancel = True
    End Sub

    Private Sub Trainer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        Me.Refresh()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()

        AddHandler TClient.AddedPartner, AddressOf AddedPartner

        ProtoSettings.SelectedObject = PrototypePartner
    End Sub


#Region "Training properties window and list box"
    Private Delegate Sub UpdateShitBitch()
    Private Sub AddedPartner(ByVal ID As UInt32)
        For Each P As TrainingPartner In TrainList.Items
            If P.ID = ID Then
                TClient.ShowStatusMessage("TUGBot -> This creature is already marked as a training partner.", 50)
                Exit Sub
            End If
        Next

        TClient.Battlelist.Cache()
        Dim Pos As Integer = TClient.Battlelist.PosByID(ID)

        TrainList.Items.Add(New TrainingPartner(TClient.Battlelist.Name(Pos), ID, TPCount))
        TPCount += 1
        Me.Invoke(New UpdateShitBitch(AddressOf War.UpdateMarks))
    End Sub

    Private Sub TrainList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrainList.SelectedIndexChanged
        TrainList.DisplayMember = "DisplayName"
        TrainList.Refresh()
        If TrainList.SelectedItem IsNot Nothing Then
            TrainerProperties.SelectedObject = TrainList.SelectedItem
        End If
    End Sub

    Private Sub TrainerProperties_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles TrainerProperties.PropertyValueChanged
        If TrainList.SelectedIndex = -1 Then TrainerProperties.SelectedObject = Nothing : Exit Sub
        TrainList.Items(TrainList.SelectedIndex) = CType(TrainerProperties.SelectedObject, TrainingPartner)
        TrainList.DisplayMember = "DisplayName"
        TrainList.Refresh()
    End Sub
#End Region

#Region "Reload ammo"
    Private Sub EnableAmmo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableAmmo.CheckedChanged
        If UseOther.Checked AndAlso FormatItem(RefillId.Text) = 0 Then EnableAmmo.Checked = False : Exit Sub

        UseSpears.Enabled = Not EnableAmmo.Checked
        UseStones.Enabled = Not EnableAmmo.Checked
        UseOther.Enabled = Not EnableAmmo.Checked
        RefillId.Enabled = Not EnableAmmo.Checked
        AmmoLeft.Enabled = Not EnableAmmo.Checked
        AmmoRight.Enabled = Not EnableAmmo.Checked
    End Sub

    Private Sub AmmoTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AmmoTimer.Tick
        If EnableAmmo.Checked = False Then Exit Sub
        Dim AmmoID As Short

        If UseStones.Checked Then
            AmmoID = SmallStone
        ElseIf UseSpears.Checked Then
            AmmoID = Spear
        Else
            AmmoID = FormatItem(RefillId.Text)
        End If

        If AmmoID = 0 Then EnableAmmo.Checked = False : Exit Sub

        Dim AmmoItem As ContainerItem = FindAmmo(AmmoID)

        If AmmoItem IsNot Nothing Then
            Dim Hand As Slots

            If AmmoLeft.Checked Then
                Hand = Slots.LeftHand
            Else
                Hand = Slots.RightHand
            End If

            If TClient.Self.SlotCount(Hand) < 100 Then
                If TClient.Self.SlotID(Hand) = AmmoID Then
                    AmmoItem.MoveToSlot(Hand)
                End If
            End If
        End If
    End Sub

    Private Function FindAmmo(ByVal ID As Short) As ContainerItem
        Dim Item As ContainerItem
        Dim ItemCount As Integer = 8
        For i = 1 To 16
            If TClient.Containers(i).IsOpen Then
                For a = 1 To TClient.Containers(i).NumberOfItems
                    Item = TClient.Containers(i).Item(a)
                    If Item Is Nothing Then Continue For
                    If Item.ID = ID Then
                        Return Item
                    End If
                Next
            End If
        Next
        Return Nothing
    End Function
#End Region

#Region "Training"
    Private Sub EnableTrainer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableTrainer.CheckedChanged
        If TrainList.Items.Count = 0 Then EnableTrainer.Checked = False

        TrainList.Enabled = Not EnableTrainer.Checked
        TrainerProperties.Enabled = Not EnableTrainer.Checked
    End Sub

    Private Sub TrainTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrainTimer.Tick
        If EnableAdd.Checked Then
            TClient.Battlelist.Cache()
            For i = 1 To TClient.Battlelist.Length
                If TClient.Battlelist.Name(i).ToLower = AddName.Text.ToLower Then
                    For Each P As TrainingPartner In TrainList.Items
                        If P.ID = TClient.Battlelist.ID(i) Then
                            'Already a partner
                            GoTo Skip
                        End If
                    Next

                    'Add it
                    Dim NewPart As New TrainingPartner(TClient.Battlelist.Name(i), TClient.Battlelist.ID(i), TPCount)
                    NewPart.StartHealth = CType(ProtoSettings.SelectedObject, TrainingPartner).StartHealth
                    NewPart.StopHealth = CType(ProtoSettings.SelectedObject, TrainingPartner).StopHealth
                    NewPart.Kill = CType(ProtoSettings.SelectedObject, TrainingPartner).Kill
                    ' NewPart.FightMode = CType(ProtoSettings.SelectedObject, TrainingPartner).FightMode
                    TrainList.Items.Add(NewPart)

                    TPCount += 1
                    Me.Invoke(New UpdateShitBitch(AddressOf War.UpdateMarks))

Skip:
                End If
            Next
        End If


        If Not EnableTrainer.Checked Then Exit Sub
        Train()
    End Sub

    Public Sub Train()
        TClient.Battlelist.Cache()
        If Not TClient.Self.HasTarget Then
            'No target, lets find one nigga.
            AttackPartner()
        Else
            'We are attacking something. Lets see if its time to switch
            For Each p As TrainingPartner In TrainList.Items
                If p.ID = TClient.Self.Target Then

                    Dim TargetHealth As Byte = HealthById(TClient.Self.Target)
                    If TargetHealth <= p.StopHealth Then
                        'lets try and switch
                        If Not AttackPartner() Then
                            'Nothing to attack right now
                            If Not p.Kill Then
                                'We cannot kill this fucker so stop attacking
                                TClient.Hook.StopActions()
                                'Now try and kill something
                                KillPartner()
                            End If
                        End If
                    End If

                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Function AttackPartner() As Boolean
        Dim TempHp As Byte = 0
        Dim HighestHp As Byte = 0
        Dim StrongestPartner As TrainingPartner = Nothing

        For Each p As TrainingPartner In TrainList.Items
            If p.ID = TClient.Self.Target Then Continue For
            TempHp = HealthById(p.ID)
            If TempHp > HighestHp AndAlso TempHp >= p.StartHealth AndAlso IsVisibleByID(p.ID) Then
                StrongestPartner = p
                HighestHp = TempHp
            End If
        Next

        If StrongestPartner IsNot Nothing Then
            TClient.Self.Attack(StrongestPartner.ID)
            Return True
        End If

        Return False
    End Function


    Private Sub KillPartner()
        For Each p As TrainingPartner In TrainList.Items
            If p.Kill Then
                TClient.Self.Attack(p.ID)
                Exit Sub
            End If
        Next
    End Sub

    Private Function HealthById(ByVal id As UInt32) As Byte
        Dim p As Byte = TClient.Battlelist.PosByID(id)
        Return TClient.Battlelist.Health(p)
    End Function

    Private Function IsVisibleByID(ByVal id As UInt32) As Boolean
        Dim p As Byte = TClient.Battlelist.PosByID(id)
        Return TClient.Battlelist.IsVisible(p)
    End Function
#End Region

    Private Sub EnableAdd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableAdd.CheckedChanged
        If AddName.Text = "" AndAlso EnableAdd.Checked Then EnableAdd.Checked = False : Exit Sub

        AddName.Enabled = Not EnableAdd.Checked
        ProtoSettings.Enabled = Not EnableAdd.Checked
    End Sub
End Class