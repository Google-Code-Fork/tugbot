Imports System.IO

Module Skinner

#Region "Setting ths tyles"
    Public Sub ApplySkin(ByVal BackgroundImage As Bitmap, ByVal FormBackgroundColor As Color, ByVal ControlBackgroundColor As Color, ByVal FormOpacity As Byte, ByVal ControlOpacity As Byte, ByVal TextColor As Color)

        Dim C As Color = Color.FromArgb(ControlOpacity, ControlBackgroundColor.R, _
                                        ControlBackgroundColor.G, ControlBackgroundColor.B)

        Main.BackgroundImage = BackgroundImage
        Main.BackColor = Color.FromArgb(FormBackgroundColor.R, _
                                    FormBackgroundColor.G, FormBackgroundColor.B)
        Main.Opacity = CalculatePercent(1, 255, FormOpacity)
        SetControlBackgrounds(Main, C, TextColor, BackgroundImage)

        For Each fi As FormInfo In Forms
            fi.Form.BackgroundImage = BackgroundImage
            fi.Form.BackColor = Color.FromArgb(FormBackgroundColor.R, _
                                        FormBackgroundColor.G, FormBackgroundColor.B)
            fi.Form.Opacity = CalculatePercent(1, 255, FormOpacity)
            SetControlBackgrounds(fi.Form, C, TextColor, BackgroundImage)
        Next
    End Sub

    Private Sub SetControlBackgrounds(ByVal form As System.Windows.Forms.Form, ByVal colorB As Color, ByVal colorT As Color, ByVal bg As Bitmap)

        For Each control As Control In form.Controls

            Try
                CType(control, Button).FlatStyle = FlatStyle.Flat
            Catch ex As Exception
            End Try

            Try
                If control.GetType() Is (New TabControl()).GetType Then
                    For Each T As TabPage In control.Controls
                        T.ForeColor = colorT
                        T.BackColor = colorB
                    Next
                End If
            Catch ex As Exception
            End Try

            Try
                control.ForeColor = colorT
                control.BackColor = colorB
            Catch ex As Exception
            End Try

            SetControlColors(control, colorB, colorT, bg)
        Next
    End Sub

    Private Sub SetControlColors(ByVal parentControl As Control, ByVal colorB As Color, ByVal colorT As Color, ByVal bg As Bitmap)
        For Each control As Control In parentControl.Controls
            Try
                control.ForeColor = colorT
            Catch ex As Exception
            End Try

            Try
                control.BackColor = Color.Transparent
            Catch
                control.BackColor = Color.FromArgb(colorB.R, colorB.G, colorB.B)
            End Try

            Try
                CType(control, Button).FlatStyle = FlatStyle.Flat
            Catch ex As Exception
            End Try

            If control.GetType() Is (New TabControl()).GetType Then
                For Each T As TabPage In CType(control, TabControl).TabPages
                    T.ForeColor = colorT
                    T.BackColor = colorB
                    T.Update()
                Next
            End If


            SetControlColors(control, colorB, colorT, bg)
        Next
    End Sub
#End Region

#Region "Loading the files"
    Public Sub LoadSkinFromFilePrototype(ByVal Path As String)
        Dim FS As New FileStream(Path, FileMode.Open)
        Dim array As Byte() = New Byte(FS.Length) {}

        'Form Opacity
        Dim FormOpacity(1) As Byte
        FS.Read(FormOpacity, 0, 1)

        'From background color
        FS.Read(array, 0, 3)
        Dim FormBackColor As Color = Color.FromArgb(array(0), array(1), array(2))

        'Control Opacity
        Dim ControlOpacity(1) As Byte
        FS.Read(ControlOpacity, 0, 1)

        'Control background color
        FS.Read(array, 0, 3)
        Dim ControlBackgroundColor As Color = Color.FromArgb(array(0), array(1), array(2))

        'Text color
        FS.Read(array, 0, 3)
        Dim TextColor As Color = Color.FromArgb(array(0), array(1), array(2))

        'Background image
        FS.Read(array, 0, FS.Length - FS.Position)
        Dim BackgroundImage As Image = BytesToBitmap(array)

        'Set It
        ApplySkin(BackgroundImage, FormBackColor, ControlBackgroundColor, FormOpacity(0), ControlOpacity(0), TextColor)


        FS.Close()
        FS.Dispose()
    End Sub


    Public Function BytesToBitmap(ByVal Imgarray As Byte()) As Bitmap
        Dim TempArray(2) As Byte
        Dim Pos As UInteger = 0
        'Size X
        Array.Copy(Imgarray, Pos, TempArray, 0, 2)
        Pos += 2
        Dim SizeX As UShort = BitConverter.ToInt16(TempArray, 0)
        'Size Y
        Array.Copy(Imgarray, Pos, TempArray, 0, 2)
        Pos += 2
        Dim SizeY As UShort = BitConverter.ToInt16(TempArray, 0)



        'The image
        Dim NewBmp As New Bitmap(SizeX, SizeY, System.Drawing.Imaging.PixelFormat.Format32bppArgb)


        For x = 0 To SizeX - 1
            For y = 0 To SizeY - 1
                NewBmp.SetPixel(x, y, _
                Color.FromArgb(Imgarray(Pos), Imgarray(Pos + 1), Imgarray(Pos + 2), Imgarray(Pos + 3)))
                Pos += 4
            Next
        Next

        Return NewBmp
    End Function
#End Region
End Module
