using System;
using System.Collections.Generic;
using System.Text;
using DwarfLifeSimulation.Enums;

namespace DwarfLifeSimulation.Randomizer.MineralTypeRandomizer
{
    public class MineralTypeGenerationStrategy : IMineralTypeRandomizer
    {
        public MaterialType Generate()
        {
            int maxValue = Enum.GetNames(typeof(DwarfType)).Length;
            int randomNumber = Generate(1,maxValue);
            switch (randomNumber)
            {
                case int n when (n > 0 && n <= 5):
                    return MaterialType.Mithril;
                case int n when (n > 5 && n <= 20):
                    return MaterialType.Gold;
                case int n when (n > 20 && n <= 55):
                    return MaterialType.Silver;
                case int n when (n > 55 && n <= 100):
                    return MaterialType.Mithril;
                default:
                    return MaterialType.None;
            }
        }

        public int Generate(int minValue, int maxValue)
        {
            return new Random().Next(minValue, maxValue);
        }
    }
}