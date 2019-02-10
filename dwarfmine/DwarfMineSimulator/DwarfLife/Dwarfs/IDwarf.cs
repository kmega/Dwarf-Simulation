﻿using System;
using System.Collections.Generic;
using DwarfLife.Buildings.Mine;
using DwarfLife.Buildings.Guild;
using DwarfLife.Buildings.Canteen;
using DwarfLife.Enums;
using DwarfLife.Buildings.Shop;

namespace DwarfLife.Dwarfs
{
    public interface IDwarf
    {
        int Id { get; }
        DwarfTypes DwarfType { get; }
        bool Alive { get; set; }
        Places WhereAmI { get; set; }
        Dictionary<Minerals, int> MinedMinerals { get; }
        decimal DailyPayment { get; }
        Dictionary<ItemsInShop, int> PurchasedItems { get; }

        void Dig(Shaft shaft, int hits = 0);
        void SellMinerals(Guild guild);
        void Eat(Canteen canteen);
        void Buy(Shop shop, ItemsInShop item = ItemsInShop.None);
        void Buy(Shop shop, ItemsInShop[] items);
    }
}
