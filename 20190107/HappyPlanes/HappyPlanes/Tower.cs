using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPlanes
{
    public class ControlTower
    {
        private Dictionary<int, int> planeOnRunway = new Dictionary<int, int>();

        public void ReceiveAskFromPlane(Planes plane, List<Runway> runways)
        {
            ControlTower ask = new ControlTower();
            ask.AskRunway(plane, runways);
        }

        public void AskRunway(Planes plane, List<<Planes> planes List<Runway> runways)
        {
            bool tryLand = false;
            for (int i = 0; i < runways.Count; i++)
            {
                if(runways[i].GetRunwayStateFree() == true)
                {
                    tryLand = true;
                    AnswerPlane(tryLand, plane, planes, runways[i]);
                }
            }
        }

        public void AnswerPlane(bool tryLand, Planes plane, List<Planes> planes, Runway runway)
        {

            UpDate(List < Planes > planes);

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
