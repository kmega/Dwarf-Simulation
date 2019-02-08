using System;
using System.Collections.Generic;

namespace DwarfMineSimulator
{
    class Shafts
    {
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
            Randomizer randomizer = new Randomizer();

            Random random = new Random();
            int workToBeDone = 0;

            for (int j = 0; j < shaft.Miners.Count; j++)
            {
                if (shaft.Miners[j].Type == DwarfTypes.Lazy)
                {
                    workToBeDone = random.Next(0, 2);
                }
                else
                {
                    workToBeDone = random.Next(1, 4);
                }

                for (int m = 0; m < workToBeDone; m++)
                {
                    shaft = WorkForOneTurn(shaft, j, randomizer.Return1to100());
                }
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

        internal Shaft WorkForOneTurn(Shaft shaft, int index, int miningChance)
        {
            Minerals mineral;

            if (miningChance <= 5)
            {
                mineral = Minerals.Mithril;
                Raport.MithrilMinded++;
            }
            else if (miningChance <= 20)
            {
                mineral = Minerals.Gold;
                Raport.GoldMinded++;
            }
            else if (miningChance <= 55)
            {
                mineral = Minerals.Silver;
                Raport.SilverMinded++;
            }
            else
            {
                mineral = Minerals.TaintedGold;
                Raport.TaintedGoldMinded++;
            }

            shaft.Miners[index].MineralsMined[mineral]++;
            Console.WriteLine("Dwarf " + shaft.Miners[index].ID + " mined " + mineral);

            return shaft;
        }
    }
}
