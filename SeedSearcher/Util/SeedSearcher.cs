using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeedSearcherGui
{
    public class SeedSearcher
    {
		public enum Mode
		{
			Star12,
			Star35
		};

		Mode m_Mode;

		public SeedSearcher(Mode mode)
		{
			m_Mode = mode;
		}

		// 結果
		static public List<ulong> Result { get; } = new List<ulong>();

		// ★1～2検索
		[DllImport("SeedSearcherLib.dll")]
		static extern void Prepare(int rerolls);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetFirstCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int flawlessIDX, int ability, int nature, int characteristic, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetNextCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetThirdCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetLSB(int bit);

		[DllImport("SeedSearcherLib.dll")]
		static extern ulong Search(ulong ivs);

		[DllImport("SeedSearcherLib.dll")]
		static extern uint TestSeed(ulong seed);

		// ★3～5検索
		[DllImport("SeedSearcherLib.dll")]
		static extern void PrepareSix(int ivOffset);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetSixFirstCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetSixSecondCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetSixThirdCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetSixFourthCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetTargetCondition6(int iv1, int iv2, int iv3, int iv4, int iv5, int iv6);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetSixLSB(int bit);

		[DllImport("SeedSearcherLib.dll")]
		static extern ulong SearchSix(ulong ivs);

		[DllImport("SeedSearcherLib.dll")]
		static extern ulong SearchFive(ulong ivs);

		[DllImport("SeedSearcherLib.dll")]
		static extern ulong SearchFour(ulong ivs);

		[DllImport("SeedSearcherLib.dll")]
		static extern uint TestSixSeed(ulong seed);

		[DllImport("SeedSearcherLib.dll")]
		static extern void Reset();

		private PkmnStruct pkmn1;
		private PkmnStruct pkmn2;
		private PkmnStruct pkmn3;
		private PkmnStruct pkmn4;
		private int LSB;

		static readonly ulong shift = 0x7817eba09827c0eful;
		static readonly ulong frontshift = 0xFFFFFFFFFFFFFFFFul - shift + 1;

		public static void ResetSearcher()
		{
			Reset();
		}

		public void RegisterPokemon1(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristics, int species, int altform, bool isNoGender, bool isEnableDream, int fixedIVPos = -1)
		{
			pkmn1 = new PkmnStruct(iv0, iv1, iv2, iv3, iv4, iv5, fixedIV, ability, nature, characteristics, species, altform, isNoGender, isEnableDream, fixedIVPos);
		}

		public void RegisterPokemon2(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristics, int species, int altform, bool isNoGender, bool isEnableDream, int fixedIVPos = -1)
		{
			pkmn2 = new PkmnStruct(iv0, iv1, iv2, iv3, iv4, iv5, fixedIV, ability, nature, characteristics, species, altform, isNoGender, isEnableDream, fixedIVPos);
		}

		public void RegisterPokemon3(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristics, int species, int altform, bool isNoGender, bool isEnableDream, int fixedIVPos = -1)
		{
			pkmn3 = new PkmnStruct(iv0, iv1, iv2, iv3, iv4, iv5, fixedIV, ability, nature, characteristics, species, altform, isNoGender, isEnableDream, fixedIVPos);
		}

		public void RegisterPokemon4(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristics, int species, int altform, bool isNoGender, bool isEnableDream, int fixedIVPos = -1)
		{
			pkmn4 = new PkmnStruct(iv0, iv1, iv2, iv3, iv4, iv5, fixedIV, ability, nature, characteristics, species, altform, isNoGender, isEnableDream, fixedIVPos);
		}

		public void RegisterLSB(int lsb)
		{
			LSB = lsb;
		}

		public uint TestInputSeed(ulong seed)
		{
			var ssg = new SeedSearcherGPU();
			ssg.SetSixLSB(LSB);
			ssg.SetSixFirstCondition(pkmn1);
			ssg.SetSixSecondCondition(pkmn2);
			ssg.SetSixThirdCondition(pkmn3);
			if (m_Mode == Mode.Star12)
			{
				return ssg.TestSeed(seed);
			}
			else
			{
				ssg.SetSixFourthCondition(pkmn4);
				return ssg.TestSeed(seed + frontshift);
			}
		}


		private void CalculateGPU(int searcherIDX, int minRerolls, int maxRerolls, int[] target, ToolStripStatusLabel updateLbl)
		{
			var devices = SeedSearcherGPU.UseableGPU();
			var ssg = new SeedSearcherGPU();
			ssg.SetSixFirstCondition(pkmn1);
			ssg.SetSixSecondCondition(pkmn2);
			ssg.SetSixThirdCondition(pkmn3);
			ssg.SetTargetCondition(target);
			ssg.SetSixLSB(LSB);
			if(m_Mode == Mode.Star12)
			{
				if (ssg.TestSeed(0) != 5)
				{
					var result = ssg.SearchOne(devices[searcherIDX], minRerolls, maxRerolls, updateLbl);
					if (result != 0)
					{
						Result.Add(result);
					}
				}
				else
				{
					Result.Add(0);
				}
			} else
			{
				ssg.SetSixFourthCondition(pkmn4);
				if (ssg.TestSeed(0) != 5)
				{
					ulong result;
					if(target[4] == -1)
					{
						result = ssg.SearchFour(devices[searcherIDX], minRerolls, maxRerolls, updateLbl);
					} else if(target[5] == -1)
					{
						result = ssg.SearchFive(devices[searcherIDX], minRerolls, maxRerolls, updateLbl);
					} else
					{
						result = ssg.SearchSix(devices[searcherIDX], minRerolls, maxRerolls, updateLbl);
					}
					if (result != 0)
					{
						Result.Add(result + shift);
					}
				}
				else
				{
					Result.Add(shift);
				}
			}
		}

		public List<ulong> Calculate(int rolls, int[] target)
		{
			Calculate(0, rolls, rolls, target, null);
			return Result;
		}

		public void Calculate(int searcherIDX, int minRerolls, int maxRerolls, int[] target, ToolStripStatusLabel updateLbl)
		{
			Result.Clear();
			if (searcherIDX == -1)
			{
				CalculateCPU(minRerolls, maxRerolls, target, updateLbl);
			} else
			{
				CalculateGPU(searcherIDX, minRerolls, maxRerolls, target, updateLbl);
			}
		}

		private void CalculateCPU(int minRerolls, int maxRerolls, int[] target, ToolStripStatusLabel updateLbl)
		{
			SetLSB(LSB);
			if (m_Mode == Mode.Star12)
			{
				SetFirstCondition(pkmn1.ivs0, pkmn1.ivs1, pkmn1.ivs2, pkmn1.ivs3, pkmn1.ivs4, pkmn1.ivs5, pkmn1.fixedIV, pkmn1.fixedIVPos,
					pkmn1.ability, pkmn1.nature, pkmn1.characteristic, pkmn1.ID, pkmn1.altForm, pkmn1.isNoGender, pkmn1.isEnableDream);
				SetNextCondition(pkmn2.ivs0, pkmn2.ivs1, pkmn2.ivs2, pkmn2.ivs3, pkmn2.ivs4, pkmn2.ivs5, pkmn2.fixedIV,
					pkmn2.ability, pkmn2.nature, pkmn2.characteristic, pkmn2.ID, pkmn2.altForm, pkmn2.isNoGender, pkmn2.isEnableDream);
				SetThirdCondition(pkmn3.ivs0, pkmn3.ivs1, pkmn3.ivs2, pkmn3.ivs3, pkmn3.ivs4, pkmn3.ivs5, pkmn3.fixedIV,
					pkmn3.ability, pkmn3.nature, pkmn3.characteristic, pkmn3.ID, pkmn3.altForm, pkmn3.isNoGender, pkmn3.isEnableDream);
				if (TestSeed(0) != 5)
				{
					int searchLower = 0;
					int searchUpper = 0x10000000;

					for (int i = minRerolls; i <= maxRerolls; ++i)
					{
						if(updateLbl != null)
							updateLbl.Text = i.ToString();
						Prepare(i);
						Parallel.For(searchLower, searchUpper, (ivs, state) =>
						{
							ulong result = Search((ulong)ivs);
							if (result != 0)
							{
								Result.Add((ulong)ivs);
								state.Stop();
							}
						});
						if (Result.Count > 0)
						{
							break;
						}
					}
				}
				else
				{
					Result.Add(0);
				}
			}
			else
			{
				SetSixFirstCondition(pkmn1.ivs0, pkmn1.ivs1, pkmn1.ivs2, pkmn1.ivs3, pkmn1.ivs4, pkmn1.ivs5, pkmn1.fixedIV, 
					pkmn1.ability, pkmn1.nature, pkmn1.characteristic, pkmn1.ID, pkmn1.altForm, pkmn1.isNoGender, pkmn1.isEnableDream);
				SetSixSecondCondition(pkmn2.ivs0, pkmn2.ivs1, pkmn2.ivs2, pkmn2.ivs3, pkmn2.ivs4, pkmn2.ivs5, pkmn2.fixedIV,
					pkmn2.ability, pkmn2.nature, pkmn2.characteristic, pkmn2.ID, pkmn2.altForm, pkmn2.isNoGender, pkmn2.isEnableDream);
				SetSixThirdCondition(pkmn3.ivs0, pkmn3.ivs1, pkmn3.ivs2, pkmn3.ivs3, pkmn3.ivs4, pkmn3.ivs5, pkmn3.fixedIV,
					pkmn3.ability, pkmn3.nature, pkmn3.characteristic, pkmn3.ID, pkmn3.altForm, pkmn3.isNoGender, pkmn3.isEnableDream);
				SetSixFourthCondition(pkmn4.ivs0, pkmn4.ivs1, pkmn4.ivs2, pkmn4.ivs3, pkmn4.ivs4, pkmn4.ivs5, pkmn4.fixedIV,
					pkmn4.ability, pkmn4.nature, pkmn4.characteristic, pkmn4.ID, pkmn4.altForm, pkmn4.isNoGender, pkmn4.isEnableDream);
				if (TestSixSeed(0) != 5)
				{
					SetTargetCondition6(target[0], target[1], target[2], target[3], target[4], target[5]);
					int searchLower = 0;
					if (target[4] == -1)
					{
						int searchUpper = 0x100000;
						for (int i = minRerolls; i <= maxRerolls; ++i)
						{
							PrepareSix(i);
							if (updateLbl != null)
								updateLbl.Text = i.ToString();

							Parallel.For(searchLower, searchUpper, (ivs, state) =>
							{
								ulong result = SearchFour((ulong)ivs);
								if (result != 0)
								{
									Result.Add(result + shift);
									state.Stop();
								}
							});
							if (Result.Count > 0)
							{
								return;
							}
						}
					}
					else if (target[5] == -1)
					{
						int searchUpper = 0x2000000;
						for (int i = minRerolls; i <= maxRerolls; ++i)
						{
							PrepareSix(i);
							if (updateLbl != null)
								updateLbl.Text = i.ToString();

							Parallel.For(searchLower, searchUpper, (ivs, state) =>
							{
								ulong result = SearchFive((ulong)ivs);
								if (result != 0)
								{
									Result.Add(result + shift);
									state.Stop();
								}
							});
							if (Result.Count > 0)
							{
								return;
							}
						}
					}
					else
					{
						int searchUpper = 0x40000000;
						for (int i = minRerolls; i <= maxRerolls; ++i)
						{
							PrepareSix(i);
							if (updateLbl != null)
								updateLbl.Text = i.ToString();

							Parallel.For(searchLower, searchUpper, (ivs, state) =>
							{
								ulong result = SearchSix((ulong)ivs);
								if (result != 0)
								{
									Result.Add(result + shift);
									state.Stop();
								}
							});
							if (Result.Count > 0)
							{
								return;
							}
						}
					}
				}
				else
				{
					Result.Add(shift);
				}
			}
		}
	}
}
