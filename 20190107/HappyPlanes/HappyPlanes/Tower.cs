using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPlanes
{
    public class ControlTower
    {
        private Dictionary<int, int> planeOnRunway = new Dictionary<int, int>();

        public bool ReceiveAskFromPlane(Planes plane, List<Runway> runways)
        {
            ControlTower ask = new ControlTower();

            return ask.AskRunway(plane, runways);
        }

        public bool AskRunway(Planes plane,  List<Runway> runways)
        {
            bool tryLand = false;
            for (int i = 0; i < runways.Count; i++)
            {
                if(runways[i].GetRunwayStateFree() == true)
                {
                    tryLand = true;
                    AnswerPlane(tryLand, plane, runways[i]);
                }
            }

            return tryLand;
        }

        public void AnswerPlane(bool tryLand, Planes plane,  Runway runway)
        {
            List<Planes> planes = new List<Planes>();
            UpDate(planes);

            if(tryLand == true)
            {
                plane.SetPlaneOnRunway();
                runway.SetRunwayStateBusy();
                planeOnRunway.Add(plane.GetPlaneId(), runway.GetRunwayId());    
            } 
            
        }

        private void UpDate(List<Planes> plane)
        {
            foreach (Planes airPlane in plane)
            {
                if (airPlane.GetPlaneInAir() == true)
                    planeOnRunway.Remove(airPlane.GetPlaneId());
            }
        }

        public Dictionary<int,int> planesOnRunways()
        {
            return planeOnRunway;
        }

        public void ReleaseRunway(int planeId,List<Runway> runways)
        {
            int runwayToRelease = planeOnRunway[planeId];
            foreach(Runway runway in runways)
            {
                if(runway.GetRunwayId() == runwayToRelease)
                {
                    runway.SetRunwayStateFree();
                }
            }
        }
    }
}
