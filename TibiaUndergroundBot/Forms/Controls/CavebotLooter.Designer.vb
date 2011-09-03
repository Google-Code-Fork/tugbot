<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CavebotLooter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CavebotLooter))
        Me.LootList = New System.Windows.Forms.ListView
        Me.IDClm = New System.Windows.Forms.ColumnHeader
        Me.LocationClm = New System.Windows.Forms.ColumnHeader
        Me.LooterContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddItemContext = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.LootSave = New System.Windows.Forms.ToolStripMenuItem
        Me.LootLoad = New System.Windows.Forms.ToolStripMenuItem
        Me.EnableLooter = New System.Windows.Forms.CheckBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cbListViewCombo = New System.Windows.Forms.ComboBox
        Me.CaveWalkEnable = New System.Windows.Forms.CheckBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LooterContextMenu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LootList
        '
        Me.LootList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LootList.AutoArrange = False
        Me.LootList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDClm, Me.LocationClm})
        Me.LootList.ContextMenuStrip = Me.LooterContextMenu
        Me.LootList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LootList.FullRowSelect = True
        Me.LootList.GridLines = True
        Me.LootList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LootList.Location = New System.Drawing.Point(3, 3)
        Me.LootList.MultiSelect = False
        Me.LootList.Name = "LootList"
        Me.LootList.ShowGroups = False
        Me.LootList.Size = New System.Drawing.Size(220, 135)
        Me.LootList.TabIndex = 44
        Me.LootList.TileSize = New System.Drawing.Size(168, 21)
        Me.ToolTip1.SetToolTip(Me.LootList, resources.GetString("LootList.ToolTip"))
        Me.LootList.UseCompatibleStateImageBehavior = False
        Me.LootList.View = System.Windows.Forms.View.Details
        '
        'IDClm
        '
        Me.IDClm.Text = "Item ID"
        Me.IDClm.Width = 91
        '
        'LocationClm
        '
        Me.LocationClm.Text = "Location"
        Me.LocationClm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.LocationClm.Width = 124
        '
        'LooterContextMenu
        '
        Me.LooterContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddItemContext, Me.ToolStripSeparator2, Me.ClearToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolStripSeparator1, Me.LootSave, Me.LootLoad})
        Me.LooterContextMenu.Name = "LooterContextMenu"
        Me.LooterContextMenu.Size = New System.Drawing.Size(124, 126)
        '
        'AddItemContext
        '
        Me.AddItemContext.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomToolStripMenuItem})
        Me.AddItemContext.Name = "AddItemContext"
        Me.AddItemContext.Size = New System.Drawing.Size(123, 22)
        Me.AddItemContext.Text = "Add Item"
        '
        'CustomToolStripMenuItem
        '
        Me.CustomToolStripMenuItem.Name = "CustomToolStripMenuItem"
        Me.CustomToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.CustomToolStripMenuItem.Text = "Custom"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(120, 6)
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(123, 22)
        Me.ToolStripMenuItem1.Text = "Delete"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(120, 6)
        '
        'LootSave
        '
        Me.LootSave.Name = "LootSave"
        Me.LootSave.Size = New System.Drawing.Size(123, 22)
        Me.LootSave.Text = "Save.."
        '
        'LootLoad
        '
        Me.LootLoad.Name = "LootLoad"
        Me.LootLoad.Size = New System.Drawing.Size(123, 22)
        Me.LootLoad.Text = "Load.."
        '
        'EnableLooter
        '
        Me.EnableLooter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EnableLooter.AutoSize = True
        Me.EnableLooter.Location = New System.Drawing.Point(3, 142)
        Me.EnableLooter.Name = "EnableLooter"
        Me.EnableLooter.Size = New System.Drawing.Size(92, 17)
        Me.EnableLooter.TabIndex = 45
        Me.EnableLooter.Text = "Enable Looter"
        Me.ToolTip1.SetToolTip(Me.EnableLooter, "Enable automatic looting.")
        Me.EnableLooter.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.EnableLooter)
        Me.Panel1.Controls.Add(Me.cbListViewCombo)
        Me.Panel1.Controls.Add(Me.LootList)
        Me.Panel1.Controls.Add(Me.CaveWalkEnable)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(226, 160)
        Me.Panel1.TabIndex = 80
        '
        'cbListViewCombo
        '
        Me.cbListViewCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbListViewCombo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbListViewCombo.FormattingEnabled = True
        Me.cbListViewCombo.ItemHeight = 13
        Me.cbListViewCombo.Items.AddRange(New Object() {"Backpack 1", "Backpack 2", "Backpack 3", "Backpack 4", "Backpack 5", "Backpack 6", "Backpack 7", "Backpack 8", "Backpack 9", "Arrow Slot", "Right Hand", "Left Hand"})
        Me.cbListViewCombo.Location = New System.Drawing.Point(96, 38)
        Me.cbListViewCombo.Name = "cbListViewCombo"
        Me.cbListViewCombo.Size = New System.Drawing.Size(127, 21)
        Me.cbListViewCombo.TabIndex = 81
        Me.cbListViewCombo.Visible = False
        '
        'CaveWalkEnable
        '
        Me.CaveWalkEnable.AutoSize = True
        Me.CaveWalkEnable.Location = New System.Drawing.Point(5, 256)
        Me.CaveWalkEnable.Name = "CaveWalkEnable"
        Me.CaveWalkEnable.Size = New System.Drawing.Size(124, 17)
        Me.CaveWalkEnable.TabIndex = 1
        Me.CaveWalkEnable.Text = "Enable Cave Walker"
        Me.CaveWalkEnable.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 8000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'CavebotLooter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(226, 160)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "CavebotLooter"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TUGBot - Looter"
        Me.LooterContextMenu.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LootList As System.Windows.Forms.ListView
    Friend WithEvents IDClm As System.Windows.Forms.ColumnHeader
    Friend WithEvents LocationClm As System.Windows.Forms.ColumnHeader
    Friend WithEvents EnableLooter As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CaveWalkEnable As System.Windows.Forms.CheckBox
    Friend WithEvents cbListViewCombo As System.Windows.Forms.ComboBox
    Friend WithEvents LooterContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LootSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LootLoad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddItemContext As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CustomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
