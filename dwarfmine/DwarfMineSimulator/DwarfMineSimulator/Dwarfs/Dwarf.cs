using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DwarfMineSimulator.Enums;
using DwarfMineSimulator.Building.Mine;

namespace DwarfMineSimulator.Dwarfs
{
    internal class DwarfsEventArgs : EventArgs
    {
        public readonly Dictionary<Minerals, int> MineralsMined;

        public DwarfsEventArgs (Dictionary<Minerals, int> mineralsMined)
        {
            MineralsMined = mineralsMined; 
        }
    }

    internal class Dwarf
    {
        int Identifier;

        int Hits;

        bool WorkDone;

        DwarfTypes Type { get; set; }

        bool Alive { get; set; }

        decimal Money { get; set; }

        decimal MoneyEarndedThisDay { get; set; }

        Dictionary<Minerals, int> MineralsMined { get; set; }

        Dictionary<Minerals, int> MineralsMinedToday { get; set; }

        public event EventHandler<DwarfsEventArgs> MinedMinerals;

        public Dwarf(int id, DwarfTypes type, bool alive, decimal money)
        {
            Identifier = id;
            Hits = 0;
            WorkDone = false;
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

        protected virtual void OnMinedMineral(DwarfsEventArgs minedMinerals)
        {
            if (minedMinerals != null)
                MinedMinerals(this, minedMinerals);
        }

        public void MineMinerals()
        {
            int chance = new Random().Next(1, 100);
            if (Enumerable.Range(1, 5).Contains(chance))
            {
                MineralsMined.TryGetValue(Minerals.Mithril, out var currentValue);
                MineralsMined[Minerals.Mithril] = currentValue++;
                //MineralsMinedToday[Minerals.Mithril] = currentValue;
                Console.WriteLine("Dwarf no {0} dug {1}", Identifier, Minerals.Mithril.ToString());
            }

            if (Enumerable.Range(6, 20).Contains(chance))
            {
                MineralsMined.TryGetValue(Minerals.Gold, out var currentValue);
                MineralsMined[Minerals.Gold] = currentValue++;
                //MineralsMinedToday[Minerals.Gold] = currentValue;
                Console.WriteLine("Dwarf no {0} dug {1}", Identifier, Minerals.Gold.ToString());
            }

            if (Enumerable.Range(21, 55).Contains(chance))
            {
                MineralsMined.TryGetValue(Minerals.Silver, out var currentValue);
                MineralsMined[Minerals.Silver] = currentValue++;
                //MineralsMinedToday[Minerals.Silver] = currentValue;
                Console.WriteLine("Dwarf no {0} dug {1}", Identifier, Minerals.Silver.ToString());
            }

            if (Enumerable.Range(56, 100).Contains(chance))
            {
                MineralsMined.TryGetValue(Minerals.TaintedGold, out var currentValue);
                MineralsMined[Minerals.TaintedGold] = currentValue++;
                //MineralsMinedToday[Minerals.TaintedGold] = currentValue;
                Console.WriteLine("Dwarf no {0} dug {1}", Identifier, Minerals.TaintedGold.ToString());
            }

            Hits--;

            //MineralsMinedToday = new Dictionary<Minerals, int>()
            //{
            //    { Minerals.Mithril, 0 },
            //    { Minerals.Gold, 0 },
            //    { Minerals.Silver, 0 },
            //    { Minerals.TaintedGold, 0 }
            //};

            //int howMany = HowManyHits();
            //while(howMany > 0)
            //{
            //    int chance = new Random().Next(1, 100);
            //    if (Enumerable.Range(1, 5).Contains(chance))
            //    {
            //        MineralsMined.TryGetValue(Minerals.Mithril, out var currentValue);
            //        MineralsMined[Minerals.Mithril] = currentValue++;
            //        MineralsMinedToday[Minerals.Mithril] = currentValue;
            //        Console.WriteLine("Dwarf no {0} dug {1}", Identifier, Minerals.Mithril.ToString());
            //    }

            //    if (Enumerable.Range(6, 20).Contains(chance))
            //    {
            //        MineralsMined.TryGetValue(Minerals.Gold, out var currentValue);
            //        MineralsMined[Minerals.Gold] = currentValue++;
            //        MineralsMinedToday[Minerals.Gold] = currentValue;
            //        Console.WriteLine("Dwarf no {0} dug {1}", Identifier, Minerals.Gold.ToString());
            //    }

            //    if (Enumerable.Range(21, 55).Contains(chance))
            //    {
            //        MineralsMined.TryGetValue(Minerals.Silver, out var currentValue);
            //        MineralsMined[Minerals.Silver] = currentValue++;
            //        MineralsMinedToday[Minerals.Silver] = currentValue;
            //        Console.WriteLine("Dwarf no {0} dug {1}", Identifier, Minerals.Silver.ToString());
            //    }

            //    if (Enumerable.Range(56, 100).Contains(chance))
            //    {
            //        MineralsMined.TryGetValue(Minerals.TaintedGold, out var currentValue);
            //        MineralsMined[Minerals.TaintedGold] = currentValue++;
            //        MineralsMinedToday[Minerals.TaintedGold] = currentValue;
            //        Console.WriteLine("Dwarf no {0} dug {1}", Identifier, Minerals.TaintedGold.ToString());
            //    }

            //    howMany--;
            //}

            //return MineralsMinedToday;
        }

        public void HowManyHits()
        {
            Hits = new Random().Next(1, 3);
        }

        public void GoToShaft(IShaft shaft)
        {
            HowManyHits();
            shaft.DwarfGoIntoShaftQueue(this);
        }

        public void GoToMine(Mine mine)
        {
            mine.DwarfsGoToShaft();
        }

        public bool IsAlive()
        {
            return Alive;
        }

        public void SummonDeath()
        {
            Alive = false;
        }

        public string GetId()
        {
            return Identifier.ToString();
        }

        public int MaxHitsInShaft()
        {
            return Hits;
        }

        public void StartShift()
        {
            WorkDone = false;
        }

        public void EndOfShift()
        {
            WorkDone = true;
        }

        public bool IsWorkDone()
        {
            return WorkDone;
        }
    }
}
