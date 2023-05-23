namespace Tetris_
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.StartGame = new System.Windows.Forms.Button();
            this.Help = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.BestScore = new System.Windows.Forms.Label();
            this.TetrisName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartGame
            // 
            this.StartGame.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartGame.Location = new System.Drawing.Point(272, 205);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(240, 80);
            this.StartGame.TabIndex = 0;
            this.StartGame.Text = "button1";
            this.StartGame.UseVisualStyleBackColor = true;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // Help
            // 
            this.Help.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Help.Location = new System.Drawing.Point(272, 375);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(240, 80);
            this.Help.TabIndex = 1;
            this.Help.Text = "button1";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Exit.Location = new System.Drawing.Point(272, 545);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(240, 80);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "button1";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // BestScore
            // 
            this.BestScore.BackColor = System.Drawing.SystemColors.Window;
            this.BestScore.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BestScore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BestScore.Location = new System.Drawing.Point(565, 205);
            this.BestScore.Name = "BestScore";
            this.BestScore.Size = new System.Drawing.Size(117, 250);
            this.BestScore.TabIndex = 3;
            this.BestScore.Text = "label1";
            // 
            // TetrisName
            // 
            this.TetrisName.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TetrisName.Location = new System.Drawing.Point(272, 64);
            this.TetrisName.Name = "TetrisName";
            this.TetrisName.Size = new System.Drawing.Size(240, 41);
            this.TetrisName.TabIndex = 4;
            this.TetrisName.Text = "label1";
            this.TetrisName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.TetrisName);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.BestScore);
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Button StartGame;
        private Button Help;
        private Button Exit;
        private Label BestScore;
        private Label TetrisName;
    }
}