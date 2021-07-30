using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class GameBoard
    {
        private GameModel.Instance game;
        public GameBoard(GameModel.Instance game) => this.game = game;

        public void Display()
        {
            GamePile.Display(game.cornerPile, 0, 3);
            GamePile.Display(game.nextToCornerPile, 12, 3);

            if (game.winningClubsPile.Any())
                GamePile.Display(game.winningClubsPile, 36, 3);

            if (game.winningDiamondsPile.Any())
                GamePile.Display(game.winningDiamondsPile, 48, 3);

            if (game.winningHeartsPile.Any())
                GamePile.Display(game.winningHeartsPile, 60, 3);

            if (game.winningSpadesPile.Any())
                GamePile.Display(game.winningSpadesPile, 72, 3);

            for (int i = 0; i < game.fieldPiles.Length; i++)
            {
                GamePile.Display(game.fieldPiles[i], i * 12, 10);
            }
        }
    }
}
