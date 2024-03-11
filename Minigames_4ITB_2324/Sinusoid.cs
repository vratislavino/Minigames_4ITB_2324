using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Minigames_4ITB_2324
{
    public partial class Sinusoid : UserControl, IMinigame
    {
        public Sinusoid()
        {
            InitializeComponent();
        }

        public int Score { get; set; }

        public event Action<int> MinigameEnded;

        Random random = new Random();

        Sinusoida target;
        Sinusoida attempt;
        private int ticksToLose = 300;
        private int currentTicks = 0;
        Timer timer;

        private int xOffset;
        private int yOffset;
        private int plotHeight = 250;
        private int maxX = 600;

        public void StartMinigame()
        {
            xOffset = Width / 80;
            yOffset = Height / 2;

            this.DoubleBuffered = true;
            timer = new Timer();
            timer.Interval = 30;
            timer.Tick += OnTick;
            
            this.Paint += OnPaint;
            this.Click += (a, b) => { Refresh(); };

            target = new Sinusoida(Color.Red, xOffset, yOffset, 9, 9) { MaxX = maxX, plotHeight = plotHeight };
            attempt = new Sinusoida(Color.Blue, xOffset, yOffset, 10, 10) { MaxX = maxX, plotHeight = plotHeight };

            Generate();
            timer.Start();
            Refresh();
        }

        private void OnTick(object? sender, EventArgs e)
        {
            currentTicks++;
            if(currentTicks >= ticksToLose)
            {
                timer.Stop();
                MinigameEnded?.Invoke(Score);
            }

            pictureBox1.Width = (int)(800 * (currentTicks / (double)ticksToLose));
        }

        private void Generate()
        {
            target.frequency = random.Next(1, 10);
            target.amplitude = random.Next(1, 10);
        }

        private void OnPaint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawAxes(e.Graphics);
            target.Draw(e.Graphics);
            attempt.Draw(e.Graphics);
        }

        private void DrawAxes(Graphics g)
        {
            g.DrawLine(Pens.Black, xOffset, yOffset - plotHeight, xOffset, yOffset + plotHeight);
            g.DrawLine(Pens.Black, xOffset, yOffset, xOffset + maxX, yOffset);
        }

        private void Check()
        {
            if(target.frequency == attempt.frequency && target.amplitude == attempt.amplitude)
            {
                Score += 2;
                if(Score == 10)
                {
                    MinigameEnded?.Invoke(Score);
                    timer.Stop();
                } else
                {
                    Generate();
                    currentTicks = 0;
                }
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            attempt.frequency = e.NewValue;
            Refresh();
            Check();

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            attempt.amplitude = e.NewValue;
            Refresh();
            Check();
        }


        class Sinusoida
        {
            public int plotHeight;

            public double amplitude;
            public double frequency;

            public Pen pen;
            public int MaxX;

            public int xOffset;
            public int yOffset;

            public Sinusoida(Color color, int xOffset, int yOffset, double initAmp, double initFreq)
            {
                this.amplitude = initAmp;
                this.frequency = initFreq;
                this.xOffset = xOffset;
                this.yOffset = yOffset;
                this.pen = new Pen(color, 4f);
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            }

            public void Draw(Graphics g)
            {
                Point first = new Point(xOffset, yOffset);

                for (double uhel = 0; uhel < MaxX; uhel++)
                {
                    Point second = new Point(
                        (int)(xOffset + uhel),
                        (int)(yOffset + GetSin(uhel) * (plotHeight / 2))
                        );
                    g.DrawLine(pen, first, second);
                    first = second;
                }
            }

            private double GetSin(double x)
            {
                return Math.Sin(((frequency) * x) / 100.0) * amplitude / 10.0;
            }
        }
    }
}
