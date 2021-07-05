using System;
using ConsoleSolitaire.Game;

namespace ConsoleSolitaire
{
    class Program
    {
        static readonly string name = "ConsoleSolitaire";
        static readonly string version = "0.1.0";
        static void Main(string[] args)
        {
            Console.WriteLine($"===== {name} =====");
            Console.WriteLine($"Version: {version}");

            var game = new Game.Instance();

            do
            {
                game.Loop();
            } while (game.StillPlaying);
        }
    }
}
