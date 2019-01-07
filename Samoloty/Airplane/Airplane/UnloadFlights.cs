using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplane
{
    class UnloadFlights
    {
        int tour = 1000;
        //In free time one must add parametrs, because i wanted testing this method
        public string FlightControlTryUnloadFlightsIn1000Tour()
        {
            string content = "";
            ListPlanes planes = new ListPlanes();
            ListTourInAirplane tourInAirplane = new ListTourInAirplane();
            var howMucPlanes = planes.InformationPlanes();
            var ifTheyAreWoreTracks = tourInAirplane.InformationTour();

            content = "Tak";
            // HowMuchTour
            for (int i = 0; i < tour - 1; i++)
            {
                //HowMuchTracks
                for (int j = 0; j < ifTheyAreWoreTracks.Count; j++)
                {
                    //IfTrackIsFree
                    if (ifTheyAreWoreTracks[j].howLongIsBusy == 0)
                    {
                        ifTheyAreWoreTracks[j].howLongIsBusy = 5;
                        j = ifTheyAreWoreTracks.Count - 1;

                        //DidLanded = true
                        for (int m = 0; m < howMucPlanes.Count; m++)
                        {
                            if (howMucPlanes[m].landed == false)
                            {
                                howMucPlanes[m].landed = true;
                                m = howMucPlanes.Count();
                            }
                        }
                    }
                }

                //How long the tracks will be occupied
                for (int j = 0; j < ifTheyAreWoreTracks.Count; j++)
                {
                    if (ifTheyAreWoreTracks[j].howLongIsBusy != 0)
                    {
                        ifTheyAreWoreTracks[j].howLongIsBusy -= 1;
                    }
                }

                //decreaseFuel
                for (int j = 0; j < howMucPlanes.Count; j++)
                {
                    howMucPlanes[j].HowMuchFuel -= 1;
                }

                //CheckFuel
                for (int j = 0; j < howMucPlanes.Count; j++)
                {

                    if (howMucPlanes[j].HowMuchFuel == 0)
                    {
                        //throw new System.ArgumentException("Doszło do tragedii! Źle rozplanowałeś lądowania", "Wypadek");
                        content = "Część samolotów zgineła w: " + i;
                        //i = tour;
                    }                   
                }
            }           
            return content;
        }
    }
}
