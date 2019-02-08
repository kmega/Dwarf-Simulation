using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class MinesEntrance
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
                        _shaftsNumber[index] = AddToShaft(_shaftsNumber[index]);
                    }
                }

                if (collapsedShaftsCounter <= _shaftsNumber.Count)
                {
                    _shaftsNumber = MineForOre(_shaftsNumber);
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

        internal Shaft AddToShaft(Shaft shaft)
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

        private List<Shaft> MineForOre(List<Shaft> shaftsNumber)
        {
            for (int index = 0; index < shaftsNumber.Count; index++)
            {
                shaftsNumber[index] = CheckForSuicider(shaftsNumber[index]);

                if (shaftsNumber[index].Collapsed == false)
                {
                    shaftsNumber[index] = GetOre(shaftsNumber[index]);
                }

                for (int i = 0; i < shaftsNumber[index].MaxInside; i++)
                {
                    try
                    {
                        _dwarfsThatMined.Add(shaftsNumber[index].Miners[0]);
                        shaftsNumber[index].Miners.RemoveAt(0);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            return shaftsNumber;
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
