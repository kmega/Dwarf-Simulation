using System;
using System.Collections.Generic;

namespace DwarfMineSimulator
{
    public class Dwarf
    {
        internal DwarfTypes Type { get; set; }

        internal bool Alive { get; set; }

        internal decimal Money { get; set; }

        internal decimal MoneyEarndedThisDay { get; set; }

        internal Dictionary<Minerals, int> MineralsMined { get; set; }
     
        public Dwarf()
        {                  
            Alive = true;
            Money = 0;
            MoneyEarndedThisDay = 0;
            MineralsMined = new Dictionary<Minerals, int>()
            {
                [Minerals.Mithril] = 0,
                [Minerals.Gold] = 0,
                [Minerals.Silver] = 0,
                [Minerals.TaintedGold] = 0
            };
        }

    }
}
