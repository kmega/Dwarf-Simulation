using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes
{
    public class Simulation
    {
        public void Start(PlanesMain planesToSimulate, RunwayMain runwaysToSimulate, PlanesMain.Planes plane, RunwayMain.Runway runway)
        {
            var tower = new ControlTower();
 
           // for (int i = 0; i == 1000; i++)
            //{
                tower.ReceiveAskFromPlane(planesToSimulate,plane, runwaysToSimulate);
           // }
        }
    }
}
