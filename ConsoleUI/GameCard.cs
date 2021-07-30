using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class GameCard
    {
        int width = 10;
        char boundary;
        string cardNumber;
        string cardSuit;

        //TODO: Card selection instead of pile selection for field piles.
        public void Display(GameModel.Card lastCard, int x, int y, bool selected)
        {
            boundary = GetBoundary(selected);
            cardNumber = lastCard.GetNumber();
            cardSuit = lastCard.Suit.ToString();

            Console.SetCursorPosition(x, y);
            Console.WriteLine(TopBottomBoundary());
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine(TopNumber());

            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine(SuitName());

            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine(BottomNumber());

            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine(TopBottomBoundary());
        }

        private string BottomNumber() => boundary + Spaces() + cardNumber + boundary;

        private string TopNumber() => boundary + cardNumber + Spaces() + boundary;

        private char GetBoundary(bool selected) => (selected) ? ':' : '#';

        private string TopBottomBoundary()
        {
            string line = string.Empty;

            for (int i = 0; i < width; i++)
            {
                line += boundary;
            }

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
