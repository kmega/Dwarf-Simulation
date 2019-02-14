using System;
using System.Collections.Generic;
using System.Text;
using DwarfLifeSimulation.Enums;

namespace DwarfLifeSimulation.Randomizer.IsDwarfBornRandomizer
{
    public class DwarfBornGenerationStrategy : IIsDwarfBornRandomizer
    {
        private IRandomizer randomizer;

        public DwarfBornGenerationStrategy()
        {
            randomizer = new Randomizer();
        }

        public bool IsDwarfBorn(int maxValue = 100)
        {
            return randomizer.Generate(1,maxValue) == 1;
        }
    }
}