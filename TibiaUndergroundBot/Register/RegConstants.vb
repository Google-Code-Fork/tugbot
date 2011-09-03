Imports Microsoft.Win32 'Importing the Windows Subsystem to get registry access
Imports System.IO 'Encryption,
Imports System.Text 'Encryption,
Module RegConstants
    Public Registered As Boolean = False
    Public NotRegistered As Boolean = True
    Public Thirdcheck As Byte = &H0

    Public CSerial As String = "Not Registered"
    Public CUser As String = "Not Registered"


    Public Function GetHDSerial() As String
        Dim disk As New System.Management.ManagementObject("Win32_LogicalDisk.DeviceID=""C:""")
        Dim diskPropertyA As System.Management.PropertyData = disk.Properties("VolumeSerialNumber")
        Return diskPropertyA.Value.ToString()
    End Function

    Public Function GetCPUId() As String
        Dim cpuInfo As String = String.Empty
        Dim temp As String = String.Empty
        Dim mc As System.Management.ManagementClass = _
            New System.Management.ManagementClass("Win32_Processor")
        Dim moc As System.Management.ManagementObjectCollection = mc.GetInstances()
        For Each mo As System.Management.ManagementObject In moc
            If cpuInfo = String.Empty Then
                cpuInfo = _
                 mo.Properties("ProcessorId").Value.ToString()
            End If
        Next
        Return cpuInfo
    End Function

    Public Function GetCompName() As String
        Dim cpu As String = GetCPUId() : cpu = cpu.Substring(cpu.Length - 4, 4)
        Dim hd As String = ReverseString(GetHDSerial().Substring(0, 4))
        Dim SerialNumber As String = ReverseString(hd & "-" & cpu(3) & hd(2) & "-" & cpu)
        Return SerialNumber
    End Function

    Public Function ReverseString(ByVal s As String) As String
        Dim len As Integer = s.Length - 1
        Dim tempstring As String
        For i = 0 To len
            tempstring += s(len - i)
        Next
        Return tempstring
    End Function

    Public Function strToHex(ByVal Str As String) As String
        Dim temp As String
        For Each b As Byte In Encoding.ASCII.GetBytes(Str.ToCharArray)
            temp += BitConverter.ToString(New Byte() {b}, 0, 1)
        Next

        Return temp
    End Function

    Public Function hexToStr(ByVal hex As String) As String
        Dim temp As String

        For i = 0 To hex.Length - 1
            temp += Chr(CInt("&H" & hex(i) & hex(i + 1)))
            i += 1
        Next

        Return temp
    End Function

    Public Function RegSubKeyName() As String
        Return hexToStr(ReverseString("34D4D4024554E4E2024766F637F6273696D4"))
    End Function

    Public Function CryptoKey() As String
        Return hexToStr(ReverseString("53E49784468467B276173683D64773A7252586D4A78524745303341415350536"))
    End Function

    Public Function CryptoIV() As String
        Return hexToStr(ReverseString("D3F685662465A424863594A6"))
    End Function

    Public Function StripNulls(ByVal s As String) As String
retry:
        For Each c As Char In s
            If c = vbNullChar Then
                s = s.Replace(c, "")
                GoTo retry
            End If
        Next

        Return s
    End Function
End Module
