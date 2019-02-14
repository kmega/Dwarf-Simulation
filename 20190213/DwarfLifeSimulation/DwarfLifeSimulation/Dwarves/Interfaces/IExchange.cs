using DwarfLifeSimulation.Enums;
using System.Collections.Generic;

namespace DwarfLifeSimulation.Dwarves.Interfaces
{
    public interface IExchange
    {
        Dictionary<MineralType, int> EmptyBackpackContent();
        void GetMoney(decimal dailyIncome);
    }
}
