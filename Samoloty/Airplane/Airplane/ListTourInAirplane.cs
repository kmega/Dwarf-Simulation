using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplane
{
    class ListTourInAirplane
    {
        public List<AirPlaneTrack> InformationTour()
        {
            List<AirPlaneTrack> airPlaneTrack = new List<AirPlaneTrack>();
            airPlaneTrack.Add(new AirPlaneTrack { track = 1, howLongIsBusy = 0 });
            airPlaneTrack.Add(new AirPlaneTrack { track = 2, howLongIsBusy = 0 });

            return airPlaneTrack;
        }
    }
}
