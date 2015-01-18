using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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
        private readonly SqlDb _sql;
        private BindingSource _mapSource, _dropSource;
        private static Main _main;
        private Settings _settings;
        internal Map _currentMap;
        private string _state;
        private int _timerTicks = 0;

        private Control _focusedControl;

        public Main()
        {
            InitializeComponent();
            _nextClipboardViewer = (IntPtr)SetClipboardViewer((int) Handle);
            _sql = new SqlDb();

            titleBar.TitleColor = Properties.Settings.Default.themeColor;
            titleBar.SettingsClick += Settings_Click;
            titleBar.MinimizeClick += Minimize_Click;
            titleBar.CloseClick += Close_Click;
            RegisterHotKey(Handle, 0, 0x0000, Properties.Settings.Default.mapHotkey);
            RegisterHotKey(Handle, 1, 0x0000, Properties.Settings.Default.zanaHotkey);
            RegisterHotKey(Handle, 2, 0x0000, Properties.Settings.Default.cartoHotkey);
            numericZana.Value = Properties.Settings.Default.zanaQuantity;

            _main = this;

            _mapSource = new BindingSource
            {
                DataSource = _sql.MapDataTable(),
                //Sort ="id DESC"
            };

            dgvMaps.DataSource = _mapSource;
            _state ="WAITING";
        }

        public static Main GetSingleton()
        {
            return _main;
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
                _settings.FormClosed += (o, ea) => _settings = null;
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
            // defined in winuser.h
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;
            const int WM_HOTKEY = 0x0312;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    if (CheckClipboard())
                    {
                        var clipboard = Clipboard.GetText(TextDataFormat.Text);
                        switch (_state)
                        {
                            case("WAITING"):
                                _currentMap = ParseClipboard();
                                if (_currentMap == null) break;
                                labelId.Text = _sql.AddMap(_currentMap).ToString(CultureInfo.InvariantCulture);
                                if (labelId.Text != String.Empty)
                                {
                                    labelMapValue.Text = _currentMap.Name;
                                    panelCurrentMap.Visible = true;
                                    _timerTicks = 0;
                                    timerMap.Start();
                                    _mapSource.DataSource = _sql.MapDataTable();
                                    dgvMaps.DataSource = _mapSource;
                                    labelStatusValue.Text = @"Running a map, listening for map drops...";
                                    _state = "DROPS";
                                }
                                break;

                            case("DROPS"):
                                if (labelId.Text == String.Empty) break;
                                if (clipboard.Contains("Map")) _sql.AddDrop(ParseClipboard(), int.Parse(labelId.Text));
                                if (clipboard.Contains("Currency")) _sql.AddCurrency(int.Parse(labelId.Text), ParseCurrency());
                                if (!clipboard.Contains("Map") && clipboard.Contains("Unique")) _sql.AddUnique(int.Parse(labelId.Text), ParseUnique());

                                break;

                            case ("ZANA"):
                                if (labelId.Text == String.Empty) break;
                                _sql.AddDrop(ParseClipboard(), int.Parse(labelId.Text), 1);
                                break;

                            case ("CARTO"):
                                if (labelId.Text == String.Empty) break;
                                _sql.AddDrop(ParseClipboard(), int.Parse(labelId.Text), 0, 1);
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
                        case (0): //F2
                            timerMap.Stop();
                            _state = "WAITING";
                            labelStatusValue.Text = @"Awaiting a map to be selected to run...";
                            break;

                        case (1): //F3
                            if (_state == "ZANA")
                            {
                                _state = "DROPS";
                                labelStatusValue.Text = @"Running a map, listening for map drops...";
                            }
                            labelStatusValue.Text = @"Zana found, press F3 again once maps have been recorded.";
                            _state = "ZANA";
                            break;
                        case (2): //F4
                            if (_state == "CARTO")
                            {
                                _state = "DROPS";
                                labelStatusValue.Text = @"Running a map, listening for map drops...";
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

        internal bool CheckClipboard()
        {
            var clipboardContents = Clipboard.GetText(TextDataFormat.Text).Replace("\r","").Split(new[] { '\n' });
            return clipboardContents.Length != -1 && clipboardContents[0].StartsWith("Rarity:");
        }

        internal Map ParseClipboard()
        {
            var clipboardContents = Clipboard.GetText(TextDataFormat.Text).Replace("\r","").Split(new [] { '\n' });
            Map newMap;
            if (!Clipboard.GetText(TextDataFormat.Text).Contains("Map")) return null;

            if (clipboardContents[0].Replace("Rarity: ","") =="Normal" || clipboardContents[0].Replace("Rarity: ","") =="Magic")
            {
                newMap = new Map
                {
                    Rarity = clipboardContents[0].Replace("Rarity: ",""),
                    Level = int.Parse(clipboardContents[3].Replace("Map Level:","")),
                    Name = MapName(clipboardContents[1]),
                    Affixes = GetAffixes(clipboardContents),
                };
                if (Clipboard.GetText(TextDataFormat.Text).Contains("Item Quantity:"))
                {
                    newMap.Quantity = int.Parse(clipboardContents[4].Replace("Item Quantity: +","").Replace("% (augmented)",""));
                }
                if (Clipboard.GetText(TextDataFormat.Text).Contains("Quality:"))
                {
                    newMap.Quality = int.Parse(clipboardContents[5].Replace("Quality: +","").Replace("% (augmented)",""));
                }
            }
            else
            {
                newMap = new Map
                {
                    Rarity = clipboardContents[0].Replace("Rarity: ",""),
                    Level = int.Parse(clipboardContents[4].Replace("Map Level:","")),
                    Affixes = GetAffixes(clipboardContents),
                };
                newMap.Name = newMap.Rarity =="Rare" ? MapName(clipboardContents[2]) : MapName(clipboardContents[1]);
                if (Clipboard.GetText(TextDataFormat.Text).Contains("Item Quantity:"))
                {
                    newMap.Quantity = int.Parse(clipboardContents[5].Replace("Item Quantity: +","").Replace("% (augmented)",""));
                }
                if (Clipboard.GetText(TextDataFormat.Text).Contains("Quality:"))
                {
                    newMap.Quality = int.Parse(clipboardContents[6].Replace("Quality: +","").Replace("% (augmented)",""));
                }
            }

            return newMap;
        }

        internal string ParseCurrency()
        {
            var clipboardContents = Clipboard.GetText(TextDataFormat.Text).Replace("\r", "").Split(new[] { '\n' });
            if (clipboardContents[0] != "Rarity: Currency") return "";

            var currency = clipboardContents[1].Replace("Orb", "").Replace("of", "").Replace(" ", "");
            return currency;
        }

        internal string ParseUnique()
        {
            var clipboardContents = Clipboard.GetText(TextDataFormat.Text).Replace("\r", "").Split(new[] { '\n' });
            if (clipboardContents[0] != "Rarity: Unique") return "";

            var item = clipboardContents[1];
            return item;
        }

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
               "Crypt","Dried Lake","Dunes","Dungeon","Grotto","Overgrown Ruin", "Tropical Island",
               "Arcade","Arsenal","Cemetery","Mountain Ledge","Sewer","Thicket", "Wharf","Ghetto",
               "Mud Geyser","Reef","Spider Lair","Springs","Vaal Pyramid", "Catacombs", "Overgrown Shrine",
               "Promenade","Shore","Spider Forest","Tunnel","Bog", "Coves", "Graveyard", "Pier",
               "Underground Sea","Arachnid Nest","Colonnade", "Dry Woods", "Strand", "Temple",
               "Jungle Valley", "Torture Chamber", "Waste Pool", "Mine", "Dry Peninsula", "Canyon",
               "Cells", "Dark Forest", "Gorge", "Maze", "Underground River", "Bazaar", "Necropolis",
               "Plateau", "Crematorium", "Precinct", "Shipyard", "Shrine", "Villa"
            };

            foreach (var x in maps.Where(inputLine.Contains))
            {
                return x;
            }
            return inputLine;
        }

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

        #endregion

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            ChangeClipboardChain(Handle, _nextClipboardViewer);
        }

        private void dgvMaps_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvMaps.SelectedRows.Count <= 0) return;
            var selectedMap = dgvMaps.SelectedRows[0];
            if (selectedMap == null) return;
            _dropSource = new BindingSource
            {
                DataSource = _sql.DropDataTable(int.Parse(selectedMap.Cells["idColumn"].Value.ToString()))
            };
            dgvDrops.DataSource = _dropSource;
        }

        private void dgvMaps_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void panelDgv_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void numericZana_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.zanaQuantity = (int)numericZana.Value;
            Properties.Settings.Default.Save();
        }

        private void timerMap_Tick(object sender, EventArgs e)
        {
            _timerTicks++;
            labelDurationValue.Text = string.Format("{0:00}:{1:00}:{2:00}", _timerTicks / 3600, (_timerTicks / 60) % 60, _timerTicks % 60);
        }

        private void dgvMaps_MouseEnter(object sender, EventArgs e)
        {
            _focusedControl = FindFocusedControl(this);
            dgvMaps.Focus();
        }

        private void dgvMaps_MouseLeave(object sender, EventArgs e)
        {
            if (_focusedControl != null) _focusedControl.Focus();
        }
    }
}
