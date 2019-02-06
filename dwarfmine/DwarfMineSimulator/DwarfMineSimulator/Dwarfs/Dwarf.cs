using System;
using System.Collections.Generic;
using System.Text;
using DwarfMineSimulator.Enums;

namespace DwarfMineSimulator.Dwarfs
{
    internal class Dwarf
    {
        DwarfTypes Type { get; set; }

        bool Alive { get; set; }

        decimal Money { get; set; }

        decimal MoneyEarndedThisDay { get; set; }

        Dictionary<Minerals, int> MineralsMined { get; set; }

        public Dwarf(DwarfTypes type, bool alive, decimal money)
        {
            Type = type;
            Alive = alive;
            Money = money;
            MoneyEarndedThisDay = 0;
            MineralsMined = new Dictionary<Minerals, int>();
        }

        public DwarfTypes GetDwarfType()
        {
            return Type;
        }
    }
}
