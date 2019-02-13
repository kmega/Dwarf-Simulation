using Dwarf_Town.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf_Town.Interfaces.SellingStrategy
{
    public interface ISellingStrategy
    {

        void ReceivedMoney(decimal payment);
        List<MineralType> ShowBackpack();
    }
}
