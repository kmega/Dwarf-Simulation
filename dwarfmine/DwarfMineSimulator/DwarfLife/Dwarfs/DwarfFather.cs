using System;
using System.Collections.Generic;
using DwarfLife.Enums;
using DwarfLife.Diaries;
using DwarfLife.Buildings.Shop;

namespace DwarfLife.Dwarfs
{
    public class DwarfFather : Dwarf, IDwarf
    {
        public new DwarfTypes DwarfType { get; }

        public DwarfFather(int id, Places whereAmI = Places.None) : base(id, whereAmI)
        {
            DwarfType = DwarfTypes.Father;
            Alive = true;
            DiaryHelper.Log(DiaryTarget.Console, String.Format(
                "Dwarf has born. His id = {0}, and his type is: {1}",
                Id, DwarfType));
        }
    }
}
