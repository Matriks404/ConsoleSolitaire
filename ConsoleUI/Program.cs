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

                GameModel.Message msg = Input.Handle(ref board);

                //TODO: This should not be in this place?
                bool updateSelectablePiles = false;

                if (msg == GameModel.Message.GetNextCard && game.nextToCornerPile.Any() == false)
                {
                    updateSelectablePiles = true;
                }

                game.Update(msg);

                if (updateSelectablePiles)
                {
                    board.SetupSelectablePiles();
                }
            } while (game.StillPlaying);

            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }
    }
}
