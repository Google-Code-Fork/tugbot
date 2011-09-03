
Imports System.Diagnostics
Public Class ClientConnector
    Private Addresses As New Dictionary(Of String, Addresses)
    Private FilePaths As New Dictionary(Of String, String)

    Private Sub ClientConnector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TrialForm.TopMost = False
        TrialForm.Hide()
        TrialForm.Dispose()


        CheckForIllegalCrossThreadCalls = False
        'Set addresses
        InitializeAddresses()

        Me.Top = My.Computer.Screen.PrimaryScreen.Bounds.Height
        Me.Left = My.Computer.Screen.PrimaryScreen.Bounds.Width - Me.Width - 5

        If Not IO.File.Exists(Application.StartupPath & "\Config.ini") Then MsgBox("Cannot find Config.ini!", MsgBoxStyle.Critical, "Error!") : End
        Dim Ini As New iniFile(Application.StartupPath & "\Config.ini")


RestartUpdates:
        Dim Update As String = Ini.GetString("TUGBot", "CheckForUpdates", "Undefined")
        If Update = "Undefined" Then
            Dim udres As MsgBoxResult = MsgBox("Would you like TUGBot to automatically connect to the internet and check for updates every time it starts?", MsgBoxStyle.YesNo)
            If udres = MsgBoxResult.Yes Then
                Ini.WriteString("TUGBot", "CheckForUpdates", "Yes")
            ElseIf udres = MsgBoxResult.No Then
                Ini.WriteString("TUGBot", "CheckForUpdates", "No")
            End If
            GoTo RestartUpdates
        ElseIf Update = "Yes" Then
            AutoUpdatesEnabled = True
            Updates.ShowDialog()
        End If

        For Each V As String In SupportedVersions
            FilePaths.Add(V, Ini.GetString("TUGBot", "ExePath" & V, "Undefined"))
            Addresses.Add(V, New Addresses(V))
            AddHandler RunButton.DropDownItems.Add(V).Click, AddressOf DropDownItemClicked
        Next

        StartSkin = Ini.GetString("TUGBot", "Skin", "Default")
        For sets As Integer = 0 To 7
            SettingNames(sets) = Ini.GetString("TUGBot", "SettingName" & sets, "Setting #" & sets + 1)
        Next

        Dim Clients As IntPtr() = LoadClients()

        If Clients.Count = 1 Then
            loadhandle = Clients(0)
            loadtime = True
        ElseIf Clients.Count > 1 Then
            For Each c As IntPtr In Clients
                ClientList.Items.Add(GetClientName(c))
            Next
        End If

        Timer1.Start()
    End Sub

#Region "Run client"
    Private Sub DropDownItemClicked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim I As ToolStripItem = CType(sender, ToolStripItem)
        If FilePaths(I.Text) = "Undefined" Then
            Dim res As MsgBoxResult = MsgBox("Path not set for Tibia version " & I.Text & ". Please select the proper file", MsgBoxStyle.OkCancel, "Client Chooser")

            If res = MsgBoxResult.Cancel Then Exit Sub
Retry:
            SelectClient.Title = "Select Client"
            SelectClient.Filter = "Executable File (*.exe)|*.exe"
            SelectClient.FileName = ""
            SelectClient.ShowDialog()

            If SelectClient.FileName = "" Then Exit Sub

            If GetFileVersion(SelectClient.FileName) = I.Text AndAlso ValidateTibiaFile(SelectClient.FileName) Then
                If Not IO.File.Exists(Application.StartupPath & "\Config.ini") Then MsgBox("Cannot find Config.ini!", MsgBoxStyle.Critical, "Error!") : End
                Dim Ini As New iniFile(Application.StartupPath & "\Config.ini")
                Ini.WriteString("TUGBot", "ExePath" & I.Text, SelectClient.FileName)

                LoadWithClientFromFile(SelectClient.FileName)
            Else
                res = MsgBox("The file you selected is either not a Tibia client or is not version " & I.Text & ".", MsgBoxStyle.RetryCancel, "Client Chooser")
                If res = MsgBoxResult.Retry Then GoTo Retry
            End If
        Else
            LoadWithClientFromFile(FilePaths(I.Text))
        End If
    End Sub
#End Region


#Region "Find/choose Client"
    Dim loadtime As Boolean = False
    Dim loadhandle As IntPtr = 0
    Dim offset As Integer = 1
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If loadtime Then
            LoadWithClient(loadhandle)
        End If

        If offset < Me.Height + 5 Then
            Me.Top -= 3
            offset += 3
            Exit Sub
        Else
            Timer1.Interval = 500
        End If

        Dim names As New List(Of String)
        Dim Clients As IntPtr() = LoadClients()
        For Each c As IntPtr In Clients
            Dim temp As String = GetClientName(c)
            names.Add(temp)
            If Not ClientList.Items.Contains(temp) Then
                ClientList.Items.Add(temp)
            End If
        Next

