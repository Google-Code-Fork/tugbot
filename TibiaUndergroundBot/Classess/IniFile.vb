Public Class iniFile
    Dim strFilename As String

    ' Constructor, accepting a filename
    Public Sub New(ByVal Filename As String)
        strFilename = Filename
    End Sub

    ' Read-only filename property
    ReadOnly Property FileName() As String
        Get
            Return strFilename
        End Get
    End Property

#Region "Get"
    Public Function GetString(ByVal Section As String, _
    ByVal Key As String, ByVal [Default] As String) As String
        ' Returns a string from your INI file
        Dim intCharCount As Integer
        GetString = [Default]
        Dim objResult As New System.Text.StringBuilder(500)
        intCharCount = GetPrivateProfileString(Section, Key, _
        [Default], objResult, objResult.Capacity, strFilename)
        If intCharCount > 0 Then
            GetString = Left(objResult.ToString, intCharCount)
        End If
    End Function

    Public Function GetInteger(ByVal Section As String, _
    ByVal Key As String, ByVal [Default] As UInt32) As UInt32
        ' Returns an integer from your INI file
        Return GetPrivateProfileInt(Section, Key, _
        [Default], strFilename)
    End Function

    Public Function GetShort(ByVal Section As String, _
    ByVal Key As String, ByVal [Default] As UShort) As UShort
        ' Returns an integer from your INI file
        Return GetPrivateProfileInt(Section, Key, _
        [Default], strFilename)
    End Function

    Public Function GetBoolean(ByVal Section As String, _
    ByVal Key As String, ByVal [Default] As Boolean) As Boolean
        ' Returns a boolean from your INI file
        Return (GetPrivateProfileInt(Section, Key, _
        CInt([Default]), strFilename) = 1)
    End Function
#End Region

#Region "Write"
    Public Sub WriteString(ByVal Section As String, _
    ByVal Key As String, ByVal Value As String)
        ' Writes a string to your INI file
        WritePrivateProfileString(Section, Key, Value, strFilename)
        Flush()
    End Sub

    Public Sub WriteInteger(ByVal Section As String, _
    ByVal Key As String, ByVal Value As Integer)
        ' Writes an integer to your INI file
        WriteString(Section, Key, CStr(Value))
        Flush()
    End Sub

    Public Sub WriteInteger(ByVal Section As String, _
    ByVal Key As String, ByVal Value As UInt32)
        ' Writes an integer to your INI file
        WriteString(Section, Key, CStr(Value))
        Flush()
    End Sub

    Public Sub WriteShort(ByVal Section As String, _
    ByVal Key As String, ByVal Value As Short)
        ' Writes an integer to your INI file
        WriteString(Section, Key, CStr(Value))
        Flush()
    End Sub

    Public Sub WriteBoolean(ByVal Section As String, _
    ByVal Key As String, ByVal Value As Boolean)
        ' Writes a boolean to your INI file
        WriteString(Section, Key, CStr(CInt(Value)))
        Flush()
    End Sub
#End Region

    Private Sub Flush()
        ' Stores all the cached changes to your INI file
        FlushPrivateProfileString(0, 0, 0, strFilename)
    End Sub

End Class

