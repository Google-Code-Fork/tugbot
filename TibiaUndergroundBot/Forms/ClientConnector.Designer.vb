<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClientConnector
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
        Me.Loading = New System.Windows.Forms.PictureBox
        Me.ClientList = New System.Windows.Forms.ListBox
        Me.Loader = New System.ComponentModel.BackgroundWorker
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.RunButton = New System.Windows.Forms.ToolStripSplitButton
        Me.ConnectButton = New System.Windows.Forms.ToolStripButton
        Me.SelectClient = New System.Windows.Forms.OpenFileDialog
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CloseLabel = New System.Windows.Forms.Label
        CType(Me.Loading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Loading
        '
        Me.Loading.Image = Global.TUGBot.My.Resources.Resources.loader_icon
        Me.Loading.Location = New System.Drawing.Point(237, 21)
        Me.Loading.Name = "Loading"
        Me.Loading.Size = New System.Drawing.Size(66, 66)
        Me.Loading.TabIndex = 0
        Me.Loading.TabStop = False
        '
        'ClientList
        '
        Me.ClientList.FormattingEnabled = True
        Me.ClientList.Location = New System.Drawing.Point(6, 26)
        Me.ClientList.Name = "ClientList"
        Me.ClientList.Size = New System.Drawing.Size(151, 56)
        Me.ClientList.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunButton, Me.ConnectButton})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(163, 26)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(68, 56)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'RunButton
        '
        Me.RunButton.AutoSize = False
        Me.RunButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.RunButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RunButton.Name = "RunButton"
        Me.RunButton.Size = New System.Drawing.Size(68, 25)
        Me.RunButton.Text = "Run"
        '
        'ConnectButton
        '
        Me.ConnectButton.AutoSize = False
        Me.ConnectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ConnectButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.Size = New System.Drawing.Size(68, 25)
        Me.ConnectButton.Text = "Connect"
        '
        'SelectClient
        '
        Me.SelectClient.FileName = "OpenFileDialog1"
        '
        'Timer1
        '
        Me.Timer1.Interval = 20
        '
        'CloseLabel
        '
        Me.CloseLabel.BackColor = System.Drawing.Color.Transparent
        Me.CloseLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CloseLabel.Location = New System.Drawing.Point(275, 2)
        Me.CloseLabel.Name = "CloseLabel"
        Me.CloseLabel.Size = New System.Drawing.Size(17, 17)
        Me.CloseLabel.TabIndex = 5
        Me.CloseLabel.Text = "X"
        Me.CloseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ClientConnector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.TUGBot.My.Resources.Resources.ClientLoader
        Me.ClientSize = New System.Drawing.Size(308, 88)
        Me.Controls.Add(Me.CloseLabel)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ClientList)
        Me.Controls.Add(Me.Loading)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ClientConnector"
        Me.Opacity = 0.7
        Me.ShowInTaskbar = False
        Me.Text = "ClientConnector"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(39, Byte), Integer))
        CType(Me.Loading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Loading As System.Windows.Forms.PictureBox
    Friend WithEvents ClientList As System.Windows.Forms.ListBox
    Friend WithEvents Loader As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents RunButton As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ConnectButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SelectClient As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CloseLabel As System.Windows.Forms.Label
End Class
