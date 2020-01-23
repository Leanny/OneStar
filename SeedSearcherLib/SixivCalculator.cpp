#include <iostream>
#include "Util.h"
#include "SixivCalculator.h"
#include "Const.h"
#include "XoroshiroState.h"
#include "Data.h"
#include "fastmod.h"

static PokemonData l_First;
static PokemonData l_Second;
static PokemonData l_Third;
static PokemonData l_Fourth;

static int g_Ivs[6];
static int g_LSB;
static int g_setIVs;

static int g_IvOffset;

static uint64_t M = fastmod::computeM_u32(6);

void SetSixFirstCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, bool isNoGender, bool isEnableDream)
{
	l_First.ivs[0] = iv0;
	l_First.ivs[1] = iv1;
	l_First.ivs[2] = iv2;
	l_First.ivs[3] = iv3;
	l_First.ivs[4] = iv4;
	l_First.ivs[5] = iv5;
	l_First.ability = ability;
	l_First.nature = nature;
	l_First.characteristic = characteristic;
	l_First.isNoGender = isNoGender;
	l_First.isEnableDream = isEnableDream;
	l_First.fixedIV = fixedIV;
}

void SetSixSecondCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, bool isNoGender, bool isEnableDream)
{
	l_Second.ivs[0] = iv0;
	l_Second.ivs[1] = iv1;
	l_Second.ivs[2] = iv2;
	l_Second.ivs[3] = iv3;
	l_Second.ivs[4] = iv4;
	l_Second.ivs[5] = iv5;
	l_Second.ability = ability;
	l_Second.nature = nature;
	l_Second.characteristic = characteristic;
	l_Second.isNoGender = isNoGender;
	l_Second.isEnableDream = isEnableDream;
	l_Second.fixedIV = fixedIV;
}

void SetSixThirdCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, bool isNoGender, bool isEnableDream)
{
	l_Third.ivs[0] = iv0;
	l_Third.ivs[1] = iv1;
	l_Third.ivs[2] = iv2;
	l_Third.ivs[3] = iv3;
	l_Third.ivs[4] = iv4;
	l_Third.ivs[5] = iv5;
	l_Third.ability = ability;
	l_Third.nature = nature;
	l_Third.characteristic = characteristic;
	l_Third.isNoGender = isNoGender;
	l_Third.isEnableDream = isEnableDream;
	l_Third.fixedIV = fixedIV;
}

void SetSixFourthCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, bool isNoGender, bool isEnableDream)
{
	l_Fourth.ivs[0] = iv0;
	l_Fourth.ivs[1] = iv1;
	l_Fourth.ivs[2] = iv2;
	l_Fourth.ivs[3] = iv3;
	l_Fourth.ivs[4] = iv4;
	l_Fourth.ivs[5] = iv5;
	l_Fourth.ability = ability;
	l_Fourth.nature = nature;
	l_Fourth.characteristic = characteristic;
	l_Fourth.isNoGender = isNoGender;
	l_Fourth.isEnableDream = isEnableDream;
	l_Fourth.fixedIV = fixedIV;
}

void SetSixLSB(int lsb) {
	g_LSB = lsb;
}

void SetTargetCondition6(int iv1, int iv2, int iv3, int iv4, int iv5, int iv6)
{
	g_Ivs[0] = iv1;
	g_Ivs[1] = iv2;
	g_Ivs[2] = iv3;
	g_Ivs[3] = iv4;
	g_Ivs[4] = iv5;
	g_Ivs[5] = iv6;
	for (int i = 0; i < 6; i++) {
		if (g_Ivs[i] != -1) {
			g_setIVs++;
		}
	}

}

void PrepareSix(int ivOffset)
{
	const int length = 10 * g_setIVs;

	g_IvOffset = ivOffset;

	g_ConstantTermVector = 0;

	InitializeTransformationMatrix();
	for (int i = 0; i <= 1 + l_First.fixedIV + ivOffset; ++i)
	{
		ProceedTransformationMatrix();
	}

	for (int a = 0; a < g_setIVs; ++a)
	{
		for (int i = 0; i < 10; ++i)
		{
			int index = 59 + (i / 5) * 64 + (i % 5);
			int bit = a * 10 + i;
			g_InputMatrix[bit] = GetMatrixMultiplier(index);
			if (GetMatrixConst(index) != 0)
			{
				g_ConstantTermVector |= (1ull << (length - 1 - bit));
			}
		}
		ProceedTransformationMatrix();
	}

	CalculateInverseMatrix(length);

	CalculateCoefficientData(length);
}

