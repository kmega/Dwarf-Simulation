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
        private List<string> redTypeOfCards = new List<string>() { "H", "D" };
        private List<string> blackTypeOfCards = new List<string>() { "S", "C" };
        public bool AreTheSame(Card card1, Card card2)
        {
            if (redTypeOfCards.Contains(card1.Colour()) && redTypeOfCards.Contains(card2.Colour()))
                return true;
            else if (blackTypeOfCards.Contains(card1.Colour()) && blackTypeOfCards.Contains(card2.Colour()))
                return true;
            return false;
        }
    }
}
