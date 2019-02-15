﻿using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf_Town.Locations.Mine
{
    public static class GiveSpecificOre 
    {

        public static MineralType GetTheOre(int chanceForMineral)
        {

            if (chanceForMineral <= 5)
            {
                return MineralType.Mithril;
            }
            else if (chanceForMineral <= 20)
            {
                return MineralType.Gold;
            }
            else if (chanceForMineral <= 55)
            {
                return MineralType.Silver;
            }
            else
            {
                return MineralType.DirtyGold;
            }

        }
       
    }
}