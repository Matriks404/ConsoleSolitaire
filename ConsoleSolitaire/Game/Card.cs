using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSolitaire.Game
{
    public class Card
    {
        public bool Hidden { get; set; }
        public bool Selected { get; set; }
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
        public static void GetNext(ref CornerPile cornerPile, ref NextToCornerPile nextToCornerPile)
        {
            if (nextToCornerPile.Last() != null)
            {
                cornerPile.PushToStart(nextToCornerPile.Last());
            }

            nextToCornerPile.Add(cornerPile.Pop());
        }

        public void DisplayCard(int x, int y)
        {
            int width = 10;

            Console.SetCursorPosition(x, y);
            TopBottomBoundary();
            Console.SetCursorPosition(x, y + 1);
            TopNumber();

            Console.SetCursorPosition(x, y + 2);
            SuitName();

            Console.SetCursorPosition(x, y + 3);
            BottomNumber();

            Console.SetCursorPosition(x, y + 4);
            TopBottomBoundary();

            void Spaces()
            {
                int amountOfSpaces = width - 2 - GetNumber().Length;

                for (int i = 0; i < amountOfSpaces; i++)
                {
                    Console.Write(' ');
                }
            }

            char Boundary() => (Selected) ? ':' : '#';

            void TopBottomBoundary()
            {
                for (int i = 0; i < width; i++)
                {
                    Console.Write(Boundary());
                }

                Console.WriteLine();
            }

            void TopNumber()
            {
                Console.Write(Boundary());
                Console.Write(GetNumber());

                Spaces();

                Console.WriteLine(Boundary());
            }

            void SuitName()
            {
                int leftSpaces = (width - Suit.ToString().Length - 2) / 2;
                int rightSpaces = leftSpaces;

                if (Suit.ToString().Length % 2 == 1)
                    rightSpaces++;

                Console.Write(Boundary());

                for (int i = 0; i < leftSpaces; i++)
                {
                    Console.Write(' ');
                }

                Console.Write(Suit);

                for (int i = 0; i < rightSpaces; i++)
                {
                    Console.Write(' ');
                }

                Console.WriteLine(Boundary());
            }

            void BottomNumber()
            {
                Console.Write(Boundary());

                Spaces();

                Console.Write(GetNumber());
                Console.WriteLine(Boundary());
            }
        }

        public string GetNumber() { 
            if (Number == CardNumber.Ace || Number > CardNumber.Ten)
            {
                return Number.ToString();
            } else
            {
                return ((int)Number).ToString();
            }
        }
    }
}
