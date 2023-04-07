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
        string p1pass = "";
        string p2pass = "";
        Image p1image=default;
        Image p2image = default;
        public StartForm()
        {
            InitializeComponent();

        }

        public void StartButton_Click(object sender, EventArgs e)
        {
            MainChess m = new MainChess(p1Name, p2Name,this,p1image,p2image);
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
                    p1pass = "";
                    P1ProfileButton.Enabled = false;
                    P1Label.Text = "Guest1";
                    p1image = default;
                    P1Pic.BackgroundImage = default;
                }
                else
                {
                    p2Name = "Guest2";
                    p2pass = "";
                    P2ProfileButton.Enabled = false;
                    P2Label.Text = "Guest2";
                    p2image = default;
                    P2Pic.BackgroundImage = default;
                }
                return;
            }
            LoginForm l = new LoginForm(s.Name, p1Name, p2Name,this);
            l.Show();
            this.Enabled = false;
        }
        public void Login(string username, string hash, string player, Image i)
        {
            string p = Convert.ToString(player[1]);
            if (p == "1")
            {
                p1Name = username;
                p1pass = hash;
                P1ProfileButton.Enabled = true;
                P1Label.Text = username;
                P1Button.Text = "Log out";
                p1image = i;
                P1Pic.BackgroundImage = i;
            }
            else
            {
                p2Name = username;
                p2pass = hash;
                P2ProfileButton.Enabled = true;
                P2Label.Text = username;
                P2Button.Text = "Log out";
                p2image = i;
                P2Pic.BackgroundImage = i;
            }
        }

        private void P1ProfileButton_Click(object sender, EventArgs e)
        {
            ProfileForm p = new ProfileForm(p1Name, p1pass,this,1);
            p.Show();
            this.Enabled = false;
        }

        private void P2ProfileButton_Click(object sender, EventArgs e)
        {
            ProfileForm p = new ProfileForm(p2Name, p2pass, this,2);
            p.Show();
            this.Enabled = false;
        }

        public void UpdateImage(int p, Image i)
        {
            if (p == 1)
            {
                p1image = i;
                P1Pic.BackgroundImage = i;
            }
            else
            {
                p2image = i;
                P2Pic.BackgroundImage = i;
            }
        }

    }
}
