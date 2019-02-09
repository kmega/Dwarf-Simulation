﻿using System;
using System.Collections.Generic;
using DwarfLife.Enums;
using DwarfLife.Diaries;

namespace DwarfLife.Dwarfs
{
    public class DwarfFather : IDwarf
    {
        readonly DwarfTypes _dwarfType;
        readonly int _id;

        public bool Alive { get; set; }

        public DwarfFather(int id)
        {
            _id = id;
            _dwarfType = DwarfTypes.Father;
            Alive = true;
            DiaryHelper.Log(DiaryTarget.Console, String.Format(
                "Dwarf has born. His id = {0}, and his type is: {1}",
                _id, _dwarfType));
        }

        public DwarfTypes DwarfType() { return _dwarfType; }

        public void Eat() { }
        public void Buy(ItemsInShop item) { }
    }
}
