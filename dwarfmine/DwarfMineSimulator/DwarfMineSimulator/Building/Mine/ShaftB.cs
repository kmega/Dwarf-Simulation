using System;
using System.Collections.Generic;
using DwarfMineSimulator.Dwarfs;

namespace DwarfMineSimulator.Building.Mine
{
    internal class ShaftB : IShaft
    {
        string name = "ShaftB";
        List<Dwarf> DwarfsInShaft;
        List<Dwarf> ShaftQueue;
        bool Collapsed;
        int MaxDwarfsInShaft;

        public ShaftB()
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

        public string ShaftName()
        {
            return name;
        }

        public bool IsCollapsed()
        {
            return Collapsed;
        }
    }
}
