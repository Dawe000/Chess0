using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess0
{
    public partial class MainChess : Form
    {
        PictureBox[,] squares;
        Chess game;
        int[][,] moves;
        Color[] colors;
        int[] lastPos;

        public MainChess()
        {
            InitializeComponent();
            
            colors = new Color[] { Color.Gray, Color.Wheat };
            int c = 0;
            this.Height = 1200;

            int offsety = 615;
            squares = new PictureBox[8, 8];
            for (int y = 0; y<8; y++)
            {
                int offsetx = 0;
                for (int x = 0; x<8; x++)
                {
                    
                    squares[y, x] = new PictureBox();
                    Controls.Add(squares[y, x]);
                    squares[y, x].Height = 90;
                    squares[y, x].Width = 90;
                    squares[y, x].Location = new Point(35+offsetx,50+offsety);
                    squares[y, x].BackColor = colors[c];
                    squares[y, x].MouseMove += MainChess_MouseMove;
                    squares[y, x].Click += PictureBoxClick;
                    squares[y, x].Name = Convert.ToString(y) + Convert.ToString(x);
                    squares[y, x].BackgroundImageLayout = ImageLayout.Stretch;
                    offsetx += 90;
                    if (c == 0) c = 1;
                    else c = 0;

                }
                offsety -= 90;
                if (c == 0) c = 1;
                else c = 0;


            }
            //xLabel.Text = Convert.ToString(Cursor.Position.X);
            //yLabel.Text = Convert.ToString(Cursor.Position.Y);
            
            game = new Chess(new string[] { "p1", "p2" }, 10, 10);
            game.start(this);

        }

        public void PictureBoxClick(object sender, EventArgs e)
        {
            Color moveColor = Color.Green;
            PictureBox p = (PictureBox)sender;
            Console.WriteLine(p.Name);
            

            int[] pos = new int[] { Convert.ToInt32(Convert.ToString(p.Name[0])) , Convert.ToInt32(Convert.ToString(p.Name[1])) };
            int c = 0;

            if (game.board[pos[0],pos[1]]!="  "&& Convert.ToInt32(Convert.ToString(game.board[pos[0], pos[1]][0])) == game.turn)
            {
                moves = game.CalculateLegalMoves(pos);
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {

                        squares[y, x].BackColor = colors[c];
                        if (c == 0) c = 1;
                        else c = 0;

                    }

                    if (c == 0) c = 1;
                    else c = 0;
                }

                foreach (int[,] move in moves)
                {
                    squares[move[0, 0], move[0, 1]].BackColor = moveColor;
                }
            }
            else if (squares[pos[0], pos[1]].BackColor == moveColor)
            {
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {

                        squares[y, x].BackColor = colors[c];
                        if (c == 0) c = 1;
                        else c = 0;

                    }

                    if (c == 0) c = 1;
                    else c = 0;
                }
                int[,] correctMove= default;
                foreach (int[,] move in moves)
                {
                    if (pos[0] == move[0, 0] && pos[1] == move[0, 1]) correctMove = move;
                }
                game.Move(lastPos, correctMove);
                moves = default;
                UpdateBoard();
                StateLabel.Text = game.gameState;
            }
            else
            {
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {

                        squares[y, x].BackColor = colors[c];
                        if (c == 0) c = 1;
                        else c = 0;

                    }

                    if (c == 0) c = 1;
                    else c = 0;
                }
                moves = default;
            }
            lastPos = pos;
        }

        public void UpdateBoard()
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    switch (game.board[y, x])
                    {
                        case "0P":
                            squares[y,x].BackgroundImage=ChessPieces._0P;
                            break;
                        case "0K":
                            squares[y, x].BackgroundImage = ChessPieces._0K;
                            break;
                        case "0Q":
                            squares[y, x].BackgroundImage = ChessPieces._0Q;
                            break;
                        case "0N":
                            squares[y, x].BackgroundImage = ChessPieces._0N;
                            break;
                        case "0R":
                            squares[y, x].BackgroundImage = ChessPieces._0R;
                            break;
                        case "0B":
                            squares[y, x].BackgroundImage = ChessPieces._0B;
                            break;
                        case "1P":
                            squares[y, x].BackgroundImage = ChessPieces._1P;
                            break;
                        case "1K":
                            squares[y, x].BackgroundImage = ChessPieces._1K;
                            break;
                        case "1Q":
                            squares[y, x].BackgroundImage = ChessPieces._1Q;
                            break;
                        case "1N":
                            squares[y, x].BackgroundImage = ChessPieces._1N;
                            break;
                        case "1R":
                            squares[y, x].BackgroundImage = ChessPieces._1R;
                            break;
                        case "1B":
                            squares[y, x].BackgroundImage = ChessPieces._1B;
                            break;
                        default:
                            squares[y, x].BackgroundImage = null;
                            break;
                    }
                }
                
            }
        }

        private void MainChess_MouseMove(object sender, MouseEventArgs e)
        {
            //xLabel.Text = Convert.ToString(Cursor.Position.X);
            //yLabel.Text = Convert.ToString(Cursor.Position.Y);
        }


    }
}
