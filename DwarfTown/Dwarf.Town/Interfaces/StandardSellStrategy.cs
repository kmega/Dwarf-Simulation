using System;
using System.Collections.Generic;
using System.Text;
using Dwarf.Town.Enums;
using Dwarf.Town.Models;

namespace Dwarf.Town.Interfaces
{
    public class StandardSellStrategy : ISell
    {
        private Dwarf _dwarf;

        public StandardSellStrategy (Dwarf dwarf)
        {
            _dwarf = dwarf;

        }

        public void ReceivedMoney(decimal payment)
        {
           _
        }

        public List<MineralType> ShowBackpack()
        {
            return _dwarf.BackPack.ShowBackpack();
        }
    }
}
