#include <iostream>
#include "Util.h"
#include "Calculator.h"
#include "Const.h"
#include "XoroshiroState.h"
#include "Data.h"
#include "fastmod.h"

static PokemonData l_First;
static PokemonData l_Second;
static PokemonData l_Third;

static int g_Rerolls;
static int g_FixedIndex;
static int length;

const int* g_IvsRef[30] = {
	&l_First.ivs[1], &l_First.ivs[2], &l_First.ivs[3], &l_First.ivs[4], &l_First.ivs[5],
	&l_First.ivs[0], &l_First.ivs[2], &l_First.ivs[3], &l_First.ivs[4], &l_First.ivs[5],
	&l_First.ivs[0], &l_First.ivs[1], &l_First.ivs[3], &l_First.ivs[4], &l_First.ivs[5],
	&l_First.ivs[0], &l_First.ivs[1], &l_First.ivs[2], &l_First.ivs[4], &l_First.ivs[5],
	&l_First.ivs[0], &l_First.ivs[1], &l_First.ivs[2], &l_First.ivs[3], &l_First.ivs[5],
	&l_First.ivs[0], &l_First.ivs[1], &l_First.ivs[2], &l_First.ivs[3], &l_First.ivs[4]
};


void SetFirstCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int flawlessIDX, int ability, int nature, int characteristics, int day, int species, int altform, bool isNoGender, bool isEnableDream)
{
	l_First.ivs[0] = iv0;
	l_First.ivs[1] = iv1;
	l_First.ivs[2] = iv2;
	l_First.ivs[3] = iv3;
	l_First.ivs[4] = iv4;
	l_First.ivs[5] = iv5;
	l_First.ability = ability;
	l_First.nature = nature;
	l_First.isNoGender = isNoGender;
	l_First.isEnableDream = isEnableDream;
	l_First.fixedIV = fixedIV;
	l_First.characteristic = characteristics;
	l_First.ID = species;
	l_First.altForm = altform;
	l_First.day = day;
	g_FixedIndex = flawlessIDX;
	for (int i = 0; i < 6; i++)
	{
		l_First.characteristicPos[i] = l_First.GetNextPos(i);
	}
}

void SetNextCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristics, int day, int species, int altform, bool isNoGender, bool isEnableDream)
{
	l_Second.ivs[0] = iv0;
	l_Second.ivs[1] = iv1;
	l_Second.ivs[2] = iv2;
	l_Second.ivs[3] = iv3;
	l_Second.ivs[4] = iv4;
	l_Second.ivs[5] = iv5;
	l_Second.ability = ability;
	l_Second.nature = nature;
	l_Second.characteristic = characteristics;
	l_Second.isNoGender = isNoGender;
	l_Second.isEnableDream = isEnableDream;
	l_Second.ID = species;
	l_Second.day = day;
	l_Second.altForm = altform;
	l_Second.fixedIV = fixedIV;
	for (int i = 0; i < 6; i++)
	{
		l_Second.characteristicPos[i] = l_Second.GetNextPos(i);
	}
}

void SetThirdCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristics, int day, int species, int altform, bool isNoGender, bool isEnableDream)
{
	l_Third.ivs[0] = iv0;
	l_Third.ivs[1] = iv1;
	l_Third.ivs[2] = iv2;
	l_Third.ivs[3] = iv3;
	l_Third.ivs[4] = iv4;
	l_Third.ivs[5] = iv5;
	l_Third.ability = ability;
	l_Third.nature = nature;
	l_Third.characteristic = characteristics;
	l_Third.isNoGender = isNoGender;
	l_Third.isEnableDream = isEnableDream;
	l_Third.ID = species;
	l_Third.day = day;
	l_Third.altForm = altform;
	l_Third.fixedIV = fixedIV;
	for (int i = 0; i < 6; i++)
	{
		l_Third.characteristicPos[i] = l_Third.GetNextPos(i);
	}
}

_u64 add_val[3];
_u64 add_last;

