<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Scripter
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
        Me.ErrorMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ErrorClear = New System.Windows.Forms.ToolStripMenuItem
        Me.ErrorCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.ScriptLoadMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewScript = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveScript = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadScript = New System.Windows.Forms.ToolStripMenuItem
        Me.RunningScripts = New System.Windows.Forms.ListBox
        Me.ErrorList = New System.Windows.Forms.ListBox
        Me.ScriptStop = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StopScriptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewCode = New System.Windows.Forms.ToolStripMenuItem
        Me.ScripterHeader = New System.Windows.Forms.ListView
        Me.LineHead = New System.Windows.Forms.ColumnHeader
        Me.ScriptHead = New System.Windows.Forms.ColumnHeader
        Me.ScriptStart = New System.Windows.Forms.ColumnHeader
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ErrorMenu.SuspendLayout()
        Me.ScriptLoadMenu.SuspendLayout()
        Me.ScriptStop.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrorMenu
        '
        Me.ErrorMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ErrorClear, Me.ErrorCopy})
        Me.ErrorMenu.Name = "ErrorMenu"
        Me.ErrorMenu.ShowImageMargin = False
        Me.ErrorMenu.Size = New System.Drawing.Size(86, 48)
        '
        'ErrorClear
        '
        Me.ErrorClear.Name = "ErrorClear"
        Me.ErrorClear.Size = New System.Drawing.Size(85, 22)
        Me.ErrorClear.Text = "Clear"
        '
        'ErrorCopy
        '
        Me.ErrorCopy.Name = "ErrorCopy"
        Me.ErrorCopy.Size = New System.Drawing.Size(85, 22)
        Me.ErrorCopy.Text = "Copy"
        '
        'ScriptLoadMenu
        '
        Me.ScriptLoadMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewScript, Me.SaveScript, Me.LoadScript})
        Me.ScriptLoadMenu.Name = "ScriptLoadMenu"
        Me.ScriptLoadMenu.ShowImageMargin = False
        Me.ScriptLoadMenu.Size = New System.Drawing.Size(93, 70)
        '
        'NewScript
        '
        Me.NewScript.Name = "NewScript"
        Me.NewScript.Size = New System.Drawing.Size(92, 22)
        Me.NewScript.Text = "New"
        '
        'SaveScript
        '
        Me.SaveScript.Name = "SaveScript"
        Me.SaveScript.Size = New System.Drawing.Size(92, 22)
        Me.SaveScript.Text = "Save.."
        '
        'LoadScript
        '
        Me.LoadScript.Name = "LoadScript"
        Me.LoadScript.Size = New System.Drawing.Size(92, 22)
        Me.LoadScript.Text = "Load.."
        '
        'RunningScripts
        '
        Me.RunningScripts.ContextMenuStrip = Me.ScriptStop
        Me.RunningScripts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunningScripts.FormattingEnabled = True
        Me.RunningScripts.Location = New System.Drawing.Point(375, 276)
        Me.RunningScripts.Name = "RunningScripts"
        Me.RunningScripts.ScrollAlwaysVisible = True
        Me.RunningScripts.Size = New System.Drawing.Size(105, 69)
        Me.RunningScripts.TabIndex = 79
        '
        'ErrorList
        '
        Me.ErrorList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErrorList.FormattingEnabled = True
        Me.ErrorList.Location = New System.Drawing.Point(5, 276)
        Me.ErrorList.Name = "ErrorList"
        Me.ErrorList.ScrollAlwaysVisible = True
        Me.ErrorList.Size = New System.Drawing.Size(364, 69)
        Me.ErrorList.TabIndex = 78
        '
        'ScriptStop
        '
        Me.ScriptStop.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StopScriptToolStripMenuItem, Me.ViewCode})
        Me.ScriptStop.Name = "ScriptStop"
        Me.ScriptStop.ShowImageMargin = False
        Me.ScriptStop.Size = New System.Drawing.Size(113, 48)
        '
        'StopScriptToolStripMenuItem
        '
        Me.StopScriptToolStripMenuItem.Name = "StopScriptToolStripMenuItem"
        Me.StopScriptToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.StopScriptToolStripMenuItem.Text = "Stop Script"
        '
        'ViewCode
        '
        Me.ViewCode.Name = "ViewCode"
        Me.ViewCode.Size = New System.Drawing.Size(112, 22)
        Me.ViewCode.Text = "View Code"
        '
        'ScripterHeader
        '
        Me.ScripterHeader.BackColor = System.Drawing.SystemColors.MenuBar
        Me.ScripterHeader.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.LineHead, Me.ScriptHead, Me.ScriptStart})
        Me.ScripterHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScripterHeader.FullRowSelect = True
        Me.ScripterHeader.Location = New System.Drawing.Point(5, 3)
        Me.ScripterHeader.Name = "ScripterHeader"
        Me.ScripterHeader.Size = New System.Drawing.Size(475, 267)
        Me.ScripterHeader.TabIndex = 80
        Me.ScripterHeader.UseCompatibleStateImageBehavior = False
        Me.ScripterHeader.View = System.Windows.Forms.View.Details
        '
        'LineHead
        '
        Me.LineHead.Tag = "Line"
        Me.LineHead.Text = "Line"
        Me.LineHead.Width = 37
        '
        'ScriptHead
        '
        Me.ScriptHead.Tag = "Code"
        Me.ScriptHead.Text = "Code"
        Me.ScriptHead.Width = 363
        '
        'ScriptStart
        '
        Me.ScriptStart.Tag = "Start Script"
        Me.ScriptStart.Text = "Start Script"
        Me.ScriptStart.Width = 70
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(485, 349)
        Me.Panel1.TabIndex = 81
        '
        'Scripter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(485, 349)
        Me.Controls.Add(Me.RunningScripts)
        Me.Controls.Add(Me.ScripterHeader)
        Me.Controls.Add(Me.ErrorList)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Scripter"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TUGBot - Scripter"
        Me.ErrorMenu.ResumeLayout(False)
        Me.ScriptLoadMenu.ResumeLayout(False)
        Me.ScriptStop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ErrorClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScriptLoadMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewScript As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveScript As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadScript As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunningScripts As System.Windows.Forms.ListBox
    Friend WithEvents ErrorList As System.Windows.Forms.ListBox
    Friend WithEvents ScriptStop As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents StopScriptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewCode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScripterHeader As System.Windows.Forms.ListView
    Friend WithEvents LineHead As System.Windows.Forms.ColumnHeader
    Friend WithEvents ScriptHead As System.Windows.Forms.ColumnHeader
    Friend WithEvents ScriptStart As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
