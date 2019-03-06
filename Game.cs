using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
>>>>>>> master

namespace TicTacToe
{
    class Game
    {
        private Presenter presenter;
        private string[,] board;
<<<<<<< HEAD

        public bool IsWon { get; private set; }
=======
        private bool isWon;
        private IList<Func<string[,], Player, bool>> winningPatterns
            = new List<Func<string[,], Player, bool>>()
        {
            WinningPatterns.FirstRow,
            WinningPatterns.SecondRow,
            WinningPatterns.ThirdRow,
            WinningPatterns.FirstColumn,
            WinningPatterns.SecondColumn,
            WinningPatterns.ThirdColumn,
            WinningPatterns.DiagonalFromLeftToRight,
            WinningPatterns.DiagonalFromRightToLeft
        };
>>>>>>> master

        public Game(Presenter presenter)
        {
            this.presenter = presenter;
            this.board = GenerateBoard();
<<<<<<< HEAD
            this.IsWon = false;
        }

        public string[,] GenerateBoard() {
=======
            this.isWon = false;
        }

        private string[,] GenerateBoard() {
>>>>>>> master
            return new string[3, 3]
            {
                {"1", "2", "3"},
                {"4", "5", "6"},
                {"7", "8", "9"}
            };
        }

        public void Play()
        {
            presenter.Banner();
            presenter.DrawBoard(board);

<<<<<<< HEAD
            while (!IsWon)
=======
            while (!isWon)
>>>>>>> master
            {
                foreach (Player player in Enum.GetValues(typeof(Player)))
                {
                    int[] position = presenter.PlayerTurn(player);
                    board[position[0], position[1]] = player.ToString();
<<<<<<< HEAD
                    IsWon = IsTheGameWon(player);
                    presenter.DrawBoard(board);

                    if (IsWon == true)
=======
                    isWon = IsTheGameWon(player);
                    presenter.DrawBoard(board);

                    if (isWon == true)
>>>>>>> master
                    {
                        presenter.WinningMessage(player);
                        break;
                    }
                }
            }
        }

        public bool IsTheGameWon(Player player)
        {
<<<<<<< HEAD
            if (
                    board[0, 0] == player.ToString() &&
                    board[0, 1] == player.ToString() &&
                    board[0, 2] == player.ToString()
                )
            {
                return true;
            }
            else
            {
                return false;
            }
=======
            foreach (var pattern in winningPatterns)
            {
                if (pattern(board, player)) { return true; }
            }
            
            return false;
>>>>>>> master
        }
    }
}