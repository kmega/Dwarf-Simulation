using System;
using System.Collections.Generic;
using ThorinsCompany;

namespace DwarfMineSimulator
{
    public class RandomizerThorins
    {
        public int ReturnRandomNumber(int first, int last)
        {
            Random rnd = new Random();

            int random = rnd.Next(first, last + 1);

            return random;
        }

        public DwarfType GenerateDwarfType(int chanceToFatherOrSingle)
        {
            if (chanceToFatherOrSingle <= 33)
            {
                return DwarfType.Father;
            }
            else if (chanceToFatherOrSingle > 33 && chanceToFatherOrSingle <= 66)
            {
                return DwarfType.Single;
            }
            else if (chanceToFatherOrSingle > 66 && chanceToFatherOrSingle <= 99)
            {
                return DwarfType.Lazy;
            }
            else
            {
                return DwarfType.Bomber;
            }
        }

        public bool WillHeBeBorn(int chanceToFatherOrSingle)
        {
            if (chanceToFatherOrSingle == 1)
                return true;
            else
                return false;
        }
    }
}
