Public Module Enums
#Region "Slots"
    Public Enum Slots As Byte
        None = &H0
        Head = &H1
        Amulet = &H2
        Backpack = &H3
        Body = &H4
        Legs = &H7
        Feet = &H8
        Ring = &H9
        RightHand = &H5
        LeftHand = &H6
        Ammo = &HA
    End Enum
#End Region

#Region "Magic Effects"
    Public Enum MagicEffects
        DrawBlood = &H0
        LoseEnergy = &H1
        Puff = &H2
        BlockHit = &H3
        ExplosionArea = &H4
        ExplosionDamage = &H5
        FireArea = &H6
        YellowRings = &H7
        PoisonRings = &H8
        HitArea = &H9
        Teleport = &HA
        EnergyDamage = &HB
        MagicEnergy = &HC
        MagicBlood = &HD
        MagicPoison = &HE
        HitByFire = &HF
        Poison = &H10
        MortArea = &H11
        SoundGreen = &H12
        SoundRed = &H13
        PoisonArea = &H14
        SoundYellow = &H15
        SoundPurple = &H16
        SoundBlue = &H17
        SoundWhite = &H18
        Bubbles = &H19
        Craps = &H1A
        GiftWraps = &H1B
        FireworkYellow = &H1C
        FireworkRed = &H1D
        FireworkBlue = &H1E
        Stun = &H1F
        Sleep = &H20
        WaterCreature = &H21
        Groundshaker = &H22
        Hearts = &H23
        FireAttack = &H24
        EnergyArea = &H25
        SmallClouds = &H26
        HolyDamage = &H27
        BigClouds = &H28
        IceArea = &H29
        IceTornado = &H2A
        IceAttack = &H2B
        Stones = &H2C
        SmallPlants = &H2D
        Carniphila = &H2E
        PurpleEnergy = &H2F
        YellowEnergy = &H30
        HolyArea = &H31
        BigPlants = &H32
        Cake = &H33
        GiantIce = &H34
        WaterSplash = &H35
        PlantAttack = &H36
        BlueArrow = &H38
        FlashSquare = &H39
    End Enum
#End Region

#Region "Packet Types"
    Public Enum IncomingPacketType
        SelfAppear = &HA
        GMAction = &HB
        ErrorMessage = &H14
        FyiMessage = &H15
        WaitingList = &H16
        Ping = &H1E
        Death = &H28
        CanReportBugs = &H32
        MapDescription = &H64
        MoveNorth = &H65
        MoveEast = &H66
        MoveSouth = &H67
        MoveWest = &H68
        UpdateTile = &H69
        TileAddThing = &H6A
        TileTransformThing = &H6B
        TileRemoveThing = &H6C
        CreatureMove = &H6D
        ContainerOpen = &H6E
        ContainerClose = &H6F
        ContainerAddItem = &H70
        ContainerUpdateItem = &H71
        ContainerRemoveItem = &H72
        InventorySetSlot = &H78
        InventoryResetSlot = &H79
        ShopWindowOpen = &H7A
        ShopSaleGoldCount = &H7B
        ShopWindowClose = &H7C
        SafeTradeRequestAck = &H7D
        SafeTradeRequestNoAck = &H7E
        SafeTradeClose = &H7F
        WorldLight = &H82
        MagicEffect = &H83
        AnimatedText = &H84
        Projectile = &H85
        CreatureSquare = &H86
        CreatureHealth = &H8C
        CreatureLight = &H8D
        CreatureOutfit = &H8E
        CreatureSpeed = &H8F
        CreatureSkull = &H90
        CreatureShield = &H91
        ItemTextWindow = &H96
        HouseTextWindow = &H97
        PlayerStatusUpdate = &HA0
        PlayerSkillsUpdate = &HA1
        PlayerFlagUpdate = &HA2
        CancelTarget = &HA3
        CreatureSpeak = &HAA
        ChannelList = &HAB
        ChannelOpen = &HAC
        ChannelOpenPrivate = &HAD
        RuleViolationOpen = &HAE
        RemoveReport = &HAF
        RuleViolationCancel = &HB0
        RuleViolationLock = &HB1
        PrivateChannelCreate = &HB2
        PrivateChannelClose = &HB3
        StatusMessage = &HB4
        PlayerCancelWalk = &HB5
        FloorChangeUp = &HBE
        FloorChangeDown = &HBF
        OutfitWindow = &HC8
        VipState = &HD2
        VipLogin = &HD3
        VipLogout = &HD4
        QuestList = &HF0
        QuestPartList = &HF1
        ShowTutorial = &HDC
        AddMapMarker = &HDD
    End Enum

    Public Enum OutgoingPacketType
        Logout = &H14
        ItemMove = &H78
        ShopSell = &H7A
        ShopBuy = &H7B
        ItemUse = &H82
        ItemUseOn = &H83
        LookAt = &H8C
        PlayerSpeech = &H96
        ChannelOpen = &H98
        ChannelClose = &H99
        Attack = &HA1
        Follow = &HA2
        CancelMove = &HBE
        ItemUseBattlelist = &H84
        ContainerClose = &H87
        ContainerOpenParent = &H88


        MoveUp = &H65
        MoveRight = &H66
        MoveDown = &H67
        MoveLeft = &H68

    End Enum
