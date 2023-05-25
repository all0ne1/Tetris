using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris_
{
    public partial class GameOver : Form
    {
        string text = "";
        public GameOver()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            if (File.Exists("score.txt"))
            {
                text = Score.ReadScore();
            }
            GameOverText.Text = $"Вы проиграли :(\n Ваш счет: {Score.score}\n Ваш лучший счет: {text}";
            MainMenuButton.Text = "Меню";
        }
        private void MainMenuButton_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Hide();
        }
        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Score.WriteScore();
            Application.Exit();
        }
    }
}
