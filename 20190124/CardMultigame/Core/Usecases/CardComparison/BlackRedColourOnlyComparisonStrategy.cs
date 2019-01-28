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
            if (card1.Colour() == card2.Colour())
            {
                return true;
            }
            else if ((card1.Colour() == "S" && card2.Colour() == "C") || (card1.Colour() == "C" && card2.Colour() == "S"))
            {
                return true;
            }
            else if ((card1.Colour() == "H" && card2.Colour() == "D") || (card1.Colour() == "D" && card2.Colour() == "H"))
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