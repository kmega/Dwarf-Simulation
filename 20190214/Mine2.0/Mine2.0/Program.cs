using System;

namespace Mine2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var r1 = new DwarfTypeRandomizer();
            var r2 = new DwarthIsBrithRandomizer();
            var r3 = new MineRandomizer();
            var r4 = new ValueRandomizer();
            var console = new WindowsConsole();

            var simulation = new SimulationEngine(30, r1, r2, r3, r4, console);
            simulation.Start();

            Console.ReadKey();
        }
    }
}
