using System;
using System.Collections.Generic;

namespace DwarfMineSimulator
{
    class Shafts
    {
        private Randomizer randomizer = new Randomizer();

        internal Shaft AddToShaft(Shaft shaft, List<Dwarf> dwarfsPopulation)
        {
            for (int i = 0; i < shaft.MaxInside; i++)
            {
                try
                {
                    shaft.Miners.Add(dwarfsPopulation[i]);
                }
                catch
                {
                    break;
                }
            }

            return shaft;
        }

        internal Shaft GetOre(Shaft shaft)
        {
            

            int miningChance = randomizer.ReturnToFrom(1, 100);
            int workToBeDone;

            for (int index = 0; index < shaft.Miners.Count; index++)
            {
                if (shaft.Miners[index].Type == DwarfTypes.Lazy)
                {
                    workToBeDone = randomizer.ReturnToFrom(0, 1);
                }
                else
                {
                    workToBeDone = randomizer.ReturnToFrom(1, 3);
                }

                shaft = WorkForOneTurn(shaft, index, miningChance, workToBeDone);
            }

            return shaft;
        }

        internal Shaft CheckForSuicider(Shaft shaft)
        {
            for (int i = 0; i < shaft.Miners.Count; i++)
            {
                if (shaft.Miners[i].Type == DwarfTypes.Suicider)
                {
                    for (int j = 0; j < shaft.Miners.Count; j++)
                    {
                        shaft.Miners[j].Alive = false;
                    }

                    shaft.Collapsed = true;
                }
            }

            return shaft;
        }

        internal Shaft WorkForOneTurn(Shaft shaft, int index, int miningChance, int workToBeDone)
        {
            Minerals mineral = Minerals.TaintedGold;

            for (int i = 0; i < workToBeDone; i++)
            {
                if (miningChance <= 55)
                {
                    mineral = Minerals.Silver;

                    if (miningChance <= 20)
                    {
                        mineral = Minerals.Gold;

                        if (miningChance <= 5)
                        {
                            mineral = Minerals.Mithril;
                        }
                    }
                }

                switch (mineral)
                {
                    case Minerals.TaintedGold:
                        Raport.TaintedGoldMinded++;
                        break;
                    case Minerals.Silver:
                        Raport.SilverMinded++;
                        break;
                    case Minerals.Gold:
                        Raport.GoldMinded++;
                        break;
                    default:
                        Raport.MithrilMinded++;
                        break;
                }

                miningChance = randomizer.ReturnToFrom(1, 100);

                shaft.Miners[index].MineralsMined[mineral]++;
                Console.WriteLine("Dwarf " + shaft.Miners[index].ID + " mined " + mineral);
            }

            return shaft;
        }
    }
}
