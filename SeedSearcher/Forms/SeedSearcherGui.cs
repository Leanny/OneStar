
using PKHeX.Core;
using PKHeX_Raid_Plugin;
using SeedSearcherGui.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeedSearcherGui
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
        private bool dontChange = false;
        private static readonly int UNDEFINED_ABILITY = -2;
        private static readonly int NORMAL_ABILITY = -1;
        public static readonly int[] ToxtricityAmplifiedNatures = { 0x03, 0x04, 0x02, 0x08, 0x09, 0x13, 0x16, 0x0B, 0x0D, 0x0E, 0x00, 0x06, 0x18 };
        public static readonly int[] ToxtricityLowKeyNatures = { 0x01, 0x05, 0x07, 0x0A, 0x0C, 0x0F, 0x10, 0x11, 0x12, 0x14, 0x15, 0x17 };
        public const int ToxtricityID = 849;

        public SeedSearcherGui()
        {
            InitializeComponent();
            dontChange = true;
            doneLoading = false;
            CB_Game.SelectedIndex = 0;
            CB_Rarity.SelectedIndex = 0;
            CB_Species = new ComboBox[] { CB_Species1, CB_Species2, CB_Species3, CB_Species4, CB_Species5 };
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
            RB_2nd.Checked = false;
            RB_3rd.Checked = false;

            LB_Response.Text = "";
            LBLAO.Text = "";
            doneLoading = true;

            foreach (var field in CB_Nature)
            {
                field.SelectedIndex = 0;
            }
            foreach (var field in CB_Characteristic)
            {
                field.SelectedIndex = 0;
            }
            BT_Table.Enabled = false;
            CB_Den.SelectedIndex = 1;
            if (Properties.Settings.Default.Language == 0)
            {
                NihongoToolStripMenuItem_Click(null, null);
            }
            else
            {
                englishToolStripMenuItem_Click(null, null);
            }
            dontChange = false;

            ToolStripMenuItem cpu = new ToolStripMenuItem();
            this.acceleratorToolStripMenuItem.DropDownItems.Add(cpu);
            cpu.CheckOnClick = true;
            cpu.Name = "cPUToolStripMenuItem";
            cpu.Size = new System.Drawing.Size(224, 26);
            cpu.Text = "CPU";
            var devices = SeedSearcherGPU.UseableGPU();
            int num = 0;
            foreach(var device in devices)
            {
                ToolStripMenuItem gpu = new ToolStripMenuItem();
                this.acceleratorToolStripMenuItem.DropDownItems.Add(gpu);
                gpu.CheckOnClick = true;
                gpu.Name = "GPUToolStripMenuItem" + device.Name;
                gpu.Size = new System.Drawing.Size(224, 26);
                gpu.Text = device.Name;
                num++;
            }
            ((ToolStripMenuItem)this.acceleratorToolStripMenuItem.DropDownItems[num]).Checked = true;
            if(num > 0)
            {
                NUD_IVMax.Value = 10;
            }
        }

        private void PopulateNature(ComboBox cb)
        {
            int old_idx = cb.SelectedIndex;
            cb.Items.Clear();
            for (int i = 0; i < GameStrings.natures.Length; i++)
            {
                cb.Items.Add(new ComboboxItem(GameStrings.natures[i], i));
            }
            cb.SelectedIndex = old_idx;
        }

        private void PopulateLanguage(int l)
        {
            dontChange = true;
            GameStrings = GameInfo.GetStrings(l);
            foreach (var cb in CB_Nature)
            {
                PopulateNature(cb);
            }
            foreach (var cb in CB_Characteristic)
            {
                int old_idx = cb.SelectedIndex;
                cb.Items.Clear();
                cb.Items.Add(Properties.strings.Unknown);
                for (int i = 1; i < GameStrings.characteristics.Length; i += 5)
                {
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
                Properties.strings.Dusty4, Properties.strings.Dusty5, Properties.strings.Dusty6, Properties.strings.Dusty7, Properties.strings.Dusty8, Properties.strings.Giant11,
                Properties.strings.Dusty9, Properties.strings.Giant21, Properties.strings.Giant31, Properties.strings.Giant41, Properties.strings.Giant51, Properties.strings.Hammerlocke1,
                Properties.strings.Hammerlocke2, Properties.strings.Hammerlocke3, Properties.strings.Hammerlocke4, Properties.strings.Hammerlocke5, Properties.strings.Hammerlocke6,
                Properties.strings.Hammerlocke7, Properties.strings.Giant12, Properties.strings.Giant22, Properties.strings.Giant32, Properties.strings.Giant42, Properties.strings.Giant52,
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

            for (int i = 0; i < CB_Species.Length; i++)
            {
                if(CB_Species[i].Items.Count > 0) 
                { 
                    CB_Species[i].SelectedIndex = species_idx[i];
                }
            }

            LBL_Rarity.Text = Properties.strings.Rarity;
            LBL_Den.Text = Properties.strings.Den;
            LBL_Game.Text = Properties.strings.Game;
            foreach (var lbl in new Label[] { LBL_Ability1, LBL_Ability2, LBL_Ability3, LBL_Ability4, LBL_Ability5 })
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
            dontChange = false;
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
            int idx = CB_Den.SelectedIndex - 1;
            int nestIdx;
            if (idx == -1)
            {
                nestIdx = -1;
            }
            else
            {
                if (idx >= 16) idx++;
                RaidTemplateTable[] tables = CB_Game.SelectedIndex == 0 ? _raidTables.SwordNests : _raidTables.ShieldNests;
                var detail = NestLocations.Nests[idx];
                DenMap.BackgroundImage = GetNestMap(detail.MapX, detail.MapY);

                if (CB_Rarity.SelectedIndex == 0)
                {
                    nestIdx = Array.FindIndex(tables, table => table.TableID == detail.CommonHash);
                }
                else
                {
                    nestIdx = Array.FindIndex(tables, table => table.TableID == detail.RareHash);
                }
            }
            CB_Nest.SelectedIndex = nestIdx + 1;
        }

        private RaidTemplate[] GetEntriesWithIV(int num)
        {
            RaidTemplateTable tbl = GetTableToUse();
            return tbl.Entries.Where(entry => entry.FlawlessIVs == num).ToArray();
        }

        private RaidTemplateTable GetTableToUse()
        {
            int idx = CB_Nest.SelectedIndex - 1;
            RaidTemplateTable[] tables;
            if (idx == -1)
            {
                tables = CB_Game.SelectedIndex == 0 ? _raidTables.SwordNestsEvent : _raidTables.ShieldNestsEvent;
                return tables[0];
            }
            tables = CB_Game.SelectedIndex == 0 ? _raidTables.SwordNests : _raidTables.ShieldNests;
            return tables[idx];
        }

        private void PopulateSpeciesCB(ComboBox species, RaidTemplate[] entries)
        {
            species.Items.Clear();
            if(entries[0].Species == (int) PKHeX.Core.Species.Ditto)
            {
                List<string> used = new List<string>();
                // special case to make it distinguishable
                for (int stars = 0; stars < 5; stars++)
                {
                    foreach (var entry in entries)
                    {
                        if (entry.Probabilities[stars] > 0)
                        {
                            string s = $"{entry.FlawlessIVs}IV {GameStrings.Species[entry.Species]} {stars + 1}\u2605";
                            if(!used.Contains(s)) { 
                                ComboboxItem item = new ComboboxItem(s, entry);
                                species.Items.Add(item);
                                used.Add(s);
                            }
                        }
                    }
                }
            } else
            {
                for (int stars = 0; stars < 5; stars++)
                {
                    foreach (var entry in entries)
                    {
                        if (entry.Probabilities[stars] > 0)
                        {
                            string gmax = "";
                            if (entry.IsGigantamax)
                            {
                                gmax = "(G-Max)";
                            }
                            ComboboxItem item = new ComboboxItem($"{GameStrings.Species[entry.Species]} {gmax} {stars + 1}\u2605", entry);
                            species.Items.Add(item);
                        }
                    }
                }
            }
            species.SelectedIndex = 0;
        }

        private static void ChangeGroupBoxColor(GroupBox gb, Color col)
        {
            if (col == Color.White) return;
            List<Color> lstColour = new List<Color>();
            foreach (Control c in gb.Controls)
                lstColour.Add(c.ForeColor);

            gb.ForeColor = col;

            int index = 0;
            foreach (Control c in gb.Controls)
            {
                c.ForeColor = lstColour[index];
                index++;
            }
        }

        static Color[] colors = new Color[]{ Color.White, Color.White, Color.White, Color.White, Color.Orange, Color.Blue, Color.Green, Color.White, Color.White, Color.White };

        private int[] CheckIVs(ref int[] fixedIVs)
        {
            int[] iv1 = { 0, 0, 0, 0, 0, 0 };
            int minIV = ((RaidTemplate)((ComboboxItem)CB_Species[0].SelectedItem).Value).FlawlessIVs;
            int[] fixedIV = { minIV, minIV + 1, minIV + 2 };
            int[] setIVs = { -1, -1, -1, -1, -1, -1, -1, -1 };
            int idx1 = 0;
            int idx2 = 0;
            int flawless = 0;
            LB_Response.Text = "";
            LBLAO.Text = "";
            int set2 = 0;
            int set3 = 0;
            bool firstTime = !RB_2nd.Checked && !RB_3rd.Checked;
            // ensure good color
            foreach (var nud in NUD_Stats)
            {
                nud.BackColor = Color.White;
                nud.Enabled = true;
            }

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
                if(flawless == 1) { 
                    LB_Response.Text = "Not enough info.";
                    GB_42.Enabled = true;
                    PopulateSpeciesCB(CB_Species[1], GetEntriesWithIV(fixedIV[1]));
                    return null;
                } else
                {
                    LB_Response.Text = "Please use a different Pokémon.";
                    return null;

                }
            }
            if (flawless < fixedIV[0])
            {
                RB_2nd.Visible = false;
                RB_3rd.Visible = false;
                GB_42.Enabled = false;
                GB_43.Enabled = false;
                GB_51.Enabled = false;
                GB_61.Enabled = false;
                LB_Response.Text = "Too many IVs are at 31. Please use a different Pokémon.";
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
                if (setIVs[3] != -1)
                {
                    RB_2nd.Visible = false;
                    RB_2nd.Checked = true;
                    RB_3rd.Visible = false;
                    GB_51.Enabled = true;
                    GB_61.Enabled = true;
                    GB_42.Enabled = true;
                    GB_43.Enabled = false;
                    LB_Response.Text = "OK!";
                    GB_PKMN1.Enabled = false;
                    checkSeedToolStripMenuItem.Enabled = true;
                    return setIVs; // we have more than enough information
                }
                else
                {
                    RB_2nd.Visible = false;
                    RB_2nd.Checked = false;
                    RB_3rd.Checked = false;
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
                checkSeedToolStripMenuItem.Enabled = true;
                return setIVs;
            }
            RaidTemplate[] entries = GetEntriesWithIV(fixedIV[1]);
            int[] iv2 = GetNextIVs(ref fixedIVs, setIVs, fixedIV[1]);
            int unsetIV = 0;
            bool settwo = entries.Length > 0;
            int lateAdd = 0;
            if (entries.Length > 0)
            {
                if (fixedIVs[fixedIV[0]] == -1)
                {
                    RB_2nd.Visible = false;
                    RB_3rd.Visible = false;
                    RB_2nd.Checked = false;
                    RB_3rd.Checked = false;
                    GB_42.Enabled = false;
                    GB_43.Enabled = false;
                    GB_51.Enabled = false;
                    GB_61.Enabled = false;
                    LB_Response.Text = "NOK!";
                    return setIVs; // we cannot get more information
                }

                if (!RB_2nd.Visible || RB_2nd.Checked)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (iv2[i] != -1)
                        {
                            if (!GB_42.Enabled)
                            {
                                NUD_Stats[i + 6].Value = iv2[i];
                            }
                            NUD_Stats[i + 6].Enabled = false;
                        }
                        else
                        {
                            if (GB_42.Enabled)
                            {
                                setIVs[idx2++] = (int)NUD_Stats[i + 6].Value;
                                lateAdd++;
                            } else
                            {
                                NUD_Stats[i + 6].BackColor = Color.Red;
                            }
                            unsetIV++;
                        }
                    }

                    GB_42.Text = String.Format(Properties.strings.Day4Follow, fixedIV[1], idx2 + unsetIV - lateAdd);
                    ChangeGroupBoxColor(GB_42, colors[idx2 + unsetIV - lateAdd]);
                    set2 = idx2 + unsetIV;
                    if (set2 - lateAdd == 3)
                    {
                        settwo = false;
                    }
                    else
                    {
                        if (!GB_42.Enabled && lateAdd == 0)
                        {
                            RB_2nd.Visible = true;
                            RB_3rd.Visible = false;
                            GB_43.Enabled = false;
                            GB_51.Enabled = false;
                            GB_61.Enabled = false;
                            GB_42.Enabled = true;
                            PopulateSpeciesCB(CB_Species[1], entries);
                        }
                        if (RB_2nd.Visible && RB_2nd.Checked)
                        {
                            if (setIVs[3] != -1)
                            {
                                RB_2nd.Visible = true;
                                RB_3rd.Visible = true;
                                GB_51.Enabled = true;
                                GB_61.Enabled = true;
                                GB_42.Enabled = true;
                                GB_43.Enabled = false;
                                LB_Response.Text = "OK!";
                                GB_PKMN1.Enabled = false;
                                checkSeedToolStripMenuItem.Enabled = true;
                                return setIVs; // we have enough information
                            }
                            else
                            {
                                RB_2nd.Visible = false;
                                RB_3rd.Visible = false;
                                RB_2nd.Checked = false;
                                RB_3rd.Checked = false;
                                GB_42.Enabled = false;
                                GB_43.Enabled = false;
                                GB_51.Enabled = false;
                                GB_61.Enabled = false;
                                LB_Response.Text = "NOK!";
                                return null; // we have more than enough information
                            }
                        }
                    }
                }
            }

            entries = GetEntriesWithIV(fixedIV[2]);
            if (entries.Length == 0)
            {
                if(!settwo)
                {
                    RB_2nd.Visible = false;
                    RB_3rd.Visible = false;
                    RB_2nd.Checked = false;
                    RB_3rd.Checked = false;
                    GB_42.Enabled = false;
                    GB_43.Enabled = false;
                    GB_51.Enabled = false;
                    GB_61.Enabled = false;
                    LB_Response.Text = "NOK!";
                }
                return setIVs;
            }
            int[] iv3 = GetNextIVs(ref fixedIVs, setIVs, fixedIV[2]);
            int unsetIV2 = 0;
            lateAdd = 0;
            for (int i = 0; i < 6; i++)
            {
                if (iv3[i] != -1)
                {
                    if (!GB_43.Enabled)
                    {
                        NUD_Stats[i + 6 * 2].Value = iv3[i];
                        NUD_Stats[i + 6 * 2].Enabled = false;
                    }
                }
                else
                {
                    if (GB_43.Enabled)
                    {
                        setIVs[idx2++] = (int)NUD_Stats[i + 6 * 2].Value;
                        lateAdd++;
                    }
                    else
                    {
                        NUD_Stats[i + 6 * 2].BackColor = Color.Red;
                    }
                    unsetIV2++;
                }
            }
            if(6 - fixedIV[2] < unsetIV2)
            {
                if(!settwo)
                {
                    RB_2nd.Visible = false;
                    RB_3rd.Visible = false;
                    RB_2nd.Checked = false;
                    RB_3rd.Checked = false;
                    GB_42.Enabled = false;
                    GB_43.Enabled = false;
                    GB_51.Enabled = false;
                    GB_61.Enabled = false;
                    LB_Response.Text = "NOK!";
                    return null;
                }
                return setIVs;
            }
            GB_43.Text = String.Format(Properties.strings.Day4Follow, fixedIV[2], idx2 + unsetIV2 - lateAdd);
            ChangeGroupBoxColor(GB_43, colors[idx2 + unsetIV2 - lateAdd]);
            set3 = idx2 + unsetIV2;
            if (!GB_43.Enabled && lateAdd == 0)
            {
                GB_43.Enabled = true;
                PopulateSpeciesCB(CB_Species[2], entries);
            }
            // cannot obtain new info
            if (unsetIV == unsetIV2)
            {
                if (unsetIV == 0 && setIVs[3] == -1)
                {
                    RB_2nd.Visible = false;
                    RB_3rd.Visible = false;
                    RB_2nd.Checked = false;
                    RB_3rd.Checked = false;
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
            }
            if (setIVs[4] == -1 && firstTime)
            {
                if(settwo) { 
                    LBLAO.Text = "OR";
                    GB_42.Enabled = true;
                }
                GB_43.Enabled = true;
                RB_2nd.Checked = true;
                RB_3rd.Visible = true;
                if (settwo && set2 >= set3)
                {
                    RB_2nd.Checked = true;
                }
                else
                {
                    RB_3rd.Checked = true;
                }
                return null; // not enough information to proceed
            }
            if (settwo)
            {
                LB_Response.Text = "OK!";
                GB_PKMN1.Enabled = false;
                RB_2nd.Visible = true;
            }
            RB_3rd.Visible = true;
            GB_51.Enabled = true;
            GB_61.Enabled = true;
            GB_42.Enabled = false;
            GB_43.Enabled = true;
            checkSeedToolStripMenuItem.Enabled = true;
            return setIVs; // we have enough information
        }

        private void BT_IVCheck(object sender, EventArgs e)
        {
            int[] res = { -1, -1, -1, -1, -1 };
            dontChange = true;
            CheckIVs(ref res);
            dontChange = false;
        }

        private int[] GetNextIVs(ref int[] fixedIVs, int[] setIVs, int fixedIVNum)
        {
            int[] iv = { -1, -1, -1, -1, -1, -1 };
            int ividx = 0;
            int setividx = 0;
            foreach (int idx in fixedIVs)
            {
                if (idx >= 0)
                {
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
            for (int i = 0; i < 6; i++)
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
            for (int i = 0; i < candidates.Count; i++)
            {
                candidates[i] = (candidates[i] + 1) % 6;
            }
        }

        private SeedSearcher SearchOneIV(int flawlessIdx)
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

            int ability1 = (int)((ComboboxItem)CB_Ability1.SelectedItem).Value; ;
            int ability2 = (int)((ComboboxItem)CB_Ability4.SelectedItem).Value; ;
            int ability3 = (int)((ComboboxItem)CB_Ability5.SelectedItem).Value; ;

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
                LSB = candidates[0] & 1;
                characteristics1 = candidates[0];
            }
            else
            {
                if (candidates.Count == 0)
                {
                    var result = Util.Prompt(MessageBoxButtons.YesNo, "Entered characteristics seem to be wrong. This might increase the search time. Do you want to start the search anyway?");
                    if (result == DialogResult.No)
                    {
                        return null;
                    }
                }
                characteristics1 = -1;
            }
            int nature1 = (int)((ComboboxItem)CB_Nature1.SelectedItem).Value;
            int nature2 = (int)((ComboboxItem)CB_Nature4.SelectedItem).Value;
            int nature3 = (int)((ComboboxItem)CB_Nature5.SelectedItem).Value;

            int Gender1 = PersonalTable.SWSH[pkmn1.Species].Gender;
            int Gender2 = PersonalTable.SWSH[pkmn2.Species].Gender;
            int Gender3 = PersonalTable.SWSH[pkmn3.Species].Gender;

            bool noGender1 = Gender1 == 0 || Gender1 > 253;
            bool noGender2 = Gender2 == 0 || Gender2 > 253;
            bool noGender3 = Gender3 == 0 || Gender3 > 253;

            bool HA1 = pkmn1.Ability == 4 || pkmn1.Ability == 2;
            bool HA2 = pkmn2.Ability == 4 || pkmn1.Ability == 2;
            bool HA3 = pkmn3.Ability == 4 || pkmn1.Ability == 2;

            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterPokemon1(iv1[0], iv1[1], iv1[2], iv1[3], iv1[4], iv1[5], pkmn1.FlawlessIVs, ability1, nature1, characteristics1, pkmn1.Species, pkmn1.AltForm, noGender1, HA1, flawlessIdx);
            searcher.RegisterPokemon2(iv2[0], iv2[1], iv2[2], iv2[3], iv2[4], iv2[5], pkmn2.FlawlessIVs, ability2, nature2, characteristics2, pkmn2.Species, pkmn2.AltForm, noGender2, HA2);
            searcher.RegisterPokemon3(iv3[0], iv3[1], iv3[2], iv3[3], iv3[4], iv3[5], pkmn3.FlawlessIVs, ability3, nature3, characteristics3, pkmn3.Species, pkmn3.AltForm, noGender3, HA3);
            searcher.RegisterLSB(LSB);
            return searcher;
        }

        private int GetAcceleratorIdx()
        {
            int res = 0;
            int idx = 0;
            foreach(ToolStripMenuItem item in acceleratorToolStripMenuItem.DropDownItems)
            {
                if(item.Checked)
                {
                    res = idx;
                }
                idx++;
            }
            return res - 1;

        }

        private void BT_Search_Click(object sender, EventArgs e)
        {
            SeedSearcher searcher = CheckInput();
            if (searcher != null)
            {
                int[] fixedIV = { -1, -1, -1, -1, -1 };
                dontChange = true;
                int[] consecutiveIVs = CheckIVs(ref fixedIV);
                dontChange = false;
                SearchImpl(searcher, consecutiveIVs);
            }
        }

        private SeedSearcher CheckInput()
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
            GB_PKMN1.Enabled = true;

            if (GB_41.Enabled)
            {
                pkmn1 = (RaidTemplate)((ComboboxItem)CB_Species[0].SelectedItem).Value;
                ability1 = (int)((ComboboxItem)CB_Ability1.SelectedItem).Value;
                characteristics1 = CB_Characteristic1.SelectedIndex - 1;
                fixedIV1 = pkmn1.FlawlessIVs;
                nature1 = (int)((ComboboxItem)CB_Nature1.SelectedItem).Value;
                int Gender = PersonalTable.SWSH[pkmn1.Species].Gender;
                noGender1 = Gender == 0 || Gender > 253;
                HA1 = pkmn1.Ability == 4 || pkmn1.Ability == 2;
            }

            if (GB_42.Enabled)
            {
                pkmn2 = (RaidTemplate)((ComboboxItem)CB_Species[1].SelectedItem).Value;
                ability2 = (int)((ComboboxItem)CB_Ability2.SelectedItem).Value;
                characteristics2 = CB_Characteristic2.SelectedIndex - 1;
                fixedIV2 = pkmn2.FlawlessIVs;
                nature2 = (int)((ComboboxItem)CB_Nature2.SelectedItem).Value;
                int Gender = PersonalTable.SWSH[pkmn2.Species].Gender;
                noGender2 = Gender == 0 || Gender > 253;
                HA2 = pkmn2.Ability == 4 || pkmn2.Ability == 2;
            }

            if (GB_43.Enabled)
            {
                pkmn3 = (RaidTemplate)((ComboboxItem)CB_Species[2].SelectedItem).Value;
                ability3 = (int)((ComboboxItem)CB_Ability3.SelectedItem).Value;
                characteristics3 = CB_Characteristic3.SelectedIndex - 1;
                fixedIV3 = pkmn3.FlawlessIVs;
                nature3 = (int)((ComboboxItem)CB_Nature3.SelectedItem).Value;
                int Gender = PersonalTable.SWSH[pkmn3.Species].Gender;
                noGender3 = Gender == 0 || Gender > 253;
                HA3 = pkmn3.Ability == 4 || pkmn3.Ability == 2;
            }

            if (GB_51.Enabled)
            {
                pkmn4 = (RaidTemplate)((ComboboxItem)CB_Species[3].SelectedItem).Value;
                ability4 = (int)((ComboboxItem)CB_Ability4.SelectedItem).Value;
                characteristics4 = CB_Characteristic4.SelectedIndex - 1;
                fixedIV4 = pkmn4.FlawlessIVs;
                nature4 = (int)((ComboboxItem)CB_Nature4.SelectedItem).Value;
                int Gender = PersonalTable.SWSH[pkmn4.Species].Gender;
                noGender4 = Gender == 0 || Gender > 253;
                HA4 = pkmn4.Ability == 4 || pkmn4.Ability == 2;
            } else
            {
                return null;
            }

            if (GB_61.Enabled)
            {
                pkmn5 = (RaidTemplate)((ComboboxItem)CB_Species[4].SelectedItem).Value;
                ability5 = (int)((ComboboxItem)CB_Ability5.SelectedItem).Value;
                characteristics5 = CB_Characteristic5.SelectedIndex - 1;
                fixedIV5 = pkmn5.FlawlessIVs;
                nature5 = (int)((ComboboxItem)CB_Nature5.SelectedItem).Value;
                int Gender = PersonalTable.SWSH[pkmn5.Species].Gender;
                noGender5 = Gender == 0 || Gender > 253;
                HA5 = pkmn5.Ability == 4 || pkmn5.Ability == 2;
            }
            else
            {
                return null;
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
            if (GB_41.Enabled && flawless1 < fixedIV1)
            {
                MessageBox.Show("Invalid IV for Pokémon 1 (Day 4).");
                return null;
            }
            if (GB_42.Enabled && flawless2 < fixedIV2)
            {
                MessageBox.Show("Invalid IV for Pokémon 2 (Day 4).");
                return null;
            }
            if (GB_43.Enabled && flawless3 < fixedIV3)
            {
                MessageBox.Show("Invalid IV for Pokémon 3 (Day 4).");
                return null;
            }
            if (GB_51.Enabled && flawless4 < fixedIV4)
            {
                MessageBox.Show("Invalid IV for Pokémon 4 (Day 5).");
                return null;
            }
            if (GB_51.Enabled && flawless5 < fixedIV5)
            {
                MessageBox.Show("Invalid IV for Pokémon 5 (Day 6).");
                return null;
            }

            // sanity check characteristics
            if (characteristics1 >= 0 && iv1[iv_order[characteristics1]] != 31)
            {
                MessageBox.Show("Invalid Characteristic for Pokémon 1.");
                return null;
            }
            if (characteristics2 >= 0 && iv2[iv_order[characteristics2]] != 31)
            {
                MessageBox.Show("Invalid Characteristic for Pokémon 2.");
                return null;
            }
            if (characteristics3 >= 0 && iv3[iv_order[characteristics3]] != 31)
            {
                MessageBox.Show("Invalid Characteristic for Pokémon 3.");
                return null;
            }
            if (characteristics4 >= 0 && iv4[iv_order[characteristics4]] != 31)
            {
                MessageBox.Show("Invalid Characteristic for Pokémon 4.");
                return null;
            }
            if (characteristics5 >= 0 && iv5[iv_order[characteristics5]] != 31)
            {
                MessageBox.Show("Invalid Characteristic for Pokémon 5.");
                return null;
            }
            int[] fixedIV = { -1, -1, -1, -1, -1 };
            dontChange = true;
            int[] consecutiveIVs = CheckIVs(ref fixedIV);
            GB_PKMN1.Enabled = true;
            dontChange = false;
            if (pkmn1.FlawlessIVs == 1)
            {
                if (fixedIV[0] == -1)
                {
                    MessageBox.Show("Invalid IV for Pokémon 1.");
                    return null;
                }
                return SearchOneIV(fixedIV[0]);
            }

            if (consecutiveIVs[3] == -1)
            {
                MessageBox.Show("Invalid IVs for first Pokémon. Use \"Check IVs\" option to check your IVs.");
                return null;
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
                LSB = candidates[0] & 1;
                characteristics1 = (candidates[0] + 4) % 6;
            }
            else
            {
                if (candidates.Count == 0)
                {
                    var result = Util.Prompt(MessageBoxButtons.YesNo, "Entered characteristics seem to be wrong. This might increase the search time. Do you want to start the search anyway?");
                    if (result == DialogResult.No)
                    {
                        return null;
                    }
                }
                characteristics1 = -1;
            }

            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterPokemon1(iv1[0], iv1[1], iv1[2], iv1[3], iv1[4], iv1[5], pkmn1.FlawlessIVs, ability1, nature1, characteristics1, pkmn1.Species, pkmn1.AltForm, noGender1, HA1);
            if (GB_42.Enabled)
            {
                searcher.RegisterPokemon2(iv2[0], iv2[1], iv2[2], iv2[3], iv2[4], iv2[5], pkmn2.FlawlessIVs, ability2, nature2, characteristics2, pkmn2.Species, pkmn2.AltForm, noGender2, HA2);
            }
            else
            {
                searcher.RegisterPokemon2(iv3[0], iv3[1], iv3[2], iv3[3], iv3[4], iv3[5], pkmn3.FlawlessIVs, ability3, nature3, characteristics3, pkmn3.Species, pkmn3.AltForm, noGender3, HA3);
            }

            searcher.RegisterPokemon3(iv4[0], iv4[1], iv4[2], iv4[3], iv4[4], iv4[5], pkmn4.FlawlessIVs, ability4, nature4, characteristics4, pkmn4.Species, pkmn4.AltForm, noGender4, HA4);
            searcher.RegisterPokemon4(iv5[0], iv5[1], iv5[2], iv5[3], iv5[4], iv5[5], pkmn5.FlawlessIVs, ability5, nature5, characteristics5, pkmn5.Species, pkmn5.AltForm, noGender5, HA5);
            searcher.RegisterLSB(LSB);
            return searcher;
        }

        async void SearchImpl(SeedSearcher searcher, int[] target = null)
        {
            bool[] enabled = { GB_41.Enabled, GB_42.Enabled, GB_43.Enabled, GB_51.Enabled, GB_61.Enabled };
            GB_41.Enabled = false;
            GB_42.Enabled = false;
            GB_43.Enabled = false;
            GB_51.Enabled = false;
            GB_61.Enabled = false;
            MenuBar.Enabled = false;
            GB_Left.Enabled = false;
            BT_newsearch.Enabled = false;
            SeedResult.Text = "";
            int minRerolls = (int)NUD_IVMin.Value;
            int maxRerolls = (int)NUD_IVMax.Value;
            BT_Search.Enabled = false;
            BT_Search.Text = "Searching...";
            // 時間計測
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            await Task.Run(() =>
            {
                searcher.Calculate(GetAcceleratorIdx(), minRerolls, maxRerolls, target, LBL_IVDev);
            });

            stopWatch.Stop();
            LBL_Time.Text = $"{stopWatch.ElapsedMilliseconds} ms";

            BT_Search.Enabled = true;
            BT_Search.Text = "Search";

            SystemSounds.Asterisk.Play();
            if (SeedSearcher.Result.Count == 0)
            {
                MessageBox.Show("No Seed found. Please increase IV Deviation and run the tool again.");
                //unlock for editing
                GB_41.Enabled = enabled[0];
                GB_42.Enabled = enabled[1];
                GB_43.Enabled = enabled[2];
                GB_51.Enabled = enabled[3];
                GB_61.Enabled = enabled[4];
                MenuBar.Enabled = true;
            }
            else
            {
                for (int i = 0; i < SeedSearcher.Result.Count; ++i)
                {
                    SeedResult.Text += $"{SeedSearcher.Result[i]:X}\n";
                }
                BT_Table.Enabled = true;
            }
            BT_newsearch.Enabled = true;
        }

        private void CB_Species1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Adjust_Ability(CB_Species1, CB_Ability1);
            PopulateNature(CB_Nature1);
            PopulateToxtricityNature(CB_Nature1, CB_Species1);
        }

        private void PopulateToxtricityNature(ComboBox nature, ComboBox species)
        {
            var item = (RaidTemplate) ((ComboboxItem)species.SelectedItem).Value;
            if(item.Species == ToxtricityID)
            {
                List<ComboboxItem> toxNatures = new List<ComboboxItem>();
                var natures = item.AltForm == 0 ? ToxtricityAmplifiedNatures : ToxtricityLowKeyNatures;
                foreach(ComboboxItem natureEntry in nature.Items)
                {
                    if(natures.Contains((int)natureEntry.Value))
                    {
                        toxNatures.Add(natureEntry);
                    }
                }
                nature.Items.Clear();
                nature.Items.AddRange(toxNatures.ToArray());
                nature.SelectedIndex = 0;
            }
        }

        private void CB_Species2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dontChange)
            {
                RB_2nd.Checked = true;
            }
            Adjust_Ability(CB_Species2, CB_Ability2);
            PopulateNature(CB_Nature2);
            PopulateToxtricityNature(CB_Nature2, CB_Species2);
        }

        private void CB_Species3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dontChange)
            {
                RB_3rd.Checked = true;
            }
            Adjust_Ability(CB_Species3, CB_Ability3);
            PopulateNature(CB_Nature3);
            PopulateToxtricityNature(CB_Nature3, CB_Species3);
        }

        private void CB_Species4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Adjust_Ability(CB_Species4, CB_Ability4);
            PopulateNature(CB_Nature4);
            PopulateToxtricityNature(CB_Nature4, CB_Species4);
        }

        private void CB_Species5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Adjust_Ability(CB_Species5, CB_Ability5);
            PopulateNature(CB_Nature5);
            PopulateToxtricityNature(CB_Nature5, CB_Species5);
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

            // case 1: only one ability
            if (a < 3)
            {
                int ability = abilities[a];
                var name = GameStrings.Ability[ability];
                var ab = new ComboboxItem(name, UNDEFINED_ABILITY);
                abilityBox.Items.Add(ab);
            } else
            {
                if((a == 3 && abilities[0] == abilities[1]) ||
                    (a == 4 && abilities[0] == abilities[1] && abilities[0] == abilities[2]))
                {
                    // one ability only
                    int ability = abilities[0];
                    var name = GameStrings.Ability[ability];
                    var ab = new ComboboxItem(name, NORMAL_ABILITY);
                    abilityBox.Items.Add(ab);
                } else
                {
                    if(abilities[0] == abilities[1])
                    {
                        int ability = abilities[0];
                        var name = GameStrings.Ability[ability];
                        var ab = new ComboboxItem(name, NORMAL_ABILITY);
                        abilityBox.Items.Add(ab);
                    } else
                    {
                        for (var i = 0; i < 2; i++)
                        {
                            int ability = abilities[i];
                            var name = GameStrings.Ability[ability] + AbilitySuffix[i];
                            var ab = new ComboboxItem(name, i);
                            abilityBox.Items.Add(ab);
                        }
                    }
                    int hiddenability = abilities[2];
                    var haname = GameStrings.Ability[hiddenability] + AbilitySuffix[2];
                    var haab = new ComboboxItem(haname, 2);
                    abilityBox.Items.Add(haab);
                }

            }
        }

        private void RB_2nd_CheckedChanged(object sender, EventArgs e)
        {
            if (!dontChange && RB_2nd.Checked)
            {
                RB_3rd.Checked = false;
                RB_2nd.Checked = true;
            }
        }

        private void RB_3rd_CheckedChanged(object sender, EventArgs e)
        {
            if (!dontChange && RB_3rd.Checked)
            {
                RB_2nd.Checked = false;
                RB_3rd.Checked = true;
            }

        }

        private void NUD_IVMin_ValueChanged(object sender, EventArgs e)
        {
            if (NUD_IVMax.Value < NUD_IVMin.Value)
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
            NUD_IVMin.Maximum = NUD_IVMax.Value;
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

        private void RefreshUI()
        {
            if (!doneLoading) return;
            dontChange = true;
            checkSeedToolStripMenuItem.Enabled = false;
            GB_Left.Enabled = true;
            BT_Table.Enabled = false;
            GB_41.Enabled = true;
            MenuBar.Enabled = true;
            GB_42.Enabled = false;
            GB_PKMN1.Enabled = true;
            GB_43.Enabled = false;
            GB_51.Enabled = false;
            GB_61.Enabled = false;
            RB_2nd.Checked = false;
            RB_2nd.Visible = false;
            RB_3rd.Visible = false;
            RB_3rd.Checked = false;
            foreach (var nud in NUD_Stats)
            {
                nud.Value = 0;
                nud.BackColor = Color.White;
                nud.Enabled = true;
            }
            foreach (var cb in CB_Species)
            {
                if (cb.Items.Count > 0)
                {
                    cb.SelectedIndex = 0;
                }
            }
            foreach (var cb in CB_Characteristic)
            {
                cb.SelectedIndex = 0;
            }
            foreach (var cb in CB_Nature)
            {
                cb.SelectedIndex = 0;
            }
            SeedResult.Text = "";
            SeedSearcher.ResetSearcher();
            dontChange = false;
        }

        private void BT_newsearch_Click(object sender, EventArgs e)
        {
            var result = Util.Prompt(MessageBoxButtons.YesNo, "Do you really want to start a new search?");
            if (result == DialogResult.No)
            {
                return;
            }
            RefreshUI();
        }

        private void BT_Table_Click(object sender, EventArgs e)
        {
            var f = new Results(SeedResult.Text, CB_Den, CB_Species4.Items, GameStrings);
            f.Show();
        }

        private void checkSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeedSearcher searcher = CheckInput();
            if (searcher != null)
            {
                string UserAnswer = Microsoft.VisualBasic.Interaction.InputBox("Enter Seed you want to check.", "Enter Seed", "0");
                ulong seed = 0;
                try
                {
                    seed = ulong.Parse(UserAnswer, System.Globalization.NumberStyles.HexNumber);
                }
                catch (System.FormatException ex)
                {
                    Util.Prompt(MessageBoxButtons.OK, "Invalid Seed Number");
                }
                var res = searcher.TestInputSeed(seed);
                switch (res)
                {
                    case 0:
                        Util.Prompt(MessageBoxButtons.OK, "Characteristics do not match.");
                        return;
                    case 1:
                        Util.Prompt(MessageBoxButtons.OK, "First Pokémon (Day4) does not match");
                        return;
                    case 2:
                        Util.Prompt(MessageBoxButtons.OK, "Second Pokémon (Day4) does not match");
                        return;
                    case 3:
                        Util.Prompt(MessageBoxButtons.OK, "Third Pokémon (Day5) does not match");
                        return;
                    case 4:
                        Util.Prompt(MessageBoxButtons.OK, "Fourth Pokémon (Day6) does not match");
                        return;
                    case 5:
                        Util.Prompt(MessageBoxButtons.OK, "Seed matches.");
                        return;
                }
            }
        }

        private void HP3_ValueChanged(object sender, EventArgs e)
        {
            if (!dontChange)
            {
                if(sender is NumericUpDown) { 
                    var s = (NumericUpDown)sender;
                    s.BackColor = Color.White;
                }
                RB_3rd.Checked = true;
            }
        }

        private void HP2_ValueChanged(object sender, EventArgs e)
        {
            if (!dontChange)
            {
                if (sender is NumericUpDown)
                {
                    var s = (NumericUpDown)sender;
                    s.BackColor = Color.White;
                }
                RB_2nd.Checked = true;
            }
        }

        private void CB_Nest_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshUI();
            dontChange = true;
            PopulateMons();
            dontChange = false;
        }

        private void PopulateMons()
        {
            if (!doneLoading) return;
            foreach (ComboBox cb in CB_Species)
            {
                cb.Items.Clear();
            }
            RaidTemplateTable toUse = GetTableToUse();
            if (toUse.Entries[0].Species == (int)PKHeX.Core.Species.Ditto)
            {
                // special case to make it not so stuffed
                for (int spidx = 0; spidx < CB_Species.Length; spidx++)
                {
                    CB_Species[spidx].Items.Add(new ComboboxItem($"1IV {GameStrings.Species[toUse.Entries[0].Species]}1\u2605", toUse.Entries[0]));
                    CB_Species[spidx].Items.Add(new ComboboxItem($"2IV {GameStrings.Species[toUse.Entries[0].Species]}1\u2605", toUse.Entries[2]));
                    CB_Species[spidx].Items.Add(new ComboboxItem($"2IV {GameStrings.Species[toUse.Entries[0].Species]}2\u2605", toUse.Entries[2]));
                    CB_Species[spidx].Items.Add(new ComboboxItem($"3IV {GameStrings.Species[toUse.Entries[0].Species]}2\u2605", toUse.Entries[4]));
                    CB_Species[spidx].Items.Add(new ComboboxItem($"3IV {GameStrings.Species[toUse.Entries[0].Species]}3\u2605", toUse.Entries[6]));
                    CB_Species[spidx].Items.Add(new ComboboxItem($"3IV {GameStrings.Species[toUse.Entries[0].Species]}4\u2605", toUse.Entries[6]));
                    if (spidx > 2)
                    {
                        CB_Species[spidx].Items.Add(new ComboboxItem($"4IV {GameStrings.Species[toUse.Entries[0].Species]}4\u2605", toUse.Entries[8]));
                        CB_Species[spidx].Items.Add(new ComboboxItem($"4IV {GameStrings.Species[toUse.Entries[0].Species]}5\u2605", toUse.Entries[10]));
                    }
                }
            }
            else
            { 
                for (int stars = 0; stars < 5; stars++)
                {
                    foreach (var entry in toUse.Entries)
                    {
                        if (entry.Probabilities[stars] > 0)
                        {
                            string gmax = "";
                            if (entry.IsGigantamax)
                            {
                                gmax = "(G-Max) ";
                            }
                            ComboboxItem item = new ComboboxItem($"{GameStrings.Species[entry.Species]} {gmax}{stars + 1}\u2605 ", entry);
                            for (int spidx = 0; spidx < CB_Species.Length; spidx++)
                            {
                                if (spidx > 2 || spidx == 0 && entry.FlawlessIVs <= 3)
                                {
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
                if (cb.Items.Count > 0)
                {
                    cb.SelectedIndex = 0;
                }
            }
        }

        private void UncheckToolStripMenuItem_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem ownerItem = e.ClickedItem.OwnerItem as ToolStripMenuItem;
            if (ownerItem != null)
            {
                //uncheck all item
                foreach (ToolStripMenuItem item in ownerItem.DropDownItems)
                {
                    item.Checked = false;
                }
            }
        }

        private void StartIVCalc(object sender, EventArgs e)
        {
            var calc = new IVCalculator(GameStrings, (RaidTemplate)((ComboboxItem)CB_Species[0].SelectedItem).Value, HP1, ATK1, DEF1, SPA1, SPD1, SPE1);
            calc.Show();
        }
    }
}
