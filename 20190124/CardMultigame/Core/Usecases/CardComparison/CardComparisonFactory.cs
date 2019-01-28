using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Usecases.CardComparison
{
    public class CardComparisonFactory
    {
        public ICardComparisonStrategy Create(string selector)
        {
            ICardComparisonStrategy strategy;

            if (selector == "colour")
            {
                strategy = new ColourCardComparisonStrategy();
            }
            else if (selector == "strict")
            {
                strategy = new StrictCardComparisonStrategy();
            }
            else if (selector == "rank")
            {
                strategy = new RankCardComparisonStrategy();
            }
            else if (selector == "blackred")
            {
                strategy = new BlackRedColourOnlyComparisonStrategy();
            }
            else
                strategy = new AlwaysFailComparisonStrategy();



            return strategy;

        }

        public ICardComparisonStrategy None()
        {
            return new StrictCardComparisonStrategy(); ;
        }
    }
}
