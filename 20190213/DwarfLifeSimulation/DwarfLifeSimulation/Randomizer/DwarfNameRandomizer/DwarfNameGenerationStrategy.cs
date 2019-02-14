using System;
using System.Collections.Generic;
using System.Text;
using DwarfLifeSimulation.Enums;

namespace DwarfLifeSimulation.Randomizer.DwarfNameRandomizer
{
    public class DwarfNameGenerationStrategy : IDwarfNameRandomizer
    {
        private IRandomizer randomizer;

        public DwarfNameGenerationStrategy()
        {
            randomizer = new Randomizer();
        }

        public string GiveMeDwarfName()
        {
            int maxValue = Enum.GetNames(typeof(DwarfNames)).Length;
            int randomNumber = randomizer.Generate(1,maxValue - 1);
            DwarfNames name = (DwarfNames)randomNumber;
            return name.ToString();
        }
    }
}