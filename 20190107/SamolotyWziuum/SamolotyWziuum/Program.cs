using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamolotyWziuum
{
    class Program
    {
        static void Main(string[] args)
        {
            AirPort ap = new AirPort();
            ap.CreateAirPlanes();
            ap.RefreshAirPlanesStatus();


            foreach (var i in ap.listOfAllPlanes)
            {
                Console.WriteLine($"Plane number: {i.planeNumber+1} is in the air: {i.planeInAir}");
            }

            foreach (var i in ap.listOfPlanesInTheAir)
            {
                Console.WriteLine($"Plane number: {i.planeNumber + 1} is in the air: {i.planeInAir}");
            }

            Console.ReadLine();
        }
    }
}
