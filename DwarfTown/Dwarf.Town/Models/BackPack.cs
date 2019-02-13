using Dwarf.Town.Enums;
using System.Collections.Generic;

namespace Dwarf.Town.Models
{
    public class BackPack
    {

        private List<MineralType> _backpack;

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