#pragma once
#include <windows.h>
class Hook
{
public:
	Hook(DWORD HookAddress, DWORD NewFunction);
	void Enable();
	void Disable();
	DWORD OldFuncAddress;
	~Hook(void);
private:
	DWORD HookAtAddress;
	DWORD NewFuncAddress;
};
