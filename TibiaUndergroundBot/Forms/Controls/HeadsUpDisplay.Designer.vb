<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HeadsUpDisplay
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
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.EnableStatusPanel = New System.Windows.Forms.CheckBox
        Me.ShowPingEnable = New System.Windows.Forms.CheckBox
        Me.ShowTargetEnable = New System.Windows.Forms.CheckBox
        Me.ShowDmgPSEnable = New System.Windows.Forms.CheckBox
        Me.ShowExpEnable = New System.Windows.Forms.CheckBox
        Me.SpellTimerEnable = New System.Windows.Forms.CheckBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.StatusPanelY = New System.Windows.Forms.NumericUpDown
        Me.StatusPanelX = New System.Windows.Forms.NumericUpDown
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CheckBox6 = New System.Windows.Forms.CheckBox
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.CheckBox4 = New System.Windows.Forms.CheckBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.HourlyExpTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusPanelDisplay = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox10.SuspendLayout()
        CType(Me.StatusPanelY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusPanelX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.EnableStatusPanel)
        Me.GroupBox10.Controls.Add(Me.ShowPingEnable)
        Me.GroupBox10.Controls.Add(Me.ShowTargetEnable)
        Me.GroupBox10.Controls.Add(Me.ShowDmgPSEnable)
        Me.GroupBox10.Controls.Add(Me.ShowExpEnable)
        Me.GroupBox10.Controls.Add(Me.SpellTimerEnable)
        Me.GroupBox10.Controls.Add(Me.Label14)
        Me.GroupBox10.Controls.Add(Me.Label15)
        Me.GroupBox10.Controls.Add(Me.StatusPanelY)
        Me.GroupBox10.Controls.Add(Me.StatusPanelX)
        Me.GroupBox10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox10.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(268, 94)
        Me.GroupBox10.TabIndex = 6
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Status Panel"
        '
        'EnableStatusPanel
        '
        Me.EnableStatusPanel.AutoSize = True
        Me.EnableStatusPanel.BackColor = System.Drawing.Color.Transparent
        Me.EnableStatusPanel.Location = New System.Drawing.Point(143, 69)
        Me.EnableStatusPanel.Name = "EnableStatusPanel"
        Me.EnableStatusPanel.Size = New System.Drawing.Size(122, 17)
        Me.EnableStatusPanel.TabIndex = 13
        Me.EnableStatusPanel.Text = "Enable Status Panel"
        Me.ToolTip1.SetToolTip(Me.EnableStatusPanel, "Show the Status Panel.")
        Me.EnableStatusPanel.UseVisualStyleBackColor = False
        '
        'ShowPingEnable
        '
        Me.ShowPingEnable.AutoSize = True
        Me.ShowPingEnable.BackColor = System.Drawing.Color.Transparent
        Me.ShowPingEnable.Enabled = False
        Me.ShowPingEnable.Location = New System.Drawing.Point(134, 43)
        Me.ShowPingEnable.Name = "ShowPingEnable"
        Me.ShowPingEnable.Size = New System.Drawing.Size(47, 17)
        Me.ShowPingEnable.TabIndex = 10
        Me.ShowPingEnable.Text = "Ping"
        Me.ToolTip1.SetToolTip(Me.ShowPingEnable, "When the Status Panel is enabled, show Ping")
        Me.ShowPingEnable.UseVisualStyleBackColor = False
        '
        'ShowTargetEnable
        '
        Me.ShowTargetEnable.AutoSize = True
        Me.ShowTargetEnable.BackColor = System.Drawing.Color.Transparent
        Me.ShowTargetEnable.Enabled = False
        Me.ShowTargetEnable.Location = New System.Drawing.Point(181, 20)
        Me.ShowTargetEnable.Name = "ShowTargetEnable"
        Me.ShowTargetEnable.Size = New System.Drawing.Size(57, 17)
        Me.ShowTargetEnable.TabIndex = 8
        Me.ShowTargetEnable.Text = "Target"
        Me.ToolTip1.SetToolTip(Me.ShowTargetEnable, "When the Status Panel is enabled, show current target.")
        Me.ShowTargetEnable.UseVisualStyleBackColor = False
        '
        'ShowDmgPSEnable
        '
        Me.ShowDmgPSEnable.AutoSize = True
        Me.ShowDmgPSEnable.BackColor = System.Drawing.Color.Transparent
        Me.ShowDmgPSEnable.Enabled = False
        Me.ShowDmgPSEnable.Location = New System.Drawing.Point(6, 43)
        Me.ShowDmgPSEnable.Name = "ShowDmgPSEnable"
        Me.ShowDmgPSEnable.Size = New System.Drawing.Size(125, 17)
        Me.ShowDmgPSEnable.TabIndex = 9
        Me.ShowDmgPSEnable.Text = "Damage Per Second"
        Me.ToolTip1.SetToolTip(Me.ShowDmgPSEnable, "When the Status Panel is enabled, show Damage Per Second.")
        Me.ShowDmgPSEnable.UseVisualStyleBackColor = False
        '
        'ShowExpEnable
        '
        Me.ShowExpEnable.AutoSize = True
        Me.ShowExpEnable.BackColor = System.Drawing.Color.Transparent
        Me.ShowExpEnable.Location = New System.Drawing.Point(96, 20)
        Me.ShowExpEnable.Name = "ShowExpEnable"
        Me.ShowExpEnable.Size = New System.Drawing.Size(79, 17)
        Me.ShowExpEnable.TabIndex = 7
        Me.ShowExpEnable.Text = "Experience"
        Me.ToolTip1.SetToolTip(Me.ShowExpEnable, "When the Status Panel is enabled, show exp/hr.")
        Me.ShowExpEnable.UseVisualStyleBackColor = False
        '
        'SpellTimerEnable
        '
        Me.SpellTimerEnable.AutoSize = True
        Me.SpellTimerEnable.BackColor = System.Drawing.Color.Transparent
        Me.SpellTimerEnable.Location = New System.Drawing.Point(6, 20)
        Me.SpellTimerEnable.Name = "SpellTimerEnable"
        Me.SpellTimerEnable.Size = New System.Drawing.Size(83, 17)
        Me.SpellTimerEnable.TabIndex = 6
        Me.SpellTimerEnable.Text = "Spell Timers"
        Me.ToolTip1.SetToolTip(Me.SpellTimerEnable, "When the Status Panel is enabled, show spell timers.")
        Me.SpellTimerEnable.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(73, 69)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(17, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Y:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 69)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(17, 13)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "X:"
        '
        'StatusPanelY
        '
        Me.StatusPanelY.Location = New System.Drawing.Point(96, 67)
        Me.StatusPanelY.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.StatusPanelY.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.StatusPanelY.Name = "StatusPanelY"
        Me.StatusPanelY.Size = New System.Drawing.Size(41, 20)
        Me.StatusPanelY.TabIndex = 12
        Me.StatusPanelY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.StatusPanelY, "The Y position at which to show the status panel")
        Me.StatusPanelY.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'StatusPanelX
        '
        Me.StatusPanelX.Location = New System.Drawing.Point(26, 67)
        Me.StatusPanelX.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.StatusPanelX.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.StatusPanelX.Name = "StatusPanelX"
        Me.StatusPanelX.Size = New System.Drawing.Size(41, 20)
        Me.StatusPanelX.TabIndex = 11
        Me.StatusPanelX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.StatusPanelX, "The X position at which to show the status panel.")
        Me.StatusPanelX.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBox6)
        Me.GroupBox2.Controls.Add(Me.CheckBox3)
        Me.GroupBox2.Controls.Add(Me.CheckBox2)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox2.Location = New System.Drawing.Point(277, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(190, 52)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Other"
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox6.Enabled = False
        Me.CheckBox6.Location = New System.Drawing.Point(95, 29)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(93, 17)
        Me.CheckBox6.TabIndex = 17
        Me.CheckBox6.Text = "M-Wall Timers"
        Me.CheckBox6.UseVisualStyleBackColor = False
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox3.Enabled = False
        Me.CheckBox3.Location = New System.Drawing.Point(6, 29)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(85, 17)
        Me.CheckBox3.TabIndex = 16
        Me.CheckBox3.Text = "Monster Info"
        Me.CheckBox3.UseVisualStyleBackColor = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.Location = New System.Drawing.Point(95, 15)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(76, 17)
        Me.CheckBox2.TabIndex = 15
        Me.CheckBox2.Text = "Player Info"
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox10)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(276, 101)
        Me.Panel1.TabIndex = 7
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.CheckBox4)
        Me.GroupBox3.Controls.Add(Me.ListBox1)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox3.Location = New System.Drawing.Point(3, 161)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(432, 142)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Custom"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.TextBox1)
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox4.Location = New System.Drawing.Point(133, 10)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(293, 126)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Add"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "TODO: Re-Enable this shit"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Text:"
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(43, 19)
        Me.TextBox1.MaxLength = 150
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(244, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Enabled = False
        Me.CheckBox4.Location = New System.Drawing.Point(6, 119)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(121, 17)
        Me.CheckBox4.TabIndex = 10
        Me.CheckBox4.Text = "Enable Custom Text"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Enabled = False
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(6, 19)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(121, 95)
        Me.ListBox1.TabIndex = 0
        '
        'HourlyExpTimer
        '
        Me.HourlyExpTimer.Enabled = True
        Me.HourlyExpTimer.Interval = 1000
        '
        'StatusPanelDisplay
        '
        Me.StatusPanelDisplay.Enabled = True
        '
        'HeadsUpDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(276, 101)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HeadsUpDisplay"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TUGBot - HUD"
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        CType(Me.StatusPanelY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusPanelX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents EnableStatusPanel As System.Windows.Forms.CheckBox
    Friend WithEvents ShowPingEnable As System.Windows.Forms.CheckBox
    Friend WithEvents ShowTargetEnable As System.Windows.Forms.CheckBox
    Friend WithEvents ShowDmgPSEnable As System.Windows.Forms.CheckBox
    Friend WithEvents ShowExpEnable As System.Windows.Forms.CheckBox
    Friend WithEvents SpellTimerEnable As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents StatusPanelY As System.Windows.Forms.NumericUpDown
    Friend WithEvents StatusPanelX As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents HourlyExpTimer As System.Windows.Forms.Timer
    Friend WithEvents StatusPanelDisplay As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
