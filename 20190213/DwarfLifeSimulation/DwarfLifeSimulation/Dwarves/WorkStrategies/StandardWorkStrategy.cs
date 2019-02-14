using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Locations.Mines;
using DwarfLifeSimulation.Randomizer.HitsRandomizer;
using System.Collections.Generic;

namespace DwarfLifeSimulation.Dwarves.WorkStrategies
{
    public class StandardWorkStrategy : IWorkStrategy
    {
        private IHitsRandomizer _hitRandomizer;

        public StandardWorkStrategy(IHitsRandomizer hitsRandomizer = null)
        {
            _hitRandomizer = (hitsRandomizer != null) ? hitsRandomizer : new HitsGenerationStrategy();
        }

        public Dictionary<MineralType, int> Perform(Shaft shaft)
        {
            Dictionary<MineralType, int> backpack = new Dictionary<MineralType, int>();
            backpack.Add(MineralType.Mithril, 0);
            backpack.Add(MineralType.Gold, 0);
            backpack.Add(MineralType.Silver, 0);
            backpack.Add(MineralType.TaintedGold, 0);
            var timesIDig = _hitRandomizer.HowManyHits();
            for(int i = 0; i < timesIDig; i++)
            {
                MineralType mineralType = Dig(shaft);
                backpack[mineralType] += 1;
            }
            return backpack;
        }

        private MineralType Dig(Shaft shaft)
        {
            return shaft.GenerateMineralType();
        }
    }
}