inline unsigned int TestXoroshiroSixSeed(_u64 seed, XoroshiroState& xoroshiro) {
	// ここから絞り込み
	XoroshiroState tmp;
	xoroshiro.SetSeed(seed);
	// EC
	unsigned int ec = -1;
	do {
		ec = xoroshiro.Next(0xFFFFFFFFu);
	} while (ec == 0xFFFFFFFFu);
	if (g_LSB != -1 && (ec & 1) != g_LSB) {
		return 0;
	}
	// 1匹目個性
	if (l_First.characteristic > -1) {
		int characteristic = fastmod::fastmod_u32(ec, M, 6);
		if (characteristic != l_First.characteristic)
		{
			return 1;
		}
	}

	while (xoroshiro.Next(0xFFFFFFFFu) == 0xFFFFFFFFu); // OTID
	while (xoroshiro.Next(0xFFFFFFFFu) == 0xFFFFFFFFu); // PID
	// 1匹目
	{
		int ivs[6] = { -1, -1, -1, -1, -1, -1 };
		int fixedCount = 0;
		int offset = -l_First.fixedIV;
		do {
			int fixedIndex = 0;
			do {
				fixedIndex = xoroshiro.Next(7); // V箇所
				++offset;
			} while (fixedIndex >= 6);

			if (ivs[fixedIndex] == -1)
			{
				ivs[fixedIndex] = 31;
				++fixedCount;
			}
		} while (fixedCount < l_First.fixedIV);

		// 個体値
		for (int i = 0; i < 6; ++i)
		{
			if (ivs[i] == 31)
			{
				if (l_First.ivs[i] != 31)
				{
					return 1;
				}
			}
			else if (l_First.ivs[i] != xoroshiro.Next(0x1F))
			{
				return 1;
			}
		}

		// 特性
		int ability = 0;
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
			do {
				nature = xoroshiro.Next(0x1F); // 性格
			} while (nature >= 25);

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
				do {
					nature = xoroshiro.Next(0x1F); // 性格
				} while (nature >= 25);

				if (nature != l_First.nature)
				{
					// both do not yield results
					return 1;
				}
			}
		}
		else {
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

			int nature = 6;
			do {
				nature = xoroshiro.Next(0x1F); // 性格
			} while (nature >= 25);

			if (nature != l_First.nature)
			{
				return 1;
			}
		}
	}

	xoroshiro.SetSeed(seed);
	if (!TestPkmn(xoroshiro, l_Second)) {
		return 2;
	}

	// 2匹目
	_u64 nextSeed = seed + Const::c_XoroshiroConst;
	xoroshiro.SetSeed(nextSeed);
	if (!TestPkmn(xoroshiro, l_Third)) {
		return 3;
	}

	// 3匹目
	nextSeed = seed + Const::c_XoroshiroConst + Const::c_XoroshiroConst;
	xoroshiro.SetSeed(nextSeed);
	if (!TestPkmn(xoroshiro, l_Fourth)) {
		return 4;
	}
	return 5;
}

