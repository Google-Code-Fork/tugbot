Public Module AddressConstants
    'Public SupportedVersions As String() = New String() {"8.41", "8.42", "8.50"} '"8.40",
    Public SupportedVersions As String() = New String() {"8.50", "8.52", "8.53", "8.54", "8.55", "8.57", "8.60", "8.61", "8.62", "8.70", "8.71"}
    'Add the self spin addressess for 8.41 and 8.42, and fix the dat editor before enabling
    'also add attack address
    'Dat reading changed >= 8.50
    'Also add auto follow call and follow state address
    'Add stop function
    'add 8.50 base head
    '8.53 buy and sell


#Region "Bases"
    Public BaseExp As New AddressArray '&H62BD24
    Public BaseZ As New AddressArray '&H63AA50
    Public BaseHead As New AddressArray '&H6380E8 '
    Public BaseTarget As New AddressArray '&H62BCFC '
    Public BaseBattle As New AddressArray '&H62BD90 + 4 '
    Public BaseContainer As New AddressArray '&H638160 '
    Public BaseCharList As New AddressArray '&H788324 '
    Public BaseCharCount As New AddressArray '&H788328 '
    Public BaseCharSelected As New AddressArray '&H788320 '
    Public BaseDat As New AddressArray '&H784D2C '
    Public BaseMap As New AddressArray '&H63F568
    Public BaseConnection As New AddressArray '&H788370
    Public BaseName1 As New AddressArray '&H4EC179
    Public BaseName2 As New AddressArray '&H4EC183

    Public BaseXtea As New AddressArray '&H784D0C

    Public BaseLevel1 As New AddressArray '&H4EE02A
    Public BaseLevel2 As New AddressArray '&H4EE12F
    Public BaseLevel3 As New AddressArray '&H4EE1B0
    Public BaseLevelPtr As New AddressArray '&H6376A8
    Public BaseLevelAdd As New AddressArray '&H6376A8

    Public BaseStatusBar As New AddressArray '&H78A1E8

    Public BaseLightNop As New AddressArray '&H4E4929
    Public BaseLightAmount As New AddressArray '&H4E492C

    Public BaseScreenRect As New AddressArray '&H6376A8
    Public BaseScreenBar As New AddressArray '&H63AA18

    Public BaseFramRate As New AddressArray '&H788EB4

    Public BaseDialog As New AddressArray '&H63AA14

    Public BaseStart As New AddressArray '&H78A1D0


    Public PrintName As New AddressArray '&H4EF161
    Public PrintFPS As New AddressArray '&H458648
    Public ShowFPS As New AddressArray '&H629A34
    Public PrintTextFunc As New AddressArray '&H4AEC00
    Public NopFPS As New AddressArray '&H458584

    Public AddContextMenuFunc As New AddressArray '&H450B00
    Public OnClickContextMenu As New AddressArray '&H44D2F0
    Public SetOutfitContextMenu As New AddressArray '&H451A32
    Public PartyActionContextMenu As New AddressArray '&H451A83
    Public CopyNameContextMenu As New AddressArray '&H451A9A
    Public TradeContextMenu As New AddressArray '&H4516A9
    Public OnClickContextMenuVF As New AddressArray '&H5B0980

    'CUSTOM CONTEXT MENUS BY ME
    Public OnClickVipMenu As New AddressArray '&H44E300
    Public OnClickVipMenuVF As New AddressArray '&H5B0B48
    Public VipListContextMenu As New AddressArray '&H4523E4


    'Hooked functions by me
    Public BaseGui As New AddressArray '&H4B3460
    Public BaseRender As New AddressArray '&H4AF7C0
    Public SendMessage As New AddressArray '&H4072F0

    ''More
    Public BaseSend As New AddressArray '&H5AB600

    Public BasePeek As New AddressArray '&H5AB43C
    Public PeekCallFrom As New AddressArray '&H5AB43C
    Public ConsoleContextMenu As New AddressArray '&H4529D9
    Public OnClickConsoleMenu As New AddressArray '&H44E700
    Public OnClickConsoleMenuVF As New AddressArray '&H5B0C48

    Public MoveObject As New AddressArray '&H405220

    Public UseObjectWithCreature As New AddressArray '&H406650

    'use
    Public UseObjectWithGround As New AddressArray '&H406430
    Public UseObjectFromGround As New AddressArray '&H406240

    'Click names and shit
    Public ClickPlayerId As New AddressArray '&H78841C
    Public ClickItemId As New AddressArray '&H788418 '
    Public ClickPlayerName As New AddressArray '&H0

    'VipGetNames
    Public VipNameHook As New AddressArray '&H4522AF
    Public VipNameFunc As New AddressArray '&H54AE40

    'Packet to client/Parser
    Public BaseParserFunc As New AddressArray '&H4522AF
    Public BaseGetNextPacketFunc As New AddressArray '&H54AE40
    Public BaseRecvStreamPtr As New AddressArray '&H54AE40

    Public BaseSpinNorth As New AddressArray '&H54AE40
    Public BaseSpinSouth As New AddressArray '&H54AE40
    Public BaseSpinEast As New AddressArray '&H54AE40
    Public BaseSpinWest As New AddressArray '&H54AE40

    Public BaseAttack As New AddressArray '&H54AE40

    Public BaseFollowFunc As New AddressArray '&H54AE40
    Public BaseFollowState As New AddressArray '&H54AE40

    Public BaseStopActions As New AddressArray '&H54AE40

    Public BaseLoggout As New AddressArray '&H54AE40

    Public BaseBattleStep As New AddressArray '&H54AE40

    Public AttackContextMenu As New AddressArray '&H54AE40

    Public BaseBuy As New AddressArray
    Public BaseSell As New AddressArray

    Public BaseCreatePacket As New AddressArray
    Public BaseAddBytePacket As New AddressArray
    Public BaseSendPacket As New AddressArray
#End Region


    Public Sub InitializeAddresses()
        'Initialize840Addresses()
        'Initialize841Addresses()
        'Initialize842Addresses()
        Initialize850Addresses()
        Initialize852Addresses()
        Initialize853Addresses()
        Initialize854Addresses()
        Initialize855Addresses()
        Initialize857Addresses()
        Initialize860Addresses()
        Initialize861Addresses()
        Initialize862Addresses()
        Initialize870Addresses()
        Initialize871Addresses()
    End Sub

#Region "8.40 Base Addressess"
    Public Sub Initialize840Addresses()
        BaseExp("8.40") = &H62BD24
        BaseZ("8.40") = &H63AA50
        BaseHead("8.40") = &H6380E8 '
        BaseTarget("8.40") = &H62BCFC '
        BaseBattle("8.40") = &H62BD90 + 4 '
        BaseContainer("8.40") = &H638160 '
        BaseCharList("8.40") = &H788324 '
        BaseCharCount("8.40") = &H788328 '
        BaseCharSelected("8.40") = &H788320 '
        BaseDat("8.40") = &H784D2C '
        BaseMap("8.40") = &H63F568
        BaseConnection("8.40") = &H788370
        BaseName1("8.40") = &H4EC179
        BaseName2("8.40") = &H4EC183

        BaseXtea("8.40") = &H784D0C

        BaseLevel1("8.40") = &H4EE02A
        BaseLevel2("8.40") = &H4EE12F
        BaseLevel3("8.40") = &H4EE1B0
        BaseLevelPtr("8.40") = &H6376A8

        BaseStatusBar("8.40") = &H78A1E8

        BaseLightNop("8.40") = &H4E4929
        BaseLightAmount("8.40") = &H4E492C

        BaseScreenRect("8.40") = &H6376A8
        BaseScreenBar("8.40") = &H63AA18

        BaseFramRate("8.40") = &H788EB4

        BaseDialog("8.40") = &H63AA14

        BaseStart("8.40") = &H78A1D0


        PrintName("8.40") = &H4EF161
        PrintFPS("8.40") = &H458648
        ShowFPS("8.40") = &H629A34
        PrintTextFunc("8.40") = &H4AEC00
        NopFPS("8.40") = &H458584

        AddContextMenuFunc("8.40") = &H450B00
        OnClickContextMenu("8.40") = &H44D2F0
        SetOutfitContextMenu("8.40") = &H451A32
        PartyActionContextMenu("8.40") = &H451A83
        CopyNameContextMenu("8.40") = &H451A9A
        TradeContextMenu("8.40") = &H4516A9
        OnClickContextMenuVF("8.40") = &H5B0980

        'CUSTOM CONTEXT MENUS BY ME
        OnClickVipMenu("8.40") = &H44E300
        OnClickVipMenuVF("8.40") = &H5B0B48
        VipListContextMenu("8.40") = &H4523E4


        'Hooked functions by me
        BaseGui("8.40") = &H4B3460
        BaseRender("8.40") = &H4AF7C0
        SendMessage("8.40") = &H4072F0

        ''More
        BaseSend("8.40") = &H5AB600

        BasePeek("8.40") = &H5AB43C
        ConsoleContextMenu("8.40") = &H4529D9
        OnClickConsoleMenu("8.40") = &H44E700
        OnClickConsoleMenuVF("8.40") = &H5B0C48

        MoveObject("8.40") = &H405220

        UseObjectWithCreature("8.40") = &H406650

        'use
        UseObjectWithGround("8.40") = &H406430
        UseObjectFromGround("8.40") = &H406240

        'Click names and shit
        ClickPlayerId("8.40") = &H78841C
        ClickItemId("8.40") = &H788418 '
        ClickPlayerName("8.40") = &H0

        'VipGetNames
        VipNameHook("8.40") = &H4522AF
        VipNameFunc("8.40") = &H54AE40


        'Parser hook/own packet injection
        'BaseParserFunc("8.41") = &H4A4E40
        'BaseGetNextPacketFunc("8.41") = &H45ACD5
        BaseRecvStreamPtr("8.40") = &H784CFC
    End Sub
#End Region

