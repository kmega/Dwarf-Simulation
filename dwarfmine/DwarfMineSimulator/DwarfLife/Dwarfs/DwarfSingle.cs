using System;
using System.Collections.Generic;
using DwarfLife.Enums;
using DwarfLife.Diaries;

namespace DwarfLife.Dwarfs
{
    public class DwarfSingle : Dwarf, IDwarf
    {
        public new DwarfTypes DwarfType { get; }

        public DwarfSingle(int id) : base(1)
        {
            DwarfType = DwarfTypes.Single;
            Alive = true;
            DiaryHelper.Log(DiaryTarget.Console, String.Format(
                "Dwarf has born. His id = {0}, and his type is: {1}",
                Id, DwarfType));
        }
    }
}
