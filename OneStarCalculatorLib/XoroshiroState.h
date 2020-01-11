#pragma once
#include "Type.h"
#include "Const.h"
inline _u64 RotateLeft(_u64 value, int amount)
{
	return  (value << amount) | (value >> (64 - amount));
}

struct XoroshiroState
{
	_u64 m_S0;
	_u64 m_S1;

	void SetSeed(_u64 seed)
	{
		m_S0 = seed;
		m_S1 = Const::c_XoroshiroConst;
	}

	void Copy(XoroshiroState* src)
	{
		m_S0 = src->m_S0;
		m_S1 = src->m_S1;
	}

	int Next(int mask)
	{
		int value = (m_S0 + m_S1) & mask;
		m_S1 = m_S0 ^ m_S1;
		m_S0 = RotateLeft(m_S0, 24) ^ m_S1 ^ (m_S1 << 16);
		m_S1 = RotateLeft(m_S1, 37);
		return value;
	}
	unsigned int Next(unsigned int mask)
	{
		unsigned int value = (m_S0 + m_S1) & mask;
		m_S1 = m_S0 ^ m_S1;
		m_S0 = RotateLeft(m_S0, 24) ^ m_S1 ^ (m_S1 << 16);
		m_S1 = RotateLeft(m_S1, 37);
		return value;
	}
	void Next()
	{
		m_S1 = m_S0 ^ m_S1;
		m_S0 = RotateLeft(m_S0, 24) ^ m_S1 ^ (m_S1 << 16);
		m_S1 = RotateLeft(m_S1, 37);
	}
};
