using System;

namespace Chess0
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] move = new int[] { 0, 0 };
            move[0] = Convert.ToInt32(Convert.ToString(Console.ReadLine()));
            move[1] = Convert.ToInt32(Convert.ToString(Console.ReadLine()));
            Chess c = new Chess(new string[] { "a", "b" },0,0);
            int[][,] moves = (c.CheckPossibleMoves(move));
            foreach (int[,] i in moves)
            {
                foreach (int j in i)
                {
                    Console.Write(j);
                }
            }
            Console.Read();

        }
    }

}
