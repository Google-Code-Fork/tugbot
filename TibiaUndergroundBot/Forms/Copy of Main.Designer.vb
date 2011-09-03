<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.TeamMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddEntireGuildToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.RemoveSelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ClientDropDown = New System.Windows.Forms.ToolStripComboBox
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ErrorClear = New System.Windows.Forms.ToolStripMenuItem
        Me.ErrorCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.ScriptLoadMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewScript = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveScript = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadScript = New System.Windows.Forms.ToolStripMenuItem
        Me.ScriptStop = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StopScriptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewCode = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadFile = New System.Windows.Forms.OpenFileDialog
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip
        Me.GeneralToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenTools = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenMagic = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenSupport = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenCavebot = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenWalker = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenAttacker = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.OpenWar = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenHUD = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenIcons = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenHotkeys = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.OpenScripter = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadSkinButton = New System.Windows.Forms.ToolStripMenuItem
        Me.ApllySkinThread = New System.ComponentModel.BackgroundWorker
        Me.TeamMenu.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ErrorMenu.SuspendLayout()
        Me.ScriptLoadMenu.SuspendLayout()
        Me.ScriptStop.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TeamMenu
        '
        Me.TeamMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.AddEntireGuildToolStripMenuItem, Me.ToolStripSeparator1, Me.RemoveSelectedToolStripMenuItem, Me.ToolStripSeparator2, Me.ClearToolStripMenuItem, Me.ToolStripSeparator3, Me.SaveToolStripMenuItem})
        Me.TeamMenu.Name = "TeamMenu"
        Me.TeamMenu.Size = New System.Drawing.Size(170, 132)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.AddToolStripMenuItem.Text = "Add.."
        '
        'AddEntireGuildToolStripMenuItem
        '
        Me.AddEntireGuildToolStripMenuItem.Name = "AddEntireGuildToolStripMenuItem"
        Me.AddEntireGuildToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.AddEntireGuildToolStripMenuItem.Text = "Add Entire Guild.."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(166, 6)
        '
        'RemoveSelectedToolStripMenuItem
        '
        Me.RemoveSelectedToolStripMenuItem.Name = "RemoveSelectedToolStripMenuItem"
        Me.RemoveSelectedToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.RemoveSelectedToolStripMenuItem.Text = "Remove"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(166, 6)
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(166, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.SaveToolStripMenuItem.Text = "Save.."
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 24)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(313, 27)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ClientDropDown
        '
        Me.ClientDropDown.AutoSize = False
        Me.ClientDropDown.BackColor = System.Drawing.SystemColors.Window
        Me.ClientDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ClientDropDown.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientDropDown.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ClientDropDown.MaxDropDownItems = 20
        Me.ClientDropDown.Name = "ClientDropDown"
        Me.ClientDropDown.Size = New System.Drawing.Size(300, 23)
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
        'LoadFile
        '
        Me.LoadFile.FileName = "OpenFileDialog1"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(313, 24)
        Me.MenuStrip2.TabIndex = 7
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'GeneralToolStripMenuItem
        '
        Me.GeneralToolStripMenuItem.Name = "GeneralToolStripMenuItem"
        Me.GeneralToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.GeneralToolStripMenuItem.Text = "General"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.OpenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenTools, Me.OpenMagic, Me.OpenSupport, Me.OpenCavebot, Me.ToolStripSeparator4, Me.OpenWar, Me.OpenHUD, Me.OpenIcons, Me.OpenHotkeys, Me.ToolStripSeparator5, Me.OpenScripter})
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.OpenToolStripMenuItem.Text = "Open.."
        '
        'OpenTools
        '
        Me.OpenTools.Name = "OpenTools"
        Me.OpenTools.Size = New System.Drawing.Size(126, 22)
        Me.OpenTools.Text = "Tools"
        '
        'OpenMagic
        '
        Me.OpenMagic.Name = "OpenMagic"
        Me.OpenMagic.Size = New System.Drawing.Size(126, 22)
        Me.OpenMagic.Text = "Magic"
        '
        'OpenSupport
        '
        Me.OpenSupport.Name = "OpenSupport"
        Me.OpenSupport.Size = New System.Drawing.Size(126, 22)
        Me.OpenSupport.Text = "Support"
        '
        'OpenCavebot
        '
        Me.OpenCavebot.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenWalker, Me.OpenAttacker})
        Me.OpenCavebot.Name = "OpenCavebot"
        Me.OpenCavebot.Size = New System.Drawing.Size(126, 22)
        Me.OpenCavebot.Text = "Cavebot"
        '
        'OpenWalker
        '
        Me.OpenWalker.Name = "OpenWalker"
        Me.OpenWalker.Size = New System.Drawing.Size(126, 22)
        Me.OpenWalker.Text = "Walker"
        '
        'OpenAttacker
        '
        Me.OpenAttacker.Name = "OpenAttacker"
        Me.OpenAttacker.Size = New System.Drawing.Size(126, 22)
        Me.OpenAttacker.Text = "Attacker"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(123, 6)
        '
        'OpenWar
        '
        Me.OpenWar.Name = "OpenWar"
        Me.OpenWar.Size = New System.Drawing.Size(126, 22)
        Me.OpenWar.Text = "War"
        '
        'OpenHUD
        '
        Me.OpenHUD.Name = "OpenHUD"
        Me.OpenHUD.Size = New System.Drawing.Size(126, 22)
        Me.OpenHUD.Text = "HUD"
        '
        'OpenIcons
        '
        Me.OpenIcons.Name = "OpenIcons"
        Me.OpenIcons.Size = New System.Drawing.Size(126, 22)
        Me.OpenIcons.Text = "Icons"
        '
        'OpenHotkeys
        '
        Me.OpenHotkeys.Name = "OpenHotkeys"
        Me.OpenHotkeys.Size = New System.Drawing.Size(126, 22)
        Me.OpenHotkeys.Text = "Hotkeys"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(123, 6)
        '
        'OpenScripter
        '
        Me.OpenScripter.Name = "OpenScripter"
        Me.OpenScripter.Size = New System.Drawing.Size(126, 22)
        Me.OpenScripter.Text = "Scripter"
        '
        'LoadSkinButton
        '
        Me.LoadSkinButton.Name = "LoadSkinButton"
        Me.LoadSkinButton.Size = New System.Drawing.Size(72, 20)
        Me.LoadSkinButton.Text = "Load Skin.."
        '
        'Main
        '
        Me.AccessibleName = "Main"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(313, 51)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "TUGBot"
        Me.TeamMenu.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ErrorMenu.ResumeLayout(False)
        Me.ScriptLoadMenu.ResumeLayout(False)
        Me.ScriptStop.ResumeLayout(False)
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebsiteDataThread As System.ComponentModel.BackgroundWorker
    Friend WithEvents TeamMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddEntireGuildToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RemoveSelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ClientDropDown As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents SaveFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents TrayMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ErrorClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScriptLoadMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewScript As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveScript As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadScript As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScriptStop As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents StopScriptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewCode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents GeneralToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenMagic As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenSupport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenCavebot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenWar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenHUD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenIcons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenHotkeys As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenScripter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ApllySkinThread As System.ComponentModel.BackgroundWorker
    Friend WithEvents LoadSkinButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenWalker As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenAttacker As System.Windows.Forms.ToolStripMenuItem

End Class
