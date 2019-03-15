using System;
using System.Collections.Generic;
using TicTacToe.Core;
using TicTacToe.Views;

namespace TicTacToe.Verifiers
{
    class Finalizer
    {
        private Presenter presenter;
        public Finalizer(Presenter presenter)
        {
            this.presenter = presenter;
        }

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

        public bool GameIsWon(Player[,] board, Player player)
        {
            foreach (var pattern in winningPatterns)
            {
                if (pattern(board, player))
                {
                    presenter.WinningMessage(player);
                    return true;
                }
            }

            return false;
        }

        public bool BoardIsFilled(Player[,] board)
        {
            int unpopulatedPositions = 0;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int cell = 0; cell < board.GetLength(1); cell++)
                {
                    if (board[row, cell] == null) { unpopulatedPositions += 1; }
                }
            }

            bool allPositionsAreFilled = unpopulatedPositions == 0;

            if (allPositionsAreFilled)
            {
                presenter.TiedMessage();
                return true;
            }
            
            return false;
        }
    }
}