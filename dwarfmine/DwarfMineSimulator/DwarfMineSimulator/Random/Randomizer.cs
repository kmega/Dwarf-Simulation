using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class Randomizer
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

        public Dictionary<Minerals, int> GetPriceMinerals()
        {
            int MithrilPrice, GoldPrice, SilverPrice, TrainedGoldPrice;
            var dictionary = new Dictionary<Minerals, int>();
            dictionary.Add(Minerals.Mithril,MithrilPrice = rnd.Next(15, 26));
            dictionary.Add(Minerals.Gold, GoldPrice = rnd.Next(10, 21));
            dictionary.Add(Minerals.Silver, SilverPrice = rnd.Next(5, 16));
            dictionary.Add(Minerals.TaintedGold, TrainedGoldPrice = 2);
            return dictionary;
        }
    }
}
