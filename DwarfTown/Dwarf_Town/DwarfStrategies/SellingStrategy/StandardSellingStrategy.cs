using System;
using System.Collections.Generic;
using System.Text;
using Dwarf_Town.Enums;

namespace Dwarf_Town.Interfaces.SellingStrategy
{
    public class StandardSellingStrategy : ISellingStrategy
    {
        public void ReceivedMoney(decimal payment)
        {
            throw new NotImplementedException();
        }

        public List<MineralType> ShowBackpack()
        {
            throw new NotImplementedException();
        }
    }
}
