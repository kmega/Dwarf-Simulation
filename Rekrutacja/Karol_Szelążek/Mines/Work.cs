using System.Collections.Generic;

namespace DwarfSimulation
{
    internal class Work
    {
        internal List<Shaft> GoToShafts(List<Dwarf> dwarfsBeforeWork, List<Shaft> shafts)
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

        internal List<Shaft> MineForOre(List<Shaft> shafts, Raport raport)
        {
            Shaft shaft;

            for (int index = 0; index < shafts.Count; index++)
            {
                shaft = shafts[index];
                shaft = shaft.WorkAction.Work(shaft, raport);
            }

            return shafts;
        }

        internal List<Dwarf> RemoveFromShafts(List<Shaft> shafts)
        {
            List<Dwarf> dwarfsAfterWork = new List<Dwarf>();

            foreach (var shaft in shafts)
            {
                for (int index = 0; index < shaft.MaxInside; index++)
                {
                    try
                    {
                        dwarfsAfterWork.Add(shaft.Miners[0]);
                        shaft.Miners.RemoveAt(0);
                    }
                    catch
                    {
                        break;
                    }
                }
            }

            return dwarfsAfterWork;
        }
    }
}