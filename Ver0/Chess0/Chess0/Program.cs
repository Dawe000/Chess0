using System;

namespace Chess0
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class Chess
    {
        char[,] board;
        string[] players;
        int[] points;
        int[] time;
        int increment;

        public Chess(string[] iPlayers, int iTime, int iIncrement)
        {
            board = new char[,]{ 
                    { 'R','N','B','K','Q','B','N','R' },
                    { 'P','P','P','P','P','P','P','P' },
                    { ' ',' ',' ',' ',' ',' ',' ',' ' },
                    { ' ',' ',' ',' ',' ',' ',' ',' ' },
                    { ' ',' ',' ',' ',' ',' ',' ',' ' },
                    { ' ',' ',' ',' ',' ',' ',' ',' ' },
                    { 'P','P','P','P','P','P','P','P' },
                    { 'R','N','B','K','Q','B','N','R' }};
            players = iPlayers;
            points = new int[] { 0, 0 };
            time = new int[] { iTime, iTime };
            increment = iIncrement;


        }

    }
        
}
