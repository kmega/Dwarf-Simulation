using System;
using System.Collections.Generic;
using System.Text;
using DwarfLifeSimulation.Enums;

namespace DwarfLifeSimulation.Randomizer.DwarfNameRandomizer
{
    public class DwarfNameGenerationStrategy : IDwarfNameRandomizer
    {
        public string Generate()
        {
            int maxValue = Enum.GetNames(typeof(DwarfNames)).Length;
            int randomNumber = Generate(1,maxValue - 1);
            DwarfNames name = (DwarfNames)randomNumber;
            return name.ToString();
        }

        public int Generate(int minValue, int maxValue)
        {
            return new Random().Next(minValue, maxValue);
        }
    }
}