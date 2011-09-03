#include "stdafx.h"
#include "Socket.h"
#include <windows.h>
#include <string>
#include <sstream>
#include <list>
#include <atlbase.h>
#include <assert.h>
#include "Constants.h"
#include "Core.h"
#include "Packet.h"
#include "Context_Menus.h"
#include <io.h>
#include "iostream"
#include "GlobalVars.h"
#include "Utils.h"
#include "DisplayHooks.h"
#include "Hook.h"


#ifdef _MANAGED
#pragma managed(push, off)
#endif

using namespace std;


//Hooking to check people talking
DWORD OldDisplayCreatureSay = 0;

DWORD OldGetNextPacket = 0;

//peek message
DWORD OrigPeekAddress = 0;

//Attack
DWORD AttackThis = 0;

Hook* PartyMenuHook;
list<ContextMenu> ContextMenus;

//Getting VIP rightclick name
extern DWORD OldGetVipName = 0;

void PipeOnRead(BYTE* Buffer);
void PipeThreadProc(HMODULE Module);
void CALLBACK ReadFileCompleted(DWORD errorCode, DWORD bytesCopied, OVERLAPPED* overlapped);  


//WndProc
DWORD CurrentPID;
BOOL fUnicode;
WNDPROC oldWndProc;
HWND hwndTibia;

struct pipePack
{
	BYTE data[1024];
	int size;
};

list<pipePack> pipePackets;
list<BYTE> KeyCodes;

//--- Subclass WndProc -----------------------------------------------------------

BOOL InArea(int x, int y, int inx, int iny, int width, int height){
	if (x >= inx && x <= inx + width)
		if (y >= iny && y <= iny + height)
			return true;

	return false;
}

bool needLeave = false;
bool TestHooks()
{
	if ((*(DWORD*)Consts::Connection) != 8)
	{
		return true;
	}
	else
	{
		return false;
	}
}

bool WINAPI MyPeekMessageA(LPMSG pMsg, HWND hwnd, UINT wMsgFilterMin, UINT wMsgFilterMax, UINT wRemoveMsg)
{	
	EnterCriticalSection(&QueuePacketCriticalSection);
	list<pipePack>::iterator it;
	for(it = pipePackets.begin(); it != pipePackets.end(); ++it)
	{
		PipeOnRead(it->data);
	}
	pipePackets.clear();
	LeaveCriticalSection(&QueuePacketCriticalSection);
	
	return oldPeek(pMsg, hwnd, wMsgFilterMin, wMsgFilterMax, wRemoveMsg);
}

bool shiftDown=false;
LRESULT WINAPI SubClassProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	//if (sock)
	//{
	//	int len;
	//	BYTE* data = sock->ReceiveBytes(len);
	//	if (len>0)
	//	{
	//		BYTE newData[1024];
	//		memcpy(newData, data, len);
	//		PipeOnRead(newData);
	//	}
	//}

	if (msg == 0x0666)
	{
		if (lParam > 0)
		{
			//PipeOnRead((BYTE*)lParam, (int)wParam);
			//DWORD breakz = 0xFFFF;
			//memcpy((LPVOID)lParam, (LPVOID)breakz, 2);
			//memset((LPVOID)lParam, 0xFF, 2);
			//VirtualFree((LPVOID)lParam, (SIZE_T)wParam, MEM_RELEASE);
		}
		return 0;
	}
	else if(msg == WM_LBUTTONDOWN || msg == WM_LBUTTONUP || msg == WM_RBUTTONUP || msg == WM_RBUTTONDOWN)
	{
		POINT pos;
		pos.x=(WORD)lParam;
		pos.y=(WORD)(lParam>>16);

		EnterCriticalSection(&ItemRenderCriticalSection);

			list<Item>::iterator niIT;
			for(niIT = DisplayItems.begin(); niIT != DisplayItems.end(); ++niIT)
			{	
				list<DisplayItem>::iterator nOB;
				for(nOB = niIT->ItemDisplays.begin(); nOB != niIT->ItemDisplays.end(); ++nOB)
				{
					if ( (InArea(pos.x, pos.y, niIT->x + nOB->ofx, niIT->y + nOB->ofy, niIT->Size, niIT->Size + 5))
						|| (InArea(pos.x, pos.y, niIT->x, niIT->y, niIT->Size, niIT->Size + 5)) )
					{
						//Mouse was clicked on this icon
						Packet* packet = new Packet();
					
						packet->AddByte(0x0F7);
						packet->AddWord((WORD)msg);
						packet->AddWord((WORD)pos.x);
						packet->AddWord((WORD)pos.y);
						SendPipeData(packet);
						LeaveCriticalSection(&ItemRenderCriticalSection);
						return 0;
					}
				}	
			}

		LeaveCriticalSection(&ItemRenderCriticalSection);

		/*Packet* packet = new Packet();
					
		packet->AddByte(0x0F7);
		packet->AddWord((WORD)msg);
		packet->AddWord((WORD)pos.x);
		packet->AddWord((WORD)pos.y);
		SendPipeData(packet);
		*/
	}
	else if (msg == WM_MOUSEMOVE)
	{
		POINT pos;
		pos.x=(WORD)lParam;
		pos.y=(WORD)(lParam>>16);


		EnterCriticalSection(&ItemRenderCriticalSection);

			list<Item>::iterator niIT;
			for(niIT = DisplayItems.begin(); niIT != DisplayItems.end(); ++niIT)
			{	
				list<DisplayItem>::iterator nOB;
				for(nOB = niIT->ItemDisplays.begin(); nOB != niIT->ItemDisplays.end(); ++nOB)
				{
					if ( (shiftDown == true)
						|| (InArea(pos.x-5, pos.y-5, niIT->x + nOB->ofx, niIT->y + nOB->ofy, niIT->Size + 10, niIT->Size + 15))
						|| (InArea(pos.x-5, pos.y-5, niIT->x, niIT->y, niIT->Size + 10, niIT->Size + 51)) )
					{
						//Mouse was clicked on this icon
						Packet* packet = new Packet();
					
						packet->AddByte(0x0F7);
						packet->AddWord((WORD)msg);
						packet->AddWord((WORD)pos.x);
						packet->AddWord((WORD)pos.y);
						SendPipeData(packet);
						LeaveCriticalSection(&ItemRenderCriticalSection);
						return 0;
					}
				}	
			}

		LeaveCriticalSection(&ItemRenderCriticalSection);


		/*Packet* packet = new Packet();
		packet->AddByte(0x0F7);
		packet->AddWord((WORD)msg);
		packet->AddWord((WORD)pos.x);
		packet->AddWord((WORD)pos.y);

		SendPipeData(packet);
		*/
	}
	else if (msg == WM_CHAR)
	{
		BYTE KeyCode = VkKeyScan((char)wParam) & 0xFF;
		
		list<BYTE>::iterator TestKey;
		BYTE Key;
		for(TestKey = KeyCodes.begin(); TestKey != KeyCodes.end(); ++TestKey)
		{
			Key = (BYTE)*TestKey;
			if (Key == KeyCode)
			{
				return 0;
			}
		}
	}
	else if (msg == WM_KEYDOWN || msg == WM_KEYUP)
	{
		BYTE PacketType;

		if (msg == WM_KEYDOWN)
			PacketType = 0x0F5;
		else
			PacketType = 0x0F6;

		//Keystrokes
		if (wParam == VK_CONTROL || wParam == VK_SHIFT)
		{
			if (wParam == VK_SHIFT)
			{
				if (msg == WM_KEYDOWN)
					shiftDown = true;
				else
					shiftDown = false;
			}
			
			Packet* packet = new Packet();
			packet->AddByte(PacketType);
			packet->AddByte((BYTE)wParam);
			SendPipeData(packet);
		}
		else if ((wParam == VK_END || wParam == VK_NEXT || wParam == VK_PRIOR || wParam ==  VK_HOME) && (msg == WM_KEYDOWN))
		{
			int extk = (lParam>>24);
			if ( extk == 1 )
			{
				list<BYTE>::iterator TestKey;
				BYTE Key;
				for(TestKey = KeyCodes.begin(); TestKey != KeyCodes.end(); ++TestKey)
				{
					Key = (BYTE)*TestKey;
					if (Key == (BYTE)wParam)
					{
						Packet* packet = new Packet();
						packet->AddByte(PacketType);
						packet->AddByte((BYTE)wParam);
						SendPipeData(packet);
						return 0;
					}
				}
			}
		}
		else
		{
			list<BYTE>::iterator TestKey;
			BYTE Key;
			for(TestKey = KeyCodes.begin(); TestKey != KeyCodes.end(); ++TestKey)
			{
				Key = (BYTE)*TestKey;
				if (Key == (BYTE)wParam)
				{
					Packet* packet = new Packet();
					packet->AddByte(PacketType);
					packet->AddByte((BYTE)wParam);
					SendPipeData(packet);
					return 0;
				}
			}
		}
	}

	return fUnicode ? CallWindowProcW(oldWndProc, hwnd, msg, wParam, lParam) : 
                                       CallWindowProcA(oldWndProc, hwnd, msg, wParam, lParam);
}

