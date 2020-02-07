using PKHeX_Raid_Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SeedSearcherGui
{
    public partial class IVCalculator : Form
    {
        private RaidTemplate RaidInfo;
        private int[] basestats;
        private TextBox[] minVals;
        private TextBox[] maxVals;
        private int[] ivstarts = { 0, 1, 16, 26, 30, 31, 32 };
        private int[] statorder = { 0, 1, 2, 5, 3, 4 };
        private ComboBox[] ratings;
        private NumericUpDown[] original;
        private ComboBox nature;
        public static readonly int[] ToxtricityAmplifiedNatures = { 0x03, 0x04, 0x02, 0x08, 0x09, 0x13, 0x16, 0x0B, 0x0D, 0x0E, 0x00, 0x06, 0x18 };
        public static readonly int[] ToxtricityLowKeyNatures = { 0x01, 0x05, 0x07, 0x0A, 0x0C, 0x0F, 0x10, 0x11, 0x12, 0x14, 0x15, 0x17 };
        public IVCalculator(PKHeX.Core.GameStrings gameStrings, RaidTemplate raidInfo, NumericUpDown hP1, NumericUpDown aTK1, NumericUpDown dEF1, NumericUpDown sPA1, NumericUpDown sPD1, NumericUpDown sPE1, ComboBox cB_Nature)
        {
            InitializeComponent();
            CB_Nature.Items.Clear();
            for (int i = 0; i < gameStrings.natures.Length; i++)
            {
                if (raidInfo.Species == (int)PKHeX.Core.Species.Toxtricity)
                {
                    if (raidInfo.AltForm == 0)
                    {
                        if(ToxtricityAmplifiedNatures.Contains(i))
                        {
                            CB_Nature.Items.Add(new ComboboxItem(gameStrings.natures[i], i));
                        }
                    }
                    else
                    {
                        if (ToxtricityLowKeyNatures.Contains(i))
                        {
                            CB_Nature.Items.Add(new ComboboxItem(gameStrings.natures[i], i));
                        }
                    }
                }
                else
                {
                    CB_Nature.Items.Add(new ComboboxItem(gameStrings.natures[i], i));
                }
            }
            CB_Nature.SelectedIndex = cB_Nature.SelectedIndex;
            nature = cB_Nature;
            this.RaidInfo = raidInfo;
            TB_Species.Text = gameStrings.Species[raidInfo.Species];
            PKHeX.Core.PersonalInfo baseinfo;
            if (raidInfo.Species == (int) PKHeX.Core.Species.Indeedee)
            {
                baseinfo = PKHeX.Core.PersonalTable.SWSH.GetFormeEntry(raidInfo.Species, raidInfo.Gender);
            } else
            {
                baseinfo = PKHeX.Core.PersonalTable.SWSH.GetFormeEntry(raidInfo.Species, raidInfo.AltForm);
            }
            
            //var baseinfo = PKHeX.Core.PersonalTable.SWSH[raidInfo.Species];
            basestats = new int[] { baseinfo.HP, baseinfo.ATK, baseinfo.DEF, baseinfo.SPA, baseinfo.SPD, baseinfo.SPE };
            minVals = new TextBox[] { ResHP1, ResAtk1, ResDef1, ResSpa1, ResSpd1, ResSpe1 };
            maxVals = new TextBox[] { ResHP2, ResAtk2, ResDef2, ResSpa2, ResSpd2, ResSpe2 };
            ratings = new ComboBox[] { CB_Rating1, CB_Rating2, CB_Rating3, CB_Rating4, CB_Rating5, CB_Rating6 };
            original = new NumericUpDown[] { hP1, aTK1, dEF1, sPA1, sPD1, sPE1 };
            
        }

        private void HP1_Enter(object sender, EventArgs e)
        {
            NumericUpDown numbox = (NumericUpDown)sender;
            numbox.Select(0, numbox.Text.Length);
        }

        private int GetReccomendedLevel()
        {
            int natureID = (int)((ComboboxItem)CB_Nature.SelectedItem).Value;
            int increase = statorder[natureID / 5 + 1];
            int decrease = statorder[natureID % 5 + 1];
            int level = (int)NUD_Level.Value;
            int[] reccomendedLevel = { 100, 100, 100, 100, 100, 100 };
            // HP Manually 
            int lowerHP = int.Parse(minVals[0].Text);
            int upperHP = int.Parse(maxVals[0].Text);
            for(int lvl = level; lvl <= 100; lvl++)
            {
                int calcMinHP = (lowerHP + (2 * basestats[0]) + 100) * lvl / 100 + 10;
                int calcMaxHP = (upperHP + (2 * basestats[0]) + 100) * lvl / 100 + 10;
                if(calcMinHP != calcMaxHP)
                {
                    reccomendedLevel[0] = lvl;
                    break;
                }
            }
            for(int stat = 1; stat < 6; stat++)
            {
                int lower = int.Parse(minVals[stat].Text);
                int upper = int.Parse(maxVals[stat].Text);
                for (int lvl = level; lvl <= 100 && lower != upper; lvl++)
                {
                    int calcMin = ((lower + (2 * basestats[stat])) * lvl / 100) + 5;
                    int calcMax = ((upper + (2 * basestats[stat])) * lvl / 100) + 5;
                    if (stat == increase && stat != decrease)
                    {
                        calcMin *= 11;
                        calcMin /= 10;
                        calcMax *= 11;
                        calcMax /= 10;
                    }
                    else if (stat == decrease && stat != increase)
                    {
                        calcMin *= 9;
                        calcMin /= 10;
                        calcMax *= 9;
                        calcMax /= 10;
                    }
                    if (calcMin != calcMax)
                    {
                        reccomendedLevel[stat] = lvl;
                        break;
                    }
                }
            }

            return reccomendedLevel.Min();
        }

        private void ButtonCalc_Click(object sender, EventArgs e)
        {
            int[] target = { (int) HP.Value, (int)ATK.Value, (int)DEF.Value, (int)SPA.Value, (int)SPD.Value, (int)SPE.Value };
            NumericUpDown[] NUD_Stats = { HP, ATK, DEF, SPA, SPD, SPE };
            string[] statNames = { "HP", "ATK", "DEF", "SPA", "SPD", "SPE" };
            int natureID = (int) ((ComboboxItem)CB_Nature.SelectedItem).Value;
            int increase = statorder[natureID / 5 + 1];
            int decrease = statorder[natureID % 5 + 1];
            int level = (int) NUD_Level.Value;
            // get HP
            int HPJudgement = CB_Rating1.SelectedIndex;
            int lowerHP = int.Parse(minVals[0].Text);
            int upperHP = int.Parse(maxVals[0].Text);
            if(HPJudgement >= 0)
            {
                lowerHP = Math.Max(lowerHP, ivstarts[HPJudgement]);
                upperHP = Math.Min(upperHP, ivstarts[HPJudgement+1] - 1);
                minVals[0].Text = lowerHP.ToString();
                maxVals[0].Text = upperHP.ToString();
            }
            if(lowerHP != upperHP)
            {
                if(basestats[0] == 1)
                {
                    MessageBox.Show("HP IV value cannot be determined for this Pokémon.");
                    return;
                } else {
                    List<int> results = new List<int>();
                    for(int iv = lowerHP; iv <= upperHP; iv++)
                    {
                        int calcHP = (iv + (2 * basestats[0]) + 100) * level / 100 + 10;
                        if(calcHP == target[0])
                        {
                            results.Add(iv);
                        }
                    }
                    if(results.Count == 0)
                    {
                        MessageBox.Show("HP IV could not be determined.");
                        return;
                    } else
                    {
                        minVals[0].Text = results.Min().ToString();
                        maxVals[0].Text = results.Max().ToString();
                    }
                }
            }
            // get other stats 
            for(int stat = 1; stat < 6; stat++)
            {
                int Judgement = ratings[stat].SelectedIndex;
                int lower = int.Parse(minVals[stat].Text);
                int upper = int.Parse(maxVals[stat].Text);
                if (Judgement >= 0)
                {
                    lower = Math.Max(lower, ivstarts[Judgement]);
                    upper = Math.Min(upper, ivstarts[Judgement + 1] - 1);
                    minVals[stat].Text = lower.ToString();
                    maxVals[stat].Text = upper.ToString();
                }
                if (lower != upper)
                {
                    if (basestats[stat] == 1)
                    {
                        MessageBox.Show(statNames[stat] + " IV value cannot be determined for this Pokémon.");
                        return;
                    }
                    else
                    {
                        List<int> results = new List<int>();
                        for (int iv = lower; iv <= upper; iv++)
                        {
                            int calc = ((iv + (2 * basestats[stat])) * level / 100) + 5;
                            if(stat == increase && stat != decrease)
                            {
                                calc *= 11;
                                calc /= 10;
                            } else if (stat == decrease && stat != increase)
                            {
                                calc *= 9;
                                calc /= 10;
                            }
                            if (calc == target[stat])
                            {
                                results.Add(iv);
                            }
                        }
                        if (results.Count == 0)
                        {
                            MessageBox.Show(statNames[stat] + " IV could not be determined.");
                            return;
                        }
                        else
                        {
                            minVals[stat].Text = results.Min().ToString();
                            maxVals[stat].Text = results.Max().ToString();
                        }
                    }
                }
            }
            // go through all of them again
            bool foundAll = true;
            for (int stat = 0; stat < 6; stat ++)
            {
                int lower = int.Parse(minVals[stat].Text);
                int upper = int.Parse(maxVals[stat].Text);
                foundAll &= lower == upper;
                ratings[stat].Enabled = lower != upper;
                NUD_Stats[stat].Enabled = lower != upper;
            }
            if(foundAll)
            {
                ButtonCalc.Enabled = false;
                ButtonApply.Enabled = true;
            } else
            {
                int lvl = GetReccomendedLevel();
                LBL_RecLevel.Text = lvl.ToString();
                NUD_Level.Value = lvl;
                NUD_Level.Focus();
            }
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            for(int stat = 0; stat < 6; stat++)
            {
                original[stat].Value = int.Parse(minVals[stat].Text);
            }
            nature.SelectedIndex = CB_Nature.SelectedIndex;
            this.Close();
        }
    }
}
