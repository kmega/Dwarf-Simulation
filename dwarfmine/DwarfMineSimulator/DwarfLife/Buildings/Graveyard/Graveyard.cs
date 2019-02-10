using System;
using System.Collections.Generic;
using System.Linq;
using DwarfLife.Dwarfs;

namespace DwarfLife.Buildings.Graveyard
{
    public class Graveyard
    {
        public List<IDwarf> DeadDwarfs { get; private set; }

        public Graveyard()
        {
            DeadDwarfs = new List<IDwarf>();
        }

        public void BurryDeadDwarfs(List<IDwarf> dwarfs)
        {
            DeadDwarfs = dwarfs.Where(dead => dead.Alive == false).ToList();
            DeadDwarfs.ForEach(dead => dwarfs.Remove(dead));
        }
    }
}
