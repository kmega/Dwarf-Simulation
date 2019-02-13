using System;

namespace DwarfsTown
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulation.Run(Configurator.PrepareCityToSimulation());
        }
    }
}
