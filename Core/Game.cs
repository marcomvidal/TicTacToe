using System;
using System.Collections.Generic;
using TicTacToe.Verifiers;
using TicTacToe.Views;

namespace TicTacToe.Core
{
    class Game
    {
        private Presenter presenter;
        private IList<Player> players;
        private Player[,] board;
        private Validator validator;
        private Finalizer finalizer;

        public Game(Presenter presenter, Validator validator, Finalizer finalizer)
        {
            this.presenter = presenter;
            this.validator = validator;
            this.finalizer = finalizer;
            this.players = GeneratePlayers();
            this.board = GenerateBoard();
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
            bool isOver = false;

            while (!isOver)
            {
                foreach (var player in players)
                {
                    int[] position = PlayerTurn(player);
                    board[position[0], position[1]] = player;
                    presenter.DrawBoard(board);

                    isOver = finalizer.GameIsWon(board, player) || finalizer.BoardIsFilled(board);
                    if (isOver) { break; }
                }
            }

            presenter.Ending();
        }

        public int[] PlayerTurn(Player player)
        {
            presenter.ColorizeByPlayer(player, () => Console.WriteLine($"\n--- {player.ToString()}'s TURN ---"));

            while (true)
            {
                Console.Write("Enter the number of the position you want to play: ");

                string chosenPosition = Console.ReadLine();
                int[] positionCoordinates;

                try
                {
                    positionCoordinates = PositionValidation(chosenPosition);
                }
                catch (ApplicationException exception)
                {
                    Console.WriteLine(exception.Message);
                    continue;
                }
                
                return positionCoordinates;
            }
        }

        private int[] PositionValidation(string chosenPosition)
        {
            validator.UserEntryIsAnAllowedValue(chosenPosition);

            int positionAsInteger = int.Parse(chosenPosition);
            int[] coordinates = PositionParserToCoordinate(positionAsInteger);

            validator.PositionChosenIsNotPopulated(board[coordinates[0], coordinates[1]]);

            return coordinates;
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
    }
}