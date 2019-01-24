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
            switch (selector)
            {
                case "colour":
                    return new ColourCardComparisonStrategy();
                case "strict":
                    return new StrictCardComparisonStrategy();
                case "rank":
                    return new RankCardComparisonStrategy();
                case "blackred":
                    return new BlackRedColourOnlyComparisonStrategy();
                default:
                    return new AlwaysFailComparisonStrategy();

            }

        }

        public ICardComparisonStrategy None()
        {
            throw new NotImplementedException("Test 107");
        }
    }
}
