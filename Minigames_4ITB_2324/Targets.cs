using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minigames_4ITB_2324
{
    public partial class Targets : UserControl, IMinigame
    {
        public Targets()
        {
            InitializeComponent();
        }

        public int Score { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action<int> MinigameEnded;

        public void StartMinigame()
        {
            throw new NotImplementedException();
        }
    }
}
