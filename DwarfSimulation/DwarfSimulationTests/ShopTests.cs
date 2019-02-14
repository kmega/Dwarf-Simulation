using NUnit.Framework;
using DwarfSimulation;
using System.Collections.Generic;

namespace ShopTests
{
    public class ShopTests
    {
        [Test]
        public void FatherDwarFBuyFoodInShop()
        {
            // GIVEN
            Dwarf fatherDwarf = new Dwarf() { BuyAction = new FatherBuyStrategy(), Wallet = 100 };
            Shop shop = new Shop();

            // WHEN
            fatherDwarf.BuyAtShop(shop);

            // THEN
            int foodBought = shop.SoldFoodValue();
            int alcoholBought = shop.SoldAcoholValue();

            Assert.AreEqual(0, alcoholBought);
            Assert.AreEqual(1, foodBought);
        }

        [Test]
        public void SingleDwarFBuyAlcoholInShop()
        {
            // GIVEN
            Dwarf singleDwarf = new Dwarf() { BuyAction = new SingleBuyStrategy(), Wallet = 100 };
            Shop shop = new Shop();

            // WHEN
            singleDwarf.BuyAtShop(shop);

            // THEN
            int foodBought = shop.SoldFoodValue();
            int alcoholBought = shop.SoldAcoholValue();

            Assert.AreEqual(1, alcoholBought);
            Assert.AreEqual(0, foodBought);
        }

        [Test]
        public void LazyDwarFDontBuyProductsInShop()
        {
            // GIVEN
            Dwarf lazyDwarf = new Dwarf() { BuyAction = new LazyBuyStrategy(), Wallet = 100 };
            Shop shop = new Shop();

            // WHEN
            lazyDwarf.BuyAtShop(shop);

            // THEN
            int productsBought = shop.SoldAcoholValue() + shop.SoldFoodValue();
            Assert.AreEqual(0, productsBought);
        }

        [Test]
        public void ShopEarnMoneyWhenSoldProductsToDwarves()
        {
            // GIVEN
            List<Dwarf> listOfDwarves = new List<Dwarf>()
            {
                new Dwarf() {BuyAction = new FatherBuyStrategy(),Wallet = 50},
                new Dwarf() {BuyAction = new SingleBuyStrategy(),Wallet = 50},
                new Dwarf() {BuyAction = new FatherBuyStrategy(),Wallet = 50},
            };

            Shop shop = new Shop();

            // WHEN
            shop.ServeEveryone(listOfDwarves);

            // THEN
            decimal shopEarned = shop.SaleValue();
            Assert.AreEqual(75, shopEarned);
        }


        [Test]
        public void ShopSellDiferentProductsToDiferentDwarves()
        {
            // GIVEN
            List<Dwarf> listOfDwarves = new List<Dwarf>()
            {
                new Dwarf() {BuyAction = new FatherBuyStrategy(),Wallet = 50},
                new Dwarf() {BuyAction = new SingleBuyStrategy(),Wallet = 50},
                new Dwarf() {BuyAction = new LazyBuyStrategy(),Wallet = 50},
            };

            Shop shop = new Shop();

            // WHEN
            shop.ServeEveryone(listOfDwarves);

            // THEN
            int foodBought = shop.SoldFoodValue();
            int alcoholBought = shop.SoldAcoholValue();

            Assert.AreEqual(1, alcoholBought);
            Assert.AreEqual(1, foodBought);
        }




    }
}