#End Region

#Region "Speech types"
    Public Enum SpeechTypePre861 As Byte
        Say = &H1
        Whisper = &H2
        Yell = &H3
        PrivatePlayerToNPC = &H4
        PrivateNPCToPlayer = &H5
        [Private] = &H6
        ChannelYellow = &H7
        ChannelWhite = &H8
        RuleViolationReport = &H9
        RuleViolationAnswer = &HA
        RuleViolationContinue = &HB
        Broadcast = &HC
        ChannelRed = &HD
        PrivateRed = &HE
        ChannelOrange = &HF
        ChannelRedAnonymous = &H11
        MonsterSay = &H13
        MonsterYell = &H14
    End Enum

    Public Enum SpeechTypePost861 As Byte
        Say = &H1
        Whisper = &H2
        Yell = &H3
        PrivatePlayerToNPC = &H4
        PrivateNPCToPlayer = &H5
        [Private] = &H6
        ChannelYellow = &H7
        ChannelWhite = &H8
        RuleViolationReport = &H9
        ChannelRed = &HA
        RuleViolationContinue = &HB
        ChannelOrange = &HC
        MonsterSay = &HD
    End Enum

    Public Enum StatusMessage As Byte
        ConsoleRed = &H12
        ConsoleOrange = &H13
        ConsoleOrange2 = &H14
        Warning = &H15
        EventAdvance = &H16
        EventDefault = &H17
        StatusDefault = &H18
        DescriptionGreen = &H19
        StatusSmall = &H1A
        ConsoleBlue = &H1B
    End Enum
#End Region

#Region "Projectile"
    Public Enum ProjectileType As Byte
        Spear = &H1
        Bolt = &H2
        Arrow = &H3
        Fire = &H4
        Energy = &H5
        PoisonArrow = &H6
        BurstArrow = &H7
        ThrowingStar = &H8
        ThrowingKnife = &H9
        SmallStone = &HA
        Skull = &HB
        BigStone = &HC
        SnowBall = &HD
        PowerBolt = &HE
        SmallPoison = &HF
        InfernalBolt = &H10
        HuntingSpear = &H11
        EnchantedSpear = &H12
        AssassinStar = &H13
        ViperStar = &H14
        RoyalSpear = &H15
        SniperArrow = &H16
        OnyxArrow = &H17
        EarthArrow = &H18
        NormalSword = &H19
        NormalAxe = &H1A
        NormalClub = &H1B
        EtherealSpear = &H1C
        Ice = &H1D
        Earth = &H1E
        Holy = &H1F
        Death = &H20
        FlashArrow = &H21
        FlamingArrow = &H22
        ShiverArrow = &H23
        EnergySmall = &H24
        IceSmall = &H25
        HolySmall = &H26
        EarthSmall = &H27
        EarthArrow2 = &H28
        Explosion = &H29
        Cake = &H2A
    End Enum
#End Region

#Region "Pipe"
    Public Enum MType As Byte
        AllPlayers = &H0
        Self = &H1
        ScreenParty = &H2
        ScreenCopyName = &H3
        ItemTrade = &H4
        VipCopyName = &H5
        ConsoleCopyName = &H6
        AllCopyName = &H7
        Attack = &H8
    End Enum

    Public Enum PipeIncomingType As Byte
        OnClickContextMenu = &HC
        PlayerSay = &HF
        VIPClickName = &HF1
        IncomingPacket = &HF2
        ShopOpen = &HF3
        ShopClose = &HF4
        KeyDown = &HF5
        KeyUP = &HF6
        MouseAction = &HF7
        ConfirmCheck = &HF8
    End Enum

    Public Enum PipePacketType As Byte
        SetConstant = &H1
        DisplayText = &H2
        RemoveText = &H3
        RemoveAllText = &H4
        InjectDisplay = &H5
        CreatureText = &H6
        RemoveCreatureText = &H7
        UpdateCreatureText = &H8
        AddMenu = &H9
        RemoveMenu = &HA
        ClearContextMenus = &HB
        AddItem = &HC
        ClearItems = &HD
        UpdateItem = &HE
        AddGui = &HF
        UpdateGui = &H10
        ClearGui = &H11
        SelfSpeak = &H12
        ClearCreatureText = &H13
        MoveItem = &H14
        UseType1 = &H15 'With creature, from inventory (known and unknown)
        UseType2 = &H16 'From ground
        UseType3 = &H17 'With ground
        SendPacketToClient = &H18
        Spin = &H19
        Attack = &H20
        Follow = &H21
        StopActions = &H22
        Logout = &H23
        BuyItem = &H24
        SellItem = &H25
        AddKey = &H26
        RemoveKey = &H27
        ShowOutput = &H28
        InjectCheck = &H29
        SendPacketToServer = &H30
    End Enum

    Private Enum Protocol
        None
        Login
        World
    End Enum
