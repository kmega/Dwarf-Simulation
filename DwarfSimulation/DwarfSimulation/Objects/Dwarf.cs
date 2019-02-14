using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfSimulation
{
    internal class Dwarf
    {
        internal bool IsAlive { get; set; }

        internal Dictionary<Mineral, int> BackPack { get; set; }
        internal IBuy BuyAction { get; set; }
        internal IDig DigAction { get; set; }
        internal IEat EatAction { get; set; }

        internal void BuyAtShop(Shop shop)
        {
            BuyAction.Buy(shop, Wallet);

        }

        internal decimal Wallet { get; set; }
        internal decimal Account { get; set; }

        public Dwarf()
        {
            IsAlive = true;

            BackPack = new Dictionary<Mineral, int>() {
                { Mineral.Mithril, 0 },
                { Mineral.Gold, 0 },
                {Mineral.Silver,0 },
                {Mineral.TaintedGold,0 }
            };

            EatAction = new EatStrategy();

            Wallet = 0.0m;

            Account = 0.0m;

        }
    }
}
