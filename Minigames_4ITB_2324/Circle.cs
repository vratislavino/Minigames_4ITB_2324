using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minigames_4ITB_2324
{
    public partial class Circle : UserControl, IMinigame
    {
        public Circle()
        {
            InitializeComponent();
        }

        public int Score { get; set; }

        public event Action<int> MinigameEnded;
        System.Windows.Forms.Timer timer;

        Pen redCirclePen = new Pen(Color.Red, 50f);
        Pen greenArcPen = new Pen(Color.Green, 50f);
        Pen arrowPen = new Pen(Color.Black, 14f);

        int greenSize = 40;
        int greenStart = 90;

        double currentAngle = 270;
        int radius;
        float speed = 2;
        float speedMult = 1.15f;

        Random rand = new Random();
        bool didHit = false;
        public void StartMinigame()
        {
            DoubleBuffered = true;
            Score = 0;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 16;
            timer.Tick += OnTick;
            this.Paint += OnPaint;
            this.KeyDown += OnKeyDown;
            radius = Width * 3 / 8;
            timer.Start();
            GenerateGreen();
        }

        private void GenerateGreen()
        {
            greenStart = rand.Next(20, 160);
        }

        private void OnTick(object? sender, EventArgs e)
        {
            currentAngle -= speed;
            if (currentAngle < 0) { 
                currentAngle += 360;
                if(didHit) didHit = false;
                else
                {
                    timer.Stop();
                    MinigameEnded?.Invoke(Score);
                }
            }
            Refresh();
        }

        private void OnKeyDown(object? sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space) { 
                if(currentAngle > greenStart && currentAngle < greenStart+greenSize)
                {
                    Score++;
                    if(Score == 10)
                    {
                        timer.Stop();
                        MinigameEnded?.Invoke(Score);
                    }
                    didHit = true;
                    speed *= speedMult;
                    greenSize -= 2;
                    GenerateGreen();
                } else
                {
                    timer.Stop();
                    MinigameEnded?.Invoke(Score);
                }
            }
        }

        private void OnPaint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawEllipse(redCirclePen, Width / 8, Height / 8, Width * 6 / 8, Height * 6 / 8);
            e.Graphics.DrawArc(greenArcPen, Width / 8, Height / 8, Width * 6 / 8, Height * 6 / 8, greenStart, greenSize);

            int x, y; //(Math.PI / 180) * degrees
            double rad = Math.PI / 180 * currentAngle;
            x = (int)(Math.Cos(rad) * radius + Width / 2);
            y = (int)(Math.Sin(rad) * radius + Height / 2);


            e.Graphics.DrawLine(arrowPen, Width / 2, Height / 2, x, y);
        }
    }
}
