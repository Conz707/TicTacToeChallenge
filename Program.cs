using System;

namespace backslash_build
{
    class Program
    {
        private enum BoardState
        {
            NOUGHTS_WIN, CROSSES_WIN, DRAW, ACTIVE, ERROR
        }

        static void Main(string[] args)
        {
            // leave this main method unchanged 
            for (int i = 0; i < args.Length; i++)
            {
                System.Console.WriteLine(GetStateOfBoard(args[i]));
            }
        }

        private static BoardState GetStateOfBoard(string board)
        {

            board = board.ToLower();                    //board to lower case to ensure consistency across program

            if (!checkForErrors(board))                  //check for any errors
            {
                if (checkWin(board, 'x'))               //check if x won
                {
                    return BoardState.CROSSES_WIN;
                }
                else if (checkWin(board, 'o'))           //check if o won
                {

                    return BoardState.NOUGHTS_WIN;
                }
                else if (checkIfGameActive(board))      //check if game is active(no win, turns leeft)
                {
                    return BoardState.ACTIVE;
                }
                else                                    //no turns left, no winner
                {
                    return BoardState.DRAW;
                }
            }
            else
            {
                return BoardState.ERROR;
            }
        }

        private static bool checkForErrors(string board) //3 possible errors, invalid character, invalid num of character, too many turns taken
        {

            var boardCharArr = board.ToCharArray();
            int numOfXOnBoard = 0;
            int numOfOOnBoard = 0;

            if (boardCharArr.Length < 9 || boardCharArr.Length > 9) //if less than 9 characters = error
            {
                return true;
            }
            else
            {
                for (int i = 0; i < boardCharArr.Length; i++)       //for length of boardChar Array
                {
                    if (boardCharArr[i] == 'x')                 //if char = X increase numOfXOnBoard
                    {
                        numOfXOnBoard = numOfXOnBoard + 1;
                    }
                    else if (boardCharArr[i] == 'o')            //if char = O increase numOfOOnBoard
                    {
                        numOfOOnBoard = numOfOOnBoard + 1;
                    }

                    if (boardCharArr[i] != 'x' && boardCharArr[i] != 'o' && boardCharArr[i] != '_')            //check correct number of turns taken
                    {

                        return true;

                    }
                }
                if (numOfXOnBoard < numOfOOnBoard || numOfXOnBoard > numOfOOnBoard +1)      //check neither player taken too many turns
                {
                    return true;
                }
            }
            return false;
        }

        private static bool checkIfGameActive(string board)
        {
            int turnsLeft = 9;  //start with 9 turns
            var boardCharArr = board.ToCharArray();

            for (int i = 0; i < boardCharArr.Length; i++)
            {
                if (boardCharArr[i] != '_')     //for every _ missing, remove 1 turn as space is filled
                {
                    turnsLeft = turnsLeft - 1;
                }
            }
            if (turnsLeft == 0)         //if turnsLeft is not 0 game is still active
            {
                return false;
            } else
            {
                return true;
            }
        }

        private static bool checkWin(string board, char player)
        {

            var newBoard = board.ToCharArray();
          
            /*
            0 | 1 | 2
            3 | 4 | 5
            6 | 7 | 8 
            */

            //check for winning permutation being matched
            if (newBoard[0] == player && newBoard[4] == player && newBoard[8] == player ||     //diagonal 024
                newBoard[2] == player && newBoard[4] == player && newBoard[6] == player ||     //diagonal 246
                newBoard[0] == player && newBoard[1] == player && newBoard[2] == player ||     //horizontal 012
                newBoard[3] == player && newBoard[4] == player && newBoard[5] == player ||     //horizontal 345
                newBoard[6] == player && newBoard[7] == player && newBoard[8] == player ||     //horizontal 678
                newBoard[0] == player && newBoard[3] == player && newBoard[6] == player ||     //vertical 036
                newBoard[1] == player && newBoard[4] == player && newBoard[7] == player ||     //vertical 147
                newBoard[2] == player && newBoard[5] == player && newBoard[8] == player)       //vertical 258
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}