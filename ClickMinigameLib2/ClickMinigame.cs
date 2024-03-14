using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minigames_4ITB_2324;

namespace ClickMinigameLib2
{
    public partial class ClickMinigame : UserControl, IMinigame
    {
        public ClickMinigame()
        {
            InitializeComponent();
        }

        public int Score { get; set; }

        public event Action<int> MinigameEnded;

        public void StartMinigame()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Score++;
            Score = Math.Min(Score, 10);
            label1.Text = Score.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MinigameEnded?.Invoke(Score);
        }
    }
}
