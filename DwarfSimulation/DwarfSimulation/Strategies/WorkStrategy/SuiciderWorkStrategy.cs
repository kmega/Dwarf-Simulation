using System;

namespace DwarfSimulation
{
    internal class SuiciderWorkStrategy : IWork
    {
        public Shaft Work(Shaft shaft, Raport raport)
        {
            Dwarf miner;

            for (int index = 0; index < shaft.MaxInside; index++)
            {
                try
                {

                    miner = shaft.Miners[index];
                    miner.IsAlive = false;

                    if (miner.DwarfType == DwarfType.Suicider)
                    {
                        Console.WriteLine("Dwarf " + miner.ID + " - " + DwarfType.Suicider + " collapsed shaft and killed:\n");
                    }
                }
                catch
                {
                    break;
                }
            }

            shaft.Collapsed = true;

            foreach (var dwarf in shaft.Miners)
            {
                if (dwarf.DwarfType != DwarfType.Suicider)
                {
                    Console.WriteLine("Dwarf " + dwarf.ID + " - " + dwarf.DwarfType);
                }
            }

            return shaft;
        }
    }
}
