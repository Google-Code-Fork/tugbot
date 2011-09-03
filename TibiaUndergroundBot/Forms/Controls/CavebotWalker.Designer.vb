<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CavebotWalker
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Label ""Start""")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CavebotWalker))
        Me.CaveWalkEnable = New System.Windows.Forms.CheckBox
        Me.WaypointTree = New System.Windows.Forms.TreeView
        Me.WaypointContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.WaypointClear = New System.Windows.Forms.ToolStripMenuItem
        Me.WaypointDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WaypointAddGround = New System.Windows.Forms.ToolStripMenuItem
        Me.WaypointAddNode = New System.Windows.Forms.ToolStripMenuItem
        Me.StairsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WaypointAddUpstairs = New System.Windows.Forms.ToolStripMenuItem
        Me.WaypointAddDownstairs = New System.Windows.Forms.ToolStripMenuItem
        Me.Ramps = New System.Windows.Forms.ToolStripMenuItem
        Me.UpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NorthUp = New System.Windows.Forms.ToolStripMenuItem
        Me.SouthUp = New System.Windows.Forms.ToolStripMenuItem
        Me.EastUp = New System.Windows.Forms.ToolStripMenuItem
        Me.WestUp = New System.Windows.Forms.ToolStripMenuItem
        Me.DownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WestDown = New System.Windows.Forms.ToolStripMenuItem
        Me.EastDown = New System.Windows.Forms.ToolStripMenuItem
        Me.SouthDown = New System.Windows.Forms.ToolStripMenuItem
        Me.NorthDown = New System.Windows.Forms.ToolStripMenuItem
        Me.FloorChangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WaypointAddRope = New System.Windows.Forms.ToolStripMenuItem
        Me.WaypointAddHole = New System.Windows.Forms.ToolStripMenuItem
        Me.WaypointAddLadder = New System.Windows.Forms.ToolStripMenuItem
        Me.WaypointAddSewer = New System.Windows.Forms.ToolStripMenuItem
        Me.ActionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WaypointAddSay = New System.Windows.Forms.ToolStripMenuItem
        Me.YellToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WhisperToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WaypointAddNPCSay = New System.Windows.Forms.ToolStripMenuItem
        Me.DelayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.TradeSessionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.MoveItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToGroundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToDepotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FindAndOpenDepotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.DoorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.KeyDoorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.OtherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WaypointAddLabel = New System.Windows.Forms.ToolStripMenuItem
        Me.WaypointAddGoto = New System.Windows.Forms.ToolStripMenuItem
        Me.WaypointAddCondition = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.WaypointSave = New System.Windows.Forms.ToolStripMenuItem
        Me.WaypointLoad = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.UseElvenhairRope = New System.Windows.Forms.CheckBox
        Me.UseLightShovel = New System.Windows.Forms.CheckBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.WaypointContextMenuStrip.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CaveWalkEnable
        '
        Me.CaveWalkEnable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CaveWalkEnable.AutoSize = True
        Me.CaveWalkEnable.Location = New System.Drawing.Point(5, 284)
        Me.CaveWalkEnable.Name = "CaveWalkEnable"
        Me.CaveWalkEnable.Size = New System.Drawing.Size(124, 17)
        Me.CaveWalkEnable.TabIndex = 1
        Me.CaveWalkEnable.Text = "Enable Cave Walker"
        Me.ToolTip1.SetToolTip(Me.CaveWalkEnable, "Enable automatic walking.")
        Me.CaveWalkEnable.UseVisualStyleBackColor = True
        '
        'WaypointTree
        '
        Me.WaypointTree.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WaypointTree.ContextMenuStrip = Me.WaypointContextMenuStrip
        Me.WaypointTree.HideSelection = False
        Me.WaypointTree.Indent = 15
        Me.WaypointTree.Location = New System.Drawing.Point(5, 5)
        Me.WaypointTree.Name = "WaypointTree"
        TreeNode1.Name = "Node0"
        TreeNode1.Text = "Label ""Start"""
        Me.WaypointTree.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.WaypointTree.ShowPlusMinus = False
        Me.WaypointTree.Size = New System.Drawing.Size(234, 246)
        Me.WaypointTree.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.WaypointTree, resources.GetString("WaypointTree.ToolTip"))
        '
        'WaypointContextMenuStrip
        '
        Me.WaypointContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WaypointClear, Me.WaypointDelete, Me.ToolStripSeparator2, Me.ToolStripMenuItem1, Me.ToolStripSeparator1, Me.WaypointSave, Me.WaypointLoad})
        Me.WaypointContextMenuStrip.Name = "WaypointContextMenuStrip"
        Me.WaypointContextMenuStrip.Size = New System.Drawing.Size(108, 126)
        '
        'WaypointClear
        '
        Me.WaypointClear.Name = "WaypointClear"
        Me.WaypointClear.Size = New System.Drawing.Size(107, 22)
        Me.WaypointClear.Text = "Clear"
        '
        'WaypointDelete
        '
        Me.WaypointDelete.Name = "WaypointDelete"
        Me.WaypointDelete.Size = New System.Drawing.Size(107, 22)
        Me.WaypointDelete.Text = "Delete"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(104, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GroundToolStripMenuItem, Me.StairsToolStripMenuItem, Me.Ramps, Me.FloorChangeToolStripMenuItem, Me.ActionToolStripMenuItem, Me.OtherToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(107, 22)
        Me.ToolStripMenuItem1.Text = "Add"
        '
        'GroundToolStripMenuItem
        '
        Me.GroundToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WaypointAddGround, Me.WaypointAddNode})
        Me.GroundToolStripMenuItem.Name = "GroundToolStripMenuItem"
        Me.GroundToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.GroundToolStripMenuItem.Text = "Ground"
        '
        'WaypointAddGround
        '
        Me.WaypointAddGround.Name = "WaypointAddGround"
        Me.WaypointAddGround.Size = New System.Drawing.Size(169, 22)
        Me.WaypointAddGround.Text = "New Ground"
        '
        'WaypointAddNode
        '
        Me.WaypointAddNode.Name = "WaypointAddNode"
        Me.WaypointAddNode.Size = New System.Drawing.Size(169, 22)
        Me.WaypointAddNode.Text = "Node On Selected"
        '
        'StairsToolStripMenuItem
        '
        Me.StairsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WaypointAddUpstairs, Me.WaypointAddDownstairs})
        Me.StairsToolStripMenuItem.Name = "StairsToolStripMenuItem"
        Me.StairsToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.StairsToolStripMenuItem.Text = "Stairs"
        '
        'WaypointAddUpstairs
        '
        Me.WaypointAddUpstairs.Name = "WaypointAddUpstairs"
        Me.WaypointAddUpstairs.Size = New System.Drawing.Size(132, 22)
        Me.WaypointAddUpstairs.Text = "Upstairs"
        '
        'WaypointAddDownstairs
        '
        Me.WaypointAddDownstairs.Name = "WaypointAddDownstairs"
        Me.WaypointAddDownstairs.Size = New System.Drawing.Size(132, 22)
        Me.WaypointAddDownstairs.Text = "Downstairs"
        '
        'Ramps
        '
        Me.Ramps.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpToolStripMenuItem, Me.DownToolStripMenuItem})
        Me.Ramps.Name = "Ramps"
        Me.Ramps.Size = New System.Drawing.Size(145, 22)
        Me.Ramps.Text = "Ramps"
        '
        'UpToolStripMenuItem
        '
        Me.UpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NorthUp, Me.SouthUp, Me.EastUp, Me.WestUp})
        Me.UpToolStripMenuItem.Name = "UpToolStripMenuItem"
        Me.UpToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.UpToolStripMenuItem.Text = "Up"
        '
        'NorthUp
        '
        Me.NorthUp.Name = "NorthUp"
        Me.NorthUp.Size = New System.Drawing.Size(105, 22)
        Me.NorthUp.Text = "North"
        '
        'SouthUp
        '
        Me.SouthUp.Name = "SouthUp"
        Me.SouthUp.Size = New System.Drawing.Size(105, 22)
        Me.SouthUp.Text = "South"
        '
        'EastUp
        '
        Me.EastUp.Name = "EastUp"
        Me.EastUp.Size = New System.Drawing.Size(105, 22)
        Me.EastUp.Text = "East"
        '
        'WestUp
        '
        Me.WestUp.Name = "WestUp"
        Me.WestUp.Size = New System.Drawing.Size(105, 22)
        Me.WestUp.Text = "West"
        '
        'DownToolStripMenuItem
        '
        Me.DownToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WestDown, Me.EastDown, Me.SouthDown, Me.NorthDown})
        Me.DownToolStripMenuItem.Name = "DownToolStripMenuItem"
        Me.DownToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.DownToolStripMenuItem.Text = "Down"
        '
        'WestDown
        '
        Me.WestDown.Name = "WestDown"
        Me.WestDown.Size = New System.Drawing.Size(105, 22)
        Me.WestDown.Text = "West"
        '
        'EastDown
        '
        Me.EastDown.Name = "EastDown"
        Me.EastDown.Size = New System.Drawing.Size(105, 22)
        Me.EastDown.Text = "East"
        '
        'SouthDown
        '
        Me.SouthDown.Name = "SouthDown"
        Me.SouthDown.Size = New System.Drawing.Size(105, 22)
        Me.SouthDown.Text = "South"
        '
        'NorthDown
        '
        Me.NorthDown.Name = "NorthDown"
        Me.NorthDown.Size = New System.Drawing.Size(105, 22)
        Me.NorthDown.Text = "North"
        '
        'FloorChangeToolStripMenuItem
        '
        Me.FloorChangeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WaypointAddRope, Me.WaypointAddHole, Me.WaypointAddLadder, Me.WaypointAddSewer})
        Me.FloorChangeToolStripMenuItem.Name = "FloorChangeToolStripMenuItem"
        Me.FloorChangeToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.FloorChangeToolStripMenuItem.Text = "Floor Change"
        '
        'WaypointAddRope
        '
        Me.WaypointAddRope.Name = "WaypointAddRope"
        Me.WaypointAddRope.Size = New System.Drawing.Size(110, 22)
        Me.WaypointAddRope.Text = "Rope"
        '
        'WaypointAddHole
        '
        Me.WaypointAddHole.Name = "WaypointAddHole"
        Me.WaypointAddHole.Size = New System.Drawing.Size(110, 22)
        Me.WaypointAddHole.Text = "Hole"
        '
        'WaypointAddLadder
        '
        Me.WaypointAddLadder.Name = "WaypointAddLadder"
        Me.WaypointAddLadder.Size = New System.Drawing.Size(110, 22)
        Me.WaypointAddLadder.Text = "Ladder"
        '
        'WaypointAddSewer
        '
        Me.WaypointAddSewer.Name = "WaypointAddSewer"
        Me.WaypointAddSewer.Size = New System.Drawing.Size(110, 22)
        Me.WaypointAddSewer.Text = "Sewer"
        '
        'ActionToolStripMenuItem
        '
        Me.ActionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WaypointAddSay, Me.YellToolStripMenuItem, Me.WhisperToolStripMenuItem, Me.WaypointAddNPCSay, Me.DelayToolStripMenuItem, Me.ToolStripSeparator4, Me.TradeSessionToolStripMenuItem, Me.ToolStripSeparator3, Me.MoveItemToolStripMenuItem, Me.FindAndOpenDepotToolStripMenuItem, Me.ToolStripSeparator5, Me.DoorToolStripMenuItem, Me.KeyDoorToolStripMenuItem, Me.ToolStripSeparator6, Me.ToolStripMenuItem2})
        Me.ActionToolStripMenuItem.Name = "ActionToolStripMenuItem"
        Me.ActionToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.ActionToolStripMenuItem.Text = "Action"
        '
        'WaypointAddSay
        '
        Me.WaypointAddSay.Name = "WaypointAddSay"
        Me.WaypointAddSay.Size = New System.Drawing.Size(189, 22)
        Me.WaypointAddSay.Text = "Say"
        '
        'YellToolStripMenuItem
        '
        Me.YellToolStripMenuItem.Enabled = False
        Me.YellToolStripMenuItem.Name = "YellToolStripMenuItem"
        Me.YellToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.YellToolStripMenuItem.Text = "Yell"
        '
        'WhisperToolStripMenuItem
        '
        Me.WhisperToolStripMenuItem.Enabled = False
        Me.WhisperToolStripMenuItem.Name = "WhisperToolStripMenuItem"
        Me.WhisperToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.WhisperToolStripMenuItem.Text = "Whisper"
        '
        'WaypointAddNPCSay
        '
        Me.WaypointAddNPCSay.Name = "WaypointAddNPCSay"
        Me.WaypointAddNPCSay.Size = New System.Drawing.Size(189, 22)
        Me.WaypointAddNPCSay.Text = "NPCSay"
        '
        'DelayToolStripMenuItem
        '
        Me.DelayToolStripMenuItem.Name = "DelayToolStripMenuItem"
        Me.DelayToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.DelayToolStripMenuItem.Text = "Delay"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(186, 6)
        '
        'TradeSessionToolStripMenuItem
        '
        Me.TradeSessionToolStripMenuItem.Name = "TradeSessionToolStripMenuItem"
        Me.TradeSessionToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.TradeSessionToolStripMenuItem.Text = "Trade Session"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(186, 6)
        '
        'MoveItemToolStripMenuItem
        '
        Me.MoveItemToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToGroundToolStripMenuItem, Me.ToDepotToolStripMenuItem})
        Me.MoveItemToolStripMenuItem.Name = "MoveItemToolStripMenuItem"
        Me.MoveItemToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.MoveItemToolStripMenuItem.Text = "Move Item"
        '
        'ToGroundToolStripMenuItem
        '
        Me.ToGroundToolStripMenuItem.Name = "ToGroundToolStripMenuItem"
        Me.ToGroundToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.ToGroundToolStripMenuItem.Text = "To Ground"
        '
        'ToDepotToolStripMenuItem
        '
        Me.ToDepotToolStripMenuItem.Name = "ToDepotToolStripMenuItem"
        Me.ToDepotToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.ToDepotToolStripMenuItem.Text = "To Depot"
        '
        'FindAndOpenDepotToolStripMenuItem
        '
        Me.FindAndOpenDepotToolStripMenuItem.Name = "FindAndOpenDepotToolStripMenuItem"
        Me.FindAndOpenDepotToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.FindAndOpenDepotToolStripMenuItem.Text = "Find And Open Depot"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(186, 6)
        '
        'DoorToolStripMenuItem
        '
        Me.DoorToolStripMenuItem.Name = "DoorToolStripMenuItem"
        Me.DoorToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.DoorToolStripMenuItem.Text = "Door"
        '
        'KeyDoorToolStripMenuItem
        '
        Me.KeyDoorToolStripMenuItem.Enabled = False
        Me.KeyDoorToolStripMenuItem.Name = "KeyDoorToolStripMenuItem"
        Me.KeyDoorToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.KeyDoorToolStripMenuItem.Text = "Key Door"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(186, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(189, 22)
        Me.ToolStripMenuItem2.Text = "Command"
        '
        'OtherToolStripMenuItem
        '
        Me.OtherToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WaypointAddLabel, Me.WaypointAddGoto, Me.WaypointAddCondition})
        Me.OtherToolStripMenuItem.Name = "OtherToolStripMenuItem"
        Me.OtherToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.OtherToolStripMenuItem.Text = "Other"
        '
        'WaypointAddLabel
        '
        Me.WaypointAddLabel.Name = "WaypointAddLabel"
        Me.WaypointAddLabel.Size = New System.Drawing.Size(144, 22)
        Me.WaypointAddLabel.Text = "Label"
        '
        'WaypointAddGoto
        '
        Me.WaypointAddGoto.Name = "WaypointAddGoto"
        Me.WaypointAddGoto.Size = New System.Drawing.Size(144, 22)
        Me.WaypointAddGoto.Text = "Goto <label>"
        '
        'WaypointAddCondition
        '
        Me.WaypointAddCondition.Name = "WaypointAddCondition"
        Me.WaypointAddCondition.Size = New System.Drawing.Size(144, 22)
        Me.WaypointAddCondition.Text = "Conditional"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(104, 6)
        '
        'WaypointSave
        '
        Me.WaypointSave.Name = "WaypointSave"
        Me.WaypointSave.Size = New System.Drawing.Size(107, 22)
        Me.WaypointSave.Text = "Save.."
        '
        'WaypointLoad
        '
        Me.WaypointLoad.Name = "WaypointLoad"
        Me.WaypointLoad.Size = New System.Drawing.Size(107, 22)
        Me.WaypointLoad.Text = "Load.."
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UseElvenhairRope)
        Me.Panel1.Controls.Add(Me.UseLightShovel)
        Me.Panel1.Controls.Add(Me.CaveWalkEnable)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(244, 307)
        Me.Panel1.TabIndex = 79
        '
        'UseElvenhairRope
        '
        Me.UseElvenhairRope.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.UseElvenhairRope.AutoSize = True
        Me.UseElvenhairRope.Location = New System.Drawing.Point(118, 257)
        Me.UseElvenhairRope.Name = "UseElvenhairRope"
        Me.UseElvenhairRope.Size = New System.Drawing.Size(121, 17)
        Me.UseElvenhairRope.TabIndex = 3
        Me.UseElvenhairRope.Text = "Use Elvenhair Rope"
        Me.UseElvenhairRope.UseVisualStyleBackColor = True
        '
        'UseLightShovel
        '
        Me.UseLightShovel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.UseLightShovel.AutoSize = True
        Me.UseLightShovel.Location = New System.Drawing.Point(5, 257)
        Me.UseLightShovel.Name = "UseLightShovel"
        Me.UseLightShovel.Size = New System.Drawing.Size(107, 17)
        Me.UseLightShovel.TabIndex = 2
        Me.UseLightShovel.Text = "Use Light Shovel"
        Me.UseLightShovel.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 8000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'CavebotWalker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(244, 307)
        Me.Controls.Add(Me.WaypointTree)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CavebotWalker"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TUGBot - Walker"
        Me.WaypointContextMenuStrip.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CaveWalkEnable As System.Windows.Forms.CheckBox
    Friend WithEvents WaypointTree As System.Windows.Forms.TreeView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents WaypointContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents WaypointClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaypointDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroundToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaypointAddGround As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaypointAddNode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StairsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaypointAddUpstairs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaypointAddDownstairs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FloorChangeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaypointAddRope As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaypointAddHole As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaypointAddLadder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaypointAddSay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents YellToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WhisperToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OtherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaypointAddLabel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaypointAddGoto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaypointAddCondition As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaypointSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaypointLoad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Ramps As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NorthUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SouthUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EastUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WestUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NorthDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SouthDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EastDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WestDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaypointAddNPCSay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DelayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaypointAddSewer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents FindAndOpenDepotToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToGroundToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToDepotToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TradeSessionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UseElvenhairRope As System.Windows.Forms.CheckBox
    Friend WithEvents UseLightShovel As System.Windows.Forms.CheckBox
    Friend WithEvents DoorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeyDoorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
End Class
