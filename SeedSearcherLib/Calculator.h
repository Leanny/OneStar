#pragma once
#include "Type.h"

extern "C"
{
	__declspec(dllexport) void Prepare(int rerolls);
	__declspec(dllexport) void SetFirstCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int flawlessIDX, int ability, int nature, int characteristics, int day, int species, int altform, bool isNoGender, bool isEnableDream);
	__declspec(dllexport) void SetNextCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristics, int day, int species, int altform, bool isNoGender, bool isEnableDream);
	__declspec(dllexport) void SetThirdCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristics, int day, int species, int altform, bool isNoGender, bool isEnableDream);
	__declspec(dllexport) void SetLSB(int val);
	__declspec(dllexport) unsigned int TestSeed(_u64);
	__declspec(dllexport) _u64 Search(_u64);
}
