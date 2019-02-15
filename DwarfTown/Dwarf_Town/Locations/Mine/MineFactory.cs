using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf_Town.Locations.Mine
{
    public static class MineFactory
    {

        public static Mine CreateStandardMine(IOutputWriter presenter)
        {
            Mine mine = new Mine(2, new Dictionary<MineralType, int>()
            {
                {MineralType.DirtyGold,0 },
                {MineralType.Gold,0 },
                {MineralType.Silver,0 },
                {MineralType.Mithril,0 } },
            presenter);
            return mine;
        }
    }
}
