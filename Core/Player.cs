using System;

namespace TicTacToe.Core
{
    class Player
    {
        public string Symbol { get; set; }
        public ConsoleColor Color { get; set; }

        public override string ToString()
        {
            return Symbol;
        }
    }
}
