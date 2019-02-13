using System;
using System.Collections.Generic;
using System.Text;
using Mine.Locations;

namespace Mine.DwarfWorkStrategy
{
    class Dig : IWork
    {
        private readonly double _mithrilProbability = 0.05;
        private readonly double _goldProbability = 0.15;
        private readonly double _silverProbability = 0.25;
        private readonly int _howManyUnitsReturn;
        public Dig()
        {
            Random rand = new Random();
            _howManyUnitsReturn = rand.Next(0, 2);
        }
        public List<Ore> DoWork()
        {
            List<Ore> Ores = new List<Ore>();

            for (int i = 0; i < _howManyUnitsReturn; i++)
            {
                Ores.Add(DigOre());
            }
            return Ores;
        }

        private Ore DigOre()
        {
            Random rand = new Random();

                if (rand.NextDouble() < _mithrilProbability)
                    return Ore.Mithril;
                if (rand.NextDouble() < _goldProbability)
                    return Ore.Gold;
                if (rand.NextDouble() < _silverProbability)
                    return Ore.Silver;
                return Ore.DirtGold;
            
        }
    }
}
