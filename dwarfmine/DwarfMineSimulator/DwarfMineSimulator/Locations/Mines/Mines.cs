using System;
using System.Collections.Generic;

namespace DwarfMineSimulator
{
    class Mines
    {
        Shafts _shafts = new Shafts();

        List<Dwarf> _dwarfsThatMined = new List<Dwarf>();

        internal List<Dwarf> MineInShafts(List<Dwarf> dwarfsPopulation, List<Shaft> shaftsNumber)
        {
            Console.WriteLine("## MINES ##\n");

            Shaft _shaft;
            int _collapsedShaftsCounter = 0;

            while (dwarfsPopulation.Count > 0)
            {
                for (int index = 0; index < shaftsNumber.Count; index++)
                {
                    _shaft = shaftsNumber[index];

                    if (_shaft.Collapsed == false)
                    {
                        _shaft = _shafts.AddToShaft(_shaft, dwarfsPopulation);
                        dwarfsPopulation.RemoveRange(0, _shaft.Miners.Count);
                    }
                    else
                    {
                        _collapsedShaftsCounter++;
                    }
                }

                if (_collapsedShaftsCounter <= shaftsNumber.Count)
                {
                    shaftsNumber = MineForOre(shaftsNumber);
                }
                else
                {
                    _dwarfsThatMined.AddRange(dwarfsPopulation);

                    return _dwarfsThatMined;
                }
            }

            return _dwarfsThatMined;
        }

        private List<Shaft> MineForOre(List<Shaft> shaftsNumber)
        {
            Shaft _shaft;

            for (int index = 0; index < shaftsNumber.Count; index++)
            {
                _shaft = shaftsNumber[index];

                _shaft = _shafts.CheckForSuicider(_shaft);

                if (_shaft.Collapsed == false)
                {
                    _shaft = _shafts.GetOre(_shaft);
                }

                for (int i = 0; i < _shaft.MaxInside; i++)
                {
                    try
                    {
                        _dwarfsThatMined.Add(_shaft.Miners[0]);
                        _shaft.Miners.RemoveAt(0);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            return shaftsNumber;
        }
    }
}
