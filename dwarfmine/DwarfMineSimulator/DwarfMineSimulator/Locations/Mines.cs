using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class Mines
    {
        List<Dwarf> DwarfsThatMined = new List<Dwarf>();
        List<Dwarf> DwarfsPopulation = new List<Dwarf>();
        List<Shaft> ShaftsNumber = new List<Shaft>();

        internal List<Dwarf> MineInShafts(List<Dwarf> dwarfsPopulation, List<Shaft> shaftsNumber)
        {
            DwarfsPopulation = dwarfsPopulation;
            ShaftsNumber = shaftsNumber;

            for (int i = 0; i < shaftsNumber.Count; i++)
            {
                if (shaftsNumber[i].Collapsed == true)
                {
                    continue;
                }
                else
                {
                    StartMining(i);
                }
            }

            return DwarfsThatMined;
        }

        private void StartMining(int i)
        {
            bool suiciderInside = false;

            for (int j = 0; j < ShaftsNumber[i].MaxInside; j++)
            {
                try
                {
                    ShaftsNumber[i].Miners.Add(DwarfsPopulation[j]);
                    DwarfsPopulation.RemoveAt(j);

                    if (DwarfsPopulation[j].Type == DwarfTypes.Suicider)
                    {
                        suiciderInside = true;
                    }
                }
                catch
                {
                    break;
                }
            }

            MineOre(i);

            if (suiciderInside == true)
            {
                for (int j = 0; j < ShaftsNumber[i].Miners.Count; j++)
                {
                    ShaftsNumber[i].Miners[j].Alive = false;
                }
                ShaftsNumber[i].Collapsed = true;
            }

            for (int j = 0; j < ShaftsNumber[i].Miners.Count; j++)
            {
                DwarfsThatMined.Add(ShaftsNumber[i].Miners[j]);
                ShaftsNumber[i].Miners.RemoveAt(j);
            }
        }

        private void MineOre(int i)
        {
            Random random = new Random();
            int miningChance = 0;

            for (int j = 0; j < ShaftsNumber[i].Miners.Count; j++)
            {
                if (ShaftsNumber[i].Miners[j].Type == DwarfTypes.Lazy)
                {
                    for (int m = 0; m < random.Next(0, 2); m++)
                    {
                        miningChance = random.Next(1, 101);

                        AssignMinedOre(miningChance, i, j);
                    }
                }
                else
                {
                    for (int m = 0; m < random.Next(1, 4); m++)
                    {
                        miningChance = random.Next(1, 101);

                        AssignMinedOre(miningChance, i, j);
                    }
                }
            }
        }

        private void AssignMinedOre(int miningChance, int i, int j)
        {
            if (miningChance <= 5)
            {
                ShaftsNumber[i].Miners[j].MineralsMined[Minerals.Mithril]++;
            }
            else if (miningChance <= 20)
            {
                ShaftsNumber[i].Miners[j].MineralsMined[Minerals.Gold]++;
            }
            else if (miningChance <= 55)
            {
                ShaftsNumber[i].Miners[j].MineralsMined[Minerals.Silver]++;
            }
            else
            {
                ShaftsNumber[i].Miners[j].MineralsMined[Minerals.TaintedGold]++;
            }
        }
    }
}
