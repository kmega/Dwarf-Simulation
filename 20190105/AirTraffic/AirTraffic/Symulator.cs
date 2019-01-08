using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AirTraffic
{
    class Symulator
    {
        public void Run()
        {
            ControlTower tower = new ControlTower();
            TrafficSystem trafficSystem = new TrafficSystem();

            RoundOperations(tower, trafficSystem, 1000);

           
        }
        void RoundOperations(ControlTower tower, TrafficSystem trafficSystem, int rounds)
        {
            int start = 1;
            for (int i = 1; i <= rounds; i++)
            {
                
                

                if (trafficSystem.Planes.Count <= 0)
                {
                    Console.WriteLine(i);
                    break;
                }

                if (i >= 3)
                {

                    var Plane = GetPlaneToLanding(trafficSystem.Planes);
                    if (Plane == null) break;

                    tower.Landing(Plane, trafficSystem.Planes);

                    UpdateLaneOccupiedTime(trafficSystem);
                  

                }

                UpdateFuel(trafficSystem.Planes);
                DeleteDestroyedPlane(trafficSystem.Planes);
                start++;
            }

            if (start < rounds)
                FlightStatus(trafficSystem.Planes, start, rounds);
        }

        private void DeleteDestroyedPlane(List<PlaneCreator> planes)
        {
            planes.RemoveAll(x => x.ActualFuel <= 0);
        }

        private void UpdateFuel(List<PlaneCreator> planes)
        {
            foreach (var plane in planes)
            {
                plane.ActualFuel--;
            }
        }

        private void UpdateLaneOccupiedTime(TrafficSystem trafficSystem)
        {
            var BusyLanes = trafficSystem.lane.Where(x => x.laneTakenStatus == false).ToList();

            foreach (var lane in BusyLanes)
            {
                lane.takenForRounds--;

                if (lane.takenForRounds == 0)
                    lane.laneTakenStatus = false;

            }

        }

        private PlaneCreator GetPlaneToLanding(List<PlaneCreator> Planes)
        {
            if (Planes.Count > 0)
            {
                var Plane = Planes.OrderBy(x => x.ActualFuel).ToList();

                return Plane[0];
            }
           
            else
            {
                return null;
            }
        }

        private static bool AllPlanesApproachedLanding(List<PlaneCreator> planes)
        {
            bool flag = false;
            foreach (var item in planes)
            {
                if (item.number != null)  //dopóki istnieje samolot
                    flag = true;
            }
            return flag;
        }

        public static bool FlightStatus(List<PlaneCreator> planes, int start, int rounds)
        {
            bool flag = true;
            foreach (var item in planes)
            {
                if (item.number != null)
                    flag = false;
            }

            if (flag == true)
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
