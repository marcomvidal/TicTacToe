using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var presenter = new Presenter();
            var game = new Game(presenter);

            game.Play();
        }
    }
}
