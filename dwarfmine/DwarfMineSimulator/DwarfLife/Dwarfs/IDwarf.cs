using System;
using System.Collections.Generic;
using DwarfLife.Enums;

namespace DwarfLife.Dwarfs
{
    public interface IDwarf
    {
        DwarfTypes DwarfType { get; }
        bool Alive { get; set; }

        void Eat();
        void Dig();
        void Buy(ItemsInShop item);
    }
}
