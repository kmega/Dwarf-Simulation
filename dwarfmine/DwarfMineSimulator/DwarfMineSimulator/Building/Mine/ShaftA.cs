using System;
using System.Collections.Generic;
using DwarfMineSimulator.Dwarfs;

namespace DwarfMineSimulator.Building.Mine
{
    internal class ShaftA : IShaft
    {
        List<Dwarf> DwarfsInShaft;
        bool Collapsed;
        int MaxDwarfsInShaft;

        public ShaftA()
        {
            DwarfsInShaft = new List<Dwarf>();
            Collapsed = false;
            SetMaxNumberOfDwarfsInShaft(5);
        }

        public void SetMaxNumberOfDwarfsInShaft(int maxNumber = 5)
        {
            MaxDwarfsInShaft = maxNumber;
        }

        public bool IsFullOfDwarfes()
        {
            return DwarfsInShaft.Count > MaxDwarfsInShaft ? true : false;
        }

        public void DwarfGoIntoShaft(Dwarf worker)
        {
            DwarfsInShaft.Add(worker);
        }
    }
}
