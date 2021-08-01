﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class Input
    {
        //TODO: Is there a better way to do this?
        public static GameModel.Message Handle(Display.Board board, GameModel.Instance game)
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
                    if (board.SelectedPile.GetType() == typeof(GameModel.CornerPile))
                    {
                        if (game.nextToCornerPile.Any() == false)
                        {
                            board.SetupSelectablePiles(true);
                        }

                        return GameModel.Message.GetNextCard;
                    }
                    else
                    {
                        return GameModel.Message.SelectCards;
                    }
                default:
                    return GameModel.Message.DoNothing;
            }
        }
    }
}
