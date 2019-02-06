using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DwarfMineSimulator.Enums;
using DwarfMineSimulator.Building.Mine;

namespace DwarfMineSimulator.Dwarfs
{
    internal class Dwarf
    {
        int Identifier;

        DwarfTypes Type { get; set; }

        bool Alive { get; set; }

        decimal Money { get; set; }

        decimal MoneyEarndedThisDay { get; set; }

        Dictionary<Minerals, int> MineralsMined { get; set; }

        public Dwarf(int id, DwarfTypes type, bool alive, decimal money)
        {
            Identifier = id;
            Type = type;
            Alive = alive;
            Money = money;
            MoneyEarndedThisDay = 0;
            MineralsMined = new Dictionary<Minerals, int>()
            {
                { Minerals.Mithril, 0 },
                { Minerals.Gold, 0 },
                { Minerals.Silver, 0 },
                { Minerals.TaintedGold, 0 }
            };
        }

        public DwarfTypes GetDwarfType()
        {
            return Type;
        }

        public void MineMinerals()
        {
            int howMany = HowManyHits();
            while(howMany > 0)
            {
                int chance = new Random().Next(1, 100);
                if (Enumerable.Range(1, 5).Contains(chance))
                {
                    MineralsMined.TryGetValue(Minerals.Mithril, out var currentValue);
                    MineralsMined[Minerals.Mithril] = currentValue++;
                    Console.WriteLine("Dwarf no {0} dug {1}", Identifier, Minerals.Mithril.ToString());
                }

                if (Enumerable.Range(6, 20).Contains(chance))
                {
                    MineralsMined.TryGetValue(Minerals.Gold, out var currentValue);
                    MineralsMined[Minerals.Gold] = currentValue++;
                    Console.WriteLine("Dwarf no {0} dug {1}", Identifier, Minerals.Gold.ToString());
                }

                if (Enumerable.Range(21, 55).Contains(chance))
                {
                    MineralsMined.TryGetValue(Minerals.Silver, out var currentValue);
                    MineralsMined[Minerals.Silver] = currentValue++;
                    Console.WriteLine("Dwarf no {0} dug {1}", Identifier, Minerals.Silver.ToString());
                }

                if (Enumerable.Range(56, 100).Contains(chance))
                {
                    MineralsMined.TryGetValue(Minerals.TaintedGold, out var currentValue);
                    MineralsMined[Minerals.TaintedGold] = currentValue++;
                    Console.WriteLine("Dwarf no {0} dug {1}", Identifier, Minerals.TaintedGold.ToString());
                }

                howMany--;
            }
        }

        private int HowManyHits()
        {
            return new Random().Next(1, 3);
        }

        public void GoToMine(Mine mine)
        {
            mine.WhichShaft().DwarfGoIntoShaft(this);
        }
    }
}
