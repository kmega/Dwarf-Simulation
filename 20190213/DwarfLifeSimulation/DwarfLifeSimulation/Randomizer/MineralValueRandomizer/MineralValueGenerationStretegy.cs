using System;
using System.Collections.Generic;
using System.Text;
using DwarfLifeSimulation.Enums;

namespace DwarfLifeSimulation.Randomizer.MineralValueRandomizer
{
    public class MineralValueGenerationStretegy : IMineralValueRandomizer
    {
        public decimal ExchangeMineralToValue(MineralType mineralType)
        {
            switch (mineralType)
            {
                case MineralType.Mithril:
                    return Generate(15,25);
                case MineralType.Gold:
                    return Generate(10,20);
                case MineralType.Silver:
                    return Generate(5,15);
                case MineralType.TaintedGold:
                    return Generate(1,5);
                default:
                    return 0;
            }
        }

        public int Generate(int minValue, int maxValue)
        {
            return new Random().Next(minValue, maxValue);
        }
    }
}