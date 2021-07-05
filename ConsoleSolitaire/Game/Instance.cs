using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ConsoleSolitaire.Game.Card;

namespace ConsoleSolitaire.Game
{
    public class Instance
    {
        public bool StillPlaying { get; private set; }
        private Card[] SelectableCards { get; set; }
        private int SelectedCardPosition { get; set; }
        private Card SelectedCard { get; set; }

        private CornerPile cornerPile = new CornerPile();
        private NextToCornerPile nextToCornerPile = new NextToCornerPile();

        private WinningPile winningClubsPile = new WinningPile(CardSuit.Clubs);
        private WinningPile winningDiamondsPile = new WinningPile(CardSuit.Diamonds);
        private WinningPile winningHeartsPile = new WinningPile(CardSuit.Hearts);
        private WinningPile winningSpadesPile = new WinningPile(CardSuit.Spades);

        private FieldPile[] fieldPiles = new FieldPile[7];

        public Instance()
        {
            StillPlaying = true;

            cornerPile.Shuffle();

            //TODO: Temporary
            winningClubsPile.Add(new Card(CardSuit.Clubs, CardNumber.Ace));
            winningDiamondsPile.Add(new Card(CardSuit.Diamonds, CardNumber.Ace));
            winningHeartsPile.Add(new Card(CardSuit.Hearts, CardNumber.Ace));
            winningSpadesPile.Add(new Card(CardSuit.Spades, CardNumber.Ace));

            for (int i = 0; i < fieldPiles.Length; i++)
            {
                fieldPiles[i] = new FieldPile(ref cornerPile, i + 1);
            }

            //TODO: Remove this later. We want user to get the first card from the corner pile.
            Card.GetNext(ref cornerPile, ref nextToCornerPile);
            //GetNextCard();

            SetupSelectableCards();
        }

        public void Loop()
        {
            Display();
            Update();
        }

        private void Display()
        {
            cornerPile.Last().DisplayCard(0, 3);
            nextToCornerPile.Last().DisplayCard(12, 3);

            if (winningClubsPile.Any())
                winningClubsPile.Last().DisplayCard(36, 3);

            if (winningDiamondsPile.Any())
                winningDiamondsPile.Last().DisplayCard(48, 3);

            if (winningHeartsPile.Any())
                winningHeartsPile.Last().DisplayCard(60, 3);

            if (winningSpadesPile.Any())
                winningSpadesPile.Last().DisplayCard(72, 3);

            for (int i = 0; i < fieldPiles.Length; i++)
            {
                fieldPiles[i].Last().DisplayCard(i * 12, 10);
            }
        }


        private void Update()
        {
            var key = Console.ReadKey();

            switch(key.Key)
            {
                case ConsoleKey.LeftArrow:
                    SelectPreviousCard();
                    break;
                case ConsoleKey.RightArrow:
                    SelectNextCard();
                    break;
                case ConsoleKey.Spacebar:
                    //TODO: Select card properly.
                    break;
            }

            SetupSelectableCards();
        }

        //TODO: Selectable piles, not cards.
        private void SetupSelectableCards()
        {
            SelectableCards = new Card[] {
                cornerPile.Last(),
                nextToCornerPile.Last(),
                fieldPiles[0].Last(),
                fieldPiles[1].Last(),
                fieldPiles[2].Last(),
                fieldPiles[3].Last(),
                fieldPiles[4].Last(),
                fieldPiles[5].Last(),
                fieldPiles[6].Last(),
            };

            SelectedCard = SelectableCards[SelectedCardPosition];
            SelectedCard.Selected = true;
        }

        private void SelectNextCard()
        {
            SelectedCard.Selected = false;

            if (SelectedCardPosition + 1 < SelectableCards.Length)
            {
                SelectedCardPosition++;
            } else
            {
                SelectedCardPosition = 0;
            }
        }

        private void SelectPreviousCard()
        {
            SelectedCard.Selected = false;

            if (SelectedCardPosition == 0)
            {
                SelectedCardPosition = SelectableCards.Length - 1;
            } else
            {
                SelectedCardPosition--;
            }
        }
    }
}
