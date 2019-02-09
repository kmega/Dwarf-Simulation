using System;
using System.Collections.Generic;
using DwarfLife.Enums;

namespace DwarfLife.Dwarfs
{
    internal class DwarfSluggard : IDwarf
    {
        readonly DwarfTypes _dwarfType;
        readonly int _id;

        public bool IsAlive { get; set; }

        public DwarfSluggard(int id)
        {
            _id = id;
            _dwarfType = DwarfTypes.Sluggard;
            IsAlive = true;
        }

        public DwarfTypes DwarfType() { return _dwarfType; }

        public void Eat() { }
        public void Buy(ItemsInShop item) { }
    }
}
