using Dwarf_Town.Enums;
using Dwarf_Town.Models;
using System.Collections.Generic;

namespace Dwarf_Town.Interfaces
{
    public interface ISell
    {
        List<MineralType> ShowBackpack();
        void ReceivedMoney(decimal payment);

    }
}