//--- Enum windows -- Used to get the Tibia HWND -------------------------------
BOOL CALLBACK EnumWindowsProc(HWND temp,LPARAM lParam)
{
	const char* wndText = new char[12];
	GetClassNameA(temp, (LPSTR)wndText, 12);
	if (strcmp(wndText, "TibiaClient") == 0)
	{
		DWORD pid;
		GetWindowThreadProcessId(temp, &pid);
		if (pid == (DWORD)lParam)
		{
			if (!hwndTibia || hwndTibia == 0)
			{
				hwndTibia = temp;
			}
		}

	}
	return TRUE;
}

//structure Tibia uses to work with buffers
struct TPacketStream
{
	LPVOID pBuffer;
	DWORD dwSize;
	DWORD dwPos;
};

//define types of functions we want to hook
//typedef void TF_PARSER();
//typedef int TF_GETNEXTPACKET();

//pointers to call original function
//TF_PARSER *TfParser = 0;
//TF_GETNEXTPACKET *TfGetNextPacket = NULL;

//pointer to Tibia packet stream
TPacketStream * pRecvStream = 0;

//flag indicates that we are sending to client
BOOL fSendingToClient = FALSE;

//--- SendToClient -------------------------------------------------------------
void SendToClient(LPBYTE pBuffer, DWORD dwSize)
{
	fSendingToClient = TRUE;

	TPacketStream StreamHolder = *pRecvStream;

	pRecvStream->pBuffer = pBuffer;
	pRecvStream->dwSize = dwSize;
	pRecvStream->dwPos = 0;

	TfParser();
	*pRecvStream = StreamHolder;

	fSendingToClient = FALSE;
}

