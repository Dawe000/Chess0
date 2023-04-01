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
    public partial class SettingsForm : Form
    {
        Color moveColor;
        Color checkColor;
        Color backColor;
        Color textColor;
        Color color1;
        Color color2;
        MainChess main;
        public SettingsForm(MainChess input, Color[] iColors, Color iCheck, Color iBack, Color iText, Color iMove)
        {
            InitializeComponent();
            main = input;
            moveColor = iMove;
            checkColor = iCheck;
            color1 = iColors[0];
            color2 = iColors[1];
            textColor = iText;
            backColor = iBack;

            s1Clr.BackColor = color1;
            s2Clr.BackColor = color2;
            moveClr.BackColor = moveColor;
            checkClr.BackColor = checkColor;
            txtClr.BackColor = textColor;
            backClr.BackColor = backColor;

            clr1diag.Color = color1;
            clr2diag.Color = color2;
            textdiag.Color = textColor;
            backdiag.Color = backColor;
            movediag.Color = moveColor;
            checkdiag.Color = checkColor;

        }



        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Enabled = true;
            main.UpdateColors(color1, color2, moveColor, checkColor, backColor, textColor);
        }

        private void Color1Btn_Click(object sender, EventArgs e)
        {
            clr1diag.ShowDialog();
            s1Clr.BackColor=clr1diag.Color;
            color1 = clr1diag.Color;
        }

        private void Color2Btn_Click(object sender, EventArgs e)
        {
            clr2diag.ShowDialog();
            s2Clr.BackColor = clr2diag.Color;
            color2 = clr2diag.Color;
        }

        private void CheckColorBtn_Click(object sender, EventArgs e)
        {
            checkdiag.ShowDialog();
            checkClr.BackColor = checkdiag.Color;
            checkColor = checkdiag.Color;
        }

        private void MoveColorBtn_Click(object sender, EventArgs e)
        {
            movediag.ShowDialog();
            moveClr.BackColor = movediag.Color;
            moveColor = movediag.Color;
        }

        private void BackColorBtn_Click(object sender, EventArgs e)
        {
            backdiag.ShowDialog();
            backClr.BackColor = backdiag.Color;
            backColor = backdiag.Color;
            BackColor = backColor;
        }

        private void TextClrBtn_Click(object sender, EventArgs e)
        {
            textdiag.ShowDialog();
            txtClr.BackColor = textdiag.Color;
            textColor = textdiag.Color;
        }
    }
}
