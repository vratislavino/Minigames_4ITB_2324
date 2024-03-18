using System.Reflection;
using System.Security.Cryptography;


namespace Minigames_4ITB_2324
{
    public partial class Form1 : Form
    {
        bool isPlayersTurn = true;

        List<Type> minigames = new List<Type>() { 
           
        };

        public Form1(List<Type> hry)
        {
            InitializeComponent();
            minigames = hry;
            this.Show();
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
                ofd.Filter = "Obr�zky PNG|*.png|Obr�zky JPG|*.jpg";
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
            playerView1.SetupPlayerView(true, "Anton�n", playerImage);
            playerView2.SetupPlayerView(false, "Android", androidImage);

            // Na�ten� custom minigame z knihovny
            LoadMinigameFromDll();

            StartRound();
        }

        private void LoadMinigameFromDll()
        {
            //
        }

        private void StartRound()
        {
            if(isPlayersTurn)
            {
                // Circle, Targets
                IMinigame m = GetRandomMinigame();
                
                panel1.Controls.Add(m as Control);
                m.MinigameEnded += (score) => {
                    playerView2.Hp -= score;
                    panel1.Controls.Remove(m as Control);
                    // odebrat minihru p�ed loadem nov�
                    SwitchPlayer();
                };
                m.StartMinigame();

            } else
            {
                int dmg = new Random().Next(0, 10);
                playerView1.Hp -= dmg;
                SwitchPlayer();
            }
        }

        private void SwitchPlayer()
        {
            isPlayersTurn = !isPlayersTurn;
            StartRound();
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