using System;
using System.Collections.Generic;
using DwarfLife.Enums;

namespace DwarfLife.Dwarfs
{
    public interface IDwarf
    {
        bool Alive { get; set; }

        void Eat();
        void Buy(ItemsInShop item);
        DwarfTypes DwarfType();
    }
}
