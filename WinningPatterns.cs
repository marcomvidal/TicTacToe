using System;

namespace TicTacToe
{
    static class WinningPatterns
    {
        static public Func<string[,], Player, bool> FirstRow =
            (board, player) =>
                board[0, 0] == player.ToString() &&
                board[0, 1] == player.ToString() &&
                board[0, 2] == player.ToString();
        
        static public Func<string[,], Player, bool> SecondRow =
            (board, player) =>
                board[1, 0] == player.ToString() &&
                board[1, 1] == player.ToString() &&
                board[1, 2] == player.ToString();

        static public Func<string[,], Player, bool> ThirdRow =
            (board, player) =>
                board[2, 0] == player.ToString() &&
                board[2, 1] == player.ToString() &&
                board[2, 2] == player.ToString();

        static public Func<string[,], Player, bool> FirstColumn =
            (board, player) =>
                board[0, 0] == player.ToString() &&
                board[1, 0] == player.ToString() &&
                board[2, 0] == player.ToString();

        static public Func<string[,], Player, bool> SecondColumn =
            (board, player) =>
                board[0, 1] == player.ToString() &&
                board[1, 1] == player.ToString() &&
                board[2, 1] == player.ToString();

        static public Func<string[,], Player, bool> ThirdColumn =
            (board, player) =>
                board[0, 2] == player.ToString() &&
                board[1, 2] == player.ToString() &&
                board[2, 2] == player.ToString();

        static public Func<string[,], Player, bool> DiagonalFromLeftToRight =
            (board, player) =>
                board[0, 0] == player.ToString() &&
                board[1, 1] == player.ToString() &&
                board[2, 2] == player.ToString();

        static public Func<string[,], Player, bool> DiagonalFromRightToLeft =
            (board, player) =>
                board[0, 2] == player.ToString() &&
                board[1, 1] == player.ToString() &&
                board[2, 0] == player.ToString();
    }
}