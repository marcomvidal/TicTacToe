using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Game
    {
        private Presenter presenter;
        private IList<Player> players;
        private Player[,] board;
        private bool isWon;
        private IList<Func<Player[,], Player, bool>> winningPatterns
            = new List<Func<Player[,], Player, bool>>()
        {
            WinningPattern.FirstRow,
            WinningPattern.SecondRow,
            WinningPattern.ThirdRow,
            WinningPattern.FirstColumn,
            WinningPattern.SecondColumn,
            WinningPattern.ThirdColumn,
            WinningPattern.StraightDiagonal,
            WinningPattern.ReverseDiagonal
        };

        public Game(Presenter presenter)
        {
            this.presenter = presenter;
            this.players = GeneratePlayers();
            this.board = GenerateBoard();
            this.isWon = false;
        }

        private IList<Player> GeneratePlayers()
        {
            return new List<Player>()
            {
                new Player() { Symbol = "X", Color = ConsoleColor.Blue },
                new Player() { Symbol = "O", Color = ConsoleColor.Red }
            };
        }

        private Player[,] GenerateBoard() {
            return new Player[3, 3];
        }

        public void Play()
        {
            presenter.Banner();
            presenter.DrawBoard(board);

            while (!isWon)
            {
                foreach (var player in players)
                {
                    int[] position = PlayerTurn(player);
                    board[position[0], position[1]] = player;
                    isWon = IsTheGameWon(player);
                    presenter.DrawBoard(board);

                    if (isWon == true) { presenter.WinningMessage(player); break; }
                }
            }
        }

        public int[] PlayerTurn(Player player)
        {
            presenter.ColorizeByPlayer(player, () => Console.WriteLine($"\n--- {player.ToString()}'s TURN ---"));

            while (true)
            {
                Console.Write("Enter the number of the position you want to play: ");

                string chosenPosition = Console.ReadLine();
                int positionAsInteger;

                try
                {
                    positionAsInteger = PositionValidator(chosenPosition);
                }
                catch (ApplicationException exception)
                {
                    Console.WriteLine(exception.Message);
                    continue;
                }
                
                return PositionParserToCoordinate(positionAsInteger);
            }
        }

        private int PositionValidator(string chosenPosition)
        {
            bool isNotAnInteger = !int.TryParse(chosenPosition, out int positionAsInteger);
            bool isOutOfRange = !(positionAsInteger > 0 && positionAsInteger < 10);

            if (isNotAnInteger || isOutOfRange)
            { 
                throw new ApplicationException("Enter a position between 1 and 9.\n");
            }

            return positionAsInteger;
        }

        private int[] PositionParserToCoordinate(int chosenPosition)
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
                default: throw new ApplicationException("Illegal position");
            }
        }

        public bool IsTheGameWon(Player player)
        {
            foreach (var pattern in winningPatterns)
            {
                if (pattern(board, player)) { return true; }
            }
            
            return false;
        }
    }
}