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

        public Runway(bool areOccupied)
        {
            IsOccupied = areOccupied;
        }

        public static bool CheckIsOccupied(List<Runway> runways)
        {
            var result = runways.Any(s => s.IsOccupied == true);
            return result;
        }
    }
}