#Region "8.41 Base Addressess"
    Public Sub Initialize841Addresses()
        BaseExp("8.41") = &H62CD24 ''-''-''
        BaseZ("8.41") = &H63BAD8 ''-''-''
        BaseHead("8.41") = &H639170 ''-''-''
        BaseTarget("8.41") = &H62CCFC ''-''-''
        BaseBattle("8.41") = &H62CD90 + 4 ''-''-''
        BaseContainer("8.41") = &H6391E8 ''-''-''
        BaseCharList("8.41") = &H7893AC ''-''-''
        BaseCharCount("8.41") = &H7893B0 ''-''-''
        BaseCharSelected("8.41") = &H7893A8 ''-''-''

        BaseDat("8.41") = &H785DB4 ''-''-''
        BaseMap("8.41") = &H6405F0 ''-''-''
        BaseConnection("8.41") = &H7893F8 ''-''-''
        BaseName1("8.41") = &H4ECA09 ''-''-''
        BaseName2("8.41") = &H4ECA13 ''-''-''

        BaseXtea("8.41") = &H785D94 ''-''-''

        BaseLevel1("8.41") = &H4EE8BA ''-''-''
        BaseLevel2("8.41") = &H4EE9BF ''-''-''
        BaseLevel3("8.41") = &H4EEA40 ''-''-''
        BaseLevelPtr("8.41") = &H637AF8 ''-''-''

        BaseStatusBar("8.41") = &H78B270 ''-''-''

        BaseLightNop("8.41") = &H4E51B9 ''-''-''
        BaseLightAmount("8.41") = &H4E51BC ''-''-''

        BaseScreenRect("8.41") = &H638734 ''-''-''
        BaseScreenBar("8.41") = &H63BAA0 ''-''-''

        BaseFramRate("8.41") = &H789F3C ''-''-''

        BaseDialog("8.41") = &H63BA9C ''-''-''

        BaseStart("8.41") = &H78B258 ''-''-''


        PrintName("8.41") = &H4EF9F1 ''-''-''
        PrintFPS("8.41") = &H458BD8 ''-''-''
        ShowFPS("8.41") = &H62AA30  ''-''-''
        PrintTextFunc("8.41") = &H4AF480  ''-''-''
        NopFPS("8.41") = &H458B14 ''-''-''

        AddContextMenuFunc("8.41") = &H451060 ''-''-''
        SetOutfitContextMenu("8.41") = &H451F92 ''-''-''
        PartyActionContextMenu("8.41") = &H451FE3 ''-''-''
        CopyNameContextMenu("8.41") = &H451FFA ''-''-''
        TradeContextMenu("8.41") = &H451C09 ''-''-''

        OnClickContextMenu("8.41") = &H44D840 '-''-''
        OnClickContextMenuVF("8.41") = &H5B0AD0 '-''-'

        'CUSTOM CONTEXT MENUS BY ME
        OnClickVipMenu("8.41") = &H44E850 '-''-''
        OnClickVipMenuVF("8.41") = &H5B0C98 '-''-''
        VipListContextMenu("8.41") = &H452924 '-''-''



        'Hooked functions by me
        BaseGui("8.41") = &H4B3CD0 ''-''-''
        BaseRender("8.41") = &H4B0040 ''-''-''
        SendMessage("8.41") = &H407460 ''-''-''

        ''More
        BaseSend("8.41") = &H5AB5D4 ''-''-''

        BasePeek("8.41") = &H5AB43C ''-''-''
        ConsoleContextMenu("8.41") = &H452F19 ''-''-''
        OnClickConsoleMenu("8.41") = &H44EC50 ''-''-''
        OnClickConsoleMenuVF("8.41") = &H5B0D98 ''-''-''

        MoveObject("8.41") = &H405390 ''-''-''

        UseObjectWithCreature("8.41") = &H4067C0 ''-''-''

        'use
        UseObjectWithGround("8.41") = &H4065A0 ''-''-''
        UseObjectFromGround("8.41") = &H4063B0 ''-''-''

        'Click names and shit
        ClickPlayerId("8.41") = &H7893FC ''-''-''
        ClickItemId("8.41") = &H7894A0 ''-''-''
        ClickPlayerName("8.41") = &H0

        'VipGetNames
        VipNameHook("8.41") = &H4527EF
        VipNameFunc("8.41") = &H54B760

        'Parser hook/own packet injection
        BaseParserFunc("8.41") = &H45ACA0
        BaseGetNextPacketFunc("8.41") = &H45ACD5
        BaseRecvStreamPtr("8.41") = &H785D84
    End Sub
#End Region

#Region "8.42 Base Addressess"
    Public Sub Initialize842Addresses()
        BaseExp("8.42") = &H631D84 ''-''-''
        BaseZ("8.42") = &H640B38 ''-''-''
        BaseHead("8.42") = &H63E1D0 ''-''-''
        BaseTarget("8.42") = &H631D5C ''-''-''
        BaseBattle("8.42") = &H631DF0 + 4 ''-''-''
        BaseContainer("8.42") = &H63E248 ''-''-''
        BaseCharList("8.42") = &H78E40C ''-''-''
        BaseCharCount("8.42") = &H78E410 ''-''-''
        BaseCharSelected("8.42") = &H78E408 ''-''-''
        BaseDat("8.42") = &H78AE14 ''-''-''
        BaseMap("8.42") = &H645650 ''-''-''
        BaseConnection("8.42") = &H78E458 ''-''-''
        BaseName1("8.42") = &H4ECA89 ''-''-''
        BaseName2("8.42") = &H4ECA93 ''-''-''

        BaseXtea("8.42") = &H78ADF4 ''-''-''

        BaseLevel1("8.42") = &H4EE93A ''-''-''
        BaseLevel2("8.42") = &H4EEA3F ''-''-''
        BaseLevel3("8.42") = &H4EEAC0 ''-''-''
        BaseLevelPtr("8.42") = &H63D794 ''-''-''

        BaseStatusBar("8.42") = &H7902D0 ''-''-''

        BaseLightNop("8.42") = &H4E5239 ''-''-''
        BaseLightAmount("8.42") = &H4E523C ''-''-''

        BaseScreenRect("8.42") = &H63D794 ''-''-''
        BaseScreenBar("8.42") = &H640B00 ''-''-''

        BaseFramRate("8.42") = &H78EF9C ''-''-''

        BaseDialog("8.42") = &H640AFC ''-''-''

        BaseStart("8.42") = &H7902B8 ''-''-''


        PrintName("8.42") = &H4EFA71 ''-''-''
        PrintFPS("8.42") = &H459048 ''-''-''
        ShowFPS("8.42") = &H62FA34 ''-''-''
        PrintTextFunc("8.42") = &H4AF8D0 ''-''-''
        NopFPS("8.42") = &H458F84 ''-''-''

        AddContextMenuFunc("8.42") = &H451160 ''-''-''
        SetOutfitContextMenu("8.42") = &H452092 ''-''-''
        PartyActionContextMenu("8.42") = &H4520E3 ''-''-''
        CopyNameContextMenu("8.42") = &H4520FA ''-''-''
        TradeContextMenu("8.42") = &H451D09 ''-''-''

        OnClickContextMenu("8.42") = &H44D920 ''-''-''
        OnClickContextMenuVF("8.42") = &H5B4AA0 ''-''-''

        'CUSTOM CONTEXT MENUS BY ME
        OnClickVipMenu("8.42") = &H44E930 ''-''-''
        OnClickVipMenuVF("8.42") = &H5B4C68 ''-''-''
        VipListContextMenu("8.42") = &H4529E4 ''-''-''


        'Hooked functions by me
        BaseGui("8.42") = &H4B4120 ''-''-''
        BaseRender("8.42") = &H4B0490 ''-''-''
        SendMessage("8.42") = &H407330 ''-''-''SEND MESSAGE

        ''More
        BaseSend("8.42") = &H5AF608 ''-''-''

        BasePeek("8.42") = &H5AF444 ''-''-''
        ConsoleContextMenu("8.42") = &H453709 ''-''-''
        OnClickConsoleMenu("8.42") = &H44ED30 ''-''-''
        OnClickConsoleMenuVF("8.42") = &H5B4D68 ''-''-''

        MoveObject("8.42") = &H405260 ''-''-''

        UseObjectWithCreature("8.42") = &H406690 ''-''-''

        'use
        UseObjectWithGround("8.42") = &H406470 ''-''-''
        UseObjectFromGround("8.42") = &H406280 ''-''-''

        'Click names and shit
        ClickPlayerId("8.42") = &H78E45C ''-''-''
        ClickItemId("8.42") = &H78E500 ''-''-''
        ClickPlayerName("8.42") = &H0

        'VipGetNames
        VipNameHook("8.42") = &H4528AF
        VipNameFunc("8.42") = &H54EEA0

        'Parser hook/own packet injection
        BaseParserFunc("8.42") = &H45B110
        BaseGetNextPacketFunc("8.42") = &H45B145
        BaseRecvStreamPtr("8.42") = &H78ADE4
    End Sub
#End Region

