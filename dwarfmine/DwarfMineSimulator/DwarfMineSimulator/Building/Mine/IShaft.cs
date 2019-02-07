using System;
using System.Collections.Generic;
using DwarfMineSimulator.Dwarfs;

namespace DwarfMineSimulator.Building.Mine
{
    internal interface IShaft
    {
        void SetMaxNumberOfDwarfsInShaft(int maxNumber);
        bool IsFullOfDwarfes();
        void DwarfGoIntoShaftQueue(Dwarf worker);
        void BeginShift();
        string ShaftName();
        bool IsCollapsed();
    }
}
