using System;
using System.Collections.Generic;
using System.Text;
using DwarfLifeSimulation.Enums;

namespace DwarfLifeSimulation.Randomizer.MineralTypeRandomizer
{
    public class MineralTypeGenerationStrategy : IMineralTypeRandomizer
    {
        private IRandomizer randomizer;

        public MineralTypeGenerationStrategy()
        {
            randomizer = new Randomizer();
        }

        public MineralType WhatHaveBeenDig()
        {
            int randomNumber = randomizer.Generate(1, 100);
            switch (randomNumber)
            {
                case int n when (n > 0 && n <= 5):
                    return MineralType.Mithril;
                case int n when (n > 5 && n <= 20):
                    return MineralType.Gold;
                case int n when (n > 20 && n <= 55):
                    return MineralType.Silver;
                case int n when (n > 55 && n <= 100):
                    return MineralType.TaintedGold;
                default:
                    return MineralType.None;
            }
        }
    }
}