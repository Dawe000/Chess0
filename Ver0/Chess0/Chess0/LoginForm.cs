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

        public LoginForm(string iplayer,string ip1, string ip2,StartForm s) //constructor, finds all the usernames and hashes ready for logging in and registering new users
        {
            InitializeComponent();
            main = s;
            player = iplayer;
            usedNames = new string[] { ip1, ip2 };
            userNames = System.IO.File.ReadAllLines(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RequiredFiles\Users.txt").ToList();
            hashes = System.IO.File.ReadAllLines(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RequiredFiles\Hashes.txt").ToList() ;
        }

        private void LoginButton_Click(object sender, EventArgs e) //runs when the login button is clicked
        {
            if (!userNames.Contains(UsernameBox.Text)) //checks if the account exists
            {
                InfoLBL.Text = "No account with this username exists";
                return;
            }
            if (usedNames.Contains(UsernameBox.Text)) //checks if the account is already logged in
            {
                InfoLBL.Text = "Already logged in";
                return;
            }
            int i = 0;
            while (userNames[i] != UsernameBox.Text) //finds index of username in username list
            {
                i++;
            }
            Crypt c = new Crypt(PasswordBox.Text); 
            if (c.MD5HashGen(PasswordBox.Text + "EXTRA") == hashes[i]) //check if password entered matches the corresponding hash
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
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RequiredFiles\" + UsernameBox.Text;
            Image profileImage = default;
            if (File.Exists(path + @"\ProfilePicture.png")) //finds the users profile picture if it exists
            {
                using (FileStream stream = new FileStream(path + @"\ProfilePicture.png", FileMode.Open, FileAccess.Read))
                {
                    profileImage = Image.FromStream(stream);
                }
            }
            Crypt c = new Crypt(PasswordBox.Text);
            main.Login(UsernameBox.Text, PasswordBox.Text, player,profileImage); //send account information to menu form
            this.Close();
            main.Enabled = true;
        }
        private void RegisterButton_Click(object sender, EventArgs e) //run when the register button is clicked
        {
            if (UsernameBox.TextLength>6 || UsernameBox.TextLength < 1) //checks username length
            {
                InfoLBL.Text = "Invalid username length";
                return;
            }
            if (userNames.Contains(UsernameBox.Text)){ //checks if username is taken
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
            if (!PasswordBox.Text.Any(char.IsLetter) || !PasswordBox.Text.Any(char.IsDigit) || int.TryParse(PasswordBox.Text,out _) || !PasswordBox.Text.Any(ch => !char.IsLetterOrDigit(ch))|| PasswordBox.Text.Contains(' ')) 
            {
                InfoLBL.Text = "Password does not meet requirements";
                return;
            }
            
            string NewDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RequiredFiles\" + UsernameBox.Text; //creates a new directory for the new user
            System.IO.Directory.CreateDirectory(NewDirectory);
            using (StreamWriter sw = File.CreateText(NewDirectory + @"\Data.txt"))
            {

            }
            Crypt c = new Crypt(PasswordBox.Text);
            userNames.Add(UsernameBox.Text);
            System.IO.File.WriteAllLines(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RequiredFiles\Users.txt", userNames); //adds the new users username to the username list
            hashes.Add(c.MD5HashGen(PasswordBox.Text + "EXTRA"));
            System.IO.File.WriteAllLines(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RequiredFiles\Hashes.txt", hashes); //adds the new users password hash to the hashes
            string data = "0^0^0^0";
            string cypherText = c.FullEncrypt(data);
            System.IO.File.WriteAllText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RequiredFiles\"+UsernameBox.Text+@"\Data.txt", cypherText); //encrypts the new users data and stores it in their directory
            login();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Enabled = true; 
        }
    }
}
