using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Chess0
{
    public partial class LoginForm : Form
    {
        string player;
        string[] usedNames;
        List<string> userNames;
        List<string> hashes;
        StartForm main;

        public LoginForm(string iplayer,string ip1, string ip2,StartForm s)
        {
            InitializeComponent();
            main = s;
            player = iplayer;
            usedNames = new string[] { ip1, ip2 };
            userNames = System.IO.File.ReadAllLines(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RequiredFiles\Users.txt").ToList();
            hashes = System.IO.File.ReadAllLines(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RequiredFiles\Hashes.txt").ToList() ;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (!userNames.Contains(UsernameBox.Text))
            {
                InfoLBL.Text = "No account with this username exists";
                return;
            }
            if (usedNames.Contains(UsernameBox.Text))
            {
                InfoLBL.Text = "Already logged in";
                return;
            }
            int i = 0;
            while (userNames[i] != UsernameBox.Text)
            {
                i++;
            }
            Crypt c = new Crypt(PasswordBox.Text);
            if (c.MD5HashGen(PasswordBox.Text + "EXTRA") == hashes[i])
            {
                login();
            }
            else
            {
                InfoLBL.Text = "Incorrect Password";
            }
            
        }

        private void login()
        {
            Crypt c = new Crypt(PasswordBox.Text);
            main.Login(UsernameBox.Text, c.MD5HashGen(PasswordBox.Text), player);
            this.Close();
            main.Enabled = true;
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (UsernameBox.TextLength>6 || UsernameBox.TextLength < 1)
            {
                InfoLBL.Text = "Invalid username length";
                return;
            }
            if (userNames.Contains(UsernameBox.Text)){
                InfoLBL.Text = "Username taken";
                return;
            }
            if (UsernameBox.Text == "Guest1" || UsernameBox.Text == "Guest2")
            {
                InfoLBL.Text = "Invalid username";
                return;
            }
            if (PasswordBox.TextLength<6 || PasswordBox.TextLength > 12)
            {
                InfoLBL.Text = "Invalid password length";
                return;
            }
            if (!PasswordBox.Text.Any(char.IsDigit) || int.TryParse(PasswordBox.Text,out _) || !PasswordBox.Text.Any(ch => !char.IsLetterOrDigit(ch))|| PasswordBox.Text.Contains(' ')) 
            {
                InfoLBL.Text = "Password does not meet requirements";
                return;
            }
            
            string NewDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RequiredFiles\" + UsernameBox.Text;
            System.IO.Directory.CreateDirectory(NewDirectory);
            using (StreamWriter sw = File.CreateText(NewDirectory + @"\ItemList.txt"))
            {

            }
            Crypt c = new Crypt(PasswordBox.Text);
            userNames.Add(UsernameBox.Text);
            System.IO.File.WriteAllLines(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RequiredFiles\Users.txt", userNames);
            hashes.Add(c.MD5HashGen(PasswordBox.Text + "EXTRA"));
            System.IO.File.WriteAllLines(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RequiredFiles\Hashes.txt", hashes);
            login();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Enabled = true;
        }
    }
}
