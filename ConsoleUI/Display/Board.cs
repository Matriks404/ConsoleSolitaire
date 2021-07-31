using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Display
{
    public class Board
    {
        private GameModel.Instance game;
        public Board(GameModel.Instance game) => this.game = game;

        public void Display()
        {
            Pile.Display(game.cornerPile, 0, 3);
            Pile.Display(game.nextToCornerPile, 12, 3);

            if (game.winningClubsPile.Any())
                Pile.Display(game.winningClubsPile, 36, 3);

            if (game.winningDiamondsPile.Any())
                Pile.Display(game.winningDiamondsPile, 48, 3);

            if (game.winningHeartsPile.Any())
                Pile.Display(game.winningHeartsPile, 60, 3);

            if (game.winningSpadesPile.Any())
                Pile.Display(game.winningSpadesPile, 72, 3);

            for (int i = 0; i < game.fieldPiles.Length; i++)
            {
                Pile.Display(game.fieldPiles[i], i * 12, 10);
            }
        }
    }
}
