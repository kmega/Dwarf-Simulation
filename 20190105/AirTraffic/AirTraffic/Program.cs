using System;
using System.Collections.Generic;

namespace AirTraffic
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlTower tower = new ControlTower();
            TrafficSystem trafficSystem = new TrafficSystem();

            RoundOperations(tower, trafficSystem, 1000);
                
            
            Console.ReadKey();
        }

        private static void RoundOperations(ControlTower tower, TrafficSystem trafficSystem, int rounds)
        {
            int start = 0;
            do
            {
                foreach (PlaneCreator singlePlane in trafficSystem.Planes)
                {
                    if (singlePlane.number != null)
                    {
                        start++;
                        tower.GetLaneForLanding(singlePlane, trafficSystem.Planes);
                    }
                    if (start >= rounds)
                    {
                        FlightStatus(trafficSystem.Planes, start, rounds);
                        break;
                    }

                }

            } while (AllPlanesApproachedLanding(trafficSystem.Planes));
            
            if (start < rounds)
                FlightStatus(trafficSystem.Planes, start, rounds);
        }

        private static bool AllPlanesApproachedLanding(List<PlaneCreator> planes)
        {
            bool flag = false;
            foreach (var item in planes)
            {
                if (item.number != null)
                    flag = true;
            }
            return flag;
        }

        private static bool FlightStatus(List<PlaneCreator> planes, int start, int rounds)
        {
            bool flag = true;
            foreach (var item in planes)
            {
                if (item.number != null)
                    flag = false;
            }

            if(flag == true)
            {
                if (start < rounds)
                    Console.WriteLine("All Planes laneded in {0} rounds", start);
                else
                    Console.WriteLine("Lost, all didnt land in {0} rounds(real {1})", rounds, start);
            }

            return flag;
        }
    }

   
}
