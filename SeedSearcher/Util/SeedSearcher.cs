using System;
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

		private readonly Mode m_Mode;

		public SeedSearcher(Mode mode)
		{
			m_Mode = mode;
		}

		// 結果
		public List<ulong> Result { get; } = new List<ulong>();

		// ★1～2検索
		[DllImport("SeedSearcherLib.dll")]
		static extern void Prepare(int rerolls);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetFirstCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int flawlessIDX, int ability, int nature, int day, int characteristic, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetNextCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int day, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetThirdCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int day, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		static extern ulong Search(ulong ivs, ulong ability);

		[DllImport("SeedSearcherLib.dll")]
		static extern uint TestSeed(ulong seed);

		// ★3～5検索
		[DllImport("SeedSearcherLib.dll")]
		static extern void PrepareSix(int ivOffset);
		[DllImport("SeedSearcherLib.dll")]
		static extern void PrepareFive(int ivOffset);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetSixFirstCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int day, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetSixSecondCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int day, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetSixThirdCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int day, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetSixFourthCondition(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristic, int day, int species, int altform, bool noGender, bool isDream);

		[DllImport("SeedSearcherLib.dll")]
		private static extern void SetTargetCondition6(int iv1, int iv2, int iv3, int iv4, int iv5, int iv6);

		[DllImport("SeedSearcherLib.dll")]
		static extern ulong SearchSix(ulong ivs, ulong ability);

		[DllImport("SeedSearcherLib.dll")]
		static extern ulong SearchFive(ulong ivs, ulong ability, ulong fixedIdx);

		[DllImport("SeedSearcherLib.dll")]
		static extern ulong SearchFour(ulong ivs, ulong ability, ulong fixedIdx);

		[DllImport("SeedSearcherLib.dll")]
		static extern uint TestSixSeed(ulong seed);

		[DllImport("SeedSearcherLib.dll")]
		static extern void Reset();

		private PkmnStruct pkmn1;
		private PkmnStruct pkmn2;
		private PkmnStruct pkmn3;
		private PkmnStruct pkmn4;
		private int LSB;

		private static bool StopSearchCommand = false;

		public static void ResetSearcher()
		{
			Reset();
		}

		public static void StopSearch()
		{
			SeedSearcherGPU.StopSearchCommand = true;
			StopSearchCommand = true;
		}

		public void RegisterPokemon1(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristics, int day, int species, int altform, bool isNoGender, bool isEnableDream, int fixedIVPos = -1)
		{
			pkmn1 = new PkmnStruct(iv0, iv1, iv2, iv3, iv4, iv5, fixedIV, ability, nature, characteristics, day, species, altform, isNoGender, isEnableDream, fixedIVPos);
		}

		public void RegisterPokemon2(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristics, int day, int species, int altform, bool isNoGender, bool isEnableDream, int fixedIVPos = -1)
		{
			pkmn2 = new PkmnStruct(iv0, iv1, iv2, iv3, iv4, iv5, fixedIV, ability, nature, characteristics, day, species, altform, isNoGender, isEnableDream, fixedIVPos);
		}

		public void RegisterPokemon3(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristics, int day, int species, int altform, bool isNoGender, bool isEnableDream, int fixedIVPos = -1)
		{
			pkmn3 = new PkmnStruct(iv0, iv1, iv2, iv3, iv4, iv5, fixedIV, ability, nature, characteristics, day, species, altform, isNoGender, isEnableDream, fixedIVPos);
		}

		public void RegisterPokemon4(int iv0, int iv1, int iv2, int iv3, int iv4, int iv5, int fixedIV, int ability, int nature, int characteristics, int day, int species, int altform, bool isNoGender, bool isEnableDream, int fixedIVPos = -1)
		{
			pkmn4 = new PkmnStruct(iv0, iv1, iv2, iv3, iv4, iv5, fixedIV, ability, nature, characteristics, day, species, altform, isNoGender, isEnableDream, fixedIVPos);
		}

		public void RegisterLSB(int lsb)
		{
			LSB = lsb;
		}

		private List<ulong> GetAbilityBits()
		{
			List<ulong> res = new List<ulong>();
			if (pkmn4.characteristicPos == null)
			{
				if (pkmn1.isEnableDream || pkmn1.ability < 0)
				{
					if(LSB == -1) { 
						res.Add(0ul);
						res.Add(1ul);
						res.Add(2ul);
						res.Add(3ul);
					} 
					else
					{
						res.Add((ulong) LSB);
						res.Add((ulong) LSB | 2);
					}
				}
				else
				{
					if (LSB == -1)
					{
						res.Add((ulong)(pkmn1.ability << 1));
						res.Add((ulong)(pkmn1.ability << 1) | 1);
					}
					else
					{
						res.Add((ulong)(pkmn1.ability << 1 | LSB));
					}
				}
			}
			else
			{
				if (pkmn2.isEnableDream || pkmn2.ability < 0)
				{
					if (LSB == -1)
					{
						res.Add(0ul);
						res.Add(1ul);
						res.Add(2ul);
						res.Add(3ul);
					}
					else
					{
						res.Add((ulong)LSB);
						res.Add((ulong)LSB | 2);
					}
				}
				else
				{
					if (LSB == -1)
					{
						res.Add((ulong)(pkmn2.ability << 1));
						res.Add((ulong)(pkmn2.ability << 1) | 1);
					}
					else
					{
						res.Add((ulong)(pkmn2.ability << 1 | LSB));
					}
				}
			}
			return res;
		}

		public uint TestInputSeed(ulong seed)
		{
			var ssg = new SeedSearcherGPU();
			ssg.SetSixLSB(LSB);
			ssg.SetSixFirstCondition(pkmn1);
			ssg.SetSixSecondCondition(pkmn2);
			ssg.SetSixThirdCondition(pkmn3);
			if (m_Mode == Mode.Star35)
			{
				ssg.SetSixFourthCondition(pkmn4);
			}
			return ssg.TestSeed(seed);
		}

		private void CalculateGPU(int searcherIDX, int minRerolls, int maxRerolls, int[] target, ToolStripStatusLabel updateLbl, ToolStripProgressBar calculationProgressBar)
		{
			var devices = SeedSearcherGPU.UseableGPU();
			var ssg = new SeedSearcherGPU();
			ssg.SetSixFirstCondition(pkmn1);
			ssg.SetSixSecondCondition(pkmn2);
			ssg.SetSixThirdCondition(pkmn3);
			ssg.SetTargetCondition(target);
			ssg.SetSixLSB(LSB);
			List<ulong> abilities = GetAbilityBits();
			if (m_Mode == Mode.Star12)
			{
				if (ssg.TestSeed(0) != 5)
				{
					var result = ssg.SearchOne(devices[searcherIDX], minRerolls, maxRerolls, abilities, updateLbl, calculationProgressBar);
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
						result = ssg.SearchFour(devices[searcherIDX], minRerolls, maxRerolls, abilities, updateLbl, calculationProgressBar);
					} else if(target[5] == -1)
					{
						result = ssg.SearchFive(devices[searcherIDX], minRerolls, maxRerolls, abilities, updateLbl, calculationProgressBar);
					} else
					{
						result = ssg.SearchSix(devices[searcherIDX], minRerolls, maxRerolls, abilities, updateLbl, calculationProgressBar);
					}
					if (result != 0)
					{
						Result.Add(result);
					}
				}
				else
				{
					Result.Add(0);
				}
			}
		}

		public List<ulong> Calculate(int rolls, int[] target)
		{
			Calculate(0, rolls, rolls, target, null, null);
			return Result;
		}

		public void Calculate(int searcherIDX, int minRerolls, int maxRerolls, int[] target, ToolStripStatusLabel updateLbl, ToolStripProgressBar calculationProgressBar)
		{
			Result.Clear();
			StopSearchCommand = false;
			SeedSearcherGPU.StopSearchCommand = false;
			if (searcherIDX < 0)
			{
				CalculateCPU(searcherIDX + 3, minRerolls, maxRerolls, target, updateLbl, calculationProgressBar);
			} else
			{
				CalculateGPU(searcherIDX, minRerolls, maxRerolls, target, updateLbl, calculationProgressBar);
			}
			StopSearchCommand = false;
			SeedSearcherGPU.StopSearchCommand = false;
		}

		private void CalculateCPU(int searcherIDX, int minRerolls, int maxRerolls, int[] target, ToolStripStatusLabel updateLbl, ToolStripProgressBar calculationProgressBar)
		{
			ParallelOptions opts;
			if(searcherIDX == 0)
			{
				opts = new ParallelOptions { MaxDegreeOfParallelism = Convert.ToInt32(Math.Ceiling(Environment.ProcessorCount * 0.5)) };
			} 
			else if(searcherIDX == 1) 
			{
				opts = new ParallelOptions { MaxDegreeOfParallelism = Convert.ToInt32(Math.Ceiling(Environment.ProcessorCount * 0.75)) };
			} 
			else
			{
				opts = new ParallelOptions { MaxDegreeOfParallelism = -1 };
			}
			
			List<ulong> abilities = GetAbilityBits();
			if (m_Mode == Mode.Star12)
			{
				SetFirstCondition(pkmn1.ivs0, pkmn1.ivs1, pkmn1.ivs2, pkmn1.ivs3, pkmn1.ivs4, pkmn1.ivs5, pkmn1.fixedIV, pkmn1.fixedIVPos,
					pkmn1.ability, pkmn1.nature, pkmn1.characteristic, pkmn1.day, pkmn1.ID, pkmn1.altForm, pkmn1.isNoGender, pkmn1.isEnableDream);
				SetNextCondition(pkmn2.ivs0, pkmn2.ivs1, pkmn2.ivs2, pkmn2.ivs3, pkmn2.ivs4, pkmn2.ivs5, pkmn2.fixedIV,
					pkmn2.ability, pkmn2.nature, pkmn2.characteristic, pkmn2.day, pkmn2.ID, pkmn2.altForm, pkmn2.isNoGender, pkmn2.isEnableDream);
				SetThirdCondition(pkmn3.ivs0, pkmn3.ivs1, pkmn3.ivs2, pkmn3.ivs3, pkmn3.ivs4, pkmn3.ivs5, pkmn3.fixedIV,
					pkmn3.ability, pkmn3.nature, pkmn3.characteristic, pkmn3.day, pkmn3.ID, pkmn3.altForm, pkmn3.isNoGender, pkmn3.isEnableDream);
				if (TestSeed(0) != 5)
				{
					if (calculationProgressBar != null)
					{
						calculationProgressBar.Maximum = abilities.Count;
					}

					for (int i = minRerolls; i <= maxRerolls; ++i)
					{
						if(updateLbl != null)
							updateLbl.Text = i.ToString();
						Prepare(i);
						if (calculationProgressBar != null)
						{
							calculationProgressBar.Value = 0;
						}
						foreach (ulong ability in abilities) 
						{
							Parallel.For(0, 0x10000000, opts, (ivs, state) =>
							{
								ulong result = Search((ulong)ivs, ability);
								if (result != 0)
								{
									Result.Add(result);
									state.Stop();
								}
								if (StopSearchCommand) state.Stop();
							});
							if (Result.Count > 0)
							{
								return;
							}
							if (StopSearchCommand) return;
							if (calculationProgressBar != null)
							{
								calculationProgressBar.Value++;
							}
						}
					}
				}
				else
				{
					Result.Add(0);
					return;
				}
			}
			else
			{
				SetSixFirstCondition(pkmn1.ivs0, pkmn1.ivs1, pkmn1.ivs2, pkmn1.ivs3, pkmn1.ivs4, pkmn1.ivs5, pkmn1.fixedIV, 
					pkmn1.ability, pkmn1.nature, pkmn1.characteristic, pkmn1.day, pkmn1.ID, pkmn1.altForm, pkmn1.isNoGender, pkmn1.isEnableDream);
				SetSixSecondCondition(pkmn2.ivs0, pkmn2.ivs1, pkmn2.ivs2, pkmn2.ivs3, pkmn2.ivs4, pkmn2.ivs5, pkmn2.fixedIV,
					pkmn2.ability, pkmn2.nature, pkmn2.characteristic, pkmn2.day, pkmn2.ID, pkmn2.altForm, pkmn2.isNoGender, pkmn2.isEnableDream);
				SetSixThirdCondition(pkmn3.ivs0, pkmn3.ivs1, pkmn3.ivs2, pkmn3.ivs3, pkmn3.ivs4, pkmn3.ivs5, pkmn3.fixedIV,
					pkmn3.ability, pkmn3.nature, pkmn3.characteristic, pkmn3.day, pkmn3.ID, pkmn3.altForm, pkmn3.isNoGender, pkmn3.isEnableDream);
				SetSixFourthCondition(pkmn4.ivs0, pkmn4.ivs1, pkmn4.ivs2, pkmn4.ivs3, pkmn4.ivs4, pkmn4.ivs5, pkmn4.fixedIV,
					pkmn4.ability, pkmn4.nature, pkmn4.characteristic, pkmn4.day, pkmn4.ID, pkmn4.altForm, pkmn4.isNoGender, pkmn4.isEnableDream);
				if (TestSixSeed(0) != 5)
				{
					List<ulong> fixedPosition = new List<ulong>();
					if (pkmn1.ivs0 == 31)
					{
						fixedPosition.Add(0);
					}
					if (pkmn1.ivs1 == 31)
					{
						fixedPosition.Add(1);
					}
					if (pkmn1.ivs2 == 31)
					{
						fixedPosition.Add(2);
					}
					if (pkmn1.ivs3 == 31)
					{
						fixedPosition.Add(3);
					}
					if (pkmn1.ivs4 == 31)
					{
						fixedPosition.Add(4);
					}
					if (pkmn1.ivs5 == 31)
					{
						fixedPosition.Add(5);
					}
					SetTargetCondition6(target[0], target[1], target[2], target[3], target[4], target[5]);
					if (target[4] == -1)
					{
						var result = Util.Prompt(MessageBoxButtons.YesNo, "Warning: This search can take multiple hours. Only do this at your own risk. Do you want to continue?");
						if (result == DialogResult.No)
						{
							return;
						}
						if (calculationProgressBar != null)
						{
							calculationProgressBar.Maximum = fixedPosition.Count * abilities.Count;
						}
						for (int i = minRerolls; i <= maxRerolls; ++i)
						{
							if (updateLbl != null) { 
								updateLbl.Text = i.ToString();
							}
							if (calculationProgressBar != null)
							{
								calculationProgressBar.Value = 0;
							}
							PrepareFive(i);
							foreach (ulong fidx in fixedPosition)
							{
								foreach (ulong ability in abilities)
								{
									Parallel.For(0, 0x800000u, opts, (ivs, state) =>
									{
										ulong result = SearchFour((ulong)ivs, ability, fidx);
										if (result != 0)
										{
											Result.Add(result);
											state.Stop();
										}
										if (StopSearchCommand) state.Stop();
									});
									if (Result.Count > 0)
									{
										return;
									}
									if (StopSearchCommand) return;
									if (calculationProgressBar != null)
									{
										calculationProgressBar.Value++;
									}
								}
							}
						}
					}
					else if (target[5] == -1)
					{
						if (calculationProgressBar != null)
						{
							calculationProgressBar.Maximum = fixedPosition.Count * abilities.Count;
						}
						for (int i = minRerolls; i <= maxRerolls; ++i)
						{
							if (updateLbl != null)
								updateLbl.Text = i.ToString();
							if (calculationProgressBar != null)
							{
								calculationProgressBar.Value = 0;
							}
							PrepareFive(i);
							foreach (ulong fidx in fixedPosition)
							{
								foreach (ulong ability in abilities)
								{
									Parallel.For(0, 0x10000000, opts, (ivs, state) =>
									{
										ulong result = SearchFive((ulong)ivs, ability, fidx);
										if (result != 0)
										{
											Result.Add(result);
											state.Stop();
										}
										if (StopSearchCommand) state.Stop();
									});
									if (Result.Count > 0)
									{
										return;
									}
									if (StopSearchCommand) return;
									if (calculationProgressBar != null)
									{
										calculationProgressBar.Value++;
									}
								}
							}
						}
					}
					else
					{
						if (calculationProgressBar != null)
						{
							calculationProgressBar.Maximum = abilities.Count;
						}
						for (int i = minRerolls; i <= maxRerolls; ++i)
						{
							if (updateLbl != null)
								updateLbl.Text = i.ToString();
							if (calculationProgressBar != null)
							{
								calculationProgressBar.Value = 0;
							}
							PrepareSix(i);
							foreach (ulong ability in abilities)
							{
								Parallel.For(0, 0x40000000, opts, (ivs, state) =>
								{
									ulong result = SearchSix((ulong)ivs, ability);
									if (result != 0)
									{
										Result.Add(result);
										state.Stop();
									}
									if (StopSearchCommand) state.Stop();
								});
								if (Result.Count > 0)
								{
									return;
								}
								if (StopSearchCommand) return;
								if (calculationProgressBar != null)
								{
									calculationProgressBar.Value++;
								}
							}
						}
					}
				}
				else
				{
					Result.Add(0);
				}
			}
		}
	}
}
