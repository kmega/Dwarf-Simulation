using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Cards;

namespace Core.Usecases.CardComparison
{
    public class BlackRedColourOnlyComparisonStrategy : ICardComparisonStrategy
    {
        private bool IsBlack(Card card)
        {
            if (card.Colour() == "S" || card.Colour() == "C")
            {
                return true;
            }

            return false;
        }

        private bool IsRed(Card card1)
        {
            if (card1.Colour() == "H" || card1.Colour() == "D")
            {
                return true;
            }

            return false;
        }

        public bool AreTheSame(Card card1, Card card2)
        {
            if (IsBlack(card1) && IsBlack(card2))
            {
                return true;
            }
            else if (IsRed(card1) && IsRed(card2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
