using System;

namespace DwarfSimulation
{
    internal class DefaultWorkStrategy : IWork
    {
        private Randomizer _randomizer = new Randomizer();

        public Shaft Work(Shaft shaft, Raport raport)
        {
            Dwarf dwarf;
            int amountOfWork, miningChance;

            for (int index = 0; index < shaft.MaxInside; index++)
            {
                try
                {
                    dwarf = shaft.Miners[index];

                    amountOfWork = dwarf.DigAction.Dig();
                    miningChance = _randomizer.ReturnFromTo(1, 100);

                    if (amountOfWork == 0)
                    {
                        Console.WriteLine("Dwarf " + dwarf.ID + " - " + dwarf.DwarfType + " is lazy today and mined NOTHING!");
                    }

                    dwarf = MineOre(dwarf, amountOfWork, miningChance, raport);
                }
                catch
                {
                    break;
                }
            }

            return shaft;
        }

        internal Dwarf MineOre(Dwarf dwarf, int amountOfWork, int miningChance, Raport raport)
        {
            Mineral mineral;

            for (int index = 0; index < amountOfWork; index++)
            {
                if (miningChance <= 5)
                {
                    dwarf.BackPack[Mineral.Mithril]++;

                    mineral = Mineral.Mithril;
                    raport.MithrilMined++;
                }
                else if (miningChance > 5 && miningChance <= 20)
                {
                    dwarf.BackPack[Mineral.Gold]++;

                    mineral = Mineral.Gold;
                    raport.GoldMined++;
                }
                else if (miningChance > 20 && miningChance <= 55)
                {
                    dwarf.BackPack[Mineral.Silver]++;

                    mineral = Mineral.Silver;
                    raport.SilverMined++;
                }
                else
                {
                    dwarf.BackPack[Mineral.TaintedGold]++;

                    mineral = Mineral.TaintedGold;
                    raport.TaintedGoldMined++;
                }

                Console.WriteLine("Dwarf " + dwarf.ID + " - " + dwarf.DwarfType + " mined " + mineral);
            }

            return dwarf;
        }
    }
}
