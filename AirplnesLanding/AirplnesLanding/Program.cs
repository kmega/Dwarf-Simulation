using System;
using System.Collections.Generic;

namespace HappyPlanes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Buduj Listę samolotów -> List<Airplane>
            Factory Factory = new Factory();
            List<AirPlane> Planes = Factory.MakeAirplanes(50);

            //Buduj Listę pasów -> List<LandBelt>
            List<LandBelts> Belts = Factory.MakeLandBelts(10);

            Belts.Add(new LandBelts("Land1"));

            //Pytaj wieży czy możesz wylądować
            FlightTower Tower = new FlightTower();
            Tower.FreeLandBelts.Add(Belts[0]);

            Console.ReadKey();                      

        }
    }
}
