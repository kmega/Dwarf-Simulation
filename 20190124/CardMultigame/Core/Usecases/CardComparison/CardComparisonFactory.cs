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
            switch (selector.ToLower())
            {
                case "strict":
                    return new StrictCardComparisonStrategy();
                case "colour":
                    return new ColourCardComparisonStrategy();
                case "rank":
                    return new RankCardComparisonStrategy();
                case "redblack":
                case "blackred":
                    return new BlackRedColourOnlyComparisonStrategy();
                default:
                    return new AlwaysFailComparisonStrategy();
            }
        }

        public ICardComparisonStrategy None()
        {
            return new StrictCardComparisonStrategy();
        }
    }
}
