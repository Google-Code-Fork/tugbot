Imports Microsoft.Win32 'Importing the Windows Subsystem to get registry access
Imports System.IO 'Encryption,
Imports System.Text 'Encryption,
Public Class TrialForm
    Private RegistryPath As String = ""
    Private OReg As RegistryKey
    Private Crypto As RegistrationCrypto

    Private InTrial As Boolean

    Private BarSize As New System.Drawing.Size(321, 32)
    Private BarPos As New System.Drawing.Point(2, 3)
    Private UsedTrialDays As Integer
    Private OverallTrialDays As Integer = 30
    Private OverallTrialDaysDoubled As Integer = 60

    Private Sub TrialForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'FAKE REGISTER FOR BETA
        Registered = True
        NotRegistered = False
        Thirdcheck = &HFF
        CSerial = "Not Registered"
        CUser = "Not Registered"

        ClientConnector.Show()
        Me.Close()
        Exit Sub

        Crypto = New RegistrationCrypto(CryptoKey, CryptoIV)

        If OverallTrialDays <> OverallTrialDaysDoubled \ 2 Then
            MsgBox("TUGBot has been tampered with in attempt to bypass the key system!")
            End
            Application.Exit()
        End If

        OReg = Registry.LocalMachine.OpenSubKey("Software", True)
        OReg = OReg.CreateSubKey(RegSubKeyName)
        OReg = Registry.LocalMachine.OpenSubKey("Software\\" & RegSubKeyName())
        Dim OldDay As String = OReg.GetValue("UserSettings", "").ToString
        Dim OldMonth As String = OReg.GetValue("operatingsystem", "").ToString
        Dim OldYear As String = OReg.GetValue("GUID", "").ToString
        Dim RegName As String = Crypto.Decrypt(OReg.GetValue("USERID", "").ToString)
        Dim RegCode As String = OReg.GetValue("LOCALPATH", "").ToString
        Dim TrialDone As String = OReg.GetValue("Set", "").ToString

        If OldDay = "" Then
            CreateRegKeys()
        End If

        If TrialDone = "1" Then
            'FIX THIS LATER
            'InTrial = False
            'TrialExpired()
        End If

        OldDay = Crypto.Decrypt(OldDay)
        OldMonth = Crypto.Decrypt(OldMonth)
        OldYear = Crypto.Decrypt(OldYear)

        'Define global variables.
        UsedTrialDays = DiffDate(OldDay, OldMonth, OldYear)

        'Disable the continue button if the trial is over
        If UsedTrialDays > OverallTrialDays Then
            'FIX THIS LATER
            'OReg.SetValue("Set", "1")
            'TrialExpired()
        End If

        'If the clock has been reset, then lock the program
        If OldMonth <> "" Then
            Dim OldDate As New Date(ParseInteger(OldYear), ParseInteger(OldMonth), ParseInteger(OldDay))
            If Date.Compare(DateTime.Now, OldDate) < 0 Then
                MsgBox("The system clock has been reset in attempt to bypass the key system!")
                End
                Application.Exit()
            End If
        End If

        If RegCode <> "" Then
            Dim Check As String = Crypto.Decrypt(RegCode)
            Dim CompID As String = Check.Substring(0, 12)
            Dim RegistrationName As String = StripNulls(Check.Substring(12))

            If RegistrationName = RegName Then
                If CompID = GetCompName() Then
                    Registered = True
                    NotRegistered = False
                    Thirdcheck = &HFF
                    CSerial = Check
                    CUser = RegName
                    ClientConnector.Show()
                    Me.Close()
                End If
            End If
        End If

        FillBar()
    End Sub

#Region "Registry"
    Structure CurrentDate
        Dim Day As String
        Dim Month As String
        Dim Year As String
    End Structure

    Public Sub CreateRegKeys()
        Try
            Dim Current As CurrentDate
            Current.Day = Crypto.Encrypt(DateTime.Today.Day)
            Current.Month = Crypto.Encrypt(DateTime.Now.Month)
            Current.Year = Crypto.Encrypt(DateTime.Now.Year)

            OReg = Registry.LocalMachine.OpenSubKey("Software", True)
            OReg = OReg.CreateSubKey(RegSubKeyName)
            OReg.SetValue("UserSettings", Current.Day)
            OReg.SetValue("operatingsystem", Current.Month)
            OReg.SetValue("GUID", Current.Year)
            OReg.Close()
        Catch
        End Try
    End Sub

    Public Function DiffDate(ByVal OrigDay As String, ByVal OrigMonth As String, ByVal OrigYear As String)
        Try
            Dim D1 As New Date(OrigYear, OrigMonth, OrigDay)
            Return DateDiff(DateInterval.Day, D1, DateTime.Now)
        Catch
            Return 0
        End Try
    End Function
#End Region

