using System;
using System.Collections.Generic;
using System.Text;


namespace DwarfMineSimulator
{
<<<<<<< HEAD

    public class Dwarf
    {
        internal DwarfTypes Type { get; set; }

        internal bool Alive { get; set; }

        internal decimal Money { get; set; }
=======
   public class Dwarf
    {
      internal DwarfTypes Type { get; set; }

      internal bool Alive { get; set; }

      internal decimal Money { get; set; }
     
      internal decimal MoneyEarndedThisDay { get; set; }
      
      internal Dictionary<Minerals, int> MineralsMined { get; set; }
>>>>>>> c950f64c38eec54dd9a839211c4b6039bc767b43

        internal decimal MoneyEarndedThisDay { get; set; }

        internal Dictionary<Minerals, int> MineralsMined { get; set; }

    }
}
