using System;
using System.Collections.Generic;
using DwarfLife.Enums;

namespace DwarfLife.Dwarfs
{
    public interface IDwarf
    {
        bool IsAlive { get; set; }

        void Eat();
        void Buy(ItemsInShop item);
        DwarfTypes DwarfType();
    }
}
