#include "stdafx.h"
#include <string>
#include <windows.h>
#include "Constants.h"

namespace Consts {

	/* Displaying Text Stuff */
	DWORD ptrPrintName = 0;
	DWORD ptrPrintFPS = 0;
	DWORD ptrShowFPS = 0;
	DWORD ptrNopFPS = 0;

	/* Context Menu Stuff */
	DWORD ptrAddContextMenu = 0;
	DWORD ptrOnClickContextMenu = 0;
	DWORD ptrSetOutfitContextMenu = 0;
	DWORD ptrPartyActionContextMenu = 0;
	DWORD ptrCopyNameContextMenu = 0;
	DWORD ptrTradeWithContextMenu = 0;
	DWORD ptrAttackContextMenu = 0;

	DWORD ptrVipListContextMenu = 0;
	DWORD ptrConsoleContextMenu = 0;
	DWORD ptrOnClickContextMenuVf = 0;

	DWORD ptrCreatureSayDisplay = 0;

	DWORD ptrOnClickVipMenuVf = 0;
	DWORD ptrOnClickVipMenu = 0;

	DWORD ptrOnClickConsoleMenuVf = 0;
	DWORD ptrOnClickConsoleMenu = 0;

	DWORD Peek= 0;

	DWORD PtrGetVipName= 0;

	DWORD Connection= 0;

	DWORD ParserFuncPTR = 0;
	DWORD GetNextPacketFuncPTR = 0;
	DWORD RECVBufferADR = 0;

	DWORD BattleStep = 0;
}

/* DLL Injection Related Stuff */
HINSTANCE hMod = 0;
bool HookInjected = false;

/* Pipes */
std::string PipeName;
bool PipeConnected = false;
HANDLE PipeThread = 0;
BYTE Buffer[1024] = {0};


CRITICAL_SECTION PipeReadCriticalSection;
CRITICAL_SECTION NormalTextCriticalSection;
CRITICAL_SECTION CreatureTextCriticalSection;
CRITICAL_SECTION ContextMenuCriticalSection;
CRITICAL_SECTION OnClickCriticalSection;
CRITICAL_SECTION ItemRenderCriticalSection;
CRITICAL_SECTION DrawGuiCriticalSection;


