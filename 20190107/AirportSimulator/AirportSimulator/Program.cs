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
            SimulationReport content = new AirportSimulation().Simulate(5);
            Console.WriteLine($"Ca�kowita liczba iteracji: {content.TotalIterations}, a {content.CrashedPlanes} samoloty/�w spad�o!");
            Console.ReadKey();
        }
    }
}
