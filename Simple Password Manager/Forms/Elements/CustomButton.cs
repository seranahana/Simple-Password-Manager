using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimplePM.Forms.Elements
{
    public class CustomButton : Control
    {
        public StringFormat SF = new StringFormat();
        public bool MouseEntered = false;
        public bool MousePressed = false;
        private Color BaseColor = Color.Black;
        private Color EnterColor = Color.FromArgb(70, 90, 90, 90);
        private SizeF TextSize;
        public CustomButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            Size = new Size(100, 20);
            Font = new Font("Verdana", 11F, FontStyle.Regular);
            BackColor = Color.Black;
            ForeColor = Color.FromArgb(210, Color.White);
            SF.Alignment = StringAlignment.Near;
            SF.LineAlignment = StringAlignment.Center;
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
            graph.DrawString(Text, Font, new SolidBrush(ForeColor), rectan, SF);
            if (MouseEntered)
            {
                switch (SF.Alignment)
                {
                    case (StringAlignment)0:
                        graph.DrawString(Text, Font, new SolidBrush(Color.White), rectan, SF);
                        Rectangle rectang0 = new Rectangle(1, Height - 3, (int)TextSize.Width - 2, 2);
                        graph.DrawRectangle(new Pen(Color.FromArgb(150, 255, 0, 255)), rectang0);
                        graph.FillRectangle(new SolidBrush(Color.FromArgb(200, 255, 0, 255)), rectang0);
                        break;
                    case (StringAlignment)1:
                        graph.DrawString(Text, Font, new SolidBrush(Color.White), rectan, SF);
                        Rectangle rectang1 = new Rectangle((Width - (int)TextSize.Width) / 2, Height - 3, (int)TextSize.Width, 2);
                        graph.DrawRectangle(new Pen(Color.FromArgb(150, 255, 0, 255)), rectang1);
                        graph.FillRectangle(new SolidBrush(Color.FromArgb(200, 255, 0, 255)), rectang1);
                        break;
                    case (StringAlignment)2:
                        break;
                }
            }
            if (MousePressed)
            {
                switch (SF.Alignment)
                {
                    case (StringAlignment)0:
                        graph.DrawString(Text, Font, new SolidBrush(Color.FromArgb(150, Color.Black)), rectan, SF);
                        Rectangle rectang0 = new Rectangle(1, Height - 3, (int)TextSize.Width - 2, 2);
                        graph.DrawRectangle(new Pen(Color.FromArgb(200, 255, 0, 255)), rectang0);
                        graph.FillRectangle(new SolidBrush(Color.FromArgb(250, 255, 0, 255)), rectang0);
                        break;
                    case (StringAlignment)1:
                        graph.DrawString(Text, Font, new SolidBrush(Color.FromArgb(150, Color.Black)), rectan, SF);
                        Rectangle rectang1 = new Rectangle((Width - (int)TextSize.Width) / 2, Height - 3, (int)TextSize.Width, 2);
                        graph.DrawRectangle(new Pen(Color.FromArgb(200, 255, 0, 255)), rectang1);
                        graph.FillRectangle(new SolidBrush(Color.FromArgb(250, 255, 0, 255)), rectang1);
                        break;
                    case (StringAlignment)2:
                        break;
                }
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseEntered = true;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseEntered = false;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MousePressed = false;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MousePressed = true;
            Invalidate();
        }
    }
}
