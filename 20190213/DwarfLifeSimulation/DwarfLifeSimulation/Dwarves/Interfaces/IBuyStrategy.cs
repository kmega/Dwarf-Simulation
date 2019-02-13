using DwarfLifeSimulation.Locations.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Dwarves.Interfaces
{
    interface IBuyStrategy
    {
        Product Buy(int customerAccountId, int shopAccountId);
    }
}
