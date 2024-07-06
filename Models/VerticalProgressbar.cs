using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MinigameOlympia {
    public class VerticalProgressbar : Control {
        private int value = 0;
        private int minimum = 0;
        private int maximum = 100;

        public VerticalProgressbar() {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            ForeColor = Color.Blue;
        }

        public int Value {
            get { return value; }
            set {
                if (value < minimum)
                    value = minimum;
                if (value > maximum)
                    value = maximum;
                this.value = value;
                Invalidate();
            }
        }

        public int Minimum {
            get { return minimum; }
            set {
                minimum = value;
                if (value > maximum)
                    maximum = value;
                if (this.value < minimum)
                    this.value = minimum;
                Invalidate();
            }
        }

        public int Maximum {
            get { return maximum; }
            set {
                maximum = value;
                if (value < minimum)
                    minimum = value;
                if (this.value > maximum)
                    this.value = maximum;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            e.Graphics.Clear(BackColor);
            int height = (int)((float)value / maximum * Height);
            using (SolidBrush brush = new SolidBrush(ForeColor)) {
                e.Graphics.FillRectangle(brush, 0, Height - height, Width, height);
            }
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
        }
    }
}
