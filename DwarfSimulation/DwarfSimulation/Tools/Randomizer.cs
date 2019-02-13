using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfSimulation
{
    internal class Randomizer
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
    }
}
