using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    static class Hero
    {
        public static int AssessWholeBuildingTime(int averageTime, int numberOfHeroesWithoutTime, int allGivenTime)
        {
            return allGivenTime + averageTime * numberOfHeroesWithoutTime;
        }

        public static List<string> GetHeroesWithoutTime(List<string> fileContents)
        {
            List<string> heroesWithoutTime = new List<string>();
            foreach (var content in fileContents)
            {
                int time = Extractor.ExtractSingleTime(content);
                if (time == 0)
                {
                    heroesWithoutTime.Add(content);
                }
            }
            return heroesWithoutTime;
        }

        public static int CountAverage(int sumOfGivenTimes, int numberOfHeroesWithTime)
        {
            return sumOfGivenTimes / numberOfHeroesWithTime;
        }

        public static int SumAllTimes(List<int> timesOfBuilding)
        {
            int sum = 0;
            foreach (var time in timesOfBuilding)
            {
                sum += time;
            }
            return sum;
        }
    }
}
