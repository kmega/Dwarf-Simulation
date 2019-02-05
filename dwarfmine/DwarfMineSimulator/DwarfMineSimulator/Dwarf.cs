using System;
using System.Collections.Generic;
using System.Text;
using DwarfMineSimulator.Enums;

namespace DwarfMineSimulator
{
    class Dwarf
    {
        DwarfTypes Type { get; set; }

        bool Alive { get; set; }

        decimal Money { get; set; }

        decimal MoneyEarndedThisDay { get; set; }

        Dictionary<Minerals, int> MineralsMined { get; set; }



    }
}
