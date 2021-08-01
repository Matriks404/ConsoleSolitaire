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

        private GameModel.PileBase[] SelectablePiles { get; set; }
        private int SelectedPilePosition { get; set; }
        private GameModel.PileBase SelectedPile { get; set; }

        public Board(GameModel.Instance game)
        {
            this.game = game;

            SetupSelectablePiles();
        }

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

        public void GoToPreviousPile()
        {
            SelectedPile.Selected = false;

            if (SelectedPilePosition == 0)
            {
                SelectedPilePosition = SelectablePiles.Length - 1;
            }
            else
            {
                SelectedPilePosition--;
            }

            UpdateSelectedPile();
        }

        public void GoToNextPile()
        {
            SelectedPile.Selected = false;

            if (SelectedPilePosition + 1 < SelectablePiles.Length)
            {
                SelectedPilePosition++;
            }
            else
            {
                SelectedPilePosition = 0;
            }

            UpdateSelectedPile();
        }

        private void SetupSelectablePiles()
        {
            SelectablePiles = new GameModel.PileBase[] {
                game.cornerPile,
                game.nextToCornerPile,
                game.fieldPiles[0],
                game.fieldPiles[1],
                game.fieldPiles[2],
                game.fieldPiles[3],
                game.fieldPiles[4],
                game.fieldPiles[5],
                game.fieldPiles[6],
            };

            UpdateSelectedPile();
        }

        private void UpdateSelectedPile()
        {
            SelectedPile = SelectablePiles[SelectedPilePosition];
            SelectedPile.Selected = true;
        }
    }
}
