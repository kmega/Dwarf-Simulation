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
                strategy = new BlackRedColourOnlyComparisonStrategy();
                return strategy;
            }
            else if (selector == "strict")
            {
                strategy = new StrictCardComparisonStrategy();
                return strategy;
            }
            else if (selector == "rank")
            {
                strategy = new RankCardComparisonStrategy();
                return strategy;
            }
            else if (selector == "blackred")
            {
                strategy = new BlackRedColourOnlyComparisonStrategy();
                return strategy;
            }
            else
                strategy = new AlwaysFailComparisonStrategy();
                return strategy;

        }

        public ICardComparisonStrategy None()
        {
            return new StrictCardComparisonStrategy();
        }
    }
}
