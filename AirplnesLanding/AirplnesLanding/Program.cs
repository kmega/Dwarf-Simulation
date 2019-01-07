using System;
using System.Collections.Generic;

namespace HappyPlanes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Buduj Listę samolotów -> List<Airplane>
            List<AirPlane> Planes = new List<AirPlane>();

            Planes.Add(new AirPlane("Airplane1"));

            //for (int i = 0; i < 50; i++)
            //{
            //    Airplanes.Add(new Airplane());
            //}

            //Buduj Listę pasów -> List<LandBelt>
            List<LandBelts> Belts = new List<LandBelts>();

            Belts.Add(new LandBelts("Land1"));

            //Pytaj wieży czy możesz wylądować
            FlightTower Tower = new FlightTower();
            Tower.FreeLandBelts.Add(Belts[0]);

            Planes[0].PermissionLandingAsk();

            if (Tower.FreeSpaces > 0)
            {
                Planes[0].LandBelt = Tower.GiveFreeLandBelt();
                Planes[0].PermissionToLanding = Tower.GivePermissionToLanding(Belts[0]);
                Planes[0].LandingSucces = true;
            }
            Console.ReadKey();                      

        }
    }
}
