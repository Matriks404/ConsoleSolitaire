using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSolitaire.Game
{
    public class CornerPile : PileBase
    {
        public CornerPile()
        {
            foreach (Card.CardSuit suit in (Card.CardSuit[])Enum.GetValues(typeof(Card.CardSuit)))
            {
                foreach (Card.CardNumber number in (Card.CardNumber[])Enum.GetValues(typeof(Card.CardNumber)))
                {
                    Add(new Card(suit, number));
                }
            }
        }


        public void PushToStart(Card card)
        {
            Insert(0, card);
        }

        public Card Pop()
        {
            Card card = Last();

            RemoveAt(Count - 1);

            return card;
        }
    }
}
