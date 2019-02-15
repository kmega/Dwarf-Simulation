using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Mines;
using DwarfLifeSimulation.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Dwarves.Interfaces
{
    public interface IWorkStrategy
    {
        Dictionary<MineralType,int> Perform(Shaft shaft, ILog logger = null);
    }
}
