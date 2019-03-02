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
            if (spacing == Spacing.Before) { Console.WriteLine(); }
            
            for (int character = 0; character < lenght; character++)
            {
                Console.Write("-");
            }

            if (spacing == Spacing.After) { Console.WriteLine(); }
        }

        public void DrawGameBoard(string[,] gameBoard)
        {
            int dashedLines = 0;

            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                Console.WriteLine($" {gameBoard[i, 0]} | {gameBoard[i ,1]} | {gameBoard[i, 2]} ");

                if (dashedLines > 1) { break; }
                DashedLine(11, Spacing.After);
                dashedLines++;
            }
        }
    }
}