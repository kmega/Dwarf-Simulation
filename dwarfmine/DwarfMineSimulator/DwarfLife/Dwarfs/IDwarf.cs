using System;
using System.Collections.Generic;
using DwarfLife.Buildings.Mine;
using DwarfLife.Enums;

namespace DwarfLife.Dwarfs
{
    public interface IDwarf
    {
        DwarfTypes DwarfType { get; }
        bool Alive { get; set; }
        Dictionary<Minerals, int> MinedMinerals { get; }
        Places WhereAmI { get; set; }

        void Eat();
        void Dig(Shaft shaft, int hits = 0);
        void Buy(ItemsInShop item);
    }
}
