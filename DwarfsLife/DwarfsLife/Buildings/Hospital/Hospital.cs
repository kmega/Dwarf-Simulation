using System;
using System.Collections.Generic;
using DwarfsLife.Dwarfs;

namespace DwarfsLife.Buildings.Hospital
{
    internal class Hospital
    {
        public int _bornedDwarfs { get; private set; }
        public List<Dwarf> Dwarfs { get; private set; }

        public Hospital()
        {
            _bornedDwarfs = 0;
            Dwarfs = new List<Dwarf>();
        }
    }
}
