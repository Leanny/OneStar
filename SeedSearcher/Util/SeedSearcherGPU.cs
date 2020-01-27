using Alea;
using Alea.Parallel;
using System;
using System.Collections.Generic;

namespace SeedSearcherGui
{
    class SeedSearcherGPU
    {
		[GpuParam]
		private int[] ToxtricityAmplifiedNatures = { 0x03, 0x04, 0x02, 0x08, 0x09, 0x13, 0x16, 0x0B, 0x0D, 0x0E, 0x00, 0x06, 0x18 };
		[GpuParam]
		private int[] ToxtricityLowKeyNatures = { 0x01, 0x05, 0x07, 0x0A, 0x0C, 0x0F, 0x10, 0x11, 0x12, 0x14, 0x15, 0x17 };
		[GpuParam]
		private const int ToxtricityID = 849;

		private PkmnStruct pkmn1;
		private PkmnStruct pkmn2;
		private PkmnStruct pkmn3;
		private PkmnStruct pkmn4;
		private int[] g_Ivs = { -1, -1, -1, -1, -1, -1 };
		private int g_setIVs;
		private int LSB;

		public void SetSixFirstCondition(PkmnStruct pkmn) {
			pkmn1 = pkmn;
		}
		public void SetSixSecondCondition(PkmnStruct pkmn)
		{
			pkmn2 = pkmn;
		}
		public void SetSixThirdCondition(PkmnStruct pkmn)
		{
			pkmn3 = pkmn;
		}
		public void SetSixFourthCondition(PkmnStruct pkmn)
		{
			pkmn4 = pkmn;
		}

		public void SetTargetCondition(int[] target) {
			for (int i = 0; i < 6; i++)
			{
				g_Ivs[i] = target[i];
				if (g_Ivs[i] != -1)
				{
					g_setIVs++;
				}
			}
		}

