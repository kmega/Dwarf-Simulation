using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Locations.Mines;
using System;
using System.Collections.Generic;
using DwarfLifeSimulation.Loggers;

namespace DwarfLifeSimulation.Dwarves.WorkStrategies
{
    public class SuicideStrategy : IWorkStrategy
    {
        public Dictionary<MineralType, int> Perform(Shaft shaft, ILog logger)
        {
            Dictionary<MineralType, int> backpack = new Dictionary<MineralType, int>();
            backpack.Add(MineralType.Mithril, 0);
            backpack.Add(MineralType.Gold, 0);
            backpack.Add(MineralType.Silver, 0);
            backpack.Add(MineralType.TaintedGold, 0); 
            
            shaft.ShaftStatus = ShaftStatus.Destroyed;
            logger.AddLog("Shaft has been destroyed.");
            
            return backpack;
        }
    }
}
