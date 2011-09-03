#include "stdafx.h"
#include <windows.h>
#include <string>
#include <sstream>
#include <list>
#include "Constants.h"
#include "Packet.h"
#include "Context_Menus.h"
#include "iostream"
#include "GlobalVars.h"
#include "Utils.h"
#include "Hook.h"

using namespace std;

//contextmenu
//DWORD OldSetOutfitContextMenu = 0;  //Used for restoring SetOutfitContextMenu ~
//DWORD OldPartyActionContextMenu = 0;//Used for restoring PartyActionContextMenu ~
//DWORD OldCopyNameContextMenu = 0;   //Used for restoring CopyNameContextMenu ~
//DWORD OldTradeWithContextMenu = 0;
//DWORD OldVipListContextMenu = 0;
//DWORD OldConsoleContextMenu = 0;
Hook* OutfitMenuHook;
Hook* CopyMenuHook;
Hook* TradeMenuHook;
Hook* VipMenuHook;
Hook* ConsoleMenuHook;
Hook* AttackMenuHook;

void InjectContextMenuHooks(){
//PARTY IS DONE IN CORE


	OutfitMenuHook = new Hook(Consts::ptrSetOutfitContextMenu, (DWORD)&MySetOutfitContextMenu);
	OutfitMenuHook->Enable();

	CopyMenuHook = new Hook(Consts::ptrCopyNameContextMenu, (DWORD)&MyCopyNameContextMenu);
	CopyMenuHook->Enable();

	TradeMenuHook = new Hook(Consts::ptrTradeWithContextMenu, (DWORD)&MyTradeWithContextMenu);
	TradeMenuHook->Enable();

	VipMenuHook = new Hook(Consts::ptrVipListContextMenu, (DWORD)&MyVipListContextMenu);
	VipMenuHook->Enable();

	AttackMenuHook = new Hook(Consts::ptrAttackContextMenu, (DWORD)&MyAttackContextMenu);
	AttackMenuHook->Enable();

	//ConsoleMenuHook = new Hook(Consts::ptrPrintFPS,(DWORD)&MyPrintFps);
	//ConsoleMenuHook->Enable();
	
	//OldSetOutfitContextMenu = HookCall(Consts::ptrSetOutfitContextMenu, (DWORD)&MySetOutfitContextMenu);

	//OnClickContextMenuEvent..
	DWORD dwOldProtect, dwNewProtect, funcAddress;
	funcAddress = (DWORD)&MyOnClickContextMenu;
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)Consts::ptrOnClickContextMenuVf, 4, PAGE_READWRITE, &dwOldProtect);
	memcpy((LPVOID)Consts::ptrOnClickContextMenuVf, &funcAddress, 4);
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)Consts::ptrOnClickContextMenuVf, 4, dwOldProtect, &dwNewProtect); //Restore access

	//OnClickVIPMenu event
	funcAddress = (DWORD)&MyOnClickVipMenu;
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)Consts::ptrOnClickVipMenuVf, 4, PAGE_READWRITE, &dwOldProtect);
	memcpy((LPVOID)Consts::ptrOnClickVipMenuVf, &funcAddress, 4);
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)Consts::ptrOnClickVipMenuVf, 4, dwOldProtect, &dwNewProtect); //Restore access

	//OnClickConsoleMenu event
	//funcAddress = (DWORD)&MyOnClickConsoleMenu;
	//VirtualProtectEx(GetCurrentProcess(), (LPVOID)Consts::ptrOnClickConsoleMenuVf, 4, PAGE_READWRITE, &dwOldProtect);
	//memcpy((LPVOID)Consts::ptrOnClickConsoleMenuVf, &funcAddress, 4);
	//VirtualProtectEx(GetCurrentProcess(), (LPVOID)Consts::ptrOnClickConsoleMenuVf, 4, dwOldProtect, &dwNewProtect); //Restore access
}

