using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes
{
    public class Simulation
    {
        public void Start(Planes planesToSimulate, Runway runwaysToSimulate)
        {
            var tower = new ControlTower();
 
           // for (int i = 0; i == 1000; i++)
            //{
                tower.ReceiveAskFromPlane(planesToSimulate, runwaysToSimulate);
           // }
        }
    }
}
