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
        public bool AreTheSame(Card card1, Card card2)
        {
            if(GetCardColour(card1) == GetCardColour(card2))
            {
                return true;
            }
            return false;
        }
        private Color GetCardColour(Card card)
        {
            if(card.Colour().Equals("H") || card.Colour().Equals("D"))
            {
                return Color.Red;
            }
            else
            {
                return Color.Black;
            }
        }
    }
    enum Color
    {
        None, Black, Red
    }
}