void UnInjectContextMenuHooks()
{
	OutfitMenuHook->Disable();
	CopyMenuHook->Disable();
	TradeMenuHook->Disable();
	VipMenuHook->Disable();

	delete [] OutfitMenuHook;
	delete [] CopyMenuHook;
	delete [] TradeMenuHook;
	delete [] VipMenuHook;

	//if(OldSetOutfitContextMenu)
		//UnhookCall(Consts::ptrSetOutfitContextMenu, OldSetOutfitContextMenu);


	//OnClickContextMenuEvent..
	DWORD dwOldProtect, dwNewProtect, funcAddress;
	funcAddress = (DWORD)&MyOnClickContextMenu;
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)Consts::ptrOnClickContextMenuVf, 4, PAGE_READWRITE, &dwOldProtect);
	memcpy((LPVOID)Consts::ptrOnClickContextMenuVf, &Consts::ptrOnClickContextMenu, 4);
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)Consts::ptrOnClickContextMenuVf, 4, dwOldProtect, &dwNewProtect); //Restore access

	//OnClickVipmenu event
	funcAddress = (DWORD)&MyOnClickVipMenu;
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)Consts::ptrOnClickVipMenuVf, 4, PAGE_READWRITE, &dwOldProtect);
	memcpy((LPVOID)Consts::ptrOnClickVipMenuVf, &Consts::ptrOnClickVipMenu, 4);
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)Consts::ptrOnClickVipMenuVf, 4, dwOldProtect, &dwNewProtect); //Restore access

			//OnClickConsolemenu event
			//funcAddress = (DWORD)&MyOnClickConsoleMenu;
			//VirtualProtectEx(GetCurrentProcess(), (LPVOID)Consts::ptrOnClickConsoleMenuVf, 4, PAGE_READWRITE, &dwOldProtect);
			//memcpy((LPVOID)Consts::ptrOnClickConsoleMenuVf, &Consts::ptrOnClickConsoleMenu, 4);
			//VirtualProtectEx(GetCurrentProcess(), (LPVOID)Consts::ptrOnClickConsoleMenuVf, 4, dwOldProtect, &dwNewProtect); //Restore access
}


//TODO: onclick event
void __stdcall MySetOutfitContextMenu (int eventId, const char* text, const char* shortcut)
{
	//MessageBoxA(0, "MySetOutfitContextMenu", "Error!", MB_ICONERROR);
	AddContextMenu(eventId, text, shortcut);
	
	//FIX HERE
	list<ContextMenu>::iterator it;
	for(it = ContextMenus.begin(); it != ContextMenus.end(); ++it)
	{
		//SetOutfitContextMenu or AllMenus
		if(it->Type == 0x01 || it->Type == 0x00)
		{
			const char* custom = it->MenuText;
			const char* shortcut_ = "TUGBot";
			int eventid=it->EventId;

			if(it->HasSeparator == 0x00)
				AddContextMenu(eventid, custom, shortcut_);
			else if(it->HasSeparator == 0x01)
				AddContextMenuEx(eventid, custom, shortcut_);		
		}

	}	

}

void __stdcall MyCopyNameContextMenu (int eventId, const char* text, const char* shortcut)
{
	//MessageBoxA(0, "MyCopyNameContextMenu", "Error!", MB_ICONERROR);
	AddContextMenu(eventId, text, shortcut);

	//FIX HERE
	list<ContextMenu>::iterator it;
	for(it = ContextMenus.begin(); it != ContextMenus.end(); ++it)
	{
		//CopyNameContextMenu or AllMenus
		if(it->Type == 0x03 || it->Type == 0x07)
		{
			const char* custom = it->MenuText;
			const char* shortcut_ = "TUGBot";
			int eventid = it->EventId;

			if(it->HasSeparator == 0x00)
				AddContextMenu(eventid, custom, shortcut_);
			else if(it->HasSeparator == 0x01)
				AddContextMenuEx(eventid, custom, shortcut_);
		}
	}
}

void __stdcall MyTradeWithContextMenu (int eventId, const char* text, const char* shortcut)
{
	//MessageBoxA(0, "MyCopyNameContextMenu", "Error!", MB_ICONERROR);
	AddContextMenu(eventId, text, shortcut);

	//FIX HERE
	list<ContextMenu>::iterator it;
	for(it = ContextMenus.begin(); it != ContextMenus.end(); ++it)
	{
		//CopyNameContextMenu or AllMenus
		if(it->Type == 0x04)
		{
			const char* custom = it->MenuText;
			const char* shortcut_ = "TUGBot";
			int eventid = it->EventId;

			if(it->HasSeparator == 0x00)
				AddContextMenu(eventid, custom, shortcut_);
			else if(it->HasSeparator == 0x01)
				AddContextMenuEx(eventid, custom, shortcut_);
		}
	}
}

void __stdcall MyAttackContextMenu (int eventId, const char* text, const char* shortcut)
{
	//MessageBoxA(0, "MyCopyNameContextMenu", "Error!", MB_ICONERROR);
	AddContextMenu(eventId, text, shortcut);

	//FIX HERE
	list<ContextMenu>::iterator it;
	for(it = ContextMenus.begin(); it != ContextMenus.end(); ++it)
	{
		//CopyNameContextMenu or AllMenus
		if(it->Type == 0x08 || it->Type == 0x07)
		{
			const char* custom = it->MenuText;
			const char* shortcut_ = "TUGBot";
			int eventid = it->EventId;

			if(it->HasSeparator == 0x00)
				AddContextMenu(eventid, custom, shortcut_);
			else if(it->HasSeparator == 0x01)
				AddContextMenuEx(eventid, custom, shortcut_);
		}
	}
}

