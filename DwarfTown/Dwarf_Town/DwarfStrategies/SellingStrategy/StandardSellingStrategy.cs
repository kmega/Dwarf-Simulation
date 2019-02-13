using System;
using System.Collections.Generic;
using System.Text;
using Dwarf_Town.Enums;
using Dwarf_Town.Models;

namespace Dwarf_Town.Interfaces.SellingStrategy
{
    public class StandardSellingStrategy : ISell
    {
        private Backpack _backpack;
        private Wallet _wallet;

        public StandardSellingStrategy (Backpack backpack, Wallet wallet)
        {
            _backpack = backpack;
            _wallet = wallet;
        }

        public void ReceivedMoney(decimal payment)
        {
            _wallet.DailyCash += payment;
        }

        public List<MineralType> ShowBackpack()
        {
            return _backpack.ShowBackpack();
        }
    }
}
