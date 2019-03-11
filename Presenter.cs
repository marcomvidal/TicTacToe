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

            for (int i = 0; i < board.GetLength(0); i++)
            {
                //if (IsFilled(board[i, 0])) { Console.Write(" "); ColorizedPlayerSymbol(board[i, 0]); }
                //else { Console.Write(" " + presentedPosition); }
                //Console.Write(" | ");

                //if (IsFilled(board[i, 1])) { ColorizedPlayerSymbol(board[i, 1]); }
                //else { Console.Write(presentedPosition + 1); }
                //Console.Write(" | ");

                //if (IsFilled(board[i, 2])) { ColorizedPlayerSymbol(board[i, 2]); }
                //else { Console.Write(presentedPosition + 2); }
                //Console.WriteLine();

                DrawLine(board[i, 0], presentedPosition);
                DrawLine(board[i, 1], presentedPosition + 1);
                DrawLine(board[i, 2], presentedPosition + 2);

                /// It allows the next interation to consider the current counting to present the next
                /// positions correctly
                presentedPosition += 3;

                /// Only two lines of dashed should be shown to represent the structure of the Tic
                /// TacToe's board
                if (dashedLines >= 2) { break; }
                DashedLine(11, Spacing.After);
                dashedLines++;
            }
        }

        private void DrawLine(Player item, int position)
        {
            if (IsFilled(item))
            { 
                Console.Write(" ");
                ColorizedPlayerSymbol(item);
            }
            else
            {
                Console.Write(" " + position);
            }

            bool isTheEndOfLine = position != 1 || position == 3;

            if (isTheEndOfLine) { Console.WriteLine(); }
            else { Console.Write(" | "); }
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

        private bool IsFilled(Player position)
        {
            return position != null ? true : false;
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

        private void ColorizedPlayerSymbol(Player player)
        {
            Console.ForegroundColor = player.Color;
            Console.Write(player.ToString());
            Console.ResetColor();
        }

        private void SorroundWithPlayersColor(Player player, Action messages)
        {
            Console.ForegroundColor = player.Color;
            messages();
            Console.ResetColor();
        }
    }
}