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
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Welcome to Chess0");
            //Chess c = new Chess(new string[] { "a", "b" },0,0);
            //c.start();
            //Console.Read();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());


        }
    }

}
