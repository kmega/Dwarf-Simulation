using System;
using System.Collections.Generic;

namespace DwarfSimulation
{
    internal class Mines
    {
        internal List<Shaft> _shafts = new List<Shaft>();
        internal List<Dwarf> _dwarfsBeforeWork = new List<Dwarf>();
        internal List<Dwarf> _dwarfsAfterWork = new List<Dwarf>();

        internal List<Dwarf> EnterMines(List<Dwarf> dwarfs, List<Shaft> shafts, Raport raport)
        {
            Console.WriteLine("\n## MINES ##\n");

            _shafts = shafts;
            _dwarfsBeforeWork = dwarfs;

             _dwarfsAfterWork = WorkInShafts(_dwarfsBeforeWork, _shafts, raport);

            return _dwarfsAfterWork;
        }

        internal List<Dwarf> WorkInShafts(List<Dwarf> dwarfsBeforeWork, List<Shaft> shafts, Raport raport)
        {
            Work work = new Work();

            while (dwarfsBeforeWork.Count > 0)
            {
                if (CheckShaftsStatus(shafts))
                {
                    _dwarfsAfterWork.AddRange(dwarfsBeforeWork);
                    return _dwarfsAfterWork;
                }

                shafts = work.GoToShafts(dwarfsBeforeWork, shafts);

                shafts = work.MineForOre(shafts, raport);

                _dwarfsAfterWork = work.RemoveFromShafts(shafts);
            }

            return _dwarfsAfterWork;
        }

        internal bool CheckShaftsStatus(List<Shaft> shafts)
        {
            int collapsedShaftsNumber = 0;

            foreach (var shaft in shafts)
            {
                if (shaft.Collapsed == true)
                {
                    collapsedShaftsNumber++;
                }
            }

            if (collapsedShaftsNumber == shafts.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
