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
                dwarf = shaft.Miners[index];

                amountOfWork = dwarf.DigAction.Dig();
                miningChance = _randomizer.ReturnFromTo(1, 100);

                dwarf = MineOre(dwarf, amountOfWork, miningChance, raport);
            }

            return shaft;
        }

        internal Dwarf MineOre(Dwarf dwarf, int amountOfWork, int miningChance, Raport raport)
        {
            for (int index = 0; index < amountOfWork; index++)
            {
                if (miningChance <= 5)
                {
                    dwarf.BackPack[Mineral.Mithril]++;
                    raport.MithrilMined++;
                }
                else if (miningChance > 5 && miningChance <= 20)
                {
                    dwarf.BackPack[Mineral.Gold]++;
                    raport.GoldMined++;
                }
                else if (miningChance > 20 && miningChance <= 55)
                {
                    dwarf.BackPack[Mineral.Silver]++;
                    raport.SilverMined++;
                }
                else
                {
                    dwarf.BackPack[Mineral.TaintedGold]++;
                    raport.TaintedGoldMined++;
                }
            }

            return dwarf;
        }
    }
}
