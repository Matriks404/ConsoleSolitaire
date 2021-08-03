using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Display
{
    public class Card
    {
        public static List<GameModel.Card> SelectableCards { get; set; }
        public static int SelectedPosition { get; set; }
        public static GameModel.Card Selected { get; set; }
        int width = 10;

        private char Boundary { get; set; }
        private string CardNumber { get; set; }
        private string CardSuit { get; set; }

        public static void GoToPrevious()
        {
            if (IsSelectable())
            {
                if (SelectedPosition == 0)
                {
                    SelectedPosition = SelectableCards.Count - 1;
                }
                else
                {
                    SelectedPosition--;
                }

                UpdateSelected();
            }
        }

        public static void GoToNext()
        {
            if (IsSelectable())
            {
                if (SelectedPosition + 1 < SelectableCards.Count)
                {
                    SelectedPosition++;
                }
                else
                {
                    SelectedPosition = 0;
                }

                UpdateSelected();
            }
        }

        public static void SetupSelectableCards(GameModel.PileBase pile)
        {
            SelectableCards = pile.contents;
            SelectedPosition = pile.Count - 1;

            UpdateSelected();
        }

        public static void UpdateSelected()
        {
            Selected = SelectableCards[SelectedPosition];
        }

        public void Show(GameModel.Card card, int x, int y, bool pileSelected, bool partial)
        {
            Boundary = GetBoundary(card, pileSelected);

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
                CardNumber = card.GetNumber();
                CardSuit = card.Suit.ToString();

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

        private static bool IsSelectable() => (Display.Pile.Selected.GetType() == typeof(GameModel.FieldPile) && SelectableCards != null);

        private string BottomNumber() => Boundary + Spaces() + CardNumber + Boundary;

        private string TopNumber() => Boundary + CardNumber + Spaces() + Boundary;

        private char GetBoundary(GameModel.Card card, bool pileSelected) => ((card == Selected || SelectableCards == null) && pileSelected) ? ':' : '#';

        private string HorizontalBoundary()
        {
            string line = string.Empty;

            for (int i = 0; i < width; i++)
            {
                line += Boundary;
            }

            return line;
        }

        private string VerticalBoundary()
        {
            string line = string.Empty;

            line += Boundary;

            for (int i = 0; i < width - 2; i++)
            {
                line += ' ';
            }

            line += Boundary;

            return line;
        }

        private string Spaces()
        {
            int amountOfSpaces = width - 2 - CardNumber.Length;
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

            int leftSpaces = (width - CardSuit.Length - 2) / 2;
            int rightSpaces = leftSpaces;

            if (CardSuit.Length % 2 == 1)
                rightSpaces++;

            line += Boundary;

            for (int i = 0; i < leftSpaces; i++)
            {
                line += ' ';
            }

            line += CardSuit;

            for (int i = 0; i < rightSpaces; i++)
            {
                line += ' ';
            }

            line += Boundary;

            return line;
        }
    }
}
