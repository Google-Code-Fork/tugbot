<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Magic
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
        Me.GroupBox13 = New System.Windows.Forms.GroupBox
        Me.ManaTrainSpell = New TUGBot.WaterMarkTextBox
        Me.EnableManaTrain = New System.Windows.Forms.CheckBox
        Me.TrainAtMana = New TUGBot.WaterMarkTextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RuneSoul = New TUGBot.WaterMarkTextBox
        Me.RuneMakerType = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.RuneSpell = New TUGBot.WaterMarkTextBox
        Me.EnableRuneMaker = New System.Windows.Forms.CheckBox
        Me.RuneMana = New TUGBot.WaterMarkTextBox
        Me.BoxTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RuneMakeThread = New System.ComponentModel.BackgroundWorker
        Me.RuneMakeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox13.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.ManaTrainSpell)
        Me.GroupBox13.Controls.Add(Me.EnableManaTrain)
        Me.GroupBox13.Controls.Add(Me.TrainAtMana)
        Me.GroupBox13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox13.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(304, 42)
        Me.GroupBox13.TabIndex = 23
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Mana Training"
        '
        'ManaTrainSpell
        '
        Me.ManaTrainSpell.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ManaTrainSpell.Location = New System.Drawing.Point(70, 16)
        Me.ManaTrainSpell.MaxLength = 30
        Me.ManaTrainSpell.Name = "ManaTrainSpell"
        Me.ManaTrainSpell.Size = New System.Drawing.Size(170, 20)
        Me.ManaTrainSpell.TabIndex = 4
        Me.ManaTrainSpell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.ManaTrainSpell, "Mana at which to cast the specified training spell.")
        Me.ManaTrainSpell.WaterMarkColor = System.Drawing.Color.Gray
        Me.ManaTrainSpell.WaterMarkText = "Spell/Shortcut"
        '
        'EnableManaTrain
        '
        Me.EnableManaTrain.AutoSize = True
        Me.EnableManaTrain.BackColor = System.Drawing.Color.Transparent
        Me.EnableManaTrain.Location = New System.Drawing.Point(246, 18)
        Me.EnableManaTrain.Name = "EnableManaTrain"
        Me.EnableManaTrain.Size = New System.Drawing.Size(59, 17)
        Me.EnableManaTrain.TabIndex = 3
        Me.EnableManaTrain.Text = "Enable"
        Me.ToolTip1.SetToolTip(Me.EnableManaTrain, "Enable Mana Training.")
        Me.EnableManaTrain.UseVisualStyleBackColor = False
        '
        'TrainAtMana
        '
        Me.TrainAtMana.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TrainAtMana.Location = New System.Drawing.Point(6, 16)
        Me.TrainAtMana.MaxLength = 5
        Me.TrainAtMana.Name = "TrainAtMana"
        Me.TrainAtMana.Size = New System.Drawing.Size(58, 20)
        Me.TrainAtMana.TabIndex = 1
        Me.TrainAtMana.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TrainAtMana, "Mana at which to cast the specified training spell.")
        Me.TrainAtMana.WaterMarkColor = System.Drawing.Color.Gray
        Me.TrainAtMana.WaterMarkText = "Mana"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox13)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(311, 121)
        Me.Panel1.TabIndex = 24
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RuneSoul)
        Me.GroupBox1.Controls.Add(Me.RuneMakerType)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.RuneSpell)
        Me.GroupBox1.Controls.Add(Me.EnableRuneMaker)
        Me.GroupBox1.Controls.Add(Me.RuneMana)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox1.Location = New System.Drawing.Point(3, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(304, 69)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rune Maker"
        '
        'RuneSoul
        '
        Me.RuneSoul.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.RuneSoul.Location = New System.Drawing.Point(6, 42)
        Me.RuneSoul.MaxLength = 5
        Me.RuneSoul.Name = "RuneSoul"
        Me.RuneSoul.Size = New System.Drawing.Size(58, 20)
        Me.RuneSoul.TabIndex = 25
        Me.RuneSoul.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RuneSoul.WaterMarkColor = System.Drawing.Color.Gray
        Me.RuneSoul.WaterMarkText = "Soul"
        '
        'RuneMakerType
        '
        Me.RuneMakerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RuneMakerType.FormattingEnabled = True
        Me.RuneMakerType.Items.AddRange(New Object() {"Rune", "Spear"})
        Me.RuneMakerType.Location = New System.Drawing.Point(110, 42)
        Me.RuneMakerType.Name = "RuneMakerType"
        Me.RuneMakerType.Size = New System.Drawing.Size(123, 21)
        Me.RuneMakerType.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(70, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Type:"
        '
        'RuneSpell
        '
        Me.RuneSpell.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.RuneSpell.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.RuneSpell.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.RuneSpell.Location = New System.Drawing.Point(70, 16)
        Me.RuneSpell.MaxLength = 30
        Me.RuneSpell.Name = "RuneSpell"
        Me.RuneSpell.Size = New System.Drawing.Size(226, 20)
        Me.RuneSpell.TabIndex = 2
        Me.RuneSpell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RuneSpell.WaterMarkColor = System.Drawing.Color.Gray
        Me.RuneSpell.WaterMarkText = "Spell"
        '
        'EnableRuneMaker
        '
        Me.EnableRuneMaker.AutoSize = True
        Me.EnableRuneMaker.BackColor = System.Drawing.Color.Transparent
        Me.EnableRuneMaker.Location = New System.Drawing.Point(239, 46)
        Me.EnableRuneMaker.Name = "EnableRuneMaker"
        Me.EnableRuneMaker.Size = New System.Drawing.Size(59, 17)
        Me.EnableRuneMaker.TabIndex = 3
        Me.EnableRuneMaker.Text = "Enable"
        Me.ToolTip1.SetToolTip(Me.EnableRuneMaker, "This will cause your character to cast the specified spell and make a rune using " & _
                "the blank item specified when your mana and soul are above the specified values." & _
                "")
        Me.EnableRuneMaker.UseVisualStyleBackColor = False
        '
        'RuneMana
        '
        Me.RuneMana.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.RuneMana.Location = New System.Drawing.Point(6, 16)
        Me.RuneMana.MaxLength = 5
        Me.RuneMana.Name = "RuneMana"
        Me.RuneMana.Size = New System.Drawing.Size(58, 20)
        Me.RuneMana.TabIndex = 1
        Me.RuneMana.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RuneMana.WaterMarkColor = System.Drawing.Color.Gray
        Me.RuneMana.WaterMarkText = "Mana"
        '
        'BoxTimer
        '
        Me.BoxTimer.Interval = 10
        '
        'RuneMakeThread
        '
        '
        'RuneMakeTimer
        '
        Me.RuneMakeTimer.Enabled = True
        Me.RuneMakeTimer.Interval = 1500
        '
        'Magic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(311, 121)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Magic"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TUGBot - Magic"
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents EnableManaTrain As System.Windows.Forms.CheckBox
    Friend WithEvents TrainAtMana As TUGBot.WaterMarkTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RuneSpell As TUGBot.WaterMarkTextBox
    Friend WithEvents EnableRuneMaker As System.Windows.Forms.CheckBox
    Friend WithEvents RuneMana As TUGBot.WaterMarkTextBox
    Friend WithEvents RuneMakerType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BoxTimer As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents RuneMakeThread As System.ComponentModel.BackgroundWorker
    Friend WithEvents RuneMakeTimer As System.Windows.Forms.Timer
    Friend WithEvents RuneSoul As TUGBot.WaterMarkTextBox
    Friend WithEvents ManaTrainSpell As TUGBot.WaterMarkTextBox
End Class