//--- OnGetNextPacket event ----------------------------------------------------
int OnGetNextPacket()
{
	if(fSendingToClient)
	{
		if(pRecvStream->dwPos < pRecvStream->dwSize)
		{
			BYTE bNextCmd = *((LPBYTE)pRecvStream->pBuffer + pRecvStream->dwPos);;
			pRecvStream->dwPos++;
			return (int)bNextCmd;
		} else return -1;
	}

	//if ((*(DWORD*)Consts::Connection) != 8)
	//{
	//	//DisabledSpecialHooks = true;
	//	//UnhookCall(Consts::GetNextPacketFuncPTR, OldGetNextPacket);
	//	return TfGetNextPacket();//We are done parsing what we want, return what remains to the client
	//}

	bool Parsing = true;
	int iCmd = -1;
	Packet* packet;
	while (Parsing){
		iCmd = TfGetNextPacket();
		switch (iCmd){//Here I can parse istncoming packets and hide them from the client if needed
			case (int)0xB4://Text message packet
			{
				packet = new Packet;//Make packet
				packet->AddByte(0xF2);
				packet->AddByte(0xB4);//Add packet type (Text message)
				
				int Position = pRecvStream->dwPos;
				packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //color
				packet->AddString(Packet::ReadString((BYTE*)pRecvStream->pBuffer, &Position)); //message
				pRecvStream->dwPos = Position;

				SendPipeData(packet);
				break;
			}
			case (int)0x8C://Creature Update Health
			{
				packet = new Packet;//Make packet
				packet->AddByte(0xF2);
				packet->AddByte(0x8C);//Add packet type (Update creature health)

				int Position = pRecvStream->dwPos;
				packet->AddDWord(Packet::ReadDWord((BYTE*)pRecvStream->pBuffer, &Position)); //ID
				packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //New health
				pRecvStream->dwPos = Position;

				//Send the packet through the pipe
				SendPipeData(packet);
				break;
			}
			case (int)0x86://Creature Update Square
			{
				packet = new Packet;//Packet to bot
				packet->AddByte(0xF2);
				packet->AddByte(0x86);//Add packet type (Update creature square)

				int Position = pRecvStream->dwPos;
				packet->AddDWord(Packet::ReadDWord((BYTE*)pRecvStream->pBuffer, &Position)); //ID
				packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //Square color
				pRecvStream->dwPos = Position;
				//Send the packet through the pipe
				SendPipeData(packet);
				break;
			}
			case (int)0x6A:
			{
				//Tile add thing (FUCK THIS COMPLICATED PACKET JEJE)
				//We want this packet to be sent directly to the client to prevent debugs,
				//So we wont advance in the actual stream, just add an offset to current pos
				//We will then set "parsing" to false so the client gets this packet right away
				int Position = pRecvStream->dwPos;
				packet = new Packet;//Packet to bot
				packet->AddByte(0xF2);
				packet->AddByte(0x6A);//Add packet type (Tile add thing)

				packet->AddWord(Packet::ReadWord((BYTE*)pRecvStream->pBuffer, &Position)); //x
				packet->AddWord(Packet::ReadWord((BYTE*)pRecvStream->pBuffer, &Position)); //y
				packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //z
				packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //stack

				//Convert the thing type id to int
				int ThingId = Packet::ReadWord((BYTE*)pRecvStream->pBuffer, &Position);
				packet->AddWord(ThingId);

				if (ThingId = 0x0061 || ThingId == 0x0062){
					if (ThingId = 0x0061){//Known creature
						packet->AddDWord(Packet::ReadDWord((BYTE*)pRecvStream->pBuffer, &Position)); //ID
					}
					else if (ThingId == 0x0062){//Unknown
						packet->AddDWord(Packet::ReadDWord((BYTE*)pRecvStream->pBuffer, &Position)); //Remove ID
						packet->AddDWord(Packet::ReadDWord((BYTE*)pRecvStream->pBuffer, &Position)); // ID
						packet->AddString(Packet::ReadString((BYTE*)pRecvStream->pBuffer, &Position)); //name
					}

					//This next part is universal to known and unknown creatures
					packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //health
					packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //direction
					packet->AddWord(Packet::ReadWord((BYTE*)pRecvStream->pBuffer, &Position)); //outfit id
					packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //outfit head
					packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //outfit body
					packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //outfit legs
					packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //outfit feet
					packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //outfit addons
					packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //light level
					packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //light color
					packet->AddWord(Packet::ReadWord((BYTE*)pRecvStream->pBuffer, &Position)); //speed
					packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //Skull
					packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //Shield

					//Above 8.53 we have 1 byte for warmode
					if (Consts::BattleStep > 160 && ThingId == 0x0061){
						packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position));

						if (Consts::BattleStep > 164){
						//is blocking
							packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position));
						}
					}
				}
				else if (ThingId = 0x0063){//Creature is turning
					//4 bytes ID, 1 byte direction
					packet->AddDWord(Packet::ReadDWord((BYTE*)pRecvStream->pBuffer, &Position)); //ID
					packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //direction
				}
				else{//Its an item
					//1 byte, possible count. No dat reader in this DLL so we will check this with
					//the bot
					packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position));
				}
				//Send the packet through the pipe
				SendPipeData(packet);
				//pass this to the client now
				Parsing = false;
				break;
			}
			case (int)0xAA://Creature Speech
			{
				packet = new Packet;//Make packet
				packet->AddByte(0xF2);
				packet->AddByte(0xAA);//Add packet type (Creature Speech)

				int Position = pRecvStream->dwPos;
				packet->AddDWord(Packet::ReadDWord((BYTE*)pRecvStream->pBuffer, &Position)); //Unknown
				packet->AddString(Packet::ReadString((BYTE*)pRecvStream->pBuffer, &Position)); //Name
				packet->AddWord(Packet::ReadWord((BYTE*)pRecvStream->pBuffer, &Position)); //Level
				
				BYTE SpeechType = Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position);
				packet->AddByte(SpeechType);

				if (SpeechType >= 0x01 && SpeechType <= 0x03)
				{
					packet->AddWord(Packet::ReadWord((BYTE*)pRecvStream->pBuffer, &Position)); //x
					packet->AddWord(Packet::ReadWord((BYTE*)pRecvStream->pBuffer, &Position)); //y
					packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //z
					packet->AddString(Packet::ReadString((BYTE*)pRecvStream->pBuffer, &Position)); //message
					
					SendPipeData(packet);
				}
				else if(SpeechType == 0x07)
				{
					packet->AddWord(Packet::ReadWord((BYTE*)pRecvStream->pBuffer, &Position)); //channel id
					packet->AddString(Packet::ReadString((BYTE*)pRecvStream->pBuffer, &Position)); //message
					SendPipeData(packet);
				}

				Parsing = false;
				break;
			}
			case (int)0x7A://Open Shop
			{
				packet = new Packet;//Make packet
				packet->AddByte(0xF3);
				//Send the packet through the pipe
				SendPipeData(packet);
				//pass this to the client now
				Parsing = false;
				break;
			}
			case (int)0x7C://close Shop
			{
				packet = new Packet;//Make packet
				packet->AddByte(0xF4);
				//Send the packet through the pipe
				SendPipeData(packet);
				//pass this to the client now
				Parsing = false;
				break;
			}
			case (int)0x85://Projectile
			{
				int pos = 0;//The offset
				packet = new Packet;//Make packet
				packet->AddByte(0xF2);
				packet->AddByte(0x85);//Add packet type (Projectile)

				//2 bytes Xfrom, 2 bytes Yfrom, 1b byte Zfrom
				//2 bytes Xto, 2 bytes Yto, 1b byte Zto
				//1 byte projectile type
				//11 bytes total

				int Position = pRecvStream->dwPos;
				packet->AddWord(Packet::ReadWord((BYTE*)pRecvStream->pBuffer, &Position)); //xfrom
				packet->AddWord(Packet::ReadWord((BYTE*)pRecvStream->pBuffer, &Position)); //yfrom
				packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //zfrom
				packet->AddWord(Packet::ReadWord((BYTE*)pRecvStream->pBuffer, &Position)); //xto
				packet->AddWord(Packet::ReadWord((BYTE*)pRecvStream->pBuffer, &Position)); //yto
				packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //zto
				packet->AddByte(Packet::ReadByte((BYTE*)pRecvStream->pBuffer, &Position)); //projectile type
				pRecvStream->dwPos = Position;

				//Send the packet through the pipe
				SendPipeData(packet);
				//pass this to the client now
				Parsing = false;
				break;
			}
			default:
			{	
				Parsing = false;
				break;
			}
		}
	}

	return iCmd;//We are done parsing what we want, return what remains to the client
}


void __stdcall MyGetVipName(char* arg1, char* arg2, char* arg3, char* name, char* arg5)
{	
	//Send the VIP name to bot
	Packet* packet = new Packet();
	packet->AddByte(0x0F1);
	packet->AddString(name);
	SendPipeData(packet);
	
	ContextMenuExtended(arg1,arg2,arg3,name,arg5);
}

