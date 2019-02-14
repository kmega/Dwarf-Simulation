using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Mines;
using DwarfLifeSimulation.Randomizer.HitsRandomizer;
using DwarfLifeSimulation.Randomizer.MineralTypeRandomizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Dwarves.Interfaces
{
    public class MinerWorkStrategy : IWorkStrategy
    {
        public Dictionary<MineralType,int> Perform(Shaft shaft)
        {
            Dictionary<MineralType,int> backpack = new Dictionary<MineralType,int>();
            int hits = new HitsGenerationStrategy().HowManyHits();
            MineralType mineral = new MineralTypeGenerationStrategy().WhatHaveBeenDig();
            
            while (hits > 0)
            {
                if (backpack.ContainsKey(mineral))
                    backpack[mineral]++;
                else
                    backpack.TryAdd(mineral, 1);
            }
            return backpack;
        }
    }
}