		public uint TestSeed(ulong seed) {
			ulong iv0 = (ulong)g_Ivs[0];
			ulong iv1 = (ulong)g_Ivs[1];
			ulong iv2 = (ulong)g_Ivs[2];
			ulong iv3 = (ulong)g_Ivs[3];
			ulong iv4 = (ulong)g_Ivs[4];
			ulong iv5 = (ulong)g_Ivs[5];

			int[] allIVs = { pkmn1.ivs0, pkmn1.ivs1, pkmn1.ivs2, pkmn1.ivs3, pkmn1.ivs4, pkmn1.ivs5, pkmn2.ivs0, pkmn2.ivs1, pkmn2.ivs2, pkmn2.ivs3, pkmn2.ivs4, pkmn2.ivs5,
							 pkmn3.ivs0, pkmn3.ivs1, pkmn3.ivs2, pkmn3.ivs3, pkmn3.ivs4, pkmn3.ivs5, pkmn4.ivs0, pkmn4.ivs1, pkmn4.ivs2, pkmn4.ivs3, pkmn4.ivs4, pkmn4.ivs5,};
			int[] fixedIVs = { pkmn1.fixedIV, pkmn2.fixedIV, pkmn3.fixedIV, pkmn4.fixedIV };
			int[] abilitys = { pkmn1.ability, pkmn2.ability, pkmn3.ability, pkmn4.ability };
			bool[] noGender = { pkmn1.isNoGender, pkmn2.isNoGender, pkmn3.isNoGender, pkmn4.isNoGender };
			bool[] HA = { pkmn1.isEnableDream, pkmn2.isEnableDream, pkmn3.isEnableDream, pkmn4.isEnableDream };
			int[] natures = { pkmn1.nature, pkmn2.nature, pkmn3.nature, pkmn4.nature };
			int characteristic1 = pkmn1.characteristic;
			int g_lsb = LSB;
			int[] species = { pkmn1.ID, pkmn2.ID, pkmn3.ID, pkmn4.ID };
			int[] alt = { pkmn1.altForm, pkmn2.altForm, pkmn3.altForm, pkmn4.altForm };
			ulong[] add_const = { 0, 0, 0x82a2b175229d6a5bul, 0x54562ea453ad4b6ul };
			ulong s0;
			ulong s1;
			ulong s0tmp;
			ulong s1tmp;
			uint ec;
			uint skip;
			int ivs;
			int g_FixedIvs;
			int fixedIndex;
			int tmp;
			for(uint val = 0; val < 4; val++)
			{
				s0 = seed + add_const[val];
				s1 = 0x82a2b175229d6a5b;
				// EC
				do
				{
					ec = (uint)(s0 + s1);
					s1 = s0 ^ s1;
					s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
					s1 = RotateLeft(s1, 37);
				} while (ec == 0xFFFFFFFF);

				if (val == 0)
				{
					if (g_lsb >= 0 && (ec & 1) != g_lsb)
					{
						return 0;
					}

					if (characteristic1 >= 0)
					{
						int characteristic = (int)(ec % 6);
						if (characteristic != characteristic1)
						{
							return val + 1;
						}
					}
				}
				// SIDTID
				do
				{
					skip = (uint)(s0 + s1);
					s1 = s0 ^ s1;
					s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
					s1 = RotateLeft(s1, 37);
				} while (skip == 0xFFFFFFFF);

				// TID
				do
				{
					skip = (uint)(s0 + s1);
					s1 = s0 ^ s1;
					s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
					s1 = RotateLeft(s1, 37);
				} while (skip == 0xFFFFFFFF);

				ivs = 0;
				g_FixedIvs = fixedIVs[val];
				while (g_FixedIvs > 0)
				{
					do
					{
						fixedIndex = (int)((s0 + s1) & 7);
						s1 = s0 ^ s1;
						s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
						s1 = RotateLeft(s1, 37);
					} while (fixedIndex >= 6 || ((1 << fixedIndex) & ivs) != 0);
					ivs |= 1 << fixedIndex;
					if (allIVs[val * 6 + fixedIndex] != 31)
					{
						return val + 1;
					}
					g_FixedIvs--;
				}

				for (int i = 0; i < 6; ++i)
				{
					if (((1 << i) & ivs) == 0)
					{
						if (allIVs[val * 6 + i] != (int)((s0 + s1) & 31))
						{
							return val + 1;
						}
						s1 = s0 ^ s1;
						s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
						s1 = RotateLeft(s1, 37);
					}
				}
				tmp = 0;
				// special case
				if (abilitys[val] == -2)
				{
					s0tmp = s0;
					s1tmp = s1;
					if (HA[val])
					{
						do
						{
							tmp = (int)((s0 + s1) & 3);
							s1 = s0 ^ s1;
							s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
							s1 = RotateLeft(s1, 37);
						} while (tmp >= 3);
					}
					else
					{
						tmp = (int)((s0 + s1) & 1);
						s1 = s0 ^ s1;
						s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
						s1 = RotateLeft(s1, 37);
					}
					if (!noGender[val])
					{
						do
						{
							tmp = (int)((s0 + s1) & 255);
							s1 = s0 ^ s1;
							s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
							s1 = RotateLeft(s1, 37);
						} while (tmp >= 253);
					}
					tmp = 0;
					if (species[val] == ToxtricityID)
					{
						if (alt[val] == 0)
						{
							do
							{
								tmp = (int)((s0 + s1) & 15);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (tmp >= 13);
							tmp = ToxtricityAmplifiedNatures[tmp];
						}
						else
						{
							do
							{
								tmp = (int)((s0 + s1) & 15);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (tmp >= 12);
							tmp = ToxtricityLowKeyNatures[tmp];
						}
					}
					else
					{
						do
						{
							tmp = (int)((s0 + s1) & 31);
							s1 = s0 ^ s1;
							s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
							s1 = RotateLeft(s1, 37);
						} while (tmp >= 25);
					}
					if (tmp != natures[val])
					{
						s0 = s0tmp;
						s1 = s1tmp;
						if (!noGender[val])
						{
							do
							{
								tmp = (int)((s0 + s1) & 255);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (tmp >= 253);
						}
						tmp = 0;
						if (species[val] == ToxtricityID)
						{
							if (alt[val] == 0)
							{
								do
								{
									tmp = (int)((s0 + s1) & 15);
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
								} while (tmp >= 13);
								tmp = ToxtricityAmplifiedNatures[tmp];
							}
							else
							{
								do
								{
									tmp = (int)((s0 + s1) & 15);
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
								} while (tmp >= 12);
								tmp = ToxtricityLowKeyNatures[tmp];
							}
						}
						else
						{
							do
							{
								tmp = (int)((s0 + s1) & 31);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (tmp >= 25);
						}
						if (tmp != natures[val])
						{
							return val + 1;
						}
					}

				}
				else
				{
					if (HA[val])
					{
						do
						{
							tmp = (int)((s0 + s1) & 3);
							s1 = s0 ^ s1;
							s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
							s1 = RotateLeft(s1, 37);
						} while (tmp >= 3);
						if (abilitys[val] != -1 && abilitys[val] != tmp) return val + 1;
					}
					else
					{
						tmp = (int)((s0 + s1) & 1);
						s1 = s0 ^ s1;
						s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
						s1 = RotateLeft(s1, 37);
						if (abilitys[val] != -1 && abilitys[val] != tmp) return val + 1;
					}

					if (!noGender[val])
					{
						do
						{
							tmp = (int)((s0 + s1) & 255);
							s1 = s0 ^ s1;
							s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
							s1 = RotateLeft(s1, 37);
						} while (tmp >= 253);
					}

					tmp = 0;
					if (species[val] == ToxtricityID)
					{
						if (alt[val] == 0)
						{
							do
							{
								tmp = (int)((s0 + s1) & 15);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (tmp >= 13);
							tmp = ToxtricityAmplifiedNatures[tmp];
						}
						else
						{
							do
							{
								tmp = (int)((s0 + s1) & 15);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (tmp >= 12);
							tmp = ToxtricityLowKeyNatures[tmp];
						}
					}
					else
					{
						do
						{
							tmp = (int)((s0 + s1) & 31);
							s1 = s0 ^ s1;
							s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
							s1 = RotateLeft(s1, 37);
						} while (tmp >= 25);
					}
					if (tmp != natures[val])
					{
						return val + 1;
					}
				}
			}
			return 5;
		}
		public void SetSixLSB(int val) {
			LSB = val;
		}

		public static Device[] UseableGPU()
		{
			try
			{
				return Device.Devices;
			} catch(Exception e)
			{
				return new Device[] { };
			}
		}

		static ulong RotateLeft(ulong value, int amount)
		{
			return (value << amount) | (value >> (64 - amount));
		}

		[GpuManaged]
		public ulong SearchOne(Device device, int start, int end, System.Windows.Forms.ToolStripStatusLabel updateLbl)
		{
			var gpu = Gpu.Get(device.Id);
			const int searchLower = 0;
			const int searchUpper = 0x10000000;
			int length = 56;
			bool abilityBit = !pkmn1.isEnableDream && (pkmn1.ability == 0 || pkmn1.ability == 1);
			if (abilityBit)
			{
				length += 1;
			}
			int numElems = 1 << (64 - length);
			ulong iv0 = (ulong)g_Ivs[0];
			ulong iv1 = (ulong)g_Ivs[1];
			ulong iv2 = (ulong)g_Ivs[2];
			ulong iv3 = (ulong)g_Ivs[3];
			ulong iv4 = (ulong)g_Ivs[4];

			ulong[] g_IvsRef = {
				(ulong) pkmn1.ivs1, (ulong) pkmn1.ivs2, (ulong) pkmn1.ivs3, (ulong) pkmn1.ivs4, (ulong) pkmn1.ivs5,
				(ulong) pkmn1.ivs0, (ulong) pkmn1.ivs2, (ulong) pkmn1.ivs3, (ulong) pkmn1.ivs4, (ulong) pkmn1.ivs5,
				(ulong) pkmn1.ivs0, (ulong) pkmn1.ivs1, (ulong) pkmn1.ivs3, (ulong) pkmn1.ivs4, (ulong) pkmn1.ivs5,
				(ulong) pkmn1.ivs0, (ulong) pkmn1.ivs1, (ulong) pkmn1.ivs2, (ulong) pkmn1.ivs4, (ulong) pkmn1.ivs5,
				(ulong) pkmn1.ivs0, (ulong) pkmn1.ivs1, (ulong) pkmn1.ivs2, (ulong) pkmn1.ivs3, (ulong) pkmn1.ivs5,
				(ulong) pkmn1.ivs0, (ulong) pkmn1.ivs1, (ulong) pkmn1.ivs2, (ulong) pkmn1.ivs3, (ulong) pkmn1.ivs4
			};

			int[] allIVs = { pkmn1.ivs0, pkmn1.ivs1, pkmn1.ivs2, pkmn1.ivs3, pkmn1.ivs4, pkmn1.ivs5, pkmn2.ivs0, pkmn2.ivs1, pkmn2.ivs2, pkmn2.ivs3, pkmn2.ivs4, pkmn2.ivs5,
							 pkmn3.ivs0, pkmn3.ivs1, pkmn3.ivs2, pkmn3.ivs3, pkmn3.ivs4, pkmn3.ivs5};
			int[] fixedIVs = { pkmn1.fixedIV, pkmn2.fixedIV, pkmn3.fixedIV};
			int[] abilitys = { pkmn1.ability, pkmn2.ability, pkmn3.ability };
			bool[] noGender = { pkmn1.isNoGender, pkmn2.isNoGender, pkmn3.isNoGender};
			bool[] HA = { pkmn1.isEnableDream, pkmn2.isEnableDream, pkmn3.isEnableDream};
			int[] natures = { pkmn1.nature, pkmn2.nature, pkmn3.nature };
			int characteristic1 = pkmn1.characteristic;
			int g_lsb = LSB;
			int[] species = { pkmn1.ID, pkmn2.ID, pkmn3.ID };
			int[] alt = { pkmn1.altForm, pkmn2.altForm, pkmn3.altForm };

			ulong[] entry = { 0 };
			for (int ivOffset = start; ivOffset <= end; ivOffset++)
			{
				updateLbl.Text = ivOffset.ToString();
				ulong g_ConstantTermVector = 0;

				MatrixStruct.InitializeTransformationMatrix();
				for (int i = 0; i <= 1 + ivOffset; ++i)
				{
					MatrixStruct.ProceedTransformationMatrix();
				}

				int bit = 0;
				for (int i = 0; i < 6; ++i, ++bit)
				{
					int index = 61 + (i / 3) * 64 + (i % 3);
					MatrixStruct.g_InputMatrix[bit] = MatrixStruct.GetMatrixMultiplier(index);
					if (MatrixStruct.GetMatrixConst(index) != 0)
					{
						g_ConstantTermVector |= (1ul << (length - 1 - bit));
					}
				}
				for (int a = 0; a < 5; ++a)
				{
					MatrixStruct.ProceedTransformationMatrix();
					for (int i = 0; i < 10; ++i, ++bit)
					{
						int index = 59 + (i / 5) * 64 + (i % 5);
						MatrixStruct.g_InputMatrix[bit] = MatrixStruct.GetMatrixMultiplier(index);
						if (MatrixStruct.GetMatrixConst(index) != 0)
						{
							g_ConstantTermVector |= (1ul << (length - 1 - bit));
						}
					}
				}

				if (abilityBit)
				{
					MatrixStruct.ProceedTransformationMatrix();

					MatrixStruct.g_InputMatrix[56] = MatrixStruct.GetMatrixMultiplier(63) ^ MatrixStruct.GetMatrixMultiplier(127);
					if ((MatrixStruct.GetMatrixConst(63) ^ MatrixStruct.GetMatrixConst(127)) != 0)
					{
						g_ConstantTermVector |= 1;
					}
				}

				MatrixStruct.CalculateInverseMatrix(length);
				MatrixStruct.CalculateCoefficientData(length);

				bool[] g_FreeBit = new bool[64];
				ulong[] g_AnswerFlag = new ulong[64];
				ulong[] g_CoefficientData = new ulong[numElems];
				ulong[] g_SearchPattern = new ulong[numElems];
				Array.Copy(MatrixStruct.g_CoefficientData, 0, g_CoefficientData, 0, numElems);
				Array.Copy(MatrixStruct.g_SearchPattern, 0, g_SearchPattern, 0, numElems);
				Array.Copy(MatrixStruct.g_AnswerFlag, 0, g_AnswerFlag, 0, 64);
				for (int num = 0; num < g_FreeBit.Length; num++)
				{
					g_FreeBit[num] = MatrixStruct.g_FreeBit[num] > 0;
				}

				ulong[] add_const = { 0, 0x82a2b175229d6a5bul, 0x54562ea453ad4b6ul };
				ulong targetStart = abilityBit ? ((ulong)pkmn1.ability & 1) : 0ul;
				int bitOffset = abilityBit ? 1 : 0;
				int g_FixedIndex = pkmn1.fixedIVPos;
				ulong g_ulongIndex = (ulong)g_FixedIndex;
				gpu.LongFor(searchLower, searchUpper, input => {
					ulong target = targetStart;
					ulong input_ivs = (ulong)input;
					target |= (input_ivs & 0xE000000ul) << (28 + bitOffset); 
					target |= (input_ivs & 0x1F00000ul) << (25 + bitOffset); 
					target |= (input_ivs & 0xF8000ul) << (20 + bitOffset); 
					target |= (input_ivs & 0x7C00ul) << (15 + bitOffset); 
					target |= (input_ivs & 0x3E0ul) << (10 + bitOffset);
					target |= (input_ivs & 0x1Ful) << (5 + bitOffset);

					target |= ((8ul + g_ulongIndex - ((input_ivs & 0xE000000ul) >> 25)) & 7) << (50 + bitOffset);
					target |= ((32ul + g_IvsRef[g_FixedIndex * 5] - ((input_ivs & 0x1F00000ul) >> 20)) & 0x1F) << (40 + bitOffset);
					target |= ((32ul + g_IvsRef[g_FixedIndex * 5 + 1] - ((input_ivs & 0xF8000ul) >> 15)) & 0x1F) << (30 + bitOffset);
					target |= ((32ul + g_IvsRef[g_FixedIndex * 5 + 2] - ((input_ivs & 0x7C00ul) >> 10)) & 0x1F) << (20 + bitOffset);
					target |= ((32ul + g_IvsRef[g_FixedIndex * 5 + 3] - ((input_ivs & 0x3E0ul) >> 5)) & 0x1F) << (10 + bitOffset);
					target |= ((32ul + g_IvsRef[g_FixedIndex * 5 + 4] - (input_ivs & 0x1Ful)) & 0x1F) << bitOffset;

					target ^= g_ConstantTermVector;

					ulong processedTarget = 0;
					int offset = 0;
					for (int i = 0; i < length; ++i)
					{
						while (g_FreeBit[i + offset])
						{
							++offset;
						}
						processedTarget |= MatrixStruct.GetSignature(g_AnswerFlag[i] & target) << (63 - (i + offset));
					}

					ulong s0;
					ulong s1;
					ulong s0tmp;
					ulong s1tmp;
					uint ec;
					uint skip;
					int ivs;
					int g_FixedIvs;
					int fixedIndex;
					int tmp;
					ulong seed = 0;
					for (int search = 0; search < numElems; ++search)
					{
						seed = (processedTarget ^ g_CoefficientData[search]) | g_SearchPattern[search];

						s0 = seed;
						s1 = 0x82a2b175229d6a5b;
						// EC
						do
						{
							ec = (uint)(s0 + s1);
							s1 = s0 ^ s1;
							s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
							s1 = RotateLeft(s1, 37);
						} while (ec == 0xFFFFFFFF);

						if (g_lsb >= 0 && (ec & 1) != g_lsb)
						{
							continue;
						}

						if (characteristic1 >= 0)
						{
							int characteristic = (int)(ec % 6);
							if (characteristic != characteristic1)
							{
								continue;
							}
						}

						int val = 2;
						while (val >= 0)
						{
							s0 = seed + add_const[val];
							s1 = 0x82a2b175229d6a5b;
							// EC
							do
							{
								ec = (uint)(s0 + s1);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (ec == 0xFFFFFFFF);

							// SIDTID
							do
							{
								skip = (uint)(s0 + s1);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (skip == 0xFFFFFFFF);

							// TID
							do
							{
								skip = (uint)(s0 + s1);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (skip == 0xFFFFFFFF);

							ivs = 0;
							g_FixedIvs = fixedIVs[val];
							fixedIndex = 0;
							while (g_FixedIvs > 0)
							{
								do
								{
									fixedIndex = (int)((s0 + s1) & 7);
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
								} while (fixedIndex >= 6 || ((1 << fixedIndex) & ivs) != 0);
								ivs |= 1 << fixedIndex;
								if (allIVs[val * 6 + fixedIndex] != 31)
								{
									goto end;
								}
								g_FixedIvs--;
							}

							for (int i = 0; i < 6; ++i)
							{
								if (((1 << i) & ivs) == 0)
								{
									if (allIVs[val * 6 + i] != (int)((s0 + s1) & 31))
									{
										goto end;
									}
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
								}
							}
							tmp = 0;
							// special case
							if (abilitys[val] == -2)
							{
								s0tmp = s0;
								s1tmp = s1;
								if (HA[val])
								{
									do
									{
										tmp = (int)((s0 + s1) & 3);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 3);
								}
								else
								{
									tmp = (int)((s0 + s1) & 1);
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
								}
								if (!noGender[val])
								{
									do
									{
										tmp = (int)((s0 + s1) & 255);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 253);
								}
								tmp = 0;
								if (species[val] == ToxtricityID)
								{
									if (alt[val] == 0)
									{
										do
										{
											tmp = (int)((s0 + s1) & 15);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 13);
										tmp = ToxtricityAmplifiedNatures[tmp];
									}
									else
									{
										do
										{
											tmp = (int)((s0 + s1) & 15);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 12);
										tmp = ToxtricityLowKeyNatures[tmp];
									}
								}
								else
								{
									do
									{
										tmp = (int)((s0 + s1) & 31);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 25);
								}
								if (tmp != natures[val])
								{
									s0 = s0tmp;
									s1 = s1tmp;
									if (!noGender[val])
									{
										do
										{
											tmp = (int)((s0 + s1) & 255);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 253);
									}
									tmp = 0;
									if (species[val] == ToxtricityID)
									{
										if (alt[val] == 0)
										{
											do
											{
												tmp = (int)((s0 + s1) & 15);
												s1 = s0 ^ s1;
												s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
												s1 = RotateLeft(s1, 37);
											} while (tmp >= 13);
											tmp = ToxtricityAmplifiedNatures[tmp];
										}
										else
										{
											do
											{
												tmp = (int)((s0 + s1) & 15);
												s1 = s0 ^ s1;
												s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
												s1 = RotateLeft(s1, 37);
											} while (tmp >= 12);
											tmp = ToxtricityLowKeyNatures[tmp];
										}
									}
									else
									{
										do
										{
											tmp = (int)((s0 + s1) & 31);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 25);
									}
									if (tmp != natures[val])
									{
										break;
									}
								}

							}
							else
							{
								if (HA[val])
								{
									do
									{
										tmp = (int)((s0 + s1) & 3);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 3);
									if (abilitys[val] != -1 && abilitys[val] != tmp) break;
								}
								else
								{
									tmp = (int)((s0 + s1) & 1);
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
									if (abilitys[val] != -1 && abilitys[val] != tmp) break;
								}

								if (!noGender[val])
								{
									do
									{
										tmp = (int)((s0 + s1) & 255);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 253);
								}

								tmp = 0;
								if (species[val] == ToxtricityID)
								{
									if (alt[val] == 0)
									{
										do
										{
											tmp = (int)((s0 + s1) & 15);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 13);
										tmp = ToxtricityAmplifiedNatures[tmp];
									}
									else
									{
										do
										{
											tmp = (int)((s0 + s1) & 15);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 12);
										tmp = ToxtricityLowKeyNatures[tmp];
									}
								}
								else
								{
									do
									{
										tmp = (int)((s0 + s1) & 31);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 25);
								}
								if (tmp != natures[val])
								{
									break;
								}
							}
							if (val == 0)
							{
								entry[0] = seed;
							}
							val--;
							continue;
						end:
							break;
						}
					}
				});
				gpu.Synchronize();
				if (entry[0] != 0)
				{
					return entry[0];
				}
			}
			return 0;
		}

		[GpuManaged]
		public ulong SearchSix(Device device, int start, int end, System.Windows.Forms.ToolStripStatusLabel updateLbl) {
			var gpu = Gpu.Get(device.Id);
			const int searchLower = 0;
			const int searchUpper = 0x40000000 ;
			const int length = 60;
			const int numElems = 1 << (64 - length);
			ulong iv0 = (ulong)g_Ivs[0];
			ulong iv1 = (ulong)g_Ivs[1];
			ulong iv2 = (ulong)g_Ivs[2];
			ulong iv3 = (ulong)g_Ivs[3];
			ulong iv4 = (ulong)g_Ivs[4];
			ulong iv5 = (ulong)g_Ivs[5];

			int[] allIVs = { pkmn1.ivs0, pkmn1.ivs1, pkmn1.ivs2, pkmn1.ivs3, pkmn1.ivs4, pkmn1.ivs5, pkmn2.ivs0, pkmn2.ivs1, pkmn2.ivs2, pkmn2.ivs3, pkmn2.ivs4, pkmn2.ivs5,
							 pkmn3.ivs0, pkmn3.ivs1, pkmn3.ivs2, pkmn3.ivs3, pkmn3.ivs4, pkmn3.ivs5, pkmn4.ivs0, pkmn4.ivs1, pkmn4.ivs2, pkmn4.ivs3, pkmn4.ivs4, pkmn4.ivs5,};
			int[] fixedIVs = { pkmn1.fixedIV, pkmn2.fixedIV, pkmn3.fixedIV, pkmn4.fixedIV };
			int[] abilitys = { pkmn1.ability, pkmn2.ability, pkmn3.ability, pkmn4.ability };
			bool[] noGender = { pkmn1.isNoGender, pkmn2.isNoGender, pkmn3.isNoGender, pkmn4.isNoGender };
			bool[] HA = { pkmn1.isEnableDream, pkmn2.isEnableDream, pkmn3.isEnableDream, pkmn4.isEnableDream };
			int[] natures = { pkmn1.nature, pkmn2.nature, pkmn3.nature, pkmn4.nature };
			int characteristic1 = pkmn1.characteristic;
			int g_lsb = LSB;
			int[] species = { pkmn1.ID, pkmn2.ID, pkmn3.ID, pkmn4.ID };
			int[] alt = { pkmn1.altForm, pkmn2.altForm, pkmn3.altForm, pkmn4.altForm };

			ulong[] entry = { 0 };
			for (int ivOffset=start; ivOffset <= end; ivOffset++)
			{
				updateLbl.Text = ivOffset.ToString();
				ulong g_ConstantTermVector = 0;
				MatrixStruct.InitializeTransformationMatrix();
				for (int i = 0; i <= 1 + pkmn1.fixedIV + ivOffset; ++i)
				{
					MatrixStruct.ProceedTransformationMatrix();
				}

				for (int a = 0; a < g_setIVs; ++a)
				{
					for (int i = 0; i < 10; ++i)
					{
						int index = 59 + (i / 5) * 64 + (i % 5);
						int bit = a * 10 + i;
						MatrixStruct.g_InputMatrix[bit] = MatrixStruct.GetMatrixMultiplier(index);
						if (MatrixStruct.GetMatrixConst(index) != 0)
						{
							g_ConstantTermVector |= (1ul << (length - 1 - bit));
						}
					}
					MatrixStruct.ProceedTransformationMatrix();
				}
				MatrixStruct.CalculateInverseMatrix(length);
				MatrixStruct.CalculateCoefficientData(length);

				bool[] g_FreeBit = new bool[64];
				ulong[] g_AnswerFlag = new ulong[64];
				ulong[] g_CoefficientData = new ulong[numElems];
				ulong[] g_SearchPattern = new ulong[numElems];
				Array.Copy(MatrixStruct.g_CoefficientData, 0, g_CoefficientData, 0, numElems);
				Array.Copy(MatrixStruct.g_SearchPattern, 0, g_SearchPattern, 0, numElems);
				Array.Copy(MatrixStruct.g_AnswerFlag, 0, g_AnswerFlag, 0, 64);
				for (int num = 0; num < g_FreeBit.Length; num++)
				{
					g_FreeBit[num] = MatrixStruct.g_FreeBit[num] > 0;
				}

				ulong[] add_const = {0, 0, 0x82a2b175229d6a5bul, 0x54562ea453ad4b6ul };
				gpu.LongFor(searchLower, searchUpper, input => {
					ulong target = 0;
					ulong input_ivs = (ulong)input;
					target |= (input_ivs & 0x3E000000ul) << 30; // iv0_0
					target |= (input_ivs & 0x1F00000ul) << 25; // iv1_0
					target |= (input_ivs & 0xF8000ul) << 20; // iv2_0
					target |= (input_ivs & 0x7C00ul) << 15; // iv3_0
					target |= (input_ivs & 0x3E0ul) << 10; // iv4_0
					target |= (input_ivs & 0x1Ful) << 5; // iv5_0

					target |= ((32ul + iv0 - ((input_ivs & 0x3E000000ul) >> 25)) & 0x1F) << 50;
					target |= ((32ul + iv1 - ((input_ivs & 0x1F00000ul) >> 20)) & 0x1F) << 40;
					target |= ((32ul + iv2 - ((input_ivs & 0xF8000ul) >> 15)) & 0x1F) << 30;
					target |= ((32ul + iv3 - ((input_ivs & 0x7C00ul) >> 10)) & 0x1F) << 20;
					target |= ((32ul + iv4 - ((input_ivs & 0x3E0ul) >> 5)) & 0x1F) << 10;
					target |= ((32ul + iv5 - (input_ivs & 0x1Ful)) & 0x1F);

					target ^= g_ConstantTermVector;

					ulong processedTarget = 0;
					int offset = 0;
					for (int i = 0; i < length; ++i)
					{
						while (g_FreeBit[i + offset])
						{
							++offset;
						}
						processedTarget |= MatrixStruct.GetSignature(g_AnswerFlag[i] & target) << (63 - (i + offset));
					}

					ulong s0;
					ulong s1;
					ulong s0tmp;
					ulong s1tmp;
					uint ec;
					uint skip;
					int ivs;
					int g_FixedIvs;
					int fixedIndex;
					int tmp;
					ulong seed = 0;
					for (int search = 0; search < numElems; ++search)
					{
						seed = (processedTarget ^ g_CoefficientData[search]) | g_SearchPattern[search];

						s0 = seed;
						s1 = 0x82a2b175229d6a5b;
						// EC
						do
						{
							ec = (uint)(s0 + s1);
							s1 = s0 ^ s1;
							s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
							s1 = RotateLeft(s1, 37);
						} while (ec == 0xFFFFFFFF);

						if (g_lsb >= 0 && (ec & 1) != g_lsb)
						{
							continue;
						}

						if (characteristic1 >= 0)
						{
							int characteristic = (int)(ec % 6);
							if (characteristic != characteristic1)
							{
								continue;
							}
						}


						int val = 3;
						while(val >= 0)
						{
							s0 = seed + add_const[val];
							s1 = 0x82a2b175229d6a5b;
							// EC
							do
							{
								ec = (uint)(s0 + s1);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (ec == 0xFFFFFFFF);

							// SIDTID
							do
							{
								skip = (uint)(s0 + s1);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (skip == 0xFFFFFFFF);

							// TID
							do
							{
								skip = (uint)(s0 + s1);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (skip == 0xFFFFFFFF);

							ivs = 0;
							g_FixedIvs = fixedIVs[val];
							fixedIndex = 0;
							while (g_FixedIvs > 0)
							{
								do
								{
									fixedIndex = (int)((s0 + s1) & 7);
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
								} while (fixedIndex >= 6 || ((1 << fixedIndex) & ivs) != 0);
								ivs |= 1 << fixedIndex;
								if(allIVs[val * 6 + fixedIndex] != 31)
								{
									goto end;
								}
								g_FixedIvs--;
							}

							for (int i = 0; i < 6; ++i)
							{
								if (((1 << i) & ivs) == 0)
								{
									if(allIVs[val * 6 + i] != (int)((s0 + s1) & 31)) {
										goto end;
									}
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
								}
							}
							tmp = 0;
							// special case
							if (abilitys[val] == -2)
							{
								s0tmp = s0;
								s1tmp = s1;
								if (HA[val])
								{
									do
									{
										tmp = (int)((s0 + s1) & 3);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 3);
								}
								else
								{
									tmp = (int)((s0 + s1) & 1);
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
								}
								if (!noGender[val])
								{
									do
									{
										tmp = (int)((s0 + s1) & 255);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 253);
								}
								tmp = 0;
								if (species[val] == ToxtricityID)
								{
									if (alt[val] == 0)
									{
										do
										{
											tmp = (int)((s0 + s1) & 15);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 13);
										tmp = ToxtricityAmplifiedNatures[tmp];
									}
									else
									{
										do
										{
											tmp = (int)((s0 + s1) & 15);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 12);
										tmp = ToxtricityLowKeyNatures[tmp];
									}
								}
								else
								{
									do
									{
										tmp = (int)((s0 + s1) & 31);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 25);
								}
								if (tmp != natures[val])
								{
									s0 = s0tmp;
									s1 = s1tmp;
									if (!noGender[val])
									{
										do
										{
											tmp = (int)((s0 + s1) & 255);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 253);
									}
									tmp = 0;
									if (species[val] == ToxtricityID)
									{
										if (alt[val] == 0)
										{
											do
											{
												tmp = (int)((s0 + s1) & 15);
												s1 = s0 ^ s1;
												s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
												s1 = RotateLeft(s1, 37);
											} while (tmp >= 13);
											tmp = ToxtricityAmplifiedNatures[tmp];
										}
										else
										{
											do
											{
												tmp = (int)((s0 + s1) & 15);
												s1 = s0 ^ s1;
												s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
												s1 = RotateLeft(s1, 37);
											} while (tmp >= 12);
											tmp = ToxtricityLowKeyNatures[tmp];
										}
									}
									else
									{
										do
										{
											tmp = (int)((s0 + s1) & 31);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 25);
									}
									if (tmp != natures[val])
									{
										break;
									}
								}

							}
							else
							{
								if (HA[val])
								{
									do
									{
										tmp = (int)((s0 + s1) & 3);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 3);
									if (abilitys[val] != -1 && abilitys[val] != tmp) break;
								}
								else
								{
									tmp = (int)((s0 + s1) & 1);
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
									if (abilitys[val] != -1 && abilitys[val] != tmp) break;
								}

								if (!noGender[val])
								{
									do
									{
										tmp = (int)((s0 + s1) & 255);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 253);
								}

								tmp = 0;
								if (species[val] == ToxtricityID)
								{
									if (alt[val] == 0)
									{
										do
										{
											tmp = (int)((s0 + s1) & 15);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 13);
										tmp = ToxtricityAmplifiedNatures[tmp];
									}
									else
									{
										do
										{
											tmp = (int)((s0 + s1) & 15);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 12);
										tmp = ToxtricityLowKeyNatures[tmp];
									}
								}
								else
								{
									do
									{
										tmp = (int)((s0 + s1) & 31);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 25);
								}
								if (tmp != natures[val])
								{
									break;
								}
							}
							if (val == 0)
							{
								entry[0] = seed;
							}
							val--;
							continue;
						end:
							break;
						}
					}
				});
				gpu.Synchronize();
				if(entry[0] != 0)
				{
					return entry[0];
				}
			}
			return 0;
		}

		[GpuManaged]
		public ulong SearchFive(Device device, int start, int end, System.Windows.Forms.ToolStripStatusLabel updateLbl)
		{
			const int length = 50;
			const int numElems = 1 << (64 - length);
			var gpu = Gpu.Get(device.Id);
			const int searchLower = 0;
			const int searchUpper = 0x2000000;

			ulong iv0 = (ulong)g_Ivs[0];
			ulong iv1 = (ulong)g_Ivs[1];
			ulong iv2 = (ulong)g_Ivs[2];
			ulong iv3 = (ulong)g_Ivs[3];
			ulong iv4 = (ulong)g_Ivs[4];

			int[] allIVs = { pkmn1.ivs0, pkmn1.ivs1, pkmn1.ivs2, pkmn1.ivs3, pkmn1.ivs4, pkmn1.ivs5, pkmn2.ivs0, pkmn2.ivs1, pkmn2.ivs2, pkmn2.ivs3, pkmn2.ivs4, pkmn2.ivs5,
							 pkmn3.ivs0, pkmn3.ivs1, pkmn3.ivs2, pkmn3.ivs3, pkmn3.ivs4, pkmn3.ivs5, pkmn4.ivs0, pkmn4.ivs1, pkmn4.ivs2, pkmn4.ivs3, pkmn4.ivs4, pkmn4.ivs5,};
			int[] fixedIVs = { pkmn1.fixedIV, pkmn2.fixedIV, pkmn3.fixedIV, pkmn4.fixedIV };
			int[] abilitys = { pkmn1.ability, pkmn2.ability, pkmn3.ability, pkmn4.ability };
			bool[] noGender = { pkmn1.isNoGender, pkmn2.isNoGender, pkmn3.isNoGender, pkmn4.isNoGender };
			bool[] HA = { pkmn1.isEnableDream, pkmn2.isEnableDream, pkmn3.isEnableDream, pkmn4.isEnableDream };
			int[] natures = { pkmn1.nature, pkmn2.nature, pkmn3.nature, pkmn4.nature };
			int characteristic1 = pkmn1.characteristic;
			int g_lsb = LSB;
			int[] species = { pkmn1.ID, pkmn2.ID, pkmn3.ID, pkmn4.ID };
			int[] alt = { pkmn1.altForm, pkmn2.altForm, pkmn3.altForm, pkmn4.altForm };

			ulong[] entry = { 0 };
			for (int ivOffset = start; ivOffset <= end; ivOffset++)
			{
				updateLbl.Text = ivOffset.ToString();
				ulong g_ConstantTermVector = 0;
				MatrixStruct.InitializeTransformationMatrix();
				for (int i = 0; i <= 1 + pkmn1.fixedIV + ivOffset; ++i)
				{
					MatrixStruct.ProceedTransformationMatrix();
				}

				for (int a = 0; a < g_setIVs; ++a)
				{
					for (int i = 0; i < 10; ++i)
					{
						int index = 59 + (i / 5) * 64 + (i % 5);
						int bit = a * 10 + i;
						MatrixStruct.g_InputMatrix[bit] = MatrixStruct.GetMatrixMultiplier(index);
						if (MatrixStruct.GetMatrixConst(index) != 0)
						{
							g_ConstantTermVector |= (1ul << (length - 1 - bit));
						}
					}
					MatrixStruct.ProceedTransformationMatrix();
				}
				MatrixStruct.CalculateInverseMatrix(length);
				MatrixStruct.CalculateCoefficientData(length);

				bool[] g_FreeBit = new bool[64];
				ulong[] g_AnswerFlag = new ulong[64];
				ulong[] g_CoefficientData = new ulong[numElems];
				ulong[] g_SearchPattern = new ulong[numElems];
				Array.Copy(MatrixStruct.g_CoefficientData, 0, g_CoefficientData, 0, numElems);
				Array.Copy(MatrixStruct.g_SearchPattern, 0, g_SearchPattern, 0, numElems);
				Array.Copy(MatrixStruct.g_AnswerFlag, 0, g_AnswerFlag, 0, 64);
				for (int num = 0; num < g_FreeBit.Length; num++)
				{
					g_FreeBit[num] = MatrixStruct.g_FreeBit[num] > 0;
				}

				ulong[] add_const = { 0, 0, 0x82a2b175229d6a5bul, 0x54562ea453ad4b6ul };
				gpu.LongFor(searchLower, searchUpper, input => {
					ulong target = 0;
					ulong input_ivs = (ulong)input;
					target |= (input_ivs & 0x1F00000ul) << 25;
					target |= (input_ivs & 0xF8000ul) << 20; 
					target |= (input_ivs & 0x7C00ul) << 15; 
					target |= (input_ivs & 0x3E0ul) << 10; 
					target |= (input_ivs & 0x1Ful) << 5; 

					target |= ((32ul + iv0 - ((input_ivs & 0x1F00000ul) >> 20)) & 0x1F) << 40;
					target |= ((32ul + iv1 - ((input_ivs & 0xF8000ul) >> 15)) & 0x1F) << 30;
					target |= ((32ul + iv2 - ((input_ivs & 0x7C00ul) >> 10)) & 0x1F) << 20;
					target |= ((32ul + iv3 - ((input_ivs & 0x3E0ul) >> 5)) & 0x1F) << 10;
					target |= ((32ul + iv4 - (input_ivs & 0x1Ful)) & 0x1F);

					target ^= g_ConstantTermVector;

					ulong processedTarget = 0;
					int offset = 0;
					for (int i = 0; i < length; ++i)
					{
						while (g_FreeBit[i + offset])
						{
							++offset;
						}
						processedTarget |= MatrixStruct.GetSignature(g_AnswerFlag[i] & target) << (63 - (i + offset));
					}

					ulong s0;
					ulong s1;
					ulong s0tmp;
					ulong s1tmp;
					uint ec;
					uint skip;
					int ivs;
					int g_FixedIvs;
					int fixedIndex;
					int tmp;
					ulong seed = 0;
					for (int search = 0; search < numElems; ++search)
					{
						seed = (processedTarget ^ g_CoefficientData[search]) | g_SearchPattern[search];

						s0 = seed;
						s1 = 0x82a2b175229d6a5b;
						// EC
						do
						{
							ec = (uint)(s0 + s1);
							s1 = s0 ^ s1;
							s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
							s1 = RotateLeft(s1, 37);
						} while (ec == 0xFFFFFFFF);

						if (g_lsb >= 0 && (ec & 1) != g_lsb)
						{
							continue;
						}

						if (characteristic1 >= 0)
						{
							int characteristic = (int)(ec % 6);
							if (characteristic != characteristic1)
							{
								continue;
							}
						}

						int val = 3;
						while (val >= 0)
						{
							s0 = seed + add_const[val];
							s1 = 0x82a2b175229d6a5b;
							// EC
							do
							{
								ec = (uint)(s0 + s1);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (ec == 0xFFFFFFFF);

							// SIDTID
							do
							{
								skip = (uint)(s0 + s1);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (skip == 0xFFFFFFFF);

							// TID
							do
							{
								skip = (uint)(s0 + s1);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (skip == 0xFFFFFFFF);

							ivs = 0;
							g_FixedIvs = fixedIVs[val];
							fixedIndex = 0;
							while (g_FixedIvs > 0)
							{
								do
								{
									fixedIndex = (int)((s0 + s1) & 7);
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
								} while (fixedIndex >= 6 || ((1 << fixedIndex) & ivs) != 0);
								ivs |= 1 << fixedIndex;
								if (allIVs[val * 6 + fixedIndex] != 31)
								{
									goto end;
								}
								g_FixedIvs--;
							}

							for (int i = 0; i < 6; ++i)
							{
								if (((1 << i) & ivs) == 0)
								{
									if (allIVs[val * 6 + i] != (int)((s0 + s1) & 31))
									{
										goto end;
									}
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
								}
							}
							tmp = 0;
							// special case
							if (abilitys[val] == -2)
							{
								s0tmp = s0;
								s1tmp = s1;
								if (HA[val])
								{
									do
									{
										tmp = (int)((s0 + s1) & 3);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 3);
								}
								else
								{
									tmp = (int)((s0 + s1) & 1);
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
								}
								if (!noGender[val])
								{
									do
									{
										tmp = (int)((s0 + s1) & 255);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 253);
								}
								tmp = 0;
								if (species[val] == ToxtricityID)
								{
									if (alt[val] == 0)
									{
										do
										{
											tmp = (int)((s0 + s1) & 15);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 13);
										tmp = ToxtricityAmplifiedNatures[tmp];
									}
									else
									{
										do
										{
											tmp = (int)((s0 + s1) & 15);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 12);
										tmp = ToxtricityLowKeyNatures[tmp];
									}
								}
								else
								{
									do
									{
										tmp = (int)((s0 + s1) & 31);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 25);
								}
								if (tmp != natures[val])
								{
									s0 = s0tmp;
									s1 = s1tmp;
									if (!noGender[val])
									{
										do
										{
											tmp = (int)((s0 + s1) & 255);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 253);
									}
									tmp = 0;
									if (species[val] == ToxtricityID)
									{
										if (alt[val] == 0)
										{
											do
											{
												tmp = (int)((s0 + s1) & 15);
												s1 = s0 ^ s1;
												s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
												s1 = RotateLeft(s1, 37);
											} while (tmp >= 13);
											tmp = ToxtricityAmplifiedNatures[tmp];
										}
										else
										{
											do
											{
												tmp = (int)((s0 + s1) & 15);
												s1 = s0 ^ s1;
												s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
												s1 = RotateLeft(s1, 37);
											} while (tmp >= 12);
											tmp = ToxtricityLowKeyNatures[tmp];
										}
									}
									else
									{
										do
										{
											tmp = (int)((s0 + s1) & 31);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 25);
									}
									if (tmp != natures[val])
									{
										break;
									}
								}

							}
							else
							{
								if (HA[val])
								{
									do
									{
										tmp = (int)((s0 + s1) & 3);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 3);
									if (abilitys[val] != -1 && abilitys[val] != tmp) break;
								}
								else
								{
									tmp = (int)((s0 + s1) & 1);
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
									if (abilitys[val] != -1 && abilitys[val] != tmp) break;
								}

								if (!noGender[val])
								{
									do
									{
										tmp = (int)((s0 + s1) & 255);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 253);
								}

								tmp = 0;
								if (species[val] == ToxtricityID)
								{
									if (alt[val] == 0)
									{
										do
										{
											tmp = (int)((s0 + s1) & 15);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 13);
										tmp = ToxtricityAmplifiedNatures[tmp];
									}
									else
									{
										do
										{
											tmp = (int)((s0 + s1) & 15);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 12);
										tmp = ToxtricityLowKeyNatures[tmp];
									}
								}
								else
								{
									do
									{
										tmp = (int)((s0 + s1) & 31);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 25);
								}
								if (tmp != natures[val])
								{
									break;
								}
							}
							if (val == 0)
							{
								entry[0] = seed;
							}
							val--;
							continue;
						end:
							break;
						}
					}
				});
				gpu.Synchronize();
				if (entry[0] != 0)
				{
					return entry[0];
				}
			}
			return 0;
		}

		[GpuManaged]
		public ulong SearchFour(Device device, int start, int end, System.Windows.Forms.ToolStripStatusLabel updateLbl)
		{
			const int length = 40;
			const int numElems = 1 << (64 - length);
			var gpu = Gpu.Get(device.Id);
			const int searchLower = 0;
			const int searchUpper = 0x100000;

			ulong iv0 = (ulong)g_Ivs[0];
			ulong iv1 = (ulong)g_Ivs[1];
			ulong iv2 = (ulong)g_Ivs[2];
			ulong iv3 = (ulong)g_Ivs[3];

			int[] allIVs = { pkmn1.ivs0, pkmn1.ivs1, pkmn1.ivs2, pkmn1.ivs3, pkmn1.ivs4, pkmn1.ivs5, pkmn2.ivs0, pkmn2.ivs1, pkmn2.ivs2, pkmn2.ivs3, pkmn2.ivs4, pkmn2.ivs5,
							 pkmn3.ivs0, pkmn3.ivs1, pkmn3.ivs2, pkmn3.ivs3, pkmn3.ivs4, pkmn3.ivs5, pkmn4.ivs0, pkmn4.ivs1, pkmn4.ivs2, pkmn4.ivs3, pkmn4.ivs4, pkmn4.ivs5,};
			int[] fixedIVs = { pkmn1.fixedIV, pkmn2.fixedIV, pkmn3.fixedIV, pkmn4.fixedIV };
			int[] abilitys = { pkmn1.ability, pkmn2.ability, pkmn3.ability, pkmn4.ability };
			bool[] noGender = { pkmn1.isNoGender, pkmn2.isNoGender, pkmn3.isNoGender, pkmn4.isNoGender };
			bool[] HA = { pkmn1.isEnableDream, pkmn2.isEnableDream, pkmn3.isEnableDream, pkmn4.isEnableDream };
			int[] natures = { pkmn1.nature, pkmn2.nature, pkmn3.nature, pkmn4.nature };
			int characteristic1 = pkmn1.characteristic;
			int g_lsb = LSB;
			int[] species = { pkmn1.ID, pkmn2.ID, pkmn3.ID, pkmn4.ID };
			int[] alt = { pkmn1.altForm, pkmn2.altForm, pkmn3.altForm, pkmn4.altForm };

			ulong[] entry = { 0 };
			for (int ivOffset = start; ivOffset <= end; ivOffset++)
			{
				updateLbl.Text = ivOffset.ToString();
				ulong g_ConstantTermVector = 0;
				MatrixStruct.InitializeTransformationMatrix();
				for (int i = 0; i <= 1 + pkmn1.fixedIV + ivOffset; ++i)
				{
					MatrixStruct.ProceedTransformationMatrix();
				}

				for (int a = 0; a < g_setIVs; ++a)
				{
					for (int i = 0; i < 10; ++i)
					{
						int index = 59 + (i / 5) * 64 + (i % 5);
						int bit = a * 10 + i;
						MatrixStruct.g_InputMatrix[bit] = MatrixStruct.GetMatrixMultiplier(index);
						if (MatrixStruct.GetMatrixConst(index) != 0)
						{
							g_ConstantTermVector |= (1ul << (length - 1 - bit));
						}
					}
					MatrixStruct.ProceedTransformationMatrix();
				}
				MatrixStruct.CalculateInverseMatrix(length);
				MatrixStruct.CalculateCoefficientData(length);

				bool[] g_FreeBit = new bool[64];
				ulong[] g_AnswerFlag = new ulong[64];
				ulong[] g_CoefficientData = new ulong[numElems];
				ulong[] g_SearchPattern = new ulong[numElems];
				Array.Copy(MatrixStruct.g_CoefficientData, 0, g_CoefficientData, 0, numElems);
				Array.Copy(MatrixStruct.g_SearchPattern, 0, g_SearchPattern, 0, numElems);
				Array.Copy(MatrixStruct.g_AnswerFlag, 0, g_AnswerFlag, 0, 64);
				for (int num = 0; num < g_FreeBit.Length; num++)
				{
					g_FreeBit[num] = MatrixStruct.g_FreeBit[num] > 0;
				}

				ulong[] add_const = { 0, 0, 0x82a2b175229d6a5bul, 0x54562ea453ad4b6ul };
				gpu.LongFor(searchLower, searchUpper, input => {
					ulong target = 0;
					ulong input_ivs = (ulong)input;
					target |= (input_ivs & 0xF8000ul) << 20;
					target |= (input_ivs & 0x7C00ul) << 15;
					target |= (input_ivs & 0x3E0ul) << 10;
					target |= (input_ivs & 0x1Ful) << 5;

					target |= ((32ul + iv0 - ((input_ivs & 0xF8000ul) >> 15)) & 0x1F) << 30;
					target |= ((32ul + iv1 - ((input_ivs & 0x7C00ul) >> 10)) & 0x1F) << 20;
					target |= ((32ul + iv2 - ((input_ivs & 0x3E0ul) >> 5)) & 0x1F) << 10;
					target |= ((32ul + iv3 - (input_ivs & 0x1Ful)) & 0x1F);

					target ^= g_ConstantTermVector;

					ulong processedTarget = 0;
					int offset = 0;
					for (int i = 0; i < length; ++i)
					{
						while (g_FreeBit[i + offset])
						{
							++offset;
						}
						processedTarget |= MatrixStruct.GetSignature(g_AnswerFlag[i] & target) << (63 - (i + offset));
					}

					ulong s0;
					ulong s1;
					ulong s0tmp;
					ulong s1tmp;
					uint ec;
					uint skip;
					int ivs;
					int g_FixedIvs;
					int fixedIndex;
					int tmp;
					ulong seed = 0;
					for (int search = 0; search < numElems; ++search)
					{
						seed = (processedTarget ^ g_CoefficientData[search]) | g_SearchPattern[search];

						s0 = seed;
						s1 = 0x82a2b175229d6a5b;
						// EC
						do
						{
							ec = (uint)(s0 + s1);
							s1 = s0 ^ s1;
							s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
							s1 = RotateLeft(s1, 37);
						} while (ec == 0xFFFFFFFF);

						if (g_lsb >= 0 && (ec & 1) != g_lsb)
						{
							continue;
						}

						if (characteristic1 >= 0)
						{
							int characteristic = (int)(ec % 6);
							if (characteristic != characteristic1)
							{
								continue;
							}
						}


						int val = 3;
						while (val >= 0)
						{
							s0 = seed + add_const[val];
							s1 = 0x82a2b175229d6a5b;
							// EC
							do
							{
								ec = (uint)(s0 + s1);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (ec == 0xFFFFFFFF);

							// SIDTID
							do
							{
								skip = (uint)(s0 + s1);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (skip == 0xFFFFFFFF);

							// TID
							do
							{
								skip = (uint)(s0 + s1);
								s1 = s0 ^ s1;
								s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
								s1 = RotateLeft(s1, 37);
							} while (skip == 0xFFFFFFFF);

							ivs = 0;
							g_FixedIvs = fixedIVs[val];
							fixedIndex = 0;
							while (g_FixedIvs > 0)
							{
								do
								{
									fixedIndex = (int)((s0 + s1) & 7);
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
								} while (fixedIndex >= 6 || ((1 << fixedIndex) & ivs) != 0);
								ivs |= 1 << fixedIndex;
								if (allIVs[val * 6 + fixedIndex] != 31)
								{
									goto end;
								}
								g_FixedIvs--;
							}

							for (int i = 0; i < 6; ++i)
							{
								if (((1 << i) & ivs) == 0)
								{
									if (allIVs[val * 6 + i] != (int)((s0 + s1) & 31))
									{
										goto end;
									}
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
								}
							}
							tmp = 0;
							// special case
							if (abilitys[val] == -2)
							{
								s0tmp = s0;
								s1tmp = s1;
								if (HA[val])
								{
									do
									{
										tmp = (int)((s0 + s1) & 3);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 3);
								}
								else
								{
									tmp = (int)((s0 + s1) & 1);
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
								}
								if (!noGender[val])
								{
									do
									{
										tmp = (int)((s0 + s1) & 255);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 253);
								}
								tmp = 0;
								if (species[val] == ToxtricityID)
								{
									if (alt[val] == 0)
									{
										do
										{
											tmp = (int)((s0 + s1) & 15);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 13);
										tmp = ToxtricityAmplifiedNatures[tmp];
									}
									else
									{
										do
										{
											tmp = (int)((s0 + s1) & 15);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 12);
										tmp = ToxtricityLowKeyNatures[tmp];
									}
								}
								else
								{
									do
									{
										tmp = (int)((s0 + s1) & 31);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 25);
								}
								if (tmp != natures[val])
								{
									s0 = s0tmp;
									s1 = s1tmp;
									if (!noGender[val])
									{
										do
										{
											tmp = (int)((s0 + s1) & 255);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 253);
									}
									tmp = 0;
									if (species[val] == ToxtricityID)
									{
										if (alt[val] == 0)
										{
											do
											{
												tmp = (int)((s0 + s1) & 15);
												s1 = s0 ^ s1;
												s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
												s1 = RotateLeft(s1, 37);
											} while (tmp >= 13);
											tmp = ToxtricityAmplifiedNatures[tmp];
										}
										else
										{
											do
											{
												tmp = (int)((s0 + s1) & 15);
												s1 = s0 ^ s1;
												s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
												s1 = RotateLeft(s1, 37);
											} while (tmp >= 12);
											tmp = ToxtricityLowKeyNatures[tmp];
										}
									}
									else
									{
										do
										{
											tmp = (int)((s0 + s1) & 31);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 25);
									}
									if (tmp != natures[val])
									{
										break;
									}
								}

							}
							else
							{
								if (HA[val])
								{
									do
									{
										tmp = (int)((s0 + s1) & 3);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 3);
									if (abilitys[val] != -1 && abilitys[val] != tmp) break;
								}
								else
								{
									tmp = (int)((s0 + s1) & 1);
									s1 = s0 ^ s1;
									s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
									s1 = RotateLeft(s1, 37);
									if (abilitys[val] != -1 && abilitys[val] != tmp) break;
								}

								if (!noGender[val])
								{
									do
									{
										tmp = (int)((s0 + s1) & 255);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 253);
								}

								tmp = 0;
								if (species[val] == ToxtricityID)
								{
									if (alt[val] == 0)
									{
										do
										{
											tmp = (int)((s0 + s1) & 15);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 13);
										tmp = ToxtricityAmplifiedNatures[tmp];
									}
									else
									{
										do
										{
											tmp = (int)((s0 + s1) & 15);
											s1 = s0 ^ s1;
											s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
											s1 = RotateLeft(s1, 37);
										} while (tmp >= 12);
										tmp = ToxtricityLowKeyNatures[tmp];
									}
								}
								else
								{
									do
									{
										tmp = (int)((s0 + s1) & 31);
										s1 = s0 ^ s1;
										s0 = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
										s1 = RotateLeft(s1, 37);
									} while (tmp >= 25);
								}
								if (tmp != natures[val])
								{
									break;
								}
							}
							if (val == 0)
							{
								entry[0] = seed;
							}
							val--;
							continue;
						end:
							break;
						}
					}
				});
				gpu.Synchronize();
				if (entry[0] != 0)
				{
					return entry[0];
				}
			}
			return 0;
		}

		private class MatrixStruct
		{
			public const ulong c_XoroshiroConst = 0x82a2b175229d6a5bul;

			public static readonly ulong[] c_N = {
				0x4000000ul,
				0x4000000ul,
				0x2000000ul,
				0x2000000ul,
				0x1000000ul,
				0x1000000ul,
				0x800000ul,
				0x800000ul,
				0x400000ul,
				0x400000ul,
				0x200000ul,
				0x200000ul,
				0x100000ul,
				0x100000ul,
				0x80000ul,
				0x80000ul,
				0x40000ul,
				0x40000ul,
				0x20000ul,
				0x20000ul,
				0x10000ul,
				0x10000ul,
				0x8000ul,
				0x8000ul,
				0x4000ul,
				0x4000ul,
				0x2000ul,
				0x2000ul,
				0x1000ul,
				0x1000ul,
				0x800ul,
				0x800ul,
				0x400ul,
				0x400ul,
				0x200ul,
				0x200ul,
				0x100ul,
				0x100ul,
				0x80ul,
				0x80ul,
				0x40ul,
				0x40ul,
				0x20ul,
				0x20ul,
				0x10ul,
				0x10ul,
				0x8ul,
				0x8ul,
				0x4ul,
				0x4ul,
				0x2ul,
				0x2ul,
				0x1ul,
				0x1ul,
				0x8000000000000000ul,
				0x8000000000000000ul,
				0x4000000000000000ul,
				0x4000000000000000ul,
				0x2000000000000000ul,
				0x2000000000000000ul,
				0x1000000000000000ul,
				0x1000000000000000ul,
				0x800000000000000ul,
				0x800000000000000ul,
				0x400000000000000ul,
				0x400000000000000ul,
				0x200000000000000ul,
				0x200000000000000ul,
				0x100000000000000ul,
				0x100000000000000ul,
				0x80000000000000ul,
				0x80000000000000ul,
				0x40000000000000ul,
				0x40000000000000ul,
				0x20000000000000ul,
				0x20000000000000ul,
				0x10000000000000ul,
				0x10000000000000ul,
				0x8000000000000ul,
				0x8000000000000ul,
				0x4000000000000ul,
				0x4000000000000ul,
				0x2000000000000ul,
				0x2000000000000ul,
				0x1000000000000ul,
				0x1000000000000ul,
				0x800000000000ul,
				0x800000000000ul,
				0x400000000000ul,
				0x400000000000ul,
				0x200000000000ul,
				0x200000000000ul,
				0x100000000000ul,
				0x100000000000ul,
				0x80000000000ul,
				0x80000000000ul,
				0x40000000000ul,
				0x40000000000ul,
				0x20000000000ul,
				0x20000000000ul,
				0x10000000000ul,
				0x10000000000ul,
				0x8000000000ul,
				0x8000000000ul,
				0x4000000000ul,
				0x4000000000ul,
				0x2000000000ul,
				0x2000000000ul,
				0x1000000000ul,
				0x1000000000ul,
				0x800000000ul,
				0x800000000ul,
				0x400000000ul,
				0x400000000ul,
				0x200000000ul,
				0x200000000ul,
				0x100000000ul,
				0x100000000ul,
				0x80000000ul,
				0x80000000ul,
				0x40000000ul,
				0x40000000ul,
				0x20000000ul,
				0x20000000ul,
				0x10000000ul,
				0x10000000ul,
				0x8000000ul,
				0x8000000ul,
				0x8000800000000000ul,
				0x8000808000000000ul,
				0x4000400000000000ul,
				0x4000404000000000ul,
				0x2000200000000000ul,
				0x2000202000000000ul,
				0x1000100000000000ul,
				0x1000101000000000ul,
				0x800080000000000ul,
				0x800080800000000ul,
				0x400040000000000ul,
				0x400040400000000ul,
				0x200020000000000ul,
				0x200020200000000ul,
				0x100010000000000ul,
				0x100010100000000ul,
				0x80008000000000ul,
				0x80008080000000ul,
				0x40004000000000ul,
				0x40004040000000ul,
				0x20002000000000ul,
				0x20002020000000ul,
				0x10001000000000ul,
				0x10001010000000ul,
				0x8000800000000ul,
				0x8000808000000ul,
				0x4000400000000ul,
				0x4000404000000ul,
				0x2000200000000ul,
				0x2000202000000ul,
				0x1000100000000ul,
				0x1000101000000ul,
				0x800080000000ul,
				0x800080800000ul,
				0x400040000000ul,
				0x400040400000ul,
				0x200020000000ul,
				0x200020200000ul,
				0x100010000000ul,
				0x100010100000ul,
				0x80008000000ul,
				0x80008080000ul,
				0x40004000000ul,
				0x40004040000ul,
				0x20002000000ul,
				0x20002020000ul,
				0x10001000000ul,
				0x10001010000ul,
				0x8000800000ul,
				0x8000808000ul,
				0x4000400000ul,
				0x4000404000ul,
				0x2000200000ul,
				0x2000202000ul,
				0x1000100000ul,
				0x1000101000ul,
				0x800080000ul,
				0x800080800ul,
				0x400040000ul,
				0x400040400ul,
				0x200020000ul,
				0x200020200ul,
				0x100010000ul,
				0x100010100ul,
				0x80008000ul,
				0x80008080ul,
				0x40004000ul,
				0x40004040ul,
				0x20002000ul,
				0x20002020ul,
				0x10001000ul,
				0x10001010ul,
				0x8000800ul,
				0x8000808ul,
				0x4000400ul,
				0x4000404ul,
				0x2000200ul,
				0x2000202ul,
				0x1000100ul,
				0x1000101ul,
				0x800080ul,
				0x8000000000800080ul,
				0x400040ul,
				0x4000000000400040ul,
				0x200020ul,
				0x2000000000200020ul,
				0x100010ul,
				0x1000000000100010ul,
				0x80008ul,
				0x800000000080008ul,
				0x40004ul,
				0x400000000040004ul,
				0x20002ul,
				0x200000000020002ul,
				0x10001ul,
				0x100000000010001ul,
				0x8000ul,
				0x80000000008000ul,
				0x4000ul,
				0x40000000004000ul,
				0x2000ul,
				0x20000000002000ul,
				0x1000ul,
				0x10000000001000ul,
				0x800ul,
				0x8000000000800ul,
				0x400ul,
				0x4000000000400ul,
				0x200ul,
				0x2000000000200ul,
				0x100ul,
				0x1000000000100ul,
				0x80ul,
				0x800000000080ul,
				0x40ul,
				0x400000000040ul,
				0x20ul,
				0x200000000020ul,
				0x10ul,
				0x100000000010ul,
				0x8ul,
				0x80000000008ul,
				0x4ul,
				0x40000000004ul,
				0x2ul,
				0x20000000002ul,
				0x1ul,
				0x10000000001ul
			};

			public static ulong[] g_TempMatrix = new ulong[256]; // 256
			public static ulong[] g_InputMatrix = new ulong[64]; // 64
			public static ulong[] g_Coefficient = new ulong[64]; // 64
			public static ulong[] g_AnswerFlag = new ulong[64]; // 64
			public static int[] g_FreeBit = new int[64]; // 64
			public static int[] g_FreeId = new int[64]; // 64
			public static ulong[] g_CoefficientData = new ulong[0x1000000];
			public static ulong[] g_SearchPattern = new ulong[0x1000000];
			public static ulong[] l_Temp = new ulong[256];

			public static void InitializeTransformationMatrix()
			{
				for (int i = 0; i < 256; ++i)
				{
					g_TempMatrix[i] = c_N[i];
				}
			}
			public static void ProceedTransformationMatrix()
			{
				for (int i = 0; i < 256; ++i)
				{
					l_Temp[i] = g_TempMatrix[i];
				}
				for (int y = 0; y < 128; ++y)
				{
					g_TempMatrix[y * 2] = 0;
					g_TempMatrix[y * 2 + 1] = 0;
					for (int x = 0; x < 64; ++x)
					{
						ulong t0 = 0;
						ulong t1 = 0;
						for (int i = 0; i < 64; ++i)
						{
							if ((c_N[y * 2] & (1ul << (63 - i))) != 0
								&& (l_Temp[i * 2] & (1ul << (63 - x))) != 0)
							{
								t0 = 1 - t0;
							}
							if ((c_N[y * 2 + 1] & (1ul << (63 - i))) != 0
								&& (l_Temp[(i + 64) * 2] & (1ul << (63 - x))) != 0)
							{
								t0 = 1 - t0;
							}

							if ((c_N[y * 2] & (1ul << (63 - i))) != 0
								&& (l_Temp[i * 2 + 1] & (1ul << (63 - x))) != 0)
							{
								t1 = 1 - t1;
							}
							if ((c_N[y * 2 + 1] & (1ul << (63 - i))) != 0
								&& (l_Temp[(i + 64) * 2 + 1] & (1ul << (63 - x))) != 0)
							{
								t1 = 1 - t1;
							}
						}
						g_TempMatrix[y * 2] |= (t0 << (63 - x));
						g_TempMatrix[y * 2 + 1] |= (t1 << (63 - x));
					}
				}
			}

			public static ulong GetMatrixMultiplier(int index)
			{
				return g_TempMatrix[index * 2 + 1];
			}

			public static short GetMatrixConst(int index)
			{
				return (short)GetSignature(g_TempMatrix[index * 2] & c_XoroshiroConst);
			}

			public static void CalculateInverseMatrix(int length)
			{
				for (int i = 0; i < length; ++i)
				{
					g_AnswerFlag[i] = (1ul << (length - 1 - i));
				}

				int skip = 0;
				for (int i = 0; i < 64; ++i)
				{
					g_FreeBit[i] = 0;
				}

				for (int rank = 0; rank < length;)
				{
					ulong top = (1ul << (63 - (rank + skip)));
					bool rankUpFlag = false;
					for (int i = rank; i < length; ++i)
					{
						if ((g_InputMatrix[i] & top) != 0)
						{
							for (int a = 0; a < length; ++a)
							{
								if (a == i) continue;
								if ((g_InputMatrix[a] & top) != 0)
								{
									g_InputMatrix[a] ^= g_InputMatrix[i];
									g_AnswerFlag[a] ^= g_AnswerFlag[i];
								}
							}
							ulong swapM = g_InputMatrix[rank];
							ulong swapF = g_AnswerFlag[rank];
							g_InputMatrix[rank] = g_InputMatrix[i];
							g_AnswerFlag[rank] = g_AnswerFlag[i];
							g_InputMatrix[i] = swapM;
							g_AnswerFlag[i] = swapF;

							++rank;
							rankUpFlag = true;
						}
					}
					if (rankUpFlag == false)
					{
						g_FreeBit[rank + skip] = 1;
						g_FreeId[skip] = rank + skip;
						++skip;
					}
				}

				for (int i = length + skip; i < 64; ++i)
				{
					g_FreeBit[i] = 1;
					g_FreeId[i - length] = i;
				}

				for (int i = 0; i < length; ++i)
				{
					g_Coefficient[i] = 0;
					for (int a = 0; a < (64 - length); ++a)
					{
						g_Coefficient[i] |= (g_InputMatrix[i] & (1ul << (63 - g_FreeId[a]))) >> ((length + a) - g_FreeId[a]);
					}
				}
			}

			public static void CalculateCoefficientData(int length)
			{
				uint max = (uint)(1 << (64 - length));
				for (uint search = 0; search < max; ++search)
				{
					g_CoefficientData[search] = 0;
					g_SearchPattern[search] = 0;
					int offset = 0;
					for (int i = 0; i < length; ++i)
					{
						while (g_FreeBit[i + offset] > 0)
						{
							++offset;
						}
						g_CoefficientData[search] |= (GetSignature(g_Coefficient[i] & search) << (63 - (i + offset)));
					}
					for (int a = 0; a < (64 - length); ++a)
					{
						g_SearchPattern[search] |= ((ulong)search & (1ul << (64 - length - 1 - a))) << ((length + a) - g_FreeId[a]);
					}
				}
			}

			public static ulong GetSignature(ulong value)
			{
				uint a = (uint)(value ^ (value >> 32));
				a = a ^ (a >> 16);
				a = a ^ (a >> 8);
				a = a ^ (a >> 4);
				a = a ^ (a >> 2);
				return (a ^ (a >> 1)) & 1;
			}
		}
	}
}
