Imports System.Xml
Public Class Icons

    Private Shadows Sub FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Visible = False
        e.Cancel = True
    End Sub

    Private Sub Icons_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        Me.Refresh()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()
    End Sub

#Region "On screen buttons"

#Region "Context Menus"
    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        If ButtonsList.SelectedItem Is Nothing Then Exit Sub
        ButtonsList.Items.Remove(ButtonsList.SelectedItem)
    End Sub

    Private Sub ClearButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearButtons.Click
        ButtonsList.Items.Clear()
    End Sub
#End Region


    Private Sub ButtonzSize_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonzSize.ValueChanged
        ButtonSize = ButtonzSize.Value
    End Sub

    Private Sub EnableButtons_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableButtons.CheckedChanged
        If TClient.ReadInt(TClient.Addresses.Client.Connection) <> 8 Then
            If EnableButtons.Checked Then
                Buttons.Clear()
                For Each b As ButtonStruct In ButtonsList.Items
                    Buttons.Add(b)
                Next
                EnableButtons.Checked = False
                Exit Sub
            End If
        End If

        ButtonsEnabled = EnableButtons.Checked
        ButtonSize = ButtonzSize.Value

        If EnableButtons.Checked Then
            Buttons.Clear()
            For Each b As ButtonStruct In ButtonsList.Items
                Buttons.Add(b)
            Next
        Else
            Dim ButtonListSelected As Integer = ButtonsList.SelectedIndex
            ButtonsList.Items.Clear()
            For Each b As ButtonStruct In Buttons
                b.DisableAutos()
                ButtonsList.Items.Add(b)
            Next
            If ButtonsList.Items.Count > ButtonListSelected Then
                ButtonsList.SelectedIndex = ButtonListSelected
            ElseIf ButtonsList.Items.Count >= 1 Then
                ButtonsList.SelectedIndex = 0
            End If
        End If

        ButtonzSize.Enabled = Not ButtonsEnabled
        DeleteButton.Enabled = Not ButtonsEnabled
        ClearButtons.Enabled = Not ButtonsEnabled
        SaveButtons.Enabled = Not ButtonsEnabled
        IconProperties.Enabled = Not ButtonsEnabled
        ButtonsList.Enabled = Not ButtonsEnabled
    End Sub
