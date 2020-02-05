#include <iostream>
#include "Util.h"
#include "Calculator.h"
#include "Const.h"
#include "XoroshiroState.h"
#include "Data.h"
#include "fastmod.h"

// 検索条件設定
static PokemonData l_First;
static PokemonData l_Second;
static PokemonData l_Third;

static int g_Rerolls;
static int g_FixedIndex;
static int g_LSB;

static uint64_t M = fastmod::computeM_u32(6);

// 絞り込み条件設定

// V確定用参照
const int* g_IvsRef[30] = {
	&l_First.ivs[1], &l_First.ivs[2], &l_First.ivs[3], &l_First.ivs[4], &l_First.ivs[5],
	&l_First.ivs[0], &l_First.ivs[2], &l_First.ivs[3], &l_First.ivs[4], &l_First.ivs[5],
	&l_First.ivs[0], &l_First.ivs[1], &l_First.ivs[3], &l_First.ivs[4], &l_First.ivs[5],
	&l_First.ivs[0], &l_First.ivs[1], &l_First.ivs[2], &l_First.ivs[4], &l_First.ivs[5],
	&l_First.ivs[0], &l_First.ivs[1], &l_First.ivs[2], &l_First.ivs[3], &l_First.ivs[5],
	&l_First.ivs[0], &l_First.ivs[1], &l_First.ivs[2], &l_First.ivs[3], &l_First.ivs[4]
};

#define LENGTH_BASE (56)

// 夢特性なし、かつ特性指定ありの場合AbilityBitが有効
inline bool IsEnableAbilityBit() { return (!l_First.isEnableDream && l_First.ability >= 0); }

void SetFirstCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int flawlessIDX, int ability, int nature, int characteristics, int species, int altform, bool isNoGender, bool isEnableDream)
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
	g_FixedIndex = flawlessIDX;
}

void SetNextCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristics, int species, int altform, bool isNoGender, bool isEnableDream)
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
	l_Second.altForm = altform;
	l_Second.fixedIV = fixedIV;
}

void SetThirdCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristics, int species, int altform, bool isNoGender, bool isEnableDream)
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
	l_Third.altForm = altform;
	l_Third.fixedIV = fixedIV;
}

void SetLSB(int lsb) {
	g_LSB = lsb;
}

void Prepare(int rerolls)
{
	const int length = (IsEnableAbilityBit() ? LENGTH_BASE + 1 : LENGTH_BASE);

	g_Rerolls = rerolls;

	// 使用する行列値をセット
	// 使用する定数ベクトルをセット

	g_ConstantTermVector = 0;

	// r[3+rerolls]をV箇所、r[4+rerolls]からr[8+rerolls]を個体値として使う

	// 変換行列を計算
	InitializeTransformationMatrix(); // r[1]が得られる変換行列がセットされる
	for (int i = 0; i <= rerolls + 1; ++i)
	{
		ProceedTransformationMatrix(); // r[2 + i]が得られる
	}

	int bit = 0;
	for (int i = 0; i < 6; ++i, ++bit)
	{
		int index = 61 + (i / 3) * 64 + (i % 3);
		g_InputMatrix[bit] = GetMatrixMultiplier(index);
		if (GetMatrixConst(index) != 0)
		{
			g_ConstantTermVector |= (1ull << (length - 1 - bit));
		}
	}
	for (int a = 0; a < 5; ++a)
	{
		ProceedTransformationMatrix();
		for (int i = 0; i < 10; ++i, ++bit)
		{
			int index = 59 + (i / 5) * 64 + (i % 5);
			g_InputMatrix[bit] = GetMatrixMultiplier(index);
			if (GetMatrixConst(index) != 0)
			{
				g_ConstantTermVector |= (1ull << (length - 1 - bit));
			}
		}
	}
	// Abilityは2つを圧縮 r[9+rerolls]
	if (IsEnableAbilityBit())
	{
		ProceedTransformationMatrix();

		g_InputMatrix[LENGTH_BASE] = GetMatrixMultiplier(63) ^ GetMatrixMultiplier(127);
		if ((GetMatrixConst(63) ^ GetMatrixConst(127)) != 0)
		{
			g_ConstantTermVector |= 1;
		}
	}

	// 行基本変形で求める
	int l = CalculateInverseMatrix(length);

	// 事前データを計算
	CalculateCoefficientData(l);
}

