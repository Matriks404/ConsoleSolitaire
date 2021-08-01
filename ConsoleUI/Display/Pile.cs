using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Display
{
    public static class Pile
    {
        public static void Display(GameModel.PileBase pile, int x, int y)
        {
            var card = new Card();

            if (pile.GetType() == typeof(GameModel.FieldPile) && pile.Count > 1)
            {
                for (int i = 0; i < pile.Count - 1; i++)
                {
                    card.Display(pile[i], x, y, pile.Selected, true);

                    y += 3;
                }
            }

            card.Display(pile.Last(), x, y, pile.Selected, false);
        }
    }
}

