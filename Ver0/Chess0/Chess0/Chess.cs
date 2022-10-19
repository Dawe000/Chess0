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
        int[] enPassant;
        bool check;

        public Chess(string[] iPlayers, int iTime, int iIncrement)
        {
            board = new string[,]{ //0 is white, 1 is black
                    { "0R","0N","0B","0Q","0K","0B","0N","0R" },
                    { "0P","0P","0P","0P","0P","0P","0P","0P" },
                    { "","","","","","","","" },
                    { "","","","","","","","" },
                    { "","","","","","","","" },
                    { "","","","","","","","" },
                    { "1P","1P","1P","1P","1P","1P","1P","1P" },
                    { "1R","1N","1B","1Q","1K","1B","1N","1R" }};
            players = iPlayers;
            points = new int[] { 0, 0 };
            time = new int[] { iTime, iTime };
            increment = iIncrement;
            turn = 0;
            enPassant = new int[] {8,8};
        }

        public Chess(PGN iPGN){
            
        }

        public int[][,] CheckPossibleMoves(int[] pos) //returns all legal moves for a piece
        {
            char type = board[pos[0], pos[1]][1];
            List<int[,]> possibleMoves = new List<int[,]>{};
            
            switch (type){
                case 'P':
                    if (turn == 0){
                        if (board[pos[0]+1,pos[1]]=="") possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]},{8,8} }); //move forward
                        if (board[pos[0]+1,pos[1]-1]!=""&&pos[1]-1!=-1) possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]-1},{pos[0]+1,pos[1]-1}}); //attack to the left
                        if (board[pos[0]+1,pos[1]+1]!=""&&pos[1]-1!=8) possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]+1},{pos[0]+1,pos[1]+1}}); //attack to the right
                        if (board[pos[0]+1,pos[1]]=="" && board[pos[0]+2,pos[1]]=="" && pos[0]==0) possibleMoves.Add(new int[,] {{pos[0]+2,pos[1]},{8,8} }); //move 2 forward
                        if (board[pos[0]+1,pos[1]-1]!=""&&pos[0]==enPassant[0]&&pos[1]-1==enPassant[1]) possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]-1},{enPassant[0],enPassant[1]} }); //en passant left
                        if (board[pos[0]+1,pos[1]+1]!=""&&pos[0]==enPassant[0]&&pos[1]+1==enPassant[1]) possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]+1},{enPassant[0],enPassant[1]} }); //en passant right
                    }
                    break;
                case 'N':
                        
                    break;
                case 'K':

                    break;
                case 'B':

                    break;
                case 'R':

                    break;
                default:

                    break;
            }

            return possibleMoves.ToArray();
        }

    }
}