void __stdcall MyPartyActionContextMenu (int eventId, const char* text, const char* shortcut)
{
	//MessageBoxA(0, "MyPartyActionContextMenu", "Error!", MB_ICONERROR);

	AddContextMenu(eventId, text, shortcut);

	//FIX HERE
	list<ContextMenu>::iterator it;
	for(it = ContextMenus.begin(); it != ContextMenus.end(); ++it)
	{
		//PartyActionContextMenu or AllMenus
		if(it->Type == 0x02 || it->Type == 0x00)
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

void InjectHooks(BYTE Inject){
	//	if(!PrintText || !DrawSkin || !RenderItem || !Consts::ptrPrintFPS || !Consts::ptrPrintName || !Consts::ptrShowFPS || !Consts::ptrNopFPS || 
	//	!Consts::ptrCopyNameContextMenu || !Consts::ptrPartyActionContextMenu || !Consts::ptrSetOutfitContextMenu
	//	|| !Consts::ptrOnClickContextMenuVf || !Consts::ptrTradeWithContextMenu || ! Consts::ptrVipListContextMenu
	//	|| !Consts::ptrOnClickVipMenu || !Consts::ptrOnClickVipMenuVf || !Consts::ptrConsoleContextMenu || !Consts::ptrOnClickConsoleMenuVf
	//	|| !Consts::ptrOnClickConsoleMenu || !Consts::Peek || !Consts::ptrCreatureSayDisplay) 
	//{
	//	MessageBoxA(0, "Wasnt able to inject! All hook values are not set!", "Error", MB_ICONEXCLAMATION);
	//}

	if(Inject == 0x01) 
	{
		if(HookInjected)
		{
			MessageBoxA(0, "The Hook is already injected!", "ERROR", MB_ICONEXCLAMATION);
		}
		else
		{
			InjectDisplayHooks();
			InjectContextMenuHooks();

			// VIPName
			OldGetVipName = HookCall(Consts::PtrGetVipName, (DWORD)&MyGetVipName);
			
			//Party menu
			PartyMenuHook = new Hook(Consts::ptrPartyActionContextMenu, (DWORD)&MyPartyActionContextMenu);
			PartyMenuHook->Enable();

			////Hook parser
			OldGetNextPacket = InlineHookCall(Consts::GetNextPacketFuncPTR, (DWORD)&OnGetNextPacket, (LPDWORD)&TfGetNextPacket);


			DWORD dwOldProtect, dwNewProtect, funcAddress;
			OrigPeekAddress=(DWORD)GetProcAddress(GetModuleHandleA("User32.dll"),"PeekMessageA");
			oldPeek=(_OldPeekMessageA)OrigPeekAddress;
			funcAddress = (DWORD)&MyPeekMessageA;
			VirtualProtect((LPVOID)Consts::Peek, 4, PAGE_READWRITE, &dwOldProtect);
			memcpy((LPVOID)Consts::Peek, &funcAddress, 4);
			VirtualProtect((LPVOID)Consts::Peek, 4, dwOldProtect, &dwNewProtect);


			HookInjected = true;
		}
	} 
	else 
	{
		if(!HookInjected) 
		{
			MessageBoxA(0, "CANNOT UNINJECT THE HOOK!", "ERROR", MB_ICONEXCLAMATION);
		}
		else
		{

			if (OldGetNextPacket)
				UnhookCall(Consts::GetNextPacketFuncPTR, OldGetNextPacket);

			UnInjectDisplayHooks();
			UnInjectContextMenuHooks();

			PartyMenuHook->Disable();

			delete [] PartyMenuHook;

			if (OldGetVipName)
				UnhookCall(Consts::PtrGetVipName, OldGetVipName);

			HookInjected = false; 


			//wnd proc
			fUnicode ? SetWindowLongPtrW(hwndTibia, GWLP_WNDPROC, (LONG_PTR)oldWndProc) : 
                        SetWindowLongPtrA(hwndTibia, GWLP_WNDPROC, (LONG_PTR)oldWndProc);
		}
	}
}

void __declspec(noreturn) UninjectSelf()
{       
        DWORD ExitCode=0;
        __asm
        {
                push hMod
                push ExitCode
                jmp dword ptr [FreeLibraryAndExitThread] 
        }
}

void StartUninjectSelf()
{
        try
        {
                CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)UninjectSelf, hMod, NULL, NULL);
        }
        catch (...)
        {
                #if _DEBUG
                        MessageBoxA(0,"StartUninjectSelf -> Unable to uninject from process." ,"TibiaAPI Injected DLL - Fatal Error", MB_ICONERROR | MB_TOPMOST );
                #endif
        }
}

void SetHookAddresses(PipeConstantType type, DWORD Address){
	switch(type)
	{
		case PrintName:
			{
				Consts::ptrPrintName = Address;
				break;
			}
		case PrintFPS:
			{
				Consts::ptrPrintFPS = Address;
				break;
			}
		case ShowFPS:
			{
				Consts::ptrShowFPS = Address;
				break;
			}
		case PrintTextFunc:
			{
				DisplaySetAddress((int)type, Address);
				break;
			}
		case NopFPS:
			{
				Consts::ptrNopFPS = Address;
				break;
			}
		case AddContextMenuFunc:
			{
				Consts::ptrAddContextMenu = Address;
				break;
			}
		case OnClickContextMenu:
			{
				Consts::ptrOnClickContextMenu = Address;
				break;
			}
		case SetOutfitContextMenu:
			{
				Consts::ptrSetOutfitContextMenu = Address;
				break;
			}
		case PartyActionContextMenu:
			{
				Consts::ptrPartyActionContextMenu = Address;
				break;
			}
		case CopyNameContextMenu:
			{
				Consts::ptrCopyNameContextMenu = Address;
				break;
			}
		case OnClickContextMenuVf:
			{
				Consts::ptrOnClickContextMenuVf = Address;
				break;
			}
		case TradeWithContextMenu:
			{
				Consts::ptrTradeWithContextMenu = Address;
				break;
			}
		case RenderItemFunc:
			{
				DisplaySetAddress((int)type, Address);
				break;
			}
		case DrawSkinFunc:
			{
				DisplaySetAddress((int)type, Address);
				break;
			}
		case VipListContextMenu:
			{
				Consts::ptrVipListContextMenu = Address;
				break;
			}
		case SpeakFunc:
			{//Speak function
				Speak = (_Speak*)Address;
				break;
			}
		case OnClickVipMenuVf:
			{
				Consts::ptrOnClickVipMenuVf = Address;
				break;
			}
		case OnClickVipMenu:
			{
				Consts::ptrOnClickVipMenu = Address;
				break;
			}
		case ConsoleContextMenu:
			{
				Consts::ptrConsoleContextMenu = Address;
				break;
			}
		case OnClickConsoleMenu:
			{
				Consts::ptrOnClickConsoleMenu = Address;
				break;
			}
		case OnClickConsoleMenuVf:
			{
				Consts::ptrOnClickConsoleMenuVf = Address;
				break;
			}
		case Peek:
			{
				Consts::Peek = Address;
				break;
			}
		case UseFromGround:
			{
				UseObjectFromGround = (_UseObjectFromGround*)Address;
				break;
			}
		case MoveObjectFunc:
			{//Move Object function
				MoveObject = (_MoveObject*)Address;
				break;
			}
		case UseObjectFunc:
			{
				UseObjectWithCreature = (_UseObjectWithCreature*)Address;
				break;
			}
		case UseWithGround:
			{
				UseObjectWithGround = (_UseObjectWithGround*)Address;
				break;
			}
		case GetVipNameFunc:
			{
				ContextMenuExtended = (_ContextMenuExtended*)Address;
				break;
			}
		case GetVipNameDetour:
			{
				Consts::PtrGetVipName = Address;
				break;
			}
		case ClientStatus:
			{
				Consts::Connection = Address;
				break;
			}
		case ParserFunc:
			{
				Consts::ParserFuncPTR = Address;
				TfParser = (TF_PARSER*)Consts::ParserFuncPTR;
				break;
			}
		case GetNextPacketFunc:
			{
				Consts::GetNextPacketFuncPTR = Address;
				break;
			}
		case RecvBufferPtr:
			{
				Consts::RECVBufferADR = Address;
				pRecvStream = (TPacketStream*)Consts::RECVBufferADR;
				break;
			}
		case adrSpinNorth:
			{
				SpinNorth = (_Spin*)Address;
				break;
			}
		case adrSpinSouth:
			{
				SpinSouth = (_Spin*)Address;
				break;
			}
		case adrSpinEast:
			{
				SpinEast = (_Spin*)Address;
				break;
			}
		case adrSpinWest:
			{
				SpinWest = (_Spin*)Address;
				break;
			}
		case adrAttackFunc:
			{
				Attack = (_Attack*)Address;
				break;
			}
		case adrFollowFunc:
			{
				Follow = (_Follow *)Address;
				break;
			}
		case adrStopFunc:
			{
				Stop = (_Stop *)Address;
				break;
			}
		case adrLogFunc:
			{
				Logout = (_Logout *)Address;
				break;
			}
		case BtlStep:
			{
				Consts::BattleStep = Address;
				break;
			}
		case AtkContext:
			{
				Consts::ptrAttackContextMenu = Address;
				break;
			}
		case BuyItemAdr:
			{
				BuyObject = (_BuyObject *)Address;
				break;
			}
		case SellItemAdr:
			{
				SellObject = (_SellObject *)Address;
				break;
			}
		case CreatePacket:
			{
				CreateTibiaPacket = (_CreateTibiaPacket*)Address;
				break;
			}
		case AddBytePacket:
			{
				TibiaPacketAddByte = (_TibiaPacketAddByte*)Address;
				break;
			}
		case SendPacket:
			{
				SendTibiaPacket = (_SendTibiaPacket*)Address;
				break;
			}
		case botHandle:
			{
				/*try
				{
					sock = new SocketClient("localhost", Address);
				} 
				catch (const char* s) {
					MessageBoxA(NULL,
					s,
					"Injection Error", 0);
				} 
				catch (std::string s) {
					MessageBoxA(NULL,
					s.c_str(),
					"Injection Error", 0);
				} 
				catch (...) {
					MessageBoxA(NULL,
					"Unhandler Exception",
					"Injection Error", 0);
				}

				HANDLE RunThread = CreateThread(NULL, 0, _socketListen, NULL, 0, NULL);
				hwndTUG = (HWND)Address;
				break;*/
			}
		default:
			break;
	};
}

