using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Display
{
    public static class Pile
    {
        public static List<GameModel.PileBase> SelectablePiles { get; private set; }
        public static int SelectedPosition { get; set; }
        public static GameModel.PileBase Selected { get; set; }

        public static void Display(GameModel.PileBase pile, int x, int y)
        {
            var card = new Card();
            bool selected = (pile == Selected);

            if (pile.GetType() == typeof(GameModel.FieldPile) && pile.Count > 1)
            {
                Card.SelectableCards = pile.contents;
                Card.SelectedPosition = pile.Count - 1;
                Card.Selected = pile[Card.SelectedPosition];

                for (int i = 0; i < pile.Count - 1; i++)
                {
                    card.Display(pile[i], x, y, selected, true);

                    y += 3;
                }
            }
            else
            {
                Card.SelectableCards = null;
            }

            card.Display(pile.Last(), x, y, selected, false);
        }

        public static void GoToPrevious()
        {
            if (Pile.SelectedPosition == 0)
            {
                Pile.SelectedPosition = Pile.SelectablePiles.Count - 1;
            }
            else
            {
                Pile.SelectedPosition--;
            }

            UpdateSelected();
        }

        public static void GoToNext()
        {
            if (Pile.SelectedPosition + 1 < Pile.SelectablePiles.Count)
            {
                Pile.SelectedPosition++;
            }
            else
            {
                Pile.SelectedPosition = 0;
            }

            UpdateSelected();
        }

        public static void SetupSelectablePiles(GameModel.Instance game, bool withNextToCornerPile)
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

            UpdateSelected();
        }

        private static void UpdateSelected()
        {
            Selected = SelectablePiles[SelectedPosition];
        }
    }
}

