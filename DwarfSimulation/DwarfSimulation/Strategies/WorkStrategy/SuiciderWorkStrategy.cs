using System;

namespace DwarfSimulation
{
    internal class SuiciderWorkStrategy : IWork
    {
        public Shaft Work(Shaft shaft, Raport raport)
        {
            Dwarf dwarf;

            for (int index = 0; index < shaft.MaxInside; index++)
            {
                dwarf = shaft.Miners[index];
                dwarf.IsAlive = false;
            }

            shaft.Collapsed = true;

            Console.WriteLine("Dwarf " + DwarfType.Suicider + " collapsed shaft and killed:\n");

            foreach (var miner in shaft.Miners)
            {
                if (miner.DwarfType != DwarfType.Suicider)
                {
                    Console.WriteLine("Dwarf " + miner.DwarfType);
                }
            }

            return shaft;
        }
    }
}
