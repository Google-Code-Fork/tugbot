#if MSC_VER > 100
#pragma once
#endif

#ifndef _DISPLAY_HOOKS_H_
#define _DISPLAY_HOOKS_H_

#include <list>
#include <string>

void MyPrintName(int nSurface, int nX, int nY, int nFont, int nRed, int nGreen, int nBlue, char* lpText, int nAlign);
void MyPrintFps(int nSurface, int nX, int nY, int nFont, int nRed, int nGreen, int nBlue, char* lpText, int nAlign);
char* MyPrintHealth(int nSurface, int nX, int nY, int nWidth, int nHeight, int nRed, int nGreen, int nBlue);


void DisplaySetAddress(int type, int address);
void InjectDisplayHooks();
void UnInjectDisplayHooks();

typedef char* _GetThis();

#define PrintRect(nSurface, nX, nY, nWidth, nHeight, nRed, nGreen, nBlue)   \
		__asm mov eax, 0x0051CC70 \
		__asm call eax \
		__asm mov ecx, eax \
		__asm push nBlue \
		__asm push nGreen \
		__asm push nRed \
		__asm push nHeight \
		__asm push nWidth \
		__asm push nY \
		__asm push nX \
		__asm push nSurface \
		__asm mov eax, 0x005282E0 \
		__asm call eax

extern struct NormalText
{
	char* text;
	int r,g,b;
	int x,y;
	int font, align;
	char *TextName;
}; 

//Display Creature Text Structure
extern struct PlayerText
{
	char *DisplayText;
	char *CreatureName;
	int CreatureId;
	int cR;
	int cG;
	int cB;
	int TextFont;
	int RelativeX;
	int RelativeY;

};

/* Structures */
//Display Normal Text Strcture
extern struct DisplayItem
{
	int id, ofx, ofy, count;
}; 

extern struct Item
{
	std::list<DisplayItem> ItemDisplays;
	int x, y;
	int cR, cG, cB;
	int Size;
	char* text;

}; 

extern struct Gui
{
	int id, index, x, y, w, h;
}; 


bool CompareLists(PlayerText first, PlayerText second);
#endif
