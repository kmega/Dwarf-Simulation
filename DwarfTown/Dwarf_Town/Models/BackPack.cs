using Dwarf_Town.Enums;
using System.Collections.Generic;

namespace Dwarf_Town.Models
{
    public class BackPack
    {

        private List<MineralType> _backpack = new List<MineralType>();

        public void AddOre (MineralType mineral)
        {
            _backpack.Add(mineral);
        }

        public List<MineralType> ShowBackpack()
        {
            return _backpack;
        }
    }
}