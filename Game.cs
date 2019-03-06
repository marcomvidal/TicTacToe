using System;

namespace TicTacToe
{
    class Game
    {
        private Presenter presenter;
        private string[,] board;

        public bool IsWon { get; private set; }

        public Game(Presenter presenter)
        {
            this.presenter = presenter;
            this.board = GenerateBoard();
            this.IsWon = false;
        }

        public string[,] GenerateBoard() {
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

            while (!IsWon)
            {
                foreach (Player player in Enum.GetValues(typeof(Player)))
                {
                    int[] position = presenter.PlayerTurn(player);
                    board[position[0], position[1]] = player.ToString();
                    IsWon = IsTheGameWon(player);
                    presenter.DrawBoard(board);

                    if (IsWon == true)
                    {
                        presenter.WinningMessage(player);
                        break;
                    }
                }
            }
        }

        public bool IsTheGameWon(Player player)
        {
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
        }
    }
}