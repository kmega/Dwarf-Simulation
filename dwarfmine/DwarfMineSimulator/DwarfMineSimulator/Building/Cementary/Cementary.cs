using System;
using System.Collections.Generic;
using System.Linq;
using DwarfMineSimulator.Dwarfs;

namespace DwarfMineSimulator.Building.Cementary
{
    internal class Cementary
    {
        List<Dwarf> DeadDwarfs;

        public Cementary(List<Dwarf> deadDwarfs)
        {
            DeadDwarfs = deadDwarfs;
        }
    }
}
