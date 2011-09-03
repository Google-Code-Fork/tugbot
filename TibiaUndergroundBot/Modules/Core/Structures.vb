Imports System.Runtime.InteropServices
Public Module Structures
    'Containers

    Public Structure Item
        Dim Id As Short
        Dim Count As Short
    End Structure

    Public Structure Skills
        Dim Axe As Integer
        Dim Sword As Integer
        Dim Club As Integer
        Dim Shield As Integer
        Dim Distance As Integer
        Dim Fishing As Integer
        Dim Fist As Integer
    End Structure

    Public Structure TileObject
        Dim Id As Integer
        Dim Data As Integer
    End Structure

    Public Structure Rect
        Public x1 As Integer
        Public y1 As Integer
        Public x2 As Integer
        Public y2 As Integer
    End Structure


    Public Structure Help
        Public IsLadder As Integer
        Public IsSewer As Integer
        Public IsDoor As Integer
        Public IsDoorWithLock As Integer
        Public IsRopeSpot As Integer
        Public IsSwitch As Integer
        Public IsStairs As Integer
        Public IsMailbox As Integer
        Public IsDepot As Integer
        Public IsTrash As Integer
        Public IsHole As Integer
        Public HasSpecialDescription As Integer
        Public IsReadOnly As Integer
    End Structure


    Public Structure DatItems
        Public Width As Integer
        Public Height As Integer
        Public Unknown1 As Integer
        Public Layers As Integer
        Public PatternX As Integer
        Public PatternY As Integer
        Public PatternDepth As Integer
        Public Phase As Integer
        Public Sprites As Integer
        Public Flags As Integer
        Public WalkSpeed As Integer
        Public TextLimit As Integer
        ' If it is readable/writable
        Public LightRadius As Integer
        Public LightColor As Integer
        Public ShiftX As Integer
        Public ShiftY As Integer
        Public WalkHeight As Integer
        Public Automap As Integer
        ' Minimap color
        Public LensHelp As Integer
        Public Help As Help
    End Structure

    Public Structure DisplayItem
        Public id As Integer
        Public text As String
        Public color As System.Drawing.Color
    End Structure

    Public Structure KBDLLHOOKSTRUCT
        Public vkCode As Integer
        Public scancode As Integer
        Public flags As Integer
        Public time As Integer
        Public dwExtraInfo As Integer
    End Structure

    Public Structure Location
        Public x As Integer
        Public y As Integer
        Public z As Byte
        Public Stack As Byte

        Public Function IsAdjacentToo(ByVal pos As Location)
            Return Math.Abs(Me.x - pos.x) <= 1 _
            AndAlso Math.Abs(Me.y - pos.y) <= 1 AndAlso Me.z = pos.z
        End Function

        Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal z As Byte, Optional ByVal stack As Byte = 0)
            Me.x = x
            Me.y = y
            Me.z = z
            Me.stack = stack
        End Sub
    End Structure

    Public Structure ULocation
        Dim x As Integer
        Dim y As Integer
        Dim z As Byte

        Public Function IsAdjacentToo(ByVal pos As Location)
            Return Math.Abs(Me.x - pos.x) <= 1 _
            AndAlso Math.Abs(Me.y - pos.y) <= 1 AndAlso Me.z = pos.z
        End Function

        Public Function ToLocation() As Location
            Return New Location(CInt(x), CInt(y), CByte(z))
        End Function

        Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal z As Byte)
            Me.x = x
            Me.y = y
            Me.z = z
        End Sub
    End Structure

    Public Structure Hotkeys
        Public Hotkey As HotkeyStruct()
    End Structure
End Module

Public Class LockedCharacter
    Public enabled = False
    Public Time As String
    Public Name As String
    Public Vocation As String
    Public Level As Integer
    Public Guild As String

    Public VictimName As String
    Public VictimLevel As String
    Public VictimVocation As String
    Public VictimGuild As String
End Class

Public Class CompareCharacter
    Public Name As String
    Public Level As String
End Class


Public Class DisplayText
    Public Name As String
    Public text As String
    Public X As Integer
    Public Y As Integer
    Public Align As TextAlign
    Public color As System.Drawing.Color

    Public Enum TextAlign As Byte
        Center = 1
        Right = 2
        Left = 0
    End Enum

    Public Sub New(ByVal name As String, ByVal text As String, ByVal x As Integer, ByVal y As Integer, ByVal color As System.Drawing.Color)
        Me.New(name, text, x, y, color, TextAlign.Left)
    End Sub

    Public Sub New(ByVal name As String, ByVal text As String, ByVal x As Integer, ByVal y As Integer, ByVal color As System.Drawing.Color, ByVal align As TextAlign)
        Me.Name = name
        Me.text = text
        Me.X = x
        Me.Y = y
        Me.color = color
        Me.Align = align
    End Sub
End Class

Public Class ClientListedObject
    Private sDisplay As String
    Private sValue As Integer
    Public Property Display() As String
        Get
            Return Me.sDisplay
        End Get
        Set(ByVal value As String)
            Me.sDisplay = value
        End Set
    End Property
    Public Property Value() As Integer
        Get
            Return Me.sValue
        End Get
        Set(ByVal value As Integer)
            Me.sValue = value
        End Set
    End Property

    Public Sub New(ByVal sDisplay As String, ByVal sValue As Integer)
        Me.Display = sDisplay
        Me.Value = sValue
    End Sub

    Public Overrides Function ToString() As String
        Return sDisplay
    End Function
End Class

'Public Class NavPosition
'    Public Name As String
'    Public X As Int32
'    Public Y As Int32
'    Public Z As Byte

'    Public ReadOnly Property Location() As Location
'        Get
'            Return New Location(X, Y, Z)
'        End Get
'    End Property
'End Class