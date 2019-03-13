using System;
using TicTacToe.Core;
using TicTacToe.Verification;
using TicTacToe.View;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var presenter = new Presenter();
            var validator = new Validator();
            var finalizer = new Finalizer(presenter);
            var game = new Game(presenter, validator, finalizer);

            game.Play();
        }
    }
}
