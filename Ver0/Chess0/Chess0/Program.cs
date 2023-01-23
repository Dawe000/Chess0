using System;

namespace Chess0
{
    class Program
    {
        static void Main(string[] args)
        {

            Chess c = new Chess(new string[] { "a", "b" },0,0);
            c.start();
            Console.Read();

        }
    }

}
