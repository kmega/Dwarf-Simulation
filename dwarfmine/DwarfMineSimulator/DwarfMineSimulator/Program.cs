using System;
using DwarfMineSimulator.Simulation;

namespace DwarfMineSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            SimulationDirector simulation = 
                new SimulationDirector(new CorealateSimulation());
        }
    }
}
