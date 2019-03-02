using System;

namespace TicTacToe
{
    class TicTacToe
    {
        private Presenter presenter;
        private string[,] gameBoard;

        public TicTacToe(Presenter presenter)
        {
            this.presenter = presenter;
            this.gameBoard = InitializeGameBoard();
        }

        public string[,] InitializeGameBoard() {
            return new string[3,3] {
                {" ", " ", " "},
                {" ", " ", " "},
                {" ", " ", " "},
            };
        }

        public void Play()
        {
            presenter.Banner();
            presenter.DrawGameBoard(gameBoard);
            
        }
    }
}