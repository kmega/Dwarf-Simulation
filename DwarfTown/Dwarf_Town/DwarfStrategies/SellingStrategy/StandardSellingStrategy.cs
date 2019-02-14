using System;
using System.Collections.Generic;
using System.Text;
using Dwarf_Town.Enums;
using Dwarf_Town.Models;

namespace Dwarf_Town.Interfaces.SellingStrategy
{
    public class StandardSellingStrategy : ISell
    {
        private Dwarf _dwarf;

        public StandardSellingStrategy (Dwarf dwarf)
        {
            _dwarf = dwarf;
        }

        public void ReceivedMoney(decimal payment )
        {
            _dwarf.Wallet.DailyCash += payment;
        }

        public List<MineralType> ShowBackpack()
        {
            return _dwarf.Backpack.ShowBackpack();
        }
    }
}
