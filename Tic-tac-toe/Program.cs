using System;


class TicTacToe
{//This will start the set up for the board and start the current player as 1(when changed to 2 thats when next player plays)
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int currentPlayer = 1; 

    static void Main()
    {

        int playerChoice;
        bool validInput = false;
        bool gameover = false;

        do
        {
            //In this do while, it will set up and display the game board, Ask the current player to pick a number 1-9 according to the board.
            DisplayBoard();

            // Get the current player's move
            Console.WriteLine($"Player {currentPlayer}, enter your choice (1-9):");
            validInput = int.TryParse(Console.ReadLine(), out playerChoice);

            if (validInput && playerChoice >= 1 && playerChoice <= 9 && board[playerChoice - 1] != 'X' && board[playerChoice - 1] != 'O')
            {
                //This is to plugin the X's and O's for what the player chooses
                board[playerChoice - 1] = (currentPlayer == 1) ? 'X' : 'O';

                /* This next if else section will check if someone has won, or if its a draw. calling on CheckForWin and CheckForDraw.
                After checking for a win or draw, it will write a display message for either one.*/
                if (CheckForWin() || CheckForDraw())
                {
                    
                    DisplayBoard();
                    if (CheckForWin())
                        Console.WriteLine($"Player {currentPlayer} wins!");
                    else
                        Console.WriteLine("It's a draw!");
                    gameover = true;
                }

                // This will update to the new player, after one has gone.
                currentPlayer = (currentPlayer == 1) ? 2 : 1;
            }
            else
            {
                //Response for entering in a bad input.
                Console.WriteLine("Invalid input. Please try again.");
            }

        } while (!gameover);
    }

    static void DisplayBoard()
    {
        //from above this is where we set up the player board and the look of it.
        Console.Clear();   //I can't figure out why this section right here doesn't like working when debugging.
        Console.WriteLine("Tic-Tac-Toe");
        Console.WriteLine($"Player 1 (X)  -  Player 2 (O)\n");

        Console.WriteLine($"     |     |      ");
        Console.WriteLine($"  {board[0]}  |  {board[1]}  |  {board[2]}  ");
        Console.WriteLine($"_____|_____|_____ ");
        Console.WriteLine($"     |     |      ");
        Console.WriteLine($"  {board[3]}  |  {board[4]}  |  {board[5]}  ");
        Console.WriteLine($"_____|_____|_____ ");
        Console.WriteLine($"     |     |      ");
        Console.WriteLine($"  {board[6]}  |  {board[7]}  |  {board[8]}  ");
        Console.WriteLine($"     |     |      ");
    }

    static bool CheckForWin()
    {
        // Win checking for a win, we got to see if any three line up.
        return
            (board[0] == board[1] && board[1] == board[2]) ||
            (board[3] == board[4] && board[4] == board[5]) ||
            (board[6] == board[7] && board[7] == board[8]) ||
            (board[0] == board[3] && board[3] == board[6]) ||
            (board[1] == board[4] && board[4] == board[7]) ||
            (board[2] == board[5] && board[5] == board[8]) ||
            (board[0] == board[4] && board[4] == board[8]) ||
            (board[2] == board[4] && board[4] == board[6]);
    }

    static bool CheckForDraw()
    {
        // This will just check to see if the board is full.
        foreach (char c in board)
        {
            if (c != 'X' && c != 'O')
                return false;
        }
        return true;
    }
}
