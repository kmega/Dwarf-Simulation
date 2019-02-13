using DwarfLifeSimulation.Locations.Shops;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Dwarves
{
    public interface IBuy
    {
        Product Buy(int customerAccountId);
    }
}
