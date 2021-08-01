using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static GameModel.Card;

namespace GameModel
{
    public class Instance
    {
        public bool StillPlaying { get; private set; }

        public readonly CornerPile cornerPile = new CornerPile();
        public readonly NextToCornerPile nextToCornerPile = new NextToCornerPile();

        public readonly WinningPile winningClubsPile = new WinningPile(CardSuit.Clubs);
        public readonly WinningPile winningDiamondsPile = new WinningPile(CardSuit.Diamonds);
        public readonly WinningPile winningHeartsPile = new WinningPile(CardSuit.Hearts);
        public readonly WinningPile winningSpadesPile = new WinningPile(CardSuit.Spades);

        public readonly FieldPile[] fieldPiles = new FieldPile[7];

        public Instance()
        {
            StillPlaying = true;

            cornerPile.Shuffle();

            PutTestCardsOnWinningPiles();

            for (int i = 0; i < fieldPiles.Length; i++)
            {
                fieldPiles[i] = new FieldPile(cornerPile, i + 1);
            }

            //TODO: Remove this later. We want user to get the first card from the corner pile.
            nextToCornerPile.GetNextCard(cornerPile);
        }

        public void Update(Message msg)
        {
            switch (msg)
            {
                case Message.DoNothing:
                    break;
                case Message.Exit:
                    StillPlaying = false;

                    break;
                case Message.SelectCards:
                    throw new NotImplementedException();
            }
        }

        //TODO: This is temporary!
        private void PutTestCardsOnWinningPiles()
        {
            winningClubsPile.Add(new Card(CardSuit.Clubs, CardNumber.Ace));
            winningDiamondsPile.Add(new Card(CardSuit.Diamonds, CardNumber.Ace));
            winningHeartsPile.Add(new Card(CardSuit.Hearts, CardNumber.Ace));
            winningSpadesPile.Add(new Card(CardSuit.Spades, CardNumber.Ace));

            winningClubsPile.Last().Visible = true;
            winningDiamondsPile.Last().Visible = true;
            winningHeartsPile.Last().Visible = true;
            winningSpadesPile.Last().Visible = true;
        }
    }
}
