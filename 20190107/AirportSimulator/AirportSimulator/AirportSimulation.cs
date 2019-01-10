using System.Collections.Generic;
using System.Linq;

namespace AirportSimulator
{
    public class AirportSimulation
    {
        public SimulationReport Simulate(int howManyPlanesToSimulate)
        {
            List<Plain> listofplain = new List<Plain>();
            List<int> initialFuelPossibilites = new List<int>()
            {
                1, 3, 5, 7, 10
            };
            int killedPlanes = 0;
            int iterations = 0;
            ControlTower ct = new ControlTower();

            for (int i = 0; i < 2; i++)
            {
                ct.landingzones.Add(new Runway() { number = i + 1 });
            };

            for (int i = 0; i < 1000; i++)
            {  
                if (i < howManyPlanesToSimulate)
                {
                    listofplain.Add(new Plain(i + 1, initialFuelPossibilites[i % 5]));
                }
                if (listofplain.Count == 0) break;
                iterations += 1;
                if (!(listofplain.Count == 0) && i > 2)
                {
                    //McPochrzest
                    var planeToLand = listofplain.OrderBy(x => x.fueltank).First();
                    bool answer = planeToLand.AskForFreeRunaway(ct, iterations);
                    if (answer)
                    {
                        listofplain.Remove(planeToLand);
                    }                 
                }
                ct.RunwayCleaner();
                killedPlanes += Plain.LoseFuel(listofplain);
            };
            if(ct.landingzones.Where(x=>x.IsEnable==false).Any())
            {
                iterations += ct.landingzones.Where(x => x.IsEnable == false).Max(x => x.BlockedTimer);
            }
            return new SimulationReport()
            {
                CrashedPlanes = killedPlanes,
                TotalIterations = iterations
            };
        }
    }
}
