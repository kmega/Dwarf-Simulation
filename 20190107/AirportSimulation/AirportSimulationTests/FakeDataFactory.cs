using AirportSimulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulationTests
{
    internal static class FakeDataFactory
    {
        internal static AirportTrafficControlTower GenerateAirport()
        {
            var runway = new Runway()
            {
                Id = 1,
                Coordinates = new int[] { 777, 4, 6 },
                TimeOfOccupation = 5
            };
            var runway2 = new Runway()
            {
                Id = 2,
                Coordinates = new int[] { 21, 4, 6 },
                TimeOfOccupation = 5
            };
            //var runway3 = new Runway()
            //{
            //    Id = 3,
            //    Coordinates = new int[] { 751, 4, 6 },
            //    TimeOfOccupation = 5
            //};
            var queue = new Queue<Runway>();
            queue.Enqueue(runway);
            queue.Enqueue(runway2);
            //queue.Enqueue(runway3);
            var airport = new AirportTrafficControlTower(queue);
                
            return airport;
        }
        internal static List<Airplane> CreatePlanes()
        {
            var airplanes = new List<Airplane>()
            {
                new Airplane(){ Id = 1, AmountOfFuel = 20 },
                new Airplane(){ Id = 2, AmountOfFuel = 20 },
                new Airplane(){ Id = 3, AmountOfFuel = 20 },
                new Airplane(){ Id = 4, AmountOfFuel = 20 },
                new Airplane(){ Id = 5, AmountOfFuel = 20 },
                new Airplane(){ Id = 6, AmountOfFuel = 10 },
                new Airplane(){ Id = 7, AmountOfFuel = 10 },

            };
            return airplanes;
        }

    }
}
