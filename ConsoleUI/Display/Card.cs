using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Display
{
    public class Card
    {
        int width = 10;
        char boundary;
        string cardNumber;
        string cardSuit;

        //TODO: Card selection instead of pile selection for field piles.
        public void Display(GameModel.Card card, int x, int y, bool selected, bool partial)
        {
            boundary = GetBoundary(selected);

            // Write top and bottom boundaries.
            Console.SetCursorPosition(x, y);
            Console.Write(HorizontalBoundary());

            if (!partial)
            {
                Console.SetCursorPosition(x, y + 4);
                Console.Write(HorizontalBoundary());
            }

            if (card.Visible)
            {
                cardNumber = card.GetNumber();
                cardSuit = card.Suit.ToString();

                Console.SetCursorPosition(x, y + 1);
                Console.Write(TopNumber());

                Console.SetCursorPosition(x, y + 2);
                Console.Write(SuitName());

                if (!partial)
                {
                    Console.SetCursorPosition(x, y + 3);
                    Console.Write(BottomNumber());
                }
            }
            else
            {
                int lines;

                if (partial)
                {
                    lines = 2;
                }
                else
                {
                    lines = 3;
                }

                for (int i = 1; i <= lines; i++)
                {
                    Console.SetCursorPosition(x, y + i);
                    Console.Write(VerticalBoundary());
                }
            }
        }

        private string BottomNumber() => boundary + Spaces() + cardNumber + boundary;

        private string TopNumber() => boundary + cardNumber + Spaces() + boundary;

        private char GetBoundary(bool selected) => (selected) ? ':' : '#';

        private string HorizontalBoundary()
        {
            string line = string.Empty;

            for (int i = 0; i < width; i++)
            {
                line += boundary;
            }

            return line;
        }

        private string VerticalBoundary()
        {
            string line = string.Empty;

            line += boundary;

            for (int i = 0; i < width - 2; i++)
            {
                line += ' ';
            }

            line += boundary;

            return line;
        }

        private string Spaces()
        {
            int amountOfSpaces = width - 2 - cardNumber.Length;
            string line = string.Empty;

            for (int i = 0; i < amountOfSpaces; i++)
            {
                line += ' ';
            }

            return line;
        }

        private string SuitName()
        {
            string line = string.Empty;

            int leftSpaces = (width - cardSuit.Length - 2) / 2;
            int rightSpaces = leftSpaces;

            if (cardSuit.Length % 2 == 1)
                rightSpaces++;

            line += boundary;

            for (int i = 0; i < leftSpaces; i++)
            {
                line += ' ';
            }

            line += cardSuit;

            for (int i = 0; i < rightSpaces; i++)
            {
                line += ' ';
            }

            line += boundary;

            return line;
        }
    }
}
