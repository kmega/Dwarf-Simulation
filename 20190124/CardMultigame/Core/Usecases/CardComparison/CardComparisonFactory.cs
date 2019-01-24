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
            switch(selector)
            {
                case "strict":
                    return new StrictCardComparisonStrategy();
                    break;
                case "colour":
                    return new ColourCardComparisonStrategy();
                    break;
                case "rank":
                    return new RankCardComparisonStrategy();
                    break;
                case "blackred":
                    return new BlackRedColourOnlyComparisonStrategy();
            }
            return None();
        }

        public ICardComparisonStrategy None()
        {
            return new AlwaysFailComparisonStrategy();
        }
    }
}
