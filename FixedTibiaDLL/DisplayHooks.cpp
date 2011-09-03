#include "StdAfx.h"
#include "DisplayHooks.h"
#include <windows.h>
#include <list>
#include "Constants.h"
#include "GlobalVars.h"
#include "Utils.h"
#include "Hook.h"
using namespace std;

/* DisplayText. Credits for Displaying text goes to Stiju and Zionz. Thanks for the help!*/
BYTE* OldNopFPS = 0;				//Used for restoring conditional jump (FPS)

list<NormalText> DisplayTexts;		//Used for normal text displyaing
list<PlayerText> CreatureTexts;		//Used for storing current text to display above creature

list<Item> DisplayItems;		//Used for item displaying
list<Gui> GuiDraws;		//Used for Gui Drawing

Hook* PrintFPSHook;
Hook* PrintNameHook;
Hook* PrintHealthHook;

void DisplaySetAddress(int type, int address){
	switch((PipeConstantType)type)
	{
		case PrintTextFunc:
			PrintText = (_PrintText*)address;
		case RenderItemFunc:
			RenderItem = (_RenderItem*)address;
		case DrawSkinFunc:
			DrawSkin = (_DrawSkin*)address;
	};
}

void InjectDisplayHooks(){

	PrintFPSHook = new Hook(Consts::ptrPrintFPS,(DWORD)&MyPrintFps);
	PrintFPSHook->Enable();


	PrintNameHook = new Hook(Consts::ptrPrintName, (DWORD)&MyPrintName);
	PrintNameHook->Enable();

	OldNopFPS = Nop(Consts::ptrNopFPS, 6); //Showing the FPS all the time..
}

void UnInjectDisplayHooks(){
	PrintFPSHook->Disable();
	PrintNameHook->Disable();
	delete [] PrintNameHook;
	delete [] PrintFPSHook;
	//PrintHealthHook->Disable();

	if (OldNopFPS)
		UnNop(Consts::ptrNopFPS, OldNopFPS, 6);
}

char* MyPrintHealth(int nSurface, int nX, int nY, int nWidth, int nHeight, int nRed, int nGreen, int nBlue)
{
	 PrintRect(nSurface, nX, nY, nWidth, nHeight, nBlue, nGreen, nRed);
	//PrintRect(UnKnown, nRed, nGreen, nBlue, nHeight, nWidth, nY, nX, nSurface);

	_GetThis* GetThis = (_GetThis *)0x0051CC70;
	return GetThis();
}

void MyPrintName(int nSurface, int nX, int nY, int nFont, int nRed, int nGreen, int nBlue, char* lpText, int nAlign)
{
	if (*(DWORD*)Consts::Connection != 8) //if not in game
	{
		//Displaying Original Text
		PrintText(nSurface, nX, nY, nFont, nRed, nGreen, nBlue, lpText, nAlign);
		return;
	}
	
	list<PlayerText>::iterator it;

	/* Write own text */

	DWORD *EntityID = (DWORD*)(lpText - 4);

	//Displaying texts
	EnterCriticalSection(&CreatureTextCriticalSection);
	for(it = CreatureTexts.begin(); it != CreatureTexts.end(); ++it) {
		if(it->CreatureId == 0)
		{
			if(case_insensitive_compare(lpText,it->CreatureName)) {
				PrintText(0x01, nX + it->RelativeX, nY + it->RelativeY, it->TextFont, it->cR, it->cG, it->cB, it->DisplayText, 0x00);
			}
		}
		else if(*EntityID == it->CreatureId)
		{
			if(it->RelativeX == 666)
			{
				PrintText(0x01, nX, nY, nFont, nRed, nGreen, nBlue, it->DisplayText, 0x00);
				nY -= 12;
			}
			else
			{
				PrintText(0x01, nX + it->RelativeX, nY + it->RelativeY, it->TextFont, it->cR, it->cG, it->cB, it->DisplayText, 0x00);
			}
		}
	}
	LeaveCriticalSection(&CreatureTextCriticalSection);
	
	//Displaying Original Text
	PrintText(nSurface, nX, nY, nFont, nRed, nGreen, nBlue, lpText, nAlign);
}


void MyPrintFps(int nSurface, int nX, int nY, int nFont, int nRed, int nGreen, int nBlue, char* lpText, int nAlign)
{
	bool *fps = (bool*)Consts::ptrShowFPS;
	if(*fps == true)
	{
		PrintText(nSurface, nX, nY, nFont, nRed, nGreen, nBlue, lpText, nAlign);
		nY += 12;
	}

	if (*(DWORD*)Consts::Connection != 8) //if not in game
	{
		return;
	}


	//Gui
	EnterCriticalSection(&DrawGuiCriticalSection);

	list<Gui>::iterator nDIT;
	for(nDIT = GuiDraws.begin(); nDIT != GuiDraws.end(); ++nDIT) {
		DrawSkin(nSurface, nDIT->x, nDIT->y, nDIT->w, nDIT->h, nDIT->id, 0, 0);
	}
	
	LeaveCriticalSection(&DrawGuiCriticalSection);

	//Items
	EnterCriticalSection(&ItemRenderCriticalSection);

	list<Item>::iterator Button;
	list<DisplayItem>::iterator ButItem;
	for(Button = DisplayItems.begin(); Button != DisplayItems.end(); ++Button) {
		for(ButItem = Button->ItemDisplays.begin(); ButItem != Button->ItemDisplays.end(); ++ButItem) {
			RenderItem(nSurface,
				(Button->x + ButItem->ofx), (Button->y + ButItem->ofy), //x and y
				Button->Size, //Size
				ButItem->id, ButItem->count, //id and count
				0, 0, 0, 0, //Outline
				(Button->x + ButItem->ofx), (Button->y + ButItem->ofy), //X and y again
				Button->Size, Button->Size, //Size again
				2, 0, 0, 0, 2, 
				-1);//Dont show count
		}
		PrintText(nSurface, (Button->x + (Button->Size / 2)), Button->y + Button->Size - 6, nFont, Button->cR, Button->cG, Button->cB, Button->text, 0x01);
	}
	
	LeaveCriticalSection(&ItemRenderCriticalSection);

	//Text
	EnterCriticalSection(&NormalTextCriticalSection);

	list<NormalText>::iterator ntIT;
	for(ntIT = DisplayTexts.begin(); ntIT != DisplayTexts.end(); ++ntIT)
		PrintText(nSurface, ntIT->x, ntIT->y, ntIT->font, ntIT->r, ntIT->g, ntIT->b, ntIT->text, ntIT->align); //0x01 Surface, 0x00 Align
	
	LeaveCriticalSection(&NormalTextCriticalSection);
}
