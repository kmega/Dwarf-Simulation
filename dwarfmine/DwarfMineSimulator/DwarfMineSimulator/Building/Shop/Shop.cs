using System;
using System.Collections.Generic;
using System.Linq;
using DwarfMineSimulator.Dwarfs;

namespace DwarfMineSimulator.Building.Shop
{
    internal class Shop
    {
        List<Dwarf> DwarfsInShop;

        public Shop(List<Dwarf> dwarfsInShop)
        {
            DwarfsInShop = dwarfsInShop;
        }
    }
}
