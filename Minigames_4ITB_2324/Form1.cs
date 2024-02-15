using System.Security.Cryptography;

namespace Minigames_4ITB_2324
{
    public partial class Form1 : Form
    {
        bool isPlayersTurn = true;

        List<Type> minigames = new List<Type>() { 
            typeof(Circle),
            typeof(Targets)
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool wantToLoadImage = false;

            var androidImage = Image.FromFile("android.jpg");
            string defaultPath = "default.png";
            Image playerImage = null;
            if (wantToLoadImage)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Obrázky PNG|*.png|Obrázky JPG|*.jpg";
                var res = ofd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    playerImage = Image.FromFile(ofd.FileName);
                } else
                {
                    playerImage = Image.FromFile(defaultPath);
                }
            } else
            {
                playerImage = Image.FromFile(defaultPath);
            }
            playerView1.SetupPlayerView(true, "Antonín", playerImage);
            playerView2.SetupPlayerView(false, "Android", androidImage);

            StartRound();
        }

        private void StartRound()
        {
            if(isPlayersTurn)
            {
                // Circle, Targets
                IMinigame m = GetRandomMinigame();
                m.MinigameEnded += (score) => { };
                m.StartMinigame();

            } else
            {
                int dmg = new Random().Next(0, 10);
                playerView1.Hp -= dmg;
            }
        }

        private IMinigame GetRandomMinigame()
        {
            Random random = new Random();
            int r = random.Next(0, minigames.Count);
            var minigame = Activator.CreateInstance(minigames[r]) as IMinigame;
            return minigame;
        }
    }
}