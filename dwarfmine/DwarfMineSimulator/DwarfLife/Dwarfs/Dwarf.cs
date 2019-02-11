using System;
using System.Collections.Generic;
using DwarfLife.Enums;
using DwarfLife.Diaries;
using DwarfLife.Buildings.Mine;
using DwarfLife.Buildings.Guild;
using DwarfLife.Buildings.Canteen;
using System.Linq;
using DwarfLife.Buildings.Shop;

namespace DwarfLife.Dwarfs
{
    public class Dwarf : IDwarf
    {
        public int Id { get; }
        public DwarfTypes DwarfType { get; }
        public bool Alive { get; set; }
        public Places WhereAmI { get; set; }
        public bool HasWorkedToday { get; set; }
        public Dictionary<Minerals, int> MinedMinerals { get; protected set; }
        public decimal DailyPayment { get; private set; }
        public Dictionary<ItemsInShop, int> PurchasedItems { get; private set; }

        public Dwarf(int id, Places whereAmI = Places.None)
        {
            Id = id;
            DwarfType = DwarfTypes.None;
            Alive = true;
            HasWorkedToday = false;
            WhereAmI = whereAmI;
            MinedMinerals = new Dictionary<Minerals, int>()
            {
                { Minerals.Mithril, 0 },
                { Minerals.Gold, 0 },
                { Minerals.Silver, 0 },
                { Minerals.TaintedGold, 0 }
            };
            DailyPayment = 0;
            PurchasedItems = new Dictionary<ItemsInShop, int>();

            DiaryHelper.Log(Constans.diaryTarget, string.Format(
                "Dwarf has born. His id = {0}, and his type is: {1}",
                Id, DwarfType));
        }

        public void Dig(int hits = 0)
        {
            int hitsCounter = new Random().Next(1, 3);
            Minerals mineral = Minerals.None;

            if (hits > 0)
                hitsCounter = hits;

            if (WhereAmI.Equals(Places.Shaft))
            {
                while (hitsCounter >= 1)
                {
                    int chance = new Random().Next(1, 100);
                    if (Enumerable.Range(1, 5).Contains(chance))
                    {
                        mineral = Minerals.Mithril;
                        DiaryHelper.Log(Constans.diaryTarget,
                        string.Format("Dwarf {0} dig {1}", Id, Minerals.Mithril.ToString()));
                    }

                    if (Enumerable.Range(6, 20).Contains(chance))
                    {
                        mineral = Minerals.Gold;
                        DiaryHelper.Log(Constans.diaryTarget,
                        string.Format("Dwarf {0} dig {1}", Id, Minerals.Gold.ToString()));
                    }

                    if (Enumerable.Range(21, 55).Contains(chance))
                    {
                        mineral = Minerals.Silver;
                        DiaryHelper.Log(Constans.diaryTarget,
                        string.Format("Dwarf {0} dig {1}", Id, Minerals.Silver.ToString()));
                    }

                    if (Enumerable.Range(56, 100).Contains(chance))
                    {
                        mineral = Minerals.TaintedGold;
                        DiaryHelper.Log(Constans.diaryTarget,
                        string.Format("Dwarf {0} dig {1}", Id, Minerals.TaintedGold.ToString()));
                    }

                    MinedMinerals[mineral] += 1;
                    hitsCounter--;
                }

                HasWorkedToday = true;

                DiaryHelper.Log(Constans.diaryTarget,
                string.Format("Dwarf {0} has nothing to dig because he is not in the shaft.", Id));
            }
        }

        public void SellMinerals(Guild guild)
        {
            if (Alive)
            {
                DailyPayment = guild.BuyMinerals(MinedMinerals);

                MinedMinerals[Minerals.Mithril] = 0;
                MinedMinerals[Minerals.Gold] = 0;
                MinedMinerals[Minerals.Silver] = 0;
                MinedMinerals[Minerals.TaintedGold] = 0;

                DiaryHelper.Log(Constans.diaryTarget,
                string.Format("Dwarf {0} sell mined minerals and got payment amound of {1}.",
                    Id, DailyPayment));
            }
        }

        public void Eat(Canteen canteen)
        {
            if (WhereAmI.Equals(Places.Canteen))
            {
                canteen.Rations--;
                DiaryHelper.Log(Constans.diaryTarget,
                string.Format("Dwarf {0} came into Canteen and eat meal.", Id));
            }
        }

        public void Buy(Shop shop, ItemsInShop item = ItemsInShop.None, int howMany = 1)
        {
            if (WhereAmI.Equals(Places.Shop))
            {
                if (PurchasedItems.ContainsKey(item))
                    PurchasedItems[item] += howMany;
                else
                    PurchasedItems.Add(shop.Sell(item), howMany);

                DiaryHelper.Log(Constans.diaryTarget,
                string.Format("Dwarf {0} came to shop and bought {1} of {2}.", 
                Id, howMany, item));
            }
        }

        public void Buy(Shop shop, ItemsInShop[] items) 
        {
            if (WhereAmI.Equals(Places.Shop))
                foreach (var item in items)
                    Buy(shop, item);
        }
    }
}
