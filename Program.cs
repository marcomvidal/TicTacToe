using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var presenter = new Presenter();
            var ticTacToe = new TicTacToe(presenter);
            
            ticTacToe.Play();
        }
    }
}
