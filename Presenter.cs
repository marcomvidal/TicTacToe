using System;

namespace TicTacToe
{
    class Presenter
    {
        public void Banner()
        {
            var message = "Welcome to the TicTacToe game!";

            Console.Clear();
            DashedLine(message.Length, Spacing.After);
            Console.WriteLine(message);
            DashedLine(message.Length, Spacing.After);
            Console.WriteLine();
        }

        public void DashedLine(int lenght, Spacing spacing)
        {
            if (spacing.Equals(Spacing.Before)) { Console.WriteLine(); }

            for (int dash = 0; dash < lenght; dash++) { Console.Write("-"); }

            if (spacing.Equals(Spacing.After)) { Console.WriteLine(); }
        }

        public void DrawBoard(string[,] board)
        {
            var dashedLines = 0;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.WriteLine($" {board[i, 0]} | {board[i , 1]} | {board[i, 2]} ");

                if (dashedLines >= 2) { break; }

                DashedLine(11, Spacing.After);
                dashedLines++;
            }
        }

        public void PlayerTurn()
        {
            Console.WriteLine("- X turn -");
            Console.WriteLine("Select the horizontal position:");
        }
    }
}