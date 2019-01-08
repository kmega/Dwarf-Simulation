using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator
{
    public class AirportSimulation
    {
        public string Simulate(List<Plain> listofplain, int howManyPlanesToSimulate)
        {
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
                    bool answer = planeToLand.AskForFreeRunaway(ct);
                    if (answer)
                    {
                        listofplain.Remove(planeToLand);
                    }                 
                }
                ct.RunwayCleaner();
                killedPlanes += Plain.LoseFuel(listofplain);
            };
            iterations += ct.landingzones.Max(x => x.BlockedTimer);
            string content = "Symulacja skończyła się po: " + iterations+" turach, a samolotów " +
                "zginęło: " + killedPlanes;
            return content;
        }
    }
}
