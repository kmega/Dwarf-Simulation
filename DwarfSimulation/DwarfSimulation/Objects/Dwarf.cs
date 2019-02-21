using System.Collections.Generic;

namespace DwarfSimulation
{
    internal class Dwarf
    {
        internal int ID;

        internal DwarfType DwarfType;
        internal bool IsAlive { get; set; }

        internal Dictionary<Mineral, int> BackPack { get; set; }
        internal IBuy BuyAction { get; set; }
        internal IDig DigAction { get; set; }

        internal void BuyAtShop(Shop shop)
        {
            if (Wallet != 0.0m)
            {
                BuyAction.Buy(shop, Wallet);
                Wallet = BuyAction.UpdateWallet(Wallet);
            }

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


            Wallet = 0.0m;

            Account = 0.0m;

        }
    }
}
