using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSolitaire.Game
{
    public class WinningPile : PileBase
    {
        Card.CardSuit Suit;

        public WinningPile(Card.CardSuit suit) => Suit = suit;

        //TODO: This is wrong. We should push cards only from field piles.
        /*public bool Push(Card card)
        {
            if (card.Suit != this.Suit)
            {
                return false;
            }
            else
            {
                Add(card);

                return true;
            }
        }*/
    }
}