void PipeOnRead(BYTE* Buffer)
{
	int position = 0;
	WORD len = Packet::ReadWord(Buffer, &position);
	BYTE PacketID = Packet::ReadByte(Buffer, &position);
	switch (PacketID){
		case 0x1: // Set Constant
			{
				PipeConstantType type = (PipeConstantType)Packet::ReadByte(Buffer, &position);
				DWORD ADR = Packet::ReadDWord(Buffer, &position);
				SetHookAddresses(type, ADR);
			}
			break;
		case 0x2: // DisplayText
			{
				BYTE Clear = Packet::ReadByte(Buffer, &position);
				string ClearThis = Packet::ReadString(Buffer, &position);

				WORD length = Packet::ReadWord(Buffer, &position);
				int i;
				
				EnterCriticalSection(&NormalTextCriticalSection);
				list<NormalText>::iterator ntIT;
				if (Clear==1)
				{
					for(ntIT = DisplayTexts.begin(); ntIT != DisplayTexts.end(); ) 
					{
						if (ntIT->TextName == ClearThis)
						{
							delete [] ntIT->TextName;
							delete [] ntIT->text;
							ntIT = DisplayTexts.erase(ntIT);
						} 
						else
						{
							++ntIT;
						}
					}
				}
				for (i=0;i<length;i++)
				{
					string TextName = Packet::ReadString(Buffer, &position);
					int PosX = Packet::ReadWord(Buffer, &position);
					int PosY = Packet::ReadWord(Buffer, &position);
					int ColorRed = Packet::ReadWord(Buffer, &position);
					int ColorGreen = Packet::ReadWord(Buffer, &position);
					int ColorBlue = Packet::ReadWord(Buffer, &position);
					int Font = Packet::ReadWord(Buffer, &position);
					int Align = Packet::ReadWord(Buffer, &position);
					string Text = Packet::ReadString(Buffer, &position);

					NormalText NewText;
					NewText.b = ColorBlue;
					NewText.g = ColorGreen;
					NewText.r = ColorRed;
					NewText.x = PosX;
					NewText.y = PosY;
					NewText.font = Font;
					NewText.align = Align;

					NewText.TextName = new char[TextName.size() + 1];
					NewText.text = new char[Text.size() + 1];

					memcpy(NewText.TextName, TextName.c_str(), TextName.size() + 1);
					memcpy(NewText.text, Text.c_str(), Text.size() + 1);


					DisplayTexts.push_back(NewText);
				}
				LeaveCriticalSection(&NormalTextCriticalSection);
			}
			break;
		case 0x3: //RemoveText
			{
				string RemovalTextName = Packet::ReadString(Buffer, &position);
				list<NormalText>::iterator ntIT;
				EnterCriticalSection(&NormalTextCriticalSection);

				for(ntIT = DisplayTexts.begin(); ntIT != DisplayTexts.end(); ) 
				{
					if (ntIT->TextName == RemovalTextName)
					{
						delete [] ntIT->TextName;
						delete [] ntIT->text;
						ntIT = DisplayTexts.erase(ntIT);
					} 
					else
						++ntIT;
				}

				LeaveCriticalSection(&NormalTextCriticalSection);
						
			}
			break;
		case 0x4: //Remove All
			{
				list<NormalText>::iterator ntIT;
				EnterCriticalSection(&NormalTextCriticalSection);

				for(ntIT = DisplayTexts.begin(); ntIT != DisplayTexts.end(); ++ntIT)
				{
					delete [] ntIT->text;
					delete [] ntIT->TextName;
				}

				DisplayTexts.clear();
				LeaveCriticalSection(&NormalTextCriticalSection);
			}
			break;
		case 0x5: //Inject Display
			{
				InjectHooks(Packet::ReadByte(Buffer, &position));
			}
			break;
		case 0x6: //Set Text Above Creature
			{
				int Id = Packet::ReadDWord(Buffer, &position);
				string CName = Packet::ReadString(Buffer, &position);
				int nX = Packet::ReadShort(Buffer, &position);
				int nY = Packet::ReadShort(Buffer, &position);
				int ColorR = Packet::ReadWord(Buffer, &position);
				int ColorG = Packet::ReadWord(Buffer, &position);
				int ColorB = Packet::ReadWord(Buffer, &position);
				int TxtFont = Packet::ReadWord(Buffer, &position);
				string Text = Packet::ReadString(Buffer, &position);
				char *lpText = (char*)calloc(Text.size() + 1, sizeof(char));
				char *cText = (char*)calloc(CName.size() + 1, sizeof(char));
				strcpy(lpText, Text.c_str());
				strcpy(cText, CName.c_str());
				PlayerText Creature = {0};
				Creature.cB = ColorB;
				Creature.cG = ColorG;
				Creature.cR = ColorR;
				Creature.CreatureId = Id;
				Creature.DisplayText = lpText;
				Creature.CreatureName = cText;
				Creature.RelativeX = nX;
				Creature.RelativeY = nY;
				Creature.TextFont = TxtFont;

				EnterCriticalSection(&CreatureTextCriticalSection);
				CreatureTexts.push_back(Creature);
				LeaveCriticalSection(&CreatureTextCriticalSection);
			}
			break;
		case 0x7: //Remove Text Above Creature
			{	
				int Id = Packet::ReadDWord(Buffer, &position);
				string Name = Packet::ReadString(Buffer, &position);
				
				list<PlayerText>::iterator ptIT;
				EnterCriticalSection(&CreatureTextCriticalSection);
				for(ptIT = CreatureTexts.begin(); ptIT != CreatureTexts.end(); ) 
				{
					if (ptIT->CreatureId == 0) 
					{
						if (ptIT->CreatureName == Name) 
						{
							free(ptIT->DisplayText);
							free(ptIT->CreatureName);
							ptIT->DisplayText = 0; //Just to make sure I won't try to free this twice
							ptIT->CreatureName = 0;
							ptIT = CreatureTexts.erase(ptIT);
						} 
						else
							++ptIT;
					} 
					else if (ptIT->CreatureId == Id) 
					{
						free(ptIT->DisplayText);
						free(ptIT->CreatureName);
						ptIT->DisplayText = 0; //Just to make sure I won't try to free this twice
						ptIT->CreatureName = 0;
						ptIT = CreatureTexts.erase(ptIT);
					} 
					else 
						++ptIT;
				}
				LeaveCriticalSection(&CreatureTextCriticalSection);
				
			}
			break;
		case 0x8: //Update Text Above Creature
			{
				int ID = Packet::ReadDWord(Buffer, &position);
				string CName = Packet::ReadString(Buffer, &position);
				int PosX = Packet::ReadShort(Buffer, &position);
				int PosY = Packet::ReadShort(Buffer, &position);
				string NewText = Packet::ReadString(Buffer, &position);
				char *lpNewText = (char*)calloc(NewText.size() + 1, sizeof(char));
				char *OldText;
				strcpy(lpNewText, NewText.c_str());
				
				EnterCriticalSection(&CreatureTextCriticalSection);

				list<PlayerText>::iterator newit;
				for(newit = CreatureTexts.begin(); newit != CreatureTexts.end(); ++newit) 
				{
					if (newit->CreatureId == 0) 
					{
						if (newit->CreatureName == CName && newit->RelativeX == PosX && newit->RelativeY == PosY) 
						{
							OldText = newit->DisplayText;
							strcpy(OldText, "");
							newit->DisplayText = lpNewText;
							free(OldText);
							OldText = 0;
							break;
						}
					}
					else if (newit->CreatureId == ID && newit->RelativeX == PosX && newit->RelativeY == PosY) 
					{
						OldText = newit->DisplayText;
						strcpy(OldText, "");
						newit->DisplayText = lpNewText;
						free(OldText);
						OldText = 0;
						break;
					}
				}

				LeaveCriticalSection(&CreatureTextCriticalSection);
			}
			break;
		case 0x9://add item to ContextMenus
			{
				int id = Packet::ReadDWord(Buffer, &position);
				string text=Packet::ReadString(Buffer, &position);
				BYTE type = Packet::ReadByte(Buffer,&position);
				BYTE hasSeparator=Packet::ReadByte(Buffer,&position);

				ContextMenu ctxt;
				ctxt.EventId = id;
				ctxt.Type = type;
				ctxt.HasSeparator = hasSeparator;               
				ctxt.MenuText = new char[text.size()+1];

				memcpy(ctxt.MenuText, text.c_str(), text.size() + 1);

				EnterCriticalSection(&ContextMenuCriticalSection);
				ContextMenus.push_back(ctxt);
				LeaveCriticalSection(&ContextMenuCriticalSection);
			}
			break;
		case 0xA://remove item from ContextMenus
			{
				//MessageBoxA(0, "Remove", "Error!", MB_ICONERROR);
				int id = Packet::ReadDWord(Buffer, &position);
				string text = Packet::ReadString(Buffer, &position);
				BYTE type = Packet::ReadByte(Buffer,&position);
				BYTE hasSeparator = Packet::ReadByte(Buffer,&position);

				EnterCriticalSection(&ContextMenuCriticalSection);

				list<ContextMenu>::iterator cmIT;
				for(cmIT = ContextMenus.begin(); cmIT != ContextMenus.end(); ) 
				{
					if (cmIT->EventId == id && cmIT->MenuText == text && cmIT->Type == type && cmIT->HasSeparator == hasSeparator)
					{
						delete [] cmIT->MenuText;
						cmIT = ContextMenus.erase(cmIT);
					} 
					else 
						++cmIT;
				}

				LeaveCriticalSection(&ContextMenuCriticalSection);
				break;
			}
		case 0xB://clear items from ContextMenus
			{
				list<ContextMenu>::iterator cmIT;

				EnterCriticalSection(&ContextMenuCriticalSection);

				for(cmIT = ContextMenus.begin(); cmIT != ContextMenus.end(); ++cmIT)
					delete [] cmIT->MenuText;

				ContextMenus.clear();

				LeaveCriticalSection(&ContextMenuCriticalSection);
				break;
			}
		case 0xC://Draw Item
			{
				WORD ClearButtons = Packet::ReadWord(Buffer, &position);
				WORD ButtonSize = Packet::ReadWord(Buffer, &position);
				WORD ButtonAmount = Packet::ReadWord(Buffer, &position);
				
				list<Item> TempDisplayItems;
				for (int i=0;i<ButtonAmount;i++){
					int ID, OffsetX, OffsetY, Count;
					DisplayItem TempDisp;
					Item TempItem;
					
					TempItem.Size = ButtonSize;

					TempItem.x = Packet::ReadWord(Buffer, &position);
					TempItem.y = Packet::ReadWord(Buffer, &position);
					TempItem.cR = Packet::ReadWord(Buffer, &position);
					TempItem.cG = Packet::ReadWord(Buffer, &position);
					TempItem.cB = Packet::ReadWord(Buffer, &position);
					//The text needs to be done special
					string Text = Packet::ReadString(Buffer, &position);
					TempItem.text = new char[Text.size() + 1];
					memcpy(TempItem.text, Text.c_str(), Text.size() + 1);

					WORD DisplayedItems = Packet::ReadWord(Buffer, &position);
					for (int a=0;a<DisplayedItems;a++){
						TempDisp.id = Packet::ReadWord(Buffer, &position);
						TempDisp.ofx = Packet::ReadShort(Buffer, &position);
						TempDisp.ofy = Packet::ReadShort(Buffer, &position);
						TempDisp.count = Packet::ReadShort(Buffer, &position);
						//Add the item to the buttons display
						TempItem.ItemDisplays.push_back(TempDisp);
					}

					TempDisplayItems.push_back(TempItem);
				}

				EnterCriticalSection(&ItemRenderCriticalSection);
					if (ClearButtons == 1)//Clear the buttons if needed
						DisplayItems.clear();
					
				list<Item>::iterator niIT;
				for(niIT = TempDisplayItems.begin(); niIT != TempDisplayItems.end(); ++niIT)
						DisplayItems.push_back(*niIT);
				LeaveCriticalSection(&ItemRenderCriticalSection);
			}
			break;
		case 0xD://Clear Items
			{
				EnterCriticalSection(&ItemRenderCriticalSection);
				DisplayItems.clear();
				LeaveCriticalSection(&ItemRenderCriticalSection);
			}
			break;
		case 0xE://Update Item
			{
				//Fix
			break;
			}
		case 0xF://Draw GUI
			{
				int Id = Packet::ReadWord(Buffer, &position);
				int Iden = Packet::ReadWord(Buffer, &position);
				int PosX = Packet::ReadWord(Buffer, &position);
				int PosY = Packet::ReadWord(Buffer, &position);
				int Width = Packet::ReadWord(Buffer, &position);
				int Height = Packet::ReadWord(Buffer, &position);

				Gui NewGui;

				NewGui.id = Id;
				NewGui.x = PosX;
				NewGui.y = PosY;
				NewGui.w = Width;
				NewGui.h = Height;
				NewGui.index = Iden;
					

				EnterCriticalSection(&DrawGuiCriticalSection);
				GuiDraws.push_back(NewGui);
				LeaveCriticalSection(&DrawGuiCriticalSection);
			break;
			}
		case 0x10: //Update GUI
			{
				int Id = Packet::ReadWord(Buffer, &position);
				int Iden = Packet::ReadWord(Buffer, &position);
				int PosX = Packet::ReadWord(Buffer, &position);
				int PosY = Packet::ReadWord(Buffer, &position);
				int Width = Packet::ReadWord(Buffer, &position);
				int Height = Packet::ReadWord(Buffer, &position);
			
				EnterCriticalSection(&DrawGuiCriticalSection);

				list<Gui>::iterator newit;
				for(newit = GuiDraws.begin(); newit != GuiDraws.end(); ++newit) 
				{
					if (newit->index == Iden) 
					{
						newit->id = Id;
						newit->h = Height;
						newit->w = Width;
						newit->x = PosX;
						newit->y = PosY;
					}
				}

				LeaveCriticalSection(&DrawGuiCriticalSection);
				break;
			}
		case 0x11://Clear GUI Items
			{
				EnterCriticalSection(&DrawGuiCriticalSection);
				GuiDraws.clear();
				LeaveCriticalSection(&DrawGuiCriticalSection);
				break;
			}
		case 0x12://Speak
			{
				int Type = Packet::ReadWord(Buffer, &position);
				string text = Packet::ReadString(Buffer, &position);

				Speak(Type, (char*)text.c_str());
				break;
			}
		case 0x13://Clear creature text
			{
				EnterCriticalSection(&CreatureTextCriticalSection);
				CreatureTexts.clear();
				LeaveCriticalSection(&CreatureTextCriticalSection);
				break;
			}
		case 0x14: //Move Item
			{
				int pos1 = Packet::ReadWord(Buffer, &position);
				int pos2 = Packet::ReadWord(Buffer, &position);
				int pos3 = Packet::ReadWord(Buffer, &position);
				int id = Packet::ReadWord(Buffer, &position);
				int stack = Packet::ReadWord(Buffer, &position);
				int pos4 = Packet::ReadWord(Buffer, &position);
				int pos5 = Packet::ReadWord(Buffer, &position);
				int pos6 = Packet::ReadWord(Buffer, &position);
				int count = Packet::ReadWord(Buffer, &position);

				MoveObject(pos1,pos2,pos3,id,stack,pos4,pos5,pos6,count);
			}
			break;
		case 0x15: //Use item with creature/use item
			{		
				int PosX = Packet::ReadWord(Buffer, &position);
				int PosY = Packet::ReadWord(Buffer, &position);
				int PosZ = Packet::ReadWord(Buffer, &position);
				int ItemID = Packet::ReadWord(Buffer, &position);
				int Stack = Packet::ReadByte(Buffer, &position);
				int CreatureID = Packet::ReadDWord(Buffer, &position);

				UseObjectWithCreature(PosX,PosY,PosZ,ItemID,Stack,CreatureID);
			}
			break;
		case 0x16: //Use from ground
			{
				int PosX = Packet::ReadWord(Buffer, &position);
				int PosY = Packet::ReadWord(Buffer, &position);
				int PosZ = Packet::ReadWord(Buffer, &position);
				int ItemID = Packet::ReadWord(Buffer, &position);
				int Stack = Packet::ReadByte(Buffer, &position);
				int Amount = Packet::ReadWord(Buffer, &position);

				UseObjectFromGround(PosX,PosY,PosZ,ItemID,Stack,Amount);		
			}
			break;
		case 0x17: //Use With Ground
		{
			int FromX = Packet::ReadWord(Buffer, &position);
			int FromY = Packet::ReadWord(Buffer, &position);
			int FromZ = Packet::ReadWord(Buffer, &position);
			int UseID = Packet::ReadWord(Buffer, &position);
			int FromStack = Packet::ReadByte(Buffer, &position);

			int ToX = Packet::ReadWord(Buffer, &position);
			int ToY = Packet::ReadWord(Buffer, &position);
			int ToZ = Packet::ReadWord(Buffer, &position);
			int UseWithID = Packet::ReadWord(Buffer, &position);
			int ToStack = Packet::ReadByte(Buffer, &position);

			int SelfX = Packet::ReadWord(Buffer, &position);
			int SelfY = Packet::ReadWord(Buffer, &position);
			int SelfZ = Packet::ReadWord(Buffer, &position);

			UseObjectWithGround(FromX,FromY,FromZ,UseID,
			FromStack, ToX, ToY, ToZ, UseWithID,
			ToStack,SelfX, SelfY, SelfZ);
		}
			break;
		case 0x18://Send to client
			{
				ToClientPacket NewPacket;
				NewPacket.Size = Packet::ReadWord(Buffer, &position);

				for (int i=0;i<NewPacket.Size;i++)
					NewPacket.Data[i] = Packet::ReadByte(Buffer, &position);

				SendToClient(NewPacket.Data, NewPacket.Size);
			}
			break;
		case 0x19://Spin
			{
				BYTE Dir = Packet::ReadByte(Buffer, &position);
				switch (Dir){
					case Direction::Up:
						SpinNorth();
						break;
					case Direction::Down:
						SpinSouth();
						break;
					case Direction::Left:
						SpinWest();
						break;
					case Direction::Right:
						SpinEast();
						break;
					default:
						break;
				}
			}
			break;
		case 0x20://Attack
			{
				Attack(Packet::ReadDWord(Buffer, &position));
			}
			break;
		case 0x21://Follow
			{
				Follow(Packet::ReadByte(Buffer, &position));
			}
			break;
		case 0x22://Stop
			{
				Stop();
			}
			break;
		case 0x23://Logout
			{
				Logout();
			}
			break;
		case 0x24://Buy Item
			{
				
				int ID = Packet::ReadWord(Buffer, &position);
				int Amount = Packet::ReadByte(Buffer, &position);
				int Count = Packet::ReadByte(Buffer, &position);
				int Bp = 0x012e300 + Packet::ReadByte(Buffer, &position);
				int Cap = 0x012e300 + Packet::ReadByte(Buffer, &position);

				BuyObject(ID,Amount,Count,Bp,Cap);
			}
			break;
		case 0x25://Sell Item
			{
				int ID = Packet::ReadWord(Buffer, &position);
				int Amount = Packet::ReadByte(Buffer, &position);
				int Count = Packet::ReadByte(Buffer, &position);
				int Ew = 0x012e300 + Packet::ReadByte(Buffer, &position);

				SellObject(ID,Amount,Count,Ew);
			}
			break;
		case 0x26://Add key
			{
				KeyCodes.push_back(Packet::ReadByte(Buffer, &position));
			}
		case 0x27://Remove key
			{
				BYTE Remove = Packet::ReadByte(Buffer, &position);

				list<BYTE>::iterator TestKey;
				BYTE Key;
				for(TestKey = KeyCodes.begin(); TestKey != KeyCodes.end(); ++TestKey)
				{
					Key = (BYTE)*TestKey;
					if (Key == Remove)
					{
						KeyCodes.erase(TestKey);
						break;
					}
				}
			}
			break;
		case 0x28:
			{
				RedirectIOToConsole();
			}
			break;
		case 0x29:
			{
				//EnterCriticalSection(&QueuePacketCriticalSection);
				//ConfirmPipe = 1;
				//LeaveCriticalSection(&QueuePacketCriticalSection);
			}
			break;
		case 0x30:
			{
				int SendBufferLen = Packet::ReadWord(Buffer, &position);
				CreateTibiaPacket(Packet::ReadByte(Buffer, &position));
				for (int sI = 1; sI<SendBufferLen; sI++)
				{
					TibiaPacketAddByte(Packet::ReadByte(Buffer, &position));
				}
				SendTibiaPacket(1);
			}
			break;
		default:
			break;
	}
}

