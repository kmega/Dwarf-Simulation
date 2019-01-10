using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplane
{
    public class Plane
    {
        public int StartFuel { get; set; }
        public int FuelLeft { get; set; }
        public bool landed = false;
        public bool isCrashed = false;

        public Plane(int fuel)
        {
            StartFuel = fuel;
            FuelLeft = fuel;
        }
    }
}
