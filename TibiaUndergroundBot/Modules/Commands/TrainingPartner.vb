Imports System.Runtime.InteropServices
Imports System.ComponentModel
Public Class TrainingPartner
    Public ID As UInt32
    Public Name As String
    Public Num As Integer

    Private _StopAttackAt As Byte = 10
    Private _NeedsForAttack As Byte = 80
    Private _FightMode As AttackMode = AttackMode.FullDefense
    Private _Kill As Boolean = False


    Public Sub New(ByVal Name As String, ByVal ID As UInt32, ByVal num As Integer)
        Me.ID = ID
        Me.Name = Name
        Me.Num = num
    End Sub

    Public Overrides Function ToString() As String
        Return "[TP " & Num & "] " & Name
    End Function


    Public Function DisplayName() As String
        Return Me.ToString
    End Function


    <Description("When the creatures health drops below this percent, TUGBot will try and switch to another target."), _
    Category("Settings")> _
    Public Property StopHealth() As Byte
        Get
            Return _StopAttackAt
        End Get
        Set(ByVal value As Byte)
            If value > 0 And value < 100 Then
                _StopAttackAt = value
            End If
        End Set
    End Property

    <Description("TUGBot will not try and attack this creature until its health is above this percent."), _
   Category("Settings")> _
   Public Property StartHealth() As Byte
        Get
            Return _NeedsForAttack
        End Get
        Set(ByVal value As Byte)
            If value > 0 And value < 100 Then
                _NeedsForAttack = value
            End If
        End Set
    End Property

    '<Description("TUGBot will put you in this fighting stance while attacking this creature."), _
    'Category("Settings")> _
    'Public Property FightMode() As AttackMode
    '    Get
    '        Return _FightMode
    '    End Get
    '    Set(ByVal value As AttackMode)
    '        MsgBox("Fightmode is currently disabled.")
    '        Exit Property
    '        If value >= 1 And value <= 3 Then
    '            _FightMode = value
    '        End If
    '    End Set
    'End Property

    <Description("If this is set to ""true"" then TUGBot will kill this creature if there is no others to switch to when ""StopHealth"" is met."), _
    Category("Settings")> _
    Public Property Kill() As Boolean
        Get
            Return _Kill
        End Get
        Set(ByVal value As Boolean)
            _Kill = value
        End Set
    End Property

End Class
