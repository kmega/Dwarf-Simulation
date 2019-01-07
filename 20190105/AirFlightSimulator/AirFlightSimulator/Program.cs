using System;
using System.Collections.Generic;

namespace AirFlightSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Planes> PlanesAwaitingForLanding = new List<Planes>
            {
                new Planes(1, 200),
                new Planes(2, 100)
            };

            ControlTower controlTower = new ControlTower();

            controlTower.TryGetLandigPermission(PlanesAwaitingForLanding[0]);
            controlTower.TryGetLandigPermission(PlanesAwaitingForLanding[1]);


            Console.ReadKey();
        }
    }

}



