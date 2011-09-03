<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrialForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TrialForm))
        Me.TrialTimer = New System.Windows.Forms.Timer(Me.components)
        Me.exitbutton = New System.Windows.Forms.Button
        Me.buybutton = New System.Windows.Forms.Button
        Me.unlockbutton = New System.Windows.Forms.Button
        Me.unregbutton = New System.Windows.Forms.Button
        Me.UsedTrialBar = New System.Windows.Forms.PictureBox
        Me.TrialPeriodDisplay = New System.Windows.Forms.PictureBox
        Me.BarBorder = New System.Windows.Forms.PictureBox
        CType(Me.UsedTrialBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrialPeriodDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrialTimer
        '
        Me.TrialTimer.Enabled = True
        '
        'exitbutton
        '
        Me.exitbutton.BackColor = System.Drawing.Color.Transparent
        Me.exitbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.exitbutton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.exitbutton.ForeColor = System.Drawing.Color.Black
        Me.exitbutton.Image = CType(resources.GetObject("exitbutton.Image"), System.Drawing.Image)
        Me.exitbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.exitbutton.Location = New System.Drawing.Point(178, 103)
        Me.exitbutton.Name = "exitbutton"
        Me.exitbutton.Size = New System.Drawing.Size(145, 56)
        Me.exitbutton.TabIndex = 16
        Me.exitbutton.Text = "Close TUGBot"
        Me.exitbutton.UseVisualStyleBackColor = False
        '
        'buybutton
        '
        Me.buybutton.BackColor = System.Drawing.Color.Transparent
        Me.buybutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buybutton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buybutton.ForeColor = System.Drawing.Color.Black
        Me.buybutton.Image = CType(resources.GetObject("buybutton.Image"), System.Drawing.Image)
        Me.buybutton.Location = New System.Drawing.Point(2, 103)
        Me.buybutton.Name = "buybutton"
        Me.buybutton.Size = New System.Drawing.Size(168, 56)
        Me.buybutton.TabIndex = 15
        Me.buybutton.Text = "Purchase Unlock Key"
        Me.buybutton.UseVisualStyleBackColor = False
        '
        'unlockbutton
        '
        Me.unlockbutton.BackColor = System.Drawing.Color.Transparent
        Me.unlockbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.unlockbutton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unlockbutton.ForeColor = System.Drawing.Color.Black
        Me.unlockbutton.Image = CType(resources.GetObject("unlockbutton.Image"), System.Drawing.Image)
        Me.unlockbutton.Location = New System.Drawing.Point(178, 41)
        Me.unlockbutton.Name = "unlockbutton"
        Me.unlockbutton.Size = New System.Drawing.Size(145, 56)
        Me.unlockbutton.TabIndex = 14
        Me.unlockbutton.Text = "Unlock TUGBot"
        Me.unlockbutton.UseVisualStyleBackColor = False
        '
        'unregbutton
        '
        Me.unregbutton.BackColor = System.Drawing.Color.Transparent
        Me.unregbutton.Enabled = False
        Me.unregbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.unregbutton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unregbutton.ForeColor = System.Drawing.Color.Black
        Me.unregbutton.Image = CType(resources.GetObject("unregbutton.Image"), System.Drawing.Image)
        Me.unregbutton.Location = New System.Drawing.Point(2, 41)
        Me.unregbutton.Name = "unregbutton"
        Me.unregbutton.Size = New System.Drawing.Size(168, 56)
        Me.unregbutton.TabIndex = 13
        Me.unregbutton.Text = "Use Trial Version (30)"
        Me.unregbutton.UseVisualStyleBackColor = False
        '
        'UsedTrialBar
        '
        Me.UsedTrialBar.BackColor = System.Drawing.Color.Transparent
        Me.UsedTrialBar.Image = CType(resources.GetObject("UsedTrialBar.Image"), System.Drawing.Image)
        Me.UsedTrialBar.Location = New System.Drawing.Point(2, 3)
        Me.UsedTrialBar.Name = "UsedTrialBar"
        Me.UsedTrialBar.Size = New System.Drawing.Size(10, 32)
        Me.UsedTrialBar.TabIndex = 12
        Me.UsedTrialBar.TabStop = False
        '
        'TrialPeriodDisplay
        '
        Me.TrialPeriodDisplay.BackColor = System.Drawing.Color.Transparent
        Me.TrialPeriodDisplay.Image = CType(resources.GetObject("TrialPeriodDisplay.Image"), System.Drawing.Image)
        Me.TrialPeriodDisplay.Location = New System.Drawing.Point(2, 3)
        Me.TrialPeriodDisplay.Name = "TrialPeriodDisplay"
        Me.TrialPeriodDisplay.Size = New System.Drawing.Size(321, 32)
        Me.TrialPeriodDisplay.TabIndex = 10
        Me.TrialPeriodDisplay.TabStop = False
        '
        'BarBorder
        '
        Me.BarBorder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BarBorder.Location = New System.Drawing.Point(1, 1)
        Me.BarBorder.Name = "BarBorder"
        Me.BarBorder.Size = New System.Drawing.Size(321, 33)
        Me.BarBorder.TabIndex = 17
        Me.BarBorder.TabStop = False
        '
        'TrialForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(327, 162)
        Me.Controls.Add(Me.exitbutton)
        Me.Controls.Add(Me.buybutton)
        Me.Controls.Add(Me.unlockbutton)
        Me.Controls.Add(Me.unregbutton)
        Me.Controls.Add(Me.UsedTrialBar)
        Me.Controls.Add(Me.TrialPeriodDisplay)
        Me.Controls.Add(Me.BarBorder)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "TrialForm"
        Me.Text = "TrialForm"
        Me.TopMost = True
        CType(Me.UsedTrialBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrialPeriodDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarBorder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents exitbutton As System.Windows.Forms.Button
    Friend WithEvents buybutton As System.Windows.Forms.Button
    Friend WithEvents unlockbutton As System.Windows.Forms.Button
    Friend WithEvents unregbutton As System.Windows.Forms.Button
    Friend WithEvents UsedTrialBar As System.Windows.Forms.PictureBox
    Friend WithEvents TrialPeriodDisplay As System.Windows.Forms.PictureBox
    Friend WithEvents TrialTimer As System.Windows.Forms.Timer
    Friend WithEvents BarBorder As System.Windows.Forms.PictureBox
End Class
