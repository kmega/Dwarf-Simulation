using System;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("DwarfSimulationTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace DwarfSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulation simulation = new Simulation();
            simulation.Start();

            Console.ReadKey();
        }
    }
}
