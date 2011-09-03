Public Module GlobalVariables
    Public Structure FormInfo
        Public Form As Form
        Public Name As String

        Public Sub New(ByVal Name As String, ByVal f As Form)
            Me.Name = Name
            Me.Form = f
        End Sub
    End Structure

    Public WithEvents TClient As Client
    Public TAddresses As Addresses
    Public TPlayer As Self

    Public AutoUpdatesEnabled As Boolean = False
    Public StartSkin As String = ""

    Public autoStack As Boolean = False

    Public Forms As New List(Of FormInfo)

    Public Hotkey As New Hotkeys

    Public Buttons As New List(Of ButtonStruct)
    Public ButtonIndex As Short
    Public ButtonSize As Short
    Public ButtonsEnabled As Boolean

    Public Healing As Boolean = False

    Public ShopWindowOpen As Boolean = False

    Public ControlPressed As Boolean = False
    Public ShiftPressed As Boolean = False

    Public MouseLeftDown As Boolean = False

    Public HooksInjected As Boolean = False

    Public SettingNames(0 To 7) As String

    'Public Looting As Boolean = False
    Private LooterStarted As Integer
    Private LooterTime As Integer
    Public LastBodyOpen As Integer
    Public Function CurrentlyLooting() As Boolean

        If GetTickCount() - TClient.DelayStart < TClient.DelayTime Then
            Return True
        Else
            Return CavebotLooter.Bodies.Count <> 0
        End If
    End Function

    Public Sub StartLooterDelay()
        If CurrentlyLooting() Then
            IncrementLooterDelay(750)
        Else
            LooterTime = 750
            LooterStarted = GetTickCount
        End If
    End Sub

    Public Sub IncrementLooterDelay(ByVal MS As Integer)
        LooterTime += MS
    End Sub

    Public CurrentStrikeSpell As String = "none"
    Public CurrentStrikeMana As Integer = 0
    Public CurrentStrikeHealthPercent As Integer = 0
    Public CurrentRuneID As Short = 0
    Public CurrentRuneHealth As Integer = 0
    Public RuneStrikeType As MagicAttackType = MagicAttackType.None

    Public PipeError As String = "TUGBot has failed to properly initialize the pipe connection between itself and the DLL injected into Tibia." & vbNewLine & _
                           "This could be caused by many different conflicts, please make sure of the following: " & vbNewLine & _
                           "1. If your running Vista or Windows 7, make sure Tibia is run as admin (Rightclick->Run As..->Administrator)" & vbNewLine & _
                           "2. Make sure you dont not have any anti-virus software blocking DLL injection." & vbNewLine & _
                            vbNewLine & _
                            "If this problem continues and your running Windows 7 or Windows Vista, try running TUGBot and Tibia in compatibility mode for Windows XP"

    Public BotStartTime As Integer
    Public LastInjectCheck As Integer = 0
End Module
