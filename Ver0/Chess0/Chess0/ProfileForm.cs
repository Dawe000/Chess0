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
    public partial class ProfileForm : Form
    {

        string userName;
        string passWord;
        Crypt c;
        StartForm main;
        Image profileImage;
        string path;
        int player;
        public ProfileForm(string u, string p, StartForm m, int n) //constructor, finds the players directory, decrypts and displays their information
        {
            InitializeComponent();
            userName = u;
            player = n;
            passWord = p;
            main = m;
            UsernameLabel.Text = userName;
            c = new Crypt(passWord);
            path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+ @"\RequiredFiles\" + userName;
            if (File.Exists(path + @"\ProfilePicture.png"))
            {
                using (FileStream stream = new FileStream(path + @"\ProfilePicture.png", FileMode.Open, FileAccess.Read))
                {
                    profileImage = Image.FromStream(stream);
                }
                ProfileImage.BackgroundImage = profileImage;
            }
            string cypheredData = File.ReadAllText(path + @"\Data.txt");
            string plainData = c.FullDecrypt(cypheredData);
            string[] plainArray = plainData.Split('^');
            GamesLabel.Text = "Games Played: " + plainArray[0];
            WinsLabel.Text = "Games Won: " + plainArray[1];
            DrawLabel.Text = "Games Drawn: " + plainArray[2];
            LossLabel.Text = "Games Lost: " + plainArray[3];
        }

        private void ChangeButton_Click(object sender, EventArgs e) //changes the profile picture of the player
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            bool test = false;
            Image img = default;
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) //use a windows open file dialogue, filtering for only PNG files
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "PNG files (*.png)|*.png";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    test = true;
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    
                    //Read the contents of the file into a stream
                    using (var fileStream = openFileDialog.OpenFile())
                    {
                        img = Image.FromStream(fileStream);
                    }
                    
                }

            }
            if (test) //runs if the file is selected, checks if its size is valid
            {
                if (img.Width < 180 || img.Height < 180)
                {
                    MessageBox.Show("Image must be at least 180x180", "Invalid Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (img.Width > 1000 || img.Height > 1000)
                {
                    MessageBox.Show("Image cannot be greater than 1000x1000", "Invalid Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    profileImage = img;
                    ProfileImage.BackgroundImage = profileImage;
                    File.Delete(path + @"\ProfilePicture.png");
                    profileImage.Save(path + @"\ProfilePicture.png"); //replaces the profile picture saved in files
                }
            }

        }

        private void ProfileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Enabled = true;
            main.UpdateImage(player, profileImage); //updates the profile picture in the main form
        }
    }
}
