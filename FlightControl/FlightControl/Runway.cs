using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightControl
{
    class Runway
    {
        public bool IsOccupied { get; set; }
        public static bool CheckIsOccupied { get; internal set; }

        public Runway(bool areOccupied)
        {
            IsOccupied = areOccupied;
        }
    }
}
