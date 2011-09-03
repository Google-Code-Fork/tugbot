<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Navigation
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Button9 = New System.Windows.Forms.Button
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button8 = New System.Windows.Forms.Button
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.CurrentFloor = New System.Windows.Forms.RadioButton
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.AllFloors = New System.Windows.Forms.RadioButton
        Me.GroupBox14 = New System.Windows.Forms.GroupBox
        Me.Button6 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.NavPort = New System.Windows.Forms.TextBox
        Me.ConnectNav = New System.Windows.Forms.Button
        Me.NavPassword = New System.Windows.Forms.TextBox
        Me.NavIp = New System.Windows.Forms.TextBox
        Me.MapContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SetReToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.MiniMapViewer1 = New TUGBot.MiniMapViewer(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.MapContextMenu.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.MiniMapViewer1)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox14)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(612, 410)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox1.Location = New System.Drawing.Point(171, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(437, 138)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Live GPS"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox4.Controls.Add(Me.Button9)
        Me.GroupBox4.Controls.Add(Me.CheckBox3)
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox4.Location = New System.Drawing.Point(186, 87)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(243, 45)
        Me.GroupBox4.TabIndex = 34
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Rendezvous"
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(6, 19)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(109, 20)
        Me.Button9.TabIndex = 33
        Me.Button9.Text = "Clear Regions"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.Location = New System.Drawing.Point(121, 22)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(116, 17)
        Me.CheckBox3.TabIndex = 8
        Me.CheckBox3.Text = "Show Rendezvous"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox3.Controls.Add(Me.Button8)
        Me.GroupBox3.Controls.Add(Me.CheckBox2)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox3.Location = New System.Drawing.Point(186, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(99, 68)
        Me.GroupBox3.TabIndex = 29
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Radar"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(6, 19)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(85, 20)
        Me.Button8.TabIndex = 33
        Me.Button8.Text = "Reset"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(6, 45)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(85, 17)
        Me.CheckBox2.TabIndex = 8
        Me.CheckBox2.Text = "Show Radar"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.Controls.Add(Me.Panel3)
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Controls.Add(Me.CurrentFloor)
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Controls.Add(Me.AllFloors)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox2.Location = New System.Drawing.Point(6, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(178, 116)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Display Names"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.RadioButton3)
        Me.Panel3.Controls.Add(Me.RadioButton4)
        Me.Panel3.Location = New System.Drawing.Point(0, 61)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(174, 26)
        Me.Panel3.TabIndex = 14
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Location = New System.Drawing.Point(89, 3)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(87, 17)
        Me.RadioButton3.TabIndex = 13
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Enemies Too"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(6, 4)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(73, 17)
        Me.RadioButton4.TabIndex = 12
        Me.RadioButton4.Text = "Allies Only"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RadioButton2)
        Me.Panel2.Controls.Add(Me.RadioButton1)
        Me.Panel2.Location = New System.Drawing.Point(0, 39)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(168, 23)
        Me.Panel2.TabIndex = 11
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(89, 3)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(78, 17)
        Me.RadioButton2.TabIndex = 13
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "All Availible"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 3)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(77, 17)
        Me.RadioButton1.TabIndex = 12
        Me.RadioButton1.Text = "Connected"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'CurrentFloor
        '
        Me.CurrentFloor.AutoSize = True
        Me.CurrentFloor.Location = New System.Drawing.Point(89, 19)
        Me.CurrentFloor.Name = "CurrentFloor"
        Me.CurrentFloor.Size = New System.Drawing.Size(85, 17)
        Me.CurrentFloor.TabIndex = 10
        Me.CurrentFloor.Text = "Current Floor"
        Me.CurrentFloor.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(6, 93)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(89, 17)
        Me.CheckBox1.TabIndex = 8
        Me.CheckBox1.Text = "Show Names"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'AllFloors
        '
        Me.AllFloors.AutoSize = True
        Me.AllFloors.Checked = True
        Me.AllFloors.Location = New System.Drawing.Point(6, 19)
        Me.AllFloors.Name = "AllFloors"
        Me.AllFloors.Size = New System.Drawing.Size(67, 17)
        Me.AllFloors.TabIndex = 9
        Me.AllFloors.TabStop = True
        Me.AllFloors.Text = "All Floors"
        Me.AllFloors.UseVisualStyleBackColor = True
        '
        'GroupBox14
        '
        Me.GroupBox14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox14.Controls.Add(Me.Button6)
        Me.GroupBox14.Controls.Add(Me.Label5)
        Me.GroupBox14.Controls.Add(Me.Label4)
        Me.GroupBox14.Controls.Add(Me.Label3)
        Me.GroupBox14.Controls.Add(Me.NavPort)
        Me.GroupBox14.Controls.Add(Me.ConnectNav)
        Me.GroupBox14.Controls.Add(Me.NavPassword)
        Me.GroupBox14.Controls.Add(Me.NavIp)
        Me.GroupBox14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox14.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(162, 138)
        Me.GroupBox14.TabIndex = 26
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Server"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(9, 112)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(143, 20)
        Me.Button6.TabIndex = 35
        Me.Button6.Text = "Disconnect"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(103, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Port:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "IP:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Password:"
        '
        'NavPort
        '
        Me.NavPort.Location = New System.Drawing.Point(106, 32)
        Me.NavPort.Name = "NavPort"
        Me.NavPort.Size = New System.Drawing.Size(46, 20)
        Me.NavPort.TabIndex = 0
        Me.NavPort.Text = "8182"
        '
        'ConnectNav
        '
        Me.ConnectNav.Location = New System.Drawing.Point(9, 92)
        Me.ConnectNav.Name = "ConnectNav"
        Me.ConnectNav.Size = New System.Drawing.Size(143, 20)
        Me.ConnectNav.TabIndex = 3
        Me.ConnectNav.Text = "Connect"
        Me.ConnectNav.UseVisualStyleBackColor = True
        '
        'NavPassword
        '
        Me.NavPassword.Location = New System.Drawing.Point(9, 71)
        Me.NavPassword.Name = "NavPassword"
        Me.NavPassword.Size = New System.Drawing.Size(143, 20)
        Me.NavPassword.TabIndex = 2
        Me.NavPassword.UseSystemPasswordChar = True
        '
        'NavIp
        '
        Me.NavIp.Location = New System.Drawing.Point(9, 32)
        Me.NavIp.Name = "NavIp"
        Me.NavIp.Size = New System.Drawing.Size(91, 20)
        Me.NavIp.TabIndex = 1
        Me.NavIp.Text = "127.0.01"
        '
        'MapContextMenu
        '
        Me.MapContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetReToolStripMenuItem})
        Me.MapContextMenu.Name = "MapContextMenu"
        Me.MapContextMenu.Size = New System.Drawing.Size(204, 26)
        '
        'SetReToolStripMenuItem
        '
        Me.SetReToolStripMenuItem.Name = "SetReToolStripMenuItem"
        Me.SetReToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.SetReToolStripMenuItem.Text = "Set As Rendezvous Point"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(291, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(138, 65)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Controls:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Zoom: Mouse Wheel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Floor Change: +/-" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Move: Leftclick+Drag" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Highlight:" & _
            " Rightclick+Drag"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(470, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(138, 65)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Display Key:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Green Marker: Ally" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Orange Marker: Enemy" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Red Area: Radar Estimatio" & _
            "n" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Yellow Area: Rendezvous"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(470, 356)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(138, 26)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "Center Map"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MiniMapViewer1
        '
        Me.MiniMapViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MiniMapViewer1.Location = New System.Drawing.Point(3, 147)
        Me.MiniMapViewer1.Name = "MiniMapViewer1"
        Me.MiniMapViewer1.Size = New System.Drawing.Size(461, 235)
        Me.MiniMapViewer1.TabIndex = 34
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripSeparator1, Me.ToolStripLabel2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 385)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(612, 25)
        Me.ToolStrip1.TabIndex = 37
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(315, 22)
        Me.ToolStripLabel1.Text = "Radar locked onto {0} - {1} Exivas stored"
        Me.ToolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(245, 22)
        Me.ToolStripLabel2.Text = "{0} Players Connected - {1} Positions Mapped"
        Me.ToolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Navigation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(612, 410)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Navigation"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Navigation"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.MapContextMenu.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents NavPassword As System.Windows.Forms.TextBox
    Friend WithEvents NavIp As System.Windows.Forms.TextBox
    Friend WithEvents NavPort As System.Windows.Forms.TextBox
    Friend WithEvents ConnectNav As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CurrentFloor As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents AllFloors As System.Windows.Forms.RadioButton
    Friend WithEvents MapContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SetReToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents MapViewer1 As TUGBot.MapViewer
    Friend WithEvents MiniMapViewer1 As TUGBot.MiniMapViewer
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
End Class
