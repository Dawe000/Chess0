
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
            this.settingsIcon = new System.Windows.Forms.PictureBox();
            this.P1NameLabel = new System.Windows.Forms.Label();
            this.P2NameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.settingsIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsIcon
            // 
            this.settingsIcon.BackgroundImage = global::Chess0.Resources.Icons.settingsicon;
            this.settingsIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.settingsIcon.Image = global::Chess0.Resources.Icons.settingsicon;
            this.settingsIcon.Location = new System.Drawing.Point(1345, 12);
            this.settingsIcon.Name = "settingsIcon";
            this.settingsIcon.Size = new System.Drawing.Size(125, 125);
            this.settingsIcon.TabIndex = 1;
            this.settingsIcon.TabStop = false;
            this.settingsIcon.Click += new System.EventHandler(this.settingsIcon_Click);
            // 
            // P1NameLabel
            // 
            this.P1NameLabel.AutoSize = true;
            this.P1NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.P1NameLabel.Font = new System.Drawing.Font("SF Movie Poster", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P1NameLabel.Location = new System.Drawing.Point(1051, 611);
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
            this.P2NameLabel.Location = new System.Drawing.Point(1042, 62);
            this.P2NameLabel.Name = "P2NameLabel";
            this.P2NameLabel.Size = new System.Drawing.Size(106, 39);
            this.P2NameLabel.TabIndex = 3;
            this.P2NameLabel.Text = "label1";
            // 
            // MainChess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1482, 1055);
            this.Controls.Add(this.P2NameLabel);
            this.Controls.Add(this.P1NameLabel);
            this.Controls.Add(this.settingsIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainChess";
            this.Text = "MainChess";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainChess_FormClosed);
            this.Load += new System.EventHandler(this.MainChess_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainChess_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.settingsIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox settingsIcon;
        private System.Windows.Forms.Label P1NameLabel;
        private System.Windows.Forms.Label P2NameLabel;
    }
}