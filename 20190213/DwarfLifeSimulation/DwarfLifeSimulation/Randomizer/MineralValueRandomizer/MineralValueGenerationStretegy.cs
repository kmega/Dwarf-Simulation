using System;
using System.Collections.Generic;
using System.Text;
using DwarfLifeSimulation.Enums;

namespace DwarfLifeSimulation.Randomizer.MineralValueRandomizer
{
    public class MineralValueGenerationStretegy : IMineralValueRandomizer
    {
        private IRandomizer randomizer;

        public MineralValueGenerationStretegy()
        {
            randomizer = new Randomizer();
        }

        public decimal ExchangeMineralToValue(MineralType mineralType)
        {
            switch (mineralType)
            {
                case MineralType.Mithril:
                    return randomizer.Generate(15,25);
                case MineralType.Gold:
                    return randomizer.Generate(10,20);
                case MineralType.Silver:
                    return randomizer.Generate(5,15);
                case MineralType.TaintedGold:
                    return 2;
                default:
                    return 0;
            }
        }
    }
}