#Region "8.50 Base Addressess"
    Public Sub Initialize850Addresses()
        BaseExp("8.50") = &H632EC4 'updated
        BaseZ("8.50") = &H641C78 'updated
        BaseTarget("8.50") = &H632E9C 'updated
        BaseHead("8.50") = &H63F310 'UPDATED

        BaseConnection("8.50") = &H78F598 'updated

        BaseBattle("8.50") = &H632F30 + 4 'updated
        BaseBattleStep("8.50") = 160 'updated 

        BaseContainer("8.50") = &H63F388 'updated

        BaseCharList("8.50") = &H78F54C 'updated
        BaseCharCount("8.50") = &H78F550 'updated
        BaseCharSelected("8.50") = &H78F548 'updated

        BaseDat("8.50") = &H78BF54 'updated
        BaseMap("8.50") = &H646790 'updated

        BaseName1("8.50") = &H4ED239 'updated
        BaseName2("8.50") = &H4ED243 'updated

        BaseLevel1("8.50") = &H4EF0EA 'updated
        BaseLevel2("8.50") = &H4EF1EF 'updated
        BaseLevel3("8.50") = &H4EF270 'updated
        BaseLevelPtr("8.50") = &H63E8D4 'updated

        BaseStatusBar("8.50") = &H791418 'updated

        BaseLightNop("8.50") = &H4E59C9 'updated
        BaseLightAmount("8.50") = &H4E59CC 'updated

        BaseScreenRect("8.50") = &H63E8D4 'updated
        BaseScreenBar("8.50") = &H641C40 'updated 

        BaseFramRate("8.50") = &H7900DC 'updated

        BaseStart("8.50") = &H7913F8 'updated

        'PRINT SHIT
        PrintName("8.50") = &H4F0221 'Updated
        PrintFPS("8.50") = &H459728 'Updated
        ShowFPS("8.50") = &H630B74 'Updated
        PrintTextFunc("8.50") = &H4B0000 'Updated
        NopFPS("8.50") = &H459664 'Updated
        BaseGui("8.50") = &H4B4860 'Updated
        BaseRender("8.50") = &H4B0BC0 'Updated 

        'CONTEXT MENUS
        AddContextMenuFunc("8.50") = &H451830 'Updated
        SetOutfitContextMenu("8.50") = &H452762 'Updated 
        PartyActionContextMenu("8.50") = &H4527B3 'Updated
        CopyNameContextMenu("8.50") = &H4527CA 'Updated
        TradeContextMenu("8.50") = &H4523D9 'Updated
        OnClickContextMenu("8.50") = &H44DFD0 'Updated
        OnClickContextMenuVF("8.50") = &H5B5B98 'Updated

        'CUSTOM CONTEXT MENUS BY ME
        OnClickVipMenu("8.50") = &H44EFE0 'Updated
        OnClickVipMenuVF("8.50") = &H5B5D60 'Updated
        VipListContextMenu("8.50") = &H4530D4 'Updated

        AttackContextMenu("8.50") = &H452470 '' Updated

        'VipGetNames
        VipNameHook("8.50") = &H452F9F 'updated
        VipNameFunc("8.50") = &H54FC90 'updated
        'Click names and shit
        ClickPlayerId("8.50") = &H78F59C  'Updated
        ClickItemId("8.50") = &H78F640 'Updated

        'Hooked functions
        BasePeek("8.50") = &H5B0444 'Updated

        'Parser hook/own packet injection
        BaseParserFunc("8.50") = &H45B810 'Updated
        BaseGetNextPacketFunc("8.50") = &H45B845 'Updated
        BaseRecvStreamPtr("8.50") = &H78BF24 'Updated

        'Outgoing Packet Composition
        'It seems all of these all change the same.
        'Meaning if one is altered by 20, the rest are as well
        SendMessage("8.50") = &H4072F0 'Updated
        UseObjectWithGround("8.50") = &H406430 'updated
        UseObjectFromGround("8.50") = &H406240 'updated
        UseObjectWithCreature("8.50") = &H406650 'updated
        MoveObject("8.50") = &H405220 'updated
        BaseSpinNorth("8.50") = &H404BA0 'Updated
        BaseSpinSouth("8.50") = &H404EE0 'Updated
        BaseSpinEast("8.50") = &H404D40 'Updated
        BaseSpinWest("8.50") = &H405080 'Updated
        BaseAttack("8.50") = &H408E20 'Updated
        BaseStopActions("8.50") = &H40A0B0 'Updated
        BaseLoggout("8.50") = &H4047B0 'Updated
        BaseFollowFunc("8.50") = &H408C30 'Updated
        'Trade
        BaseBuy("8.50") = &H405610 'Updated 
        BaseSell("8.50") = &H4057F0 'Updated 

        'follow state
        BaseFollowState("8.50") = &H78C35C + 4 'Updated

        ''UNUSED
        ConsoleContextMenu("8.50") = &H4530D4 'not in use yet
        OnClickConsoleMenu("8.50") = &H44F3E0 'not in use yet
        OnClickConsoleMenuVF("8.50") = &H5B5E60 'not in use yet
        BaseDialog("8.50") = &H64510C 'not in use yet
        ClickPlayerName("8.50") = &H0 'Obsolete
        BaseSend("8.50") = &H5AF608 'obsolete
        BaseXtea("8.50") = &H78BF34 'Obsolete
        PeekCallFrom("8.50") = &H56F029 'Obsolete

        'OWN
        BaseCreatePacket("8.50") = &H4F2D40
        BaseAddBytePacket("8.50") = &H4F3010
        BaseSendPacket("8.50") = &H4F38F0
    End Sub
#End Region

#Region "8.52 Base Addressess"
    Public Sub Initialize852Addresses()
        BaseExp("8.52") = &H633E84 'UPDATED
        BaseZ("8.52") = &H642C38 'UPDATED
        BaseHead("8.52") = &H6402D0 'UPDATED
        BaseTarget("8.52") = &H633E5C 'UPDATED

        BaseBattle("8.52") = &H633EF4 '+ 4 'UPDATED
        BaseBattleStep("8.52") = 160 'updated

        BaseContainer("8.52") = &H640348 'UPDATED
        BaseCharList("8.52") = &H79050C 'UPDATED
        BaseCharCount("8.52") = &H790510 'UPDATED
        BaseCharSelected("8.52") = &H790508 'UPDATED
        BaseDat("8.52") = &H78CF14 'UPDATED
        BaseMap("8.52") = &H647750 'UPDATED
        BaseConnection("8.52") = &H790558 'UPDATED
        BaseName1("8.52") = &H4ED2C9 'UPDATED
        BaseName2("8.52") = &H4ED2D3 'UPDATED

        BaseXtea("8.52") = &H78BF34 'Obsolete

        BaseLevel1("8.52") = &H4EF17A 'UPDATED
        BaseLevel2("8.52") = &H4EF27F 'UPDATED
        BaseLevel3("8.52") = &H4EF300 'UPDATED
        BaseLevelPtr("8.52") = &H63F894 'UPDATED

        BaseStatusBar("8.52") = &H7923DC + 4 'UPDATED

        BaseLightNop("8.52") = &H4E5A59 'UPDATED
        BaseLightAmount("8.52") = &H4E5A5C 'UPDATED

        BaseScreenRect("8.52") = &H63F894 'UPDATED
        BaseScreenBar("8.52") = &H7923D4 'UPDATED

        BaseFramRate("8.52") = &H7910A4 'UPDATED

        BaseDialog("8.52") = &H642BFC 'UPDATED

        BaseStart("8.52") = &H7923C0 'UPDATED

        PrintName("8.52") = &H4F02B1 'UPDATED
        PrintFPS("8.52") = &H4597C8 'UPDATED
        ShowFPS("8.52") = &H630B34 'UPDATED
        PrintTextFunc("8.52") = &H4B0090 'UPDATED
        NopFPS("8.52") = &H459704 'UPDATED

        AddContextMenuFunc("8.52") = &H4518D0 'UPDATED

        SetOutfitContextMenu("8.52") = &H452802 'UPDATED
        PartyActionContextMenu("8.52") = &H452853 'UPDATED
        CopyNameContextMenu("8.52") = &H45286A 'UPDATED
        TradeContextMenu("8.52") = &H452479 'UPDATED

        OnClickContextMenu("8.52") = &H44E070 'UPDATED
        OnClickContextMenuVF("8.52") = &H5B67D8 'UPDATED

        'CUSTOM CONTEXT MENUS BY ME
        OnClickVipMenu("8.52") = &H44F080 'UPDATED
        OnClickVipMenuVF("8.52") = &H5B69A0 'UPDATED
        VipListContextMenu("8.52") = &H453154 'UPDATED


        'Hooked functions by me
        BaseGui("8.52") = &H4B48E0 'UPDATED
        BaseRender("8.52") = &H4B0C50 'UPDATED
        SendMessage("8.52") = &H407330 'UPDATED

        ''More
        BaseSend("8.52") = &H5AF608 'obsolete

        BasePeek("8.52") = &H5B1444 'UPDATED
        PeekCallFrom("8.52") = &H56F029 'UPDATED
        ConsoleContextMenu("8.52") = &H4530D4 'not in use yet
        OnClickConsoleMenu("8.52") = &H44F3E0 'not in use yet
        OnClickConsoleMenuVF("8.52") = &H5B5E60 'not in use yet

        MoveObject("8.52") = &H405260 'UPDATED

        AttackContextMenu("8.52") = &H452510 ''UPDATED

        UseObjectWithCreature("8.52") = &H406690 'UPDATED

        'use
        UseObjectWithGround("8.52") = &H406470 'UPDATED
        UseObjectFromGround("8.52") = &H406280 'UPDATED

        'Click names and shit
        ClickPlayerId("8.52") = &H790560 - 4 'UPDATED/untested
        ClickItemId("8.52") = &H790604 'UPDATED
        ClickPlayerName("8.52") = &H0 'Obsolete

        'VipGetNames
        VipNameHook("8.52") = &H45301F 'UPDATED
        VipNameFunc("8.52") = &H5506F0 'UPDATED

        'Parser hook/own packet injection
        BaseParserFunc("8.52") = &H45B8B0 'UPDATED
        BaseGetNextPacketFunc("8.52") = &H45B8E5 'UPDATED
        BaseRecvStreamPtr("8.52") = &H78CEE4 'UPDATED

        'Spin
        BaseSpinNorth("8.52") = &H404BE0 'UPDATED
        BaseSpinSouth("8.52") = &H404F20 'UPDATED
        BaseSpinEast("8.52") = &H404D80 'UPDATED
        BaseSpinWest("8.52") = &H4050C0 'UPDATED

        BaseAttack("8.52") = &H408E60 'UPDATED
        BaseFollowFunc("8.52") = &H408C70 'UPDATED
        BaseFollowState("8.52") = &H78D320 'UPDATED

        BaseStopActions("8.52") = &H40A0F0 'UPDATED
        BaseLoggout("8.52") = &H4047F0 'UPDATED


        'OWN
        BaseCreatePacket("8.52") = &H4F2DD0
        BaseAddBytePacket("8.52") = &H4F30A0
        BaseSendPacket("8.52") = &H4F3980
    End Sub
#End Region


