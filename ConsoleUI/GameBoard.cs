using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class GameBoard
    {
        private GameModel.Instance game;
        public GameBoard(GameModel.Instance game) => this.game = game;

        public void Display()
        {
            PileDisplay(game.cornerPile, 0, 3);
            PileDisplay(game.nextToCornerPile, 12, 3);

            if (game.winningClubsPile.Any())
                PileDisplay(game.winningClubsPile, 36, 3);

            if (game.winningDiamondsPile.Any())
                PileDisplay(game.winningDiamondsPile, 48, 3);

            if (game.winningHeartsPile.Any())
                PileDisplay(game.winningHeartsPile, 60, 3);

            if (game.winningSpadesPile.Any())
                PileDisplay(game.winningSpadesPile, 72, 3);

            for (int i = 0; i < game.fieldPiles.Length; i++)
            {
                PileDisplay(game.fieldPiles[i], i * 12, 10);
            }
        }

        public void PileDisplay(GameModel.PileBase pile, int x, int y)
        {
            GameModel.Card lastCard = pile.Last();

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
                int amountOfSpaces = width - 2 - lastCard.GetNumber().Length;

                for (int i = 0; i < amountOfSpaces; i++)
                {
                    Console.Write(' ');
                }
            }

            char Boundary() => (pile.Selected) ? ':' : '#';

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
                Console.Write(lastCard.GetNumber());

                Spaces();

                Console.WriteLine(Boundary());
            }

            void SuitName()
            {
                int leftSpaces = (width - lastCard.Suit.ToString().Length - 2) / 2;
                int rightSpaces = leftSpaces;

                if (lastCard.Suit.ToString().Length % 2 == 1)
                    rightSpaces++;

                Console.Write(Boundary());

                for (int i = 0; i < leftSpaces; i++)
                {
                    Console.Write(' ');
                }

                Console.Write(lastCard.Suit);

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

                Console.Write(lastCard.GetNumber());
                Console.WriteLine(Boundary());
            }
        }
    }
}
