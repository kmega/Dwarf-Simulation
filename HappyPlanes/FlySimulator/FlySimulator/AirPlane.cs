using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySimulator
{
    public  class AirPlane
    {
        public int PlaneNumber { get; set; } = 0;

        public int Fuel { get; set; }

        public bool OnEarth { get; set; }

        public AirPlane()
        {

            PlaneNumber = _planeNumber++;
            Fuel = 200;
            OnEarth = false;
        }

        public static int _planeNumber = 1;
        
    }
}
