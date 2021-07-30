using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class GamePile
    {
        public static void Display(GameModel.PileBase pile, int x, int y)
        {
            var card = new GameCard();
            card.Display(pile.Last(), x, y, pile.Selected);
        }
    }
}
