using System.Collections.Generic;
using System.Linq;

namespace Mine2._0
{
    public class NormalWorkingStrategy : IWorkStrategy
    {
        public List<E_Minerals> ExecuteWork(Schaft schaft, IRandomizer randomizer)
        {
            int max = randomizer.RandomWorkIteration();
            List<E_Minerals> outputList = new List<E_Minerals>();

            for (int i = 0; i < max; i++)
            {
                int material = randomizer.GenerateRadnomFromRange();
                if (Enumerable.Range(1, 5).Contains(material))
                {
                    outputList.Add(E_Minerals.Mithril);
                }
                else if (Enumerable.Range(6, 20).Contains(material))
                {
                    outputList.Add(E_Minerals.Gold);
                }
                else if (Enumerable.Range(21, 55).Contains(material))
                {
                    outputList.Add(E_Minerals.Silver);
                }
                else
                {
                    outputList.Add(E_Minerals.DritGold);
                }
            }

            schaft.SchaftStats.AddRange(outputList);
            return outputList;
        }
    }


}
