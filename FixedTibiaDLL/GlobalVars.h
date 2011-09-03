#if MSC_VER > 100
#pragma once
#endif

#ifndef _GLOBALVARS_H_
#define _GLOBALVARS_H_

#include <windows.h>
#include <list>
#include "Context_Menus.h"
#include "DisplayHooks.h"
#include "Constants.h"
using namespace std;

//PIPE
extern DWORD errorStatus;
extern bool mustUnload;

extern list<ContextMenu> ContextMenus;    //Used for storing the context menus that will be added on this call

extern list<NormalText> DisplayTexts;		//Used for normal text displyaing
extern list<PlayerText> CreatureTexts;		//Used for storing current text to display above creature

extern list<Item> DisplayItems;		//Used for item displaying
extern list<Gui> GuiDraws;		//Used for Gui Drawing


#endif

