using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSolitaire.Game
{
    public abstract class PileBase
    {
        public List<Card> contents = new List<Card>();

        protected int Count => contents.Count;

        protected Card this[int i]
        {
            get => contents[i];
            set => contents[i] = value;
        }

        public void Add(Card card) => contents.Add(card);
        public bool Any() => contents.Any();
        protected void Insert(int index, Card card) => contents.Insert(index, card);
        public Card Last() => (Any()) ? contents.Last() : null; 
        protected void RemoveAt(int index) => contents.RemoveAt(index);

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
    }
}
