using DwarfLifeSimulation.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Randomizer.HitsRandomizer
{
    public class HitsGenerationStrategy :IHitsRandomizer
    {
        private IRandomizer randomizer;

        public HitsGenerationStrategy()
        {
            randomizer = new Randomizer();
        }

        public int HowManyHits()
        {
            return randomizer.Generate(1, 3);
        }

        
    }
}