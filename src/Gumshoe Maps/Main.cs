﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Tesseract;

namespace Gumshoe_Maps
{
    public partial class Main : Form
    {
        #region DLLs

        [DllImport("User32.dll")]
        protected static extern int
        SetClipboardViewer(int hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool
        ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        internal static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        

        #endregion

        IntPtr _nextClipboardViewer;
        public readonly SqlDb _sql;
        public readonly MySqlDb _mySql;
        private BindingSource _mapSource, _dropSource;
        private static Main _main;
        private Settings _settings;
        private Details _details;
        private readonly OcrDownload _ocrDownload;
        internal Map CurrentMap;
        private string _state;
        private int _timerTicks = 0, _mySqlId = 0, _SqLiteId = 0;
        private bool _paintBorder, publicOpt;

        private Control _focusedControl;

        public Main()
        {
            InitializeComponent();
            _nextClipboardViewer = (IntPtr)SetClipboardViewer((int) Handle);
            publicOpt = Properties.Settings.Default.publicOptIn;
            _sql = new SqlDb();
            if (publicOpt) _mySql = new MySqlDb();
            

            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\GumshoeMaps\tessdata\");
            if (Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\GumshoeMaps\tessdata\").Length <= 0)
            {
                _ocrDownload = new OcrDownload();
                _ocrDownload.ShowDialog();
            }
            if (_ocrDownload != null) while (_ocrDownload.Visible) Thread.Sleep(5000);
            titleBar.TitleColor = Properties.Settings.Default.themeColor;
            titleBar.SettingsClick += Settings_Click;
            titleBar.MinimizeClick += Minimize_Click;
            titleBar.CloseClick += Close_Click;
            RegisterHotKey(Handle, 0, 0x0000, Properties.Settings.Default.mapHotkey);
            RegisterHotKey(Handle, 1, 0x0000, Properties.Settings.Default.zanaHotkey);
            RegisterHotKey(Handle, 2, 0x0000, Properties.Settings.Default.cartoHotkey);
            labelZanaValue.Text = Properties.Settings.Default.zanaQuantity.ToString();
            dgvMaps.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.themeColor;
            _main = this;

            RefreshMaps();
            _state ="WAITING";

            contextMenuDgvMaps.ShowImageMargin = false;
            foreach (ToolStripMenuItem menuItem in contextMenuDgvMaps.Items)
            {
                ((ToolStripDropDownMenu)menuItem.DropDown).ShowImageMargin = false;
                menuItem.ForeColor = SystemColors.ControlLight;
            }

            contextMenuDgvMaps.Renderer = new ContextRenderer();

            if (_sql.ExperienceCount() != 100) PopulateExperience();
            if (!PopulateLeagues()) MessageBox.Show(@"Failed to populate leagues! Check your internet connection and try again.", @"Error fetching league data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (listBoxEvents.Items.Contains(Properties.Settings.Default.selectedLeague))
                textBoxLeague.Text = Properties.Settings.Default.selectedLeague;

            if (Properties.Settings.Default.selectedLeague == String.Empty)
                MessageBox.Show(@"Please select your league in the top right before starting any maps", @"Select league",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private bool PopulateLeagues()
        {
            var raceEvents = JsonHandler.ParseJson<JsonEvent[]>("http://api.pathofexile.com/leagues");
            foreach (var league in raceEvents)
            {
                DateTime startAt, finishAt;
                if (league.Id == "Standard" || league.Id == "Hardcore") listBoxEvents.Items.Add(league.Id);
                if (league.StartAt == null || league.EndAt == null) continue;
                if (!DateTime.TryParse(league.StartAt, out startAt) || !DateTime.TryParse(league.EndAt, out finishAt)) continue;
                var diff = finishAt - startAt;
                if (diff.Days > 6 && startAt.Year >= 2015) listBoxEvents.Items.Add(league.Id);
            }
            return listBoxEvents.Items.Count > 0;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            if (_state != "WAITING")
            {
                titleBar.TitleColor = Color.Red;
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
                dgvMaps.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
                dgvMaps.DefaultCellStyle.SelectionBackColor = Color.Red;
                dgvMaps.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.Red;
            }
            else
            {
                titleBar.TitleColor = Properties.Settings.Default.themeColor;
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Properties.Settings.Default.themeColor, ButtonBorderStyle.Solid);
                dgvMaps.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.themeColor;
                dgvMaps.DefaultCellStyle.SelectionBackColor = Properties.Settings.Default.themeColor;
                dgvMaps.AlternatingRowsDefaultCellStyle.SelectionBackColor = Properties.Settings.Default.themeColor;
            }
        }

        public static Main GetSingleton()
        {
            return _main;
        }

        private void PopulateExperience()
        {

            var lines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\Resources\Experience.csv").Select(a => a.Split(','));
            var listExp = new List<Experience>();
            foreach (var line in lines)
            {
                int level, expGoal;
                Int64 experience;
                var exp = new Experience
                {
                    Level = int.TryParse(line[0], out level) ? level : 0,
                    CurrentExperience = Int64.TryParse(line[1], out experience) ? experience : 0,
                    NextLevelExperience = int.TryParse(line[2], out expGoal) ? expGoal : 0
                };
                listExp.Add(exp);
            }
            _sql.AddExperience(listExp);
        }

        #region Title Bar
        protected void Settings_Click(object sender, EventArgs e)
        {
            if (_settings != null && _settings.Visible)
            {
                _settings.Focus();
                _settings.BringToFront();
            }
            else
            {
                _settings = new Settings();
                _settings.FormClosed += (o, ea) =>
                {
                    _settings = null;
                    RegisterHotKey(Handle, 0, 0x0000, Properties.Settings.Default.mapHotkey);
                    RegisterHotKey(Handle, 1, 0x0000, Properties.Settings.Default.zanaHotkey);
                    RegisterHotKey(Handle, 2, 0x0000, Properties.Settings.Default.cartoHotkey);
                };
                _settings.ShowDialog();
            }
        }

        protected void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        protected void Close_Click(object sender, EventArgs e)
        {
            Dispose();
        }


        #endregion

        #region Clipboard/Hotkey

        protected override void WndProc(ref Message m)
        {
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;
            const int WM_HOTKEY = 0x0312;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    if (CheckClipboard())
                    {
                        if (textBoxLeague.Text == String.Empty && Visible)
                        {
                            MessageBox.Show(@"Please verify that you have selected a league and try again.", @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        var clipboard = Clipboard.GetText(TextDataFormat.Text);
                        switch (_state)
                        {
                            case("WAITING"):
                                CurrentMap = ParseClipboard();
                                if (CurrentMap == null) break;
                                CurrentMap.ExpBefore = ExpValue();
                                CurrentMap.League = textBoxLeague.Text;
                                if (publicOpt)
                                {
                                    _mySqlId = _mySql.AddMap(CurrentMap);
                                    labelMySqlId.Text = _mySqlId.ToString(CultureInfo.InvariantCulture);
                                }
                                CurrentMap.SqlId = _mySqlId;
                                _SqLiteId = _sql.AddMap(CurrentMap);
                                labelId.Text = _SqLiteId.ToString();
                                if (labelId.Text != String.Empty)
                                {

                                    labelMapValue.Text = CurrentMap.Name;
                                    panelCurrentMap.Visible = true;
                                    labelExperience.Visible = false;
                                    _timerTicks = 0;
                                    timerMap.Start();
                                    RefreshMaps();

                                    labelStatusValue.Text = @"Running a map, listening for map drops...";
                                    _state = "DROPS";
                                    Refresh();
                                    RefreshDrops();
                                }
                                break;

                            case("DROPS"):
                                if (labelId.Text == String.Empty) break;
                                try
                                {
                                    if (clipboard.Contains("Map"))
                                    {
                                        var parsedMap = ParseClipboard();
                                        if (parsedMap == null) break;
                                        _sql.AddDrop(parsedMap, _SqLiteId);
                                        if (publicOpt && _mySqlId > 0) _mySql.AddDrop(parsedMap, _mySqlId);
                                    }
                                    if (clipboard.Contains("Currency"))
                                    {
                                        var parsedCurrency = ParseCurrency();
                                        _sql.AddCurrency(_SqLiteId, parsedCurrency);
                                        if (publicOpt && _mySqlId > 0) _mySql.AddCurrency(_mySqlId, parsedCurrency);
                                    }
                                    if (!clipboard.Contains("Map") && clipboard.Contains("Unique"))
                                    {
                                        var parsedUnique = ParseUnique();
                                        _sql.AddUnique(_SqLiteId, parsedUnique);
                                        if (publicOpt && _mySqlId > 0) _sql.AddUnique(_mySqlId, parsedUnique);
                                    }
                                }
                                catch (Exception)
                                {
                                    //do nothing
                                }
                                
                                RefreshDrops();
                                break;

                            case ("ZANA"):
                                if (labelId.Text == String.Empty) break;
                                _sql.AddDrop(ParseClipboard(), _SqLiteId, 1);
                                if (publicOpt && _mySqlId > 0) _mySql.AddDrop(ParseClipboard(), _SqLiteId, 1);
                                RefreshDrops();
                                break;

                            case ("CARTO"):
                                if (labelId.Text == String.Empty) break;
                                _sql.AddDrop(ParseClipboard(), int.Parse(labelId.Text), 0, 1);
                                if (publicOpt && _mySqlId > 0) _mySql.AddDrop(ParseClipboard(), _SqLiteId, 0, 1);
                                break;
                        }
                    }
                    SendMessage(_nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                case WM_CHANGECBCHAIN:
                    if (m.WParam == _nextClipboardViewer) _nextClipboardViewer = m.LParam;
                    else SendMessage(_nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case (0):
                            if (_state == "DROPS") { 
                                timerMap.Stop();
                                var expAfter = ExpValue();
                                _sql.FinishMap(_SqLiteId, expAfter);
                                if (publicOpt && _mySqlId > 0) _mySql.FinishMap(_mySqlId, expAfter);
                                _state = "WAITING";
                                var expDiff = expAfter.CurrentExperience - CurrentMap.ExpBefore.CurrentExperience;
                                var expGoal = _sql.ExperienceGoal(CurrentMap.ExpBefore.Level);
                                var percentDiff = (float)expDiff/expGoal;
                                labelExperience.Visible = true;
                                labelExperience.Text = String.Format("Gained {0} xp ({1:P2})", expDiff.ToString("#,##0"), percentDiff);
                                labelStatusValue.Text = @"Awaiting a map to be selected to run...";
                                RefreshMaps();
                                Refresh();
                            }
                            break;

                        case (1):
                            if (_state == "ZANA")
                            {
                                _state = "DROPS";
                                labelStatusValue.Text = @"Running a map, listening for map drops...";
                                break;
                            }
                            labelStatusValue.Text = @"Zana found, press F3 again once maps have been recorded.";
                            _state = "ZANA";
                            break;
                        case (2):
                            if (_state == "CARTO")
                            {
                                _state = "DROPS";
                                labelStatusValue.Text = @"Running a map, listening for map drops...";
                                break;
                            }
                            labelStatusValue.Text = @"Carto found, press F4 again once maps have been recorded.";
                            _state = "CARTO";
                            break;
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        #endregion

        #region Custom Methods

        /// <summary>
        /// Checks the clipboard to determine if it contains PoE Related data or not
        /// </summary>
        /// <returns> TRUE if it contains 'Rarity:' on the first line </returns>
        internal bool CheckClipboard()
        {
            var clipboardContents = Clipboard.GetText(TextDataFormat.Text).Replace("\r","").Split(new[] { '\n' });
            return clipboardContents.Length != -1 && clipboardContents[0].StartsWith("Rarity:");
        }

        /// <summary>
        /// Parses the information gained off the keyboard to construct a Map Object
        /// </summary>
        /// <returns>Map object with details from the clipboard</returns>
        internal Map ParseClipboard()
        {
            var clipboardContents = Clipboard.GetText(TextDataFormat.Text).Replace("\r", "").Split(new[] {'\n'});
            Map newMap;
            if (!Clipboard.GetText(TextDataFormat.Text).Contains("Map")) return null;
            if (Clipboard.GetText(TextDataFormat.Text).Contains("Sacrifice at")) return null;
            if (clipboardContents[0].Replace("Rarity: ", "") == "Normal" || clipboardContents[0].Replace("Rarity: ", "") == "Magic")
            {
                newMap = new Map
                {
                    Rarity = clipboardContents[0].Replace("Rarity: ", ""),
                    Level = int.Parse(clipboardContents[3].Replace("Map Level:", "")),
                    Name = MapName(clipboardContents[1]),
                    Affixes = GetAffixes(clipboardContents),
                };
                if (Clipboard.GetText(TextDataFormat.Text).Contains("Item Quantity:"))
                {
                    newMap.Quantity =
                        int.Parse(clipboardContents[4].Replace("Item Quantity: +", "").Replace("% (augmented)", ""));
                }
                if (Clipboard.GetText(TextDataFormat.Text).Contains("Quality:"))
                {
                    newMap.Quality =
                        int.Parse(clipboardContents[5].Replace("Quality: +", "").Replace("% (augmented)", ""));
                }
                return newMap;
            }
            if (clipboardContents[0].Replace("Rarity: ", "") == "Rare" || clipboardContents[0].Replace("Rarity: ", "") == "Unique")
            {
                var i = 0;
                if (Clipboard.GetText(TextDataFormat.Text).Contains("Unidentified")) i = 1;
                
                newMap = new Map
                {
                    Rarity = clipboardContents[0].Replace("Rarity: ", ""),
                    Level = int.Parse(clipboardContents[4 - i].Replace("Map Level:", "")),
                    Affixes = GetAffixes(clipboardContents),
                };
                newMap.Name = newMap.Rarity == "Rare" ? MapName(clipboardContents[2 - i]) : MapName(clipboardContents[1]);

                if (Clipboard.GetText(TextDataFormat.Text).Contains("Item Quantity:"))
                {
                    newMap.Quantity =
                        int.Parse(clipboardContents[5].Replace("Item Quantity: +", "").Replace("% (augmented)", ""));
                }
                if (Clipboard.GetText(TextDataFormat.Text).Contains("Quality:"))
                {
                    newMap.Quality =
                        int.Parse(clipboardContents[6].Replace("Quality: +", "").Replace("% (augmented)", ""));
                }
                return newMap;
            }
            return null;
        }

        /// <summary>
        /// Parses currency off the clipboard into a KVP of stack size and currency name
        /// </summary>
        /// <returns>Stack Count and Name</returns>
        internal KeyValuePair<int, string> ParseCurrency()
        {
            var clipboardContents = Clipboard.GetText(TextDataFormat.Text).Replace("\r", "").Split(new[] { '\n' });
            if (clipboardContents[0] != "Rarity: Currency") return new KeyValuePair<int, string>(-1, "");

            var currency = clipboardContents[1].Replace("Orb", "").Replace("of", "").Trim();
            var size = Regex.Match(clipboardContents[3].Replace("Stack Size: ", ""), @"^.*?(?=/)");

            return new KeyValuePair<int, string>(int.Parse(size.ToString()), currency);
        }

        /// <summary>
        /// Parses the name out of a unique non-map item off the clipboard
        /// </summary>
        /// <returns>Name of unique item</returns>
        internal string ParseUnique()
        {
            var clipboardContents = Clipboard.GetText(TextDataFormat.Text).Replace("\r", "").Split(new[] { '\n' });
            if (clipboardContents[0] != "Rarity: Unique") return "";

            var item = clipboardContents[1];
            return item;
        }

        /// <summary>
        /// Gets the affixes from the clipboard and puts them into a list
        /// </summary>
        /// <param name="clipboardContents">The map item as it appears on the clipboard</param>
        /// <returns>List containing each parameter</returns>
        private static List<string> GetAffixes(string[] clipboardContents)
        {
            var affixes = new List<string>();
            if (clipboardContents.Count(line => line =="--------") == 4 || clipboardContents.Count(line => line =="--------") == 5)
            {
                var lineCount = 0;
                foreach (var line in clipboardContents)
                {
                    if (line =="--------")
                    {
                        lineCount++;
                        continue;
                    }
                    if (lineCount < 3) continue;
                    if (lineCount == 4) break;
                    affixes.Add(line);
                }
            }
            return affixes;
        }

        /// <summary> Returns the map name given the complete name </summary>
        /// <param name="inputLine"> Line containing map name + affixes</param>
        /// <returns> Map Name eg. "Vaal Pyramid" </returns>
        private static string MapName(string inputLine)
        {
            var maps = new[]
            {
               "Academy", "Crypt","Dried Lake","Dunes","Dungeon","Grotto","Overgrown Ruin", "Tropical Island",
               "Arcade","Arsenal","Cemetery","Mountain Ledge","Sewer","Thicket", "Wharf","Ghetto",
               "Mud Geyser","Reef","Spider Lair","Springs","Vaal Pyramid", "Catacomb", "Overgrown Shrine",
               "Promenade","Shore","Spider Forest","Tunnel","Bog", "Coves", "Graveyard", "Pier",
               "Underground Sea","Arachnid Nest","Colonnade", "Dry Woods", "Strand", "Temple",
               "Jungle Valley", "Torture Chamber", "Waste Pool", "Mine", "Dry Peninsula", "Canyon",
               "Cells", "Dark Forest", "Gorge", "Maze", "Underground River", "Bazaar", "Necropolis",
               "Plateau", "Crematorium", "Precinct", "Shipyard", "Shrine", "Villa", "Palace"
            };

            foreach (var x in maps.Where(inputLine.Contains))
            {
                return x;
            }
            return inputLine;
        }

        /// <summary>
        /// Finds the currently focused control
        /// </summary>
        /// <param name="control"></param>
        /// <returns>control that is currently focused</returns>
        public static Control FindFocusedControl(Control control)
        {
            var container = control as ContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as ContainerControl;
            }
            return control;
        }

        public void HoverBorder(PaintEventArgs e)
        {
            var pen = new Pen(titleBar.TitleColor);
            e.Graphics.DrawRectangle(pen,
                e.ClipRectangle.Left,
                e.ClipRectangle.Top,
                e.ClipRectangle.Width - 1,
                e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void HoverBorderFix(PaintEventArgs e)
        {
            var pen = new Pen(titleBar.TitleColor);
            e.Graphics.DrawLine(pen, 0, 0, 0, 260);
            base.OnPaint(e);
        }

        /// <summary>
        /// Refreshes the drops datagridview
        /// </summary>
        private void RefreshDrops()
        {
            if (labelId.Text == String.Empty) return;
            _dropSource = new BindingSource
            {
                DataSource = _sql.DropDataTable(int.Parse(labelId.Text))
            };
            dgvDrops.DataSource = null;
            dgvDrops.DataSource = _dropSource;
            dgvDrops.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        /// <summary>
        /// Refreshes the map datagridview
        /// </summary>
        private void RefreshMaps()
        {
            _mapSource = new BindingSource
            {
                DataSource = _sql.MapDataTable(),
                Sort = "id DESC"
            };
            dgvMaps.DataSource = _mapSource;
            dgvMaps.Columns["idColumn"].ValueType = typeof(double);
        }

        /// <summary>
        /// Uses OCR to parse the experience from the tooltip. Moves the mouse to the desired position automatically
        /// </summary>
        /// <returns>The string containing the full experience tooltip</returns>
        private string CaptureExp()
        {
            Cursor = new Cursor(Cursor.Current.Handle);
            var previousPoint = Cursor.Position;
            Cursor.Position = new Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height);
            Cursor.Clip = new Rectangle(Cursor.Position, new Size(1, 1));
            Thread.Sleep(750);
            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                                           Screen.PrimaryScreen.Bounds.Height,
                                                           PixelFormat.Format32bppArgb);
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(MousePosition.X + 35, MousePosition.Y - 60, 0, 0, new Size(580, 500), CopyPixelOperation.SourceCopy);
            bmpScreenshot.Save("Screenshot.bmp");

            var image = Pix.LoadFromFile(Directory.GetCurrentDirectory() + "\\Screenshot.bmp");
            string result;
            var tessData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\GumshoeMaps";
            using (var engine = new TesseractEngine(tessData, "eng", EngineMode.Default))
            {
                using (var page = engine.Process(image))
                {
                    result = page.GetText();
                }

            }
            File.Delete(Directory.GetCurrentDirectory() + "\\Screenshot.bmp");
            Cursor.Clip = Rectangle.Empty;
            Cursor.Position = new Point(previousPoint.X, previousPoint.Y);
            return result;
        }

        /// <summary>
        /// Parses the captured experience into the Experience object
        /// </summary>
        /// <returns>Experience object containing all the details</returns>
        internal Experience ExpValue()
        {
            var exp = CaptureExp();
            var currentPercent = Regex.Match(exp, @"(?<=\().+?(?=\%)");
            var currentLevel = Regex.Match(exp, @"(?<=el ).+?(?=\ )");
            var currentExperience = Regex.Match(exp, @"(?<=p: ).+?(?=\ )");
            var nextLevel = Regex.Match(exp.Replace("\n", ""), @"(?<=l: ).+?(?=$)");
            int level, percent;
            Int64 currentExp, expToLevel;
            var expObj = new Experience
            {
                Level = currentLevel.Success ? int.TryParse(currentLevel.Groups[0].ToString(), out level) ? level : 0 : 0,
                Percentage = currentPercent.Success ? int.TryParse(currentPercent.Groups[0].ToString(), out percent) ? percent : 0 : 0,
                CurrentExperience = currentExperience.Success ? Int64.TryParse(currentExperience.Groups[0].ToString().Replace(",",""), out currentExp) ? currentExp : 0 : 0,
                NextLevelExperience = nextLevel.Success ? Int64.TryParse(nextLevel.Groups[0].ToString().Replace(",",""), out expToLevel) ? expToLevel : 0 : 0
            };
            return expObj;
        }

        #endregion

        #region context menu

        internal class ContextRenderer : ToolStripProfessionalRenderer
        {
            public ContextRenderer() : base(new MyColors()) { }
        }

        internal class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return new HSLColor(Properties.Settings.Default.themeColor); }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return new HSLColor(Properties.Settings.Default.themeColor); }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return new HSLColor(Properties.Settings.Default.themeColor); }
            }
            public override Color MenuItemBorder
            {
                get { return new HSLColor(Properties.Settings.Default.themeColor); }
            }
        }

        #endregion
        
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            ChangeClipboardChain(Handle, _nextClipboardViewer);
        }

        private void dgvMaps_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMaps.SelectedRows.Count != 1) return;
            labelId.Text = dgvMaps.SelectedRows[0].Cells["idColumn"].Value.ToString();
            RefreshDrops();
        }

        private void panelDgv_Paint(object sender, PaintEventArgs e)
        {
            if (_paintBorder) HoverBorder(e);
        }

        private void timerMap_Tick(object sender, EventArgs e)
        {
            _timerTicks++;
            labelDurationValue.Text = string.Format("{0:00}:{1:00}:{2:00}", _timerTicks / 3600, (_timerTicks / 60) % 60, _timerTicks % 60);
        }

        private void dgvMaps_MouseEnter(object sender, EventArgs e)
        {
            _paintBorder = true;
            panelDgv.Refresh();
            panelDgvRight.Refresh();
            _focusedControl = FindFocusedControl(this);
            dgvMaps.Focus();
        }

        private void dgvMaps_MouseLeave(object sender, EventArgs e)
        {
            if (_paintBorder)
            {
                _paintBorder = false;
                panelDgv.Refresh();
                panelDgvRight.Refresh();
            }
            if (_focusedControl != null) _focusedControl.Focus();
        }

        private void dgvDrops_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != 0 && e.ColumnIndex != 1) return;
            var selectedId = dgvMaps.SelectedRows[0].Cells["idColumn"].Value.ToString();
            var mapToolTip = _sql.MapList(int.Parse(selectedId));
            var tooltipText = mapToolTip.Aggregate("", (current, item) => current + (item.Key + " - " + item.Value + Environment.NewLine));
            dgvDrops[1, 0].ToolTipText = tooltipText;
        }

