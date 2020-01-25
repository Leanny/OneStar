using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeedSearcherGui
{
    class SeedSearcher
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
		public static extern void SetFirstCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int flawlessIDX, int ability, int nature, int characteristic, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		public static extern void SetNextCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		public static extern void SetThirdCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		public static extern void SetLSB(int bit);

		[DllImport("SeedSearcherLib.dll")]
		static extern ulong Search(ulong ivs);

		[DllImport("SeedSearcherLib.dll")]
		static extern uint TestSeed(ulong seed);

		// ★3～5検索
		[DllImport("SeedSearcherLib.dll")]
		static extern void PrepareSix(int ivOffset);

		[DllImport("SeedSearcherLib.dll")]
		public static extern void SetSixFirstCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		public static extern void SetSixSecondCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		public static extern void SetSixThirdCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		public static extern void SetSixFourthCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		public static extern void SetTargetCondition6(int iv1, int iv2, int iv3, int iv4, int iv5, int iv6);

		[DllImport("SeedSearcherLib.dll")]
		public static extern void SetSixLSB(int bit);

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

		static readonly ulong shift = 0x7817eba09827c0eful;
		static readonly ulong frontshift = 0xFFFFFFFFFFFFFFFFul - shift + 1;

		public static void ResetSearcher()
		{
			Reset();
		}

		public uint TestInputSeed(ulong seed)
		{
			if (m_Mode == Mode.Star12)
			{
				return TestSeed(seed);
			}
			else
			{
				return TestSixSeed(seed + frontshift);
			}
		}
		
		public void Calculate(int minRerolls, int maxRerolls, int[] target, ToolStripStatusLabel updateLbl)
		{
			Result.Clear();
			if (m_Mode == Mode.Star12)
			{
				if (TestSeed(0) != 5)
				{
					int searchLower = 0;
					int searchUpper = 0x10000000;

					for (int i = minRerolls; i <= maxRerolls; ++i)
					{
						updateLbl.Text = i.ToString();
						Prepare(i);
						Parallel.For(searchLower, searchUpper, (ivs, state) =>
						{
							ulong result = Search((ulong)ivs);
							if (result != 0)
							{
								Result.Add(result);
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
