using System;
using System.Collections.Generic;

namespace HappyPlanes
{
    public class FlightTower
    {
        public bool PermissionToLanding { get; set; }
        public int FreeSpaces { get; set;}
        public List<LandBelts> FreeLandBelts { get; set; } = new List<LandBelts>();
        public List<LandBelts> OccupiedLandBelts { get; set; } = new List<LandBelts>();

        public FlightTower()
        {
            PermissionToLanding = false;
            FreeSpaces = 10;
        }

        public LandBelts GiveFreeLandBelt()
        {
            OccupiedLandBelts.Add(FreeLandBelts[0]);
            FreeLandBelts.Remove(FreeLandBelts[0]);

            return OccupiedLandBelts[0];
        }

        public bool GivePermissionToLanding(LandBelts landBelts)
        {
            if(FreeSpaces > 0)
            {
                Console.WriteLine($"Możesz podejść do lądowania\nPrzydzielam Ci pas {landBelts.Name}");
                return true;
            }

            return false;
            


        }
    }
}