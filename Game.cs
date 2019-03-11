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
                    int[] position = presenter.PlayerTurn(player);
                    board[position[0], position[1]] = player;
                    isWon = IsTheGameWon(player);
                    presenter.DrawBoard(board);

                    if (isWon == true) { presenter.WinningMessage(player); break; }
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