#Region "8.53 Base Addressess"
    Public Sub Initialize853Addresses()
        BaseExp("8.53") = &H635F04 ''UPDATED
        BaseZ("8.53") = &H645148 ''UPDATED
        BaseHead("8.53") = &H6427E0 ''UPDATED
        BaseTarget("8.53") = &H635EDC ''UPDATED

        BaseConnection("8.53") = &H792A68 ''UPDATED

        BaseBattle("8.53") = &H635F70 + 4 ''UPDATED
        BaseBattleStep("8.53") = 164 ''UPDATED

        BaseContainer("8.53") = &H642858 ''UPDATED
        BaseCharList("8.53") = &H792A1C ''UPDATED
        BaseCharCount("8.53") = &H790520 ''UPDATED
        BaseCharSelected("8.53") = &H792A18 ''UPDATED

        BaseDat("8.53") = &H78F424 ''UPDATED
        BaseMap("8.53") = &H649C60 ''UPDATED

        BaseName1("8.53") = &H4ED729 ''UPDATED
        BaseName2("8.53") = &H4ED733 ''UPDATED

        BaseLevel1("8.53") = &H4EF5DA ''UPDATED
        BaseLevel2("8.53") = &H4EF6DF ''UPDATED
        BaseLevel3("8.53") = &H4EF760 ''UPDATED
        BaseLevelPtr("8.53") = &H641DA4 ''UPDATED

        BaseStatusBar("8.53") = &H7D62F0  ''UPDATED

        BaseLightNop("8.53") = &H4E5EC9 ''UPDATED
        BaseLightAmount("8.53") = &H4E5ECC ''UPDATED

        BaseScreenRect("8.53") = &H641DA4 ''UPDATED
        BaseScreenBar("8.53") = &H7948E4 ''UPDATED

        BaseFramRate("8.53") = &H7935B4 ''UPDATED

        BaseDialog("8.53") = &H64510C ''UPDATED

        BaseStart("8.53") = &H7D62D0 ''UPDATED

        'PRINT SHIT
        PrintName("8.53") = &H4F0743 ''UPDATED
        PrintFPS("8.53") = &H459918 ''UPDATED
        ShowFPS("8.53") = &H632BB4 ''UPDATED
        PrintTextFunc("8.53") = &H4B0330 ''UPDATED
        NopFPS("8.53") = &H459854 ''UPDATED
        BaseGui("8.53") = &H4B4B80 ''UPDATED
        BaseRender("8.53") = &H4B0EF0 ''UPDATED

        'CONTEXT MENUS
        AddContextMenuFunc("8.53") = &H451A00 ''UPDATED
        SetOutfitContextMenu("8.53") = &H452932 ''UPDATED
        PartyActionContextMenu("8.53") = &H4527D1 ''UPDATED
        CopyNameContextMenu("8.53") = &H45299A ''UPDATED
        TradeContextMenu("8.53") = &H4525A9 ''UPDATED
        OnClickContextMenu("8.53") = &H44E1C0 ''UPDATED
        OnClickContextMenuVF("8.53") = &H5B7820 ''UPDATED
        'CUSTOM CONTEXT MENUS BY ME
        OnClickVipMenu("8.53") = &H44F1D0 ''UPDATED
        OnClickVipMenuVF("8.53") = &H5B79E8 ''UPDATED
        VipListContextMenu("8.53") = &H4532A4 ''UPDATED

        AttackContextMenu("8.53") = &H452640 ''UPDATED
        'VipGetNames
        VipNameHook("8.53") = &H45316F ''UPDATED
        VipNameFunc("8.53") = &H5512A0 ''UPDATED
        'Click names and shit
        ClickPlayerId("8.53") = &H792B14 - &HA8 ''UPDATED
        ClickItemId("8.53") = &H792B14  ''UPDATED

        'Hooked functions
        BasePeek("8.53") = &H5B2444 ''UPDATED
        'Parser hook/own packet injection
        BaseParserFunc("8.53") = &H45BA00 ''UPDATED
        BaseGetNextPacketFunc("8.53") = &H45BA35 ''UPDATED
        BaseRecvStreamPtr("8.53") = &H78F3F4 ''UPDATED
        'outgoing packets
        'It seems all of these all change the same.
        'Meaning if one is altered by 20, the rest are as well
        SendMessage("8.53") = &H407310 ''UPDATED
        UseObjectFromGround("8.53") = &H406260 ''UPDATED
        UseObjectWithGround("8.53") = &H406450 ''UPDATED
        UseObjectWithCreature("8.53") = &H406670 ''UPDATED
        MoveObject("8.53") = &H405240 ''UPDATED
        BaseSpinNorth("8.53") = &H404BC0 ''UPDATED
        BaseSpinSouth("8.53") = &H404F00 ''UPDATED
        BaseSpinEast("8.53") = &H404D60 ''UPDATED
        BaseSpinWest("8.53") = &H4050A0 ''UPDATED
        BaseAttack("8.53") = &H408E40 ''UPDATED
        BaseFollowFunc("8.53") = &H408C50 ''UPDATED
        BaseFollowState("8.53") = &H78F830 ''UPDATED
        BaseStopActions("8.53") = &H40A0D0 ''UPDATED
        BaseLoggout("8.53") = &H4047D0 ''UPDATED

        'OWN
        BaseCreatePacket("8.53") = &H4F3430
        BaseAddBytePacket("8.53") = &H4F3700
        BaseSendPacket("8.53") = &H4F3FE0

        'Trade
        BaseBuy("8.53") = &H405630
        BaseSell("8.53") = &H405810

        ''UNUSED
        ConsoleContextMenu("8.53") = &H4530D4 'not in use yet
        OnClickConsoleMenu("8.53") = &H44F3E0 'not in use yet
        OnClickConsoleMenuVF("8.53") = &H5B5E60 'not in use yet
        ClickPlayerName("8.53") = &H0 'Obsolete
        BaseSend("8.53") = &H5AF608 'obsolete
        BaseXtea("8.53") = &H78BF34 'Obsolete
        PeekCallFrom("8.53") = &H56F029 'Obsolete

    End Sub
#End Region

    'STILL SOME MISSING SHIT TO UPDATE
    'UPDATE FRAMERATE AND SCRENBAR
#Region "8.54 Base Addressess"
    Public Sub Initialize854Addresses()
        BaseExp("8.54") = &H635F04 '' UPDATED
        BaseZ("8.54") = &H645530 '' UPDATED
        BaseHead("8.54") = &H642BC8 '' UPDATED
        BaseTarget("8.54") = &H635EDC '' UPDATED

        BaseConnection("8.54") = &H792E50 '' UPDATED

        BaseBattle("8.54") = &H635F70 + 4 '' UPDATED 
        BaseBattleStep("8.54") = 168 '' UPDATED 

        BaseContainer("8.54") = &H642C40 '' UPDATED

        BaseCharList("8.54") = &H792E04 '' UPDATED
        BaseCharSelected("8.54") = &H792E00 '' UPDATED
        BaseCharCount("8.54") = &H792E08 '' UPDATED

        BaseDat("8.54") = &H78F80C '' UPDATED
        BaseMap("8.54") = &H64A048 '' UPDATED

        BaseName1("8.54") = &H4ED979 '' UPDATED
        BaseName2("8.54") = &H4ED983 '' UPDATED

        BaseLevel1("8.54") = &H4EF82A '' UPDATED
        BaseLevel2("8.54") = &H4EF92F '' UPDATED 
        BaseLevel3("8.54") = &H4EF9B0 '' UPDATED 
        BaseLevelPtr("8.54") = &H64218C '' UPDATED

        BaseStatusBar("8.54") = &H7D66D4 + 4  '' UPDATED

        BaseLightNop("8.54") = &H4E6119 '' UPDATED
        BaseLightAmount("8.54") = &H4E611C '' UPDATED

        BaseScreenRect("8.54") = &H64218C '' UPDATED
        BaseScreenBar("8.54") = &H7948E4 '' 

        BaseFramRate("8.54") = &H7935B4 '' 

        BaseStart("8.54") = &H7D66B8 '' UPDATED

        'PRINT SHIT
        PrintName("8.54") = &H4F0993 '' UPDATED
        PrintFPS("8.54") = &H459AC8 ''UPDATED
        ShowFPS("8.54") = &H633BB4 '' UPDATED
        PrintTextFunc("8.54") = &H4B0550 '' UPDATED
        NopFPS("8.54") = &H459A04 '' UPDATED
        BaseGui("8.54") = &H4B4DA0 '' UPDATED
        BaseRender("8.54") = &H4B1110 '' UPDATED

        'CONTEXT MENUS
        AddContextMenuFunc("8.54") = &H451BB0 '' UPDATED
        SetOutfitContextMenu("8.54") = &H452AE2 '' UPDATED
        PartyActionContextMenu("8.54") = &H452981 '' UPDATED 
        CopyNameContextMenu("8.54") = &H452B4A '' UPDATED
        TradeContextMenu("8.54") = &H452759 '' UPDATED
        OnClickContextMenu("8.54") = &H44E350 '' UPDATED
        OnClickContextMenuVF("8.54") = &H5B77F0 '' UPDATED

        'CUSTOM CONTEXT MENUS BY ME
        OnClickVipMenu("8.54") = &H44F360 '' UPDATED
        OnClickVipMenuVF("8.54") = &H5B79B8 '' UPDATED
        VipListContextMenu("8.54") = &H453454 '' UPDATED

        AttackContextMenu("8.54") = &H4527F0 '' UPDATED
        'VipGetNames
        VipNameHook("8.54") = &H45331F '' UPDATED
        VipNameFunc("8.54") = &H5514F0 '' UPDATED
        'Click names and shit
        ClickPlayerId("8.54") = &H792EFC - &HA8 '' UPDATED
        ClickItemId("8.54") = &H792EFC  '' UPDATED

        'Hooked functions
        BasePeek("8.54") = &H5B2444 '' UPDATED

        'Parser hook/own packet injection
        BaseParserFunc("8.54") = &H45BBB0 '' UPDATED
        BaseGetNextPacketFunc("8.54") = &H45BBE5 '' UPDATED
        BaseRecvStreamPtr("8.54") = &H78F7DC '' UPDATED

        'Outgoing Packet Composition
        'It seems all of these all change the same.
        'Meaning if one is altered by 20, the rest are as well
        SendMessage("8.54") = &H407310 '' UPDATED
        UseObjectFromGround("8.54") = &H406260 '' UPDATED
        UseObjectWithGround("8.54") = &H406450 '' UPDATED
        UseObjectWithCreature("8.54") = &H406670 '' UPDATED
        MoveObject("8.54") = &H405240 '' UPDATED
        BaseSpinNorth("8.54") = &H404BC0 '' UPDATED
        BaseSpinSouth("8.54") = &H404F00 '' UPDATED
        BaseSpinEast("8.54") = &H404D60 '' UPDATED
        BaseSpinWest("8.54") = &H4050A0 '' UPDATED
        BaseAttack("8.54") = &H408E40 '' UPDATED
        BaseStopActions("8.54") = &H40A0D0 '' UPDATED
        BaseLoggout("8.54") = &H4047D0 '' UPDATED
        BaseFollowFunc("8.54") = &H408C50 '' UPDATED
        'Trade
        BaseBuy("8.54") = &H405630 '' UPDATED
        BaseSell("8.54") = &H405810 '' UPDATED
        'OWN
        BaseCreatePacket("8.54") = &H4F3680
        BaseAddBytePacket("8.54") = &H4F3950
        BaseSendPacket("8.54") = &H4F4230



        'follow state
        BaseFollowState("8.54") = &H78FC18 '' UPDATED

        ''UNUSED
        ConsoleContextMenu("8.54") = &H4530D4 'not in use yet
        OnClickConsoleMenu("8.54") = &H44F3E0 'not in use yet
        OnClickConsoleMenuVF("8.54") = &H5B5E60 'not in use yet
        BaseDialog("8.54") = &H64510C 'not in use yet
        ClickPlayerName("8.54") = &H0 'Obsolete
        BaseSend("8.54") = &H5AF608 'obsolete
        BaseXtea("8.54") = &H78BF34 'Obsolete
        PeekCallFrom("8.54") = &H56F029 'Obsolete

    End Sub
