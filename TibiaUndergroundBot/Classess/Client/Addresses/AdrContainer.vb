Public Class AdrContainer
    Public Start As Integer

    Public Finish As Integer
    'Constant Distances
    Public IsOpen As Integer = 0
    Public Icon As Integer = 4
    Public Name As Integer = 16
    Public ContainerSize As Integer = 48
    Public NumberofItems As Integer = 56
    Public Item As Integer = 60
    Public ItemCount As Integer = 64
    Public Size As Integer = 492
    Public MaxContainers As Integer = 16
    Public HasParent As Integer = 52

    Public Sub Initialize()
        Finish = (Start + MaxContainers * Size)
    End Sub
End Class
