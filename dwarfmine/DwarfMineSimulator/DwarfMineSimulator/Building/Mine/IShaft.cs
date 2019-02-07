using System;
using DwarfMineSimulator.Dwarfs;

namespace DwarfMineSimulator.Building.Mine
{
    internal interface IShaft
    {
        void SetMaxNumberOfDwarfsInShaft(int maxNumber);
        bool IsFullOfDwarfes();
        //void DwarfGoIntoShaft(Dwarf worker);
        void DwarfGoIntoShaftQueue(Dwarf worker);
        string ShaftName();
        bool IsCollapsed();
    }
}
