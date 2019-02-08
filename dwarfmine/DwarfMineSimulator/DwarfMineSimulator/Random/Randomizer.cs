using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class Randomizer
    {
        Random rnd = new Random();

        internal DwarfTypes RandomTypeDwarf()
        {
            int chanceToFatherOrSingle = rnd.Next(1, 101);

            DwarfTypes dwarfTypes = GenerateDwarfType(chanceToFatherOrSingle);
            
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
            int chanceToBirthDwarf = rnd.Next(1, 101);
            if (chanceToBirthDwarf == 1)
                return true;
            else
                return false;
        }

        internal int Return1to100()
        {
            int chanceToBirthDwarf = rnd.Next(1, 101);
            return chanceToBirthDwarf;
        }

        internal Dictionary<Minerals, int> GetPriceMinerals()
        {
            int MithrilPrice, GoldPrice, SilverPrice, TaintedGoldPrice;
            Dictionary<Minerals, int> dictionary = new Dictionary<Minerals, int>();

            dictionary.Add(Minerals.Mithril,MithrilPrice = rnd.Next(15, 26));
            dictionary.Add(Minerals.Gold, GoldPrice = rnd.Next(10, 21));
            dictionary.Add(Minerals.Silver, SilverPrice = rnd.Next(5, 16));
            dictionary.Add(Minerals.TaintedGold, TaintedGoldPrice = 2);

            return dictionary;
        }
    }
}