void Prepare(int rerolls)
{
	add_val[0] = (l_First.day - 1) * Const::c_XoroshiroConst;
	add_val[1] = (l_Second.day - 1) * Const::c_XoroshiroConst;
	add_val[2] = (l_Third.day - 1) * Const::c_XoroshiroConst;

	add_last = add_val[0];
	for (int i = 0; i < 3; i++) {
		add_val[i] -= add_last;
	}

	g_Rerolls = rerolls;

	g_ConstantTermVector = 0;

	InitializeTransformationMatrix(); 
	for (int i = 0; i <= rerolls + l_First.fixedIV; ++i)
	{
		ProceedTransformationMatrix();
	}

	int bit = 0;
	for (int i = 0; i < 6; ++i)
	{
		int index = 61 + (i / 3) * 64 + (i % 3);
		g_InputMatrix[bit++] = GetMatrixMultiplier(index);
		g_ConstantTermVector <<= 1;
		if (GetMatrixConst(index) != 0)
		{
			g_ConstantTermVector |= 1;
		}
	}
	for (int a = 0; a < 5; ++a)
	{
		ProceedTransformationMatrix();
		for (int i = 0; i < 10; ++i)
		{
			int index = 59 + (i / 5) * 64 + (i % 5);
			g_InputMatrix[bit++] = GetMatrixMultiplier(index);
			g_ConstantTermVector <<= 1;
			if (GetMatrixConst(index) != 0)
			{
				g_ConstantTermVector |= 1;
			}
		}
	}

	ProceedTransformationMatrix();

	g_InputMatrix[bit++] = GetMatrixMultiplier(63) ^ GetMatrixMultiplier(127);
	g_ConstantTermVector <<= 1;
	if (GetMatrixConst(63) != GetMatrixConst(127))
	{
		g_ConstantTermVector |= 1;
	}

	g_InputMatrix[bit++] = 1;
	g_ConstantTermVector <<= 1;
	g_ConstantTermVector |= 1;

	length = CalculateInverseMatrix(bit);

	CalculateCoefficientData(length);
}

