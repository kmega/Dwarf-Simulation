using System;
using System.Collections.Generic;
using System.Text;
using DwarfLifeSimulation.Enums;

namespace DwarfLifeSimulation.Randomizer.DwarfTypeRandomizer
{
    public class DwarfTypeGenerationStrategy : IDwarfTypeRandomizer
    {
        public DwarfType Generate()
        {
            int maxValue = Enum.GetNames(typeof(DwarfType)).Length;
            int randomNumber = Generate(1,maxValue);
            switch (randomNumber)
            {
                case int n when (n > 0 && n <=33):
                    return DwarfType.Father;
                case int n when (n > 33 && n <=66):
                    return DwarfType.Single;
                case int n when (n > 66 && n <=99):
                    return DwarfType.Suicide;
                case int n when (n == 100):
                    return DwarfType.Sluggard;
                default:
                    return DwarfType.None;
            }
        }

        public int Generate(int minValue, int maxValue)
        {
            return new Random().Next(minValue, maxValue);
        }
    }
}
