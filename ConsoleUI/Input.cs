using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class Input
    {
        public static GameModel.Message HandleInput()
        {
            var key = Console.ReadKey();

            GameModel.Message msg = key.Key switch
            {
                ConsoleKey.Escape => GameModel.Message.Exit,
                ConsoleKey.LeftArrow => GameModel.Message.GoToPreviousPile,
                ConsoleKey.RightArrow => GameModel.Message.GoToNextPile,
                ConsoleKey.Spacebar => GameModel.Message.SelectCards,
                _ => GameModel.Message.DoNothing
            };

            return msg;
        }
    }
}