#End Region

#Region "8.55 Base Addressess"
    Public Sub Initialize855Addresses()
        BaseExp("8.55") = &H63D2E4 'UPDATED
        BaseZ("8.55") = &H64CB28 'UPDATED
        BaseHead("8.55") = &H64A1C0 'UPDATED
        BaseTarget("8.55") = &H63D2BC 'UPDATED

        BaseConnection("8.55") = &H79A450 'UPDATED

        BaseBattle("8.55") = &H63D350 + 4 'UPDATED
        BaseBattleStep("8.55") = 168 'UPDATED

        BaseContainer("8.55") = &H64A238 'UPDATED

        BaseCharList("8.55") = &H79A404 'UPDATED
        BaseCharSelected("8.55") = &H79A400 'UPDATED
        BaseCharCount("8.55") = &H79A408 'UPDATED

        BaseDat("8.55") = &H796E04 'UPDATED
        BaseMap("8.55") = &H651640 'UPDATED

        BaseName1("8.55") = &H4F2119 'UPDATED
        BaseName2("8.55") = &H4F2123 'UPDATED

        BaseLevel1("8.55") = &H4F3FCA 'UPDATED
        BaseLevel2("8.55") = &H4F40CF 'UPDATED
        BaseLevel3("8.55") = &H4F4150 'UPDATED
        BaseLevelPtr("8.55") = &H649784 'UPDATED

        BaseStatusBar("8.55") = &H7DDCD4 + 4 'UPDATED

        BaseLightNop("8.55") = &H4EA8B9 'UPDATED
        BaseLightAmount("8.55") = &H4EA8BC 'UPDATED

        BaseScreenRect("8.55") = &H649784 'UPDATED
        BaseScreenBar("8.55") = &H7DDCCC 'UPDATED

        BaseFramRate("8.55") = &H79AF9C 'UPDATED

        BaseStart("8.55") = &H7DDCB8 'UPDATED

        'PRINT SHIT
        PrintName("8.55") = &H4F5133 'UPDATED
        PrintFPS("8.55") = &H45A058 'UPDATED
        ShowFPS("8.55") = &H63AF94 'UPDATED
        PrintTextFunc("8.55") = &H4B4130 'UPDATED
        NopFPS("8.55") = &H459F94 'UPDATED
        BaseGui("8.55") = &H4B8BE0 'UPDATED
        BaseRender("8.55") = &H4B4CF0 'UPDATED

        'CONTEXT MENUS
        AddContextMenuFunc("8.55") = &H4520F0 'UPDATED
        SetOutfitContextMenu("8.55") = &H453022 'UPDATED
        PartyActionContextMenu("8.55") = &H453073 'UPDATED
        CopyNameContextMenu("8.55") = &H45354D 'UPDATED
        TradeContextMenu("8.55") = &H452C99 'UPDATED
        OnClickContextMenu("8.55") = &H44E700 'UPDATED
        OnClickContextMenuVF("8.55") = &H5BCBD0 'UPDATED

        'CUSTOM CONTEXT MENUS BY ME
        OnClickVipMenu("8.55") = &H44F7B0 'UPDATED
        OnClickVipMenuVF("8.55") = &H5BCD98 'UPDATED
        VipListContextMenu("8.55") = &H453989 'UPDATED

        AttackContextMenu("8.55") = &H452D30 'UPDATED
        'VipGetNames
        VipNameHook("8.55") = &H45386F 'UPDATED
        VipNameFunc("8.55") = &H555E10 'UPDATED
        'Click names and shit
        ClickPlayerId("8.55") = &H79A4F8 'UPDATED
        ClickItemId("8.55") = &H79A4FC 'UPDATED

        'Hooked functions
        BasePeek("8.55") = &H5B7444 'UPDATED

        'Parser hook/own packet injection
        BaseParserFunc("8.55") = &H45C180 'UPDATED
        BaseGetNextPacketFunc("8.55") = &H45C1B5 'UPDATED
        BaseRecvStreamPtr("8.55") = &H796DD4 'UPDATED

        'Outgoing Packet Composition
        'It seems all of these all change the same.
        'Meaning if one is altered by 20, the rest are as well
        SendMessage("8.55") = &H4072F0 'UPDATED
        UseObjectFromGround("8.55") = &H406260 - &H20 'UPDATED
        UseObjectWithGround("8.55") = &H406450 - &H20 'UPDATED
        UseObjectWithCreature("8.55") = &H406670 - &H20 'UPDATED
        MoveObject("8.55") = &H405240 - &H20 'UPDATED
        BaseSpinNorth("8.55") = &H404BC0 - &H20 'UPDATED
        BaseSpinSouth("8.55") = &H404F00 - &H20 'UPDATED
        BaseSpinEast("8.55") = &H404D60 - &H20 'UPDATED
        BaseSpinWest("8.55") = &H4050A0 - &H20 'UPDATED
        BaseAttack("8.55") = &H408E40 - &H20 'UPDATED
        BaseStopActions("8.55") = &H40A0D0 - &H20 'UPDATED
        BaseLoggout("8.55") = &H4047D0 - &H20 'UPDATED
        BaseFollowFunc("8.55") = &H408C50 - &H20 'UPDATED
        'Trade
        BaseBuy("8.55") = &H405630 - &H20 'UPDATED
        BaseSell("8.55") = &H405810 - &H20 'UPDATED
        'OWN
        BaseCreatePacket("8.55") = &H4F7E30 'UPDATED
        BaseAddBytePacket("8.55") = &H4F8100 'UPDATED
        BaseSendPacket("8.55") = &H4F89E0 'UPDATED



        'follow state
        BaseFollowState("8.55") = &H797210 'UPDATED

        ''UNUSED
        ConsoleContextMenu("8.55") = &H4530D4 'not in use yet
        OnClickConsoleMenu("8.55") = &H44F3E0 'not in use yet
        OnClickConsoleMenuVF("8.55") = &H5B5E60 'not in use yet
        BaseDialog("8.55") = &H64510C 'not in use yet
        ClickPlayerName("8.55") = &H0 'Obsolete
        BaseSend("8.55") = &H5AF608 'obsolete
        BaseXtea("8.55") = &H78BF34 'Obsolete
        PeekCallFrom("8.55") = &H56F029 'Obsolete

    End Sub
#End Region

#Region "8.57 Base Addressess"
    Public Sub Initialize857Addresses()
        BaseExp("8.57") = &H63FE84 'updated
        BaseZ("8.57") = &H64F5F8 'updated
        BaseHead("8.57") = &H64CC90 'updated
        BaseTarget("8.57") = &H63FE5C 'updated

        BaseConnection("8.57") = &H79CF20 'updated

        BaseBattle("8.57") = &H63FEF0 + 4 'updated
        BaseBattleStep("8.57") = 168 'updated

        BaseContainer("8.57") = &H64CD08 'updated

        BaseCharList("8.57") = &H79CED4 'updated
        BaseCharSelected("8.57") = &H79CED0 'updated
        BaseCharCount("8.57") = &H79CED8 'updated

        BaseDat("8.57") = &H7998D4 'updated
        BaseMap("8.57") = &H654110 'updated

        BaseName1("8.57") = &H4F2689 'updated
        BaseName2("8.57") = &H4F2693 'updated

        BaseLevel1("8.57") = &H4F453A 'updated
        BaseLevel2("8.57") = &H4F463F 'updated
        BaseLevel3("8.57") = &H4F46C0 'updated
        BaseLevelPtr("8.57") = &H64C254 'updated

        BaseStatusBar("8.57") = &H7E07A8 'updated

        BaseLightNop("8.57") = &H4EAE29 'updated
        BaseLightAmount("8.57") = &H4EAE2C 'updated

        BaseScreenRect("8.57") = &H64C254 'updated
        BaseScreenBar("8.57") = &H7E079C 'updated

        BaseFramRate("8.57") = &H79DA6C 'updated

        BaseStart("8.57") = &H7E0788 'updated

        'PRINT SHIT
        PrintName("8.57") = &H4F56A3 'updated
        PrintFPS("8.57") = &H45A1F8 'updated
        ShowFPS("8.57") = &H63DB34 'updated
        PrintTextFunc("8.57") = &H4B4BB0 'updated
        NopFPS("8.57") = &H45A134 'updated
        BaseGui("8.57") = &H4B9560 'updated
        BaseRender("8.57") = &H4B5770 'updated

        'CONTEXT MENUS
        AddContextMenuFunc("8.57") = &H4522E0 'updated
        SetOutfitContextMenu("8.57") = &H453243 'updated
        PartyActionContextMenu("8.57") = &H45366C 'updated
        CopyNameContextMenu("8.57") = &H453750 'updated
        TradeContextMenu("8.57") = &H452E89 'updated
        OnClickContextMenu("8.57") = &H44E910 'updated
        OnClickContextMenuVF("8.57") = &H5BD9C0 'updated

        'CUSTOM CONTEXT MENUS BY ME
        OnClickVipMenu("8.57") = &H44F9C0 'updated
        OnClickVipMenuVF("8.57") = &H5BDB88 'updated
        VipListContextMenu("8.57") = &H453B39 'updated

        AttackContextMenu("8.57") = &H452F20 'updated
        'VipGetNames
        VipNameHook("8.57") = &H453A1F 'updated
        VipNameFunc("8.57") = &H5565B0 'updated
        'Click names and shit
        ClickPlayerId("8.57") = &H79CF24 'updated
        ClickItemId("8.57") = &H79CFCC 'updated

        'Hooked functions
        BasePeek("8.57") = &H5B8438 'updated

        'Parser hook/own packet injection
        BaseParserFunc("8.57") = &H45C310 'updated
        BaseGetNextPacketFunc("8.57") = &H45C345 'updated
        BaseRecvStreamPtr("8.57") = &H7998A4 'updated

        'Outgoing Packet Composition
        'It seems all of these all change the same.
        'Meaning if one is altered by 20, the rest are as well
        SendMessage("8.57") = &H407400 'updated
        UseObjectFromGround("8.57") = &H406350 'updated
        UseObjectWithGround("8.57") = &H406540 'updated
        UseObjectWithCreature("8.57") = &H406760 'updated
        MoveObject("8.57") = &H405240 - &H20 + &H110 'updated
        BaseSpinNorth("8.57") = &H404BC0 - &H20 + &H110 'updated
        BaseSpinSouth("8.57") = &H404F00 - &H20 + &H110 'updated
        BaseSpinEast("8.57") = &H404D60 - &H20 + &H110 'updated
        BaseSpinWest("8.57") = &H4050A0 - &H20 + &H110 'updated
        BaseAttack("8.57") = &H408F30 'updated
        BaseStopActions("8.57") = &H40A0D0 - &H20 + &H110 'updated
        BaseLoggout("8.57") = &H4048C0 'updated
        BaseFollowFunc("8.57") = &H408D40 'updated
        'Trade
        BaseBuy("8.57") = &H405720 'updated
        BaseSell("8.57") = &H405900 'updated
        'OWN
        BaseCreatePacket("8.57") = &H4F8110 'updated
        BaseAddBytePacket("8.57") = &H4F83E0 'updated
        BaseSendPacket("8.57") = &H4F8CC0 'updated



        'follow state
        BaseFollowState("8.57") = &H799CE0 'updated

        ''UNUSED
        ConsoleContextMenu("8.57") = &H4530D4 'not in use yet
        OnClickConsoleMenu("8.57") = &H44F3E0 'not in use yet
        OnClickConsoleMenuVF("8.57") = &H5B5E60 'not in use yet
        BaseDialog("8.57") = &H64510C 'not in use yet
        ClickPlayerName("8.57") = &H0 'Obsolete
        BaseSend("8.57") = &H5AF608 'obsolete
        BaseXtea("8.57") = &H78BF34 'Obsolete
        PeekCallFrom("8.57") = &H56F029 'Obsolete

    End Sub
