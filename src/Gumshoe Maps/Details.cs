using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gumshoe_Maps
{
    public partial class Details : Form
    {
        private readonly Main _main;
        private List<string> _affixes;

        public int MapId { get; set; }

        #region DLL Import
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        internal static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        #endregion

        public Details()
        {
            InitializeComponent();

            _main = Main.GetSingleton();
            Icon = _main.Icon;
            titlePanel.BackColor = Properties.Settings.Default.themeColor;
        }

        private void titlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 0xA1, 0x2, 0);
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void textBoxRarity_Enter(object sender, EventArgs e)
        {
            if (textBoxRarity.Text != @"Rarity") return;
            textBoxRarity.Text = String.Empty;
            textBoxRarity.ForeColor = SystemColors.ControlLight;
            textBoxRarity.TextAlign = HorizontalAlignment.Left;
        }

        private void textBoxRarity_Leave(object sender, EventArgs e)
        {
            if (textBoxRarity.Text != String.Empty) return;
            textBoxRarity.Text = @"Rarity";
            textBoxRarity.ForeColor = SystemColors.ControlDark;
            textBoxRarity.TextAlign = HorizontalAlignment.Center;
        }

        private void textBoxLevel_Enter(object sender, EventArgs e)
        {
            if (textBoxLevel.Text != @"Level") return;
            textBoxLevel.Text = String.Empty;
            textBoxLevel.ForeColor = SystemColors.ControlLight;
            textBoxLevel.TextAlign = HorizontalAlignment.Left;
        }

        private void textBoxLevel_Leave(object sender, EventArgs e)
        {
            if (textBoxLevel.Text != String.Empty) return;
            textBoxLevel.Text = @"Level";
            textBoxLevel.ForeColor = SystemColors.ControlDark;
            textBoxLevel.TextAlign = HorizontalAlignment.Center;
        }

        private void textBoxName_Enter(object sender, EventArgs e)
        {
            if (textBoxName.Text != @"Name") return;
            textBoxName.Text = String.Empty;
            textBoxName.ForeColor = SystemColors.ControlDark;
            textBoxName.TextAlign = HorizontalAlignment.Left;
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (textBoxName.Text != String.Empty) return;
            textBoxName.Text = @"Name";
            textBoxName.ForeColor = SystemColors.ControlLight;
            textBoxName.TextAlign = HorizontalAlignment.Center;
        }

        private void Details_VisibleChanged(object sender, EventArgs e)
        {
            var mapItem = _main._sql.GetMap(MapId);
            var affixString = mapItem.Affixes.Aggregate("", (current, affix) => current + (affix + Environment.NewLine));
            var duration = (mapItem.FinishAt - mapItem.StartAt);
            labelMapDetails.Text = String.Format("Rarity: {0}\r\n{1}\r\nLevel: {2}\r\nQuantity: {3}\r\nQuality: {4}\r\n\r\n{5}\r\n\r\n{6}\r\n{7}", 
                mapItem.Rarity, mapItem.Name, mapItem.Level, mapItem.Quantity, mapItem.Quality, affixString, String.Format("Duration: {0:00}:{1:00}:{2:00}", duration.Hours, duration.Minutes, duration.Seconds));
            textBoxNotes.Text = mapItem.Notes;
        }

        private void textBoxNotes_Enter(object sender, EventArgs e)
        {
            if (textBoxNotes.Text != @"Notes...") return;
            textBoxNotes.Text = String.Empty;
            textBoxNotes.ForeColor = SystemColors.ControlLight;
        }

        private void textBoxNotes_Leave(object sender, EventArgs e)
        {
            if (textBoxNotes.Text != @"Notes...")
            {
                _main._sql.UpdateNotes(MapId, textBoxNotes.Text);
                return;
            }
            textBoxNotes.Text = @"Notes...";
            textBoxNotes.ForeColor = SystemColors.ControlDark;
        }

        private void textBoxNotes_TextChanged(object sender, EventArgs e)
        {
            textBoxName.ForeColor = textBoxNotes.Text == @"Notes..." ? SystemColors.ControlDark : SystemColors.ControlLight;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxRarity.Text != String.Empty)
            {
                int zana = checkBoxZana.Checked ? 1 : 0, carto = checkBoxCarto.Checked ? 1 : 0, level;
                var newMap = new Map
                {
                    Rarity = textBoxRarity.Text,
                    Name = textBoxName.Text,
                    Level = int.TryParse(textBoxLevel.Text, out level) ? level : 0,

                };
                _main._sql.AddDrop(newMap, MapId, zana, carto);
            }
            if (textBoxUnique.Text != String.Empty)
            {
                _main._sql.AddUnique(MapId, textBoxUnique.Text);
            }
            if (textBoxCurrency.Text != String.Empty && labelCurrencyValue.Text != @"0")
            {
                int currencyCount;
                _main._sql.AddCurrency(MapId, new KeyValuePair<int, string>(int.TryParse(labelCurrencyValue.Text, out currencyCount) ? currencyCount : 0, textBoxCurrency.Text));
            }
        }

        private void buttonCurrencyUp_Click(object sender, EventArgs e)
        {
            int count;
            if (int.TryParse(labelCurrencyValue.Text, out count))
            {
                labelCurrencyValue.Text = (count + 1).ToString("#");
            }
        }

        private void buttonCurrencyDown_Click(object sender, EventArgs e)
        {
            int count;
            if (!int.TryParse(labelCurrencyValue.Text, out count)) return;
            if (count == 0) return;
            labelCurrencyValue.Text = (count - 1).ToString("#");
        }
    }
}
