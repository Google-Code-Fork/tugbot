Imports System.Runtime.InteropServices
Imports System.ComponentModel
Public Class Ally
    Public Enum AllyHealingType
        None
        UHRune
        IHRune
        ExuraSio
    End Enum

    Private _name As String

    Private _HealAtPercent As Byte = 0
    Private _HealAtMana As Short = 140
    Private _HealType As AllyHealingType = AllyHealingType.None


    Public Sub New(ByVal name As String)
        Me._name = name
    End Sub

#Region "Methods"
    Public Overrides Function ToString() As String
        Return _name
    End Function

    Public Function DisplayName() As String
        Return Me.ToString
    End Function
#End Region

#Region "Healer"
    <Description("When the Allys health drops below this percent, TUGBot will try and heal it if enabled."), _
    Category("Ally Healer")> _
    Public Property HealPercent() As Byte
        Get
            Return _HealAtPercent
        End Get
        Set(ByVal value As Byte)
            If value > 0 And value < 100 Then
                _HealAtPercent = value
            End If
        End Set
    End Property

    <Description("Only heal the Ally if your mana is above this amount. This is only used for the ExuraSio healing type."), _
    Category("Ally Healer")> _
    Public Property HealMana() As Short
        Get
            Return _HealAtMana
        End Get
        Set(ByVal value As Short)
            _HealAtMana = value
        End Set
    End Property

    <Description("Determine how the Ally will be healed."), _
    Category("Ally Healer")> _
    Public Property HealType() As AllyHealingType
        Get
            Return _HealType
        End Get
        Set(ByVal value As AllyHealingType)
            _HealType = value
        End Set
    End Property
#End Region

End Class

Public Class Enemy

    Private _name As String
End Class
