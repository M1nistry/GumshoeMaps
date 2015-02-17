using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gumshoe_Maps
{
    public partial class Details : Form
    {
        private readonly Main _main;

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
    }
}
