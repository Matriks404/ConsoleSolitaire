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
        private PileBase[] SelectablePiles { get; set; }
        private int SelectedPilePosition { get; set; }
        private PileBase SelectedPile { get; set; }

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

            SetupSelectablePiles();
        }

        public void Loop()
        {
            Display();
            Update();
        }

        private void Display()
        {
            cornerPile.Display(0, 3);
            nextToCornerPile.Display(12, 3);

            if (winningClubsPile.Any())
                winningClubsPile.Display(36, 3);

            if (winningDiamondsPile.Any())
                winningDiamondsPile.Display(48, 3);

            if (winningHeartsPile.Any())
                winningHeartsPile.Display(60, 3);

            if (winningSpadesPile.Any())
                winningSpadesPile.Display(72, 3);

            for (int i = 0; i < fieldPiles.Length; i++)
            {
                fieldPiles[i].Display(i * 12, 10);
            }
        }


        private void Update()
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
