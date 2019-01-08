using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulation
{
    public class Runway
    {
        public int Id { get; set; }
        public short TimeOfOccupation { get; set; }
        public int[] Coordinates { get; set; }
    }
}