#End Region

    Public Enum HotkeyPressType
        Press = 1
        Down = 2
        Up = 3
        UpDown = 4
    End Enum

    Public Enum Direction
        Up = 0
        Right = 1
        Down = 2
        Left = 3
        UpRight = 5
        DownRight = 6
        DownLeft = 7
        UpLeft = 8
    End Enum

    Public Enum AttackMode As Byte
        FullAttack = 1
        Balance = 2
        FullDefense = 3
    End Enum

    Public Enum FollowMode As Byte
        Stand = 0
        Follow = 1
    End Enum

    Public Enum SelfSpeechType
        Say = 1
        Whisper = 2
        Yell = 3
        NPC = 4
    End Enum

    Public Enum ItemLocationType
        Ground
        Slot
        Container
    End Enum

    Public Enum AttackPriority
        VeryHigh = 3
        High = 2
        Average = 1
        Ignore = 0
    End Enum

    Public Enum MagicAttackType
        None = 0
        Strike = 1
        Rune = 2
    End Enum

    Public Enum WindowShowStyle As UInteger
        ''' <summary>Hides the window and activates another window.</summary>
        ''' <remarks>See SW_HIDE</remarks>
        Hide = 0
        '''<summary>Activates and displays a window. If the window is minimized
        ''' or maximized, the system restores it to its original size and
        ''' position. An application should specify this flag when displaying
        ''' the window for the first time.</summary>
        ''' <remarks>See SW_SHOWNORMAL</remarks>
        ShowNormal = 1
        ''' <summary>Activates the window and displays it as a minimized window.</summary>
        ''' <remarks>See SW_SHOWMINIMIZED</remarks>
        ShowMinimized = 2
        ''' <summary>Activates the window and displays it as a maximized window.</summary>
        ''' <remarks>See SW_SHOWMAXIMIZED</remarks>
        ShowMaximized = 3
        ''' <summary>Maximizes the specified window.</summary>
        ''' <remarks>See SW_MAXIMIZE</remarks>
        Maximize = 3
        ''' <summary>Displays a window in its most recent size and position.
        ''' This value is similar to "ShowNormal", except the window is not
        ''' actived.</summary>
        ''' <remarks>See SW_SHOWNOACTIVATE</remarks>
        ShowNormalNoActivate = 4
        ''' <summary>Activates the window and displays it in its current size
        ''' and position.</summary>
        ''' <remarks>See SW_SHOW</remarks>
        Show = 5
        ''' <summary>Minimizes the specified window and activates the next
        ''' top-level window in the Z order.</summary>
        ''' <remarks>See SW_MINIMIZE</remarks>
        Minimize = 6
        '''   <summary>Displays the window as a minimized window. This value is
        '''   similar to "ShowMinimized", except the window is not activated.</summary>
        ''' <remarks>See SW_SHOWMINNOACTIVE</remarks>
        ShowMinNoActivate = 7
        ''' <summary>Displays the window in its current size and position. This
        ''' value is similar to "Show", except the window is not activated.</summary>
        ''' <remarks>See SW_SHOWNA</remarks>
        ShowNoActivate = 8
        ''' <summary>Activates and displays the window. If the window is
        ''' minimized or maximized, the system restores it to its original size
        ''' and position. An application should specify this flag when restoring
        ''' a minimized window.</summary>
        ''' <remarks>See SW_RESTORE</remarks>
        Restore = 9
        ''' <summary>Sets the show state based on the SW_ value specified in the
        ''' STARTUPINFO structure passed to the CreateProcess function by the
        ''' program that started the application.</summary>
        ''' <remarks>See SW_SHOWDEFAULT</remarks>
        ShowDefault = 10
        ''' <summary>Windows 2000/XP: Minimizes a window, even if the thread
        ''' that owns the window is hung. This flag should only be used when
        ''' minimizing windows from a different thread.</summary>
        ''' <remarks>See SW_FORCEMINIMIZE</remarks>
        ForceMinimized = 11
    End Enum



    Public Enum ClickType
        Move = &H200
        LeftDown = &H201
        RightDown = &H2040B
        LeftUp = &H202
        RightUp = &H205
    End Enum
End Module
