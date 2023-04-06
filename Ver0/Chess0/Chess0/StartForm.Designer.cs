
namespace Chess0
{
    partial class StartForm
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
            this.StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.P1Label = new System.Windows.Forms.Label();
            this.P2Label = new System.Windows.Forms.Label();
            this.P1Button = new System.Windows.Forms.Button();
            this.P2Button = new System.Windows.Forms.Button();
            this.P1Pic = new System.Windows.Forms.PictureBox();
            this.P2Pic = new System.Windows.Forms.PictureBox();
            this.P1ProfileButton = new System.Windows.Forms.Button();
            this.P2ProfileButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.P1Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2Pic)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.StartButton.Font = new System.Drawing.Font("SF Movie Poster", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartButton.Location = new System.Drawing.Point(24, 471);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(502, 90);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Movie Poster", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(24, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player one:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SF Movie Poster", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(346, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Player two:";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("PR Celtic Narrow", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TitleLabel.Location = new System.Drawing.Point(159, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(256, 133);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "Chess0";
            // 
            // P1Label
            // 
            this.P1Label.AutoSize = true;
            this.P1Label.Font = new System.Drawing.Font("SF Movie Poster", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P1Label.Location = new System.Drawing.Point(141, 155);
            this.P1Label.Name = "P1Label";
            this.P1Label.Size = new System.Drawing.Size(69, 23);
            this.P1Label.TabIndex = 4;
            this.P1Label.Text = "Guest1";
            // 
            // P2Label
            // 
            this.P2Label.AutoSize = true;
            this.P2Label.Font = new System.Drawing.Font("SF Movie Poster", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P2Label.Location = new System.Drawing.Point(463, 155);
            this.P2Label.Name = "P2Label";
            this.P2Label.Size = new System.Drawing.Size(74, 23);
            this.P2Label.TabIndex = 5;
            this.P2Label.Text = "Guest2";
            // 
            // P1Button
            // 
            this.P1Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.P1Button.Font = new System.Drawing.Font("SF Movie Poster", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P1Button.Location = new System.Drawing.Point(24, 199);
            this.P1Button.Name = "P1Button";
            this.P1Button.Size = new System.Drawing.Size(83, 48);
            this.P1Button.TabIndex = 6;
            this.P1Button.Text = "Login";
            this.P1Button.UseVisualStyleBackColor = false;
            this.P1Button.Click += new System.EventHandler(this.LoginClick);
            // 
            // P2Button
            // 
            this.P2Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.P2Button.Font = new System.Drawing.Font("SF Movie Poster", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P2Button.Location = new System.Drawing.Point(346, 199);
            this.P2Button.Name = "P2Button";
            this.P2Button.Size = new System.Drawing.Size(85, 48);
            this.P2Button.TabIndex = 7;
            this.P2Button.Text = "Login";
            this.P2Button.UseVisualStyleBackColor = false;
            this.P2Button.Click += new System.EventHandler(this.LoginClick);
            // 
            // P1Pic
            // 
            this.P1Pic.BackColor = System.Drawing.SystemColors.ControlDark;
            this.P1Pic.Location = new System.Drawing.Point(24, 269);
            this.P1Pic.Name = "P1Pic";
            this.P1Pic.Size = new System.Drawing.Size(180, 180);
            this.P1Pic.TabIndex = 8;
            this.P1Pic.TabStop = false;
            // 
            // P2Pic
            // 
            this.P2Pic.BackColor = System.Drawing.SystemColors.ControlDark;
            this.P2Pic.Location = new System.Drawing.Point(346, 269);
            this.P2Pic.Name = "P2Pic";
            this.P2Pic.Size = new System.Drawing.Size(180, 180);
            this.P2Pic.TabIndex = 9;
            this.P2Pic.TabStop = false;
            // 
            // P1ProfileButton
            // 
            this.P1ProfileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.P1ProfileButton.Font = new System.Drawing.Font("SF Movie Poster", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P1ProfileButton.Location = new System.Drawing.Point(113, 199);
            this.P1ProfileButton.Name = "P1ProfileButton";
            this.P1ProfileButton.Size = new System.Drawing.Size(91, 48);
            this.P1ProfileButton.TabIndex = 11;
            this.P1ProfileButton.Text = "Profile";
            this.P1ProfileButton.UseVisualStyleBackColor = false;
            // 
            // P2ProfileButton
            // 
            this.P2ProfileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.P2ProfileButton.Font = new System.Drawing.Font("SF Movie Poster", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P2ProfileButton.Location = new System.Drawing.Point(435, 199);
            this.P2ProfileButton.Name = "P2ProfileButton";
            this.P2ProfileButton.Size = new System.Drawing.Size(91, 48);
            this.P2ProfileButton.TabIndex = 12;
            this.P2ProfileButton.Text = "Profile";
            this.P2ProfileButton.UseVisualStyleBackColor = false;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(553, 588);
            this.Controls.Add(this.P2ProfileButton);
            this.Controls.Add(this.P1ProfileButton);
            this.Controls.Add(this.P2Pic);
            this.Controls.Add(this.P1Pic);
            this.Controls.Add(this.P2Button);
            this.Controls.Add(this.P1Button);
            this.Controls.Add(this.P2Label);
            this.Controls.Add(this.P1Label);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartButton);
            this.Name = "StartForm";
            this.Text = "StartForm";
            ((System.ComponentModel.ISupportInitialize)(this.P1Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2Pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label P1Label;
        private System.Windows.Forms.Label P2Label;
        private System.Windows.Forms.Button P1Button;
        private System.Windows.Forms.Button P2Button;
        private System.Windows.Forms.PictureBox P1Pic;
        private System.Windows.Forms.PictureBox P2Pic;
        private System.Windows.Forms.Button P1ProfileButton;
        private System.Windows.Forms.Button P2ProfileButton;
    }
}