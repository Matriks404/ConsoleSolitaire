using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel
{
    public class NextToCornerPile : PileBase
    {
        public void GetNextCard(CornerPile cornerPile)
        {
            if (this.Last() != null)
            {
                cornerPile.PushToStart(this.Last());
            }

            this.Add(cornerPile.Pop());
            this.Last().Visible = true;
        }
    }
}
