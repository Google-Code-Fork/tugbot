#if MSC_VER > 100
#pragma once
#endif
#ifndef _CORE_H_
#define _CORE_H_

#include <string>

//;O
void SendToClient(LPBYTE pBuffer, DWORD dwSize);
int OnGetNextPacket();
typedef void TF_PARSER();
typedef int TF_GETNEXTPACKET();

TF_PARSER *TfParser = 0;
TF_GETNEXTPACKET *TfGetNextPacket = NULL;

void UnloadSelf();

//Attack
typedef void _Attack(DWORD id);
static _Attack *Attack = 0;

//Stop
typedef void _Stop(void);
static _Stop *Stop = 0;

//Logout
typedef void _Logout(void);
static _Logout *Logout = 0;

//Speak
typedef void _Speak(int type, char* text);
static _Speak *Speak = 0;

//Spin
typedef void _Spin();
static _Spin *SpinNorth = 0;
static _Spin *SpinSouth = 0;
static _Spin *SpinEast = 0;
static _Spin *SpinWest = 0;

//SendFunction
typedef void _CreateTibiaPacket(BYTE type);
static _CreateTibiaPacket *CreateTibiaPacket = 0;
typedef void _TibiaPacketAddByte(BYTE data);
static _TibiaPacketAddByte *TibiaPacketAddByte = 0;
typedef void _SendTibiaPacket(BYTE Xtea);//always1
static _SendTibiaPacket *SendTibiaPacket = 0;



//Follow
typedef void _Follow(BYTE Dir);
static _Follow *Follow = 0;

//Move Object
typedef void _MoveObject(int xfrom, int yfrom, int zfrom, int id, int stack, int xto, int yto, int zto, int count);
static _MoveObject *MoveObject = 0;


void __stdcall MyOldPartyActionContextMenu(int eventId, const char* text, const char* shortcut);
void __stdcall MyNewPartyActionContextMenu(char* arg1, char* arg2, char* arg3, char* name, char* arg5);

typedef void _ContextMenuExtended(char* arg1, char* arg2, char* arg3, char* name, char* arg5);
static _ContextMenuExtended *ContextMenuExtended = 0;
//Use object
typedef void __cdecl _UseObjectWithCreature(int xfrom, int yfrom, int zfrom, int id, BYTE stack, int creature);
static _UseObjectWithCreature *UseObjectWithCreature = 0;

typedef void _UseObjectFromGround(int x, int y, int z, int id, BYTE stack, int count);
static _UseObjectFromGround *UseObjectFromGround = 0;

typedef void _UseObjectWithGround(int FromX, int FromY, int FromZ, 
								  int UseID, BYTE stack, int ToX, int ToY, int ToZ,
								  int UseWithID, BYTE toStack, int SelfX, int SelfY, int SelfZ);
static _UseObjectWithGround *UseObjectWithGround = 0;

//Amount is charge for vials and shit
typedef void _BuyObject(int ID, int Amount, int Count, int Backpack, int Capacity);
static _BuyObject *BuyObject = 0;

typedef void _SellObject(int ID, int Amount, int Count, int FromEQ);
static _SellObject *SellObject = 0;

void CALLBACK ReadFileCompleted(DWORD errorCode, DWORD bytesCopied, OVERLAPPED* overlapped);

bool WINAPI MyPeekMessageA(LPMSG pMsg, HWND hwnd, UINT wMsgFilterMin, UINT wMsgFilterMax, UINT wRemoveMsg);
typedef bool (WINAPI *_OldPeekMessageA)(LPMSG pMsg,HWND hwnd,UINT wMsgFilterMin,UINT wMsgFilterMax,UINT wRemoveMsg);
_OldPeekMessageA oldPeek;

BOOL CALLBACK EnumWindowsProc(HWND hwnd,LPARAM lParam);
LRESULT WINAPI SubClassProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam);
#endif