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
        int Hits;
        bool WorkDone;
        DwarfTypes Type { get; set; }
        bool Alive { get; set; }
        decimal Money { get; set; }
        decimal MoneyEarndedThisDay { get; set; }
        Dictionary<Minerals, int> MineralsMined { get; set; }
        Dictionary<Minerals, int> MineralsMinedToday { get; set; }
        Dictionary<ShopGoods, decimal> ShoppedGoods { get; set; }

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
            MineralsMinedToday = new Dictionary<Minerals, int>();
            ShoppedGoods = new Dictionary<ShopGoods, decimal>
            {
                { ShopGoods.Food, 0 },
                { ShopGoods.Alcohol, 0 }
            };
        }

        public DwarfTypes GetDwarfType()
        {
            return Type;
        }

        public void MineMinerals()
        {
            MineralsMinedToday = new Dictionary<Minerals, int>()
            {
                { Minerals.Mithril, 0 },
                { Minerals.Gold, 0 },
                { Minerals.Silver, 0 },
                { Minerals.TaintedGold, 0 }
            };

            int chance = new Random().Next(1, 100);
            if (Enumerable.Range(1, 5).Contains(chance))
            {
                MineralsMined[Minerals.Mithril] += 1;
                MineralsMinedToday[Minerals.Mithril] += 1;
                Console.WriteLine("Dwarf {0} dig {1}", Identifier, Minerals.Mithril.ToString());
            }

            if (Enumerable.Range(6, 20).Contains(chance))
            {
                MineralsMined[Minerals.Gold] += 1;
                MineralsMinedToday[Minerals.Gold] += 1;
                Console.WriteLine("Dwarf {0} dig {1}", Identifier, Minerals.Gold.ToString());
            }

            if (Enumerable.Range(21, 55).Contains(chance))
            {
                MineralsMined[Minerals.Silver] += 1;
                MineralsMinedToday[Minerals.Silver] += 1;
                Console.WriteLine("Dwarf {0} dig {1}", Identifier, Minerals.Silver.ToString());
            }

            if (Enumerable.Range(56, 100).Contains(chance))
            {
                MineralsMined[Minerals.TaintedGold] += 1;
                MineralsMinedToday[Minerals.TaintedGold] += 1;
                Console.WriteLine("Dwarf {0} dig {1}", Identifier, Minerals.TaintedGold.ToString());
            }

            Hits--;
        }

        public void HowManyHits()
        {
            Hits = new Random().Next(1, 4);
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

        public Dictionary<Minerals, int> MinedMineralsReport()
        {
            return MineralsMinedToday;
        }

        public void TakeMoney(decimal moneyFromGuild)
        {
            MoneyEarndedThisDay = moneyFromGuild;
            //Money += MoneyEarndedThisDay;
        }

        private void PutMoneyToSock()
        {
            Money += (MoneyEarndedThisDay / 2);
        }

        public void Eat()
        {
            Console.WriteLine("Dwarf {0} eat foot ration.", this.GetId());
        }

        public void BoughtGoods(ShopGoods shopGoods)
        {
            switch (shopGoods)
            {
                case ShopGoods.Food:
                    ShoppedGoods[ShopGoods.Food] += (MoneyEarndedThisDay / 2);
                    break;
                case ShopGoods.Alcohol:
                    ShoppedGoods[ShopGoods.Alcohol] += (MoneyEarndedThisDay / 2);
                    break;
            }

            PutMoneyToSock();

            Console.WriteLine("Dwarf {0} bought {1} in shop.", this.GetId(), shopGoods);
        }

        public decimal BoughtGoodsCount(ShopGoods shopGoods)
        {
            switch (shopGoods)
            {
                case ShopGoods.Food:
                    return ShoppedGoods[ShopGoods.Food];
                case ShopGoods.Alcohol:
                    return ShoppedGoods[ShopGoods.Alcohol];
                default:
                    return 0;
            }
        }
    }
}
