#include "StdAfx.h"
#include "Hook.h"

Hook::Hook(DWORD HookAddress, DWORD NewFunction)
{
	HookAtAddress = HookAddress;
	OldFuncAddress = HookAddress;
	NewFuncAddress = NewFunction;
}

void Hook::Enable(){
	DWORD dwOldProtect, dwNewProtect, dwNewCall;
	//CALL opcode = 0xE8 <4 byte for distance>
	BYTE callByte[5] = {0xE8, 0x00, 0x00, 0x00, 0x00};

	//Calculate the distance
	dwNewCall = NewFuncAddress - HookAtAddress - 5;
	memcpy(&callByte[1], &dwNewCall, 4);
	
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)(HookAtAddress), 5, PAGE_READWRITE, &dwOldProtect); //Gain access to read/write
	memcpy(&OldFuncAddress, (LPVOID)(HookAtAddress+1), 4); //Get the old function address for unhooking
	memcpy((LPVOID)(HookAtAddress), &callByte, 5); //Hook the function
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)(HookAtAddress), 5, dwOldProtect, &dwNewProtect); //Restore access
}

void Hook::Disable(){
	DWORD dwOldProtect, dwNewProtect;
	BYTE callByte[5] = {0xE8, 0x00, 0x00, 0x00, 0x00};

	memcpy(&callByte[1], &OldFuncAddress, 4);
	
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)(HookAtAddress), 5, PAGE_READWRITE, &dwOldProtect);
	memcpy((LPVOID)(HookAtAddress), &callByte, 5);
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)(HookAtAddress), 5, dwOldProtect, &dwNewProtect);
}

Hook::~Hook(void)
{
}
