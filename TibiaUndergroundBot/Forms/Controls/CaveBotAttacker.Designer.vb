<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CaveBotAttacker
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
        Me.GroupBox18 = New System.Windows.Forms.GroupBox
        Me.EnableAttacker = New System.Windows.Forms.CheckBox
        Me.EnableAdvanced = New System.Windows.Forms.RadioButton
        Me.EnableAll = New System.Windows.Forms.RadioButton
        Me.EnableAggresive = New System.Windows.Forms.RadioButton
        Me.EnableFollow = New System.Windows.Forms.CheckBox
        Me.AttackerContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewCreature = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearCreatures = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteCreature = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.SaveAttacks = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadAttacks = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Timeout = New System.Windows.Forms.NumericUpDown
        Me.EnableTimeout = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.AttackerProperties = New System.Windows.Forms.PropertyGrid
        Me.TargetList = New System.Windows.Forms.ListBox
        Me.TargettingTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox18.SuspendLayout()
        Me.AttackerContextMenu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Timeout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.EnableAttacker)
        Me.GroupBox18.Controls.Add(Me.EnableAdvanced)
        Me.GroupBox18.Controls.Add(Me.EnableAll)
        Me.GroupBox18.Controls.Add(Me.EnableAggresive)
        Me.GroupBox18.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox18.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(162, 109)
        Me.GroupBox18.TabIndex = 50
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "Attack Style"
        '
        'EnableAttacker
        '
        Me.EnableAttacker.AutoSize = True
        Me.EnableAttacker.Location = New System.Drawing.Point(8, 86)
        Me.EnableAttacker.Name = "EnableAttacker"
        Me.EnableAttacker.Size = New System.Drawing.Size(102, 17)
        Me.EnableAttacker.TabIndex = 2
        Me.EnableAttacker.Text = "Enable Attacker"
        Me.ToolTip1.SetToolTip(Me.EnableAttacker, "Enable targeting.")
        Me.EnableAttacker.UseVisualStyleBackColor = True
        '
        'EnableAdvanced
        '
        Me.EnableAdvanced.AutoSize = True
        Me.EnableAdvanced.Location = New System.Drawing.Point(8, 40)
        Me.EnableAdvanced.Name = "EnableAdvanced"
        Me.EnableAdvanced.Size = New System.Drawing.Size(122, 17)
        Me.EnableAdvanced.TabIndex = 10
        Me.EnableAdvanced.Text = "Advanced Targeting"
        Me.ToolTip1.SetToolTip(Me.EnableAdvanced, "Use the Advanced Targeting Configuration to determine attacking style.")
        Me.EnableAdvanced.UseVisualStyleBackColor = True
        '
        'EnableAll
        '
        Me.EnableAll.AutoSize = True
        Me.EnableAll.Checked = True
        Me.EnableAll.Location = New System.Drawing.Point(8, 17)
        Me.EnableAll.Name = "EnableAll"
        Me.EnableAll.Size = New System.Drawing.Size(118, 17)
        Me.EnableAll.TabIndex = 9
        Me.EnableAll.TabStop = True
        Me.EnableAll.Text = "Target All Creatures"
        Me.ToolTip1.SetToolTip(Me.EnableAll, "Target all visible creatures.")
        Me.EnableAll.UseVisualStyleBackColor = True
        '
        'EnableAggresive
        '
        Me.EnableAggresive.AutoSize = True
        Me.EnableAggresive.BackColor = System.Drawing.Color.Transparent
        Me.EnableAggresive.Location = New System.Drawing.Point(8, 62)
        Me.EnableAggresive.Name = "EnableAggresive"
        Me.EnableAggresive.Size = New System.Drawing.Size(154, 17)
        Me.EnableAggresive.TabIndex = 8
        Me.EnableAggresive.TabStop = True
        Me.EnableAggresive.Text = "Target Aggresive Creatures"
        Me.ToolTip1.SetToolTip(Me.EnableAggresive, "Only target aggresive creatures.")
        Me.EnableAggresive.UseVisualStyleBackColor = False
        '
        'EnableFollow
        '
        Me.EnableFollow.AutoSize = True
        Me.EnableFollow.Checked = True
        Me.EnableFollow.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EnableFollow.Location = New System.Drawing.Point(6, 42)
        Me.EnableFollow.Name = "EnableFollow"
        Me.EnableFollow.Size = New System.Drawing.Size(81, 17)
        Me.EnableFollow.TabIndex = 7
        Me.EnableFollow.Text = "Auto Follow"
        Me.ToolTip1.SetToolTip(Me.EnableFollow, "Automatically enable Tibia's auto follow feature while attacking.")
        Me.EnableFollow.UseVisualStyleBackColor = True
        '
        'AttackerContextMenu
        '
        Me.AttackerContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewCreature, Me.ClearCreatures, Me.DeleteCreature, Me.ToolStripSeparator1, Me.SaveAttacks, Me.LoadAttacks})
        Me.AttackerContextMenu.Name = "AttackerContextMenu"
        Me.AttackerContextMenu.Size = New System.Drawing.Size(155, 120)
        '
        'NewCreature
        '
        Me.NewCreature.Name = "NewCreature"
        Me.NewCreature.Size = New System.Drawing.Size(154, 22)
        Me.NewCreature.Text = "<New>"
        '
        'ClearCreatures
        '
        Me.ClearCreatures.Name = "ClearCreatures"
        Me.ClearCreatures.Size = New System.Drawing.Size(154, 22)
        Me.ClearCreatures.Text = "Clear List"
        '
        'DeleteCreature
        '
        Me.DeleteCreature.Name = "DeleteCreature"
        Me.DeleteCreature.Size = New System.Drawing.Size(154, 22)
        Me.DeleteCreature.Text = "Delete Selected"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(151, 6)
        '
        'SaveAttacks
        '
        Me.SaveAttacks.Name = "SaveAttacks"
        Me.SaveAttacks.Size = New System.Drawing.Size(154, 22)
        Me.SaveAttacks.Text = "Save.."
        '
        'LoadAttacks
        '
        Me.LoadAttacks.Name = "LoadAttacks"
        Me.LoadAttacks.Size = New System.Drawing.Size(154, 22)
        Me.LoadAttacks.Text = "Load.."
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox18)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(574, 311)
        Me.Panel1.TabIndex = 55
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Timeout)
        Me.GroupBox2.Controls.Add(Me.EnableTimeout)
        Me.GroupBox2.Controls.Add(Me.EnableFollow)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox2.Location = New System.Drawing.Point(3, 241)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(162, 65)
        Me.GroupBox2.TabIndex = 51
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Attack Options"
        '
        'Timeout
        '
        Me.Timeout.Location = New System.Drawing.Point(113, 19)
        Me.Timeout.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.Timeout.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Timeout.Name = "Timeout"
        Me.Timeout.Size = New System.Drawing.Size(43, 20)
        Me.Timeout.TabIndex = 54
        Me.Timeout.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'EnableTimeout
        '
        Me.EnableTimeout.AutoSize = True
        Me.EnableTimeout.Checked = True
        Me.EnableTimeout.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EnableTimeout.Location = New System.Drawing.Point(6, 19)
        Me.EnableTimeout.Name = "EnableTimeout"
        Me.EnableTimeout.Size = New System.Drawing.Size(101, 17)
        Me.EnableTimeout.TabIndex = 7
        Me.EnableTimeout.Text = "Attack Timeout:"
        Me.ToolTip1.SetToolTip(Me.EnableTimeout, "Allow the attacker to stop targeting a creature if its health has not changed sig" & _
                "nificantly in the selected amount of seconds.")
        Me.EnableTimeout.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AttackerProperties)
        Me.GroupBox1.Controls.Add(Me.TargetList)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox1.Location = New System.Drawing.Point(171, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(393, 303)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Advanced Targeting Configuration"
        '
        'AttackerProperties
        '
        Me.AttackerProperties.BackColor = System.Drawing.Color.WhiteSmoke
        Me.AttackerProperties.LineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.AttackerProperties.Location = New System.Drawing.Point(141, 19)
        Me.AttackerProperties.Name = "AttackerProperties"
        Me.AttackerProperties.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.AttackerProperties.Size = New System.Drawing.Size(246, 277)
        Me.AttackerProperties.TabIndex = 13
        Me.AttackerProperties.ToolbarVisible = False
        '
        'TargetList
        '
        Me.TargetList.ContextMenuStrip = Me.AttackerContextMenu
        Me.TargetList.FormattingEnabled = True
        Me.TargetList.Location = New System.Drawing.Point(6, 19)
        Me.TargetList.Name = "TargetList"
        Me.TargetList.Size = New System.Drawing.Size(129, 277)
        Me.TargetList.TabIndex = 0
        '
        'TargettingTimer
        '
        Me.TargettingTimer.Enabled = True
        Me.TargettingTimer.Interval = 500
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 8000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'CaveBotAttacker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(574, 311)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CaveBotAttacker"
        Me.ShowInTaskbar = False
        Me.Text = "TUGBot - Attacker"
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.AttackerContextMenu.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Timeout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents EnableAttacker As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents EnableAggresive As System.Windows.Forms.RadioButton
    Friend WithEvents EnableFollow As System.Windows.Forms.CheckBox
    Friend WithEvents EnableAdvanced As System.Windows.Forms.RadioButton
    Friend WithEvents EnableAll As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TargettingTimer As System.Windows.Forms.Timer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Timeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents EnableTimeout As System.Windows.Forms.CheckBox
    Friend WithEvents AttackerContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewCreature As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearCreatures As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteCreature As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveAttacks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadAttacks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TargetList As System.Windows.Forms.ListBox
    Friend WithEvents AttackerProperties As System.Windows.Forms.PropertyGrid
End Class
