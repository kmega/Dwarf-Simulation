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
            bool black1 = false, black2 = false;
            bool red1 = true, red2 = true;

            switch (card1.Colour())
            {
                case "S":
                case "C":
                    black1 = true;
                    red1 = false;
                    break;
                case "H":
                case "D":
                    black1 = false;
                    red1 = true;
                    break;
                default:
                    break;
            }
            switch (card2.Colour())
            {
                case "S":
                case "C":
                    black2 = true;
                    red2 = false;
                    break;
                case "H":
                case "D":
                    black2 = false;
                    red2 = true;
                    break;
                default:
                    break;
            }


            if (black1 == black2 || red1 == red2) return true;
            else return false;
        }
    }
}
