using System;
using System.Collections.Generic;
using DwarfLife.Enums;

namespace DwarfLife.Dwarfs
{
    public class DwarfSaboteur : IDwarf
    {
        readonly DwarfTypes _dwarfType;
        readonly int _id;
        readonly bool _alive;

        public bool IsAlive { get; set; }

        public DwarfSaboteur(int id)
        {
            _id = id;
            _dwarfType = DwarfTypes.Saboteur;
            IsAlive = true;
        }

        public DwarfTypes DwarfType() { return _dwarfType; }

        public void Eat() { }
        public void Buy(ItemsInShop item) { }
    }
}
