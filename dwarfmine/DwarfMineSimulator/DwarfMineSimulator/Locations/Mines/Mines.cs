using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class Mines
    {
        Shafts _shafts = new Shafts();

        List<Dwarf> _dwarfsThatMined = new List<Dwarf>();

        internal List<Dwarf> MineInShafts(List<Dwarf> dwarfsPopulation, List<Shaft> shaftsNumber)
        {
            Console.WriteLine("### Mines ###\n");
            int collapsedShaftsCounter = 0;

            while (dwarfsPopulation.Count > 0)
            {
                for (int index = 0; index < shaftsNumber.Count; index++)
                {
                    if (shaftsNumber[index].Collapsed == false)
                    {
                        shaftsNumber[index] = _shafts.AddToShaft(shaftsNumber[index], dwarfsPopulation);
                        dwarfsPopulation.RemoveRange(0, shaftsNumber[index].Miners.Count);
                    }
                    else
                    {
                        collapsedShaftsCounter++;
                    }
                }

                if (collapsedShaftsCounter <= shaftsNumber.Count)
                {
                    shaftsNumber = MineForOre(shaftsNumber);
                }
                else
                {
                    _dwarfsThatMined.AddRange(dwarfsPopulation);

                    return _dwarfsThatMined;
                }
            }

            Console.WriteLine("\n");

            return _dwarfsThatMined;
        }

        private List<Shaft> MineForOre(List<Shaft> shaftsNumber)
        {
            for (int index = 0; index < shaftsNumber.Count; index++)
            {
                shaftsNumber[index] = _shafts.CheckForSuicider(shaftsNumber[index]);

                if (shaftsNumber[index].Collapsed == false)
                {
                    shaftsNumber[index] = _shafts.GetOre(shaftsNumber[index]);
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
    }
}
