using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneStarCalculator
{
	public class SeedSearcher
	{

		// モード
		public enum Mode {
			Star12,
			Star35_4,
			Star35_5,
			Star35_6,
		};
		Mode m_Mode;

		public SeedSearcher(Mode mode)
		{
			m_Mode = mode;
		}

		// 結果
		static public List<ulong> Result { get; } = new List<ulong>();

		// ★1～2検索
		[DllImport("OneStarCalculatorLib.dll")]
		static extern void Prepare(int rerolls);

		[DllImport("OneStarCalculatorLib.dll")]
		public static extern void SetFirstCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int flawlessIDX, int ability, int nature, int characteristic, bool noGender, bool isDream);

		[DllImport("OneStarCalculatorLib.dll")]
		public static extern void SetNextCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, bool noGender, bool isDream);

		[DllImport("OneStarCalculatorLib.dll")]
		public static extern void SetThirdCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, bool noGender, bool isDream);

		[DllImport("OneStarCalculatorLib.dll")]
		public static extern void SetLSB(int bit);

		[DllImport("OneStarCalculatorLib.dll")]
		static extern ulong Search(ulong ivs);

		[DllImport("OneStarCalculatorLib.dll")]
		static extern uint TestSeed(ulong seed);

		// ★3～5検索
		[DllImport("OneStarCalculatorLib.dll")]
		static extern void PrepareSix(int ivOffset);

		[DllImport("OneStarCalculatorLib.dll")]
		public static extern void SetSixFirstCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, bool noGender, bool isDream);

		[DllImport("OneStarCalculatorLib.dll")]
		public static extern void SetSixSecondCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, bool noGender, bool isDream);

		[DllImport("OneStarCalculatorLib.dll")]
		public static extern void SetSixThirdCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, bool noGender, bool isDream);

		[DllImport("OneStarCalculatorLib.dll")]
		public static extern void SetSixFourthCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, bool noGender, bool isDream);

		[DllImport("OneStarCalculatorLib.dll")]
		public static extern void SetTargetCondition6(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5);

		[DllImport("OneStarCalculatorLib.dll")]
		public static extern void SetTargetCondition5(int iv0, int iv1, int iv2, int iv3, int iv4);

		[DllImport("OneStarCalculatorLib.dll")]
		public static extern void SetTargetCondition4(int iv0, int iv1, int iv2, int iv3);

		[DllImport("OneStarCalculatorLib.dll")]
		public static extern void SetSixLSB(int bit);

		[DllImport("OneStarCalculatorLib.dll")]
		static extern ulong SearchSix(ulong ivs);

		[DllImport("OneStarCalculatorLib.dll")]
		static extern uint TestSixSeed(ulong seed);

		static readonly ulong shift = 0x7817eba09827c0eful;
		static readonly ulong frontshift = 0xFFFFFFFFFFFFFFFFul - shift + 1;


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

		public void Calculate(int minRerolls, int maxRerolls, int[] target, ToolStripStatusLabel updateLbl, ToolStripProgressBar PB_Deviation)
		{
			Result.Clear();
			PB_Deviation.Value = 0;
			if (m_Mode == Mode.Star12)
			{
				if(TestSeed(0) != 5)
				{
					// 探索範囲
					int searchLower = 0;
					int searchUpper = 0xFFFFFFF;

					for (int i = minRerolls; i <= maxRerolls; ++i)
					{
						updateLbl.Text = i.ToString();
						// C++ライブラリ側の事前計算
						Prepare(i);
						// 中断あり
						Parallel.For(searchLower, searchUpper, (ivs, state)=>
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
				} else
				{
					Result.Add(0);
				}
			}
			else {
				// 探索範囲
				int searchLower = 0;
				int searchUpper = 0x3FFFFFFF;
				if (TestSixSeed(0) != 5)
				{
					int limit1 = 0;
					int limit2 = 0;
					bool update1 = false;
					bool update2 = false;
					if(target[4] == -1)
					{
						update1 = true;
						update2 = true;
						limit1 = 31;
						limit2 = 31;
					} else if(target[5] == -1)
					{
						update1 = true;
						limit1 = 31;
					}
					PB_Deviation.Maximum = (limit1 + 1) * (limit2 + 1);
					for (int i = minRerolls; i <= maxRerolls; ++i)
					{
						PB_Deviation.Value = 0;
						SetTargetCondition6(target[0], target[1], target[2], target[3], target[4], target[5]);
						PrepareSix(i);
						for (int l1 = 0; l1 <= limit1; l1++)
						{
							if(update1)
							{
								target[5] = l1;
							}
							for (int l2 = 0; l2 <= limit2; l2++)
							{
								if (update2)
								{
									target[4] = l2;
								}
								
								SetTargetCondition6(target[0], target[1], target[2], target[3], target[4], target[5]);
								updateLbl.Text = i.ToString();
								// C++ライブラリ側の事前計算
								
								// 並列探索
								Parallel.For(searchLower, searchUpper, (ivs, state) =>
								{
									ulong result = SearchSix((ulong)ivs);
									if (result != 0)
									{
										Result.Add(result + shift);
										state.Stop();
									}
								});
								PB_Deviation.Value += 1;
								if (Result.Count > 0)
								{
									return;
								}
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
