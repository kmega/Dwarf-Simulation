using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    public class Shaft
    {
        internal bool Collapsed = false;
        internal int MaxInside = 5;
        internal List<Dwarf> Miners = new List<Dwarf>();
    }
}
