using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samoloty
{
    public class HappyPlaneSimulation
    {
        public static List<Airplane> generateAirplanes(int n)
        {
            List<Airplane> airplanes = new List<Airplane>();
            for (int i = 0; i < n; i++)

                airplanes.Add(new Airplane(7));
            return airplanes;
        }
        public static List<Airstrip> generateAirstrips(int n)
        {
            List<Airstrip> airstrips = new List<Airstrip>();
            for (int i = 0; i < n; i++)
                airstrips.Add(new Airstrip());
            return airstrips;
        }

        public int Simulation(int numberOfPlanes, int numberOfRunways)
        {
            List<Airplane> airplanes = generateAirplanes(numberOfPlanes);
            List<Airstrip> airstrips = generateAirstrips(numberOfRunways);
            
            ControlTower controlTower = new ControlTower(airstrips);

            for (int i = 1; i <= 1000; i++)
            {
                bool breaked = false;

                for (int z = 0; z < airplanes.Count; z++)
                {
                    if (airplanes[z].inAir == false)
                        airplanes[z].PlaneFuel++;
                }

                for (int y = 0; y < airplanes.Count; y++)
                {
                    if (airplanes[y].PlaneFuel == airplanes[y].TankCapacity)
                        controlTower.RestoreAirstrip();
                }

                for (int j = 0; j < airplanes.Count; j++)
                {
                    bool deleted = false;
                    

                    if (airplanes[j].PlaneFuel == 0)
                    {
                        Console.WriteLine("plane CRASHED");
                        airplanes.Remove(airplanes[j]);
                        
                        Console.WriteLine("Num of flying planes {0}", airplanes.Count);
                        deleted = true;
                    } 

                    else if (airplanes[j].inAir && airplanes[j].PlaneFuel > 0 && breaked == false)
                    {
                        airplanes[j].RequestForPermission(controlTower);
                        if (airplanes[j].permission)
                        {
                            Airstrip airstrip = controlTower.GetFreeAirstrip();
                            airplanes[j].TryLand(airstrip);

                            breaked = true;
                        }
                        
                    }

                    if (deleted == false)
                        airplanes[j].PlaneFuel -= 1;

                }
                if (airplanes.Count == 0)
                    break;

                Console.WriteLine($" {i} iteracja");
            }

            return airplanes.Count;
        }
    }
}