_u64 SearchSix(_u64 ivs)
{
	const int length =60;

	XoroshiroState xoroshiro;
	XoroshiroState tmp;

	_u64 target = 0;

	// 下位30bit = 個体値
	target |= (ivs & 0x3E000000ul) << 30;
	target |= (ivs & 0x1F00000ul) << 25;
	target |= (ivs & 0xF8000ul) << 20; 
	target |= (ivs & 0x7C00ul) << 15;
	target |= (ivs & 0x3E0ul) << 10;
	target |= (ivs & 0x1Ful) << 5; 


	target |= ((32ul + g_Ivs[0] - ((ivs & 0x3E000000ul) >> 25)) & 0x1F) << 50;
	target |= ((32ul + g_Ivs[1] - ((ivs & 0x1F00000ul) >> 20)) & 0x1F) << 40;
	target |= ((32ul + g_Ivs[2] - ((ivs & 0xF8000ul) >> 15)) & 0x1F) << 30;
	target |= ((32ul + g_Ivs[3] - ((ivs & 0x7C00ul) >> 10)) & 0x1F) << 20;
	target |= ((32ul + g_Ivs[4] - ((ivs & 0x3E0ul) >> 5)) & 0x1F) << 10;
	target |= ((32ul + g_Ivs[5] - (ivs & 0x1Ful)) & 0x1F);

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

	for (_u64 search = 0; search < 16; ++search)
	{
		_u64 seed = (processedTarget ^ g_CoefficientData[search]) | g_SearchPattern[search];
		xoroshiro.SetSeed(seed);
		// EC
		unsigned int ec = -1;
		do {
			ec = xoroshiro.Next(0xFFFFFFFFu);
		} while (ec == 0xFFFFFFFFu);
		if (g_LSB != -1 && (ec & 1) != g_LSB) {
			continue;
		}
		if(l_First.characteristic > -1) {
			int characteristic = fastmod::fastmod_u32(ec, M, 6);
			if (characteristic != l_First.characteristic)
			{
				continue;
			}
		}

		while (xoroshiro.Next(0xFFFFFFFFu) == 0xFFFFFFFFu); // OTID
		while (xoroshiro.Next(0xFFFFFFFFu) == 0xFFFFFFFFu); // PID
		{
			int ivs[6] = { -1, -1, -1, -1, -1, -1 };
			int fixedCount = 0;
			int offset = -l_First.fixedIV;
			do {
				int fixedIndex = 0;
				do {
					fixedIndex = xoroshiro.Next(7);
					++offset;
				} while (fixedIndex >= 6);

				if (ivs[fixedIndex] == -1)
				{
					ivs[fixedIndex] = 31;
					++fixedCount;
				}
			} while (fixedCount < l_First.fixedIV);

			if (offset != g_IvOffset)
			{
				continue;
			}

			bool isPassed = true;
			for (int i = 0; i < 6; ++i)
			{
				if (ivs[i] == 31)
				{
					if (l_First.ivs[i] != 31)
					{
						isPassed = false;
						break;
					}
				}
				else if (l_First.ivs[i] != xoroshiro.Next(0x1F))
				{
					isPassed = false;
					break;
				}
			}
			if (!isPassed)
			{
				continue;
			}
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
				if ((l_First.ability >= 0 && l_First.ability != ability) || (l_First.ability == -1 && ability >= 2))
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
				do {
					nature = xoroshiro.Next(0x1F);
				} while (nature >= 25);

				if (nature != l_First.nature)
				{
					xoroshiro.Copy(&tmp);
					// ignore ability
					if (!l_First.isNoGender)
					{
						int gender = 0;
						do {
							gender = xoroshiro.Next(0xFF);
						} while (gender >= 253);
					}

					int nature = 0;
					do {
						nature = xoroshiro.Next(0x1F);
					} while (nature >= 25);

					if (nature != l_First.nature)
					{
						// both do not yield results
						continue;
					}
				}
			} else {
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
				do {
					nature = xoroshiro.Next(0x1F);
				} while (nature >= 25);

				if (nature != l_First.nature)
				{
					continue;
				}
			}
		}

		xoroshiro.SetSeed(seed);
		if (!TestPkmn(xoroshiro, l_Second)) {
			continue;
		}

		_u64 newseed = seed + Const::c_XoroshiroConst;
		xoroshiro.SetSeed(newseed + Const::c_XoroshiroConst);
		if (!TestPkmn(xoroshiro, l_Fourth)) {
			continue;
		}

		xoroshiro.SetSeed(newseed);
		if (!TestPkmn(xoroshiro, l_Third)) {
			continue;
		}

		return seed;
	}
	return 0;
}

