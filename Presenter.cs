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
                SorroundWithPlayersColor(player, () => Console.Write(" " + player));
            }
            else
            {
                Console.Write(" " + position);
            }

            bool isTheEndOfLine = position % 3 == 0;

            if (isTheEndOfLine) { Console.WriteLine(); }
            else { Console.Write(" |"); }

            position++;
            return position;
        }

        public int[] PlayerTurn(Player player)
        {
            SorroundWithPlayersColor(
                player,
                () => Console.WriteLine($"\n--- {player.ToString()}'s TURN ---")
            );

            while (true)
            {
                Console.Write("Enter the number of the desired position to play: ");

                string chosenPosition = Console.ReadLine();
                int positionAsInteger = PositionValidator(chosenPosition);
                if (positionAsInteger == 0) { continue; }
                
                return PositionParser(positionAsInteger);
            }
        }

        public void WinningMessage(Player player)
        {
            Console.Write("\nCongratulations! ");

            SorroundWithPlayersColor(
                player,
                () => Console.WriteLine($"{player.ToString()} won!")
            );
        }

        private int PositionValidator(string chosenPosition)
        {
            bool isInteger = int.TryParse(chosenPosition, out int positionAsInteger);
            bool isOnRange = positionAsInteger > 0 && positionAsInteger < 10;

            if (!isInteger || !isOnRange)
            { 
                Console.WriteLine("Enter a position between 1 and 9.\n");
                return 0;
            }

            return positionAsInteger;
        }

        private int[] PositionParser(int chosenPosition)
        {
            switch (chosenPosition) {
                case 1: return new int[] {0, 0};
                case 2: return new int[] {0, 1};
                case 3: return new int[] {0, 2};
                case 4: return new int[] {1, 0};
                case 5: return new int[] {1, 1};
                case 6: return new int[] {1, 2};
                case 7: return new int[] {2, 0};
                case 8: return new int[] {2, 1};
                case 9: return new int[] {2, 2};
                default: throw new Exception("Illegal position");
            }
        }

        private void SorroundWithPlayersColor(Player player, Action consoleWriteInstructions)
        {
            Console.ForegroundColor = player.Color;
            consoleWriteInstructions();
            Console.ResetColor();
        }
    }
}