void UnloadSelf()
{
        if(HookInjected)
        {
            //Remove Text
			list<NormalText>::iterator ntIT;
			EnterCriticalSection(&NormalTextCriticalSection);
			for(ntIT = DisplayTexts.begin(); ntIT != DisplayTexts.end(); ++ntIT)
			{
				delete [] ntIT->text;
				delete [] ntIT->TextName;
			}
			DisplayTexts.clear();
			LeaveCriticalSection(&NormalTextCriticalSection);

			//Remove creature text
			EnterCriticalSection(&CreatureTextCriticalSection);
			list<PlayerText>::iterator it;
			for(it = CreatureTexts.begin(); it != CreatureTexts.end(); ++it) {
				delete [] it->CreatureName;
				delete [] it->DisplayText;
			}
			LeaveCriticalSection(&CreatureTextCriticalSection);

			//Remove Items
			EnterCriticalSection(&ItemRenderCriticalSection);
			list<Item>::iterator Button;
			list<DisplayItem>::iterator ButItem;
			for(Button = DisplayItems.begin(); Button != DisplayItems.end(); ++Button) {
				delete [] Button->text;
			}
			DisplayItems.clear();
			LeaveCriticalSection(&ItemRenderCriticalSection);

			//remove all contextmenus
			list<ContextMenu>::iterator cmIT;
			EnterCriticalSection(&ContextMenuCriticalSection);
			for(cmIT = ContextMenus.begin(); cmIT != ContextMenus.end(); ++cmIT)
				delete [] cmIT->MenuText;
			ContextMenus.clear();
			LeaveCriticalSection(&ContextMenuCriticalSection);
			//Uninject hooks
			InjectHooks(0);
        }

		DeleteCriticalSection(&PipeReadCriticalSection);
		DeleteCriticalSection(&NormalTextCriticalSection);
		DeleteCriticalSection(&CreatureTextCriticalSection);
		DeleteCriticalSection(&ContextMenuCriticalSection);
		DeleteCriticalSection(&OnClickCriticalSection);
		DeleteCriticalSection(&ItemRenderCriticalSection);
		DeleteCriticalSection(&DrawGuiCriticalSection);

		DeleteCriticalSection(&QueuePacketCriticalSection);
        StartUninjectSelf();
}

