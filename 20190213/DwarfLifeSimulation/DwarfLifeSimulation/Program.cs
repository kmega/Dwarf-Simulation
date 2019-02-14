using DwarfLifeSimulation.ApplicationLogic;
using System;

namespace DwarfLifeSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var simulationEngine = new SimulationEngine();
            simulationEngine.Start();
        }
    }
}
