using System;
using System.Collections.Generic;
using System.Text;
using DwarfMineSimulator.Enums;

namespace DwarfMineSimulator
{
   public class Dwarf
    {
       internal DwarfTypes Type { get; set; }

       internal bool Alive { get; set; }

      internal decimal Money { get; set; }
     
      internal decimal MoneyEarndedThisDay { get; set; }
      
      internal Dictionary<Minerals, int> MineralsMined { get; set; }



    }
}
