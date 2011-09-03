#if MSC_VER > 100
#pragma once
#endif

#ifndef _CONTEXT_MENUS_H_
#define _CONTEXT_MENUS_H_

#define AddContextMenu(eventId, text, shortcut)   \
		__asm push shortcut \
		__asm push text \
		__asm push eventId \
		__asm mov ecx, esi \
		__asm mov eax, Consts::ptrAddContextMenu \
		__asm call eax

#define AddContextMenuEx(eventId, text, shortcut)   \
		__asm mov byte ptr[esi+0x30], 1 \
		__asm push shortcut \
		__asm push text \
		__asm push eventId \
		__asm mov ecx, esi \
		__asm mov eax, Consts::ptrAddContextMenu \
		__asm call eax

void __stdcall MyTradeWithContextMenu(int eventId, const char* text, const char* shortcut);
void __stdcall MySetOutfitContextMenu(int eventId, const char* text, const char* shortcut);
void __stdcall MyCopyNameContextMenu(int eventId, const char* text, const char* shortcut);
void __stdcall MyVipListContextMenu(int eventId, const char* text, const char* shortcut);
void __stdcall MyConsoleContextMenu(int eventId, const char* text, const char* shortcut);
void __stdcall MyAttackContextMenu(int eventId, const char* text, const char* shortcut);

void __stdcall MyOnClickContextMenu(int eventId);
void __stdcall MyOnClickVipMenu(int eventId);

void InjectContextMenuHooks();
void UnInjectContextMenuHooks();

//Context Menu structure
extern struct ContextMenu
{
	int EventId;
	char *MenuText;
	BYTE Type;
	BYTE HasSeparator;
};
#endif