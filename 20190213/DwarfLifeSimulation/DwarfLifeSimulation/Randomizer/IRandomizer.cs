using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Randomizer
{
    public interface IRandomizer
    {
        int Generate(int minValue, int maxValue);
    }
}
