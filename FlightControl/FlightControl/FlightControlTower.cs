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
                while (Runway.CheckRunwayAreFree(runways))
                {
                    var planeInFlight = Plane.FindFirstInFlight(planes);
                    Plane.StopAtAirport(planeInFlight);
                    Runway.LockRunway(runways);
                }


                var planesOnGround = Plane.FindPlanesOnGround(planes);

                foreach (var plane in planesOnGround)
                {
                    if (plane.OnGroundTime == 5)
                    {
                        Plane.StartFromAirport(plane);
                        Runway.ReleaseRunway(runways);
                    }
                    plane.OnGroundTime += 1;

                }
            }
        }
    }
}