#End Region

#Region "8.60 Base Addressess"
    Public Sub Initialize860Addresses()
        BaseExp("8.60") = &H63FE8C 'updated
        BaseZ("8.60") = &H64F600 'updated
        BaseHead("8.60") = &H64CC98 'updated
        BaseTarget("8.60") = &H63FE64 'updated

        BaseConnection("8.60") = &H79CF28 'updated

        BaseBattle("8.60") = &H63FEF8 + 4 'updated
        BaseBattleStep("8.60") = 168 'updated

        BaseContainer("8.60") = &H64CD10 'updated

        BaseCharList("8.60") = &H79CEDC 'updated
        BaseCharSelected("8.60") = &H79CED8 'updated
        BaseCharCount("8.60") = &H79CEE0 'updated

        BaseDat("8.60") = &H7998DC 'updated
        BaseMap("8.60") = &H654118 'updated

        BaseName1("8.60") = &H4F2809 'updated
        BaseName2("8.60") = &H4F2813 'updated

        BaseLevel1("8.60") = &H4F46BA 'updated
        BaseLevel2("8.60") = &H4F47BF 'updated
        BaseLevel3("8.60") = &H4F4840 'updated
        BaseLevelPtr("8.60") = &H64C25C 'updated

        BaseStatusBar("8.60") = &H7E07B0 'updated

        BaseLightNop("8.60") = &H4EAFA9 'updated
        BaseLightAmount("8.60") = &H4EAFAC 'updated

        BaseScreenRect("8.60") = &H64C25C 'updated
        BaseScreenBar("8.60") = &H7E07A4 'updated

        BaseFramRate("8.60") = &H79DA74 'updated

        BaseStart("8.60") = &H7E0790 'updated

        'PRINT SHIT
        PrintName("8.60") = &H4F5823 'updated
        PrintFPS("8.60") = &H45A258 'updated
        ShowFPS("8.60") = &H63DB3C 'updated
        PrintTextFunc("8.60") = &H4B4DD0 'updated
        NopFPS("8.60") = &H45A194 'updated
        BaseGui("8.60") = &H4B96E0 'updated
        BaseRender("8.60") = &H4B5990 'updated

        'CONTEXT MENUS
        AddContextMenuFunc("8.60") = &H452320 'updated
        SetOutfitContextMenu("8.60") = &H453283 'updated
        PartyActionContextMenu("8.60") = &H4531A2 'updated 'now at report offense
        CopyNameContextMenu("8.60") = &H453790 'updated
        TradeContextMenu("8.60") = &H452EC9 'updated
        OnClickContextMenu("8.60") = &H44E960 'updated
        OnClickContextMenuVF("8.60") = &H5BD9C0 'updated

        'CUSTOM CONTEXT MENUS BY ME
        OnClickVipMenu("8.60") = &H44FA10 'updated
        OnClickVipMenuVF("8.60") = &H5BDB88 'updated
        VipListContextMenu("8.60") = &H453B79 'updated

        AttackContextMenu("8.60") = &H452F60 'updated
        'VipGetNames
        VipNameHook("8.60") = &H453AF5 'updated
        VipNameFunc("8.60") = &H556AB0 'updated
        'Click names and shit
        ClickPlayerId("8.60") = &H79CFD8 'updated
        ClickItemId("8.60") = &H79CFD4 'updated

        'Hooked functions
        BasePeek("8.60") = &H5B8438 'updated

        'Parser hook/own packet injection
        BaseParserFunc("8.60") = &H45C370 'updated
        BaseGetNextPacketFunc("8.60") = &H45C3A5 'updated
        BaseRecvStreamPtr("8.60") = &H7998AC 'updated

        'Outgoing Packet Composition
        'It seems all of these all change the same.
        'Meaning if one is altered by 20, the rest are as well
        SendMessage("8.60") = &H407400 - 16 'updated
        UseObjectFromGround("8.60") = &H406350 - 16 'updated
        UseObjectWithGround("8.60") = &H406540 - 16 'updated
        UseObjectWithCreature("8.60") = &H406760 - 16 'updated
        MoveObject("8.60") = &H405320 'updated
        BaseSpinNorth("8.60") = &H404BC0 - &H20 + &H110 - 16 'updated
        BaseSpinSouth("8.60") = &H404F00 - &H20 + &H110 - 16 'updated
        BaseSpinEast("8.60") = &H404D60 - &H20 + &H110 - 16 'updated
        BaseSpinWest("8.60") = &H4050A0 - &H20 + &H110 - 16 'updated

        BaseAttack("8.60") = &H408F30 - 16 'updated
        BaseStopActions("8.60") = &H40A1D0 'updated
        BaseLoggout("8.60") = &H4048B0 'updated
        BaseFollowFunc("8.60") = &H408D30 'updated
        'Trade
        BaseBuy("8.60") = &H405720 - 16 'updated
        BaseSell("8.60") = &H405900 - 16 'updated


        'OWN
        BaseCreatePacket("8.60") = &H4F8290 'updated
        BaseAddBytePacket("8.60") = &H4F8560 'updated
        BaseSendPacket("8.60") = &H4F8E40 'updated



        'follow state
        BaseFollowState("8.60") = &H799CE8 'updated

        ''UNUSED
        ConsoleContextMenu("8.60") = &H4530D4 'not in use yet
        OnClickConsoleMenu("8.60") = &H44F3E0 'not in use yet
        OnClickConsoleMenuVF("8.60") = &H5B5E60 'not in use yet
        BaseDialog("8.60") = &H64510C 'not in use yet
        ClickPlayerName("8.60") = &H0 'Obsolete
        BaseSend("8.60") = &H5AF608 'obsolete
        BaseXtea("8.60") = &H78BF34 'Obsolete
        PeekCallFrom("8.60") = &H56F029 'Obsolete

    End Sub
#End Region

