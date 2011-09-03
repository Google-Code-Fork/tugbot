Public Class AdrBattle
    Public Start As Integer

    Public Finish As Integer

    Public Characters As Integer = 250
    Public [Step] As Integer = 250

    Public Id As Integer = -4
    Public Name As Integer = 0

    Public X As Integer = 32
    Public Y As Integer = 36
    Public Z As Integer = 40

    Public IsWalking As Integer = 72
    Public Direction As Integer = 76

    Public Outfit As Integer = 92
    Public OutfitHead As Integer = 96
    Public OutfitBody As Integer = 100
    Public OutfitLegs As Integer = 104
    Public OutfitFeet As Integer = 108
    Public OutfitAddon As Integer = 112
    Public BlackSquare As Integer = 128
    Public HpBar As Integer = 132
    Public Walkspeed As Integer = 136
    Public Visible As Integer = 140
    Public Skull As Integer = 144


    Public Type As Integer = -1

    Public Sub Initialize()
        Finish = Start + Characters * [Step]
    End Sub

End Class

