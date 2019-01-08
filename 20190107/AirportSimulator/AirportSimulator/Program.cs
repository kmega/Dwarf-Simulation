using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Plain> listofplain = new List<Plain>();
            SimulationReport content = new AirportSimulation().Simulate(listofplain, 5);
            Console.WriteLine($"Ca³kowita liczba iteracji: {content.TotalIterations}, a {content.CrashedPlanes} samoloty/ów spad³o!");
            Console.ReadKey();
        }
    }
}
