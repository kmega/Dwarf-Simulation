using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Randomizer
{
    public class Randomizer : IRandomizer
    {
        public int Generate(int minValue, int maxValue)
        {
            return new Random().Next(minValue, maxValue);
        }
    }
}
