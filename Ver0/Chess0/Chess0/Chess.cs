using System;
using System.Collections.Generic;
using System.Text;

namespace Chess0
{
    public class Chess
    {
        string[,] board;
        string[] players;
        int[] points;
        int[] time;
        int increment;
        int turn;

        public Chess(string[] iPlayers, int iTime, int iIncrement)
        {
            board = new string[,]{
                    { "0R","0N","0B","0K","0Q","0B","0N","0R" },
                    { "0P","0P","0P","0P","0P","0P","0P","0P" },
                    { "","","","","","","","" },
                    { "","","","","","","","" },
                    { "","","","","","","","" },
                    { "","","","","","","","" },
                    { "1P","1P","1P","1P","1P","1P","1P","1P" },
                    { "1R","1N","1B","1K","1Q","1B","1N","1R" }};
            players = iPlayers;
            points = new int[] { 0, 0 };
            time = new int[] { iTime, iTime };
            increment = iIncrement;
            turn = 0;
        }

        public string[] CheckLegalMoves(int[] pos) //returns all legal moves for a piece
        {
            char type = board[pos[0], pos[1]][1];
        }

    }
}

