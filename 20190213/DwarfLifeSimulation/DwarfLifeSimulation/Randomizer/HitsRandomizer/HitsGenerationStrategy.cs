using DwarfLifeSimulation.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Randomizer.HitsRandomizer
{
    public class HitsGenerationStrategy :IHitsRandomizer
    {
        public int HowManyHits(int min = 1, int max = 3)
        {
            return Generate(min,max);
        }

        public int Generate(int minValue, int maxValue)
        {
            return new Random().Next(minValue, maxValue);
        }
    }
}