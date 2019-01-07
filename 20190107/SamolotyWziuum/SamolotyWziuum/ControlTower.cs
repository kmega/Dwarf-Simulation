using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamolotyWziuum
{
    public class ControlTower
    {
        public List<RunWay> allRunWays = new List<RunWay>()
        {new RunWay(1), new RunWay(2), new RunWay(3), new RunWay(4), new RunWay(5),
            new RunWay(6), new RunWay(7), new RunWay(8), new RunWay(9), new RunWay(10)};
        
        public int CheckForFreeLandingRunWay()
        {
            int isAvailable = 0;
            foreach(var i in this.allRunWays)
            {
                if (i.available)
                {
                    isAvailable = i.numberRunWay;
                    break;
                }
            }
            return isAvailable;
        }
    }
}
