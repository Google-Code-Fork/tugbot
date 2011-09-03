<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Trainer
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.EnableAdd = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ProtoSettings = New System.Windows.Forms.PropertyGrid
        Me.AddName = New TUGBot.WaterMarkTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RefillId = New TUGBot.WaterMarkTextBox
        Me.UseOther = New System.Windows.Forms.RadioButton
        Me.EnableAmmo = New System.Windows.Forms.CheckBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.AmmoRight = New System.Windows.Forms.RadioButton
        Me.AmmoLeft = New System.Windows.Forms.RadioButton
        Me.UseSpears = New System.Windows.Forms.RadioButton
        Me.UseStones = New System.Windows.Forms.RadioButton
        Me.TrainerProperties = New System.Windows.Forms.PropertyGrid
        Me.TrainList = New System.Windows.Forms.ListBox
        Me.EnableTrainer = New System.Windows.Forms.CheckBox
        Me.AmmoTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TrainTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(378, 408)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.TrainerProperties)
        Me.GroupBox3.Controls.Add(Me.TrainList)
        Me.GroupBox3.Controls.Add(Me.EnableTrainer)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(372, 402)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Trainer"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.EnableAdd)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.ProtoSettings)
        Me.GroupBox2.Controls.Add(Me.AddName)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox2.Location = New System.Drawing.Point(179, 169)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(189, 230)
        Me.GroupBox2.TabIndex = 87
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Auto Add Training Partners"
        '
        'EnableAdd
        '
        Me.EnableAdd.AutoSize = True
        Me.EnableAdd.Location = New System.Drawing.Point(6, 207)
        Me.EnableAdd.Name = "EnableAdd"
        Me.EnableAdd.Size = New System.Drawing.Size(152, 17)
        Me.EnableAdd.TabIndex = 87
        Me.EnableAdd.Text = "Automatically Add Partners"
        Me.EnableAdd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Add with these settings:"
        '
        'ProtoSettings
        '
        Me.ProtoSettings.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ProtoSettings.LineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ProtoSettings.Location = New System.Drawing.Point(6, 58)
        Me.ProtoSettings.Name = "ProtoSettings"
        Me.ProtoSettings.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.ProtoSettings.Size = New System.Drawing.Size(177, 146)
        Me.ProtoSettings.TabIndex = 88
        Me.ProtoSettings.ToolbarVisible = False
        '
        'AddName
        '
        Me.AddName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.AddName.Location = New System.Drawing.Point(6, 19)
        Me.AddName.MaxLength = 5
        Me.AddName.Name = "AddName"
        Me.AddName.Size = New System.Drawing.Size(177, 20)
        Me.AddName.TabIndex = 86
        Me.AddName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.AddName.WaterMarkColor = System.Drawing.Color.Gray
        Me.AddName.WaterMarkText = "Creature Name To Add"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RefillId)
        Me.GroupBox1.Controls.Add(Me.UseOther)
        Me.GroupBox1.Controls.Add(Me.EnableAmmo)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.UseSpears)
        Me.GroupBox1.Controls.Add(Me.UseStones)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox1.Location = New System.Drawing.Point(6, 285)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(167, 114)
        Me.GroupBox1.TabIndex = 83
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ammo Refiller"
        '
        'RefillId
        '
        Me.RefillId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.RefillId.Location = New System.Drawing.Point(69, 68)
        Me.RefillId.MaxLength = 5
        Me.RefillId.Name = "RefillId"
        Me.RefillId.Size = New System.Drawing.Size(93, 20)
        Me.RefillId.TabIndex = 86
        Me.RefillId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RefillId.WaterMarkColor = System.Drawing.Color.Gray
        Me.RefillId.WaterMarkText = "Item [ID/shortcut]"
        '
        'UseOther
        '
        Me.UseOther.AutoSize = True
        Me.UseOther.Location = New System.Drawing.Point(6, 68)
        Me.UseOther.Name = "UseOther"
        Me.UseOther.Size = New System.Drawing.Size(57, 17)
        Me.UseOther.TabIndex = 85
        Me.UseOther.Text = "Other: "
        Me.UseOther.UseVisualStyleBackColor = True
        '
        'EnableAmmo
        '
        Me.EnableAmmo.AutoSize = True
        Me.EnableAmmo.Location = New System.Drawing.Point(6, 94)
        Me.EnableAmmo.Name = "EnableAmmo"
        Me.EnableAmmo.Size = New System.Drawing.Size(126, 17)
        Me.EnableAmmo.TabIndex = 82
        Me.EnableAmmo.Text = "Enable Ammo Refiller"
        Me.EnableAmmo.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.AmmoRight)
        Me.Panel2.Controls.Add(Me.AmmoLeft)
        Me.Panel2.Location = New System.Drawing.Point(69, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(93, 43)
        Me.Panel2.TabIndex = 84
        '
        'AmmoRight
        '
        Me.AmmoRight.AutoSize = True
        Me.AmmoRight.Location = New System.Drawing.Point(3, 26)
        Me.AmmoRight.Name = "AmmoRight"
        Me.AmmoRight.Size = New System.Drawing.Size(79, 17)
        Me.AmmoRight.TabIndex = 86
        Me.AmmoRight.Text = "Right Hand"
        Me.AmmoRight.UseVisualStyleBackColor = True
        '
        'AmmoLeft
        '
        Me.AmmoLeft.AutoSize = True
        Me.AmmoLeft.Checked = True
        Me.AmmoLeft.Location = New System.Drawing.Point(3, 3)
        Me.AmmoLeft.Name = "AmmoLeft"
        Me.AmmoLeft.Size = New System.Drawing.Size(72, 17)
        Me.AmmoLeft.TabIndex = 85
        Me.AmmoLeft.TabStop = True
        Me.AmmoLeft.Text = "Left Hand"
        Me.AmmoLeft.UseVisualStyleBackColor = True
        '
        'UseSpears
        '
        Me.UseSpears.AutoSize = True
        Me.UseSpears.Location = New System.Drawing.Point(6, 42)
        Me.UseSpears.Name = "UseSpears"
        Me.UseSpears.Size = New System.Drawing.Size(58, 17)
        Me.UseSpears.TabIndex = 83
        Me.UseSpears.Text = "Spears"
        Me.UseSpears.UseVisualStyleBackColor = True
        '
        'UseStones
        '
        Me.UseStones.AutoSize = True
        Me.UseStones.Checked = True
        Me.UseStones.Location = New System.Drawing.Point(6, 19)
        Me.UseStones.Name = "UseStones"
        Me.UseStones.Size = New System.Drawing.Size(58, 17)
        Me.UseStones.TabIndex = 82
        Me.UseStones.TabStop = True
        Me.UseStones.Text = "Stones"
        Me.UseStones.UseVisualStyleBackColor = True
        '
        'TrainerProperties
        '
        Me.TrainerProperties.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TrainerProperties.LineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.TrainerProperties.Location = New System.Drawing.Point(179, 19)
        Me.TrainerProperties.Name = "TrainerProperties"
        Me.TrainerProperties.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.TrainerProperties.Size = New System.Drawing.Size(189, 146)
        Me.TrainerProperties.TabIndex = 82
        Me.TrainerProperties.ToolbarVisible = False
        '
        'TrainList
        '
        Me.TrainList.FormattingEnabled = True
        Me.TrainList.Location = New System.Drawing.Point(6, 19)
        Me.TrainList.Name = "TrainList"
        Me.TrainList.Size = New System.Drawing.Size(167, 238)
        Me.TrainList.TabIndex = 81
        '
        'EnableTrainer
        '
        Me.EnableTrainer.AutoSize = True
        Me.EnableTrainer.Location = New System.Drawing.Point(6, 263)
        Me.EnableTrainer.Name = "EnableTrainer"
        Me.EnableTrainer.Size = New System.Drawing.Size(95, 17)
        Me.EnableTrainer.TabIndex = 2
        Me.EnableTrainer.Text = "Enable Trainer"
        Me.EnableTrainer.UseVisualStyleBackColor = True
        '
        'AmmoTimer
        '
        Me.AmmoTimer.Enabled = True
        Me.AmmoTimer.Interval = 1000
        '
        'TrainTimer
        '
        Me.TrainTimer.Enabled = True
        Me.TrainTimer.Interval = 500
        '
        'Trainer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 408)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Trainer"
        Me.Text = "TUGBot - Trainer"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TrainList As System.Windows.Forms.ListBox
    Friend WithEvents EnableTrainer As System.Windows.Forms.CheckBox
    Friend WithEvents UseStones As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents AmmoRight As System.Windows.Forms.RadioButton
    Friend WithEvents AmmoLeft As System.Windows.Forms.RadioButton
    Friend WithEvents UseSpears As System.Windows.Forms.RadioButton
    Friend WithEvents UseOther As System.Windows.Forms.RadioButton
    Friend WithEvents EnableAmmo As System.Windows.Forms.CheckBox
    Friend WithEvents RefillId As TUGBot.WaterMarkTextBox
    Friend WithEvents TrainerProperties As System.Windows.Forms.PropertyGrid
    Friend WithEvents AmmoTimer As System.Windows.Forms.Timer
    Friend WithEvents TrainTimer As System.Windows.Forms.Timer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents AddName As TUGBot.WaterMarkTextBox
    Friend WithEvents EnableAdd As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProtoSettings As System.Windows.Forms.PropertyGrid
End Class
