#pragma once

#if MSC_VER > 100
#pragma once
#endif

#ifndef _UTILS_H_
#define _UTILS_H_

#include <windows.h>
#include <list>
#include "Packet.h"

using namespace std;

void SendPipeData(Packet* packet);
extern HWND hwndTUG;
extern CRITICAL_SECTION QueuePacketCriticalSection;

extern HANDLE pipe;
extern OVERLAPPED overlapped;  

DWORD HookCall(DWORD dwAddress, DWORD dwFunction);
void UnhookCall(DWORD dwAddress, DWORD dwOldCall);
BYTE* Nop(DWORD dwAddress, int size);
void UnNop(DWORD dwAddress, BYTE* OldBytes, int size);

void VoidUnHookCall(DWORD dwCallAddress, LPDWORD dwOldCall);
DWORD InlineHookCall(DWORD dwCallAddress, DWORD dwNewAddress, LPDWORD pOldAddress);

bool case_insensitive_compare(string a, string b);
void RedirectIOToConsole();
#endif