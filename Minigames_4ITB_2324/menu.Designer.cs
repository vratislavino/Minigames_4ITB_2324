namespace Minigames_4ITB_2324
{
    partial class menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            checkedListBox1 = new CheckedListBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(0, 0);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(426, 760);
            checkedListBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(432, 12);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 1;
            button1.Text = "nahrát dll";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(432, 64);
            button2.Name = "button2";
            button2.Size = new Size(150, 377);
            button2.TabIndex = 2;
            button2.Text = "hrát";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(432, 597);
            button3.Name = "button3";
            button3.Size = new Size(150, 155);
            button3.TabIndex = 3;
            button3.Text = "konec";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(432, 447);
            button4.Name = "button4";
            button4.Size = new Size(150, 144);
            button4.TabIndex = 4;
            button4.Text = "deletealll";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // menu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 764);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkedListBox1);
            Name = "menu";
            Text = "menu";
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox checkedListBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}