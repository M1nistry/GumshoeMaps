using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Gumshoe_Maps
{
    public partial class Settings : Form
    {
        private readonly Main _main;
        private HSLColor _titleColor;

        #region DLL Import
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        internal static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        #endregion

        public Settings()
        {
            InitializeComponent();
            _main = Main.GetSingleton();

            _titleColor = new HSLColor(Properties.Settings.Default.themeColor);
            titlePanel.BackColor = _titleColor;
            buttonCancel.FlatAppearance.BorderColor = _titleColor;
            buttonApply.FlatAppearance.BorderColor = _titleColor;

            var rgbValues = Regex.Matches(_titleColor.ToRGBString(), @" \d+");
            trackBarRed.Value = Int32.Parse(rgbValues[0].ToString());
            trackBarGreen.Value = Int32.Parse(rgbValues[1].ToString());
            trackBarBlue.Value = Int32.Parse(rgbValues[2].ToString());
            checkBoxOptIn.Checked = Properties.Settings.Default.publicOptIn;

            if (Properties.Settings.Default.mapHotkey != -1) buttonMapHotkey.Text = ((Keys)Properties.Settings.Default.mapHotkey).ToString();
            if (Properties.Settings.Default.zanaHotkey != -1) buttonZanaHotkey.Text = ((Keys)Properties.Settings.Default.zanaHotkey).ToString();
            if (Properties.Settings.Default.cartoHotkey != -1) buttonCartoHotkey.Text = ((Keys)Properties.Settings.Default.cartoHotkey).ToString();

            UnregisterHotKey(_main.Handle, 0);
            UnregisterHotKey(_main.Handle, 1);
            UnregisterHotKey(_main.Handle, 2);

        }

        private void trackBarColor_ValueChanged(object sender, EventArgs e)
        {
            _titleColor = new HSLColor(Color.FromArgb(trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value));
            titlePanel.BackColor = _titleColor;
            _main.titleBar.TitleColor = _titleColor;
            buttonApply.FlatAppearance.BorderColor = _titleColor;
            buttonCancel.FlatAppearance.BorderColor = _titleColor;
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            _titleColor = Properties.Settings.Default.themeColor;
            _main.titleBar.TitleColor = _titleColor;
            Properties.Settings.Default.Reload();
        }

        #region TitlePanel
        private void titlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 0xA1, 0x2, 0);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.themeColor = Color.FromArgb(trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
            Properties.Settings.Default.Save();
            _main.dgvMaps.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.themeColor;
            _main.Refresh();

            if (Properties.Settings.Default.mapHotkey != -1) RegisterHotKey(_main.Handle, 0, 0x0000, Properties.Settings.Default.mapHotkey);
            if (Properties.Settings.Default.zanaHotkey != -1) RegisterHotKey(_main.Handle, 1, 0x0000, Properties.Settings.Default.zanaHotkey);
            if (Properties.Settings.Default.cartoHotkey != -1) RegisterHotKey(_main.Handle, 2, 0x0000, Properties.Settings.Default.cartoHotkey);
            Dispose();
        }

        public void HoverBorder(PaintEventArgs e)
        {
            var pen = new Pen(_titleColor);
            e.Graphics.DrawRectangle(pen,
                e.ClipRectangle.Left,
                e.ClipRectangle.Top,
                e.ClipRectangle.Width - 1,
                e.ClipRectangle.Height - 1);
            OnPaint(e);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #region Hotkey Buttons

        private void buttonMapHotkey_Click(object sender, EventArgs e)
        {
            buttonMapHotkey.Text = String.Empty;
        }

        private void buttonZanaHotkey_Click(object sender, EventArgs e)
        {
            buttonZanaHotkey.Text = String.Empty;
        }

        private void buttonCartoHotkey_Click(object sender, EventArgs e)
        {
            buttonCartoHotkey.Text = String.Empty;
        }

        private void buttonMapHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                buttonMapHotkey.Text = ((Keys)Properties.Settings.Default.mapHotkey).ToString();
                return;
            }
            if (Properties.Settings.Default.zanaHotkey == e.KeyValue) NullHotkeys(false, true, false);
            if (Properties.Settings.Default.cartoHotkey == e.KeyValue) NullHotkeys(false, false, true);
            Properties.Settings.Default.mapHotkey = e.KeyValue;
            buttonMapHotkey.Text = ((Keys)e.KeyValue).ToString();
        }

        private void buttonZanaHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                buttonZanaHotkey.Text = ((Keys)Properties.Settings.Default.zanaHotkey).ToString();
                return;
            }
            if (Properties.Settings.Default.mapHotkey == e.KeyValue) NullHotkeys(true, false, false);
            if (Properties.Settings.Default.cartoHotkey == e.KeyValue) NullHotkeys(false, false, true);
            Properties.Settings.Default.zanaHotkey = e.KeyValue;
            buttonZanaHotkey.Text = ((Keys)e.KeyValue).ToString();
        }

        private void buttonCartoHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                buttonCartoHotkey.Text = ((Keys)Properties.Settings.Default.cartoHotkey).ToString();
                return;
            }
            if (Properties.Settings.Default.mapHotkey == e.KeyValue) NullHotkeys(true, false, false);
            if (Properties.Settings.Default.zanaHotkey == e.KeyValue) NullHotkeys(false, true, false);
            Properties.Settings.Default.cartoHotkey = e.KeyValue;
            buttonCartoHotkey.Text = ((Keys)e.KeyValue).ToString();
        }

        #endregion

        /// <summary> Removes the values for the hotkey pressed </summary>
        private void NullHotkeys(bool map, bool zana, bool carto)
        {
            if (map)
            {
                Properties.Settings.Default.mapHotkey = -1;
                buttonMapHotkey.Text = String.Empty;
            }
            if (zana)
            {
                Properties.Settings.Default.zanaHotkey = -1;
                buttonZanaHotkey.Text = String.Empty;
            }
            if (!carto) return;
            Properties.Settings.Default.cartoHotkey = -1;
            buttonCartoHotkey.Text = String.Empty;
        }

        private void checkBoxOptIn_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.publicOptIn = checkBoxOptIn.Checked;
        }
    }
}