void __stdcall MyVipListContextMenu (int eventId, const char* text, const char* shortcut)
{
	//MessageBoxA(0, "MyVipListContextMenu", "Error!", MB_ICONERROR);
	AddContextMenu(eventId, text, shortcut);

	//FIX HERE
	list<ContextMenu>::iterator it;
	for(it = ContextMenus.begin(); it != ContextMenus.end(); ++it)
	{
		//CopyNameContextMenu or AllMenus
		if(it->Type == 0x05 || it->Type == 0x00 || it->Type == 0x07)
		{
			const char* custom = it->MenuText;
			const char* shortcut_ = "TUGBot";
			int eventid = it->EventId;

			if(it->HasSeparator == 0x00)
				AddContextMenu(eventid, custom, shortcut_);
			else if(it->HasSeparator == 0x01)
				AddContextMenuEx(eventid, custom, shortcut_);
		}
	}
}

void __stdcall MyConsoleContextMenu (int eventId, const char* text, const char* shortcut)
{
	//MessageBoxA(0, "MyConsoleContextMenu", "Error!", MB_ICONERROR);
	AddContextMenu(eventId, text, shortcut);

	//FIX HERE
	list<ContextMenu>::iterator it;
	for(it = ContextMenus.begin(); it != ContextMenus.end(); ++it)
	{
		//CopyNameContextMenu or AllMenus
		if(it->Type == 0x06 || it->Type == 0x00 || it->Type == 0x07)
		{
			//const char* custom = it->MenuText;
			//const char* shortcut_ = "TUGBot";
			//int eventid = it->EventId;

			//if(it->HasSeparator == 0x00)
				//AddContextMenu(eventid, custom, shortcut_);
			//else if(it->HasSeparator == 0x01)
				//AddContextMenuEx(eventid, custom, shortcut_);
		}
	}
}

//function from http://www.tpforums.org/forum/showthread.php?t=2399 by Vitor

void __stdcall MyOnClickContextMenu (int eventId)
{
    __asm mov esi, ecx //; Compiler will ensure esi register is safe to use

    if (eventId >= 0x2000)
    {
        __asm
        {
            push eventId
            mov ecx, esi //; Ensure ecx carries the right value - you never know!
            mov eax, Consts::ptrOnClickContextMenu
            call eax
        }
        return;
    }

	/*WARNING:
	Again, as AddContextMenu, this function is a thiscall. But, unfortunately this time,
	the registers that carry the this are ecx and eax, registers commonly used to do random
	tasks at function's epilogue (that is, the code executed by the compiler when it enters
	a function). If, however, you can confirm that your compiler does not change ecx - or
	that it does not change eax, case in which you could move eax to ecx - you are ok to go on.
	If you can not confirm or you are not sure, we have to go deeper.
	*/

    /* Either switch event IDs if application is C++ or, if using TibiaAPI, send this information to the caller code using a pipe.
     * Here, we'll exemplify using a switch statement.
     */

	Packet* packet = new Packet();
	packet->AddByte(0x0C);
	packet->AddDWord(eventId);
	SendPipeData(packet);
}

void __stdcall MyOnClickVipMenu (int eventId)
{
    __asm mov esi, ecx //; Compiler will ensure esi register is safe to use

    if (eventId >= 0x2000)
    {
        __asm
        {
            push eventId
            mov ecx, esi //; Ensure ecx carries the right value - you never know!
			mov eax, Consts::ptrOnClickVipMenu
            call eax
        }
        return;
    }

	Packet* packet = new Packet();
	packet->AddByte(0x0C);
	packet->AddDWord(eventId);
	SendPipeData(packet);
}

void __stdcall MyOnClickConsoleMenu (int eventId)
{
    __asm mov esi, ecx //; Compiler will ensure esi register is safe to use

    if (eventId >= 0x2000)
    {
        __asm
        {
            push eventId
            mov ecx, esi //; Ensure ecx carries the right value - you never know!
			mov eax, Consts::ptrOnClickVipMenu
            call eax
        }
        return;
    }

	Packet* packet = new Packet();
	packet->AddByte(0x0C);
	packet->AddDWord(eventId);
	SendPipeData(packet);
}