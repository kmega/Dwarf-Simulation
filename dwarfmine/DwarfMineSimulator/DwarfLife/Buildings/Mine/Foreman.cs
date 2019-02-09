using System;
using System.Collections.Generic;
using DwarfLife.Dwarfs;

namespace DwarfLife.Buildings.Mine
{
    public class Foreman
    {
        public void SendDwarfsToRandomShaft(Mine mine, List<IDwarf> dwarfs)
        {
            dwarfs.ForEach(dwarf =>
            {
                Shaft shaft = WhichShaft(mine);
                if (!shaft.IsShaftFull())
                    shaft.DwarfsInShaft.Add(dwarf);
            });
        }

        public void SendDwarfsToShaft(Shaft shaft, List<IDwarf> dwarfs)
        {
            dwarfs.ForEach(dwarf =>
            {
                if (!shaft.IsShaftFull())
                    shaft.DwarfsInShaft.Add(dwarf);
            });
        }

        public Shaft WhichShaft(Mine mine)
        {
            return mine.Shafts[new Random().Next(0, mine.Shafts.Count)];
        }
    }
}
