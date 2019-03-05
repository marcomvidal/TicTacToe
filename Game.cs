using System;

namespace TicTacToe
{
    class Game
    {
        private Presenter presenter;
        private string[,] board;

        public Game(Presenter presenter)
        {
            this.presenter = presenter;
            this.board = InitializeBoard();
        }

        public string[,] InitializeBoard() {
            return new string[3,3] {
                {"1", "2", "3"},
                {"4", "5", "6"},
                {"7", "8", "9"},
            };
        }

        public void Play()
        {
            presenter.Banner();
            presenter.DrawBoard(board);
        }
    }
}