        private void dgvMaps_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= 0 || dgvMaps.SelectedRows.Count <= 0) return;
            labelId.Text = dgvMaps.SelectedRows[0].Cells["idColumn"].Value.ToString();
            //RefreshDrops();
        }

        private void panelDgvRight_Paint(object sender, PaintEventArgs e)
        {
            if (_paintBorder) HoverBorderFix(e);
        }

        private void dgvDrops_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvDrops.DefaultCellStyle.SelectionBackColor = dgvDrops.DefaultCellStyle.BackColor;
            dgvDrops.AlternatingRowsDefaultCellStyle.SelectionBackColor = dgvDrops.AlternatingRowsDefaultCellStyle.BackColor;
        }

        private void dgvDrops_MouseEnter(object sender, EventArgs e)
        {
            _paintBorder = true;
            panelDgvExtra.Refresh();
        }

        private void panelDgvExtra_Paint(object sender, PaintEventArgs e)
        {
            if (_paintBorder) HoverBorder(e);
        }

        private void dgvDrops_MouseLeave(object sender, EventArgs e)
        {
            _paintBorder = false;
            panelDgvExtra.Refresh();
        }

        private void dgvMaps_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex != 0) return;
            var selectedId = dgvMaps.Rows[e.RowIndex].Cells["idColumn"].Value.ToString();
            var affixToolTip = _sql.MapAffixes(int.Parse(selectedId));
            var tooltipText = affixToolTip.Aggregate("", (current, affix) => current + (affix + Environment.NewLine));
            dgvMaps.Rows[e.RowIndex].Cells["mapColumn"].ToolTipText = tooltipText;
        }

        private void dgvMaps_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            dgvMaps.ClearSelection();
            dgvMaps.Rows[e.RowIndex].Selected = true;
            contextMenuDgvMaps.Show(MousePosition);
        }

        #region Maps Context Menu

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedId = dgvMaps.SelectedRows[0].Cells["idColumn"].Value;
            var mysqlId = dgvMaps.SelectedRows[0].Cells["mysqlColumn"].Value;
            if (!_sql.DeleteMap(int.Parse(selectedId.ToString()))) return;
            if (publicOpt && _mySqlId > 0) _mySql.DeleteMap(int.Parse(mysqlId.ToString()));
            _mapSource.DataSource = _sql.MapDataTable();
            _mapSource.Sort = "id DESC";
            dgvMaps.DataSource = _mapSource;

        }


        #endregion

        private void buttonZanaUp_Click(object sender, EventArgs e)
        {
            var value = int.Parse(labelZanaValue.Text) + 1;
            labelZanaValue.Text = value.ToString();
            Properties.Settings.Default.zanaQuantity = int.Parse(labelZanaValue.Text);
            Properties.Settings.Default.Save();
        }

        private void buttonZanaDown_Click(object sender, EventArgs e)
        {
            var value = int.Parse(labelZanaValue.Text) - 1;
            labelZanaValue.Text = value.ToString();
            Properties.Settings.Default.zanaQuantity = int.Parse(labelZanaValue.Text);
            Properties.Settings.Default.Save();
        }

        private void dgvMaps_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index != 0) return;
            if (double.Parse(e.CellValue1.ToString()) > double.Parse(e.CellValue2.ToString()))
            {
                e.SortResult = 1;
            }
            else if (double.Parse(e.CellValue1.ToString()) < double.Parse(e.CellValue2.ToString()))
            {
                e.SortResult = -1;
            }
            else
            {
                e.SortResult = 0;
            }
            e.Handled = true;
        }

        private void dgvMaps_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvMaps.Rows)
            {
                switch (row.Cells["columnRarity"].Value.ToString())
                {
                    case ("Normal"):
                        dgvMaps[3, row.Index].Style.ForeColor = SystemColors.ControlLight;
                        break;
                    case ("Magic"):
                        dgvMaps[3, row.Index].Style.ForeColor = Color.CornflowerBlue;
                        break;
                    case ("Rare"):
                        dgvMaps[3, row.Index].Style.ForeColor = Color.Gold;
                        break;
                    case ("Unique"):
                        dgvMaps[3, row.Index].Style.ForeColor = Color.DarkOrange;
                        break;
                }
            }
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvMaps.SelectedRows.Count <= 0) return;
            if (_details != null && _details.Visible)
            {
                _details.Focus();
                _details.BringToFront();
            }
            else
            {
                int mapId;
                _details = new Details();
                _details.MapId = int.TryParse(dgvMaps.SelectedRows[0].Cells["idColumn"].Value.ToString(), out mapId) ? mapId : -1;
                _details.FormClosed += (o, ea) => _details = null;
                _details.ShowDialog();
            }
        }

        #region EventsDropDown
        private void buttonExpandEvents_Click(object sender, EventArgs e)
        {
            buttonExpandEvents.Text = !panelEventsList.Visible ? "↑" : "↓";
            panelEventsList.Visible = !panelEventsList.Visible;

            if (panelEventsList.Visible)
            {
                panelEventsList.Height = (listBoxEvents.Items.Count * 14) + 1;
                listBoxEvents.Height = panelEventsList.Height;
                listBoxEvents.Focus();
            }
            else
            {
                panelEventsList.Height = 0;
            }
        }

        private void listBoxEvents_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index,
                    e.State ^ DrawItemState.Selected, e.ForeColor,
                    Properties.Settings.Default.themeColor);
            e.DrawBackground();
            e.Graphics.DrawString(listBoxEvents.Items[e.Index].ToString(), e.Font, Brushes.FloralWhite, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void listBoxEvents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxEvents.SelectedItems.Count != 1) return;
            textBoxLeague.Text = listBoxEvents.SelectedItem.ToString();
            buttonExpandEvents.PerformClick();
        }

        private void panelEventsList_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panelEventsList.ClientRectangle, Properties.Settings.Default.themeColor, ButtonBorderStyle.Solid);
        }

        private void listBoxEvents_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (listBoxEvents.SelectedItems.Count != 1 && e.KeyChar != (Char)Keys.Enter) return;
            textBoxLeague.Text = listBoxEvents.SelectedItem.ToString();
            buttonExpandEvents.PerformClick();
        }
        #endregion

        private void textBoxSelectedEvent_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.selectedLeague = textBoxLeague.Text;
            Properties.Settings.Default.Save();
        }
    }
}