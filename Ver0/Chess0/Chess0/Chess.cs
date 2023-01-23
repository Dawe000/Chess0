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
        bool[,] castle;

        public Chess(string[] iPlayers, int iTime, int iIncrement)
        {
            board = new string[,]{ //0 is white, 1 is black
                    { "0R","0N","0B","0Q","0K","0B","0N","0R" },
                    { "0P","0P","0P","0P","0P","0P","0P","0P" },
                    { "  ","  ","  ","  ","  ","  ","  ","  " },
                    { "  ","  ","  ","0B","  ","  ","  ","  " },
                    { "  ","  ","  ","  ","  ","  ","  ","  " },
                    { "  ","  ","  ","  ","  ","  ","  ","  " },
                    { "1P","1P","1P","1P","1P","1P","1P","1P" },
                    { "1R","1N","1B","1Q","1K","1B","1N","1R" }};
            players = iPlayers;
            points = new int[] { 0, 0 }; 
            time = new int[] { iTime, iTime }; //time total
            increment = iIncrement; //time increment after move
            turn = 0; //0 is white, 1 is black
            enPassant = new int[] {8,8}; //position of en-passantable pawn
            castle = new bool[,] {{true,true},{true,true}}; //queenside, kingside
        }

        public Chess(PGN iPGN){
            
        }

        public int[][,] CheckPossibleMoves(int[] pos) //returns all legal moves for a piece
        {
            char type = board[pos[0], pos[1]][1];
            int attacker = Convert.ToInt32(Convert.ToString(board[pos[0], pos[1]][0]));
            List<int[,]> possibleMoves = new List<int[,]>{};
            
            switch (type){
                case 'P': //pawn movement
                    if (attacker == 0){//white
                        if (board[pos[0]+1,pos[1]]=="  ") possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]},{8,8} }); //move forward
                        if (pos[1] - 1 != -1) if (board[pos[0]+1,pos[1]-1]!="  ") if (Convert.ToInt16(Convert.ToString(board[pos[0]+1,pos[1]-1]))!=attacker) possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]-1},{pos[0]+1,pos[1]-1}}); //attack to the left
                        if (pos[1] - 1 != 8) if (board[pos[0]+1,pos[1]+1]!="  ") if (Convert.ToInt16(Convert.ToString(board[pos[0]+1,pos[1]+1]))!=attacker) possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]+1},{pos[0]+1,pos[1]+1}}); //attack to the right
                        if (board[pos[0]+1,pos[1]]=="  " && board[pos[0]+2,pos[1]]=="  " && pos[0]==1) possibleMoves.Add(new int[,] {{pos[0]+2,pos[1]},{8,8} }); //move 2 forward
                        if (enPassant[0] < 8) if (board[pos[0]+1,pos[1]-1]!="  "&&pos[0]==enPassant[0]&&pos[1]-1==enPassant[1]) possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]-1},{enPassant[0],enPassant[1]} }); //en passant left
                        if (enPassant[0] < 8)  if (board[pos[0]+1,pos[1]+1]!="  "&&pos[0]==enPassant[0]&&pos[1]+1==enPassant[1]) possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]+1},{enPassant[0],enPassant[1]} }); //en passant right
                    }
                    else{//black
                        if (board[pos[0]-1,pos[1]]=="  ") possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]},{8,8} }); //move forward
                        if (pos[1] - 1 != -1) if (board[pos[0]-1,pos[1]-1]!="  ") if (Convert.ToInt16(Convert.ToString(board[pos[0]-1,pos[1]-1]))!=attacker) possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]-1},{pos[0]-1,pos[1]-1}}); //attack to the left
                        if (pos[1] - 1 != 8) if (board[pos[0]-1,pos[1]+1]!="  ") if (Convert.ToInt16(Convert.ToString(board[pos[0]-1,pos[1]+1]))!=attacker) possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]+1},{pos[0]-1,pos[1]+1}}); //attack to the right
                        if (board[pos[0]-1,pos[1]]=="  " && board[pos[0]-2,pos[1]]=="  " && pos[0]==1) possibleMoves.Add(new int[,] {{pos[0]-2,pos[1]},{8,8} }); //move 2 forward
                        if (enPassant[0] < 8) if (board[pos[0]-1,pos[1]-1]!="  "&&pos[0]==enPassant[0]&&pos[1]-1==enPassant[1]) possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]-1},{enPassant[0],enPassant[1]} }); //en passant left
                        if (enPassant[0] < 8)  if (board[pos[0]-1,pos[1]+1]!="  "&&pos[0]==enPassant[0]&&pos[1]+1==enPassant[1]) possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]+1},{enPassant[0],enPassant[1]} }); //en passant right
                    }
                    break;
                case 'N': //knight movement
                        if (pos[0]-2>-1){ //move down 2
                            if (pos[1]-1>-1){ //left 1
                                
                                if (board[pos[0]-2,pos[1]-1][0]==' ') possibleMoves.Add(new int[,] {{pos[0]-2,pos[1]-1},{8,8}});
                                else if (Convert.ToInt16(board[pos[0]-2,pos[1]-1][0]) != attacker) possibleMoves.Add(new int[,] {{pos[0]-2,pos[1]-1},{pos[0]-2,pos[1]-1}});
                            }
                            if (pos[1]+1<8){ //right 1
                                
                                if (board[pos[0]-2,pos[1]+1][0]==' ') possibleMoves.Add(new int[,] {{pos[0]-2,pos[1]+1},{8,8}});
                                else if (Convert.ToInt16(board[pos[0]-2,pos[1]+1][0]) != attacker) possibleMoves.Add(new int[,] {{pos[0]-2,pos[1]+1},{pos[0]-2,pos[1]+1}});
                            }
                        }
                        else if (pos[0]+2<8){ //move up 2
                            if (pos[1]-1>-1){ //left 1
                                
                                if (board[pos[0]+2,pos[1]-1][0]==' ') possibleMoves.Add(new int[,] {{pos[0]+2,pos[1]-1},{8,8}});
                                else if (Convert.ToInt16(board[pos[0]+2,pos[1]-1][0]) != attacker) possibleMoves.Add(new int[,] {{pos[0]+2,pos[1]-1},{pos[0]+2,pos[1]-1}});
                            }
                            if (pos[1]+1<8){ //right 1
                                
                                if (board[pos[0]+2,pos[1]+1][0]==' ') possibleMoves.Add(new int[,] {{pos[0]+2,pos[1]+1},{8,8}});
                                else if (Convert.ToInt16(board[pos[0]+2,pos[1]+1][0]) != attacker) possibleMoves.Add(new int[,] {{pos[0]+2,pos[1]+1},{pos[0]+2,pos[1]+1}});
                            }
                        }
                        else if (pos[0]-1>-1){ //move down 1
                            if (pos[1]-2>-1){ //left 2
                                
                                if (board[pos[0]-1,pos[1]-2][0]==' ') possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]-2},{8,8}});
                                else if (Convert.ToInt16(board[pos[0]-1,pos[1]-2][0]) != attacker) possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]-2},{pos[0]-1,pos[1]-2}});
                            }
                            if (pos[1]+2<8){ //right 2
                                
                                if (board[pos[0]-1,pos[1]+2][0]==' ') possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]+2},{8,8}});
                                else if (Convert.ToInt16(board[pos[0]-1,pos[1]+2][0]) != attacker) possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]+2},{pos[0]-1,pos[1]+2}});
                            }
                        }
                        else if (pos[0]+1<8){ //move up 1
                            if (pos[1]-2>-1){ //left 2
                                
                                if (board[pos[0]+1,pos[1]-2][0]==' ') possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]-2},{8,8}});
                                else if (Convert.ToInt16(board[pos[0]+1,pos[1]-2][0]) != attacker) possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]-2},{pos[0]+1,pos[1]-2}});
                            }
                            if (pos[1]+2<8){ //right 2
                                
                                if (board[pos[0]+1,pos[1]+2][0]==' ') possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]+2},{8,8}});
                                else if (Convert.ToInt16(board[pos[0]+2,pos[1]+2][0]) != attacker) possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]+2},{pos[0]+1,pos[1]+2}});
                            }
                        }
                    break;
                case 'K': //king movement
                    for (int y = -1; y<2; y++) if (pos[0] + y > -1 && pos[0] + y < 8){//basic king moves in every direction
                        for (int x = -1; x<2; x++) if (pos[1] + x > -1 && pos[1] + x < 8 && !(x==0 && y==0)){
                            if (board[pos[0]+y,pos[1]+x]=="  ") possibleMoves.Add(new int[,] {{pos[0]+y,pos[1]+x},{8,8} });
                            else if (Convert.ToInt16(Convert.ToString(board[pos[0]+y,pos[1]+x][0]))!=attacker) possibleMoves.Add(new int[,] {{pos[0]+y,pos[1]+x},{pos[0]+y,pos[1]+x}});
                        }
                    }
                    
                    if (attacker == 0){ //white castle
                        if (castle[0,0]){//queenside
                            if (board[0,1] == "  " && board[0,2] == "  " & board[0,3] == "  "){
                                
                                    //ADD CASTLE CODE LATER
                                
                            }
                        }
                        if (castle[0,1]){//kingside
                            if (board[0,5] == "  " && board[0,6] == "  "){
                                
                                    //ADD CASTLE CODE LATER
                                
                            }
                        }
                    }
                    else{ //black castle
                        if (castle[1,0]){//queenside
                            if (board[7,1] == "  " && board[7,2] == "  " & board[7,3] == "  "){
                                
                                    //ADD CASTLE CODE LATER
                                
                            }
                        }
                        if (castle[1,1]){//kingside
                            if (board[1,5] == "  " && board[1,6] == "  "){
                                
                                    //ADD CASTLE CODE LATER
                                
                            }
                        }
                    }
                    
                    break;
                case 'B': //bishop movement
                        possibleMoves.AddRange(checkBishopMoves(pos,attacker));
                    break;
                case 'R':

                    break;
                default:

                    break;
            }

            return possibleMoves.ToArray();
        }


        public int[][,] checkRookMoves(int[] pos, int attacker)
        {
            List<int[,]> possibleMoves = new List<int[,]> { };

            

            return possibleMoves.ToArray();
        }
        public int[][,] checkBishopMoves(int[] pos,int attacker){
            List<int[,]> possibleMoves = new List<int[,]>{};
            for (int i = 1; i < 8; i++) //down left
            {
                if (pos[0] - i > -1 && pos[1] - i > -1)
                {
                    if (board[pos[0] - i, pos[1] - i] == "  ")
                    {
                        possibleMoves.Add(new int[,] { { pos[0] - i, pos[1] - i }, { 8, 8 } });
                    }
                    else if ((Convert.ToInt16(Convert.ToString(board[pos[0] - i, pos[1] - i][0])) != attacker))
                    {
                        possibleMoves.Add(new int[,] { { pos[0] - i, pos[1] - i }, { pos[0] - i, pos[1] - i } });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++) //down up
            {
                if (pos[0] + i < 8 && pos[1] - i > -1)
                {
                    if (board[pos[0] + i, pos[1] - i] == "  ")
                    {
                        possibleMoves.Add(new int[,] { { pos[0] + i, pos[1] - i }, { 8, 8 } });
                    }
                    else if ((Convert.ToInt16(Convert.ToString(board[pos[0] + i, pos[1] - i][0])) != attacker))
                    {
                        possibleMoves.Add(new int[,] { { pos[0] + i, pos[1] - i }, { pos[0] + i, pos[1] - i } });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++) //down right
            {
                if (pos[0] - i > -1 && pos[1] + i < 8)
                {
                    if (board[pos[0] - i, pos[1] + i] == "  ")
                    {
                        possibleMoves.Add(new int[,] { { pos[0] - i, pos[1] + i }, { 8, 8 } });
                    }
                    else if ((Convert.ToInt16(Convert.ToString(board[pos[0] - i, pos[1] + i][0])) != attacker))
                    {
                        possibleMoves.Add(new int[,] { { pos[0] - i, pos[1] + i }, { pos[0] - i, pos[1] + i } });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++) //up right
            {
                if (pos[0] + i < 8 && pos[1] + i < 8)
                {
                    if (board[pos[0] + i, pos[1] + i] == "  ")
                    {
                        possibleMoves.Add(new int[,] { { pos[0] + i, pos[1] + i }, { 8, 8 } });
                    }
                    else if ((Convert.ToInt16(Convert.ToString(board[pos[0] + i, pos[1] + i][0])) != attacker))
                    {
                        possibleMoves.Add(new int[,] { { pos[0] + i, pos[1] + i }, { pos[0] + i, pos[1] + i } });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }



            return possibleMoves.ToArray();
        }

    }
}

