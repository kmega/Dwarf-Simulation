﻿using DwarfLifeSimulation.Locations.Shops;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Dwarves.Interfaces
{
    public interface IBuyStrategy
    {
        Product Buy(int customerAccountId, int shopAccountId);
    }
}
