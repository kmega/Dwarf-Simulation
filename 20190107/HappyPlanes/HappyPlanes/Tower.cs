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

        public void AskRunway(Planes plane, List<Runway> runways)
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
        }

        public void AnswerPlane(bool tryLand, Planes plane, Runway runway)
        {
            

            if(tryLand == true)
            {
                plane.SetPlaneOnRunway();
                runway.SetRunwayStateBusy();
                planeOnRunway.Add(plane.GetPlaneId(), runway.GetRunwayId());    
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
