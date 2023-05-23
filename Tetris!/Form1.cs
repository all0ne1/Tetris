namespace Tetris_
{

    public partial class Form1 : Form
    {
        Shape currentshape;
        string text = "";
        int size;
        int[,] map = new int[24, 10];
        int Interval;
        int linesremoved;
        int score;
        public int bestscore;
        public Form1()
        {
            InitializeComponent();
            this.KeyUp += new KeyEventHandler(keyFunc);
            Init();
        }
        public void Init()
        {
            score = 0;
            if (File.Exists("score.txt"))
            {
                using (StreamReader sr = new StreamReader("score.txt", System.Text.Encoding.Default))
                {
                    text = sr.ReadToEnd();
                }
                bestscore = Convert.ToInt32(text);
            }
            else
            {
                bestscore = 0;
            }
            linesremoved = 0;
            size = 25;
            currentshape = new Shape(4, 0);
            Interval = 300;
            timer1.Interval = Interval;
            timer1.Tick += new EventHandler(update);
            label1.Text = "Score: " + score;
            label2.Text = "Lines: " + linesremoved;
            label3.Text = "Next shape: ";
            timer1.Start();
            Invalidate();
        }
        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           Application.Exit();
        }

        private void keyFunc(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (!IsIntersects())
                    {
                        ResetArea();
                        currentshape.RotateShape();
                        Merge();
                        Invalidate();
                    }
                    break;
                case Keys.D:
                    if (!CollisionHor(1))
                    {
                        ResetArea();
                        currentshape.MoveRight();
                        Merge();
                        Invalidate();
                    }
                    break;
                case Keys.A:
                    if (!CollisionHor(-1))
                    {
                        ResetArea();
                        currentshape.MoveLeft();
                        Merge();
                        Invalidate();
                    }
                    break;
                case Keys.S:
                    timer1.Interval = 10;
                    break;
            }
        }
        
        public void ShowNextShape(Graphics g)
        {
            for (int i = 0; i < currentshape.sizenextmatrix; i++)
            {
                for (int j = 0; j < currentshape.sizenextmatrix; j++)
                {
                    if(currentshape.nextmatrix[i, j] == 1)
                    {
                        g.FillRectangle(Brushes.Red, new Rectangle(630 + j * size, 250 + i * size, size - 2, size - 2));
                    }
                    if (currentshape.nextmatrix[i, j] == 2)
                    {
                        g.FillRectangle(Brushes.Blue, new Rectangle(630 + j * size, 250 + i * size, size - 2, size - 2));
                    }
                    if (currentshape.nextmatrix[i, j] == 3)
                    {
                        g.FillRectangle(Brushes.Yellow, new Rectangle(630 + j * size, 250 + i * size, size - 2, size - 2));
                    }
                    if (currentshape.nextmatrix[i, j] == 4)
                    {
                        g.FillRectangle(Brushes.Brown, new Rectangle(630 + j * size, 250 + i * size, size - 2, size - 2));
                    }
                    if (currentshape.nextmatrix[i, j] == 5)
                    {
                        g.FillRectangle(Brushes.Purple, new Rectangle(630 + j * size, 250 + i * size, size - 2, size - 2));
                    }
                    if (currentshape.nextmatrix[i, j] == 6)
                    {
                        g.FillRectangle(Brushes.Orange, new Rectangle(630 + j * size, 250 + i * size, size - 2, size - 2));
                    }
                    if (currentshape.nextmatrix[i, j] == 7)
                    {
                        g.FillRectangle(Brushes.Green, new Rectangle(630 + j * size, 250 + i * size, size - 2, size - 2));
                    }
                }
            }
        }
        private void update(object? sender, EventArgs e)
        {
            ResetArea();
            if (!Collision())
            {
                currentshape.MoveDown();
            }
            else
            {
                Merge();
                SliceMap();
                score += 10;
                label1.Text = "Score: " + score;
                timer1.Interval = 300;
                currentshape.ResetShape(3, 0);
                if (Collision())
                {
                    for (int i = 0; i < 24; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            map[i, j] = 0;
                        }
                    }
                    score -= 10;
                    Program.score = score;
                    if (score > bestscore)
                    {
                        Program.bestscore = score;
                        using (StreamWriter sr = new StreamWriter("score.txt", false, System.Text.Encoding.Default))
                        {
                            sr.WriteLine(Program.bestscore);
                        }
                    }
                    timer1.Tick -= new EventHandler(update);
                    timer1.Stop();
                    GameOver gameOver = new GameOver();
                    gameOver.Show();
                    this.Hide();
                }
            }
            Merge();
            Invalidate();
        }
        public void SliceMap()
        {
            int curRemovedlines = 0;
            int count = 0;
            for (int i = 0; i < 24; i++)
            {
                count = 0;
                for (int j = 0; j < 10; j++)
                {
                    if (map[i,j] != 0)
                    {
                        count++;
                    }
                }
                if (count == 10)
                {
                    curRemovedlines++;
                    for (int k = i; k >= 1; k--)
                    {
                        for (int o = 0; o < 10; o++)
                        {
                            map[k, o] = map[k - 1, o];
                        }
                    }
                }
            }
            score += 100 * curRemovedlines; 
            linesremoved += curRemovedlines;
            label1.Text = "Score: " + score;
            label2.Text = "Lines: " + linesremoved;
        }
        public bool IsIntersects()
        {
            for (int i = currentshape.y; i < currentshape.y + currentshape.sizematrix; i++)
            {
                for (int j = currentshape.x; j < currentshape.x + currentshape.sizematrix; j++)
                {
                    if (j >= 0 && j < 10)
                    {
                        if (map[i, j] != 0 && currentshape.matrix[i - currentshape.y, j - currentshape.x] == 0)
                            return true;
                    }
                }
            }
            return false;
        }

        public void Merge()
        {
            for (int i = currentshape.y; i < currentshape.y + currentshape.sizematrix; i++)
            {
                for (int j = currentshape.x; j < currentshape.x + currentshape.sizematrix; j++)
                {
                    if (currentshape.matrix[i - currentshape.y, j - currentshape.x] != 0)
                    {
                        map[i, j] = currentshape.matrix[i - currentshape.y, j - currentshape.x];
                    }
                }
            }
        }
        public bool Collision()
        {
            for (int i = currentshape.y; i <= currentshape.y + currentshape.sizematrix - 1; i++)
            {
                for (int j = currentshape.x; j < currentshape.x + currentshape.sizematrix; j++)
                {
                    if (currentshape.matrix[i - currentshape.y, j - currentshape.x] != 0)
                    {
                        if (i + 1 == 24)
                        {
                            return true;
                        }
                        if (map[i+1,j] != 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool CollisionHor(int dir)
        {
            for (int i = currentshape.y; i < currentshape.y + currentshape.sizematrix; i++)
            {
                for (int j = currentshape.x; j < currentshape.x + currentshape.sizematrix; j++)
                {
                    if (currentshape.matrix[i - currentshape.y, j - currentshape.x] != 0)
                    {
                        if (j + 1 * dir > 9 || j + 1 * dir < 0)
                        {
                            return true;
                        }
                        if (map[i,j + 1 * dir] != 0)
                        {
                            if (j - currentshape.x + 1 * dir >= currentshape.sizematrix || j - currentshape.x + 1 * dir < 0)
                            {
                                return true;
                            }
                            if (currentshape.matrix[i - currentshape.y,j - currentshape.x + 1 * dir] == 0)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public void ResetArea()
        {
            for (int i = currentshape.y; i < currentshape.y + currentshape.sizematrix; i++)
            {
                for (int j = currentshape.x; j < currentshape.x + currentshape.sizematrix; j++)
                {
                    if (i >= 0 && j >= 0 && i < 24 && j < 10)
                    {
                        if (currentshape.matrix[i - currentshape.y, j - currentshape.x] != 0)
                        {
                            map[i, j] = 0;
                        }
                    }
                }
            }
        }
        public void DrawMap(Graphics e) 
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (map[i, j] == 1)
                    {
                        e.FillRectangle(Brushes.Red, new Rectangle(250 + j * size, 50 + i * size, size, size));
                    }
                    if (map[i, j] == 2)
                    {
                        e.FillRectangle(Brushes.Blue, new Rectangle(250 + j * size, 50 + i * size, size, size));
                    }
                    if (map[i, j] == 3)
                    {
                        e.FillRectangle(Brushes.Yellow, new Rectangle(250 + j * size, 50 + i * size, size, size));
                    }
                    if (map[i, j] == 4)
                    {
                        e.FillRectangle(Brushes.Brown, new Rectangle(250 + j * size, 50 + i * size, size, size));
                    }
                    if (map[i, j] == 5)
                    {
                        e.FillRectangle(Brushes.Purple, new Rectangle(250 + j * size, 50 + i * size, size, size));
                    }
                    if (map[i, j] == 6)
                    {
                        e.FillRectangle(Brushes.Orange, new Rectangle(250 + j * size, 50 + i * size, size, size));
                    }
                    if (map[i, j] == 7)
                    {
                        e.FillRectangle(Brushes.Green, new Rectangle(250 + j * size, 50 + i * size, size, size));
                    }
                }
            }
        }

        public void DrawGrid(Graphics g)
        {
            for (int i = 0; i <= 10; i++)
            {
                g.DrawLine(Pens.Black, new Point(250 + i * size, 50), new Point(250 + i * size, 650));
            }
            for (int i = 0; i <= 24; i++)
            {
                g.DrawLine(Pens.Black, new Point(250, 50 + i * size), new Point(500, 50 + i * size));
            }

        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            DrawMap(e.Graphics);
            DrawGrid(e.Graphics);
            ShowNextShape(e.Graphics);
        }
    }
    class BaseShapes
    {
        public int[,] baseTetr = new int[4, 4];
        public int[,] tetrI = new int[4, 4]
        {
            {0,0,1,0},
            {0,0,1,0},
            {0,0,1,0},
            {0,0,1,0},
        };
        public int[,] tetrJ = new int[3, 3]
        {
            {0,2,0 },
            {0,2,0 },
            {2,2,0 },
        };
        public int[,] tetrL = new int[3, 3]
        {
            {0,3,0 },
            {0,3,0 },
            {0,3,3 },
        };
        public int[,] tetrO = new int[2, 2]
        {
            {4,4},
            {4,4},
        };
        public int[,] tetrZ = new int[3, 3]
        {
            {0,5,0 },
            {5,5,0 },
            {5,0,0 }
        };
        public int[,] tetrS = new int[3, 3]
        {
            {0,6,0 },
            {0,6,6 },
            {0,0,6 }
        };
        public int[,] tetrT = new int[3, 3]
        {
            {0,0,0 },
            {7,7,7 },
            {0,7,0 },
        };
    }
    class Shape : BaseShapes
    {
        public int x;
        public int y;
        public int[,] matrix;
        public int[,] nextmatrix;
        public int sizematrix;
        public int sizenextmatrix;
        public Shape(int _x, int _y)
        {
            x = _x;
            y = _y;
            matrix = GenerateMatrix();
            sizematrix = (int)Math.Sqrt(matrix.Length);
            nextmatrix = GenerateMatrix();
            sizenextmatrix = (int)Math.Sqrt(nextmatrix.Length);

        }
        public void ResetShape(int _x, int _y)
        {
            x = _x;
            y = _y;
            matrix = nextmatrix;
            sizematrix = (int)Math.Sqrt(matrix.Length);
            nextmatrix = GenerateMatrix();
            sizenextmatrix = (int)Math.Sqrt(nextmatrix.Length);
        }
        public int[,] GenerateMatrix()
        {
            int[,] newmatrix = baseTetr;
            Random r = new Random();
            switch (r.Next(1, 8))
            {
                case 1:
                    newmatrix = tetrI;
                    break;
                case 2:
                    newmatrix = tetrJ;
                    break;
                case 3:
                    newmatrix = tetrL;
                    break;
                case 4:
                    newmatrix = tetrO;
                    break;
                case 5:
                    newmatrix = tetrZ;
                    break;
                case 6:
                    newmatrix = tetrS;
                    break;
                case 7:
                    newmatrix = tetrT;
                    break;
            }
            return newmatrix;
        }
        public void RotateShape()
        {
            int[,] tempMatrix = new int[sizematrix, sizematrix];
            for (int i = 0; i < sizematrix; i++)
            {
                for (int j = 0; j < sizematrix; j++)
                {
                    tempMatrix[i, j] = matrix[j, (sizematrix - 1) - i];
                }
            }
            matrix = tempMatrix;
            int offsetright = (10 - (x + sizematrix));
            if (offsetright < 0)
            {
                for (int i = 0; i < Math.Abs(offsetright); i++)
                    MoveLeft();
            }

            if (x < 0)
            {
                for (int i = 0; i < Math.Abs(x) + 1; i++)
                    MoveRight();
            }
        }

        public void MoveDown()
        {
            y++;
        }
        public void MoveRight()
        {
            x++;
        }
        public void MoveLeft()
        {
            x--;
        }
    }
}