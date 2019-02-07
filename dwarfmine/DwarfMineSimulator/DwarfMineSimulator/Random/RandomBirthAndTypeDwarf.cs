using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class RandomBirthAndTypeDwarf
    {
        Random rnd = new Random();

        public DwarfTypes RandomTypeDwarf()
        {
            int chanceToFatherOrSingle = rnd.Next(1, 101);
            DwarfTypes dwarfTypes;
            if (chanceToFatherOrSingle <= 33)
            {
                dwarfTypes = DwarfTypes.Father;
            }
            else if (chanceToFatherOrSingle > 33 && chanceToFatherOrSingle <= 66)
            {
                dwarfTypes = DwarfTypes.Single;
            }
            else if (chanceToFatherOrSingle > 66 && chanceToFatherOrSingle <= 99)
            {
                dwarfTypes = DwarfTypes.Lazy;
            }
            else
            {
                dwarfTypes = DwarfTypes.Suicider;
            }
            return dwarfTypes;
        }

        public bool WillHeBeBorn()
        {
            int chanceToBirthDwarf = rnd.Next(1, 101);
            if (chanceToBirthDwarf == 1)
                return true;
            else
                return false;
        }

        public int Return1to100()
        {
            int chanceToBirthDwarf = rnd.Next(1, 101);
            return chanceToBirthDwarf;
        }
    }
}
