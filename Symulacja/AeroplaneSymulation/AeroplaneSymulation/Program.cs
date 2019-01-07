using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroplaneSymulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Planes create_plane = new Planes();
            List<int> planes = planes = create_plane.plane_creator(2);

            Airport airport = new Airport();
            List<bool> airports_places = airport.Airport_Places(2);

            foreach (var item in airports_places)
            {
                Console.WriteLine(item);
            }

            foreach (var item in planes)
            {
                Console.WriteLine(item);
            }

            Simulation simulation = new Simulation();
            Console.WriteLine(simulation.simulate(planes, airports_places, 10));
            Console.ReadKey();
        }
    }
}
