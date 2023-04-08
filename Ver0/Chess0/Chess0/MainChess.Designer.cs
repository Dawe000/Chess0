
namespace Chess0
{
    partial class MainChess
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
            this.components = new System.ComponentModel.Container();
            this.P1NameLabel = new System.Windows.Forms.Label();
            this.P2NameLabel = new System.Windows.Forms.Label();
            this.P2Pic = new System.Windows.Forms.PictureBox();
            this.P1Pic = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timeLabel2 = new System.Windows.Forms.Label();
            this.timeLabel1 = new System.Windows.Forms.Label();
            this.DrawButton = new System.Windows.Forms.Button();
            this.ResignButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.PointsLabel2 = new System.Windows.Forms.Label();
            this.PointsLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.P2Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1Pic)).BeginInit();
            this.SuspendLayout();
            // 
            // P1NameLabel
            // 
            this.P1NameLabel.AutoSize = true;
            this.P1NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.P1NameLabel.Font = new System.Drawing.Font("SF Movie Poster", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P1NameLabel.Location = new System.Drawing.Point(920, 391);
            this.P1NameLabel.Name = "P1NameLabel";
            this.P1NameLabel.Size = new System.Drawing.Size(106, 39);
            this.P1NameLabel.TabIndex = 2;
            this.P1NameLabel.Text = "label1";
            // 
            // P2NameLabel
            // 
            this.P2NameLabel.AutoSize = true;
            this.P2NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.P2NameLabel.Font = new System.Drawing.Font("SF Movie Poster", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P2NameLabel.Location = new System.Drawing.Point(920, 65);
            this.P2NameLabel.Name = "P2NameLabel";
            this.P2NameLabel.Size = new System.Drawing.Size(106, 39);
            this.P2NameLabel.TabIndex = 3;
            this.P2NameLabel.Text = "label1";
            // 
            // P2Pic
            // 
            this.P2Pic.BackColor = System.Drawing.SystemColors.ControlDark;
            this.P2Pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P2Pic.Location = new System.Drawing.Point(920, 116);
            this.P2Pic.Name = "P2Pic";
            this.P2Pic.Size = new System.Drawing.Size(180, 180);
            this.P2Pic.TabIndex = 10;
            this.P2Pic.TabStop = false;
            // 
            // P1Pic
            // 
            this.P1Pic.BackColor = System.Drawing.SystemColors.ControlDark;
            this.P1Pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P1Pic.Location = new System.Drawing.Point(920, 443);
            this.P1Pic.Name = "P1Pic";
            this.P1Pic.Size = new System.Drawing.Size(180, 180);
            this.P1Pic.TabIndex = 11;
            this.P1Pic.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timeLabel2
            // 
            this.timeLabel2.AutoSize = true;
            this.timeLabel2.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel2.Font = new System.Drawing.Font("SF Movie Poster", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeLabel2.Location = new System.Drawing.Point(920, 312);
            this.timeLabel2.Name = "timeLabel2";
            this.timeLabel2.Size = new System.Drawing.Size(0, 39);
            this.timeLabel2.TabIndex = 12;
            // 
            // timeLabel1
            // 
            this.timeLabel1.AutoSize = true;
            this.timeLabel1.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel1.Font = new System.Drawing.Font("SF Movie Poster", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeLabel1.Location = new System.Drawing.Point(920, 640);
            this.timeLabel1.Name = "timeLabel1";
            this.timeLabel1.Size = new System.Drawing.Size(0, 39);
            this.timeLabel1.TabIndex = 14;
            // 
            // DrawButton
            // 
            this.DrawButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DrawButton.Enabled = false;
            this.DrawButton.Font = new System.Drawing.Font("SF Movie Poster", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DrawButton.Location = new System.Drawing.Point(920, 731);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(230, 126);
            this.DrawButton.TabIndex = 16;
            this.DrawButton.Text = "Draw";
            this.DrawButton.UseVisualStyleBackColor = false;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // ResignButton
            // 
            this.ResignButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ResignButton.Enabled = false;
            this.ResignButton.Font = new System.Drawing.Font("SF Movie Poster", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ResignButton.Location = new System.Drawing.Point(920, 863);
            this.ResignButton.Name = "ResignButton";
            this.ResignButton.Size = new System.Drawing.Size(230, 126);
            this.ResignButton.TabIndex = 17;
            this.ResignButton.Text = "Resign";
            this.ResignButton.UseVisualStyleBackColor = false;
            this.ResignButton.Click += new System.EventHandler(this.ResignButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SettingsButton.Font = new System.Drawing.Font("SF Movie Poster", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SettingsButton.Location = new System.Drawing.Point(1165, 800);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(230, 126);
            this.SettingsButton.TabIndex = 18;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.settingsIcon_Click);
            // 
            // PointsLabel2
            // 
            this.PointsLabel2.AutoSize = true;
            this.PointsLabel2.Font = new System.Drawing.Font("SF Movie Poster", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PointsLabel2.Location = new System.Drawing.Point(1106, 116);
            this.PointsLabel2.Name = "PointsLabel2";
            this.PointsLabel2.Size = new System.Drawing.Size(107, 28);
            this.PointsLabel2.TabIndex = 19;
            this.PointsLabel2.Text = "Points: 0";
            // 
            // PointsLabel1
            // 
            this.PointsLabel1.AutoSize = true;
            this.PointsLabel1.Font = new System.Drawing.Font("SF Movie Poster", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PointsLabel1.Location = new System.Drawing.Point(1106, 443);
            this.PointsLabel1.Name = "PointsLabel1";
            this.PointsLabel1.Size = new System.Drawing.Size(107, 28);
            this.PointsLabel1.TabIndex = 20;
            this.PointsLabel1.Text = "Points: 0";
            // 
            // MainChess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1407, 953);
            this.Controls.Add(this.PointsLabel1);
            this.Controls.Add(this.PointsLabel2);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.ResignButton);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.timeLabel1);
            this.Controls.Add(this.timeLabel2);
            this.Controls.Add(this.P1Pic);
            this.Controls.Add(this.P2Pic);
            this.Controls.Add(this.P2NameLabel);
            this.Controls.Add(this.P1NameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainChess";
            this.Text = "MainChess";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainChess_FormClosed);
            this.Load += new System.EventHandler(this.MainChess_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainChess_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.P2Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1Pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label P1NameLabel;
        private System.Windows.Forms.Label P2NameLabel;
        private System.Windows.Forms.PictureBox P2Pic;
        private System.Windows.Forms.PictureBox P1Pic;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label timeLabel2;
        private System.Windows.Forms.Label timeLabel1;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Button ResignButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Label PointsLabel2;
        private System.Windows.Forms.Label PointsLabel1;
    }
}