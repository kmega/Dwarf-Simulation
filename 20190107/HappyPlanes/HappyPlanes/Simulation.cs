using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes
{
    public class Simulation
    {
        ControlTower tower = new ControlTower();
        public void Start(int numberOfPlanes, int numberOfRunways)
        {
            List<Planes> planes = BuildPlanes(numberOfPlanes);
            List<Runway> runways = BuildRunways(numberOfRunways);
            
            List<Planes> wishToLand = new List<Planes>();

            for (int i = 0; i < 1000; i++)
            {
                if(i>0)
                    foreach(Planes plane in planes)
                    {
                        plane.DecreasePlaneFuelByFlying();
                    }

                foreach(Planes plane in planes)
                {
                    if(plane.GetPlaneFuel() <= 3 && plane.GetPlaneInAir() == true && plane.GetWishToLand() == false)
                    {
                        wishToLand.Add(plane);
                        plane.SetWishToLand();
                    }
                }

                releaseRunWay(planes,runways);

                if(wishToLand.Count > 0)
                {
                    foreach(Planes plane in wishToLand)
                    {
                        if (plane.GetPlaneFuel() == 0)
                            if (tower.ReceiveAskFromPlane(plane, runways) == true)
                            {
                                plane.RemoveWishToLand();
                                break;
                            }
                    }
                }

                foreach(Planes plane in planes)
                {
                    if (plane.GetPlaneInAir() == false)
                        plane.IncreasePlaneFuelByTankingUp();
                }

                for (int j = 0; j < planes.Count; j++)
                {
                    if(planes[j].GetPlaneFuel() == 0)
                    {
                        planes.RemoveAt(j);
                    }
                }

                Console.WriteLine("Tour number {0}; Flying planes {1}", i, planes.Count);
            }

            Console.WriteLine("From {0} planes only {1} survived", numberOfPlanes, planes.Count);
          
        }

        private void releaseRunWay(List<Planes> planes, List<Runway> runways)
        {

            foreach (Runway runway in runways)
            {
                if(runway.GetRunwayStateFree() == false)
                {
                    foreach (Planes plane in planes)
                    {
                        if(plane.GetPlaneFuel() == plane.GetPlaneFuelMax())
                        {
                            plane.SetPlaneInAir();
                            tower.ReleaseRunway(plane.GetPlaneId(),runways);
                            
                        }

                    }
                }
            }
            
        }

        public List<Planes> BuildPlanes(int numberOfPlanes)
        {
            var planesList = new List<Planes>();

            for (int i = 0; i < numberOfPlanes; i++)
            {
                Random rnd = new Random();
                planesList.Add(new Planes(i, rnd.Next(1,15)));
            }

            return planesList;
        }

        public List<Runway> BuildRunways(int numberOfRunways)
        {
            var runwaysList = new List<Runway>();

            for (int i = 0; i < numberOfRunways; i++)
            {
                runwaysList.Add(new Runway(i));
            }

            return runwaysList;
        }
    }
}
