using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel
{
    public class Card
    {
        public bool Visible { get; set; }
        public CardSuit Suit { get; private set; }
        public CardNumber Number { get; private set; }

        public Card(CardSuit suit, CardNumber number)
        {
            this.Suit = suit;
            this.Number = number;
        }

        public enum CardNumber
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        }

        public enum CardSuit
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
        }

        public string GetNumber()
        {
            if (Number == CardNumber.Ace || Number > CardNumber.Ten)
            {
                return Number.ToString();
            }
            else
            {
                return ((int)Number).ToString();
            }
        }
    }
}
