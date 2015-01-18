using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Gumshoe_Maps
{
    public partial class Settings : Form
    {
        private Boolean _hoverPaint;
        private readonly Main _main;
        private HSLColor _titleColor;

        #region DLL Import
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

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

            buttonMapHotkey.Text = ((Keys)Properties.Settings.Default.mapHotkey).ToString();
            buttonZanaHotkey.Text = ((Keys)Properties.Settings.Default.zanaHotkey).ToString();
            buttonCartoHotkey.Text = ((Keys)Properties.Settings.Default.cartoHotkey).ToString();

        }

        private void trackBarColor_ValueChanged(object sender, EventArgs e)
        {
            _titleColor = new HSLColor(Color.FromArgb(trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value));
            titlePanel.BackColor = _titleColor;
            _main.titleBar.TitleColor = _titleColor;
            buttonApply.FlatAppearance.BorderColor = _titleColor;
            buttonCancel.FlatAppearance.BorderColor = _titleColor;
        }

        private void trackBarBlue_ValueChanged(object sender, EventArgs e)
        {
            _titleColor = new HSLColor(Color.FromArgb(trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value));
            titlePanel.BackColor = _titleColor;
            _main.titleBar.TitleColor = _titleColor;
            buttonApply.FlatAppearance.BorderColor = _titleColor;
            buttonCancel.FlatAppearance.BorderColor = _titleColor;
        }

        private void trackBarGreen_ValueChanged(object sender, EventArgs e)
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
            base.OnPaint(e);
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonMapHotkey_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine(e.KeyChar);
        }

        private void buttonMapHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            Properties.Settings.Default.mapHotkey = e.KeyValue;
            if (e.KeyCode == Keys.Escape) buttonMapHotkey.Text = ((Keys)Properties.Settings.Default.mapHotkey).ToString();
        }

        private void buttonMapHotkey_Click(object sender, EventArgs e)
        {
            UnregisterHotKey(_main.Handle, 1);
            buttonMapHotkey.Text = String.Empty;

        }


    }
}
