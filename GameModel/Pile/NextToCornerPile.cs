using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel
{
    public class NextToCornerPile : PileBase
    {
        public void GetNextCard(ref CornerPile cornerPile)
        {
            if (this.Last() != null)
            {
                cornerPile.PushToStart(this.Last());
            }

            cornerPile.Last().Hidden = false;
            this.Add(cornerPile.Pop());
        }
    }
}
