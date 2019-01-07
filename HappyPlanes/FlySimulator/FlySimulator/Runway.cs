using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySimulator
{
    public class Runway
    {
        public int RunwayNumber { get; set; } = 0;

        public bool IsEmpty { get; set; }

        public int TimePlaneOnRunway { get; set; }



        public Runway()
        {
            RunwayNumber = _planeNumber++;
            IsEmpty = true;
            TimePlaneOnRunway = 0;
        }

        public static int _planeNumber = 1;

    }
}
