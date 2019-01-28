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
            switch (card1.Colour())
            {
                case "S":
                case "C":
                    switch (card2.Colour())
                    {
                        case "S":
                        case "C":
                            return true;
                        default:
                            return false;
                    }
                case "H":
                case "D":
                    switch (card2.Colour())
                    {
                        case "H":
                        case "D":
                            return true;
                        default:
                            return false;
                    }
                default:
                    return false;
            }
        }
    }
}