inline int TestXoroshiroSeed(_u64 seed, XoroshiroState& xoroshiro) {
	const _u64 add_val[] = {(l_First.day - 1) * Const::c_XoroshiroConst, (l_Second.day - 1) * Const::c_XoroshiroConst, (l_Third.day - 1) * Const::c_XoroshiroConst };
	XoroshiroState tmp;
	xoroshiro.SetSeed(seed + add_val[0]);
	unsigned int ec = -1;
	do {
		ec = xoroshiro.Next(0xFFFFFFFFu);
	} while (ec == 0xFFFFFFFFu);

	if (l_First.characteristic > -1) {
		int characteristic = fastmod::fastmod_u32(ec, M, 6);
		if (l_First.characteristicPos[characteristic] != l_First.characteristic)
		{
			return 1;
		}
	}
	while (xoroshiro.Next(0xFFFFFFFFu) == 0xFFFFFFFFu); // OTID
	while (xoroshiro.Next(0xFFFFFFFFu) == 0xFFFFFFFFu); // PID

	// V箇所
	int offset = -1;
	for (offset = 0; xoroshiro.Next(7) >= 6; offset++); // V箇所

	for (int i = 0; i < 6; i++) {
		if(i != g_FixedIndex) {
			int iv = xoroshiro.Next(31);
			if (iv != l_First.ivs[i]) {
				return 1;
			}
		}
	}

	// 特性
	if (l_First.ability == -2) {
		tmp.Copy(&xoroshiro);
		// normal
		int ability = 0;
		if (l_First.isEnableDream)
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
		if (!l_First.isNoGender)
		{
			int gender = 0;
			do {
				gender = xoroshiro.Next(0xFF); // 性別値
			} while (gender >= 253);
		}

		int nature = 0;
		if (l_First.ID == ToxtricityID) {
			if (l_First.altForm == 0) { // ToxtricityAmplifiedNatures
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

		if (nature != l_First.nature)
		{
			// does not work
			xoroshiro.Copy(&tmp);
			// ignore ability
			// 性別値
			if (!l_First.isNoGender)
			{
				int gender = 0;
				do {
					gender = xoroshiro.Next(0xFF); // 性別値
				} while (gender >= 253);
			}

			int nature = 0;
			if (l_First.ID == ToxtricityID) {
				if (l_First.altForm == 0) { // ToxtricityAmplifiedNatures
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

			if (nature != l_First.nature)
			{
				// both do not yield results
				return 1;
			}
		}
	}
	else {
		int ability = 0;
		if (l_First.isEnableDream)
		{
			do {
				ability = xoroshiro.Next(3);
			} while (ability >= 3);
		}
		else
		{
			ability = xoroshiro.Next(1);
		}
		if ((l_First.ability >= 0 && l_First.ability != ability) || (l_First.ability == -1 && ability >= 2))
		{
			return 1;
		}

		// 性別値
		if (!l_First.isNoGender)
		{
			int gender = 0;
			do {
				gender = xoroshiro.Next(0xFF); // 性別値
			} while (gender >= 253);
		}

		int nature = 0;
		if (l_First.ID == ToxtricityID) {
			if (l_First.altForm == 0) { // ToxtricityAmplifiedNatures
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

		if (nature != l_First.nature)
		{
			return 1;
		}
	}
	

	// 2匹目
	_u64 nextSeed = seed + add_val[1];
	xoroshiro.SetSeed(nextSeed);
	if (!TestPkmn(xoroshiro, l_Second)) {
		return 3;
	}

	// 3匹目
	nextSeed = seed + add_val[2];
	xoroshiro.SetSeed(nextSeed);
	if (!TestPkmn(xoroshiro, l_Third)) {
		return 4;
	}
	return 5;
}

_u64 Search(_u64 ivs, _u64 ability)
{
	XoroshiroState xoroshiro;
	XoroshiroState tmp;
	_u64 target = ability;
	const int bitOffset = 2;
	target |= (ivs & 0xE000000ul) << (28 + bitOffset); // fixedIndex0
	target |= (ivs & 0x1F00000ul) << (25 + bitOffset); // iv0_0
	target |= (ivs & 0xF8000ul) << (20 + bitOffset); // iv1_0
	target |= (ivs & 0x7C00ul) << (15 + bitOffset); // iv2_0
	target |= (ivs & 0x3E0ul) << (10 + bitOffset); // iv3_0
	target |= (ivs & 0x1Ful) << (5 + bitOffset); // iv4_0

	target |= ((8ul + g_FixedIndex - ((ivs & 0xE000000ul) >> 25)) & 7) << (50 + bitOffset);

	target |= ((32ul + *g_IvsRef[g_FixedIndex * 5] - ((ivs & 0x1F00000ul) >> 20)) & 0x1F) << (40 + bitOffset);
	target |= ((32ul + *g_IvsRef[g_FixedIndex * 5 + 1] - ((ivs & 0xF8000ul) >> 15)) & 0x1F) << (30 + bitOffset);
	target |= ((32ul + *g_IvsRef[g_FixedIndex * 5 + 2] - ((ivs & 0x7C00ul) >> 10)) & 0x1F) << (20 + bitOffset);
	target |= ((32ul + *g_IvsRef[g_FixedIndex * 5 + 3] - ((ivs & 0x3E0ul) >> 5)) & 0x1F) << (10 + bitOffset);
	target |= ((32ul + *g_IvsRef[g_FixedIndex * 5 + 4] - (ivs & 0x1Ful)) & 0x1F) << bitOffset;

	target ^= g_ConstantTermVector;
	_u64 processedTarget = 0;
	int offset = 0;
	for (int i = 0; i < length; ++i)
	{
		while (g_FreeBit[i + offset] > 0)
		{
			++offset;
		}
		processedTarget |= (GetSignature(g_AnswerFlag[i] & target) << (63 - (i + offset)));
	}

	_u64 max = 1ull << (64 - length);
	for (_u64 search = 0; search < max; ++search)
	{
		_u64 seed = (processedTarget ^ g_CoefficientData[search]) | g_SearchPattern[search];

		xoroshiro.SetSeed(seed);
		unsigned int ec = -1;
		do {
			ec = xoroshiro.Next(0xFFFFFFFFu);
		} while (ec == 0xFFFFFFFFu);


		while (xoroshiro.Next(0xFFFFFFFFu) == 0xFFFFFFFFu); // OTID
		while (xoroshiro.Next(0xFFFFFFFFu) == 0xFFFFFFFFu); // PID

		int offset = -1;
		for (offset = 0; xoroshiro.Next(7) >= 6; offset++);

		if (offset != g_Rerolls)
		{
			continue;
		}

		xoroshiro.Next(); 
		xoroshiro.Next(); 
		xoroshiro.Next(); 
		xoroshiro.Next(); 
		xoroshiro.Next(); 

		if (l_First.ability == -2) {
			tmp.Copy(&xoroshiro);
			// normal
			int tmp_ability = 0;
			if (l_First.isEnableDream)
			{
				do {
					tmp_ability = xoroshiro.Next(3);
				} while (tmp_ability >= 3);
			}
			else
			{
				tmp_ability = xoroshiro.Next(1);
			}
			if ((l_First.ability >= 0 && l_First.ability != tmp_ability) || (l_First.ability == -1 && tmp_ability >= 2))
			{
				continue;
			}

			if (!l_First.isNoGender)
			{
				int gender = 0;
				do {
					gender = xoroshiro.Next(0xFF);
				} while (gender >= 253);
			}

			int nature = 0;
			if (l_First.ID == ToxtricityID) {
				if (l_First.altForm == 0) { // ToxtricityAmplifiedNatures
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

			if (nature != l_First.nature)
			{
				// does not work
				xoroshiro.Copy(&tmp);
				// ignore ability
				if (!l_First.isNoGender)
				{
					int gender = 0;
					do {
						gender = xoroshiro.Next(0xFF); // 性別値
					} while (gender >= 253);
				}

				int nature = 0;
				if (l_First.ID == ToxtricityID) {
					if (l_First.altForm == 0) { // ToxtricityAmplifiedNatures
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

				if (nature != l_First.nature)
				{
					// both do not yield results
					continue;
				}
			}
		}
		else {
			int tmp_ability = 0;
			if (l_First.isEnableDream)
			{
				do {
					tmp_ability = xoroshiro.Next(3);
				} while (tmp_ability >= 3);
			}
			else
			{
				tmp_ability = xoroshiro.Next(1);
			}
			if ((l_First.ability >= 0 && l_First.ability != tmp_ability) || (l_First.ability == -1 && tmp_ability >= 2))
			{
				continue;
			}

			// 性別値
			if (!l_First.isNoGender)
			{
				int gender = 0;
				do {
					gender = xoroshiro.Next(0xFF); // 性別値
				} while (gender >= 253);
			}

			int nature = 0;
			if (l_First.ID == ToxtricityID) {
				if (l_First.altForm == 0) { // ToxtricityAmplifiedNatures
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

			if (nature != l_First.nature)
			{
				continue;
			}
		}

		_u64 nextSeed = seed + add_val[1];
		xoroshiro.SetSeed(nextSeed);
		if (!TestPkmn(xoroshiro, l_Second)) {
			continue;
		}

		nextSeed = seed + add_val[2];
		xoroshiro.SetSeed(nextSeed);
		if (!TestPkmn(xoroshiro, l_Third)) {
			continue;
		}
		return seed - add_last;
	}
	return 0;
}

unsigned int TestSeed(_u64 seed) {
	XoroshiroState xoroshiro;
	return TestXoroshiroSeed(seed, xoroshiro);
}