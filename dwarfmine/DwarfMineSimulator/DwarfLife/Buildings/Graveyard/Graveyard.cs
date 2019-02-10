using System;
using System.Collections.Generic;
using System.Linq;
using DwarfLife.Dwarfs;
using DwarfLife.Diaries;

namespace DwarfLife.Buildings.Graveyard
{
    public class Graveyard
    {
        public List<IDwarf> DeadDwarfs { get; private set; }

        public Graveyard()
        {
            DeadDwarfs = new List<IDwarf>();

            DiaryHelper.Log(Constans.diaryTarget,
                string.Format("Graveyard has been created."));
        }

        public void BurryDeadDwarfs(List<IDwarf> dwarfs)
        {
            DeadDwarfs = dwarfs.Where(dead => dead.Alive == false).ToList();
            DeadDwarfs.ForEach(dead =>
            {
                dwarfs.Remove(dead);
                DiaryHelper.Log(Constans.diaryTarget,
                string.Format("On Graveyard has been burried dwarf {0}.",
                dead.Id));
            });
        }
    }
}
