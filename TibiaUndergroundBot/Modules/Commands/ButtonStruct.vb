Imports System.Runtime.InteropServices
Imports System.ComponentModel
Public Class ItemDisplay
    Private ID As Short
    Private pOffsetX As Short
    Private pOffsety As Short
    Private pCount As Byte = 1

    Public Sub New()
        ID = 100
    End Sub

    Public Overrides Function ToString() As String
        Return "ID: " & Me.ID & ". X: " & Me.PosOffsetX & ". Y: " & Me.PosOffsetY
    End Function

#Region "Methods"
    Public Function GetPositiveOffsetRegionX() As Integer
        If ID > 0 And pOffsetX > 0 Then
            Return pOffsetX
        Else
            Return 0
        End If
    End Function

    Public Function GetPositiveOffsetRegionY() As Integer
        If ID > 0 And pOffsety > 0 Then
            Return pOffsety
        Else
            Return 0
        End If
    End Function

    Public Function GetNegativeOffsetRegionX() As Integer
        If ID > 0 And pOffsetX < 0 Then
            Return pOffsetX
        Else
            Return 0
        End If
    End Function

    Public Function GetNegativeOffsetRegionY() As Integer
        If ID > 0 And pOffsety < 0 Then
            Return pOffsety
        Else
            Return 0
        End If
    End Function
#End Region

    <Description("The X offset at which the this item is positioned at."), _
    Category("Location")> _
   Public Property PosOffsetX() As Short
        Get
            Return pOffsetX
        End Get
        Set(ByVal value As Short)
            If value >= 0 And value <= 32 Then
                Me.pOffsetX = value
            ElseIf value <= 0 And value >= -32 Then
                Me.pOffsetX = value
            ElseIf value > 32 Then
                Me.pOffsetX = 32
            ElseIf value < -32 Then
                Me.pOffsetX = -32
            Else
                Me.pOffsetX = 0
            End If
        End Set
    End Property
    <Description("The Y offset at which the this item is positioned at."), _
     Category("Location")> _
    Public Property PosOffsetY() As Short
        Get
            Return pOffsety
        End Get
        Set(ByVal value As Short)
            If value >= 0 And value <= 32 Then
                Me.pOffsety = value
            ElseIf value <= 0 And value >= -32 Then
                Me.pOffsety = value
            ElseIf value > 32 Then
                Me.pOffsety = 32
            ElseIf value < -32 Then
                Me.pOffsety = -32
            Else
                Me.pOffsety = 0
            End If
        End Set
    End Property

    <Description("The itemID entered here will be the one that is shown."), _
    Category("Display")> _
    Public Property DisplayID() As String
        Get
            Return ID
        End Get
        Set(ByVal value As String)
            Dim ItemID As Short = FormatItem(value)
            If ItemID > 0 And ItemID < 32767 Then
                If ItemID >= 100 And ItemID <= 9000 Then
                    Me.ID = ItemID
                ElseIf ItemID < 100 Then
                    Me.ID = 100
                ElseIf ItemID > 9000 Then
                    Me.ID = 9000
                End If
            End If
        End Set
    End Property

    <Description("The Count of the item to be shown."), _
   Category("Display")> _
   Public Property Count() As Byte
        Get
            Return pCount
        End Get
        Set(ByVal value As Byte)
            If value = 0 Then value = 1
            pCount = value
        End Set
    End Property
End Class

Public Class ButtonStruct
    Private pName As String
    Private pText As String
    Private pCommandL As New CommandRunner
    Private pCommandR As New CommandRunner
    Private pUnderlayID As Short
    Private pOffsetX As Short
    Private pOffsety As Short
    Private pColor As Drawing.Color
    Private pX As Integer
    Private pY As Integer
    Private pCanDrag As Integer
    Private pCount As Byte = 1

    Public DragX As UShort
    Public DragY As UShort
    Public IsDragging As Boolean
    Public HasHover As Boolean

    Public OverLays As New List(Of ItemDisplay)

#Region "Location"
    <Description("The X location of the button on screen."), _
     Category("Location")> _
    Public Property LocationX() As Integer
        Get
            Return pX
        End Get
        Set(ByVal value As Integer)
            If value >= 5 Then
                pX = value
            Else
                pX = 5
            End If
        End Set
    End Property
    <Description("The Y location of the button on screen."), _
     Category("Location")> _
    Public Property LocationY() As Integer
        Get
            Return pY
        End Get
        Set(ByVal value As Integer)
            If value >= 5 Then
                pY = value
            Else
                pY = 5
            End If
        End Set
    End Property
#End Region

