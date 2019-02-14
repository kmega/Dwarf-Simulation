using System;
using System.Collections.Generic;
using ThorinsCompany;

namespace DwarfMineSimulator
{
    public class RandomizerThorins
    {
        Random rnd = new Random();

        public int ReturnRandomNumber(int first, int last)
        {
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

        public int ReturnPriceMaterials(Material material)
        {
            int random = 0;
            switch (material)
            {
                case Material.Mithril:
                    random = rnd.Next(15, 25 + 1);
                    break;
                case Material.Silver:
                    random = rnd.Next(5, 15 + 1);
                    break;
                case Material.Gold:
                    random = rnd.Next(10, 20 + 1);
                    break;
                case Material.DirtyGold:
                    random = rnd.Next(1, 5 + 1);
                    break;
            }
            return random;
        }
    }
}
