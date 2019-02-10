using System;
using DwarfLife.Enums;
using DwarfLife.Diaries;

namespace DwarfLife.Dwarfs
{
    public class DwarfSluggard : Dwarf, IDwarf
    {
        public new DwarfTypes DwarfType { get; }

        public DwarfSluggard(int id, Places whereAmI = Places.None) : base(id)
        {
            DwarfType = DwarfTypes.Sluggard;
            Alive = true;
            DiaryHelper.Log(DiaryTarget.Console, String.Format(
                "Dwarf has born. His id = {0}, and his type is: {1}",
                Id, DwarfType));
        }
    }
}
