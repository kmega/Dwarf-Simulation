using System;

namespace TortoiseCardGame
{
    public class Deck
    {
        public int Hearts;
        public int Clubs;
        public int Diamonds;

        private CardType DrawCard()
        {
            int value = new Random().Next(0, Hearts + Clubs + Diamonds);
            if (value < Hearts)
            {
                Hearts -= 1;
                return CardType.hearts;
            }
            else if (value < Hearts + Clubs)
            {
                Clubs -= 1;
                return CardType.clubs;
            }
            else
            {
                Diamonds -= 1;
                return CardType.diamonds;
            }
        }

        public CardType[] DrawTwoCards()
        {
            return new[] { DrawCard(), DrawCard() };
        }
    }
}
