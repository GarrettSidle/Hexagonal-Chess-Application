using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Hexagonal_Chess
{
    /// <summary>Horizontal slider, green thumb.</summary>
    public class CustomSlider : Control
    {
        // exp scale: left 100, 25% -> 1500, right 5000
        private const double ExpPower = 0.266;

        private int _value = 1500;
        private int _minimum = 100;
        private int _maximum = 5000;
        private bool _dragging;

        private const int TrackHeight = 8;
        private const int ThumbRadius = 12;
        private const int PaddingX = ThumbRadius + 4;

        private static readonly Color TrackColor = Color.FromArgb(200, 210, 200);
        private static readonly Color TrackBorderColor = Color.FromArgb(180, 190, 180);
        private static readonly Color ThumbColor = Color.FromArgb(136, 171, 95);
        private static readonly Color ThumbBorderColor = Color.FromArgb(102, 133, 64);

        public event EventHandler ValueChanged;

        public int Value
        {
            get => _value;
            set => SetValue(value);
        }

        public int Minimum
        {
            get => _minimum;
            set { _minimum = value; SetValue(_value); Invalidate(); }
        }

        public int Maximum
        {
            get => _maximum;
            set { _maximum = value; SetValue(_value); Invalidate(); }
        }

        public CustomSlider()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);
            Cursor = Cursors.Hand;
            BackColor = Color.FromArgb(245, 248, 242);
            Size = new Size(400, 40);
            MinimumSize = new Size(100, 36);
        }

        private void SetValue(int value)
        {
            int v = Math.Max(_minimum, Math.Min(_maximum, value));
            if (v == _value) return;
            _value = v;
            Invalidate();
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>Position [0,1] to value.</summary>
        private int PositionToValue(double t)
        {
            t = Math.Max(0, Math.Min(1, t));
            if (t <= 0) return _minimum;
            if (t >= 1) return _maximum;
            double exponent = Math.Pow(t, ExpPower);
            double ratio = Math.Pow((double)_maximum / _minimum, exponent);
            return (int)Math.Round(_minimum * ratio);
        }

        /// <summary>Value to position [0,1].</summary>
        private double ValueToPosition(int value)
        {
            value = Math.Max(_minimum, Math.Min(_maximum, value));
            if (value <= _minimum) return 0;
            if (value >= _maximum) return 1;
            double ratio = (double)value / _minimum;
            double exponent = Math.Log(ratio) / Math.Log((double)_maximum / _minimum);
            return Math.Pow(exponent, 1.0 / ExpPower);
        }

        private int ValueToX(int value)
        {
            int trackWidth = Width - 2 * PaddingX;
            if (trackWidth <= 0) return PaddingX;
            double t = ValueToPosition(value);
            return PaddingX + (int)(t * trackWidth);
        }

        private int XToValue(int x)
        {
            int trackWidth = Width - 2 * PaddingX;
            if (trackWidth <= 0) return _minimum;
            int rel = x - PaddingX;
            double t = (double)rel / trackWidth;
            return PositionToValue(t);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;
            int thumbX = ValueToX(_value);
            int dist = Math.Abs(e.X - thumbX);
            if (dist <= ThumbRadius + 4)
                _dragging = true;
            else
            {
                SetValue(XToValue(e.X));
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_dragging && e.Button == MouseButtons.Left)
                SetValue(XToValue(e.X));
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
                _dragging = false;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _dragging = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            int yCenter = Height / 2;
            int trackWidth = Width - 2 * PaddingX;
            int trackTop = yCenter - TrackHeight / 2;
            int thumbX = ValueToX(_value);

            // track bg
            int x1 = PaddingX;
            int x2 = PaddingX + trackWidth - TrackHeight;
            using (var path = new GraphicsPath())
            {
                path.AddArc(x1, trackTop, TrackHeight, TrackHeight, 180, 90);
                path.AddArc(x2, trackTop, TrackHeight, TrackHeight, 270, 90);
                path.AddArc(x2, trackTop + TrackHeight - TrackHeight, TrackHeight, TrackHeight, 0, 90);
                path.AddArc(x1, trackTop + TrackHeight - TrackHeight, TrackHeight, TrackHeight, 90, 90);
                path.CloseFigure();
                using (var brush = new SolidBrush(TrackColor))
                    g.FillPath(brush, path);
                using (var pen = new Pen(TrackBorderColor, 1f))
                    g.DrawPath(pen, path);
            }

            // thumb
            int thumbLeft = thumbX - ThumbRadius;
            int thumbTop = yCenter - ThumbRadius;
            using (var brush = new SolidBrush(ThumbColor))
                g.FillEllipse(brush, thumbLeft, thumbTop, ThumbRadius * 2, ThumbRadius * 2);
            using (var pen = new Pen(ThumbBorderColor, 2f))
                g.DrawEllipse(pen, thumbLeft, thumbTop, ThumbRadius * 2, ThumbRadius * 2);
        }
    }
}
