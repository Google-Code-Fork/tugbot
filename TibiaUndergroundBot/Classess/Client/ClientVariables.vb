Partial Public Class Client
    Public Paused As Boolean = False

    Public DelayStart As Integer = 0
    Public DelayTime As Integer = 0


    Public Profile As PlayerProfile

#Region "Spell timer variables"
    Public LastHasteType As Integer
    Public LastSaidHaste As New Date(1, 1, 1)
    Public LastSaidInvis As New Date(1, 1, 1)
    Public LastSaidMShield As New Date(1, 1, 1)
#End Region

#Region "Replace Trees, OpenPitfalls, Walk on fields"
    Public TreesDone As Boolean = False
    Public PitsDone As Boolean = False
    Public CanWalkOnFields As Boolean = False
#End Region


End Class
