using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplane
{
   public class ControlTower
    {
        List<AirPlaneTrack> listoftracks = new List<AirPlaneTrack>();

        public ControlTower()
        {
            listoftracks = new ListTourInAirplane().InformationTour();
        }

        public void PlaneLand (List<Plane> listofplanes)
        {
            foreach (var item in listofplanes)
            {
                if (item.FuelLeft < 3 && item.isCrashed==false && !(item.landed==true))
                {
                    bool island = IsTrackFree(item.StartFuel - item.FuelLeft);
                    if (island)
                    {
                       item.landed = true;
                    }
                }
            }
        }

        public bool IsTrackFree(int fuel)
        {
            bool result = false;
            for (int j = 0; j < listoftracks.Count; j++)
            {
                
                if (listoftracks[j].howLongIsBusy == 0)
                {
                    listoftracks[j].howLongIsBusy = fuel;
                    j = listoftracks.Count - 1; //This is ending for loop
                    result = true;

                }
            }
            return result;
        }

        public void TrackOccupied()
        {
            for (int j = 0; j < listoftracks.Count; j++)
            {
                if (listoftracks[j].howLongIsBusy != 0)
                {
                    listoftracks[j].howLongIsBusy -= 1;
                }
            }
        }

    }
}
