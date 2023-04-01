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
        Color[] boardColours;
        Color moveColor;
        Color checkColor;
        Color backColor;
        Color textColor;

        int[] lastPos;

        public MainChess()
        {
            InitializeComponent();
            
            boardColours = new Color[] { Color.Gray, Color.Wheat };
            moveColor = Color.Green;
            checkColor = Color.Red;
            backColor = Color.White;
            BackColor = backColor;
            textColor = Color.Black;

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
                    squares[y, x].BackColor = boardColours[c];
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

        public void UpdateColors(Color newColor1, Color newColor2, Color newMoveColor, Color newCheckColor, Color newBackColor, Color newTextColor)
        {
            foreach (PictureBox p in squares)
            {
                if (p.BackColor == boardColours[0]) p.BackColor = newColor1;
                else if (p.BackColor == boardColours[1]) p.BackColor = newColor2;
                else if (p.BackColor == moveColor) p.BackColor = newMoveColor;
                else if (p.BackColor == checkColor) p.BackColor = newCheckColor;
                BackColor = newBackColor;
            }
            BackColor = newBackColor;

            boardColours[0] = newColor1;
            boardColours[1] = newColor2;
            moveColor = newMoveColor;
            checkColor = newCheckColor;
            backColor = newBackColor;
            textColor = newTextColor;
        }




        public void PictureBoxClick(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            

            int[] pos = new int[] { Convert.ToInt32(Convert.ToString(p.Name[0])) , Convert.ToInt32(Convert.ToString(p.Name[1])) };
            int c = 0;

            if (game.board[pos[0],pos[1]]!="  "&& Convert.ToInt32(Convert.ToString(game.board[pos[0], pos[1]][0])) == game.turn)
            {
                moves = game.CalculateLegalMoves(pos);
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {

                        squares[y, x].BackColor = boardColours[c];
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

                        squares[y, x].BackColor = boardColours[c];
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

                        squares[y, x].BackColor = boardColours[c];
                        if (c == 0) c = 1;
                        else c = 0;

                    }

                    if (c == 0) c = 1;
                    else c = 0;
                }
                moves = default;
            }
            lastPos = pos;

            if (game.check)
            {
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        if (game.board[y, x][1] == 'K')
                        {
                            if (Convert.ToInt64(Convert.ToString(game.board[y, x][0])) == game.turn)
                            {
                                squares[y, x].BackColor = checkColor;
                            }
                            
                        }
                    }
                }
            }
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

        private void settingsIcon_Click(object sender, EventArgs e)
        {
            SettingsForm s = new SettingsForm(this,boardColours,checkColor,backColor,textColor,moveColor);
            s.Show();
            this.Enabled = false;
        }

        private void MainChess_Load(object sender, EventArgs e)
        {

        }
    }
}
