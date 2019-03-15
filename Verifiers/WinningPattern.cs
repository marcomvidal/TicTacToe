using System;
using TicTacToe.Core;

namespace TicTacToe.Verifiers
{
    static class WinningPattern
    {
        public static bool FirstRow(Player[,] board, Player player)
        {
            return
                board[0, 0] == player &&
                board[0, 1] == player &&
                board[0, 2] == player;
        }

        public static bool SecondRow(Player[,] board, Player player)
        {
            return
                board[1, 0] == player &&
                board[1, 1] == player &&
                board[1, 2] == player;
        }
                
        public static bool ThirdRow(Player[,] board, Player player)
        {
            return
                board[2, 0] == player &&
                board[2, 1] == player &&
                board[2, 2] == player;
        }

        public static bool FirstColumn(Player[,] board, Player player)
        {
            return
                board[0, 0] == player &&
                board[1, 0] == player &&
                board[2, 0] == player;
        }

        public static bool SecondColumn(Player[,] board, Player player)
        {
            return
                board[0, 1] == player &&
                board[1, 1] == player &&
                board[2, 1] == player;
        }

        public static bool ThirdColumn(Player[,] board, Player player)
        {
            return
                board[0, 2] == player &&
                board[1, 2] == player &&
                board[2, 2] == player;
        }

        public static bool StraightDiagonal(Player[,] board, Player player)
        {
            return
                board[0, 0] == player &&
                board[1, 1] == player &&
                board[2, 2] == player;
        }

        public static bool ReverseDiagonal(Player[,] board, Player player)
        {
            return
                board[0, 2] == player &&
                board[1, 1] == player &&
                board[2, 0] == player;
        }
    }
}