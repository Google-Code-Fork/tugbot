Imports System
Imports System.Collections.Generic
Imports System.Text

Imports System.IO

''' <summary>
''' Contains the method to merge tibia maps.
''' </summary>
Public Module MapMerger
    '
    '        Map File Format
    '       
    '        The first 65536 bytes of the map file is the graphical portion of the map.
    '        The next 65536 bytes appears to be the map that is used for path finding.
    '       
    '        The next 4 bytes is the number of markers on the map.
    '       
    '        The markers than follow here. If there are no markers than nothing
    '        is beyond the marker count bytes.
    '       
    '       
    '        Marker Format
    '       
    '        The first byte appears to be the x position
    '        The second byte appears to be the map tile it is in on the x axis
    '        Two blank bytes
    '       
    '        The next byte appears to the y position
    '        The next byte appears to be the map tile it is in on the y axis
    '        Two blank bytes
    '       
    '        The next 4 bytes are the image id of the image
    '       
    '        The next 2 bytes are the size of the string that fallows
    '        The string of text for the marker
    '        
    Public Function Merge(ByVal outputDirectory As String, ByVal ParamArray inputDirectories As String()) As Boolean
        If inputDirectories.Length < 1 Then
            Return False
        End If


        Dim files As String() = Directory.GetFiles(inputDirectories(0), "1??1????.map")

        Try
            For Each file__1 As String In files
                File.Copy(file__1, (outputDirectory & "/") + Path.GetFileName(file__1), True)
            Next
        Catch
            Return False
        End Try

        For i As Integer = 1 To inputDirectories.Length - 1
            files = Directory.GetFiles(inputDirectories(i))

            For Each file__1 As String In files
                If Not File.Exists((outputDirectory & "/") + Path.GetFileName(file__1)) Then
                    Try
                        File.Copy(file__1, (outputDirectory & "/") + Path.GetFileName(file__1))
                    Catch
                        Return False
                    End Try
                Else
                    Dim sourcefile As FileStream = Nothing
                    Dim inputfile As FileStream = Nothing
                    Dim sourcebuffered As BufferedStream = Nothing
                    Dim inputbuffered As BufferedStream = Nothing

                    Try
                        'Setup the streams and buffers
                        sourcefile = New FileStream((outputDirectory & "/") + Path.GetFileName(file__1), FileMode.Open)
                        inputfile = New FileStream(file__1, FileMode.Open)
                        sourcebuffered = New BufferedStream(sourcefile)
                        inputbuffered = New BufferedStream(inputfile)


                        'Read and write the graphical data
                        Dim source As Byte() = New Byte(65535) {}
                        sourcebuffered.Read(source, 0, 65536)

                        Dim input As Byte() = New Byte(65535) {}
                        inputbuffered.Read(input, 0, 65536)

                        Compare(source, input, 0, 65536)

                        sourcebuffered.Seek(0, SeekOrigin.Begin)
                        sourcebuffered.Write(source, 0, 65536)


                        'Read and write the pathfinding data
                        sourcebuffered.Seek(65536, SeekOrigin.Begin)
                        inputbuffered.Seek(65536, SeekOrigin.Begin)

                        sourcebuffered.Read(source, 0, 65536)
                        inputbuffered.Read(input, 0, 65536)

                        Compare(source, input, &HFA, 65536)

                        sourcebuffered.Seek(65536, SeekOrigin.Begin)
                        sourcebuffered.Write(source, 0, 65536)


                        'Read and write the marker data
                        sourcebuffered.Seek(131072, SeekOrigin.Begin)
                        Dim sourcemarkercountbytes As Byte() = New Byte(3) {}
                        sourcebuffered.Read(sourcemarkercountbytes, 0, 4)
                        Dim sourcemarkercount As Integer = BitConverter.ToInt32(sourcemarkercountbytes, 0)

                        inputbuffered.Seek(131072, SeekOrigin.Begin)
                        Dim inputmarkercountbytes As Byte() = New Byte(3) {}
                        inputbuffered.Read(inputmarkercountbytes, 0, 4)
                        Dim inputmarkercount As Integer = BitConverter.ToInt32(inputmarkercountbytes, 0)

                        Dim sourcemarkers As New List(Of Marker)()

                        For r As Integer = 0 To sourcemarkercount - 1
                            Dim data As Byte() = New Byte(11) {}
                            sourcebuffered.Read(data, 0, 12)

                            Dim stringlength As Byte() = New Byte(1) {}
                            sourcebuffered.Read(stringlength, 0, 2)
                            Dim len As Integer = BitConverter.ToUInt16(stringlength, 0)

                            Dim str As Byte() = New Byte(len - 1) {}
                            sourcebuffered.Read(str, 0, len)
                            sourcebuffered.Seek(len, SeekOrigin.Current)

                            Dim marker As New Marker(data, stringlength, str)
                            sourcemarkers.Add(marker)
                        Next

                        For r As Integer = 0 To inputmarkercount - 1
                            Dim data As Byte() = New Byte(11) {}
                            inputbuffered.Read(data, 0, 12)

                            Dim stringlength As Byte() = New Byte(1) {}
                            inputbuffered.Read(stringlength, 0, 2)
                            Dim len As Integer = BitConverter.ToUInt16(stringlength, 0)

                            Dim str As Byte() = New Byte(len - 1) {}
                            inputbuffered.Read(str, 0, len)
                            inputbuffered.Seek(len, SeekOrigin.Current)

                            Dim marker As New Marker(data, stringlength, str)

                            'Make sure we arn't copying a marker that already exists
                            If Not sourcemarkers.Contains(marker) Then
                                sourcemarkercount += 1

                                Dim write As Byte() = marker.GetBytes()
                                sourcebuffered.SetLength(sourcebuffered.Length + write.Length)
                                sourcebuffered.Seek(-write.Length, SeekOrigin.[End])
                                sourcebuffered.Write(write, 0, write.Length)
                            End If
                        Next

                        sourcebuffered.Seek(131072, SeekOrigin.Begin)
                        sourcemarkercountbytes = BitConverter.GetBytes(sourcemarkercount)
                        sourcebuffered.Write(sourcemarkercountbytes, 0, 4)
                    Catch
                        Return False
                    Finally
                        If sourcebuffered IsNot Nothing Then
                            sourcebuffered.Close()
                        End If


                        If inputbuffered IsNot Nothing Then
                            inputbuffered.Close()
                        End If

                        If sourcefile IsNot Nothing Then
                            sourcefile.Close()
                        End If

                        If inputfile IsNot Nothing Then
                            inputfile.Close()
                        End If
                    End Try
                End If
            Next
        Next

        Return True
    End Function

    Private Sub Compare(ByVal source As Byte(), ByVal input As Byte(), ByVal comp As Byte, ByVal length As Integer)
        For i As Integer = 0 To length - 1
            If source(i) = comp AndAlso input(i) <> comp Then
                source(i) = input(i)
            End If
        Next
    End Sub

    Private Structure Marker
        Public data As Byte()
        Public len As Byte()
        Public str As Byte()


        Public Sub New(ByVal data As Byte(), ByVal len As Byte(), ByVal str As Byte())
            Me.data = data
            Me.len = len
            Me.str = str
        End Sub

        Public Function GetBytes() As Byte()
            Dim bytes As Byte() = New Byte(data.Length + len.Length + (str.Length - 1)) {}

            Array.Copy(data, bytes, data.Length)
            Array.Copy(len, 0, bytes, data.Length, len.Length)
            Array.Copy(str, 0, bytes, data.Length + len.Length, str.Length)

            Return bytes
        End Function

        Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
            If obj.[GetType]() IsNot GetType(Marker) Then
                Return False
            End If

            Return Me = DirectCast(obj, Marker)
        End Function

        Public Overloads Overrides Function GetHashCode() As Integer
            Return data.Length + len.Length + str.Length
        End Function

        Public Shared Operator =(ByVal a As Marker, ByVal b As Marker) As Boolean
            If CompareBytes(a.data, b.data) AndAlso a.len Is b.len AndAlso CompareBytes(a.str, b.str) Then
                Return True
            End If

            Return False
        End Operator

        Public Shared Operator <>(ByVal a As Marker, ByVal b As Marker) As Boolean
            If Not CompareBytes(a.data, b.data) AndAlso a.len IsNot b.len AndAlso Not CompareBytes(a.str, b.str) Then
                Return True
            End If

            Return False
        End Operator

        Private Shared Function CompareBytes(ByVal data1 As Byte(), ByVal data2 As Byte()) As Boolean
            For i As Integer = 0 To data1.Length - 1
                If data1(i) <> data2(i) Then
                    Return False
                End If
            Next

            Return True
        End Function
    End Structure
End Module

