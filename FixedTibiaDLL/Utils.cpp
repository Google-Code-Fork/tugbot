#include "StdAfx.h"
#include "Socket.h"
#include "Utils.h"
#include <fcntl.h>
#include <io.h>
#include "iostream"
#include "Constants.h"



HANDLE pipe;
OVERLAPPED overlapped = { 0 };
CRITICAL_SECTION QueuePacketCriticalSection;

//DWORD WINAPI _sendPipeDataInternal(LPVOID lpParam)
//{
//	Packet* packet = (Packet*)lpParam;
//	static LPVOID address = VirtualAlloc(NULL, 1024, MEM_COMMIT, PAGE_READWRITE);
//	int size = packet->GetSize() + 2; 
//
//	EnterCriticalSection(&QueuePacketCriticalSection);
//		memcpy(address, (LPVOID)packet->GetPacket(), size);
//		SendMessageA(hwndTUG, 0x0666, GetCurrentProcessId(), (LPARAM)address);
//	LeaveCriticalSection(&QueuePacketCriticalSection);
//
//	delete packet;
//	return 0;
//}

void SendPipeData(Packet* packet)
{
	if ((*(DWORD*)Consts::Connection) != 8) return;
	WriteFileEx(pipe, packet->GetPacket(), packet->GetSize()+2, &overlapped, NULL); 
	delete packet;
	//HANDLE RunThread = CreateThread(NULL, 0, _sendPipeDataInternal, &(*packet), 0, NULL);
	//CloseHandle(RunThread);
}

DWORD HookCall(DWORD dwAddress, DWORD dwFunction)
{   
	DWORD dwOldProtect, dwNewProtect, dwOldCall, dwNewCall;
	//CALL opcode = 0xE8 <4 byte for distance>
	BYTE callByte[5] = {0xE8, 0x00, 0x00, 0x00, 0x00};

	//Calculate the distance
	dwNewCall = dwFunction - dwAddress - 5;
	memcpy(&callByte[1], &dwNewCall, 4);
	
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)(dwAddress), 5, PAGE_READWRITE, &dwOldProtect); //Gain access to read/write
	memcpy(&dwOldCall, (LPVOID)(dwAddress+1), 4); //Get the old function address for unhooking
	memcpy((LPVOID)(dwAddress), &callByte, 5); //Hook the function
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)(dwAddress), 5, dwOldProtect, &dwNewProtect); //Restore access
	
	return dwOldCall; //Return old funtion address for unhooking
}

DWORD InlineHookCall(DWORD dwCallAddress, DWORD dwNewAddress, LPDWORD pOldAddress)
{
	DWORD dwOldProtect, dwNewProtect, dwOldCall, dwNewCall;
	BYTE call[5] = {0xE8, 0x00, 0x00, 0x00, 0x00};

	dwNewCall = dwNewAddress - dwCallAddress - 5;
	memcpy(&call[1], &dwNewCall, 4);

	VirtualProtectEx(GetCurrentProcess(), (LPVOID)(dwCallAddress), 5, PAGE_READWRITE, &dwOldProtect);
	if(pOldAddress)
	{
		memcpy(&dwOldCall, (LPVOID)(dwCallAddress+1), 4);
		*pOldAddress = dwCallAddress + dwOldCall + 5;
	}
	memcpy((LPVOID)(dwCallAddress), &call, 5);
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)(dwCallAddress), 5, dwOldProtect, &dwNewProtect);
	
	return dwOldCall;
}

void UnhookCall(DWORD dwAddress, DWORD dwOldCall)
{
	DWORD dwOldProtect, dwNewProtect;
	BYTE callByte[5] = {0xE8, 0x00, 0x00, 0x00, 0x00};

	memcpy(&callByte[1], &dwOldCall, 4);
	
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)(dwAddress), 5, PAGE_READWRITE, &dwOldProtect);
	memcpy((LPVOID)(dwAddress), &callByte, 5);
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)(dwAddress), 5, dwOldProtect, &dwNewProtect);
}