#End Region

    Private Sub LoadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadToolStripMenuItem.Click
        Main.LoadFile.Title = "Load Icons"
        Main.LoadFile.Filter = "TUGBot Icon File (*.TBIC)|*.TBIC|All files (*.*)|*.*"

        If System.IO.Directory.Exists(Application.StartupPath & "\Quickload\Icons") Then
            Main.LoadFile.InitialDirectory = Application.StartupPath & "\Quickload\Icons"
        Else
            Main.LoadFile.InitialDirectory = Application.StartupPath
        End If
        Main.LoadFile.FileName = ""
        Main.LoadFile.ShowDialog()

        If Main.LoadFile.FileName = "" Then Exit Sub
        LoadButtons(Main.LoadFile.FileName)
    End Sub

    Private Sub SaveButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButtons.Click
        Dim settings As New XmlWriterSettings()
        settings.Indent = True
        settings.NewLineOnAttributes = False

        Main.SaveFile.Title = "Save Icons"
        Main.SaveFile.Filter = "TUGBot Icon File (*.TBIC)|*.TBIC|All files (*.*)|*.*"
        If System.IO.Directory.Exists(Application.StartupPath & "\Quickload\Icons") Then
            Main.SaveFile.InitialDirectory = Application.StartupPath & "\Quickload\Icons"
        Else
            Main.SaveFile.InitialDirectory = Application.StartupPath
        End If
        Main.SaveFile.FileName = ""
        Main.SaveFile.ShowDialog()

        If Main.SaveFile.FileName = "" Then Exit Sub

        Using writer As XmlWriter = XmlWriter.Create(Main.SaveFile.FileName, settings)
            writer.WriteStartDocument()
            writer.WriteComment("This is a saved On-Screen button configuration for TUGBot." _
                                 & vbNewLine & "If you wish to edit this file, please load it in TUGBot.")
            writer.WriteStartElement("Buttons") 'Start buttons
            'name
            For Each b As ButtonStruct In ButtonsList.Items
                writer.WriteStartElement("Button") 'Start button
                writer.WriteStartAttribute("Name") : writer.WriteValue(b.Name) : writer.WriteEndAttribute()
                writer.WriteStartAttribute("Text") : writer.WriteValue(b.Text) : writer.WriteEndAttribute()
                writer.WriteStartAttribute("CommandL") : writer.WriteValue(b.LeftClickCommand) : writer.WriteEndAttribute()
                writer.WriteStartAttribute("CommandR") : writer.WriteValue(b.RightClickCommand) : writer.WriteEndAttribute()
                writer.WriteStartAttribute("ItemUnderID") : writer.WriteValue(b.UnderlayID) : writer.WriteEndAttribute()
                writer.WriteStartAttribute("XPos") : writer.WriteValue(b.LocationX) : writer.WriteEndAttribute()
                writer.WriteStartAttribute("YPos") : writer.WriteValue(b.LocationY) : writer.WriteEndAttribute()
                writer.WriteStartAttribute("Color") : writer.WriteValue(b.TextColor.Name) : writer.WriteEndAttribute()
                writer.WriteStartAttribute("CanDrag") : writer.WriteValue(BoolToInt(b.Draggable)) : writer.WriteEndAttribute()


                For Each O As ItemDisplay In b.OverLays
                    writer.WriteStartElement("Overlay") 'Start Overlay
                    writer.WriteStartAttribute("ID") : writer.WriteValue(O.DisplayID) : writer.WriteEndAttribute()
                    writer.WriteStartAttribute("X") : writer.WriteValue(O.PosOffsetX) : writer.WriteEndAttribute()
                    writer.WriteStartAttribute("Y") : writer.WriteValue(O.PosOffsetY) : writer.WriteEndAttribute()
                    writer.WriteEndElement() 'End overlay
                Next
                writer.WriteEndElement() 'End button
            Next

            writer.WriteEndElement() 'End buttons
            writer.WriteEndDocument()
        End Using
    End Sub

    Public Sub LoadButtons(ByVal Filepath As String)
        Dim Document As New XmlDocument

        Document.Load(Filepath)
        Dim Btns As XmlNodeList = Document.GetElementsByTagName("Button")
        Dim Items As XmlNodeList
        For Each Node As XmlElement In Btns
            Dim TempBut As New ButtonStruct("")
            TempBut.Name = Node.GetAttribute("Name")
            TempBut.Text = Node.GetAttribute("Text")
            TempBut.LeftClickCommand = Node.GetAttribute("CommandL")
            TempBut.RightClickCommand = Node.GetAttribute("CommandR")
            TempBut.UnderlayID = Node.GetAttribute("ItemUnderID")
            'Overlays
            Items = Node.GetElementsByTagName("Overlay")
            For Each OverNode As XmlElement In Items
                Dim OverLay As New ItemDisplay
                OverLay.DisplayID = OverNode.GetAttribute("ID")
                OverLay.PosOffsetX = OverNode.GetAttribute("X")
                OverLay.PosOffsetY = OverNode.GetAttribute("Y")
                TempBut.OverlayItems.Add(OverLay)
            Next
            TempBut.LocationX = Node.GetAttribute("XPos")
            TempBut.LocationY = Node.GetAttribute("YPos")
            TempBut.TextColor = Color.FromName(Node.GetAttribute("Color"))
            TempBut.Draggable = IntToBool(Node.GetAttribute("CanDrag"))
            ButtonsList.Items.Add(TempBut)
        Next
    End Sub

    Public Sub PrintButtonTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintButtonTimer.Tick
        If TClient.Status <> 8 Then Exit Sub
        Try
            If ButtonsEnabled Then
                TClient.Hook.AddItems(Buttons, ButtonSize, True)
            Else
                TClient.Hook.ClearItems()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub NewIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewIcon.Click
        Dim newcount As Integer = 0
        For Each b As ButtonStruct In ButtonsList.Items
            If b.Name.StartsWith("New") Then
                newcount += 1
            End If
        Next

        ButtonsList.DisplayMember = "Name"
        Dim Button As ButtonStruct
        If newcount = 0 Then
            Button = CType(ButtonsList.Items(ButtonsList.Items.Add(New ButtonStruct("New"))), ButtonStruct)
        Else
            Button = CType(ButtonsList.Items(ButtonsList.Items.Add(New ButtonStruct("New " & newcount))), ButtonStruct)
        End If
        IconProperties.SelectedObject = Button
        ButtonsList.SelectedItem = Button
    End Sub

    Private Sub ButtonList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonsList.SelectedIndexChanged
        ButtonsList.DisplayMember = "Name"
        ButtonsList.Refresh()
        If ButtonsList.SelectedItem IsNot Nothing Then
            IconProperties.SelectedObject = ButtonsList.SelectedItem
        End If
    End Sub

    Private Sub IconProperties_PropertyValueChanged(ByVal s As System.Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles IconProperties.PropertyValueChanged
        If ButtonsList.SelectedIndex = -1 Then IconProperties.SelectedObject = Nothing : Exit Sub
        ButtonsList.Items(ButtonsList.SelectedIndex) = CType(IconProperties.SelectedObject, ButtonStruct)
        ButtonsList.DisplayMember = "Name"
        ButtonsList.Refresh()
    End Sub
End Class