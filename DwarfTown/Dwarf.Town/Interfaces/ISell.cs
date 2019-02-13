using Dwarf.Town.Enums;
using Dwarf.Town.Models;
using System.Collections.Generic;

namespace Dwarf.Town.Interfaces
{
    public interface ISell
    {
        List<MineralType> ShowBackpack();
        void ReceivedMoney(decimal payment);
    }
}