_u64 SearchFive(_u64 ivs)
{
	const int length = 50;

	XoroshiroState xoroshiro;
	XoroshiroState tmp;

	_u64 target = 0;

	target |= (ivs & 0x1F00000ul) << 25;
	target |= (ivs & 0xF8000ul) << 20;
	target |= (ivs & 0x7C00ul) << 15; 
	target |= (ivs & 0x3E0ul) << 10; 
	target |= (ivs & 0x1Ful) << 5; 

	target |= ((32ul + g_Ivs[0] - ((ivs & 0x1F00000ul) >> 20)) & 0x1F) << 40;
	target |= ((32ul + g_Ivs[1] - ((ivs & 0xF8000ul) >> 15)) & 0x1F) << 30;
	target |= ((32ul + g_Ivs[2] - ((ivs & 0x7C00ul) >> 10)) & 0x1F) << 20;
	target |= ((32ul + g_Ivs[3] - ((ivs & 0x3E0ul) >> 5)) & 0x1F) << 10;
	target |= ((32ul + g_Ivs[4] - (ivs & 0x1Ful)) & 0x1F);

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

	for (_u64 search = 0; search < 0x4000; ++search)
	{
		_u64 seed = (processedTarget ^ g_CoefficientData[search]) | g_SearchPattern[search];
		xoroshiro.SetSeed(seed);
		// EC
		unsigned int ec = -1;
		do {
			ec = xoroshiro.Next(0xFFFFFFFFu);
		} while (ec == 0xFFFFFFFFu);
		if (g_LSB != -1 && (ec & 1) != g_LSB) {
			continue;
		}
		if (l_First.characteristic > -1) {
			int characteristic = fastmod::fastmod_u32(ec, M, 6);
			if (characteristic != l_First.characteristic)
			{
				continue;
			}
		}

		while (xoroshiro.Next(0xFFFFFFFFu) == 0xFFFFFFFFu); // OTID
		while (xoroshiro.Next(0xFFFFFFFFu) == 0xFFFFFFFFu); // PID
		{
			int ivs[6] = { -1, -1, -1, -1, -1, -1 };
			int fixedCount = 0;
			int offset = -l_First.fixedIV;
			do {
				int fixedIndex = 0;
				do {
					fixedIndex = xoroshiro.Next(7);
					++offset;
				} while (fixedIndex >= 6);

				if (ivs[fixedIndex] == -1)
				{
					ivs[fixedIndex] = 31;
					++fixedCount;
				}
			} while (fixedCount < l_First.fixedIV);

			if (offset != g_IvOffset)
			{
				continue;
			}

			bool isPassed = true;
			for (int i = 0; i < 6; ++i)
			{
				if (ivs[i] == 31)
				{
					if (l_First.ivs[i] != 31)
					{
						isPassed = false;
						break;
					}
				}
				else if (l_First.ivs[i] != xoroshiro.Next(0x1F))
				{
					isPassed = false;
					break;
				}
			}
			if (!isPassed)
			{
				continue;
			}
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
				if ((l_First.ability >= 0 && l_First.ability != ability) || (l_First.ability == -1 && ability >= 2))
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
				do {
					nature = xoroshiro.Next(0x1F);
				} while (nature >= 25);

				if (nature != l_First.nature)
				{
					xoroshiro.Copy(&tmp);
					// ignore ability
					if (!l_First.isNoGender)
					{
						int gender = 0;
						do {
							gender = xoroshiro.Next(0xFF);
						} while (gender >= 253);
					}

					int nature = 0;
					do {
						nature = xoroshiro.Next(0x1F);
					} while (nature >= 25);

					if (nature != l_First.nature)
					{
						// both do not yield results
						continue;
					}
				}
			}
			else {
				// 特性
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
				do {
					nature = xoroshiro.Next(0x1F); // 性格
				} while (nature >= 25);

				if (nature != l_First.nature)
				{
					continue;
				}
			}
		}

		_u64 newseed = seed + Const::c_XoroshiroConst;
		xoroshiro.SetSeed(newseed + Const::c_XoroshiroConst);
		if (!TestPkmn(xoroshiro, l_Fourth)) {
			continue;
		}

		xoroshiro.SetSeed(newseed);
		if (!TestPkmn(xoroshiro, l_Third)) {
			continue;
		}

		xoroshiro.SetSeed(seed);
		if (!TestPkmn(xoroshiro, l_Second)) {
			continue;
		}

		return seed;
	}
	return 0;
}

