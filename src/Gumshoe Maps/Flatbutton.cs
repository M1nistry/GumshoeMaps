using System.Drawing;
using System.Windows.Forms;

namespace Gumshoe_Maps
{
    class Flatbutton : Button
    {
        public override void NotifyDefault(bool value)
        {
            base.NotifyDefault(false);
        }

        private string _ownerDrawText;
        public string OwnerDrawText
        {
            get { return _ownerDrawText; }
            set { _ownerDrawText = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!string.IsNullOrEmpty(Text) || string.IsNullOrEmpty(_ownerDrawText)) return;
            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(_ownerDrawText, Font, new SolidBrush(ForeColor), ClientRectangle, stringFormat);
        }
    }
}
