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
                case "blackred":
                    return new BlackRedColourOnlyComparisonStrategy();
                case "rank":
                    return new RankCardComparisonStrategy();
                case "strict":
                    return new StrictCardComparisonStrategy();
                case "colour":
                    return new ColourCardComparisonStrategy();
            }
            return None();
            //throw new NotImplementedException("Test 105");
        }

        public ICardComparisonStrategy None()
        {
            return new AlwaysFailComparisonStrategy();
            //throw new NotImplementedException("Test 107");
        }
    }
}
