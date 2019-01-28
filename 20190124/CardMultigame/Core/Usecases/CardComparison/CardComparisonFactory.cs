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
            if (selector == "colour")
            {
                return new ColourCardComparisonStrategy();
            }
            else if (selector == "strict")
            {
                return new StrictCardComparisonStrategy();
            }
            else if (selector == "rank")
            {
                return new RankCardComparisonStrategy();
            }
            else if (selector == "blackred")
            {
                return new BlackRedColourOnlyComparisonStrategy();
            }
            else
            {
                return new AlwaysFailComparisonStrategy();
            }
        }

        public ICardComparisonStrategy None()
        {
            return new AlwaysFailComparisonStrategy();
        }
    }
}