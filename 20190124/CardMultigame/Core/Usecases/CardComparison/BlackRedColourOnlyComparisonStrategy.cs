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
            //popraw nie uwzgledniam koloru czarnego
            if ((card1.Colour() == "H" || card1.Colour() == "D")
                && (card2.Colour() == "H" || card2.Colour() == "D"))
            {
                return true;
            }
            else
                return false;
        }
    }
}
