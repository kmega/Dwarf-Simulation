using System;

namespace ThorinsCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Dwarfs!");
            Config config = new SimulationConfigurator().getConfig();
            new Simulation(config).PerformSimulation();
        }
    }
}
