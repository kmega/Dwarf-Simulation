using NUnit.Framework;
using System;
using System.Collections.Generic;
using DwarfLife.Buildings.Shop;
using DwarfLife.Dwarfs;
using DwarfLife.Enums;
using System.Linq;

namespace DwarfLife.Tests
{
    [TestFixture()]
    public class ShopTests
    {
        [TestCase(ItemsInShop.Alcohol)]
        [TestCase(ItemsInShop.Food)]
        public void ShouldSellItemNameOf(ItemsInShop item)
        {
            // given
            var shop = new Shop();
            var dwarf = new Dwarf(1, Places.Shop);

            // when
            dwarf.Buy(shop, item);

            // then
            Assert.IsTrue(dwarf.PurchasedItems.ContainsKey(item));
            Assert.IsTrue(dwarf.PurchasedItems[item] == 1);
        }

        [Test]
        public void ShouldSellOnlyFood()
        {
            // given
            var shop = new Shop();
            var dwarf = new DwarfFather(1, Places.Shop);

            // when
            dwarf.Buy(shop, ItemsInShop.Food);

            // then
            Assert.IsTrue(dwarf.PurchasedItems.ContainsKey(ItemsInShop.Food));
            Assert.IsTrue(dwarf.PurchasedItems[ItemsInShop.Food] == 1);
        }

        [Test]
        public void ShouldSellOnlyAlcohol()
        {
            // given
            var shop = new Shop();
            var dwarf = new DwarfSingle(1, Places.Shop);

            // when
            dwarf.Buy(shop, ItemsInShop.Alcohol);

            // then
            Assert.IsTrue(dwarf.PurchasedItems.ContainsKey(ItemsInShop.Alcohol));
            Assert.IsTrue(dwarf.PurchasedItems[ItemsInShop.Alcohol] == 1);
        }

        [Test]
        public void ShouldSellNone()
        {
            // given
            var shop = new Shop();
            var dwarf = new DwarfSluggard(1, Places.Shop);

            // when
            dwarf.Buy(shop);

            // then
            Assert.IsTrue(dwarf.PurchasedItems.ContainsKey(ItemsInShop.None));
            Assert.IsTrue(dwarf.PurchasedItems[ItemsInShop.None] == 1);
        }

        [Test]
        public void ShouldSellAmoundOfFoodEqualsHalfOfDailyPayment()
        {
            // Need to create builder for dwarfs!!!

            // given
            var shop = new Shop();
            var dwarf = new DwarfFather(1, Places.Shop);

            // when
            dwarf.Buy(shop, 50, ItemsInShop.Food);

            // then
            Assert.IsTrue(dwarf.PurchasedItems.ContainsKey(ItemsInShop.Food));
            Assert.IsTrue(dwarf.PurchasedItems[ItemsInShop.Food] == 50);
        }
    }
}