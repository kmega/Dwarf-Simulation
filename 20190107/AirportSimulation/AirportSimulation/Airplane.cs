using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulation
{
    public class Airplane
    {
        public int Id { get; set; }
        public int AmountOfFuel { get; set; }
        public int FuelAtStart { get; set;  }
        public int[] CoordinatesToLand { get; set; }
    }
}
