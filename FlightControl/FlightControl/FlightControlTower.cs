using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightControl
{
    class FlightControlTower
    {

        public void TrafficControl(List<Plane> planes, List<Runway> runways)
        {
            
            for (int i = 0; i < 1000; i++)
            {
                if (Runway.CheckIsOccupied(runways))
                {

                }
            }
        }
    }
}
