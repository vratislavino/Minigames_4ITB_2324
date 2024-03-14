using System.Reflection;
using System.Security.Cryptography;


namespace Minigames_4ITB_2324
{
    public partial class Form1 : Form
    {
        bool isPlayersTurn = true;

        List<Type> minigames = new List<Type>() { 
            typeof(Targets),
            typeof(Circle),
            typeof(Sinusoid),
            typeof(Letters)
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

            // Naètení custom minigame z knihovny
            LoadMinigameFromDll();

            StartRound();
        }

        private void LoadMinigameFromDll()
        {
            string filename = "C:\\Users\\vrati\\source\\repos\\Minigames_4ITB_2324\\Minigames_4ITB_2324\\bin\\Debug\\net6.0-windows\\ClickMinigameLib2.dll";
            Assembly assembly = Assembly.LoadFile(filename);
            
            foreach(var typ in assembly.GetTypes())
            {
                if(typ.IsAssignableTo(typeof(IMinigame)))
                {
                    MessageBox.Show(typ.Name);
                    minigames.Add(typ);
                }
            }
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
                    // odebrat minihru pøed loadem nové
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
            int r = minigames.Count - 1;//random.Next(0, minigames.Count);
            var minigame = Activator.CreateInstance(minigames[r]) as IMinigame;
            return minigame;
        }
    }
}