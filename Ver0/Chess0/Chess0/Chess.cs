using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Chess0
{
    public class Chess
    {
        public string[,] board; //initialising required variables
        string[] players;
        public int[] points;
        int[] time;
        int increment;
        public int turn;
        int[] enPassant;
        public bool check;
        bool[,] castle;
        public string gameState;
        MainChess game;

        public Chess(string[] iPlayers, int iTime, int iIncrement)
        {
            board = new string[,]{ //0 is white, 1 is black
                    { "0R","0N","0B","0Q","0K","0B","0N","0R" },
                    { "0P","0P","0P","0P","0P","0P","0P","0P" },
                    { "  ","  ","  ","  ","  ","  ","  ","  " },
                    { "  ","  ","  ","  ","  ","  ","  ","  " },
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
            gameState = "notbegun";
        }
        
        public void start(MainChess sender) //starting a new game
        {
            game = sender;
            game.UpdateBoard();
            gameState = "In Play";
 
        }
        public void Move(int[] pos,int[,] move)
        {

            //Console.Write("Input y coord: ");
            //pos[0] = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Input x coord: ");
            //pos[1] = Convert.ToInt32(Console.ReadLine());
            //int opt = Convert.ToInt32(Console.ReadLine());



            try //adding points
            {
                int y = move[1, 0];
                int x = move[1, 1];
                char pieceTaken = board[y, x][1];
                switch (pieceTaken)
                {
                    case 'P':
                        points[turn] += 1;
                        break;
                    case 'N':
                        points[turn] += 3;
                        break;
                    case 'B':
                        points[turn] += 3;
                        break;
                    case 'R':
                        points[turn] += 5;
                        break;
                    case 'Q':
                        points[turn] += 9;
                        break;
                    default:
                        break;
                }
            }
            catch
            {

            }
            UpdateBoard(pos, move);

            if (turn == 1) turn = 0;
            else turn = 1;

            int[] kingPos = new int[] { 0, 0 }; //find king position
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (board[y, x][1] == 'K')
                    {
                        if (Convert.ToInt32(Convert.ToString(board[y, x][0])) == turn)
                        {
                            kingPos[0] = y; kingPos[1] = x; break;
                        }
                    }
                }
            }
            char toCheck = '0';
            if (turn == 0)
            {
                toCheck = '1';
            }
            check = false;
            if (CheckIfAttacked(kingPos, toCheck)) //use king position to see if king is under attack
            {
                check = true;
            }

            List<int[,]> nextLegalMoves = new List<int[,]> { };
            for(int y = 0; y<8; y++) //find all moves that opponent can makes. If it is 0 and the king is attacked, it is checkmate. If it is 0 and the king is not attacked, it is stalemate.
            {
                for (int x = 0; x < 8; x++)
                {
                    if (board[y, x][0]!=' ')
                    {
                        if (Convert.ToInt32(Convert.ToString(board[y, x][0])) == turn)
                        {
                            nextLegalMoves.AddRange(CalculateLegalMoves(new int[] { y, x }));
                        }
                    }
                    
                }
            }
            if (nextLegalMoves.Count == 0 && CheckIfAttacked(kingPos, toCheck)) 
            {
                gameState = "checkmate";
            }
            else if (nextLegalMoves.Count == 0)
            {
                gameState = "stalemate";
            }

            
        }

        public int[][,] CalculateLegalMoves(int[] pos) //a function where, if you input a position, it will return all the legal moves that the piece at this position can make
        {
            int attacker = Convert.ToInt32(Convert.ToString(board[pos[0], pos[1]][0]));
            int[][,] moves = CheckPossibleMoves(pos); //find possible moves (not necessarily legal)
            List<int[,]> legalMoves = new List<int[,]> { };
            string[,] currentBoard = (string[,])board.Clone();
            int[] currentEnPassant = (int[])enPassant.Clone();
            bool[,] currentCastle = (bool[,])castle.Clone();
            bool currentCheck = check;
            foreach (int[,] m in moves) //for each move calculated, simulate the move being made and check if it gets your own king in check
            {
                UpdateBoard(pos, m); 
                int[] kingPos = new int[] { 0, 0 };
                for (int x = 0; x<8; x++) //find king
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if (board[y, x][1] == 'K') 
                        {  
                            if (Convert.ToInt32(Convert.ToString(board[y, x][0])) == attacker)
                            {
                                kingPos[0] = y; kingPos[1] = x; break;
                            }
                        }
                    }
                }
                char toCheck = '0';
                if (attacker == 0)
                {
                    toCheck = '1';
                }
                if (CheckIfAttacked(kingPos, toCheck) == false)
                {
                    legalMoves.Add(m);
                }
                board = (string[,]) currentBoard.Clone();
                castle = (bool[,])currentCastle.Clone();
                enPassant = (int[])currentEnPassant.Clone();
                check = currentCheck;
            }
            return legalMoves.ToArray();
        }

        public void UpdateBoard(int[] pos,int[,] move)
        {
            char type = board[pos[0], pos[1]][1];
            int attacker = Convert.ToInt32(Convert.ToString(board[pos[0], pos[1]][0]));
            board[pos[0], pos[1]] = "  ";
            enPassant[0] = 8;
            enPassant[1] = 8;
            if (move[1,0] == 9) //code 9 refers to castling
            {
                if (attacker == 0) //white
                {
                    castle[0, 0] = false; castle[0, 1] = false; //makes sure that castle move cannot be used again
                    if (move[0, 1] == 2) //kingside
                    {
                        board[0, 0] = "  ";
                        board[0, 2] = "0K";
                        board[0, 3] = "0R";
                    }
                    else //queenside
                    {
                        board[0, 5] = "0R";
                        board[0, 6] = "0K";
                        board[0, 7] = "  ";
                    }
                }
                else //black
                { 
                    castle[1, 0] = false; castle[1, 1] = false; //makes sure that castle move cannot be used again

                    if (move[0, 1] == 2) //kingside
                    {
                        board[7, 0] = "  ";
                        board[7, 2] = "1K";
                        board[7, 3] = "1R";
                    }
                    else //queenside
                    {
                        board[7, 5] = "1R";
                        board[7, 6] = "1K";
                        board[7, 7] = "  ";
                    }
                }
            }
            else if (move[1, 0] == 10) //10 refers to pawn moving forward by 2
            {
                board[move[0, 0], move[0, 1]] = Convert.ToString(attacker) + type;
                enPassant[0] = move[0, 0];
                enPassant[1] = move[0, 1]; 
            } 
            else if (move[1,0] == 8)//no take
            {
                board[move[0, 0], move[0, 1]] = Convert.ToString(attacker) + type;
            }
            else //regular move
            {
                board[move[1, 0], move[1, 1]] = "  ";
                board[move[0, 0], move[0, 1]] = Convert.ToString(attacker) + type;
            }
            if (type == 'K')
            {
                castle[attacker, 0] = false; //removes opportunity to castle after king moves
                castle[attacker, 1] = false;
            }
            if (board[0,0][1] != 'R') castle[0, 0] = false; //removes opportunity to castle certain directions after rook moves
            if (board[0,7][1] != 'R') castle[0, 1] = false;
            if (board[7, 0][1] != 'R') castle[1, 0] = false;
            if (board[7, 7][1] != 'R') castle[1, 1] = false;
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
                        if (pos[1] - 1 != -1) if (board[pos[0]+1,pos[1]-1]!="  ") if (Convert.ToInt16(Convert.ToString(board[pos[0]+1,pos[1]-1][0]))!=attacker) possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]-1},{pos[0]+1,pos[1]-1}}); //attack to the left
                        if (pos[1] + 1 != 8) if (board[pos[0]+1,pos[1]+1]!="  ") if (Convert.ToInt16(Convert.ToString(board[pos[0]+1,pos[1]+1][0]))!=attacker) possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]+1},{pos[0]+1,pos[1]+1}}); //attack to the right
                        if (board[pos[0]+1,pos[1]]=="  " && board[pos[0]+2,pos[1]]=="  " && pos[0]==1) possibleMoves.Add(new int[,] {{pos[0]+2,pos[1]},{10,10} }); //move 2 forward
                        if (enPassant[0] < 8) if (pos[1] - 1 != -1) if (board[pos[0]+1,pos[1]-1]=="  "&&pos[0]==enPassant[0]&&pos[1]-1==enPassant[1]) possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]-1},{enPassant[0],enPassant[1]} }); //en passant left
                        if (enPassant[0] < 8) if (pos[1] + 1 != 8) if (board[pos[0]+1,pos[1]+1]=="  "&&pos[0]==enPassant[0]&&pos[1]+1==enPassant[1]) possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]+1},{enPassant[0],enPassant[1]} }); //en passant right
                    }
                    else{//black
                        if (board[pos[0]-1,pos[1]]=="  ") possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]},{8,8} }); //move forward
                        if (pos[1] - 1 != -1) if (board[pos[0]-1,pos[1]-1]!="  ") if (Convert.ToInt16(Convert.ToString(board[pos[0]-1,pos[1]-1][0]))!=attacker) possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]-1},{pos[0]-1,pos[1]-1}}); //attack to the left
                        if (pos[1] + 1 != 8) if (board[pos[0]-1,pos[1]+1]!="  ") if (Convert.ToInt16(Convert.ToString(board[pos[0]-1,pos[1]+1][0]))!=attacker) possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]+1},{pos[0]-1,pos[1]+1}}); //attack to the right
                        if (board[pos[0]-1,pos[1]]=="  " && board[pos[0]-2,pos[1]]=="  " && pos[0]==6) possibleMoves.Add(new int[,] {{pos[0]-2,pos[1]},{10,10} }); //move 2 forward
                        if (enPassant[0] < 8) if (pos[1] - 1 != -1) if (board[pos[0]-1,pos[1]-1]=="  "&&pos[0]==enPassant[0]&&pos[1]-1==enPassant[1]) possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]-1},{enPassant[0],enPassant[1]} }); //en passant left
                        if (enPassant[0] < 8) if (pos[1] + 1 != 8) if (board[pos[0]-1,pos[1]+1]=="  "&&pos[0]==enPassant[0]&&pos[1]+1==enPassant[1]) possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]+1},{enPassant[0],enPassant[1]} }); //en passant right
                    }
                    break;
                case 'N': //knight movement
                        if (pos[0]-2>-1){ //move down 2
                            if (pos[1]-1>-1){ //left 1
                                
                                if (board[pos[0]-2,pos[1]-1][0]==' ') possibleMoves.Add(new int[,] {{pos[0]-2,pos[1]-1},{8,8}});
                                else if (Convert.ToInt32(Convert.ToString(board[pos[0]-2,pos[1]-1][0])) != attacker) possibleMoves.Add(new int[,] {{pos[0]-2,pos[1]-1},{pos[0]-2,pos[1]-1}});
                            }
                            if (pos[1]+1<8){ //right 1
                                
                                if (board[pos[0]-2,pos[1]+1][0]==' ') possibleMoves.Add(new int[,] {{pos[0]-2,pos[1]+1},{8,8}});
                                else if (Convert.ToInt32(Convert.ToString(board[pos[0]-2,pos[1]+1][0])) != attacker) possibleMoves.Add(new int[,] {{pos[0]-2,pos[1]+1},{pos[0]-2,pos[1]+1}});
                            }
                        }
                        if (pos[0]+2<8){ //move up 2
                            if (pos[1]-1>-1){ //left 1
                                
                                if (board[pos[0]+2,pos[1]-1][0]==' ') possibleMoves.Add(new int[,] {{pos[0]+2,pos[1]-1},{8,8}});
                                else if (Convert.ToInt32(Convert.ToString(board[pos[0]+2,pos[1]-1][0])) != attacker) possibleMoves.Add(new int[,] {{pos[0]+2,pos[1]-1},{pos[0]+2,pos[1]-1}});
                            }
                            if (pos[1]+1<8){ //right 1
                                
                                if (board[pos[0]+2,pos[1]+1][0]==' ') possibleMoves.Add(new int[,] {{pos[0]+2,pos[1]+1},{8,8}});
                                else if (Convert.ToInt32(Convert.ToString(board[pos[0]+2,pos[1]+1][0])) != attacker) possibleMoves.Add(new int[,] {{pos[0]+2,pos[1]+1},{pos[0]+2,pos[1]+1}});
                            }
                        }
                        if (pos[0]-1>-1){ //move down 1
                            if (pos[1]-2>-1){ //left 2
                                
                                if (board[pos[0]-1,pos[1]-2][0]==' ') possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]-2},{8,8}});
                                else if (Convert.ToInt32(Convert.ToString(board[pos[0]-1,pos[1]-2][0])) != attacker) possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]-2},{pos[0]-1,pos[1]-2}});
                            }
                            if (pos[1]+2<8){ //right 2
                                
                                if (board[pos[0]-1,pos[1]+2][0]==' ') possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]+2},{8,8}});
                                else if (Convert.ToInt32(Convert.ToString(board[pos[0]-1,pos[1]+2][0])) != attacker) possibleMoves.Add(new int[,] {{pos[0]-1,pos[1]+2},{pos[0]-1,pos[1]+2}});
                            }
                        }
                        if (pos[0]+1<8){ //move up 1
                            if (pos[1]-2>-1){ //left 2
                                
                                if (board[pos[0]+1,pos[1]-2][0]==' ') possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]-2},{8,8}});
                                else if (Convert.ToInt32(Convert.ToString(board[pos[0]+1,pos[1]-2][0])) != attacker) possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]-2},{pos[0]+1,pos[1]-2}});
                            }
                            if (pos[1]+2<8){ //right 2
                                
                                if (board[pos[0]+1,pos[1]+2][0]==' ') possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]+2},{8,8}});
                                else if (Convert.ToInt32(Convert.ToString(board[pos[0]+1,pos[1]+2][0])) != attacker) possibleMoves.Add(new int[,] {{pos[0]+1,pos[1]+2},{pos[0]+1,pos[1]+2}});
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
                    
                    if (check == false)
                    {
                        if (attacker == 0){ //white castle
                            if (castle[0,0]){//queenside
                                if (board[0, 1] == "  " && board[0,2] == "  " && board[0,3] == "  " && CheckIfAttacked(new int[] { 0, 2 },'1') == false && CheckIfAttacked(new int[] { 0, 3 }, '1') == false)
                                {
                                    possibleMoves.Add(new int[,] { { 0 , 2 }, {9,9} });
                                }
                            }
                            if (castle[0,1]){//kingside
                                if (board[0,5] == "  " && board[0,6] == "  " && CheckIfAttacked(new int[] { 0, 5 }, '1') == false && CheckIfAttacked(new int[] { 0, 6 }, '1') == false)
                                {
                                    possibleMoves.Add(new int[,] { { 0, 6 }, { 9, 9 } });
                                }
                            }
                        }
                        else{ //black castle
                            if (castle[1,0]){//queenside
                                if (board[7, 1] == "  " && board[7,2] == "  " && board[7,3] == "  " && CheckIfAttacked(new int[] { 7, 2 }, '0') == false && CheckIfAttacked(new int[] { 7, 3 }, '0') == false)
                                {
                                    possibleMoves.Add(new int[,] { { 7, 2 }, { 9, 9 } });
                                }
                            }
                            if (castle[1,1]){//kingside
                                if (board[7,5] == "  " && board[7,6] == "  " && CheckIfAttacked(new int[] { 7, 5 }, '0') == false && CheckIfAttacked(new int[] { 7, 6 }, '0') == false)
                                {
                                    possibleMoves.Add(new int[,] { { 7, 6 }, { 9, 9 } });
                                }
                            }
                        }
                    }
                    
                    
                    break;
                case 'B': //bishop movement
                        possibleMoves.AddRange(checkBishopMoves(pos,attacker));
                    break;
                case 'R': //rook movement
                        possibleMoves.AddRange(checkRookMoves(pos, attacker));
                    break;
                case 'Q': //queen movement (just rook and bishop movement in one)
                        possibleMoves.AddRange(checkBishopMoves(pos, attacker));
                        possibleMoves.AddRange(checkRookMoves(pos, attacker));
                    break;
                default:

                    break;
            }

            return possibleMoves.ToArray();
        }
              
        public bool CheckIfAttacked(int[] pos,char attacker) //calculates all possible moves for every opponent piece and checks if a certain position is under attack
        {
            check = true;
            for (int y = 0; y<8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (board[y, x][0] == attacker)
                    {
                        foreach (int[,] i in CheckPossibleMoves(new int[]{ y, x }))
                        {
                            if (i[0, 0] == pos[0] && i[0, 1] == pos[1])
                            {
                                check = false;
                                return true;
                            }
                        }
                    }
                }
            }
            check = false;
            return false;
        }

        public int[][,] checkRookMoves(int[] pos, int attacker) //returns all possible rook moves for a certain position

        {
            List<int[,]> possibleMoves = new List<int[,]> { };
            for (int i = 1; i < 8; i++) //down
            {
                if (pos[0] - i > -1)
                {
                    if (board[pos[0] - i, pos[1]] == "  ")
                    {
                        possibleMoves.Add(new int[,] { { pos[0] - i,pos[1]}, { 8, 8 } });
                    }
                    else if ((Convert.ToInt16(Convert.ToString(board[pos[0] - i, pos[1]][0])) != attacker))
                    {
                        possibleMoves.Add(new int[,] { { pos[0] - i, pos[1] }, { pos[0] - i, pos[1] } });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++) //up
            {
                if (pos[0] + i < 8)
                {
                    if (board[pos[0] + i, pos[1]] == "  ")
                    {
                        possibleMoves.Add(new int[,] { { pos[0] + i, pos[1] }, { 8, 8 } });
                    }
                    else if ((Convert.ToInt16(Convert.ToString(board[pos[0] + i, pos[1]][0])) != attacker))
                    {
                        possibleMoves.Add(new int[,] { { pos[0] + i, pos[1] }, { pos[0] + i, pos[1] } });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++) //left
            {
                if (pos[1] - i > -1)
                {
                    if (board[pos[0], pos[1] - i] == "  ")
                    {
                        possibleMoves.Add(new int[,] { { pos[0], pos[1] - i }, { 8, 8 } });
                    }
                    else if ((Convert.ToInt16(Convert.ToString(board[pos[0], pos[1]-i][0])) != attacker))
                    {
                        possibleMoves.Add(new int[,] { { pos[0], pos[1]-i }, { pos[0], pos[1] -i } });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            for (int i = 1; i < 8; i++) //right
            {
                if (pos[1] + i < 8)
                {
                    if (board[pos[0], pos[1] + i] == "  ")
                    {
                        possibleMoves.Add(new int[,] { { pos[0], pos[1] + i }, { 8, 8 } });
                    }
                    else if ((Convert.ToInt16(Convert.ToString(board[pos[0], pos[1] + i][0])) != attacker))
                    {
                        possibleMoves.Add(new int[,] { { pos[0], pos[1] + i }, { pos[0], pos[1] + i } });
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
        public int[][,] checkBishopMoves(int[] pos,int attacker)//returns all possible bishop moves for this position
        {
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

