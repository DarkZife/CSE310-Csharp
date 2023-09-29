using System;

class Program
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int playerTurn = 1; // Player 1 starts

    static void Main()
    {
        int choice;
        bool validInput;

        do
        {
            Console.Clear(); // Clear the console on each iteration
            DrawBoard();

            validInput = int.TryParse(Console.ReadLine(), out choice);

            if (validInput)
            {
                if (choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O')
                {
                    char playerSymbol = (playerTurn % 2 == 0) ? 'O' : 'X';
                    board[choice - 1] = playerSymbol;
                    playerTurn++;
                }
                else
                {
                    Console.WriteLine("Invalid move! Please try again.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a number between 1 and 9.");
                Console.ReadLine();
            }

        } while (!CheckForWin() && !IsBoardFull());

        Console.Clear();
        DrawBoard();
        if (IsBoardFull() && !CheckForWin())
        {
            Console.WriteLine("It's a draw!");
        }
        else
        {
            int winner = (playerTurn % 2 == 0) ? 1 : 2;
            Console.WriteLine($"Player {winner} wins!");
        }

        Console.ReadLine();
    }

    static void DrawBoard()
    {
        Console.WriteLine("   |   |   ");
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
        Console.WriteLine("   |   |   ");
    }

    static bool CheckForWin()
    {
        for (int i = 0; i < 8; i += 3)
        {
            if (board[i] == board[i + 1] && board[i + 1] == board[i + 2])
            {
                return true;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (board[i] == board[i + 3] && board[i + 3] == board[i + 6])
            {
                return true;
            }
        }

        if (board[0] == board[4] && board[4] == board[8])
        {
            return true;
        }

        if (board[2] == board[4] && board[4] == board[6])
        {
            return true;
        }

        return false;
    }

    static bool IsBoardFull()
    {
        foreach (char c in board)
        {
            if (c != 'X' && c != 'O')
            {
                return false;
            }
        }
        return true;
    }
}
