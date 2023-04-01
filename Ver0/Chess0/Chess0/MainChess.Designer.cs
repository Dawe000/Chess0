
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
            this.StateLabel = new System.Windows.Forms.Label();
            this.settingsIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.settingsIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // StateLabel
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Font = new System.Drawing.Font("SF Movie Poster", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StateLabel.Location = new System.Drawing.Point(1110, 76);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(181, 39);
            this.StateLabel.TabIndex = 0;
            this.StateLabel.Text = "StateLabel";
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
            // MainChess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 1055);
            this.Controls.Add(this.settingsIcon);
            this.Controls.Add(this.StateLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainChess";
            this.Text = "MainChess";
            this.Load += new System.EventHandler(this.MainChess_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainChess_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.settingsIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StateLabel;
        private System.Windows.Forms.PictureBox settingsIcon;
    }
}