void PipeThreadProc(HMODULE Module)
{
        //Connect to Pipe
        if (WaitNamedPipeA(PipeName.c_str(), NMPWAIT_WAIT_FOREVER)) 
        {
                pipe=CreateFileA(PipeName.c_str(), GENERIC_READ | GENERIC_WRITE , 0, NULL, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, NULL);
                if (pipe == INVALID_HANDLE_VALUE)
                {
                        errorStatus = ::GetLastError();
                        UnloadSelf();
                        return;
                } 
                else 
                {
                        //Pipe is ready. Let's start listening for incoming packets
                        PipeConnected = true;
                        
                        if (!mustUnload)
                        {
                                if(!::ReadFileEx(pipe, Buffer, sizeof(Buffer), &overlapped, ReadFileCompleted))
                                {
                                        errorStatus = ::GetLastError();                                 
                                        UnloadSelf();
                                        return;
                                } 
                                else 
                                {
                                        while (errorStatus == ERROR_SUCCESS)
                                        {
                                                const DWORD sleepResult = ::SleepEx(INFINITE, TRUE);
                                                assert(WAIT_IO_COMPLETION == sleepResult);
                                        }
                                }
                        }
                        else
                        {
                                UnloadSelf();
                        }
                }
        } 
        else 
        {
        }
}

