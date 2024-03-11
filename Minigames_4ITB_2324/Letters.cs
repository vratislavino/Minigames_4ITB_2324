using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minigames_4ITB_2324
{
    public partial class Letters : UserControl, IMinigame
    {
        System.Windows.Forms.Timer timer;

        public Letters()
        {
            InitializeComponent();
        }

        private Random random = new Random();

        public int Score { get; set; }

        public event Action<int> MinigameEnded;

        private int tickToLose = 100;
        private int currentTicks = 0;

        private string currentChar;

        private string chars = "abcdefghijklmnopqrstuvwxyz";

        public void StartMinigame()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 30;
            currentTicks = 0;

            timer.Tick += OnTick;
            this.KeyDown += OnKeyDown;
            this.Load += OnLoad;

            GenerateChar();
            timer.Start();
        }

        private void GenerateChar()
        {
            currentChar = chars[random.Next(0, chars.Length)].ToString().ToUpper();
            label1.Text = currentChar;
        }

        private void OnLoad(object? sender, EventArgs e)
        {
            this.Focus();
        }

        private void OnKeyDown(object? sender, KeyEventArgs e)
        {
            KeysConverter kc = new KeysConverter();
            string keyChar = kc.ConvertToString(e.KeyValue);
            
            if (keyChar == currentChar)
            {
                currentTicks = 0;
                Score++;
                if (Score < 10)
                {
                    GenerateChar();
                    tickToLose = (int)(tickToLose * 0.9);
                } else
                {
                    timer.Stop();
                    MinigameEnded?.Invoke(Score);
                }
            } else
            {
                timer.Stop();
                MinigameEnded?.Invoke(Score);
            }
        }

        private void OnTick(object? sender, EventArgs e)
        {
            currentTicks++;
            if(currentTicks >= tickToLose)
            {
                timer.Stop();
                MinigameEnded?.Invoke(Score);
            }

            pictureBox1.Width = (int)(800 * (currentTicks / (double)tickToLose));
        }
    }
}
