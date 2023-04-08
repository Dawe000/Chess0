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
        public string p1pass = "";
        public string p2pass = "";
        Image p1image=default;
        Image p2image = default;
        public StartForm()
        {
            InitializeComponent();

        }

        public void StartButton_Click(object sender, EventArgs e) //runs necessary validation for the time control before starting the game
        {
            int t = 0;
            int i = 0;
            if (TimeControlToggle.Checked == true)
            {
                if (!int.TryParse(MinutesBox.Text, out _))
                {
                    MessageBox.Show("Invalid minutes value", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!int.TryParse(SecondsBox.Text, out _))
                {
                    MessageBox.Show("Invalid seconds value", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!int.TryParse(IncrementBox.Text, out _))
                {
                    MessageBox.Show("Invalid increment value", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (Convert.ToInt32(SecondsBox.Text)>59 || Convert.ToInt32(SecondsBox.Text) < 0)
                {
                    MessageBox.Show("Invalid number of seconds", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (Convert.ToInt32(MinutesBox.Text) * 60 + Convert.ToInt32(SecondsBox.Text) < 5)
                {
                    MessageBox.Show("Time too low", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (Convert.ToInt32(MinutesBox.Text) * 60 + Convert.ToInt32(SecondsBox.Text) > 54000)
                {
                    MessageBox.Show("Time too high", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (Convert.ToInt32(MinutesBox.Text) < 0)
                {
                    MessageBox.Show("Invalid number of minutes", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (Convert.ToInt32(IncrementBox.Text) > 60 || Convert.ToInt32(IncrementBox.Text) < 0)
                {
                    MessageBox.Show("Invalid increment", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    t = Convert.ToInt32(MinutesBox.Text) * 60 + Convert.ToInt32(SecondsBox.Text);
                    i = Convert.ToInt32(IncrementBox.Text);
                }
            }
                
            MainChess m = new MainChess(p1Name, p2Name,this,p1image,p2image,t,i,TimeControlToggle.Checked); //starts a game of chess and hides this form
            m.Show();
            this.Hide();
            this.Enabled = false;
        }

        private void LoginClick(object sender, EventArgs e) //either opens the login page or, if a user is already logged in, logs them out
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
        public void Login(string username, string hash, string player, Image i) //takes the parameters sent by the login form and applies them to this one
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

        private void P1ProfileButton_Click(object sender, EventArgs e) //opens profile form for player one
        {
            ProfileForm p = new ProfileForm(p1Name, p1pass,this,1);
            p.Show();
            this.Enabled = false;
        }

        private void P2ProfileButton_Click(object sender, EventArgs e) //opens profile form for player two
        {
            ProfileForm p = new ProfileForm(p2Name, p2pass, this,2);
            p.Show();
            this.Enabled = false;
        }

        public void UpdateImage(int p, Image i) //updates the image for either player
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

        private void TimeControlToggle_CheckedChanged(object sender, EventArgs e) //allows the time control to be edited only when the checkbox is checked
        {
            if (TimeControlToggle.Checked)
            {
                IncrementBox.Enabled = true;
                SecondsBox.Enabled = true;
                MinutesBox.Enabled = true;
            }
            else
            {
                IncrementBox.Enabled = false;
                SecondsBox.Enabled = false;
                MinutesBox.Enabled = false;
            }
        }
    }
}
