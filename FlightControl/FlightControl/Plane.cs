using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightControl
{
    public class Plane
    {
        public int AmountOfFuel { get; set; }
        public bool InFlight { get; set; }
        public int OnGroundTime { get; set; }

        public Plane(int amountOfFuel, bool inFlight, int onGroundTime)
        {
            AmountOfFuel = amountOfFuel;
            InFlight = inFlight;
            OnGroundTime = onGroundTime;
        }

        public static void StopAtAirport(Plane plane)
        {
            plane.InFlight = false;
            plane.AmountOfFuel -= 1;
        }

        public static List<Plane> FindPlanesOnGround(List<Plane> planes)
        {
            return planes.Where(s => s.InFlight == false).ToList();
        }

        public static void StartFromAirport(Plane plane)
        {
            plane.InFlight = true;
            plane.OnGroundTime = 0;
        }

        public static Plane FindFirstInFlight(List<Plane> planes)
        {
            return planes.Where(s => s.InFlight == true).First();
        }
    }
}
