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
            _shafts = shafts;
            _dwarfsBeforeWork = dwarfs;

             _dwarfsAfterWork = Work(_dwarfsBeforeWork, _shafts, raport);

            return _dwarfsAfterWork;
        }

        internal List<Dwarf> Work(List<Dwarf> dwarfsBeforeWork, List<Shaft> shafts, Raport raport)
        {
            while (dwarfsBeforeWork.Count > 0)
            {
                if (CheckShaftsStatus(shafts))
                {
                    _dwarfsAfterWork.AddRange(dwarfsBeforeWork);
                    return _dwarfsAfterWork;
                }

                shafts = AddToShafts(dwarfsBeforeWork, shafts);

                shafts = MineForOre(shafts, raport);

                shafts = RemoveFromShafts(shafts);
            }

            return null;
        }

        private List<Shaft> RemoveFromShafts(List<Shaft> shafts)
        {
            foreach (var shaft in shafts)
            {
                _dwarfsAfterWork.AddRange(shaft.Miners);
                shaft.Miners.RemoveRange(0, shaft.MaxInside);
            }

            return shafts;
        }

        private List<Shaft> MineForOre(List<Shaft> shafts, Raport raport)
        {
            Shaft shaft;

            for (int index = 0; index < shafts.Count; index++)
            {
                shaft = shafts[index];
                shaft = shaft.WorkAction.Work(shaft, raport);
            }

            return shafts;
        }

        internal List<Shaft> AddToShafts(List<Dwarf> dwarfsBeforeWork, List<Shaft> shafts)
        {
            foreach (var shaft in shafts)
            {
                if (shaft.Collapsed == false)
                {
                    for (int index = 0; index < shaft.MaxInside; index++)
                    {
                        try
                        {
                            if (dwarfsBeforeWork[0].DwarfType == DwarfType.Suicider)
                            {
                                shaft.WorkAction = new SuiciderWorkStrategy();
                            }
                            shaft.Miners.Add(dwarfsBeforeWork[0]);
                            dwarfsBeforeWork.RemoveAt(0);
                        }
                        catch
                        {
                            break;
                        }
                    }
                }
            }

            return shafts;
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