BYTE* Nop(DWORD dwAddress, int size)
{
	DWORD dwOldProtect, dwNewProtect;
	BYTE* OldBytes;
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)(dwAddress), size, PAGE_READWRITE, &dwOldProtect);
	OldBytes = new BYTE[size];
	memcpy(OldBytes, (LPVOID)(dwAddress), size);
	memset((LPVOID)(dwAddress), 0x90, size);
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)(dwAddress), size, dwOldProtect, &dwNewProtect);
	
	return OldBytes;
}

void UnNop(DWORD dwAddress, BYTE* OldBytes, int size)
{
	DWORD dwOldProtect, dwNewProtect;
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)(dwAddress), size, PAGE_READWRITE, &dwOldProtect);
	memcpy((LPVOID)(dwAddress), OldBytes, size);
	VirtualProtectEx(GetCurrentProcess(), (LPVOID)(dwAddress), size, dwOldProtect, &dwNewProtect);

	delete [] OldBytes;
	OldBytes = 0;
}

void VoidUnHookCall(DWORD dwCallAddress, LPDWORD dwOldCall)
{
    DWORD dwOldProtect, dwNewProtect;
   BYTE call[5] = {0xE8, 0x00, 0x00, 0x00, 0x00};

    memcpy(&call[1], &dwOldCall, 4);

    VirtualProtectEx(GetCurrentProcess(), (LPVOID)(dwCallAddress), 5, PAGE_READWRITE, &dwOldProtect);
    memcpy((LPVOID)(dwCallAddress), &call, 5);
    VirtualProtectEx(GetCurrentProcess(), (LPVOID)(dwCallAddress), 5, dwOldProtect, &dwNewProtect);
}




bool case_insensitive_compare(string a, string b) { 
	char char1, char2, blank = ' ';   
	int len1 = a.length(); 
	int len2 = b.length();  
	if (len1 != len2) return false ; 
	
	for (int i = 0 ; i < len1 ; ++i ) { 
		// get a single character from the current position in the string
		char1 = *(a.substr(i,1).data());
		char2 = *(b.substr(i,1).data()); 
		// make lowercase for compare 
		char1 |= blank;
		char2 |= blank; 
		//Test
		if (char1 == char2) continue; 
		return false; 
	} 
	//Everything matched up, return true
	return true; 
} 

void RedirectIOToConsole()
{
	int hConHandle;
	long lStdHandle;
	CONSOLE_SCREEN_BUFFER_INFO coninfo;
	FILE *fp;
	// allocate a console for this app
	AllocConsole();
	// set the screen buffer to be big enough to let us scroll text
	GetConsoleScreenBufferInfo(GetStdHandle(STD_OUTPUT_HANDLE), &coninfo);
	coninfo.dwSize.Y = 4000;
	SetConsoleScreenBufferSize(GetStdHandle(STD_OUTPUT_HANDLE), coninfo.dwSize);
	// redirect unbuffered STDOUT to the console
	lStdHandle = (long)GetStdHandle(STD_OUTPUT_HANDLE);
	hConHandle = _open_osfhandle(lStdHandle, _O_TEXT);
	fp = _fdopen( hConHandle, "w" );
	*stdout = *fp;
	setvbuf( stdout, NULL, _IONBF, 0 );
	// redirect unbuffered STDIN to the console
	lStdHandle = (long)GetStdHandle(STD_INPUT_HANDLE);
	hConHandle = _open_osfhandle(lStdHandle, _O_TEXT);
	fp = _fdopen( hConHandle, "r" );
	*stdin = *fp;
	setvbuf( stdin, NULL, _IONBF, 0 );
	// redirect unbuffered STDERR to the console
	lStdHandle = (long)GetStdHandle(STD_ERROR_HANDLE);
	hConHandle = _open_osfhandle(lStdHandle, _O_TEXT);
	fp = _fdopen( hConHandle, "w" );
	*stderr = *fp;
	setvbuf( stderr, NULL, _IONBF, 0 );

	// make cout, wcout, cin, wcin, wcerr, cerr, wclog and clog
	// point to console as well
	std::ios::sync_with_stdio();

}