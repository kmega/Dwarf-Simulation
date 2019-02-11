using System;
using System.Collections.Generic;
using DwarfLife.Enums;
using DwarfLife.Buildings.Mine;
using DwarfLife.Diaries;

namespace DwarfLife.Dwarfs
{
    public class DwarfSaboteur : Dwarf, IDwarf
    {
        public new DwarfTypes DwarfType { get; }

        public DwarfSaboteur(int id, Places whereAmI = Places.None) : base(id, whereAmI)
        {
            DwarfType = DwarfTypes.Saboteur;
            Alive = true;
            HasWorkedToday = false;
            DiaryHelper.Log(Constans.diaryTarget, string.Format(
                "Dwarf has born. His id = {0}, and his type is: {1}",
                Id, DwarfType));
        }
    }
}
