using Dwarf_Town.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf_Town.Locations.Mine
{
    public interface IBroughtOutOreChance
    {
         MineralType GetTheOre(int chanceForMineral);
    }
}