Redo:
        For Each n As String In ClientList.Items
            If Not names.Contains(n) Then
                ClientList.Items.Remove(n)
                GoTo Redo
            End If
        Next
    End Sub

    Private Sub ConnectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectButton.Click
        If ClientList.SelectedIndex = -1 Then MsgBox("Please select a client from the list.") : Exit Sub
        LoadWithClient(System.Diagnostics.Process.GetProcessById(ClientList.Text.Split(":")(0)).MainWindowHandle)
    End Sub

    Public Function GetClientName(ByVal c As IntPtr) As String
        Dim PID As Integer
        GetWindowThreadProcessId(c, PID)
        Dim version As String = GetWindowVersion(PID)
        Dim ret As String = PID & ": [" & version & "] "
        If ReadMemory(PID, Addresses(version).Client.Connection, 4)(0) = 8 Then
            Dim ID As Short = ReadMemoryShort(c, Addresses(version).Login.Selected)
            Dim Adr As Integer = ReadMemoryInt(c, Addresses(version).Login.CharList)
            ret += ReadMemoryString(c, Adr + Addresses(version).Login.Step_Char * ID)
        Else
            ret += "Logged Out"
        End If

        Return ret
    End Function

    Public Function LoadClients() As IntPtr()
        Dim TibiaClient As IntPtr
        Dim DesktopHwnd As IntPtr
        Dim Clients As New List(Of IntPtr)
        Dim i As Integer
        Dim PID As Integer

        DesktopHwnd = GetDesktopWindow()
        TibiaClient = 0
        i = 0
        Do
            TibiaClient = FindWindowEx(DesktopHwnd, TibiaClient, "tibiaclient", vbNullString)
            GetWindowThreadProcessId(TibiaClient, PID)
            If TibiaClient = 0 Then Exit Do
            If ArrayContains(SupportedVersions, GetWindowVersion(PID)) Then
                If Not HasInjectedDLL(PID) Then
                    Clients.Add(TibiaClient)
                End If
            End If
        Loop

        Return Clients.ToArray
    End Function

    Public Sub LoadWithClient(ByVal c As IntPtr)
        Timer1.Stop()
        Me.Visible = False
        Dim temppid As IntPtr
        GetWindowThreadProcessId(c, temppid)
        TAddresses = New Addresses(GetWindowVersion(temppid))
        TClient = New Client(c)
        Main.Show()
        Me.Close()
    End Sub

    Public Sub LoadWithClient(ByVal p As System.Diagnostics.Process)
        loadhandle = p.MainWindowHandle
        loadtime = True

        'TAddresses = New Addresses(GetWindowVersion(p.Id))
        'TClient = New Client(p.Handle, p.Id)
        'Main.Show()
        'Me.Close()
    End Sub

    Public Delegate Sub LD(ByVal p As System.Diagnostics.Process)
    Public Sub LoadWithClientFromFile(ByVal path As String)
        Me.Visible = False

        Dim startInfo As New ProcessStartInfo
        startInfo.FileName = path
        startInfo.WorkingDirectory = New IO.FileInfo(path).Directory.FullName

        Dim a As Process = System.Diagnostics.Process.Start(startInfo)

        System.Threading.Thread.Sleep(3000)
        Dim LWClient As New LD(AddressOf LoadWithClient)
        Me.Invoke(LWClient, a)
    End Sub
#End Region

#Region "Drag and hover"
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub ClientConnector_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If Windows.Forms.Cursor.Position.Y - Me.Top <= 21 Then
            drag = True 'Sets the variable drag to true.
            mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
            mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
        End If
    End Sub
    Private Sub ClientConnector_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub
    Private Sub ClientConnector_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub ClientConnector_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter, ClientList.MouseEnter, Loading.MouseEnter, RunButton.MouseEnter, ConnectButton.MouseEnter, ToolStrip1.MouseEnter
        Me.Opacity = 0.9
    End Sub

    Private Sub ClientConnector_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave, ClientList.MouseLeave, Loading.MouseLeave, RunButton.MouseLeave, ConnectButton.MouseLeave, ToolStrip1.MouseLeave
        Me.Opacity = 0.7
    End Sub

    Private Sub CloseLabel_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CloseLabel.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then End
    End Sub

    Private Sub CloseLabel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CloseLabel.MouseLeave
        Me.Opacity = 0.7
        CloseLabel.BackColor = Color.Transparent
    End Sub

    Private Sub CloseLabel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CloseLabel.MouseEnter
        Me.Opacity = 0.9
        CloseLabel.BackColor = Color.Red
    End Sub
#End Region
End Class
