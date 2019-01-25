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
            if (selector.Equals("colour"))
            {
                return new ColourCardComparisonStrategy();
            }
            else if (selector.Equals("strict"))
            {
                return new StrictCardComparisonStrategy();
            }
            else if (selector.Equals("rank"))
            {
                return new RankCardComparisonStrategy();
            }
            else if (selector.Equals("blackred"))
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
            return null;
        }
    }
}
