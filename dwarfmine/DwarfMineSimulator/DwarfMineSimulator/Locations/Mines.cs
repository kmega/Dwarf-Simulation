using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class Mines
    {
        List<Dwarf> _dwarfsThatMined = new List<Dwarf>();
        List<Dwarf> _dwarfsPopulation = new List<Dwarf>();
        List<Shaft> _shaftsNumber = new List<Shaft>();

        internal List<Dwarf> MineInShafts(List<Dwarf> dwarfsPopulation, List<Shaft> shaftsNumber)
        {
            _dwarfsPopulation = dwarfsPopulation;
            _shaftsNumber = shaftsNumber;

            int collapsedShaftsCounter = 0;

            while (_dwarfsPopulation.Count > 0)
            {
                for (int i = 0; i < shaftsNumber.Count; i++)
                {
                    if (shaftsNumber[i].Collapsed == true)
                    {
                        collapsedShaftsCounter++;
                        if (collapsedShaftsCounter == _shaftsNumber.Count)
                        {
                            return _dwarfsPopulation;
                        }
                    }
                    else
                    {
                        StartMining(i);
                    }
                }

                collapsedShaftsCounter = 0;
            }

            return _dwarfsThatMined;
        }

        private void StartMining(int i)
        {
            bool suiciderInside = false;

            for (int j = 0; j < _shaftsNumber[i].MaxInside; j++)
            {
                try
                {
                    if (_dwarfsPopulation[i].Type == DwarfTypes.Suicider)
                    {
                        suiciderInside = true;
                    }

                    _shaftsNumber[i].Miners.Add(_dwarfsPopulation[i]);
                    _dwarfsPopulation.RemoveAt(i);
                }
                catch
                {
                    continue;
                }
            }

            MineOre(i);

            if (suiciderInside == true)
            {
                for (int j = 0; j < _shaftsNumber[i].Miners.Count; j++)
                {
                    _shaftsNumber[i].Miners[j].Alive = false;
                }
                _shaftsNumber[i].Collapsed = true;
            }

            for (int j = 0; j < _shaftsNumber[i].Miners.Count; j++)
            {
                _dwarfsThatMined.Add(_shaftsNumber[i].Miners[j]);
                _shaftsNumber[i].Miners.RemoveAt(j);
            }
        }

        private void MineOre(int i)
        {
            Random random = new Random();
            int miningChance = 0;

            for (int j = 0; j < _shaftsNumber[i].Miners.Count; j++)
            {
                if (_shaftsNumber[i].Miners[j].Type == DwarfTypes.Lazy)
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
                _shaftsNumber[i].Miners[j].MineralsMined[Minerals.Mithril]++;
            }
            else if (miningChance <= 20)
            {
                _shaftsNumber[i].Miners[j].MineralsMined[Minerals.Gold]++;
            }
            else if (miningChance <= 55)
            {
                _shaftsNumber[i].Miners[j].MineralsMined[Minerals.Silver]++;
            }
            else
            {
                _shaftsNumber[i].Miners[j].MineralsMined[Minerals.TaintedGold]++;
            }
        }
    }
}
