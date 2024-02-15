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
    public partial class PlayerView : UserControl
    {
        int hp;
        string name;
        Image image;

        public PlayerView()
        {
            InitializeComponent();
        }

        public int Hp
        {
            get { return hp; }
            set
            {
                hp = value;
                if (hp < 0) hp = 0;
                progressBar1.Value = hp;
            }
        }

        public new string Name
        {
            get { return name; }
            set
            {
                name = value;
                label1.Text = name;
            }
        }

        public Image Image
        {
            get { return image; }
            set
            {
                image = value;
                pictureBox1.BackgroundImage = image;
            }
        }

        public void SetupPlayerView(bool isPlayer, string name, Image image)
        {
            this.Hp = 100;
            this.Name = name;
            this.Image = image;

            if (!isPlayer)
            {
                progressBar1.RightToLeft = RightToLeft.Yes;
                progressBar1.RightToLeftLayout = true;
            }
        }
    }
}
