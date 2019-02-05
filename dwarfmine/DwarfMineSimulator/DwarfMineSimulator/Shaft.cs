using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    public class Shaft
    {
        internal bool Collapsed;
        internal int MaxInside;
        internal List<Dwarf> Miners;

        public Shaft()
        {
            Collapsed = false;
            MaxInside = 5;
            Miners = new List<Dwarf>();
        }
    }
}
