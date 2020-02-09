#pragma once
#include "Type.h"

extern "C"
{
	__declspec(dllexport) void PrepareSix(int ivOffset);
	__declspec(dllexport) void PrepareFive(int ivOffset);
	__declspec(dllexport) void SetSixFirstCondition(int, int, int, int, int, int, int, int, int, int, int, int, int, bool, bool);
	__declspec(dllexport) void SetSixSecondCondition(int, int, int, int, int, int, int, int, int, int, int, int, int, bool, bool);
	__declspec(dllexport) void SetSixThirdCondition(int, int, int, int, int, int, int, int, int, int, int, int, int, bool, bool);
	__declspec(dllexport) void SetSixFourthCondition(int, int, int, int, int, int, int, int, int, int, int, int, int, bool, bool);
	__declspec(dllexport) void SetTargetCondition6(int iv1, int iv2, int iv3, int iv4, int iv5, int iv6);
	__declspec(dllexport) unsigned int TestSixSeed(_u64 seed);
	__declspec(dllexport) void SetSixLSB(int val);
	__declspec(dllexport) _u64 SearchSix(_u64, _u64);
	__declspec(dllexport) _u64 SearchFive(_u64, _u64, _u64);
	__declspec(dllexport) _u64 SearchFour(_u64, _u64, _u64);
	__declspec(dllexport) void Reset();
}
