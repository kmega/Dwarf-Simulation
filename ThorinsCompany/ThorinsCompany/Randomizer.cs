using System;
using System.Collections.Generic;
using ThorinsCompany;

namespace DwarfMineSimulator
{
    class Randomizer
    {
        internal int ReturnToFrom(int first, int last)
        {
            Random rnd = new Random();

            int random = rnd.Next(first, last + 1);

            return random;
        }

        internal DwarfType RandomTypeDwarf()
        {
            DwarfType dwarfTypes = GenerateDwarfType(ReturnToFrom(1, 100));
            
            return dwarfTypes;
        }

        internal DwarfType GenerateDwarfType(int chanceToFatherOrSingle)
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

        internal bool WillHeBeBorn()
        {
            int chanceToBirthDwarf = ReturnToFrom(1, 100);

            if (chanceToBirthDwarf == 1)
                return true;
            else
                return false;
        }
    }
}