#Region "Display"
    <Description("The name of the Icon. Only used for the display in the list."), _
     Category("Display")> _
    Public Property Name() As String
        Get
            Return Me.pName
        End Get
        Set(ByVal value As String)
            If value.Trim <> "" Then
                Me.pName = value
            End If
        End Set
    End Property
    <Description("The text displayed on the Icon."), _
     Category("Display")> _
    Public Property Text() As String
        Get
            Return Me.pText
        End Get
        Set(ByVal value As String)
            If value.Trim <> "" Then
                Me.pText = value
            End If
        End Set
    End Property
    <Description("The color of the text displayed on the icon."), _
    Category("Display")> _
    Public Property TextColor() As System.Drawing.Color
        Get
            Return pColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            Me.pColor = value
        End Set
    End Property
    <Description("The itemID entered here will be the one that the icon shows. This is needed."), _
    Category("Display")> _
    Public Property UnderlayID() As String
        Get
            Return pUnderlayID
        End Get
        Set(ByVal value As String)
            Dim ItemID As Short = FormatItem(value)
            If ItemID > 0 And ItemID < 32767 Then
                If ItemID >= 100 And ItemID <= 9000 Then
                    Me.pUnderlayID = ItemID
                ElseIf ItemID < 100 Then
                    Me.pUnderlayID = 100
                ElseIf ItemID > 9000 Then
                    Me.pUnderlayID = 9000
                End If
            End If
        End Set
    End Property


    <Description("The Count of the item to be shown."), _
   Category("Display")> _
   Public Property Count() As Byte
        Get
            Return pCount
        End Get
        Set(ByVal value As Byte)
            If value = 0 Then value = 1
            pCount = value
        End Set
    End Property

    <Description("Optional items can be added to the button. These isn't needed, its just incase you want more sophisticated, multi-image icons."), _
     Category("Display")> _
    Public Property OverlayItems() As List(Of ItemDisplay)
        Get
            Return OverLays
        End Get
        Set(ByVal value As List(Of ItemDisplay))
            OverLays = value
        End Set
    End Property
#End Region

#Region "Behavior"
    <Description("The command executed when the icon is Left-Clicked."), _
    Category("Behavior")> _
   Public Property LeftClickCommand() As String
        Get
            Return Me.pCommandL.CommandString
        End Get
        Set(ByVal value As String)
            Me.pCommandL.CommandString = value
        End Set
    End Property
    <Description("The command executed when the icon is Right-Clicked."), _
    Category("Behavior")> _
    Public Property RightClickCommand() As String
        Get
            Return Me.pCommandR.CommandString
        End Get
        Set(ByVal value As String)
            Me.pCommandR.CommandString = value
        End Set
    End Property
    <Description("Determines whether the Icon can be dragged around the screen using shift+click."), _
    Category("Behavior")> _
    Public Property Draggable() As Boolean
        Get
            Return pCanDrag
        End Get
        Set(ByVal value As Boolean)
            pCanDrag = value
        End Set
    End Property
#End Region

    Public Sub DisableAutos()
        pCommandL.DisableCommand()
        pCommandR.DisableCommand()
    End Sub

    Public Sub InvokeLeft()
        pCommandL.InvokeComand(Me.Name)
    End Sub

    Public Sub InvokeRight()
        pCommandR.InvokeComand(Me.Name)
    End Sub


    Public Function RegionContains(ByVal x As Integer, ByVal y As Integer) As Boolean
        For Each OverLay As ItemDisplay In OverlayItems
            If x - Me.LocationX < (ButtonSize + OverLay.GetPositiveOffsetRegionX()) Then
                If y - Me.LocationY < (ButtonSize + 5 + OverLay.GetPositiveOffsetRegionY()) Then
                    If x - Me.LocationX >= OverLay.GetNegativeOffsetRegionX() Then
                        If y - Me.LocationY >= OverLay.GetNegativeOffsetRegionY() Then
                            Return True
                        End If
                    End If
                End If
            End If
        Next

        If x - Me.LocationX < ButtonSize Then
            If y - Me.LocationY < ButtonSize + 5 Then
                If x - Me.LocationX >= 0 Then
                    If y - Me.LocationY >= 0 Then
                        Return True
                    End If
                End If
            End If
        End If

        Return False
    End Function

    Public Sub New(ByVal name As String)
        pX = 5
        pY = 5
        pText = name
        pUnderlayID = 100
        pColor = Color.Red
        pCanDrag = True
        pCommandL.CommandString = "none"
        pCommandR.CommandString = "none"
        Me.Name = name
    End Sub
End Class
