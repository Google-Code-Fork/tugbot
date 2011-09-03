Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Public Class RegistrationCrypto
    Private Key As String
    Private IV As String
    Public Sub New(ByVal key As String, ByVal iv As String)
        Me.Key = key
        Me.IV = iv
    End Sub

    Public Function Encrypt(ByVal Text As String) As String
        Try
            Dim sa As SymmetricAlgorithm = SymmetricAlgorithm.Create("TripleDES")
            sa.Key = Convert.FromBase64String(Key)
            sa.IV = Convert.FromBase64String(IV)
            sa.Mode = CipherMode.CBC
            sa.Padding = PaddingMode.Zeros

            Dim inputByteArray() As Byte = Encoding.ASCII.GetBytes(Text)
            Dim mS As MemoryStream = New MemoryStream()

            Dim trans As ICryptoTransform = sa.CreateEncryptor
            Dim buf() As Byte = New Byte(2048) {}
            Dim cs As CryptoStream = New CryptoStream(mS, trans, CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()

            Return strToHex(Convert.ToBase64String(mS.ToArray, Base64FormattingOptions.None))
        Catch
            Return ""
        End Try
    End Function

    Public Function Decrypt(ByVal Text As String) As String
        Try
            'initialize our key
            Dim tripleDESKey As SymmetricAlgorithm = SymmetricAlgorithm.Create("TripleDES")
            tripleDESKey.Key = Convert.FromBase64String(Key)
            tripleDESKey.IV = Convert.FromBase64String(IV)
            tripleDESKey.Mode = CipherMode.CBC
            tripleDESKey.Padding = PaddingMode.Zeros
            'load our encrypted value into a memory stream
            Dim encryptedValue As String = hexToStr(Text)
            Dim encryptedStream As MemoryStream = New MemoryStream()
            encryptedStream.Write(Convert.FromBase64String(encryptedValue), 0, Convert.FromBase64String(encryptedValue).Length)
            encryptedStream.Position = 0

            'set up a stream to do the decryption
            Dim cs As CryptoStream = New CryptoStream(encryptedStream, tripleDESKey.CreateDecryptor, CryptoStreamMode.Read)
            Dim decryptedStream As MemoryStream = New MemoryStream()
            Dim buf() As Byte = New Byte(2048) {}
            Dim bytesRead As Integer

            'keep reading from encrypted stream via the crypto stream
            'and store that in the decrypted stream
            bytesRead = cs.Read(buf, 0, buf.Length)
            While (bytesRead > 0)
                decryptedStream.Write(buf, 0, bytesRead)
                bytesRead = cs.Read(buf, 0, buf.Length)
            End While

            'reassemble the decrypted stream into a string	
            Dim decryptedValue As String = Encoding.ASCII.GetString(decryptedStream.ToArray())

            Return decryptedValue.ToString()
        Catch
            Return ""
        End Try
    End Function
End Class
