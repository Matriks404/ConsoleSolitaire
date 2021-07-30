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
        private PileBase[] SelectablePiles { get; set; }
        private int SelectedPilePosition { get; set; }
        private PileBase SelectedPile { get; set; }

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

            SetupSelectablePiles();
        }

        public void Update()
        {
            var key = Console.ReadKey();

            switch(key.Key)
            {
                case ConsoleKey.LeftArrow:
                    SelectPreviousPile();
                    break;
                case ConsoleKey.RightArrow:
                    SelectNextPile();
                    break;
                case ConsoleKey.Spacebar:
                    //TODO: Select card properly.
                    break;
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

        private void SetupSelectablePiles()
        {
            SelectablePiles = new PileBase[] {
                cornerPile,
                nextToCornerPile,
                fieldPiles[0],
                fieldPiles[1],
                fieldPiles[2],
                fieldPiles[3],
                fieldPiles[4],
                fieldPiles[5],
                fieldPiles[6],
            };

            UpdateSelectedPile();
        }

        private void SelectNextPile()
        {
            SelectedPile.Selected = false;

            if (SelectedPilePosition + 1 < SelectablePiles.Length)
            {
                SelectedPilePosition++;
            } else
            {
                SelectedPilePosition = 0;
            }

            UpdateSelectedPile();
        }

        private void SelectPreviousPile()
        {
            SelectedPile.Selected = false;

            if (SelectedPilePosition == 0)
            {
                SelectedPilePosition = SelectablePiles.Length - 1;
            } else
            {
                SelectedPilePosition--;
            }

            UpdateSelectedPile();
        }

        private void UpdateSelectedPile()
        {
            SelectedPile = SelectablePiles[SelectedPilePosition];
            SelectedPile.Selected = true;
        }
    }
}
