using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightControl
{
    class Plane
    {
        public int AmountOfFuel { get; set; }
        public bool InFlight { get; set; }

        public Plane(int amountOfFuel, bool inFlight)
        {
            amountOfFuel = AmountOfFuel;
            inFlight = InFlight;
        }
    }
}
