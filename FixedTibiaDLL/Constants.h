#if MSC_VER > 100
#pragma once
#endif

#ifndef _CONSTANTS_H_
#define _CONSTANTS_H_

namespace Consts {

	/* Displaying Text Stuff */
	extern DWORD ptrPrintName;
	extern DWORD ptrPrintFPS;
	extern DWORD ptrShowFPS;
	extern DWORD ptrNopFPS;

	extern DWORD ptrAddContextMenu;
	extern DWORD ptrOnClickContextMenu;
	extern DWORD ptrSetOutfitContextMenu;
	extern DWORD ptrPartyActionContextMenu;
	extern DWORD ptrCopyNameContextMenu;
	extern DWORD ptrTradeWithContextMenu;
	extern DWORD ptrOnClickContextMenuVf;

	extern DWORD ptrVipListContextMenu;
	extern DWORD ptrConsoleContextMenu;

	extern DWORD ptrAttackContextMenu;

	extern DWORD ptrOnClickVipMenuVf;
	extern DWORD ptrOnClickVipMenu;

	extern DWORD ptrOnClickConsoleMenuVf;
	extern DWORD ptrOnClickConsoleMenu;

	extern DWORD Peek;

	extern DWORD PtrGetVipName;

	extern DWORD Connection;

	extern DWORD ParserFuncPTR;
	extern DWORD GetNextPacketFuncPTR;
	extern DWORD RECVBufferADR;

	extern DWORD BattleStep;
}

typedef void _PrintText(int nSurface, int nX, int nY, int nFont, int nRed, int nGreen, int nBlue, char* lpText, int nAlign);
static _PrintText *PrintText = 0; //(_PrintText*)0x4A3C00;

//Render Item
typedef void _RenderItem(int nSurface, int nX, int nY, int size, int itemId, int count, int uk1, int uk2, int uk3, int uk4, int nX1, int nY1, int s1, int s2, int countTextType, int CountTextR , int CountTextG , int CountTextB , int CountTextAlign , int CountTextVisible);
static _RenderItem *RenderItem = 0;

//DrawGUI
typedef void _DrawSkin(int nSurface, int X, int Y, int W, int H, int SkinId, int dX, int xY);
static _DrawSkin *DrawSkin = 0;

/* DLL Injection Related Stuff */
extern HINSTANCE hMod;
extern bool HookInjected;



/* Pipes */
extern std::string PipeName;
extern bool PipeConnected;
extern HANDLE PipeThread;
extern BYTE Buffer[1024];

extern CRITICAL_SECTION PipeReadCriticalSection;
extern CRITICAL_SECTION NormalTextCriticalSection;
extern CRITICAL_SECTION CreatureTextCriticalSection;
extern CRITICAL_SECTION ContextMenuCriticalSection;
extern CRITICAL_SECTION OnClickCriticalSection;
extern CRITICAL_SECTION ItemRenderCriticalSection;
extern CRITICAL_SECTION DrawGuiCriticalSection;

enum Direction : BYTE
    {
        Up = 0x00,
        Right = 0x01,
        Down = 0x02,
        Left = 0x03,
        UpRight = 0x05,
        DownRight = 0x06,
        DownLeft = 0x07,
        UpLeft = 0x08
    };


enum PipeConstantType : BYTE
{
        PrintName = 0x01,
        PrintFPS = 0x02,
        ShowFPS = 0x03,
        PrintTextFunc = 0x04,
        NopFPS = 0x05,
        AddContextMenuFunc = 0x06,
        OnClickContextMenu = 0x07,
        SetOutfitContextMenu = 0x08,
        PartyActionContextMenu = 0x09,
        CopyNameContextMenu = 0x0A,
		OnClickContextMenuVf = 0x0B,
		TradeWithContextMenu = 0x0C,
		RenderItemFunc = 0x0D,
		DrawSkinFunc = 0x0E,
		VipListContextMenu = 0x0F,
		SpeakFunc = 0x010,
		OnClickVipMenuVf = 0x011,
		OnClickVipMenu = 0x12,
		ConsoleContextMenu = 0x13,
		OnClickConsoleMenu = 0x14,
		OnClickConsoleMenuVf = 0x15,
		Peek = 0x16,
		UseFromGround = 0x17,
		MoveObjectFunc = 0x18,

		UseObjectFunc = 0x21,
		UseWithGround = 0x22,

		GetVipNameFunc = 0x23,
		GetVipNameDetour = 0x24,

		ClientStatus = 0x25,

		ParserFunc = 0x26,
		GetNextPacketFunc = 0x27,
		RecvBufferPtr = 0x28,

		adrSpinNorth = 0x29,
		adrSpinSouth = 0x30,
		adrSpinEast = 0x31,
		adrSpinWest = 0x32,
		adrAttackFunc = 0x33,
		adrFollowFunc = 0x34,
		adrStopFunc = 0x35,
		adrLogFunc = 0x36,

		BtlStep = 0x37,

		AtkContext = 0x38,

		BuyItemAdr = 0x39,
		SellItemAdr = 0x40,
		
		CreatePacket = 0x41,
		AddBytePacket = 0x42,
		SendPacket = 0x43,
		botHandle = 0x44
};

struct ToClientPacket
{
	int Size;
	BYTE Data[1024];
};

#endif
