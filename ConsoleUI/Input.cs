using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class Input
    {
        //TODO: Is there a better way to do this?
        public static GameModel.Message HandleInput(ref Display.Board board)
        {
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    return GameModel.Message.Exit;
                case ConsoleKey.LeftArrow:
                    board.GoToPreviousPile();

                    return GameModel.Message.DoNothing;
                case ConsoleKey.RightArrow:
                    board.GoToNextPile();

                    return GameModel.Message.DoNothing;
                case ConsoleKey.Spacebar:
                    return GameModel.Message.SelectCards;
                default:
                    return GameModel.Message.DoNothing;
            }
        }
    }
}