inline int TestXoroshiroSeed(_u64 seed, XoroshiroState& xoroshiro) {
	XoroshiroState tmp;
	xoroshiro.SetSeed(seed);
	unsigned int ec = -1;
	do {
		ec = xoroshiro.Next(0xFFFFFFFFu);
	} while (ec == 0xFFFFFFFFu);
	if (g_LSB != -1 && (ec & 1) != g_LSB) {
		return 0;
	}
	if (l_First.characteristic > -1) {
		int characteristic = fastmod::fastmod_u32(ec, M, 6);
		if (characteristic != l_First.characteristic)
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
		if (IsEnableAbilityBit())
		{
			xoroshiro.Next(); // AbilityBitが有効な場合は計算で加味されているのでチェック不要
		}
		else
		{
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
	}
	

	// 2匹目
	_u64 nextSeed = seed + Const::c_XoroshiroConst;
	xoroshiro.SetSeed(nextSeed);
	if (!TestPkmn(xoroshiro, l_Second)) {
		return 3;
	}

	// 3匹目
	nextSeed = seed + Const::c_XoroshiroConst + Const::c_XoroshiroConst;
	xoroshiro.SetSeed(nextSeed);
	if (!TestPkmn(xoroshiro, l_Third)) {
		return 4;
	}
	return 5;
}

_u64 Search(_u64 ivs)
{
	const int length = (IsEnableAbilityBit() ? LENGTH_BASE + 1 : LENGTH_BASE);

	XoroshiroState xoroshiro;
	XoroshiroState tmp;
	_u64 target = (IsEnableAbilityBit() ? (l_First.ability & 1) : 0);
	int bitOffset = (IsEnableAbilityBit() ? 1 : 0);

	// 上位3bit = V箇所決定
	target |= (ivs & 0xE000000ul) << (28 + bitOffset); // fixedIndex0

	// 下位25bit = 個体値
	target |= (ivs & 0x1F00000ul) << (25 + bitOffset); // iv0_0
	target |= (ivs & 0xF8000ul) << (20 + bitOffset); // iv1_0
	target |= (ivs & 0x7C00ul) << (15 + bitOffset); // iv2_0
	target |= (ivs & 0x3E0ul) << (10 + bitOffset); // iv3_0
	target |= (ivs & 0x1Ful) << (5 + bitOffset); // iv4_0

	// 隠された値を推定
	target |= ((8ul + g_FixedIndex - ((ivs & 0xE000000ul) >> 25)) & 7) << (50 + bitOffset);

	target |= ((32ul + *g_IvsRef[g_FixedIndex * 5] - ((ivs & 0x1F00000ul) >> 20)) & 0x1F) << (40 + bitOffset);
	target |= ((32ul + *g_IvsRef[g_FixedIndex * 5 + 1] - ((ivs & 0xF8000ul) >> 15)) & 0x1F) << (30 + bitOffset);
	target |= ((32ul + *g_IvsRef[g_FixedIndex * 5 + 2] - ((ivs & 0x7C00ul) >> 10)) & 0x1F) << (20 + bitOffset);
	target |= ((32ul + *g_IvsRef[g_FixedIndex * 5 + 3] - ((ivs & 0x3E0ul) >> 5)) & 0x1F) << (10 + bitOffset);
	target |= ((32ul + *g_IvsRef[g_FixedIndex * 5 + 4] - (ivs & 0x1Ful)) & 0x1F) << bitOffset;

	// targetベクトル入力完了

	target ^= g_ConstantTermVector;

	// 56~57bit側の計算結果キャッシュ
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

	// 下位7bitを決める
	_u64 max = ((1 << (64 - length)) - 1);
	for (_u64 search = 0; search <= max; ++search)
	{
		_u64 seed = (processedTarget ^ g_CoefficientData[search]) | g_SearchPattern[search];

		// ここから絞り込み
		xoroshiro.SetSeed(seed);
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

		// V箇所
		int offset = -1;
		for (offset = 0; xoroshiro.Next(7) >= 6; offset++); // V箇所

		// reroll回数
		if (offset != g_Rerolls)
		{
			continue;
		}

		xoroshiro.Next(); // 個体値1
		xoroshiro.Next(); // 個体値2
		xoroshiro.Next(); // 個体値3
		xoroshiro.Next(); // 個体値4
		xoroshiro.Next(); // 個体値5

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
					continue;
				}
			}
		}
		else {
			if (IsEnableAbilityBit())
			{
				xoroshiro.Next(); // AbilityBitが有効な場合は計算で加味されているのでチェック不要
			}
			else
			{
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
		}

		// 2匹目
		_u64 nextSeed = seed + Const::c_XoroshiroConst;
		xoroshiro.SetSeed(nextSeed);
		if (!TestPkmn(xoroshiro, l_Second)) {
			continue;
		}

		// 3匹目
		nextSeed += Const::c_XoroshiroConst;
		xoroshiro.SetSeed(nextSeed);
		if (!TestPkmn(xoroshiro, l_Third)) {
			continue;
		}
		return seed;
	}
	return 0;
}

unsigned int TestSeed(_u64 seed) {
	XoroshiroState xoroshiro;
	return TestXoroshiroSeed(seed, xoroshiro);
}