using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickerWheel
{
    class PieContainerPanel : Panel
    {
        public float StartAngle { get; set; }
        public float EndAngle { get; set; }
        public float SpinOffset { get; set; }
        public int InputCount { get; set; }
        private string Winner { get; set; }
        public int TargetInput { get; set; }

        public Dictionary<Color, string> PieInfo = new Dictionary<Color, string>();
        public PieContainerPanel(Point loc, Size size)
        {
            TargetInput = -1; // -1 means do nothing
            Winner = "";
            InputCount = 0;
            StartAngle = 0;
            EndAngle = 360;
            SpinOffset = 0;

            DoubleBuffered = true;
            Location = loc;
            Size = size;
            Paint += Panel_Paint;
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            // makes lines look smoother
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Pie Chart Rect Container
            Rectangle rect = new Rectangle(0, 0, Size.Width - 10, Size.Height - 10);

            // Draw the pie chart, if there are inputs of course
            if (InputCount != 0)
            {
                float localStartAngle = StartAngle;
                float localEndAngle = EndAngle;

                // Draw pie
                for (int i = 0; i < InputCount; i++)
                {
                    if ((StartAngle + SpinOffset) % 360 <= 270 & (StartAngle + SpinOffset) % 360 + EndAngle >= 270)
                        Winner = PieInfo.Values.ElementAt(i);
                    SolidBrush brush;
                    brush = new SolidBrush(PieInfo.Keys.ElementAt(i));
                    e.Graphics.FillPie(brush, rect, (StartAngle + SpinOffset) % 360, EndAngle);
                    StartAngle += EndAngle;
                }
                StartAngle = 0;
                //e.Graphics.DrawPie(Pens.Red, rect, StartAngle, EndAngle);

                // Draw Labels
                for (int i = 0; i < InputCount; i++)
                {
                    // Find the center of the rectangle.
                    float cx = (rect.Left + rect.Right) / 2f;
                    float cy = (rect.Top + rect.Bottom) / 2f;
                    float radius = (rect.Width + rect.Height) / 2f * 0.33f;
                    double label_angle = Math.PI * (((localStartAngle + SpinOffset) % 360) + localEndAngle / 2f) / 180f;
                    float x = cx + (float)(radius * Math.Cos(label_angle));
                    float y = cy + (float)(radius * Math.Sin(label_angle));

                    e.Graphics.DrawString(PieInfo.Values.ElementAt(i), new Font("Microsoft JhengHei UI", 12, FontStyle.Bold), Brushes.Black, x, y);
                    localStartAngle += localEndAngle;
                }
            }
            else // if there are no inputs, just draw a blank white circle
                e.Graphics.FillPie(Brushes.White, rect, 0, 360);

            // Draw the pointer
            e.Graphics.FillPolygon(Brushes.Black, new Point[] { new Point((rect.Width / 2) - 5, 0), new Point((rect.Width / 2) + 3, 0), new Point((rect.Width / 2), 70) });
            e.Graphics.DrawPolygon(Pens.Black, new Point[] { new Point((rect.Width / 2) - 5, 0), new Point((rect.Width / 2) + 3, 0), new Point((rect.Width / 2), 70) });
        }
        public void AddPie(string label, Color color)
        {
            InputCount += 1;
            StartAngle = 0;
            EndAngle = 360f / InputCount;

            PieInfo.Add(color, label);
            Invalidate();
        }
        public void RemovePie(string label, Color color)
        {
            InputCount -= 1;
            StartAngle = 0;
            if (InputCount != 0)
                EndAngle = 360f / InputCount;
            else
                EndAngle = 360;

            PieInfo.Remove(color);
            Invalidate();
        }
        public async Task Spin()
        {
            Random rSpin = new Random();
            int speedUp = rSpin.Next(150, 250);
            int slowDown = rSpin.Next(700, 800);
            float TargetInputShiftAmount = 0;
            float currSpin = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < slowDown; i++)
                {
                    if (i < speedUp)
                    {
                        SpinOffset += SpinOffset * 0.02f + 1;
                    }
                    else if (i == speedUp) // end of speeding up
                    {
                        currSpin = SpinOffset;
                        TargetInputShiftAmount = GetShiftAmount(slowDown, speedUp, TargetInput);
                        SpinOffset += TargetInputShiftAmount;
                    } // speed down
                    else
                    {
                        SpinOffset += currSpin * 0.02f;
                        currSpin -= currSpin * 0.02f;
                    }
                    Invalidate();
                    //Thread.Sleep(10);
                }
                StartAngle %= 360;
                SpinOffset %= 360f;
                ShowWheelResult();
            });
        }
        private float GetShiftAmount(int slowDown, int speedUp, int targetInputIndex)
        {
            if (targetInputIndex == -1)
                return 0f;
            Random r = new Random();

            float localSpinfOffset = SpinOffset;
            float currSpin = SpinOffset;
            
            for (int i = 0; i < slowDown - speedUp - 1; i++)
            {
                localSpinfOffset += currSpin * 0.02f;
                currSpin -= currSpin * 0.02f;
            }

            float targetOffset = r.Next(Convert.ToInt32(Math.Floor(EndAngle * .05)), Convert.ToInt32(Math.Floor(EndAngle * .95))); // its position on the target input on the circle
            float ShiftAmount = (270f - ((localSpinfOffset + EndAngle * targetInputIndex) % 360)) - targetOffset; // amount to add to shift to 270 degree position
            return ShiftAmount;
        }
        private void ShowWheelResult()
        {
            MessageBox.Show(Winner);
        }
    }
}
