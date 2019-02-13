using System;
using System.Collections.Generic;
using System.Text;
using DwarfLifeSimulation.Enums;

namespace DwarfLifeSimulation.Randomizer.IsDwarfBornRandomizer
{
    public class DwarfBornGenerationStrategy : IIsDwarfBornRandomizer
    {
        public bool IsDwarfBorn(int maxValue = 100)
        {
            return Generate(1,maxValue) == 1;
        }

        public int Generate(int minValue, int maxValue)
        {
            return new Random().Next(minValue, maxValue);
        }
    }
}