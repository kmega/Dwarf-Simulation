using System;
using System.Collections.Generic;
using System.Text;

namespace Mine
{
    public interface IDwarf
    {
        IWork Work { get; }
        List<Ore> Backpack { get; }
        IBankAccount BankAccount { get; }
        DwarfType Type { get; }

        void AddOresToBackPack(List<Ore> ores);
        void AddOreToBackPack(Ore ores);
    }



}

   