#Region "8.61 Base Addressess"
    Public Sub Initialize861Addresses()
        BaseExp("8.61") = &H634BCC 'updated
        BaseZ("8.61") = &H644260 'updated
        BaseHead("8.61") = &H6418F8 'updated
        BaseTarget("8.61") = &H634BA4 'updated

        BaseConnection("8.61") = &H791ABC 'updated

        BaseBattle("8.61") = &H634C38 + 4 'updated
        BaseBattleStep("8.61") = 168 'updated

        BaseContainer("8.61") = &H641970 'updated

        BaseCharList("8.61") = &H791A70 'updated
        BaseCharSelected("8.61") = &H791A6C 'updated
        BaseCharCount("8.61") = &H791A74 'updated

        BaseDat("8.61") = &H78E53C 'updated
        BaseMap("8.61") = &H648D78 'updated

        BaseName1("8.61") = &H4ED739 'updated
        BaseName2("8.61") = &H4ED743 'updated

        BaseLevel1("8.61") = &H4EF5EA 'updated
        BaseLevel2("8.61") = &H4EF6EF 'updated
        BaseLevel3("8.61") = &H4EF770 'updated
        BaseLevelPtr("8.61") = &H640EBC 'updated

        BaseStatusBar("8.61") = &H7D5340 'updated

        BaseLightNop("8.61") = &H4E5ED9 'updated
        BaseLightAmount("8.61") = &H4E5EDC 'updated

        BaseScreenRect("8.61") = &H640EBC 'updated
        BaseScreenBar("8.61") = &H7D5330 'updated

        BaseFramRate("8.61") = &H792604 'updated

        BaseStart("8.61") = &H7D5320 'updated

        'PRINT SHIT
        PrintName("8.61") = &H4F0753 'updated
        PrintFPS("8.61") = &H457C28 'updated
        ShowFPS("8.61") = &H63287C 'updated
        PrintTextFunc("8.61") = &H4B02B0 'updated
        NopFPS("8.61") = &H457B64 'updated
        BaseGui("8.61") = &H4B4AC0 'updated
        BaseRender("8.61") = &H4B0E70 'updated

        'CONTEXT MENUS
        AddContextMenuFunc("8.61") = &H450140 'updated
        SetOutfitContextMenu("8.61") = &H45105C 'updated
        PartyActionContextMenu("8.61") = &H450F84 'now at report offense
        CopyNameContextMenu("8.61") = &H4510C4 'updated
        TradeContextMenu("8.61") = &H450CE9 'updated
        OnClickContextMenu("8.61") = &H44CD60 'updated
        OnClickContextMenuVF("8.61") = &H5B5668 'updated

        'CUSTOM CONTEXT MENUS BY ME
        OnClickVipMenu("8.61") = &H44DD40 'updated
        OnClickVipMenuVF("8.61") = &H5B5830 'updated
        VipListContextMenu("8.61") = &H451934 'updated

        AttackContextMenu("8.61") = &H450D80 'updated
        'VipGetNames
        VipNameHook("8.61") = &H4517FF 'updated
        VipNameFunc("8.61") = &H550090 'updated
        'Click names and shit
        ClickPlayerId("8.61") = &H791B6C 'updated
        ClickItemId("8.61") = &H791B68 'updated

        'Hooked functions
        BasePeek("8.61") = &H5B0438 'UPDATED

        'Parser hook/own packet injection
        BaseParserFunc("8.61") = &H459BF0 'updated
        BaseGetNextPacketFunc("8.61") = &H459C25 'updated
        BaseRecvStreamPtr("8.61") = &H78E50C 'updated

        'Outgoing Packet Composition
        'It seems all of these all change the same.
        'Meaning if one is altered by 20, the rest are as well
        SendMessage("8.61") = &H4073D0 'updated
        UseObjectFromGround("8.61") = &H406320 'updated
        UseObjectWithGround("8.61") = &H406510 'updated
        UseObjectWithCreature("8.61") = &H406730 'updated
        MoveObject("8.61") = &H405300 'updated
        BaseSpinNorth("8.61") = &H404C80 'updated
        BaseSpinSouth("8.61") = &H404FC0 'updated
        BaseSpinEast("8.61") = &H404E20 'updated
        BaseSpinWest("8.61") = &H405160 'updated

        BaseAttack("8.61") = &H4089D0 'updated
        BaseStopActions("8.61") = &H409C80 'updated
        BaseLoggout("8.61") = &H404890 'updated
        BaseFollowFunc("8.61") = &H4087E0 'updated
        'Trade
        BaseBuy("8.61") = &H4056F0 'updated
        BaseSell("8.61") = &H4058D0 'updated


        'OWN
        BaseCreatePacket("8.61") = &H4F31C0 'updated
        BaseAddBytePacket("8.61") = &H4F3490 'updated
        BaseSendPacket("8.61") = &H4F3D70 'updated

        'follow state
        BaseFollowState("8.61") = &H78E948 'updated

        ''UNUSED
        ConsoleContextMenu("8.61") = &H4530D4 'not in use yet
        OnClickConsoleMenu("8.61") = &H44F3E0 'not in use yet
        OnClickConsoleMenuVF("8.61") = &H5B5E60 'not in use yet
        BaseDialog("8.61") = &H64510C 'not in use yet
        ClickPlayerName("8.61") = &H0 'Obsolete
        BaseSend("8.61") = &H5AF608 'obsolete
        BaseXtea("8.61") = &H78BF34 'Obsolete
        PeekCallFrom("8.61") = &H56F029 'Obsolete

    End Sub
#End Region

#Region "8.62 Base Addressess"
    Public Sub Initialize862Addresses()
        BaseExp("8.62") = &H637C4C 'updated
        BaseZ("8.62") = &H672428 'updated
        BaseHead("8.62") = &H66FAC0 'updated
        BaseTarget("8.62") = &H637C24 'updated

        BaseConnection("8.62") = &H7BFC84 'updated

        BaseBattle("8.62") = &H637CE0 + 4 'updated
        BaseBattleStep("8.62") = 168

        BaseContainer("8.62") = &H66FB38 'updated

        BaseCharList("8.62") = &H7BFC38 'updated
        BaseCharSelected("8.62") = &H7BFC34 'updated
        BaseCharCount("8.62") = &H7BFC3C 'updated

        BaseDat("8.62") = &H7BC704 'updated
        BaseMap("8.62") = &H676F40 'updated

        BaseName1("8.62") = &H4EE519 'updated
        BaseName2("8.62") = &H4EE523 'updated

        BaseLevel1("8.62") = &H4F038A 'updated
        BaseLevel2("8.62") = &H4F048F 'updated
        BaseLevel3("8.62") = &H4F0510 'updated
        BaseLevelPtr("8.62") = &H66F080 'updated
        BaseLevelAdd("8.62") = &H5BC0 'updated

        BaseStatusBar("8.62") = &H8034E8 + &H20 'updated

        BaseLightNop("8.62") = &H4E6C29 'updated
        BaseLightAmount("8.62") = &H4E6C2C 'updated

        BaseScreenRect("8.62") = &H640EBC 'no need atm
        BaseScreenBar("8.62") = &H7D5330 'no need atm

        BaseFramRate("8.62") = &H792604 'no need atm

        BaseStart("8.62") = &H8034E8 'updated

        'PRINT SHIT
        PrintName("8.62") = &H4F14F3 'updated
        PrintFPS("8.62") = &H458778 'updated
        ShowFPS("8.62") = &H6358FC 'updated
        PrintTextFunc("8.62") = &H4B0F70 'updated
        NopFPS("8.62") = &H4586B4 'updated
        BaseGui("8.62") = &H4B57A0 'updated
        BaseRender("8.62") = &H4B1B30 'updated

        'CONTEXT MENUS
        AddContextMenuFunc("8.62") = &H450C90 'updated
        SetOutfitContextMenu("8.62") = &H451BAC 'updated
        PartyActionContextMenu("8.62") = &H451BFD 'updated 'now at report offense
        CopyNameContextMenu("8.62") = &H451C14 'updated
        TradeContextMenu("8.62") = &H451839 'updated
        OnClickContextMenu("8.62") = &H44D870 'updated
        OnClickContextMenuVF("8.62") = &H5B7878 'updated

        'CUSTOM CONTEXT MENUS BY ME
        OnClickVipMenu("8.62") = &H44E850 'updated
        OnClickVipMenuVF("8.62") = &H5B7A40 'updated
        VipListContextMenu("8.62") = &H45249A 'updated

        AttackContextMenu("8.62") = &H4518D0 'updated
        'VipGetNames
        VipNameHook("8.62") = &H45234F 'updated
        VipNameFunc("8.62") = &H550EC0 'updated
        'Click names and shit
        ClickPlayerId("8.62") = &H7BFD34 'updated
        ClickItemId("8.62") = &H7BFD30 'updated

        'Hooked functions
        BasePeek("8.62") = &H5B2438 'updated

        'Parser hook/own packet injection
        BaseParserFunc("8.62") = &H45A740 'updated
        BaseGetNextPacketFunc("8.62") = &H45A775 'updated
        BaseRecvStreamPtr("8.62") = &H7BC6D4 'updated

        'Outgoing Packet Composition
        'It seems all of these all change the same.
        'Meaning if one is altered by 20, the rest are as well
        SendMessage("8.62") = &H407520
        UseObjectFromGround("8.62") = &H406320 + &H150 'updated
        UseObjectWithGround("8.62") = &H406510 + &H150 'updated
        UseObjectWithCreature("8.62") = &H406730 + &H150 'updated
        MoveObject("8.62") = &H405300 + &H150 'updated
        BaseSpinNorth("8.62") = &H404C80 + &H150 'updated
        BaseSpinSouth("8.62") = &H404FC0 + &H150 'updated
        BaseSpinEast("8.62") = &H404E20 + &H150 'updated
        BaseSpinWest("8.62") = &H405160 + &H150 'updated

        BaseAttack("8.62") = &H4089D0 + &H150 'updated
        BaseStopActions("8.62") = &H409C80 + &H150 'updated
        BaseLoggout("8.62") = &H404890 + &H150 'updated
        BaseFollowFunc("8.62") = &H4087E0 + &H150 'updated
        'Trade
        BaseBuy("8.62") = &H4056F0 + &H150 'updated
        BaseSell("8.62") = &H4058D0 + &H150 'updated


        'OWN
        BaseCreatePacket("8.62") = &H4F3F70 'updated
        BaseAddBytePacket("8.62") = &H4F4240 'updated
        BaseSendPacket("8.62") = &H4F4B20 'updated

        'follow state
        BaseFollowState("8.62") = &H7BCB10 'updated

        ''UNUSED
        ConsoleContextMenu("8.62") = &H4530D4 'not in use yet
        OnClickConsoleMenu("8.62") = &H44F3E0 'not in use yet
        OnClickConsoleMenuVF("8.62") = &H5B5E60 'not in use yet
        BaseDialog("8.62") = &H64510C 'not in use yet
        ClickPlayerName("8.62") = &H0 'Obsolete
        BaseSend("8.62") = &H5AF608 'obsolete
        BaseXtea("8.62") = &H78BF34 'Obsolete
        PeekCallFrom("8.62") = &H56F029 'Obsolete

    End Sub
#End Region


