Public Class AdrPlayer
    Public Experience As Integer
    Public extraOffset As Integer = 0
    Public Z As Integer
    Public HeadSlot As Integer
    Public Target As Integer

    'Soul, Stamina and Capacity
    Public Soul As Integer = Experience - 28
    Public Stamina As Integer = Experience - 32
    Public Capacity As Integer = Experience - 36

    'Skills
    Public Axe As Integer = Experience - 64
    Public Sword As Integer = Experience - 68
    Public Club As Integer = Experience - 72
    Public Fist As Integer = Experience - 76
    Public Shield As Integer = Experience - 56
    Public Distance As Integer = Experience - 60
    Public Fishing As Integer = Experience - 60


    'Level, Magic Level, Id and status
    Public Status As Integer = Experience - 108
    Public Level As Integer = Status + 104
    Public Id As Integer = Experience + 12
    Public MagicLevel As Integer = Experience - 8
    'Health and Mana
    Public Health As Integer = Status + 116
    Public MaxHealth As Integer = Status + 112
    Public Mana As Integer = Status + 88
    Public MaxMana As Integer = Status + 84
    'Position, Goto Position
    Public X As Integer = Z + 8
    Public Y As Integer = Z + 4
    Public GotoX As Integer = Experience + 80
    Public GotoY As Integer = Experience + 76
    Public GotoZ As Integer = Experience + 72


    Public Sub Initialize()
        'Soul, Stamina and Capacity
        Soul = Experience - 28 - extraOffset
        Stamina = Experience - 32 - extraOffset
        Capacity = Experience - 36 - extraOffset

        'Skills
        Axe = Experience - 64 - extraOffset
        Sword = Experience - 68 - extraOffset
        Club = Experience - 72 - extraOffset
        Fist = Experience - 76 - extraOffset
        Shield = Experience - 56 - extraOffset
        Distance = Experience - 60 - extraOffset
        Fishing = Experience - 60 - extraOffset

        MaxMana = Experience - 24 - extraOffset
        Mana = Experience - 20 - extraOffset

        'Level, Magic Level, Id and status
        Status = Experience - 108 - extraOffset
        Health = Experience + 8 + extraOffset
        MaxHealth = Experience + 4 + extraOffset

        MagicLevel = Experience - 8 - extraOffset
        Level = Experience - 4 - extraOffset

        Id = Experience + 12 + extraOffset
        'Health and Mana
        'Position, Goto Position
        X = Z + 8
        Y = Z + 4
        GotoX = Experience + 80 + extraOffset
        GotoY = Experience + 76 + extraOffset
        GotoZ = Experience + 72 + extraOffset
    End Sub
End Class