_u64 SearchFour(_u64 ivs)
{
	const int length = 40;

	XoroshiroState xoroshiro;
	XoroshiroState tmp;

	_u64 target = 0;

	target |= (ivs & 0xF8000ul) << 20;
	target |= (ivs & 0x7C00ul) << 15;
	target |= (ivs & 0x3E0ul) << 10;
	target |= (ivs & 0x1Ful) << 5;

	target |= ((32ul + g_Ivs[0] - ((ivs & 0xF8000ul) >> 15)) & 0x1F) << 30;
	target |= ((32ul + g_Ivs[1] - ((ivs & 0x7C00ul) >> 10)) & 0x1F) << 20;
	target |= ((32ul + g_Ivs[2] - ((ivs & 0x3E0ul) >> 5)) & 0x1F) << 10;
	target |= ((32ul + g_Ivs[3] - (ivs & 0x1Ful)) & 0x1F);

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

	for (_u64 search = 0; search < 0x1000000; ++search)
	{
		_u64 seed = (processedTarget ^ g_CoefficientData[search]) | g_SearchPattern[search];
		xoroshiro.SetSeed(seed);
		// EC
		unsigned int ec = -1;
		do {
			ec = xoroshiro.Next(0xFFFFFFFFu);
		} while (ec == 0xFFFFFFFFu);
		if (g_LSB != -1 && (ec & 1) != g_LSB) {
			continue;
		}
		if (l_First.characteristic > -1) {
			int characteristic = fastmod::fastmod_u32(ec, M, 6);
			if (characteristic != l_First.characteristic)
			{
				continue;
			}
		}

		while (xoroshiro.Next(0xFFFFFFFFu) == 0xFFFFFFFFu); // OTID
		while (xoroshiro.Next(0xFFFFFFFFu) == 0xFFFFFFFFu); // PID
		{
			int ivs[6] = { -1, -1, -1, -1, -1, -1 };
			int fixedCount = 0;
			int offset = -l_First.fixedIV;
			do {
				int fixedIndex = 0;
				do {
					fixedIndex = xoroshiro.Next(7);
					++offset;
				} while (fixedIndex >= 6);

				if (ivs[fixedIndex] == -1)
				{
					ivs[fixedIndex] = 31;
					++fixedCount;
				}
			} while (fixedCount < l_First.fixedIV);

			if (offset != g_IvOffset)
			{
				continue;
			}

			bool isPassed = true;
			for (int i = 0; i < 6; ++i)
			{
				if (ivs[i] == 31)
				{
					if (l_First.ivs[i] != 31)
					{
						isPassed = false;
						break;
					}
				}
				else if (l_First.ivs[i] != xoroshiro.Next(0x1F))
				{
					isPassed = false;
					break;
				}
			}
			if (!isPassed)
			{
				continue;
			}
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
				if ((l_First.ability >= 0 && l_First.ability != ability) || (l_First.ability == -1 && ability >= 2))
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
				do {
					nature = xoroshiro.Next(0x1F);
				} while (nature >= 25);

				if (nature != l_First.nature)
				{
					xoroshiro.Copy(&tmp);
					// ignore ability
					if (!l_First.isNoGender)
					{
						int gender = 0;
						do {
							gender = xoroshiro.Next(0xFF);
						} while (gender >= 253);
					}

					int nature = 0;
					do {
						nature = xoroshiro.Next(0x1F);
					} while (nature >= 25);

					if (nature != l_First.nature)
					{
						// both do not yield results
						continue;
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
				do {
					nature = xoroshiro.Next(0x1F); 
				} while (nature >= 25);

				if (nature != l_First.nature)
				{
					continue;
				}
			}
		}

		xoroshiro.SetSeed(seed);
		if (!TestPkmn(xoroshiro, l_Second)) {
			continue;
		}

		_u64 newseed = seed + Const::c_XoroshiroConst;
		xoroshiro.SetSeed(newseed + Const::c_XoroshiroConst);
		if (!TestPkmn(xoroshiro, l_Fourth)) {
			continue;
		}

		xoroshiro.SetSeed(newseed);
		if (!TestPkmn(xoroshiro, l_Third)) {
			continue;
		}
		return seed;
	}
	return 0;
}

unsigned int TestSixSeed(_u64 seed) {
	XoroshiroState xoroshiro;
	return TestXoroshiroSixSeed(seed, xoroshiro);
}