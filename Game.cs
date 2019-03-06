using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Game
    {
        private Presenter presenter;
        private string[,] board;
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

        public Game(Presenter presenter)
        {
            this.presenter = presenter;
            this.board = GenerateBoard();
            this.isWon = false;
        }

        private string[,] GenerateBoard() {
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

            while (!isWon)
            {
                foreach (Player player in Enum.GetValues(typeof(Player)))
                {
                    int[] position = presenter.PlayerTurn(player);
                    board[position[0], position[1]] = player.ToString();
                    isWon = IsTheGameWon(player);
                    presenter.DrawBoard(board);

                    if (isWon == true)
                    {
                        presenter.WinningMessage(player);
                        break;
                    }
                }
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