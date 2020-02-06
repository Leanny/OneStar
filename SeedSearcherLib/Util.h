#pragma once
#include "Type.h"
#include "XoroshiroState.h"

inline _u64 GetSignature(_u64 value)
{
	unsigned int a = (unsigned int)(value ^ (value >> 32));
	a = a ^ (a >> 16);
	a = a ^ (a >> 8);
	a = a ^ (a >> 4);
	a = a ^ (a >> 2);
	return (a ^ (a >> 1)) & 1;
}

static const int ToxtricityAmplifiedNatures[] = { 0x03, 0x04, 0x02, 0x08, 0x09, 0x13, 0x16, 0x0B, 0x0D, 0x0E, 0x00, 0x06, 0x18 };
static const int ToxtricityLowKeyNatures[] = { 0x01, 0x05, 0x07, 0x0A, 0x0C, 0x0F, 0x10, 0x11, 0x12, 0x14, 0x15, 0x17 };
static const int ToxtricityID = 849;
static const int iv_order[] = { 0, 1, 2, 5, 3, 4 };
struct PokemonData
{
	int ivs[6];
	int ability;
	int nature;
	int characteristic;
	int fixedIV;
	int ID;
	int altForm;
	int characteristicPos[6];
	bool isNoGender;
	bool isEnableDream;

	inline bool IsCharacterized(int index) // H A B "S" C D
	{
		switch (index)
		{
			case 0: return (ivs[0] == 31);
			case 1: return (ivs[1] == 31);
			case 2: return (ivs[2] == 31);
			case 3: return (ivs[5] == 31);
			case 4: return (ivs[3] == 31);
			case 5: return (ivs[4] == 31);
			default: return true;
		}
	}

	inline int GetNextPos(int idx)
	{
		for (int i = 0; i < 6; i++)
		{
			int pos = (idx + i) % 6;
			if (ivs[iv_order[pos]] == 31)
			{
				return pos;
			}
		}
		return 0;
	}
};



inline bool TestPkmn(XoroshiroState xoroshiro, PokemonData pkmn) {
	unsigned int ec = -1;
	do {
		ec = xoroshiro.Next(0xFFFFFFFFu);
	} while (ec == 0xFFFFFFFFu);
	if (pkmn.characteristic > -1) {
		int characteristic = fastmod::fastmod_u32(ec, M, 6);
		if (pkmn.characteristicPos[characteristic] != pkmn.characteristic)
		{
			return 1;
		}
	}

	while (xoroshiro.Next(0xFFFFFFFFu) == 0xFFFFFFFFu); // OTID
	while (xoroshiro.Next(0xFFFFFFFFu) == 0xFFFFFFFFu); // PID
	XoroshiroState tmp;
	int ivs[6] = { -1, -1, -1, -1, -1, -1 };
	int fixedCount = 0;
	do {
		int fixedIndex = 0;
		do {
			fixedIndex = xoroshiro.Next(7); // V箇所
		} while (fixedIndex >= 6);

		if (ivs[fixedIndex] == -1)
		{
			ivs[fixedIndex] = 31;
			++fixedCount;
		}
	} while (fixedCount < pkmn.fixedIV);

	// 個体値
	bool isPassed = true;
	for (int i = 0; i < 6; ++i)
	{
		if (ivs[i] == 31)
		{
			if (pkmn.ivs[i] != 31)
			{
				isPassed = false;
				break;
			}
		}
		else if (pkmn.ivs[i] != xoroshiro.Next(0x1F))
		{
			isPassed = false;
			break;
		}
	}
	if (!isPassed)
	{
		return false;
	}

	if (pkmn.ability == -2) {
		tmp.Copy(&xoroshiro);

		// 特性
		int ability = 0;
		if (pkmn.isEnableDream)
		{
			do {
				ability = xoroshiro.Next(3);
			} while (ability >= 3);
		}
		else
		{
			ability = xoroshiro.Next(1);
		}
		// 性別値
		if (!pkmn.isNoGender)
		{
			int gender = 0;
			do {
				gender = xoroshiro.Next(0xFF);
			} while (gender >= 253);
		}

		// 性格
		int nature = 0;
		if (pkmn.ID == ToxtricityID) {
			if (pkmn.altForm == 0) { // ToxtricityAmplifiedNatures
				do {
					nature = xoroshiro.Next(0x1F);
				} while (nature >= 13);
				nature = ToxtricityAmplifiedNatures[nature];
			}
			else
			{ // ToxtricityLowKeyNatures
				do {
					nature = xoroshiro.Next(0x1F);
				} while (nature >= 12);
				nature = ToxtricityLowKeyNatures[nature];
			}
		} else {
			do {
				nature = xoroshiro.Next(0x1F);
			} while (nature >= 25);
		}
		if (nature != pkmn.nature) {
			xoroshiro.Copy(&tmp);

			// 性別値
			if (!pkmn.isNoGender)
			{
				int gender = 0;
				do {
					gender = xoroshiro.Next(0xFF);
				} while (gender >= 253);
			}

			// 性格
			int nature = 0;
			if (pkmn.ID == ToxtricityID) {
				if (pkmn.altForm == 0) { // ToxtricityAmplifiedNatures
					do {
						nature = xoroshiro.Next(0x1F);
					} while (nature >= 13);
					nature = ToxtricityAmplifiedNatures[nature];
				}
				else
				{ // ToxtricityLowKeyNatures
					do {
						nature = xoroshiro.Next(0x1F);
					} while (nature >= 12);
					nature = ToxtricityLowKeyNatures[nature];
				}
			}
			else {
				do {
					nature = xoroshiro.Next(0x1F);
				} while (nature >= 25);
			}

			return nature == pkmn.nature;
		}
		return true;

	} else {
		// 特性
		int ability = 0;
		if (pkmn.isEnableDream)
		{
			do {
				ability = xoroshiro.Next(3);
			} while (ability >= 3);
		}
		else
		{
			ability = xoroshiro.Next(1);
		}
		if ((pkmn.ability >= 0 && pkmn.ability != ability) || (pkmn.ability == -1 && ability >= 2))
		{
			return false;
		}

		// 性別値
		if (!pkmn.isNoGender)
		{
			int gender = 0;
			do {
				gender = xoroshiro.Next(0xFF);
			} while (gender >= 253);
		}

		// 性格
		int nature = 0;
		if (pkmn.ID == ToxtricityID) {
			if (pkmn.altForm == 0) { // ToxtricityAmplifiedNatures
				do {
					nature = xoroshiro.Next(0xF);
				} while (nature >= 13);
				nature = ToxtricityAmplifiedNatures[nature];
			}
			else
			{ // ToxtricityLowKeyNatures
				do {
					nature = xoroshiro.Next(0xF);
				} while (nature >= 12);
				nature = ToxtricityLowKeyNatures[nature];
			}
		}
		else {
			do {
				nature = xoroshiro.Next(0x1F);
			} while (nature >= 25);
		}

		return nature == pkmn.nature;
	}
}