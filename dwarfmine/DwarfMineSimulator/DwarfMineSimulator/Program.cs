using System;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("DwarfMineSimulatorTests")]

namespace DwarfMineSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulation simulation = new Simulation();

            simulation.Simulate();

            Console.ReadKey();
        }
    }
}
