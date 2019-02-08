using System;
using System.Collections.Generic;

namespace DwarfMineSimulator
{
    class Randomizer
    {
        internal DwarfTypes RandomTypeDwarf()
        {
            DwarfTypes dwarfTypes = GenerateDwarfType(ReturnToFrom(1, 100));
            
            return dwarfTypes;
        }

        internal DwarfTypes GenerateDwarfType(int chanceToFatherOrSingle)
        {
            if (chanceToFatherOrSingle <= 33)
            {
                return DwarfTypes.Father;
            }
            else if (chanceToFatherOrSingle > 33 && chanceToFatherOrSingle <= 66)
            {
                return DwarfTypes.Single;
            }
            else if (chanceToFatherOrSingle > 66 && chanceToFatherOrSingle <= 99)
            {
                return DwarfTypes.Lazy;
            }
            else
            {
                return DwarfTypes.Suicider;
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

        internal Dictionary<Minerals, int> GetPriceMinerals()
        {
            int MithrilPrice, GoldPrice, SilverPrice, TaintedGoldPrice;
            Dictionary<Minerals, int> dictionary = new Dictionary<Minerals, int>();

            dictionary.Add(Minerals.Mithril, MithrilPrice = ReturnToFrom(15, 25));
            dictionary.Add(Minerals.Gold, GoldPrice = ReturnToFrom(10, 20));
            dictionary.Add(Minerals.Silver, SilverPrice = ReturnToFrom(5, 15));
            dictionary.Add(Minerals.TaintedGold, TaintedGoldPrice = 2);

            return dictionary;
        }

        internal int ReturnToFrom(int first, int last)
        {
            Random rnd = new Random();

            int random = rnd.Next(first, last + 1);

            return random;
        }
    }
}