#Region "8.70 Base Addressess"
    Public Sub Initialize870Addresses()
        BaseExp("8.70") = &H63FD50 ''updated
        BaseZ("8.70") = &H67BA30 ''updated
        BaseHead("8.70") = &H6790C8 ''updated
        BaseTarget("8.70") = (&H63FD50 - 112) + 68 ''updated

        BaseConnection("8.70") = &H7C928C ''updated

        BaseBattle("8.70") = &H63FDE8 + 4 ''updated
        BaseBattleStep("8.70") = 172 ''updated

        BaseContainer("8.70") = &H679140 ''updated

        BaseCharList("8.70") = &H7C9240 ''updated
        BaseCharSelected("8.70") = &H7C923C ''updated
        BaseCharCount("8.70") = &H7C9244 ''updated

        BaseDat("8.70") = &H7C5D0C ''updated
        BaseMap("8.70") = &H680548 ''updated

        BaseName1("8.70") = &H4F2769 ''updated
        BaseName2("8.70") = &H4F2773 ''updated

        BaseLevel1("8.70") = &H4F465A ''updated
        BaseLevel2("8.70") = &H4F475F ''updated
        BaseLevel3("8.70") = &H4F47E0 ''updated
        BaseLevelPtr("8.70") = &H67868C ''updated
        BaseLevelAdd("8.70") = &H5BC0 ''updated

        BaseStatusBar("8.70") = &H80CAF0 + &H20 ''updated

        BaseLightNop("8.70") = &H4EACD9 ''updated
        BaseLightAmount("8.70") = &H4EACDC ''updated

        BaseScreenRect("8.70") = &H640EBC 'no need atm
        BaseScreenBar("8.70") = &H7D5330 'no need atm

        BaseFramRate("8.70") = &H792604 'no need atm

        BaseStart("8.70") = &H80CAF0 ''updated

        'PRINT SHIT
        PrintName("8.70") = &H4F57C3 ''updated
        PrintFPS("8.70") = &H45A6A8 ''updated
        ShowFPS("8.70") = &H63D9FC ''updated
        PrintTextFunc("8.70") = &H4B4D50 ''updated
        NopFPS("8.70") = &H45A5E4 ''updated
        BaseGui("8.70") = &H4B9620 ''updated
        BaseRender("8.70") = &H4B5910 ''updated

        'CONTEXT MENUS
        AddContextMenuFunc("8.70") = &H452BA0 ''updated
        SetOutfitContextMenu("8.70") = &H453AE6 ''updated
        PartyActionContextMenu("8.70") = &H4539E4 'now at report offense ''updated
        CopyNameContextMenu("8.70") = &H453B4E ''updated
        TradeContextMenu("8.70") = &H453749 ''updated
        OnClickContextMenu("8.70") = &H44F760 ''updated
        OnClickContextMenuVF("8.70") = &H5BDB60 ''updated

        'CUSTOM CONTEXT MENUS BY ME
        OnClickVipMenu("8.70") = &H450760 ''updated
        OnClickVipMenuVF("8.70") = &H5BDD28 ''updated
        VipListContextMenu("8.70") = &H4543EA ''updated

        AttackContextMenu("8.70") = &H4537E0 ''updated
        'VipGetNames
        VipNameHook("8.70") = &H4F429F ''updated
        VipNameFunc("8.70") = &H5568C0 ''updated
        'Click names and shit
        ClickPlayerId("8.70") = &H7C933C ''updated
        ClickItemId("8.70") = &H7C9338 ''updated

        'Hooked functions
        BasePeek("8.70") = &H5B8438 ''updated

        'Parser hook/own packet injection
        BaseParserFunc("8.70") = &H45C670 ''updated
        BaseGetNextPacketFunc("8.70") = &H45C6A5 ''updated
        BaseRecvStreamPtr("8.70") = &H7C5CDC ''updated

        'Outgoing Packet Composition
        'It seems all of these all change the same.
        'Meaning if one is altered by 20, the rest are as well
        SendMessage("8.70") = &H407550 ''updated
        UseObjectFromGround("8.70") = &H4064A0 ''updated
        UseObjectWithGround("8.70") = &H406690 ''updated
        UseObjectWithCreature("8.70") = &H4068B0 ''updated
        MoveObject("8.70") = &H405480 ''updated
        BaseSpinNorth("8.70") = &H404C80 + &H150 + 48 ''updated
        BaseSpinSouth("8.70") = &H404FC0 + &H150 + 48 ''updated
        BaseSpinEast("8.70") = &H404E20 + &H150 + 48 ''updated
        BaseSpinWest("8.70") = &H405160 + &H150 + 48 ''updated

        BaseAttack("8.70") = &H408B50 ''updated
        BaseStopActions("8.70") = &H409E00  ''updated
        BaseLoggout("8.70") = &H404A10  ''updated
        BaseFollowFunc("8.70") = &H408960  ''updated
        'Trade
        BaseBuy("8.70") = &H405870  ''updated
        BaseSell("8.70") = &H405A50  ''updated


        'OWN
        BaseCreatePacket("8.70") = &H4F8240 ''updated
        BaseAddBytePacket("8.70") = &H4F8510 ''updated
        BaseSendPacket("8.70") = &H4F8DF0 ''updated

        'follow state
        BaseFollowState("8.70") = &H7C6118 ''updated

        ''UNUSED
        ConsoleContextMenu("8.70") = &H4530D4 'not in use yet
        OnClickConsoleMenu("8.70") = &H44F3E0 'not in use yet
        OnClickConsoleMenuVF("8.70") = &H5B5E60 'not in use yet
        BaseDialog("8.70") = &H64510C 'not in use yet
        ClickPlayerName("8.70") = &H0 'Obsolete
        BaseSend("8.70") = &H5AF608 'obsolete
        BaseXtea("8.70") = &H78BF34 'Obsolete
        PeekCallFrom("8.70") = &H56F029 'Obsolete

    End Sub
#End Region


#Region "8.71 Base Addressess"
    Public Sub Initialize871Addresses()
        BaseExp("8.71") = &H63FD50 ''updated
        BaseZ("8.71") = &H67BA30 ''updated
        BaseHead("8.71") = &H6790C8 ''updated
        BaseTarget("8.71") = (&H63FCE0) + 68 ''updated

        BaseConnection("8.71") = &H7C928C ''updated

        BaseBattle("8.71") = &H63FDE8 + 4 ''updated
        BaseBattleStep("8.71") = 172 ''updated

        BaseContainer("8.71") = &H679140 ''updated

        BaseCharList("8.71") = &H7C9240 ''updated
        BaseCharSelected("8.71") = &H7C923C ''updated
        BaseCharCount("8.71") = &H7C9244 ''updated

        BaseDat("8.71") = &H7C5D0C ''updated
        BaseMap("8.71") = &H680548 ''updated

        BaseName1("8.71") = &H4F2793 ''updated
        BaseName2("8.71") = &H4F2789 ''updated

        BaseLevel1("8.71") = &H4F467A ''updated
        BaseLevel2("8.71") = &H4F477F ''updated
        BaseLevel3("8.71") = &H4F4800 ''updated
        BaseLevelPtr("8.71") = &H67868C ''updated
        BaseLevelAdd("8.71") = &H5BC0 ''updated

        BaseStatusBar("8.71") = &H80CAF0 + &H20 ''updated

        BaseLightNop("8.71") = &H4EACF9 ''updated
        BaseLightAmount("8.71") = &H4EACFC ''updated

        BaseScreenRect("8.71") = &H640EBC 'no need atm
        BaseScreenBar("8.71") = &H7D5330 'no need atm

        BaseFramRate("8.71") = &H792604 'no need atm

        BaseStart("8.71") = &H80CAF0 ''updated

        'PRINT SHIT
        PrintName("8.71") = &H4F57E3 ''updated
        PrintFPS("8.71") = &H45A6C8 ''updated
        ShowFPS("8.71") = &H63D9FC ''updated
        PrintTextFunc("8.71") = &H4B4D70 ''updated
        NopFPS("8.71") = &H45A604 ''updated
        BaseGui("8.71") = &H4B9640 ''updated
        BaseRender("8.71") = &H4B5930 ''updated

        'CONTEXT MENUS
        AddContextMenuFunc("8.71") = &H452BC0 ''updated
        SetOutfitContextMenu("8.71") = &H453ADC ''updated
        PartyActionContextMenu("8.71") = &H453B57 'now at report offense ''updated
        CopyNameContextMenu("8.71") = &H453B6E ''updated
        TradeContextMenu("8.71") = &H453769 ''updated
        OnClickContextMenu("8.71") = &H44F780 ''updated
        OnClickContextMenuVF("8.71") = &H5BDB80 ''updated

        'CUSTOM CONTEXT MENUS BY ME
        OnClickVipMenu("8.71") = &H450780 ''updated
        OnClickVipMenuVF("8.71") = &H5BDD48 ''updated
        VipListContextMenu("8.71") = &H45440A ''updated

        AttackContextMenu("8.71") = &H453800 ''updated
        'VipGetNames
        VipNameHook("8.71") = &H4F42BF ''updated
        VipNameFunc("8.71") = &H5568E0 ''updated
        'Click names and shit
        ClickPlayerId("8.71") = &H7C933C ''updated
        ClickItemId("8.71") = &H7C9338 ''updated

        'Hooked functions
        BasePeek("8.71") = &H5B8438 ''updated

        'Parser hook/own packet injection
        BaseParserFunc("8.71") = &H45C690 ''updated
        BaseGetNextPacketFunc("8.71") = &H45C6C5 ''updated
        BaseRecvStreamPtr("8.71") = &H7C5CDC ''updated

        'Outgoing Packet Composition
        'It seems all of these all change the same.
        'Meaning if one is altered by 20, the rest are as well
        SendMessage("8.71") = &H407550 ''updated
        UseObjectFromGround("8.71") = &H4064A0 ''updated
        UseObjectWithGround("8.71") = &H406690 ''updated
        UseObjectWithCreature("8.71") = &H4068B0 ''updated
        MoveObject("8.71") = &H405480 ''updated
        BaseSpinNorth("8.71") = &H404C80 + &H150 + 48 ''updated
        BaseSpinSouth("8.71") = &H404FC0 + &H150 + 48 ''updated
        BaseSpinEast("8.71") = &H404E20 + &H150 + 48 ''updated
        BaseSpinWest("8.71") = &H405160 + &H150 + 48 ''updated

        BaseAttack("8.71") = &H408B50 ''updated
        BaseStopActions("8.71") = &H409E00  ''updated
        BaseLoggout("8.71") = &H404A10  ''updated
        BaseFollowFunc("8.71") = &H408960  ''updated
        'Trade
        BaseBuy("8.71") = &H405870  ''updated
        BaseSell("8.71") = &H405A50  ''updated


        'OWN
        BaseCreatePacket("8.71") = &H4F8260 ''updated
        BaseAddBytePacket("8.71") = &H4F8530 ''updated
        BaseSendPacket("8.71") = &H4F8E10 ''updated

        'follow state
        BaseFollowState("8.71") = &H7C6118 ''updated

        ''UNUSED
        ConsoleContextMenu("8.71") = &H4530D4 'not in use yet
        OnClickConsoleMenu("8.71") = &H44F3E0 'not in use yet
        OnClickConsoleMenuVF("8.71") = &H5B5E60 'not in use yet
        BaseDialog("8.71") = &H64510C 'not in use yet
        ClickPlayerName("8.71") = &H0 'Obsolete
        BaseSend("8.71") = &H5AF608 'obsolete
        BaseXtea("8.71") = &H78BF34 'Obsolete
        PeekCallFrom("8.71") = &H56F029 'Obsolete

    End Sub
#End Region
End Module