#Region "Trial Bar"
    Private Sub TrialPeriodDisplay_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TrialPeriodDisplay.Paint
        Dim dayrem As Integer = OverallTrialDays - UsedTrialDays
        If dayrem < 0 Then dayrem = 0
        Dim DayText As String = String.Format("You have {0} days remaining on your free trial period.", dayrem)
        Dim Xpos As Integer = BarSize.Width \ 2 - _
        e.Graphics.MeasureString(DayText, Me.Font, BarSize, StringFormat.GenericDefault, Nothing, Nothing).Width \ 2
        e.Graphics.DrawString(DayText, Me.Font, Brushes.Black, Xpos + 1, 9, StringFormat.GenericDefault)
        e.Graphics.DrawString(DayText, Me.Font, Brushes.Red, Xpos, 8, StringFormat.GenericDefault)
    End Sub

    Private Sub UsedTrialBar_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UsedTrialBar.Paint
        Dim dayrem As Integer = OverallTrialDays - UsedTrialDays
        If dayrem < 0 Then dayrem = 0
        Dim DayText As String = String.Format("You have {0} days remaining on your free trial period.", dayrem)
        Dim Xpos As Integer = BarSize.Width \ 2 - _
        e.Graphics.MeasureString(DayText, Me.Font, BarSize, StringFormat.GenericDefault, Nothing, Nothing).Width \ 2
        e.Graphics.DrawString(DayText, Me.Font, Brushes.Black, Xpos + 1, 9, StringFormat.GenericDefault)
        e.Graphics.DrawString(DayText, Me.Font, Brushes.Green, Xpos, 8, StringFormat.GenericDefault)
    End Sub

    Public Sub FillBar() 'Method to fill the progress bar (nothing here to modify really...
        BarBorder.Location = New System.Drawing.Point(BarPos.X - 1, BarPos.Y - 1)
        BarBorder.Size = New System.Drawing.Size(BarSize.Width + 2, BarSize.Height + 2)
        'Check if the author made the mistake of setting the trial period days to less than 0
        If OverallTrialDays <= 0 Then
            MsgBox("TUGBot has been edited to try and bypass registration!" & vbNewLine & _
                   "TUGBot will be locked to prevent unauthorized access!", MsgBoxStyle.Critical, "Tamper Warning!")
            Application.Exit()
        End If
        'Calculate the percentage used; store it as PercentDone
        Dim PercentDone = UsedTrialDays / OverallTrialDays
        'Draw the bar

        'TrialPeriodDisplay.Size = New System.Drawing.Size((BarSize.Width - ((BarSize.Width / OverallTrialDays) * UsedTrialDays)), BarSize.Height)
        TrialPeriodDisplay.Size = BarSize

        'TrialText.Text = "You have " & (TotalDays - DaysUsed) & " days remaining on your free trial period."
        'Now that that's out of the way...
        'More code!

        'This time fill the used bar... and move it to the right place
        UsedTrialBar.Size = New System.Drawing.Size(((BarSize.Width / OverallTrialDays) * UsedTrialDays), BarSize.Height)
        'UsedTrialBar.Location = New System.Drawing.Point((BarPos.X + (BarSize.Width - ((BarSize.Width / OverallTrialDays) * UsedTrialDays))), BarPos.Y)
        UsedTrialBar.Location = BarPos
    End Sub

    Dim TrialSecondsRem As Byte = 30
    Private Sub TrialTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrialTimer.Tick
        If TrialSecondsRem = 0 Then
            unregbutton.Text = "Use Trial Version"
            unregbutton.Enabled = True
            TrialTimer.Stop()
            Exit Sub
        End If
        unregbutton.Text = "Use Trial Version (" & TrialSecondsRem & ")"
        TrialSecondsRem -= 1
    End Sub

    Public Sub TrialExpired()
        TrialTimer.Stop()
        unregbutton.Text = "Trial Expired"
        unregbutton.Enabled = False

        'TrialText.Text = "Your trial has expired!"
        UsedTrialBar.Size = BarSize
        UsedTrialBar.Location = BarPos
        TrialPeriodDisplay.Visible = False

        MsgBox("Your free TUGBot trial has ended! Please purchase the full product.")
        Application.Exit()
        End
    End Sub
#End Region

    Private Sub exitbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitbutton.Click
        Application.Exit()
    End Sub

    Private Sub unlockbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unlockbutton.Click
        Registration.ShowDialog(Me)
    End Sub

    Private Sub buybutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buybutton.Click
        System.Diagnostics.Process.Start("")
    End Sub

    Private Sub unregbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unregbutton.Click
        If InTrial = False Then
            MsgBox("TUGBot has been edited to try and bypass registration!" & vbNewLine & _
                               "TUGBot will be locked to prevent unauthorized access!", MsgBoxStyle.Critical, "Tamper Warning!")
            Application.Exit()
        End If
        Registered = False
        NotRegistered = True
        Thirdcheck = &H0

        ClientConnector.Show()
        Me.Close()
    End Sub
End Class