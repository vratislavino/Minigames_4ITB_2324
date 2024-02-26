using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Minigames_4ITB_2324
{
    public partial class Targets : UserControl, IMinigame
    {
        public Targets()
        {
            InitializeComponent();
        }

        public int Score { get; set; }

        public event Action<int> MinigameEnded;

        System.Windows.Forms.Timer timer;

        Target currentTarget;
        float speed = 1;
        float speedMult = 1.15f;

        public void StartMinigame()
        {
            DoubleBuffered = true;
            Score = 0;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 16;
            
            this.MouseDown += OnMouseDown;
            this.Paint += OnPaint;
            timer.Tick += OnTick;

            timer.Start();
            GenerateTarget();
        }

        private void GenerateTarget()
        {
            Random r = new Random();
            currentTarget = new Target() {
                posX = r.Next(0, Width),
                posY = r.Next(0, Height),
                brush = new SolidBrush(Color.Red),
                size = 150
            };
        }

        private void OnTick(object? sender, EventArgs e)
        {
            currentTarget.size -= speed;
            if(currentTarget.size <= 0) {
                timer.Stop();
                MinigameEnded?.Invoke(Score);
            }
            Refresh();
        }

        private void OnPaint(object? sender, PaintEventArgs e)
        {
            currentTarget.Draw(e.Graphics);
        }

        private void OnMouseDown(object? sender, MouseEventArgs e)
        {
            if(currentTarget.IsMouseOver(e.Location))
            {
                Score++;
                if(Score == 10)
                {
                    timer.Stop();
                    MinigameEnded?.Invoke(Score);
                }
                speed *= speedMult;
                GenerateTarget();
            } else
            {
                timer.Stop();
                MinigameEnded?.Invoke(Score);
            }
        }

        class Target
        {
            public int posX;
            public int posY;
            public float size;
            public Brush brush;

            public void Draw(Graphics g) {
                g.FillEllipse(brush, posX - size / 2, posY - size / 2, size, size);
            }

            public bool IsMouseOver(Point mousePos)
            {
                double dist = Math.Sqrt(Math.Pow(posX - mousePos.X, 2) + Math.Pow(posY - mousePos.Y, 2));

                return dist < size / 2;
            }
        }
    }
}
