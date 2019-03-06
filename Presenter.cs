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
            Console.Clear();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.WriteLine($" {board[i, 0]} | {board[i, 1]} | {board[i, 2]} ");

                if (dashedLines >= 2) { break; }

                DashedLine(11, Spacing.After);
                dashedLines++;
            }
        }

        public int[] PlayerTurn(Player player)
        {
            Console.WriteLine($"\n--- {player.ToString()} TURN ---");

            while (true)
            {
                Console.Write("Enter the number of the desired position to play: ");

                var chosenPosition = Console.ReadLine();
                var positionAsInteger = PositionValidator(chosenPosition);
                if (positionAsInteger == 0) { continue; }
                
                return PositionParser(positionAsInteger);
            }
        }

        private int PositionValidator(string chosenPosition)
        {
            bool isInteger = int.TryParse(chosenPosition, out var positionAsInteger);
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

        public void WinningMessage(Player player)
        {
            Console.WriteLine($"\nCongratulations! {player.ToString()} won!");
        }
    }
}