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
    public partial class MainMenu : Form
    {
        string text = "";
        public MainMenu()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            TetrisName.BackColor = Color.Transparent;
            TetrisName.ForeColor = Color.White;
            TetrisName.Text = "TETRIS";
            StartGame.Text = "Играть";
            Help.Text = "Справка";
            Exit.Text = "Выход";
            if (File.Exists("score.txt"))
            {
                text = Score.ReadScore();
                BestScore.Text = "Лучший счет: " + text;
            }
            else
            {
                BestScore.Text = "Лучший счет: 0";
            }
        }
        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Score.WriteScore();
            Application.Exit();
        }
        private void StartGame_Click(object sender, EventArgs e)
        {
            
            Form1 game = new Form1();
            game.Show();
            this.Hide();
        }

        private void Help_Click(object sender, EventArgs e)
        {
            string text = "Добро пожаловать в игру 'Tetris!'\n\n" +
                "Цель игры - заполнять горизонтальные линии на игровом поле " +
                "падающими фигурами. Когда линия полностью заполняется, она " +
                "исчезает, и вы получаете очки. Так же вы получаете очки после " +
                "каждой упавшей фигуры.\n\n" +
                "Управление:\n" +
                "Клавиша 'A' - переместить фигуру влево\n" +
                "Клавиша 'D' - переместить фигуру вправо\n" +
                "Клавиша 'W' - повернуть фигуру\n" +
                "Клавиша 'S' - быстро опустить фигуру\n" +
                "Нажмите 'Играть', чтобы начать игру.\n" +
                "Удачи!";
            MessageBox.Show(text);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Score.WriteScore();
            Application.Exit();

        }

    }
}
