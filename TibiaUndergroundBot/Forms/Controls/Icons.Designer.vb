<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Icons
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
        Me.ButtonsMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ClearButtons = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteButton = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.NewIcon = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.SaveButtons = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label55 = New System.Windows.Forms.Label
        Me.ButtonsList = New System.Windows.Forms.ListBox
        Me.EnableButtons = New System.Windows.Forms.CheckBox
        Me.ButtonzSize = New System.Windows.Forms.NumericUpDown
        Me.IconProperties = New System.Windows.Forms.PropertyGrid
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PrintButtonTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonsMenu.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ButtonzSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonsMenu
        '
        Me.ButtonsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearButtons, Me.DeleteButton, Me.ToolStripSeparator4, Me.NewIcon, Me.ToolStripSeparator1, Me.SaveButtons, Me.LoadToolStripMenuItem})
        Me.ButtonsMenu.Name = "ButtonsMenu"
        Me.ButtonsMenu.ShowImageMargin = False
        Me.ButtonsMenu.Size = New System.Drawing.Size(136, 126)
        '
        'ClearButtons
        '
        Me.ClearButtons.Name = "ClearButtons"
        Me.ClearButtons.Size = New System.Drawing.Size(135, 22)
        Me.ClearButtons.Text = "Delete All"
        '
        'DeleteButton
        '
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(135, 22)
        Me.DeleteButton.Text = "Delete Selected"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(132, 6)
        '
        'NewIcon
        '
        Me.NewIcon.Name = "NewIcon"
        Me.NewIcon.Size = New System.Drawing.Size(135, 22)
        Me.NewIcon.Text = "<New..>"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(132, 6)
        '
        'SaveButtons
        '
        Me.SaveButtons.Name = "SaveButtons"
        Me.SaveButtons.Size = New System.Drawing.Size(135, 22)
        Me.SaveButtons.Text = "Save List"
        '
        'LoadToolStripMenuItem
        '
        Me.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        Me.LoadToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.LoadToolStripMenuItem.Text = "Load List"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label55)
        Me.GroupBox3.Controls.Add(Me.ButtonsList)
        Me.GroupBox3.Controls.Add(Me.EnableButtons)
        Me.GroupBox3.Controls.Add(Me.ButtonzSize)
        Me.GroupBox3.Controls.Add(Me.IconProperties)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(415, 298)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Icons"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(3, 253)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(30, 13)
        Me.Label55.TabIndex = 80
        Me.Label55.Text = "Size:"
        '
        'ButtonsList
        '
        Me.ButtonsList.ContextMenuStrip = Me.ButtonsMenu
        Me.ButtonsList.FormattingEnabled = True
        Me.ButtonsList.Location = New System.Drawing.Point(6, 19)
        Me.ButtonsList.Name = "ButtonsList"
        Me.ButtonsList.Size = New System.Drawing.Size(151, 225)
        Me.ButtonsList.TabIndex = 81
        '
        'EnableButtons
        '
        Me.EnableButtons.AutoSize = True
        Me.EnableButtons.Location = New System.Drawing.Point(6, 277)
        Me.EnableButtons.Name = "EnableButtons"
        Me.EnableButtons.Size = New System.Drawing.Size(98, 17)
        Me.EnableButtons.TabIndex = 2
        Me.EnableButtons.Text = "Enable Buttons"
        Me.EnableButtons.UseVisualStyleBackColor = True
        '
        'ButtonzSize
        '
        Me.ButtonzSize.Location = New System.Drawing.Point(39, 251)
        Me.ButtonzSize.Maximum = New Decimal(New Integer() {64, 0, 0, 0})
        Me.ButtonzSize.Minimum = New Decimal(New Integer() {16, 0, 0, 0})
        Me.ButtonzSize.Name = "ButtonzSize"
        Me.ButtonzSize.Size = New System.Drawing.Size(118, 20)
        Me.ButtonzSize.TabIndex = 1
        Me.ButtonzSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ButtonzSize.Value = New Decimal(New Integer() {32, 0, 0, 0})
        '
        'IconProperties
        '
        Me.IconProperties.BackColor = System.Drawing.Color.WhiteSmoke
        Me.IconProperties.LineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.IconProperties.Location = New System.Drawing.Point(163, 19)
        Me.IconProperties.Name = "IconProperties"
        Me.IconProperties.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.IconProperties.Size = New System.Drawing.Size(246, 275)
        Me.IconProperties.TabIndex = 12
        Me.IconProperties.ToolbarVisible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(421, 305)
        Me.Panel1.TabIndex = 12
        '
        'PrintButtonTimer
        '
        Me.PrintButtonTimer.Enabled = True
        Me.PrintButtonTimer.Interval = 150
        '
        'Icons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(421, 305)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Icons"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TUGBot - Icons"
        Me.ButtonsMenu.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.ButtonzSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonsMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ClearButtons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveButtons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents ButtonzSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents EnableButtons As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PrintButtonTimer As System.Windows.Forms.Timer
    Friend WithEvents IconProperties As System.Windows.Forms.PropertyGrid
    Friend WithEvents NewIcon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonsList As System.Windows.Forms.ListBox
End Class
