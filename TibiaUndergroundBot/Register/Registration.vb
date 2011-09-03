Imports Microsoft.Win32 'Importing the Windows Subsystem to get registry access
Imports System.IO 'Encryption,
Imports System.Text 'Encryption,
Public Class Registration
    Private Sub Registration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = GetCompName()
    End Sub


    Private Sub unlockbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unlockbutton.Click
        Dim Crypto As New RegistrationCrypto(CryptoKey, CryptoIV)

        Dim Check As String = Crypto.Decrypt(TextBox2.Text)
        Dim CompID As String = Check.Substring(0, 12)
        Dim RegistrationName As String = StripNulls(Check.Substring(12).Trim)

        If RegistrationName.ToLower = TextBox3.Text.ToLower AndAlso CompID = GetCompName() Then
            Dim oReg As RegistryKey
            oReg = Registry.LocalMachine.OpenSubKey("Software", True)
            oReg = oReg.CreateSubKey(RegSubKeyName)
            oReg.SetValue("USERID", Crypto.Encrypt(RegistrationName))
            oReg.SetValue("LOCALPATH", TextBox2.Text)
            oReg.SetValue("Enabled", "")
            MsgBox("Thank you for registering. You may now enjoy the fully-functional version of TUGBot. Please re-launch the program.", MsgBoxStyle.Information, "Registration Successful")
            Application.Exit()
            End
        Else
        End If
    End Sub
End Class