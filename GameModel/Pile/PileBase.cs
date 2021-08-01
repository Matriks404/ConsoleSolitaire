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
        
        public int Count => contents.Count;

        public Card this[int i]
        {
            get => contents[i];
            set => contents[i] = value;
        }

        public void Add(Card card) => contents.Add(card);
        public bool Any() => contents.Any();

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
