using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samoloty
{
    class HappyPlaneSimulation
    {
        public static List<Airplane> generateAirplanes(int n)
        {
            List<Airplane> airplanes = new List<Airplane>();
            for (int i = 0; i < n; i++)
                airplanes.Add(new Airplane());
            return airplanes;
        }
        public static List<Airstrip> generateAirstrips(int n)
        {
            List<Airstrip> airstrips = new List<Airstrip>();
            for (int i = 0; i < n; i++)
                airstrips.Add(new Airstrip());
            return airstrips;
        }
        public void Simulation()
        {
            List<Airplane> airplanes = generateAirplanes(15);
            List<Airstrip> airstrips = generateAirstrips(10);
            ControlTower controlTower = new ControlTower(airstrips);
            
            for(int i=1;i<=25;i++)
            {
                if (i % 5 == 0)
                    controlTower.RestoreAirstrip();
                foreach(Airplane airplane in airplanes)
                {
                    if(airplane.inAir && airplane.fuel > 0)
                    {
                        airplane.RequestForPermission(controlTower);
                        if(airplane.permission)
                        {
                            Airstrip airstrip = controlTower.GetFreeAirstrip();
                            airplane.TryLand(airstrip);
                        }
                        break;
                    }
                }
                Console.WriteLine($" {i} iteracja");
            }
        }
    }
}
