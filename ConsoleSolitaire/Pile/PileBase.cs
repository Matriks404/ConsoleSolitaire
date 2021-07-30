using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel
{
    public abstract class PileBase
    {
        public bool Selected { get; set; }

        public List<Card> contents = new List<Card>();
        
        protected int Count => contents.Count;

        protected Card this[int i]
        {
            get => contents[i];
            set => contents[i] = value;
        }

        public void Add(Card card) => contents.Add(card);
        public bool Any() => contents.Any();

        public void Display(int x, int y)
        {
            Card lastCard = Last();

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

        public Card Last() => (Any()) ? contents.Last() : null; 

        public void Shuffle()
        {
            Random rng = new Random();

            int n = Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = this[k];
                this[k] = this[n];
                this[n] = value;
            }
        }
        protected void Insert(int index, Card card) => contents.Insert(index, card);
        protected void RemoveAt(int index) => contents.RemoveAt(index);
    }
}
