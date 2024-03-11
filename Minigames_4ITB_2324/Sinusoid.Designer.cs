namespace Minigames_4ITB_2324
{
    partial class Sinusoid
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            hScrollBar1 = new HScrollBar();
            vScrollBar1 = new VScrollBar();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // hScrollBar1
            // 
            hScrollBar1.LargeChange = 1;
            hScrollBar1.Location = new Point(28, 689);
            hScrollBar1.Maximum = 10;
            hScrollBar1.Minimum = 1;
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(709, 39);
            hScrollBar1.TabIndex = 0;
            hScrollBar1.Value = 5;
            hScrollBar1.Scroll += hScrollBar1_Scroll;
            // 
            // vScrollBar1
            // 
            vScrollBar1.LargeChange = 1;
            vScrollBar1.Location = new Point(744, 19);
            vScrollBar1.Maximum = 10;
            vScrollBar1.Minimum = 1;
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(39, 659);
            vScrollBar1.TabIndex = 1;
            vScrollBar1.Value = 5;
            vScrollBar1.Scroll += vScrollBar1_Scroll;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Yellow;
            pictureBox1.Location = new Point(0, 759);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 41);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // Sinusoid
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 0);
            Controls.Add(pictureBox1);
            Controls.Add(vScrollBar1);
            Controls.Add(hScrollBar1);
            Name = "Sinusoid";
            Size = new Size(800, 800);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private HScrollBar hScrollBar1;
        private VScrollBar vScrollBar1;
        private PictureBox pictureBox1;
    }
}
