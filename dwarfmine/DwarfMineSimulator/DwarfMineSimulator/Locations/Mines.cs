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

            Console.WriteLine("### Mines ###\n");

            while (_dwarfsPopulation.Count > 0)
            {
                for (int index = 0; index < _shaftsNumber.Count; index++)
                {
                    if (_shaftsNumber[index].Collapsed == true)
                    {
                        collapsedShaftsCounter++;
                    }
                    else
                    {
                        AddToShaft(index);
                    }
                }

                if (collapsedShaftsCounter <= _shaftsNumber.Count)
                {
                    StartMining();
                }
                else
                {
                    _dwarfsThatMined.AddRange(_dwarfsPopulation);

                    return _dwarfsThatMined;
                }
            }

            Console.WriteLine("\n");

            return _dwarfsThatMined;
        }

        private void AddToShaft(int index)
        {
            for (int i = 0; i < _shaftsNumber[index].MaxInside; i++)
            {
                try
                {
                    _shaftsNumber[index].Miners.Add(_dwarfsPopulation[0]);
                    _dwarfsPopulation.RemoveAt(0);
                }
                catch
                {
                    break;
                }
            }
        }

        private void StartMining()
        {
            for (int index = 0; index < _shaftsNumber.Count; index++)
            {
                CheckForSuicider(index);

                if (_shaftsNumber[index].Collapsed == false)
                {
                    MineOre(index);
                }

                for (int i = 0; i < _shaftsNumber[index].MaxInside; i++)
                {
                    try
                    {
                        _dwarfsThatMined.Add(_shaftsNumber[index].Miners[0]);
                        _shaftsNumber[index].Miners.RemoveAt(0);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        private void CheckForSuicider(int index)
        {
            for (int i = 0; i < _shaftsNumber[index].Miners.Count; i++)
            {
                if (_shaftsNumber[index].Miners[i].Type == DwarfTypes.Suicider)
                {
                    for (int j = 0; j < _shaftsNumber[index].Miners.Count; j++)
                    {
                        _shaftsNumber[index].Miners[j].Alive = false;
                    }

                    _shaftsNumber[index].Collapsed = true;
                }
            }
        }

        private void MineOre(int i)
        {
            Randomizer randomizer = new Randomizer();

            Random random = new Random();
            int workToBeDone = 0;

            for (int j = 0; j < _shaftsNumber[i].Miners.Count; j++)
            {
                if (_shaftsNumber[i].Miners[j].Type == DwarfTypes.Lazy)
                {
                    workToBeDone = random.Next(0, 2);
                }
                else
                {
                    workToBeDone = random.Next(1, 4);
                }

                for (int m = 0; m < workToBeDone; m++)
                {
                    AssignMinedOre(randomizer.Return1to100(), i, j);
                }
            }
        }

        private void AssignMinedOre(int miningChance, int i, int j)
        {
            Minerals mineral;

            if (miningChance <= 5)
            {
                mineral = Minerals.Mithril;
                Simulation.MithrilMinded++;
            }
            else if (miningChance <= 20)
            {
                mineral = Minerals.Gold;
                Simulation.GoldMinded++;
            }
            else if (miningChance <= 55)
            {
                mineral = Minerals.Silver;
                Simulation.SilverMinded++;
            }
            else
            {
                mineral = Minerals.TaintedGold;
                Simulation.TaintedGoldMinded++;
            }

            _shaftsNumber[i].Miners[j].MineralsMined[mineral]++;
            Console.WriteLine("Dwarf " + j + " mined " + mineral);
        }
    }
}
