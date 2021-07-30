using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel
{
    public class FieldPile : PileBase
    {
        public FieldPile(CornerPile sourcePile, int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.Add(sourcePile.Pop());

                if (i == count - 1)
                {
                    this.Last().Visible = true;
                }
            }
        }
    }
}
