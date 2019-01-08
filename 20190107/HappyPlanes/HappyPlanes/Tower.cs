using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPlanes
{
    public class ControlTower
    {
        public void ReceiveAskFromPlane(PlanesMain planesSimulation,PlanesMain.Planes plane, RunwayMain runwaySimulation)
        {
            ControlTower ask = new ControlTower();
            ask.AskRunway(planesSimulation,plane, runwaySimulation);
        }

        public void AskRunway(PlanesMain planesSimulation,PlanesMain.Planes plane, RunwayMain runways)
        {
            Dictionary<int, bool> runwayIdState = runways.AllRunwaysIdAndState; 
  
            for (int i = 0; i < runwayIdState.Count; i++)
            {
                if(runwayIdState[i] == true)
                {
                    AnswerPlane(runwayIdState.Keys.ElementAt(runwayIdState.Count()-1), planesSimulation, plane, runways);
                }
            }
        }

        public void AnswerPlane(int idOfRunwayToLand, PlanesMain planesSimulation, PlanesMain.Planes plane, RunwayMain runwaysSimulation)
        {
            planesSimulation.AllPlanesIdsAndRunway[plane.GetPlaneId()] = idOfRunwayToLand;
            plane.SetPlaneState();
            runwaysSimulation.AllRunwaysIdAndState[idOfRunwayToLand] = false;
        }
    }
}
