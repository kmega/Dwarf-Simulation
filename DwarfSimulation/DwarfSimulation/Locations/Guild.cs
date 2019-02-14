using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfSimulation
{
    internal class Guild
    {
             
        

        internal void clearBackpacks(List<Dwarf> listOfDwarves)
        {
            foreach (var dwarf in listOfDwarves)
            {
                clearBackpack(dwarf);
            }
        }

        internal void clearBackpack(Dwarf dwarf)
        {
            dwarf.BackPack[Mineral.Mithril] = 0;
            dwarf.BackPack[Mineral.Gold] = 0;
            dwarf.BackPack[Mineral.Silver] = 0;
            dwarf.BackPack[Mineral.TaintedGold] = 0;
        }
    }
}
