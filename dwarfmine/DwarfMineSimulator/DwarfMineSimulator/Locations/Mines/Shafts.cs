using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class Shafts
    {
        internal Shaft AddToShaft(Shaft shaft, List<Dwarf> _dwarfsPopulation)
        {
            for (int i = 0; i < shaft.MaxInside; i++)
            {
                try
                {
                    shaft.Miners.Add(_dwarfsPopulation[0]);
                    _dwarfsPopulation.RemoveAt(0);
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
                    shaft = WorkForOneTurn(shaft, randomizer.Return1to100());
                }
            }

            return shaft;
        }

        internal Shaft WorkForOneTurn(Shaft shaft, int miningChance)
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

            _shaftsNumber[i].Miners[j].MineralsMined[mineral]++;
            Console.WriteLine("Dwarf " + j + " mined " + mineral);

            return shaft;
        }
    }
}
