using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfSimulation
{
    internal class Randomizer : IMineralsPrices, IBornRandomizer
    {
        internal int ReturnFromTo(int first, int last)
        {
            Random rnd = new Random();
            int random = rnd.Next(first, last + 1);

            return random;
        }

        internal DwarfType ReturnDwarfType()
        {
            int value = ReturnFromTo(1, 100);

            if (value <= 33)
            {
                return DwarfType.Lazy;
            }
            else if (value > 33 && value <= 66)
            {
                return DwarfType.Single;
            }
            else if (value > 66 && value <= 99)
            {
                return DwarfType.Father;
            }
            else
                return DwarfType.Suicider;
        }
                    

        public decimal ReturnMineralPrice(Mineral mineral)
        {
            decimal price;

            if (mineral == Mineral.Gold)
            {
                price = ReturnFromTo(15, 25);
                return price;
            }
            else if (mineral == Mineral.Gold)
            {
                price = ReturnFromTo(10, 20);
                return price;
            }
            else if (mineral == Mineral.Silver)
            {
                price = ReturnFromTo(5, 15);
                return price;
            }
            else
            {
                return price = 2;
            }
        }

        public bool IsBorn()
        {
            Randomizer random = new Randomizer();
            int chance = random.ReturnFromTo(1, 100);
            return (chance > 1);
        }
    }
}
