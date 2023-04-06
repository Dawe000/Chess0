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
    public partial class StartForm : Form
    {

        string p1Name = "Guest1";
        string p2Name = "Guest2";
        string p1hash = "";
        string p2hash = "";
        public StartForm()
        {
            InitializeComponent();

        }

        public void StartButton_Click(object sender, EventArgs e)
        {
            MainChess m = new MainChess(p1Name, p2Name,this);
            m.Show();
            this.Hide();
            this.Enabled = false;
        }

        private void LoginClick(object sender, EventArgs e)
        {
            Button s = (Button)sender;
            if (s.Text=="Log out")
            {
                s.Text = "log in";
                string p = Convert.ToString(s.Name[1]);
                if (p == "1")
                {
                    p1Name = "Guest1";
                    p1hash = "";
                    P1ProfileButton.Enabled = false;
                    P1Label.Text = "Guest1";
                }
                else
                {
                    p2Name = "Guest2";
                    p2hash = "";
                    P2ProfileButton.Enabled = false;
                    P2Label.Text = "Guest2";
                }
                return;
            }
            LoginForm l = new LoginForm(s.Name, p1Name, p2Name,this);
            l.Show();
            this.Enabled = false;
        }
        public void Login(string username, string hash, string player)
        {
            string p = Convert.ToString(player[1]);
            if (p == "1")
            {
                p1Name = username;
                p1hash = hash;
                P1ProfileButton.Enabled = true;
                P1Label.Text = username;
                P1Button.Text = "Log out";
            }
            else
            {
                p2Name = username;
                p2hash = hash;
                P2ProfileButton.Enabled = true;
                P2Label.Text = username;
                P2Button.Text = "Log out";
            }
        }
    }
}
