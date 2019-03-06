using System;

namespace TicTacToe
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
