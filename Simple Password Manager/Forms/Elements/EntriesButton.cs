using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimplePM.Forms.Elements
{
    public class EntriesButton : Control
    {
        public string NameText { get; set; }
        public string UrlText { get; set; }
        public Font NameFont { get; set; }
        public Font UrlFont { get; set; }
        private StringFormat SFName = new StringFormat();
        private StringFormat SFUrl = new StringFormat();
        public bool MouseEntered = false;
        public bool MousePressed = false;
        private Color BaseColor = Color.Black;
        private Color EnterColor = Color.FromArgb(70, 90, 90, 90);
        private SizeF TextSize;
        public EntriesButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            Location = new Point(0, 0);
            Size = new Size(250, 50);
            NameFont = new Font("Verdana", 11F, FontStyle.Regular);
            UrlFont = new Font("Verdana", 8F, FontStyle.Regular);
            BackColor = Color.Black;
            ForeColor = Color.FromArgb(210, Color.White);
            SFName.Alignment = StringAlignment.Near;
            SFName.LineAlignment = StringAlignment.Near;
            SFUrl.Alignment = StringAlignment.Near;
            SFUrl.LineAlignment = StringAlignment.Far;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            TextSize = graph.MeasureString(Text, Font);
            graph.SmoothingMode = SmoothingMode.HighQuality;
            graph.Clear(Parent.BackColor);
            Rectangle rectan = new Rectangle(0, 0, Width - 1, Height - 1);
            graph.DrawRectangle(new Pen(BackColor), rectan);
            graph.FillRectangle(new SolidBrush(BackColor), rectan);
            graph.DrawString(NameText, NameFont, new SolidBrush(ForeColor), rectan, SFName);
            graph.DrawString(UrlText, UrlFont, new SolidBrush(ForeColor), rectan, SFUrl);
            if (MouseEntered)
            {
                // reserved for future features
            }
            if (MousePressed)
            {
                // reserved for future features
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseEntered = true;
            BackColor = EnterColor;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseEntered = false;
            BackColor = BaseColor;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MousePressed = false;
            BackColor = BaseColor;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MousePressed = true;
            BackColor = EnterColor;
            Invalidate();
        }
    }
}
