using System;
using GameModel;

namespace ConsoleUI
{
    public static class Program
    {
        static readonly string name = "ConsoleSolitaire";
        static readonly string version = "0.1.0";
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine($"===== {name} =====");
            Console.Write($"Version: {version} running on {Environment.OSVersion.VersionString}");

            var game = new GameModel.Instance();
            Display.Pile.SetupSelectablePiles(game, false);

            do
            {
                Display.Board.Display(game);

                //TODO: Refactor input and updating the game.
                GameModel.Message msg = Input.Handle(game);

                game.Update(msg);
            } while (game.StillPlaying);

            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }
    }
}
