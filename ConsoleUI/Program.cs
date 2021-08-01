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
            var board = new Display.Board(game);

            do
            {
                board.Display();

                GameModel.Message msg = Input.HandleInput(ref board);

                game.Update(msg);
            } while (game.StillPlaying);

            //TODO: This will be wrong in the future.
            Console.CursorTop = 15;
        }
    }
}
