using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Mine;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Interfaces
{
    interface IWorkStrategy
    {
        Dictionary<MineralType,int> Perform(Shaft shaft);
    }
}
