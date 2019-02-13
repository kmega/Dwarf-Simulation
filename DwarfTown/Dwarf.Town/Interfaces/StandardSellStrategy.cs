using System;
using System.Collections.Generic;
using System.Text;
using Dwarf_Town.Enums;
using Dwarf_Town.Models;

namespace Dwarf_Town.Interfaces
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
           
        }

        public List<MineralType> ShowBackpack()
        {
            return _dwarf.BackPack.ShowBackpack();
        }
    }
}
