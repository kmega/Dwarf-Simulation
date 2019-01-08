using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightControl
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightControlTower flightControlTower = new FlightControlTower();
            List<Plane> planes = new List<Plane>();
            for (int i = 0; i < 50; i++)
            {
                planes.Add(new Plane(200, true, 0));
            }
            List<Runway> runways = new List<Runway>();
            for (int i = 0; i < 20; i++)
            {
                runways.Add(new Runway(true));
            }
            flightControlTower.TrafficControl(planes, runways);

            Console.ReadKey();

            //Samoloty l¹duj¹ i odlatuj¹, czy wracaj¹ te same czy nie?
        }
    }
}
