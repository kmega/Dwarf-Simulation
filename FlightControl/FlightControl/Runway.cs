using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightControl
{
    class Runway
    {
        public bool IsFree { get; set; }

        public Runway(bool isFree)
        {
            IsFree = isFree;
        }

        public static bool CheckRunwayAreFree(List<Runway> runways)
        {
            return runways.Any(s => s.IsFree == true);
        }

        public static void LockRunway(List<Runway> runways)
        {
            runways.Where(s => s.IsFree == true).First().IsFree = false;
        }

        public static void ReleaseRunway(List<Runway> runways)
        {
            runways.Where(s => s.IsFree == false).First().IsFree = true;
        }
    }
}
