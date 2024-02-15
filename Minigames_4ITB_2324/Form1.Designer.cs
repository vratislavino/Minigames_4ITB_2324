namespace Minigames_4ITB_2324
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            playerView1 = new PlayerView();
            playerView2 = new PlayerView();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Location = new Point(371, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 800);
            panel1.TabIndex = 0;
            // 
            // playerView1
            // 
            playerView1.Hp = 0;
            playerView1.Image = null;
            playerView1.Location = new Point(12, 12);
            playerView1.Name = "playerView1";
            playerView1.Size = new Size(353, 755);
            playerView1.TabIndex = 1;
            // 
            // playerView2
            // 
            playerView2.Hp = 0;
            playerView2.Image = null;
            playerView2.Location = new Point(1177, 12);
            playerView2.Name = "playerView2";
            playerView2.Size = new Size(353, 755);
            playerView2.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1529, 846);
            Controls.Add(playerView2);
            Controls.Add(playerView1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PlayerView playerView1;
        private PlayerView playerView2;
    }
}