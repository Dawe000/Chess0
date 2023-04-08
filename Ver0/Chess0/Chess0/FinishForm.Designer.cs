
namespace Chess0
{
    partial class FinishForm
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
            this.ReplayButton = new System.Windows.Forms.Button();
            this.MenuButton = new System.Windows.Forms.Button();
            this.statelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ReplayButton
            // 
            this.ReplayButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ReplayButton.Font = new System.Drawing.Font("SF Movie Poster", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ReplayButton.Location = new System.Drawing.Point(9, 121);
            this.ReplayButton.Name = "ReplayButton";
            this.ReplayButton.Size = new System.Drawing.Size(248, 126);
            this.ReplayButton.TabIndex = 0;
            this.ReplayButton.Text = "Replay";
            this.ReplayButton.UseVisualStyleBackColor = false;
            this.ReplayButton.Click += new System.EventHandler(this.ReplayButton_Click);
            // 
            // MenuButton
            // 
            this.MenuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MenuButton.Font = new System.Drawing.Font("SF Movie Poster", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MenuButton.Location = new System.Drawing.Point(281, 121);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(248, 126);
            this.MenuButton.TabIndex = 1;
            this.MenuButton.Text = "Main Menu";
            this.MenuButton.UseVisualStyleBackColor = false;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // statelabel
            // 
            this.statelabel.AutoSize = true;
            this.statelabel.BackColor = System.Drawing.Color.Transparent;
            this.statelabel.Font = new System.Drawing.Font("SF Movie Poster", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statelabel.Location = new System.Drawing.Point(9, 9);
            this.statelabel.MinimumSize = new System.Drawing.Size(520, 100);
            this.statelabel.Name = "statelabel";
            this.statelabel.Size = new System.Drawing.Size(520, 100);
            this.statelabel.TabIndex = 2;
            this.statelabel.Text = "label1";
            this.statelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FinishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(541, 259);
            this.Controls.Add(this.statelabel);
            this.Controls.Add(this.MenuButton);
            this.Controls.Add(this.ReplayButton);
            this.Name = "FinishForm";
            this.Text = "FinishForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FinishForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReplayButton;
        private System.Windows.Forms.Button MenuButton;
        private System.Windows.Forms.Label statelabel;
    }
}