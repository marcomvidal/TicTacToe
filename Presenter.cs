using System;

namespace TicTacToe
{
    class Presenter
    {
        public void Banner()
        {
            string message = "Welcome to the TicTacToe game!";

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

        public void DrawBoard(Player[,] board)
        {
            int dashedLines = 0;
            int presentedPosition = 1;
            Console.Clear();

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int cell = 0; cell < board.GetLength(1); cell++)
                {
                    presentedPosition = DrawPosition(board[row, cell], presentedPosition);
                }

                /// Only two dashed lines should be shown to represent the structure of the Tic
                /// TacToe's board
                if (dashedLines < 2)
                { 
                    DashedLine(11, Spacing.After);
                    dashedLines++;
                }
            }
        }

        private int DrawPosition(Player player, int position)
        {
            bool positionIsFilledWithPlayer = player != null;
            
            if (positionIsFilledWithPlayer)
            {
                ColorizeByPlayer(player, () => Console.Write($" {player}"));
            }
            else
            {
                Console.Write($" {position}");
            }

            bool isTheEndOfLine = position % 3 == 0;

            if (isTheEndOfLine) { Console.WriteLine(); }
            else { Console.Write(" |"); }

            position++;
            return position;
        }

        public void WinningMessage(Player player)
        {
            Console.Write("\nCongratulations! ");
            ColorizeByPlayer(player, () => Console.WriteLine($"{player.ToString()} won!"));
        }

        public void ColorizeByPlayer(Player player, Action consoleWriteInstructions)
        {
            Console.ForegroundColor = player.Color;
            consoleWriteInstructions();
            Console.ResetColor();
        }
    }
}