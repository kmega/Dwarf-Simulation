using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamolotyWziuum
{
    public class Plane
    {
        
        public int planeNumber { get; set; }
        public Plane(int number)
        {
            planeNumber = number;
        }

        public void TryLand(ControlTower ct)
        {
            if (ct.CheckForFreeLandingRunWay() != 0)
            {
                Landing(ct, ct.CheckForFreeLandingRunWay());
            } else
            {
                Console.WriteLine("All runways are taken");
            }
        }

        public void Landing(ControlTower ct, int runwayNumber)
        {
            ct.allRunWays[runwayNumber].available = false;
        }
    }
}
