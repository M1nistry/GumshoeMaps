using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gumshoe_Maps
{
    public partial class TitleBar : UserControl
    {

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public TitleBar()
        {
            InitializeComponent();
            titlePanel.BackColor = TitleColor;
            buttonSettings.Visible = SettingsVisible;
            titleLabel.Text = Title;
        }

        public bool SettingsVisible
        {
            get { return buttonSettings.Visible; }
            set { buttonSettings.Visible = value; }
        }

        public string Title
        {
            get { return titleLabel.Text; }
            set { titleLabel.Text = value; }
        }

        public Color TitleColor
        {
            get { return titlePanel.BackColor; } 
            set { titlePanel.BackColor = value;  } 
        }

        public EventHandler SettingsClick, MinimizeClick, CloseClick;

        protected void buttonSettings_Click(object sender, EventArgs e)
        {
            if (SettingsClick != null) SettingsClick(this, e);
        }

        protected void buttonMinimize_Click(object sender, EventArgs e)
        {
            if (MinimizeClick != null) MinimizeClick(this, e);
        }

        protected void buttonClose_Click(object sender, EventArgs e)
        {
            if (CloseClick != null) CloseClick(this, e);
        }

        private void titlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Parent.Handle, 0xA1, 0x2, 0);
        }

        private void titleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Parent.Handle, 0xA1, 0x2, 0);
        }

    }
}
