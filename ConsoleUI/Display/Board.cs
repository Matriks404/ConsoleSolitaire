using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Display
{
    public static class Board
    {
        public static void Show(GameModel.Instance game)
        {
            Pile.Show(game.cornerPile, 0, 3);

            if (game.nextToCornerPile.Any())
            {
                Pile.Show(game.nextToCornerPile, 12, 3);
            }

            if (game.winningClubsPile.Any())
            {
                Pile.Show(game.winningClubsPile, 36, 3);
            }

            if (game.winningDiamondsPile.Any())
            {
                Pile.Show(game.winningDiamondsPile, 48, 3);
            }

            if (game.winningHeartsPile.Any())
            {
                Pile.Show(game.winningHeartsPile, 60, 3);
            }

            if (game.winningSpadesPile.Any())
            {
                Pile.Show(game.winningSpadesPile, 72, 3);
            }

            for (int i = 0; i < game.fieldPiles.Length; i++)
            {
                Pile.Show(game.fieldPiles[i], i * 12, 10);
            }
        }
    }
}