void CALLBACK ReadFileCompleted(DWORD errorCode, DWORD bytesCopied, OVERLAPPED* overlapped)
{
	errorStatus = errorCode;
	if (errorStatus == ERROR_SUCCESS)
	{
		if (!HookInjected)
			PipeOnRead(Buffer);
		else
		{
			while ((*(DWORD*)Consts::Connection) == 6)
				Sleep(100);

            EnterCriticalSection(&QueuePacketCriticalSection);
			pipePack p;
			for (int i = 0; i < bytesCopied; i++)
				p.data[i] = Buffer[i];
			p.size = bytesCopied;
			pipePackets.push_back(p);
			LeaveCriticalSection(&QueuePacketCriticalSection);
		}

		if (!mustUnload)
		{

			if (!::ReadFileEx(pipe, Buffer, sizeof(Buffer), overlapped, ReadFileCompleted))
			{
				errorStatus = ::GetLastError();                         
				UnloadSelf();
			}
		}
		else
		{
			UnloadSelf();
		}
	}
	else
	{
                // pipe disconnected clean everything and remove the hook
		UnloadSelf();
	}
}



extern "C" bool APIENTRY DllMain (HMODULE hModule, DWORD reason, LPVOID reserved)
{
	switch (reason)
	{
		case DLL_PROCESS_ATTACH: //DLL was injected
        {
			hMod = hModule;

			CurrentPID = GetCurrentProcessId();

			while (!hwndTibia || hwndTibia == 0)
			{
				static int count = 0;
				EnumWindows(EnumWindowsProc, (LPARAM)GetCurrentProcessId());
				count++;

				if (count > 10)
				{
					MessageBoxA(NULL,
					"Failed to initialize a message segway between TUGBot and the Tibia Process. Please make sure TUGBot and Tibia are both run as admin. If the problem persists, contact DarkstaR.",
					"Injection Error", 0);
					StartUninjectSelf();
					return false;
				}
			}

			//HANDLE RunThread = CreateThread(NULL, 0, _socketListen, NULL, 0, NULL);

			std::stringstream sout;
			sout << "\\\\.\\pipe\\TUGBot" << CurrentPID;
			PipeName =  sout.str();


			InitializeCriticalSection(&PipeReadCriticalSection);
			InitializeCriticalSection(&NormalTextCriticalSection);
			InitializeCriticalSection(&CreatureTextCriticalSection);
			InitializeCriticalSection(&ContextMenuCriticalSection);
			InitializeCriticalSection(&OnClickCriticalSection);
			InitializeCriticalSection(&ItemRenderCriticalSection);
			InitializeCriticalSection(&DrawGuiCriticalSection);
			InitializeCriticalSection(&QueuePacketCriticalSection);
			
			PipeConnected = false;
			PipeThread = CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)PipeThreadProc, hMod, NULL, NULL);

			fUnicode=IsWindowUnicode(hwndTibia);
			oldWndProc = (WNDPROC) ((fUnicode) ? SetWindowLongPtrW(hwndTibia, GWLP_WNDPROC, (LONG_PTR)SubClassProc) : 
								SetWindowLongPtrA(hwndTibia, GWLP_WNDPROC, (LONG_PTR)SubClassProc));
		
		}
        break;
		case DLL_PROCESS_DETACH: //DLL was uninjected
		{
			DeleteCriticalSection(&PipeReadCriticalSection);
			DeleteCriticalSection(&NormalTextCriticalSection);
			DeleteCriticalSection(&CreatureTextCriticalSection);
			DeleteCriticalSection(&ContextMenuCriticalSection);
			DeleteCriticalSection(&OnClickCriticalSection);
			DeleteCriticalSection(&ItemRenderCriticalSection);
			DeleteCriticalSection(&DrawGuiCriticalSection);

			DeleteCriticalSection(&QueuePacketCriticalSection);
		}
		break;
    }

    return true;
}
