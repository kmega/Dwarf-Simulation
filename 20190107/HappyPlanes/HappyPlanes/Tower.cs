using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPlanes
{
    public class ControlTower
    {
        public void ReceiveAskFromPlane(Planes plane, Runway runways)
        {
            ControlTower ask = new ControlTower();
            ask.AskRunway(plane, runways);
        }

        public void AskRunway(Planes plane, Runway runways)
        {
            Dictionary<int, bool> runwayIdState = runways.AllRunwaysIdAndState; 
  
            for (int i = 0; i < runwayIdState.Count; i++)
            {
                if(runwayIdState[i] == true)
                {
                    AnswerPlane(runwayIdState.Keys.ElementAt(runwayIdState.Count()-1), plane, runways);
                }
            }
        }

        public void AnswerPlane(int idOfRunwayToLand, Planes plane, Runway runways)
        {
            plane.SetPlaneState();
            runways.AllRunwaysIdAndState[idOfRunwayToLand] = false;
        }
    }
}
