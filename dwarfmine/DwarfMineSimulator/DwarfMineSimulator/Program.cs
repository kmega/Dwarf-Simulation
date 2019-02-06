using System;

namespace DwarfMineSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulation simulation = new Simulation();
            simulation.SetDaysToEnd(30);
            simulation.Execute();
        }
    }
}
