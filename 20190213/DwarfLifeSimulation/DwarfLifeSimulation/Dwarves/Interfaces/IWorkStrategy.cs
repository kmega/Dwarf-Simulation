using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Mine;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Dwarves.Interfaces
{
    public interface IWorkStrategy
    {
        Dictionary<MineralType,int> Perform(Shaft shaft);
    }
}
