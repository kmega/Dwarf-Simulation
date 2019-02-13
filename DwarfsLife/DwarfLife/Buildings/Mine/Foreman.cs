using System;
using System.Collections.Generic;
using DwarfLife.Dwarfs;
using DwarfLife.Enums;
using DwarfLife.Diaries;

namespace DwarfLife.Buildings.Mine
{
    public class Foreman
    {
        public Foreman()
        {
            DiaryHelper.Log(Constans.diaryTarget,
                string.Format("New Foreman has been created."));
        }

        public void SendDwarfsToRandomShaft(Mine mine, List<IDwarf> dwarfs)
        {
            mine.Shafts.ForEach(shaft =>
            {
                shaft.DwarfsInShaft.RemoveAll(dwarf => dwarf.HasWorkedToday == true);
            });

            dwarfs.ForEach(dwarf =>
            {
                if (dwarf.WhereAmI == Places.Mine)
                {
                    Shaft shaft = WhichShaft(mine);
                    if (!shaft.IsShaftFull())
                    {
                        shaft.DwarfsInShaft.Add(dwarf);
                        dwarf.GoTo(Places.Shaft);

                        DiaryHelper.Log(Constans.diaryTarget,
                            string.Format("Foreman send dwarf {0} to the {1}.",
                            dwarf.Id, shaft.Name));
                    }
                }
            });
        }

        public void SendDwarfsToShaft(Shaft shaft, List<IDwarf> dwarfs)
        {
            shaft.DwarfsInShaft.RemoveAll(dwarf => dwarf.HasWorkedToday == true);

            dwarfs.ForEach(dwarf =>
            {
                if (!shaft.IsShaftFull() && !shaft.IsCollapsed)
                {
                    shaft.DwarfsInShaft.Add(dwarf);
                    dwarf.WhereAmI = Places.Shaft;

                    DiaryHelper.Log(Constans.diaryTarget,
                        string.Format("Foreman send dwarf {0} to the {1}.",
                        dwarf.Id, shaft.Name));
                }
            });
        }

        public Shaft WhichShaft(Mine mine)
        {
            return mine.Shafts[new Random().Next(0, mine.Shafts.Count)];
        }
    }
}
