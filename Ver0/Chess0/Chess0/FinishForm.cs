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
    public partial class FinishForm : Form
    {
        StartForm main;
        string winner;
        MainChess game;

        public FinishForm(StartForm m,MainChess g, string w)
        {
            InitializeComponent();
            main = m;
            winner = w;
            game = g;
            if (w != "")
            {
                statelabel.Text = "Winner: " + winner;
            }
            else
            {
                statelabel.Text = "Stalemate!";
            }
        }

        private void ReplayButton_Click(object sender, EventArgs e)
        {
            main.Enabled = true;
            game.Close();
            main.Enabled = false;
            main.StartButton_Click(default,default);
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            main.Enabled = true;
            game.Close();
            main.Show();
            this.Close();
        }
    }
}
