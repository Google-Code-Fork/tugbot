Imports System.Runtime.InteropServices
Imports System.ComponentModel
Public Class AdvancedTarget

    Private _Name As String
    Private _Priority As AttackPriority = AttackPriority.Average
    Private _FollowMode As FollowMode = FollowMode.Follow
    Private _Proximity As Byte = 7
    Private _MagicAttackType As MagicAttackType = MagicAttackType.None 'Rune, Strike, or none

    Private _StrikeSpell As String = "Exori Flam"
    Private _StrikeMana As Short = 20
    Private _StrikeHealth As Byte = 15

    Private _RuneID As String = 100
    Private _RuneHealth As Byte = 15



    Public Sub New(ByVal name As String)
        _Name = name
    End Sub

    Public Overrides Function ToString() As String
        Return _Name
    End Function

#Region "Priority"
    <Description("Creatures with the following name(s) are attacked using this configuration. To specify multiple names, use a comma."), _
    Category("General")> _
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                _Name = value
            End If
        End Set
    End Property

    <Description("This is the priority which the creatures defined by this configuration should be targetted with."), _
        Category("General")> _
        Public Property Priority() As AttackPriority
        Get
            Return _Priority
        End Get
        Set(ByVal value As AttackPriority)
            _Priority = value
        End Set
    End Property

    <Description("This is the follow mode which the creatures defined by this configuration should be targetted with."), _
       Category("General")> _
       Public Property FollowMode() As FollowMode
        Get
            Return _FollowMode
        End Get
        Set(ByVal value As FollowMode)
            _FollowMode = value
        End Set
    End Property

    <Description("This defines whether to use a rune or cast a spell on the creatures defined by this configuration. Alternatively, you can select neither."), _
      Category("General")> _
      Public Property MagicType() As MagicAttackType
        Get
            Return _MagicAttackType
        End Get
        Set(ByVal value As MagicAttackType)
            _MagicAttackType = value
        End Set
    End Property

    <Description("This is the distance from you which the creatures defined by this configuration must be within before they are attacked."), _
     Category("General")> _
     Public Property Proximity() As Integer
        Get
            Return _Proximity
        End Get
        Set(ByVal value As Integer)
            If value > 7 Then value = 7
            If value < 1 Then value = 1
            _Proximity = value
        End Set
    End Property
#End Region

#Region "Strike"
    <Description("This is the strike spell which the creatures defined by this configuration should be attacked with."), _
    Category("Spell Configuration")> _
    Public Property StrikeSpell() As String
        Get
            Return _StrikeSpell
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                _StrikeSpell = value
            End If
        End Set
    End Property

    <Description("This is the PERCENT of health the creatures defined by this must have, which dictates whether or not to use a strike spell on the creatures defined by this configuration."), _
    Category("Spell Configuration")> _
    Public Property StrikeHealth() As Byte
        Get
            Return _StrikeHealth
        End Get
        Set(ByVal value As Byte)
            If value < 100 Then
                _StrikeHealth = value
            End If
        End Set
    End Property

    <Description("This is the mana you must have to use a strike spell on the creatures defined by this configuration."), _
  Category("Spell Configuration")> _
  Public Property StrikeMana() As Short
        Get
            Return _StrikeMana
        End Get
        Set(ByVal value As Short)
            If value > 0 Then
                _StrikeMana = value
            End If
        End Set
    End Property
#End Region

#Region "Rune"
    <Description("This is the rune ID which the creatures defined by this configuration should be attacked with."), _
    Category("Rune Configuration")> _
    Public Property RuneID() As String
        Get
            Return _RuneID
        End Get
        Set(ByVal value As String)
            If FormatItem(value) <> 0 Then
                _RuneID = value
            End If
        End Set
    End Property

    <Description("This is the PERCENT of health the creatures defined by this must have, which dictates whether or not to use a rune on the creatures defined by this configuration."), _
    Category("Rune Configuration")> _
    Public Property RuneHealth() As Byte
        Get
            Return _RuneHealth
        End Get
        Set(ByVal value As Byte)
            If value < 100 Then
                _RuneHealth = value
            End If
        End Set
    End Property
#End Region

End Class
