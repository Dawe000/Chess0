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

        Dictionary<string, Dictionary<string, Image>> textureSets;
        string textureSet;
        public MainChess()
        {
            InitializeComponent();
            
            boardColours = new Color[] { Color.Gray, Color.Wheat };
            moveColor = Color.Green;
            checkColor = Color.Red;
            backColor = Color.White;
            BackColor = backColor;
            textColor = Color.Black;

            InitTextures();
            textureSet="Default";

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

        public void UpdateColors(Color newColor1, Color newColor2, Color newMoveColor, Color newCheckColor, Color newBackColor, Color newTextColor, Dictionary<string, Dictionary<string, Image>> iTextureSets, string iTextureSet)
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
            textureSet = iTextureSet;
            textureSets = iTextureSets;
            UpdateBoard();
        }

        public void InitTextures()
        {
            Dictionary<string, Image> DefaultPieces=new Dictionary<string, Image> { };
            DefaultPieces.Add("0B", ChessPieces._0B);
            DefaultPieces.Add("0K", ChessPieces._0K);
            DefaultPieces.Add("0N", ChessPieces._0N);
            DefaultPieces.Add("0P", ChessPieces._0P);
            DefaultPieces.Add("0R", ChessPieces._0R);
            DefaultPieces.Add("0Q", ChessPieces._0Q);
            DefaultPieces.Add("1B", ChessPieces._1B);
            DefaultPieces.Add("1K", ChessPieces._1K);
            DefaultPieces.Add("1N", ChessPieces._1N);
            DefaultPieces.Add("1P", ChessPieces._1P);
            DefaultPieces.Add("1R", ChessPieces._1R);
            DefaultPieces.Add("1Q", ChessPieces._1Q);
            Dictionary<string, Image> BPieces=new Dictionary<string, Image> { };
            BPieces.Add("0B", BackupPieces.B0B);
            BPieces.Add("0K", BackupPieces.B0K);
            BPieces.Add("0N", BackupPieces.B0N);
            BPieces.Add("0P", BackupPieces.B0P);
            BPieces.Add("0R", BackupPieces.B0R);
            BPieces.Add("0Q", BackupPieces.B0Q);
            BPieces.Add("1B", BackupPieces.B1B);
            BPieces.Add("1K", BackupPieces.B1K);
            BPieces.Add("1N", BackupPieces.B1N);
            BPieces.Add("1P", BackupPieces.B1P);
            BPieces.Add("1R", BackupPieces.B1R);
            BPieces.Add("1Q", BackupPieces.B1Q);
            textureSets = new Dictionary<string, Dictionary<string, Image>> { };
            textureSets.Add("Default", DefaultPieces);
            textureSets.Add("Basic", BPieces);

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
                    if (game.board[y, x]!="  ")
                    {
                        squares[y, x].BackgroundImage = textureSets[textureSet][game.board[y, x]];
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
            SettingsForm s = new SettingsForm(this,boardColours,checkColor,backColor,textColor,moveColor,textureSets,textureSet);
            s.Show();
            this.Enabled = false;
        }

        private void MainChess_Load(object sender, EventArgs e)
        {

        }
    }
}
