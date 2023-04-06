
namespace Chess0
{
    partial class ProfileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProfileImage = new System.Windows.Forms.PictureBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.GamesLabel = new System.Windows.Forms.Label();
            this.WinsLabel = new System.Windows.Forms.Label();
            this.DrawLabel = new System.Windows.Forms.Label();
            this.LossLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ProfileImage
            // 
            this.ProfileImage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ProfileImage.Location = new System.Drawing.Point(12, 12);
            this.ProfileImage.Name = "ProfileImage";
            this.ProfileImage.Size = new System.Drawing.Size(180, 180);
            this.ProfileImage.TabIndex = 9;
            this.ProfileImage.TabStop = false;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("SF Movie Poster", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UsernameLabel.Location = new System.Drawing.Point(198, 12);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(239, 39);
            this.UsernameLabel.TabIndex = 10;
            this.UsernameLabel.Text = "UsernameLabel";
            // 
            // ChangeButton
            // 
            this.ChangeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ChangeButton.Font = new System.Drawing.Font("SF Movie Poster", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChangeButton.Location = new System.Drawing.Point(12, 198);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(180, 59);
            this.ChangeButton.TabIndex = 11;
            this.ChangeButton.Text = "Change";
            this.ChangeButton.UseVisualStyleBackColor = false;
            // 
            // GamesLabel
            // 
            this.GamesLabel.AutoSize = true;
            this.GamesLabel.Font = new System.Drawing.Font("SF Movie Poster", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GamesLabel.Location = new System.Drawing.Point(198, 78);
            this.GamesLabel.Name = "GamesLabel";
            this.GamesLabel.Size = new System.Drawing.Size(176, 31);
            this.GamesLabel.TabIndex = 12;
            this.GamesLabel.Text = "Games Played:";
            // 
            // WinsLabel
            // 
            this.WinsLabel.AutoSize = true;
            this.WinsLabel.Font = new System.Drawing.Font("SF Movie Poster", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WinsLabel.Location = new System.Drawing.Point(198, 125);
            this.WinsLabel.Name = "WinsLabel";
            this.WinsLabel.Size = new System.Drawing.Size(84, 31);
            this.WinsLabel.TabIndex = 13;
            this.WinsLabel.Text = "Wins: ";
            // 
            // DrawLabel
            // 
            this.DrawLabel.AutoSize = true;
            this.DrawLabel.Font = new System.Drawing.Font("SF Movie Poster", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DrawLabel.Location = new System.Drawing.Point(198, 171);
            this.DrawLabel.Name = "DrawLabel";
            this.DrawLabel.Size = new System.Drawing.Size(95, 31);
            this.DrawLabel.TabIndex = 14;
            this.DrawLabel.Text = "Draws:";
            // 
            // LossLabel
            // 
            this.LossLabel.AutoSize = true;
            this.LossLabel.Font = new System.Drawing.Font("SF Movie Poster", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LossLabel.Location = new System.Drawing.Point(198, 218);
            this.LossLabel.Name = "LossLabel";
            this.LossLabel.Size = new System.Drawing.Size(103, 31);
            this.LossLabel.TabIndex = 15;
            this.LossLabel.Text = "Losses:";
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(444, 275);
            this.Controls.Add(this.LossLabel);
            this.Controls.Add(this.DrawLabel);
            this.Controls.Add(this.WinsLabel);
            this.Controls.Add(this.GamesLabel);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.ProfileImage);
            this.Name = "ProfileForm";
            this.Text = "ProfileForm";
            ((System.ComponentModel.ISupportInitialize)(this.ProfileImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ProfileImage;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.Label GamesLabel;
        private System.Windows.Forms.Label WinsLabel;
        private System.Windows.Forms.Label DrawLabel;
        private System.Windows.Forms.Label LossLabel;
    }
}