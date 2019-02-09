using System;
using System.Collections.Generic;
using DwarfLife.Enums;
using DwarfLife.Diaries;

namespace DwarfLife.Dwarfs
{
    public class DwarfSaboteur : IDwarf
    {
        readonly DwarfTypes _dwarfType;
        readonly int _id;

        public DwarfTypes DwarfType { get { return _dwarfType; } }
        public bool Alive { get; set; }

        public DwarfSaboteur(int id)
        {
            _id = id;
            _dwarfType = DwarfTypes.Saboteur;
            Alive = true;
            DiaryHelper.Log(DiaryTarget.Console, String.Format(
                "Dwarf has born. His id = {0}, and his type is: {1}",
                _id, _dwarfType));
        }

        public void Eat() { }
        public void Buy(ItemsInShop item) { }
    }
}
