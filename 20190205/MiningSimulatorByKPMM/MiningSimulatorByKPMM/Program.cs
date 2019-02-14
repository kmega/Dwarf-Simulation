using MiningSimulatorByKPMM.ApplicationLogic;
using System;

namespace MiningSimulatorByKPMM
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Start App");
            SimulationEngine se = new SimulationEngine();
            se.Start();

            Console.ReadKey();
        }
    }
}