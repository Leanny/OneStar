using OneStarCalculator;
using PKHeX.Core;
using PKHeX_Raid_Plugin;
using SeedSearcherGui.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeedSearcherGui.Forms
{
    public partial class SeedSearcherGui : Form
    {
        private static readonly int[] iv_order = { 0, 1, 2, 5, 3, 4 };
        private readonly ComboBox[] CB_Species;
        private readonly ComboBox[] CB_Nature;
        private readonly ComboBox[] CB_Characteristic;
        private readonly RaidTables _raidTables = new RaidTables();
        private bool doneLoading = false;
        private readonly NumericUpDown[] NUD_Stats;
        private GameStrings GameStrings = GameInfo.Strings;
        public SeedSearcherGui()
        {
            InitializeComponent();
            CB_Game.SelectedIndex = 0;
            CB_Rarity.SelectedIndex = 0;
            CB_Species = new ComboBox[] { CB_Species1, CB_Species2 , CB_Species3 , CB_Species4 , CB_Species5 };
            NUD_Stats = new NumericUpDown[] { HP1, ATK1, DEF1, SPA1, SPD1, SPE1, HP2, ATK2, DEF2, SPA2, SPD2, SPE2, 
                                              HP3, ATK3, DEF3, SPA3, SPD3, SPE3, HP4, ATK4, DEF4, SPA4, SPD4, SPE4, 
                                              HP5, ATK5, DEF5, SPA5, SPD5, SPE5};
            CB_Nature = new ComboBox[] { CB_Nature1, CB_Nature2, CB_Nature3, CB_Nature4, CB_Nature5 };
            CB_Characteristic = new ComboBox[] { CB_Characteristic1, CB_Characteristic2, CB_Characteristic3, CB_Characteristic4, CB_Characteristic5 };
            GB_42.Enabled = false;
            GB_43.Enabled = false;
            GB_51.Enabled = false;
            GB_61.Enabled = false;
            RB_2nd.Visible = false;
            RB_3rd.Visible = false;

            LB_Response.Text = "";
            LBLAO.Text = "";


            foreach(var field in CB_Nature)
            {
                field.SelectedIndex = 0;
            }
            foreach (var field in CB_Characteristic)
            {
                field.SelectedIndex = 0;
            }
            BT_Table.Enabled = false;
            doneLoading = true;
            CB_Den.SelectedIndex = 1;
            if(Properties.Settings.Default.Language == 0)
            {
                NihongoToolStripMenuItem_Click(null, null);
            } else
            {
                englishToolStripMenuItem_Click(null, null);
            }
        }

        private void PopulateLanguage(int l)
        {
            GameStrings = GameInfo.GetStrings(l);
            foreach(var cb in CB_Nature)
            {
                int old_idx = cb.SelectedIndex;
                cb.Items.Clear();
                cb.Items.AddRange(GameStrings.natures);
                cb.SelectedIndex = old_idx;
            }
            foreach (var cb in CB_Characteristic)
            {
                int old_idx = cb.SelectedIndex;
                cb.Items.Clear();
                cb.Items.Add(Properties.strings.Unknown);
                for(int i=1; i < GameStrings.characteristics.Length; i+=5) {
                    cb.Items.Add(GameStrings.characteristics[i]);
                }
                cb.SelectedIndex = old_idx;
            }
            int[] species_idx = { CB_Species1.SelectedIndex, CB_Species2.SelectedIndex, CB_Species3.SelectedIndex, CB_Species4.SelectedIndex, CB_Species5.SelectedIndex };

            int old_den_idx = CB_Den.SelectedIndex;
            CB_Den.Items.Clear();
            var entries = new string[]{ Properties.strings.Event, Properties.strings.Rolling1, Properties.strings.Rolling2, Properties.strings.Rolling3, Properties.strings.Rolling4, 
                Properties.strings.Rolling5, Properties.strings.Rolling6, Properties.strings.Rolling7, Properties.strings.Rolling8, Properties.strings.Rolling9, 
                Properties.strings.Dappled1, Properties.strings.Dappled2, Properties.strings.Dappled3, Properties.strings.Dappled4, Properties.strings.Dappled5, 
                Properties.strings.Watchtower1, Properties.strings.Watchtower2, Properties.strings.East1, Properties.strings.East2, Properties.strings.East3, 
                Properties.strings.East4, Properties.strings.West1, Properties.strings.West2, Properties.strings.West3, Properties.strings.West4, Properties.strings.West5, 
                Properties.strings.West6, Properties.strings.Axew1, Properties.strings.South1, Properties.strings.South2, Properties.strings.South3, Properties.strings.South4,
                Properties.strings.South5, Properties.strings.Giant1, Properties.strings.Giant2, Properties.strings.Giant3, Properties.strings.Giant4, Properties.strings.Giant5, 
                Properties.strings.North1, Properties.strings.North2, Properties.strings.North3, Properties.strings.North4, Properties.strings.North5, Properties.strings.East5, 
                Properties.strings.North6, Properties.strings.Motostoke1, Properties.strings.Motostoke2, Properties.strings.Motostoke3, Properties.strings.Motostoke4, 
                Properties.strings.Bridge1, Properties.strings.Bridge2, Properties.strings.Bridge3, Properties.strings.Bridge4, Properties.strings.Bridge5, Properties.strings.Bridge6,
                Properties.strings.Bridge7, Properties.strings.Bridge8, Properties.strings.Bridge9, Properties.strings.Stony1, Properties.strings.Stony2, Properties.strings.Stony3, 
                Properties.strings.Stony4, Properties.strings.Stony5, Properties.strings.Stony6, Properties.strings.Stony7, Properties.strings.Stony8, Properties.strings.Stony9, 
                Properties.strings.Stony0, Properties.strings.Stony1, Properties.strings.Stony2, Properties.strings.Dusty1, Properties.strings.Dusty2, Properties.strings.Dusty3,
                Properties.strings.Dusty4, Properties.strings.Dusty5, Properties.strings.Dusty6, Properties.strings.Dusty7, Properties.strings.Dusty8, Properties.strings.Giant1,
                Properties.strings.Dusty9, Properties.strings.Giant2, Properties.strings.Giant3, Properties.strings.Giant4, Properties.strings.Giant5, Properties.strings.Hammerlocke1,
                Properties.strings.Hammerlocke2, Properties.strings.Hammerlocke3, Properties.strings.Hammerlocke4, Properties.strings.Hammerlocke5, Properties.strings.Hammerlocke6, 
                Properties.strings.Hammerlocke7, Properties.strings.Giant1, Properties.strings.Giant2, Properties.strings.Giant3, Properties.strings.Giant4, Properties.strings.Giant5,
                Properties.strings.Lake1, Properties.strings.Lake2, Properties.strings.Lake3, Properties.strings.Lake4};
            
            for (int i = 0; i < entries.Length; i++)
            {
                int idx = i > 16 ? i + 1 : i;
                CB_Den.Items.Add($"{idx}: {entries[i]}");
            }
            CB_Den.SelectedIndex = old_den_idx;

            int old_rarity_idx = CB_Rarity.SelectedIndex;
            CB_Rarity.Items.Clear();
            CB_Rarity.Items.Add(Properties.strings.Normal);
            CB_Rarity.Items.Add(Properties.strings.Rare);
            CB_Rarity.SelectedIndex = old_rarity_idx;

            int old_game_idx = CB_Game.SelectedIndex;
            CB_Game.Items.Clear();
            CB_Game.Items.Add(Properties.strings.Sword);
            CB_Game.Items.Add(Properties.strings.Shield);
            CB_Game.SelectedIndex = old_game_idx;

            CB_Den.SelectedIndex = old_den_idx;

            for(int i=0; i < CB_Species.Length; i++)
            {
                CB_Species[i].SelectedIndex = species_idx[i];
            }

            LBL_Rarity.Text = Properties.strings.Rarity;
            LBL_Den.Text = Properties.strings.Den;
            LBL_Game.Text = Properties.strings.Game;
            foreach(var lbl in new Label[]{ LBL_Ability1, LBL_Ability2, LBL_Ability3, LBL_Ability4, LBL_Ability5 })
            {
                lbl.Text = Properties.strings.Ability;
            }
            foreach (var lbl in new Label[] { LBL_Nature1, LBL_Nature2, LBL_Nature3, LBL_Nature4, LBL_Nature5 })
            {
                lbl.Text = Properties.strings.Nature;
            }
            foreach (var lbl in new Label[] { LBL_PKMN1, LBL_PKMN2, LBL_PKMN3, LBL_PKMN4, LBL_PKMN5 })
            {
                lbl.Text = Properties.strings.Pokemon;
            }
            foreach (var lbl in new Label[] { LBL_Characteristic1, LBL_Characteristic2, LBL_Characteristic3, LBL_Characteristic4, LBL_Characteristic5 })
            {
                lbl.Text = Properties.strings.Characteristic;
            }
            foreach (var lbl in new Label[] { LBL_HP1, LBL_HP2, LBL_HP3, LBL_HP4, LBL_HP5 })
            {
                lbl.Text = Properties.strings.HP;
            }
            foreach (var lbl in new Label[] { LBL_ATK1, LBL_ATK2, LBL_ATK3, LBL_ATK4, LBL_ATK5 })
            {
                lbl.Text = Properties.strings.ATK;
            }
            foreach (var lbl in new Label[] { LBL_DEF1, LBL_DEF2, LBL_DEF3, LBL_DEF4, LBL_DEF5 })
            {
                lbl.Text = Properties.strings.DEF;
            }
            foreach (var lbl in new Label[] { LBL_SPA1, LBL_SPA2, LBL_SPA3, LBL_SPA4, LBL_SPA5 })
            {
                lbl.Text = Properties.strings.SPA;
            }
            foreach (var lbl in new Label[] { LBL_SPD1, LBL_SPD2, LBL_SPD3, LBL_SPD4, LBL_SPD5 })
            {
                lbl.Text = Properties.strings.SPD;
            }
            foreach (var lbl in new Label[] { LBL_SPE1, LBL_SPE2, LBL_SPE3, LBL_SPE4, LBL_SPE5 })
            {
                lbl.Text = Properties.strings.SPE;
            }
            LBL_IVDeviation.Text = Properties.strings.IVDeviation;
            GB_41.Text = Properties.strings.Day4Base;
            GB_PKMN1.Text = Properties.strings.Day4;
            GB_51.Text = Properties.strings.Day5;
            GB_61.Text = Properties.strings.Day6;
        }

        private static Bitmap GetNestMap(int x, int y)
        {
            Pen redPen = new Pen(Color.Red, 10);
            var map = Resources.map;
            using (var graphics = Graphics.FromImage(map))
                graphics.DrawArc(redPen, x - 5, y - 5, 15, 15, 0, 360);
            return map;
        }

        private void CB_Den_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!doneLoading) return;
            foreach(ComboBox cb in CB_Species)
            {
                cb.Items.Clear();
            }
            if (CB_Den.SelectedIndex == 0)
            {
                var tables = _raidTables.SwordNestsEvent;
                RaidTemplateTable toUse = Array.Find(tables, table => table.TableID == NestLocations.EventHash);
                int len = toUse.Entries.Length / 5;
                for (int i = 0; i < 5; i++)
                {
                    ComboboxItem item = new ComboboxItem($"{i+1}\u2605 Raid", toUse.Entries[i * len]);
                    foreach (ComboBox cb in CB_Species)
                    {
                        cb.Items.Add(item);
                    }
                }
            }
            else
            {
                RaidTemplateTable toUse = GetTableToUse();
                for (int stars = 0; stars < 5; stars++)
                {
                    foreach (var entry in toUse.Entries)
                    {
                        if(entry.Probabilities[stars] > 0) { 
                            ComboboxItem item = new ComboboxItem($"{GameStrings.Species[entry.Species]} {stars + 1}\u2605 ", entry);
                            for (int spidx=0; spidx < CB_Species.Length; spidx++)
                            {
                                if(spidx > 2 || spidx == 0 && entry.FlawlessIVs <= 3) { 
                                    ComboBox cb = CB_Species[spidx];
                                    cb.Items.Add(item);
                                } 
                            }
                        }
                    }
                }
            }
            foreach (ComboBox cb in CB_Species)
            {
                if(cb.Items.Count > 0) { 
                    cb.SelectedIndex = 0;
                }
            }
        }

        private RaidTemplate[] GetEntriesWithIV(int num)
        {
            RaidTemplateTable tbl = GetTableToUse();
            return tbl.Entries.Where(entry => entry.FlawlessIVs == num).ToArray();
        }

        private RaidTemplateTable GetTableToUse()
        {
            int idx = CB_Den.SelectedIndex - 1;
            if (idx >= 16) idx++;
            var detail = NestLocations.Nests[idx];
            DenMap.BackgroundImage = GetNestMap(detail.MapX, detail.MapY);
            var tables = CB_Game.SelectedIndex == 0 ? _raidTables.SwordNests : _raidTables.ShieldNests;
            if (CB_Rarity.SelectedIndex == 0)
            {
                return Array.Find(tables, table => table.TableID == detail.CommonHash);
            }
            else
            {
                return Array.Find(tables, table => table.TableID == detail.RareHash);
            }
        }

        private void PopulateSpeciesCB(ComboBox species, RaidTemplate[] entries)
        {
            species.Items.Clear();
            var s = GameInfo.Strings;
            for (int stars = 0; stars < 5; stars++)
            {
                foreach (var entry in entries)
                {
                    if (entry.Probabilities[stars] > 0)
                    {
                        ComboboxItem item = new ComboboxItem($"{stars + 1}\u2605 {s.Species[entry.Species]}", entry);
                        species.Items.Add(item);
                    }
                }
            }
            species.SelectedIndex = 0;
        }

        private int[] CheckIVs(ref int[] fixedIVs)
        {
            int[] iv1 = { 0, 0, 0, 0, 0, 0 };
            int minIV = (int)((RaidTemplate)((ComboboxItem)CB_Species[0].SelectedItem).Value).FlawlessIVs;
            int[] fixedIV = { minIV, minIV + 1, minIV + 2 };
            int[] setIVs = { -1, -1, -1, -1, -1, -1, -1, -1};
            int idx1 = 0;
            int idx2 = 0;
            int flawless = 0;
            LB_Response.Text = "";
            LBLAO.Text = "";
            for (int i = 0; i < 6; i++)
            {
                iv1[i] = (int)NUD_Stats[i].Value;
                if (iv1[i] == 31)
                {
                    flawless++;
                }
            }
            if (!GB_42.Enabled && flawless > fixedIV[0])
            {
                LB_Response.Text = "Not enough info.";
                GB_42.Enabled = true;
                PopulateSpeciesCB(CB_Species[1], GetEntriesWithIV(fixedIV[1]));
                return null;
            }
            if (flawless < fixedIV[0])
            {
                RB_2nd.Visible = false;
                RB_3rd.Visible = false;
                GB_42.Enabled = false;
                GB_43.Enabled = false;
                GB_51.Enabled = false;
                GB_61.Enabled = false;
                LB_Response.Text = "Invalid IVs.";
                return null;
            }
            if (GB_42.Enabled && flawless > fixedIV[0])
            {
                for (int i = 0; i < 6; i++)
                {
                    if (iv1[i] != 31)
                    {
                        setIVs[idx2++] = iv1[i];
                    }
                    else
                    {
                        if (31 == (int)NUD_Stats[i + 6].Value)
                        {
                            fixedIVs[idx1++] = i;
                        }
                        else
                        {
                            setIVs[idx2++] = iv1[i];
                        }
                    }
                }
                if (setIVs[4] != -1)
                {
                    RB_2nd.Visible = false;
                    RB_2nd.Checked = true;
                    RB_3rd.Visible = false;
                    GB_51.Enabled = true;
                    GB_61.Enabled = true;
                    GB_42.Enabled = true;
                    GB_43.Enabled = false;
                    LB_Response.Text = "OK!";
                    return setIVs; // we have more than enough information
                } else
                {
                    RB_2nd.Visible = false;
                    RB_2nd.Checked = false;
                    RB_3rd.Visible = false;
                    GB_42.Enabled = false;
                    GB_43.Enabled = false;
                    GB_51.Enabled = false;
                    GB_61.Enabled = false;
                    LB_Response.Text = "NOK!";
                    return setIVs; // we have more than enough information
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    if (iv1[i] == 31)
                    {
                        fixedIVs[idx1++] = i;
                    }
                    else
                    {
                        setIVs[idx2++] = iv1[i];
                    }
                }
            }
            if (flawless == 1)
            {
                RB_2nd.Visible = false;
                RB_3rd.Visible = false;
                GB_42.Enabled = false;
                GB_43.Enabled = false;
                LB_Response.Text = Properties.strings._1ivok;
                GB_51.Enabled = true;
                GB_61.Enabled = true;
                return setIVs;
            }
            RaidTemplate[] entries = GetEntriesWithIV(fixedIV[1]);
            if (entries.Length == 0)
            {
                RB_2nd.Visible = false;
                RB_3rd.Visible = false;
                GB_42.Enabled = false;
                GB_43.Enabled = false;
                GB_51.Enabled = false;
                GB_61.Enabled = false;
                LB_Response.Text = "NOK!";
                return null;
            }
            GB_42.Text = String.Format(Properties.strings.Day4Follow, fixedIV[1]);
            GB_43.Text = String.Format(Properties.strings.Day4Follow, fixedIV[2]);
            int[] iv2 = GetNextIVs(ref fixedIVs, setIVs, fixedIV[1]);
            int unsetIV = 0;
            if(!RB_2nd.Visible || RB_2nd.Checked) { 
                for (int i = 0; i < 6; i++)
                {
                    if (iv2[i] != -1)
                    {
                        if (!GB_42.Enabled)
                        {
                            NUD_Stats[i + 6].Value = iv2[i];
                        }
                    }
                    else
                    {
                        if (GB_42.Enabled)
                        {
                            setIVs[idx2++] = (int)NUD_Stats[i + 6].Value;
                        }
                        unsetIV++;
                    }
                }
                if (!GB_42.Enabled && unsetIV > 0)
                {
                    RB_2nd.Visible = true;
                    RB_3rd.Visible = false;
                    GB_43.Enabled = false;
                    GB_51.Enabled = false;
                    GB_61.Enabled = false;
                    GB_42.Enabled = true;
                    PopulateSpeciesCB(CB_Species[1], entries);
                }
                if(RB_2nd.Visible && RB_2nd.Checked)
                {
                    if (setIVs[4] != -1)
                    {
                        RB_2nd.Visible = true;
                        RB_3rd.Visible = true;
                        GB_51.Enabled = true;
                        GB_61.Enabled = true;
                        GB_42.Enabled = true;
                        GB_43.Enabled = false;
                        LB_Response.Text = "OK!";
                        return setIVs; // we have enough information
                    }
                    else
                    {
                        RB_2nd.Visible = false;
                        RB_3rd.Visible = false;
                        GB_42.Enabled = false;
                        GB_43.Enabled = false;
                        GB_51.Enabled = false;
                        GB_61.Enabled = false;
                        LB_Response.Text = "NOK!";
                        return setIVs; // we have more than enough information
                    }
                }
            }
            entries = GetEntriesWithIV(fixedIV[2]);
            if (entries.Length == 0)
            {
                return null;
            }
            int[] iv3 = GetNextIVs(ref fixedIVs, setIVs, fixedIV[2]);
            int unsetIV2 = 0;
            for (int i = 0; i < 6; i++)
            {
                if (iv3[i] != -1)
                {
                    if (!GB_43.Enabled)
                    {
                        NUD_Stats[i + 6 * 2].Value = iv3[i];
                    }
                }
                else
                {
                    if (GB_43.Enabled)
                    {
                        setIVs[idx2++] = (int)NUD_Stats[i + 6 * 2].Value;
                    }
                    unsetIV2++;
                }
            }
            if (!GB_43.Enabled && unsetIV2 > 0)
            {
                GB_43.Enabled = true;
                PopulateSpeciesCB(CB_Species[2], entries);
            }
            // cannot obtain new info
            if (unsetIV == unsetIV2)
            {
                if (unsetIV == 0)
                {
                    RB_2nd.Visible = false;
                    RB_3rd.Visible = false;
                    GB_42.Enabled = false;
                    GB_43.Enabled = false;
                    GB_51.Enabled = false;
                    GB_61.Enabled = false;
                    LB_Response.Text = "NOK!";
                    return null;
                }
                LBLAO.Text = "OR";
                RB_2nd.Visible = true;
                RB_3rd.Visible = true;
                RB_2nd.Checked = true;
            }
            if (setIVs[4] == -1)
            {
                return null; // not enough information to proceed
            }
            RB_2nd.Visible = true;
            RB_3rd.Visible = true;
            GB_51.Enabled = true;
            GB_61.Enabled = true;
            GB_42.Enabled = false;
            GB_43.Enabled = true;
            LB_Response.Text = "OK!";
            return setIVs; // we have enough information
        }

        private void BT_IVCheck(object sender, EventArgs e)
        {
            int[] res = { -1, -1, -1, -1, -1 };
            CheckIVs(ref res);
        }

        private int[] GetNextIVs(ref int[] fixedIVs, int[] setIVs, int fixedIVNum)
        {
            int[] iv = { -1, -1, -1, -1, -1, -1 };
            int ividx = 0;
            int setividx = 0;
            foreach(int idx in fixedIVs)
            {
                if (idx >= 0) { 
                    iv[idx] = 31;
                    ividx++;
                }
            }
            while (ividx < fixedIVNum && setividx < setIVs.Length)
            {
                int tmp = setIVs[setividx++] & 7;
                if (tmp < 6 && iv[tmp] == -1)
                {
                    iv[tmp] = 31;
                    fixedIVs[ividx++] = tmp;
                }
            }
            for(int i=0; i < 6; i++)
            {
                if (iv[i] == -1 && setividx < setIVs.Length)
                {
                    iv[i] = setIVs[setividx++];
                }
            }
            return iv;
        }

        private void HP1_Enter(object sender, EventArgs e)
        {
            NumericUpDown numbox = (NumericUpDown)sender;
            numbox.Select(0, numbox.Text.Length);
        }

        private void removeCandidates(int characteristic, int[] ivs, ref List<int> candidates)
        {
            int idx = (characteristic + 5) % 6;
            // get possible characteristics
            while (ivs[iv_order[idx]] != 31)
            {
                idx = (idx + 5) % 6;
            }
            while (idx != characteristic)
            {
                candidates.Remove(idx);
                idx = (idx + 5) % 6;
            }
        }

        private void shiftCandidates(ref List<int> candidates)
        {
            for(int i=0; i < candidates.Count; i++)
            {
                candidates[i] = (candidates[i] + 1) % 6;
            }
        }

        private void SearchOneIV(int flawlessIdx)
        {
            int[] iv1 = { -1, -1, -1, -1, -1, -1 };
            int[] iv2 = { -1, -1, -1, -1, -1, -1 };
            int[] iv3 = { -1, -1, -1, -1, -1, -1 };
            int flawless1 = 0;
            int flawless2 = 0;
            int flawless3 = 0;
            RaidTemplate pkmn1 = (RaidTemplate)((ComboboxItem)CB_Species[0].SelectedItem).Value;
            RaidTemplate pkmn2 = (RaidTemplate)((ComboboxItem)CB_Species[3].SelectedItem).Value;
            RaidTemplate pkmn3 = (RaidTemplate)((ComboboxItem)CB_Species[4].SelectedItem).Value;

            for (int i = 0; i < 6; i++)
            {
                iv1[i] = (int)NUD_Stats[i].Value;
                iv2[i] = (int)NUD_Stats[i + 6 * 3].Value;
                iv3[i] = (int)NUD_Stats[i + 6 * 4].Value;
            }

            int ability1 = CB_Ability1.SelectedIndex - 1;
            int ability2 = CB_Ability4.SelectedIndex - 1;
            int ability3 = CB_Ability5.SelectedIndex - 1;

            int characteristics1 = CB_Characteristic1.SelectedIndex - 1;
            int characteristics2 = CB_Characteristic4.SelectedIndex - 1;
            int characteristics3 = CB_Characteristic5.SelectedIndex - 1;

            // calculate seed LSB
            int LSB = -1;
            var candidates = new List<int>();
            candidates.AddRange(new int[] { 0, 1, 2, 3, 4, 5 });
            if (characteristics1 >= 0 && flawless1 > 1)
            {
                removeCandidates(characteristics1, iv1, ref candidates);
            }
            else
            {
                characteristics1 = -1; // ensure its -1
            }
            shiftCandidates(ref candidates);
            if (characteristics2 >= 0 && flawless2 > 1)
            {
                removeCandidates(characteristics2, iv2, ref candidates);
            }
            else
            {
                characteristics2 = -1; // ensure its -1
            }
            shiftCandidates(ref candidates);
            if (characteristics3 >= 0 && flawless3 > 1)
            {
                removeCandidates(characteristics3, iv3, ref candidates);
            }
            else
            {
                characteristics3 = -1; // ensure its -1
            }
            if (candidates.Count == 1)
            {
                LSB = 1 - (candidates[0] & 1);
            } else
            {
                characteristics1 = -1;
            }
            int nature1 = CB_Nature1.SelectedIndex;
            int nature2 = CB_Nature4.SelectedIndex;
            int nature3 = CB_Nature5.SelectedIndex;

            int Gender1 = PersonalTable.SWSH[pkmn1.Species].Gender;
            int Gender2 = PersonalTable.SWSH[pkmn2.Species].Gender;
            int Gender3 = PersonalTable.SWSH[pkmn3.Species].Gender;

            bool noGender1 = Gender1 == 0 || Gender1 > 253;
            bool noGender2 = Gender2 == 0 || Gender2 > 253;
            bool noGender3 = Gender3 == 0 || Gender3 > 253;

            bool HA1 = pkmn1.Ability == 4;
            bool HA2 = pkmn2.Ability == 4;
            bool HA3 = pkmn3.Ability == 4;

            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            SeedSearcher.SetFirstCondition(iv1[0], iv1[1], iv1[2], iv1[3], iv1[4], iv1[5], pkmn1.FlawlessIVs, flawlessIdx, ability1, nature1, characteristics1, noGender1, HA1);
            SeedSearcher.SetNextCondition(iv2[0], iv2[1], iv2[2], iv2[3], iv2[4], iv2[5], pkmn2.FlawlessIVs, ability2, nature2, characteristics2, noGender2, HA2);
            SeedSearcher.SetThirdCondition(iv3[0], iv3[1], iv3[2], iv3[3], iv3[4], iv3[5], pkmn3.FlawlessIVs, ability3, nature3, characteristics3, noGender3, HA3);
            SeedSearcher.SetLSB(LSB);
            SearchImpl(searcher);
        }

        private void BT_Search_Click(object sender, EventArgs e)
        {
            int[] iv1 = { -1, -1, -1, -1, -1, -1 }; // 1 low IV
            int[] iv2 = { -1, -1, -1, -1, -1, -1 }; // 1 mid IV
            int[] iv3 = { -1, -1, -1, -1, -1, -1 }; // 1 high IV
            int[] iv4 = { -1, -1, -1, -1, -1, -1 }; // 2
            int[] iv5 = { -1, -1, -1, -1, -1, -1 }; // 3
            int flawless1 = 0;
            int flawless2 = 0;
            int flawless3 = 0;
            int flawless4 = 0;
            int flawless5 = 0;
            RaidTemplate pkmn1 = null; 
            RaidTemplate pkmn2 = null;
            RaidTemplate pkmn3 = null; 
            RaidTemplate pkmn4 = null; 
            RaidTemplate pkmn5 = null;

            int ability1 = -1;
            int ability2 = -1;
            int ability3 = -1;
            int ability4 = -1;
            int ability5 = -1;

            int nature1 = -1;
            int nature2 = -1;
            int nature3 = -1;
            int nature4 = -1;
            int nature5 = -1;

            int characteristics1 = -1;
            int characteristics2 = -1;
            int characteristics3 = -1;
            int characteristics4 = -1;
            int characteristics5 = -1;

            int fixedIV1 = -1;
            int fixedIV2 = -1;
            int fixedIV3 = -1;
            int fixedIV4 = -1;
            int fixedIV5 = -1;

            bool noGender1 = false;
            bool noGender2 = false;
            bool noGender3 = false;
            bool noGender4 = false;
            bool noGender5 = false;

            bool HA1 = false;
            bool HA2 = false;
            bool HA3 = false;
            bool HA4 = false;
            bool HA5 = false;

            if (GB_41.Enabled)
            {
                pkmn1 = (RaidTemplate)((ComboboxItem)CB_Species[0].SelectedItem).Value;
                ability1 = CB_Ability1.SelectedIndex - 1;
                characteristics1 = CB_Characteristic1.SelectedIndex - 1;
                fixedIV1 = pkmn1.FlawlessIVs;
                nature1 = CB_Nature1.SelectedIndex;
                int Gender = PersonalTable.SWSH[pkmn1.Species].Gender;
                noGender1 = Gender == 0 || Gender > 253;
                HA1 = pkmn1.Ability == 4;
            }

            if (GB_42.Enabled)
            {
                pkmn2 = (RaidTemplate)((ComboboxItem)CB_Species[1].SelectedItem).Value;
                ability2 = CB_Ability2.SelectedIndex - 1;
                characteristics2 = CB_Characteristic2.SelectedIndex - 1;
                fixedIV2 = pkmn2.FlawlessIVs;
                nature2 = CB_Nature2.SelectedIndex;
                int Gender = PersonalTable.SWSH[pkmn2.Species].Gender;
                noGender2 = Gender == 0 || Gender > 253;
                HA2 = pkmn2.Ability == 4;
            }

            if (GB_43.Enabled)
            {
                pkmn3 = (RaidTemplate)((ComboboxItem)CB_Species[2].SelectedItem).Value;
                ability3 = CB_Ability3.SelectedIndex - 1;
                characteristics3 = CB_Characteristic3.SelectedIndex - 1;
                fixedIV3 = pkmn3.FlawlessIVs;
                nature3 = CB_Nature3.SelectedIndex;
                int Gender = PersonalTable.SWSH[pkmn3.Species].Gender;
                noGender3 = Gender == 0 || Gender > 253;
                HA3 = pkmn3.Ability == 4;
            }

            if (GB_51.Enabled)
            {
                pkmn4 = (RaidTemplate)((ComboboxItem)CB_Species[3].SelectedItem).Value;
                ability4 = CB_Ability4.SelectedIndex - 1;
                characteristics4 = CB_Characteristic4.SelectedIndex - 1;
                fixedIV4 = pkmn4.FlawlessIVs;
                nature4 = CB_Nature4.SelectedIndex;
                int Gender = PersonalTable.SWSH[pkmn4.Species].Gender;
                noGender4 = Gender == 0 || Gender > 253;
                HA4 = pkmn4.Ability == 4;
            }

            if (GB_61.Enabled)
            {
                pkmn5 = (RaidTemplate)((ComboboxItem)CB_Species[4].SelectedItem).Value;
                ability5 = CB_Ability5.SelectedIndex - 1;
                characteristics5 = CB_Characteristic5.SelectedIndex - 1;
                fixedIV5 = pkmn5.FlawlessIVs;
                nature5 = CB_Nature5.SelectedIndex;
                int Gender = PersonalTable.SWSH[pkmn5.Species].Gender;
                noGender5 = Gender == 0 || Gender > 253;
                HA5 = pkmn5.Ability == 4;
            }

            for (int i = 0; i < 6; i++)
            {
                iv1[i] = (int)NUD_Stats[i].Value;
                iv2[i] = (int)NUD_Stats[i + 6 * 1].Value;
                iv3[i] = (int)NUD_Stats[i + 6 * 2].Value;
                iv4[i] = (int)NUD_Stats[i + 6 * 3].Value;
                iv5[i] = (int)NUD_Stats[i + 6 * 4].Value;
                if (iv1[i] == 31)
                {
                    flawless1++;
                }
                if (iv2[i] == 31)
                {
                    flawless2++;
                }
                if (iv3[i] == 31)
                {
                    flawless3++;
                }
                if (iv4[i] == 31)
                {
                    flawless4++;
                }
                if (iv5[i] == 31)
                {
                    flawless5++;
                }
            }
            if(GB_41.Enabled && flawless1 < fixedIV1)
            {
                MessageBox.Show("Invalid IV for Pokémon 1.");
                return;
            }
            if (GB_42.Enabled && flawless2 < fixedIV2)
            {
                MessageBox.Show("Invalid IV for Pokémon 2.");
                return;
            }
            if (GB_43.Enabled && flawless3 < fixedIV3)
            {
                MessageBox.Show("Invalid IV for Pokémon 3.");
                return;
            }
            if (GB_51.Enabled && flawless4 < fixedIV4)
            {
                MessageBox.Show("Invalid IV for Pokémon 4.");
                return;
            }
            if (GB_51.Enabled && flawless5 < fixedIV5)
            {
                MessageBox.Show("Invalid IV for Pokémon 5.");
                return;
            }

            // sanity check characteristics
            if (characteristics1 >= 0 && iv1[iv_order[characteristics1]] != 31)
            {
                MessageBox.Show("Invalid Characteristic for Pokémon 1.");
                return;
            }
            if (characteristics2 >= 0 && iv2[iv_order[characteristics2]] != 31)
            {
                MessageBox.Show("Invalid Characteristic for Pokémon 2.");
                return;
            }
            if (characteristics3 >= 0 && iv3[iv_order[characteristics3]] != 31)
            {
                MessageBox.Show("Invalid Characteristic for Pokémon 3.");
                return;
            }
            if (characteristics4 >= 0 && iv4[iv_order[characteristics4]] != 31)
            {
                MessageBox.Show("Invalid Characteristic for Pokémon 4.");
                return;
            }
            if (characteristics5 >= 0 && iv5[iv_order[characteristics5]] != 31)
            {
                MessageBox.Show("Invalid Characteristic for Pokémon 5.");
                return;
            }
            int[] fixedIV = { -1, -1, -1, -1, -1 };
            int[] consecutiveIVs = CheckIVs(ref fixedIV);
            
            if (pkmn1.FlawlessIVs == 1)
            {
                if(fixedIV[0] == -1)
                {
                    MessageBox.Show("Invalid IV for Pokémon 1.");
                    return;
                }
                SearchOneIV(fixedIV[0]);
                return;
            }

            if(consecutiveIVs[4] == -1)
            {
                MessageBox.Show("Invalid IVs for first Pokémon. Use \"Check IVs\" option to check your IVs.");
                return;
            }
            // 2+ search
            // calculate seed LSB
            int LSB = -1;
            var candidates = new List<int>();
            candidates.AddRange(new int[] { 0, 1, 2, 3, 4, 5 });
            if (characteristics1 >= 0 && flawless1 > 1)
            {
                removeCandidates(characteristics1, iv1, ref candidates);
            }
            else
            {
                characteristics1 = -1; // ensure its -1
            }
            if (GB_42.Enabled && characteristics2 >= 0 && flawless2 > 1)
            {
                removeCandidates(characteristics2, iv2, ref candidates);
            }
            else
            {
                characteristics2 = -1; // ensure its -1
            }
            if (GB_43.Enabled && characteristics3 >= 0 && flawless3 > 1)
            {
                removeCandidates(characteristics3, iv3, ref candidates);
            }
            else
            {
                characteristics3 = -1; // ensure its -1
            }
            shiftCandidates(ref candidates);
            if (characteristics4 >= 0 && flawless4 > 1)
            {
                removeCandidates(characteristics4, iv4, ref candidates);
            }
            else
            {
                characteristics4 = -1; // ensure its -1
            }
            shiftCandidates(ref candidates);
            if (characteristics5 >= 0 && flawless5 > 1)
            {
                removeCandidates(characteristics5, iv5, ref candidates);
            }
            else
            {
                characteristics5 = -1; // ensure its -1
            }
            if (candidates.Count == 1)
            {
                LSB = 1 - candidates[0] & 1;
                characteristics1 = (candidates[0] + 4) % 6;
            } else
            {
                characteristics1 = -1;
            }

            SeedSearcher searcher = new SeedSearcher(consecutiveIVs[5] == -1 ? SeedSearcher.Mode.Star35_5 : SeedSearcher.Mode.Star35_6);
            SeedSearcher.SetSixFirstCondition(iv1[0], iv1[1], iv1[2], iv1[3], iv1[4], iv1[5], pkmn1.FlawlessIVs, ability1, nature1, characteristics1, noGender1, HA1);
            if(GB_42.Enabled) { 
                SeedSearcher.SetSixSecondCondition(iv2[0], iv2[1], iv2[2], iv2[3], iv2[4], iv2[5], pkmn2.FlawlessIVs, ability2, nature2, characteristics2, noGender2, HA2);
            } else
            {
                SeedSearcher.SetSixSecondCondition(iv3[0], iv3[1], iv3[2], iv3[3], iv3[4], iv3[5], pkmn3.FlawlessIVs, ability3, nature3, characteristics3, noGender3, HA3);
            }

            SeedSearcher.SetSixThirdCondition(iv4[0], iv4[1], iv4[2], iv4[3], iv4[4], iv4[5], pkmn4.FlawlessIVs, ability4, nature4, characteristics4, noGender4, HA4);
            SeedSearcher.SetSixFourthCondition(iv5[0], iv5[1], iv5[2], iv5[3], iv5[4], iv5[5], pkmn5.FlawlessIVs, ability5, nature5, characteristics5, noGender5, HA5);
            SeedSearcher.SetSixLSB(LSB);

            if (consecutiveIVs[5] == -1)
            {
                
                SeedSearcher.SetTargetCondition5(consecutiveIVs[0], consecutiveIVs[1], consecutiveIVs[2], consecutiveIVs[3], consecutiveIVs[4]);
            }
            else
            {
                SeedSearcher.SetTargetCondition6(consecutiveIVs[0], consecutiveIVs[1], consecutiveIVs[2], consecutiveIVs[3], consecutiveIVs[4], consecutiveIVs[5]);
            }

            SearchImpl(searcher);
        }

        async void SearchImpl(SeedSearcher searcher)
        {
            bool[] enabled = { GB_41.Enabled, GB_42.Enabled, GB_43.Enabled, GB_51.Enabled, GB_61.Enabled };
            GB_41.Enabled = false;
            GB_42.Enabled = false;
            GB_43.Enabled = false;
            GB_51.Enabled = false;
            GB_61.Enabled = false;
            GB_Left.Enabled = false;
            BT_newsearch.Enabled = false;
            SeedResult.Text = "";
            int minRerolls = (int) NUD_IVMin.Value;
            int maxRerolls = (int) NUD_IVMax.Value;
            BT_Search.Enabled = false;
            BT_Search.Text = "Searching...";
            // 時間計測
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            await Task.Run(() =>
            {
               searcher.Calculate(minRerolls, maxRerolls, LBL_IVDev);
            });

            stopWatch.Stop();
            LBL_Time.Text = $"{stopWatch.ElapsedMilliseconds} ms";

            BT_Search.Enabled = true;
            BT_Search.Text = "Search";
            // 結果が見つからなかったらエラー
            if (searcher.Result.Count == 0)
            {
                MessageBox.Show("No Seed found. Please increase IV Deviation and run the tool again.");
                //unlock for editing
                GB_41.Enabled = enabled[0];
                GB_42.Enabled = enabled[1];
                GB_43.Enabled = enabled[2];
                GB_51.Enabled = enabled[3];
                GB_61.Enabled = enabled[4];
            }
            else
            {
                for (int i = 0; i < searcher.Result.Count; ++i)
                {
                    SeedResult.Text += $"{searcher.Result[i]:X}\n";
                }
                BT_Table.Enabled = true;
            }
            BT_newsearch.Enabled = true;
        }

        private void CB_Species1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Adjust_Ability(CB_Species1, CB_Ability1);
        }

        private void CB_Species2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Adjust_Ability(CB_Species2, CB_Ability2);
        }

        private void CB_Species3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Adjust_Ability(CB_Species3, CB_Ability3);
        }

        private void CB_Species4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Adjust_Ability(CB_Species4, CB_Ability4);
        }

        private void CB_Species5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Adjust_Ability(CB_Species5, CB_Ability5);
        }

        private void Adjust_Ability(ComboBox species, ComboBox abilityBox)
        {
            var pkm = (RaidTemplate)((ComboboxItem)species.SelectedItem).Value;
            var abilities = PersonalTable.SWSH.GetAbilities(pkm.Species, pkm.AltForm);
            PopulateAbilityList(abilities, pkm.Ability, abilityBox);
            abilityBox.SelectedIndex = 0;
        }

        private static readonly string[] AbilitySuffix = { " (1)", " (2)", " (H)" };

        private void PopulateAbilityList(int[] abilities, int a, ComboBox abilityBox)
        {
            abilityBox.Items.Clear();
            abilityBox.Items.Add(Properties.strings.AbilityNormal);
            for (var i = 0; i < abilities.Length; i++)
            {
                int ability = abilities[i];
                if (a == 3 && abilityBox.Items.Count == 3)
                    break;

                var name = GameStrings.Ability[ability] + AbilitySuffix[i];
                var ab = new ComboboxItem(name, ability);
                abilityBox.Items.Add(ab);
            }
        }

        private void RB_2nd_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_2nd.Checked)
            {
                RB_3rd.Checked = false;
                RB_2nd.Checked = true;
            }
        }

        private void RB_3rd_CheckedChanged(object sender, EventArgs e)
        {
            if(RB_3rd.Checked) { 
                RB_2nd.Checked = false;
                RB_3rd.Checked = true;
            }

        }

        private void NUD_IVMin_ValueChanged(object sender, EventArgs e)
        {
            if(NUD_IVMax.Value < NUD_IVMin.Value)
            {
                NUD_IVMax.Value = NUD_IVMin.Value;
            }
            NUD_IVMax.Minimum = NUD_IVMin.Value;
        }

        private void NUD_IVMax_ValueChanged(object sender, EventArgs e)
        {
            if (NUD_IVMax.Value < NUD_IVMin.Value)
            {
                NUD_IVMin.Value = NUD_IVMax.Value;
            }
            NUD_IVMin.Maximum= NUD_IVMax.Value;
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = 1;
            Properties.Settings.Default.Save();
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            PopulateLanguage(1);
        }

        private void NihongoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = 0;
            Properties.Settings.Default.Save();
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ja-JA");
            PopulateLanguage(0);
        }

        private void BT_newsearch_Click(object sender, EventArgs e)
        {
            BT_Table.Enabled = false;
            GB_41.Enabled = true;
            GB_42.Enabled = false;
            GB_43.Enabled = false;
            GB_51.Enabled = false;
            GB_61.Enabled = false;
            RB_2nd.Checked = false;
            RB_2nd.Visible = false;
            RB_3rd.Visible = false;
            RB_3rd.Checked = false;
            foreach(var nud in NUD_Stats)
            {
                nud.Value = 0;
            }
        }

        private void BT_Table_Click(object sender, EventArgs e)
        {
            var f = new Results(SeedResult.Text, CB_Den, CB_Species4.Items, GameStrings);
            f.Show();
        }
    }
}
