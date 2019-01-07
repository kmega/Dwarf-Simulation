using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySimulator
{
    public class FlightTower
    {
        public List<Runway> runways;

        public List<AirPlane> airPlanes;

        public FlightTower()
        {
            runways = new List<Runway>();

            airPlanes = new List<AirPlane>();

            for (int i = 0; i < 10; i++)
            {
                runways.Add(new Runway());
            }

            for (int i = 0; i < 50; i++)
            {
                airPlanes.Add(new AirPlane());
            }
        }


        public void TakeThePlane(AirPlane plane)
        {
            if (plane.OnEarth)
            {
                Console.WriteLine("Samolot jest na ziemi");
            }
            else
            if (runways.Find(r => r.IsEmpty == true) != null)
            {
                var freeRunway = runways.Find(r => r.IsEmpty == true);
                if (freeRunway.IsEmpty)
                {
                    plane.OnEarth = true;
                    freeRunway.IsEmpty = false;
                }
            }
            else
                Console.WriteLine("Brak wolnych pasów");


        }

        public void MakeRunwayFree(AirPlane plane)
        {
            if (plane.OnEarth == false)
            {
                Console.WriteLine("Samolot znajduje się w powietrzu");
            }
            else if (runways.Find(r => r.IsEmpty == false) != null)
            {
                var freeRunway = runways.Find(r => r.IsEmpty == false);
                if (freeRunway.IsEmpty == false)
                {
                    plane.OnEarth = false;
                    freeRunway.IsEmpty = true;
                    
                }
            }
        }

        public bool AreEmptyRunways()
        {
            bool result = false;

            if (runways.Find(r => r.IsEmpty == true) != null)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
       
        }

    }
}
