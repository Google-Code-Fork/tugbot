Imports System.Text
Imports System.Net
Imports System.IO
Public Class Updates
#Region "find updates"
    Public Sub UpdateBot()
        ' Non-breaking space
        Try
            Dim url As String = "http://www.tibiaugbot.com/autoupdate.txt"

            Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)
            Dim response As WebResponse = request.GetResponse()
            Dim SR As New StreamReader(response.GetResponseStream)
            Dim ver As String = SR.ReadLine
            If Application.ProductVersion.Trim <> ver.Trim Then
                Dim l As String = SR.ReadLine
                UpdatesText.Text += "Current Bot Version: " & Application.ProductVersion & vbNewLine
                UpdatesText.Text += "Update Version: " & ver & vbNewLine & vbNewLine
                UpdatesText.Text += "Update Information: " & vbNewLine
                Do While l IsNot Nothing
                    UpdatesText.Text += l & vbNewLine
                    l = SR.ReadLine
                Loop
            Else
                Me.Close()
            End If
        Catch
            Me.Close()
        End Try
    End Sub

    Private Sub Updates_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UpdateBot()
    End Sub
#End Region

#Region "Install Updates"
    Public Sub InstallUpdate()
        Dim WebC As New WebClient
        WebC.DownloadFile("http://www.tibiaugbot.com/downloads/TUGBot%20Installer.msi", Application.StartupPath & "\Update.msi")
        OpenURL(Application.StartupPath & "\Update.msi")
        End
    End Sub
#End Region

    Private Sub Install_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Install.Click
        InstallUpdate()
    End Sub

    Private Sub NoInstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoInstall.Click
        Me.Close()
    End Sub
End Class