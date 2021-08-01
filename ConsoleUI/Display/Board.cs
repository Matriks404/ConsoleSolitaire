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

        private List<GameModel.PileBase> SelectablePiles;
        private int SelectedPilePosition { get; set; }
        public GameModel.PileBase SelectedPile { get; set; }

        public Board(GameModel.Instance game)
        {
            this.game = game;

            SetupSelectablePiles(false);
        }

        public void Display()
        {
            Pile.Display(game.cornerPile, 0, 3);

            if (game.nextToCornerPile.Any())
            {
                Pile.Display(game.nextToCornerPile, 12, 3);
            }

            if (game.winningClubsPile.Any())
            {
                Pile.Display(game.winningClubsPile, 36, 3);
            }

            if (game.winningDiamondsPile.Any())
            {
                Pile.Display(game.winningDiamondsPile, 48, 3);
            }

            if (game.winningHeartsPile.Any())
            {
                Pile.Display(game.winningHeartsPile, 60, 3);
            }

            if (game.winningSpadesPile.Any())
            {
                Pile.Display(game.winningSpadesPile, 72, 3);
            }

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
                SelectedPilePosition = SelectablePiles.Count - 1;
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

            if (SelectedPilePosition + 1 < SelectablePiles.Count)
            {
                SelectedPilePosition++;
            }
            else
            {
                SelectedPilePosition = 0;
            }

            UpdateSelectedPile();
        }

        public void SetupSelectablePiles(bool withNextToCornerPile)
        {
            SelectablePiles = new List<GameModel.PileBase>();

            SelectablePiles.Add(game.cornerPile);

            if (withNextToCornerPile)
            {
                SelectablePiles.Add(game.nextToCornerPile);
            }

            foreach (GameModel.FieldPile fieldPile in game.fieldPiles)
            {
                SelectablePiles.Add(fieldPile);
            }

            UpdateSelectedPile();
        }

        private void UpdateSelectedPile()
        {
            SelectedPile = SelectablePiles[SelectedPilePosition];
            SelectedPile.Selected = true;
        }
    }
}
