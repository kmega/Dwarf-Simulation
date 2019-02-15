using DwarfsTown;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTownTests
{
    [TestClass]
    public class ShopAndBarTests
    {
        Shop shop = new Shop();
        [TestMethod]
        public void IsFatherDoShopForHalfOfMoney()
        {
            List<Dwarf> dwarfs = new List<Dwarf> { new Dwarf(TypeEnum.Father) };
            dwarfs[0].BankAccount.Moneys = 20;
            shop.DoShopping(dwarfs);
            decimal expected = 10;
            decimal result = dwarfs[0].BankAccount.Moneys;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void IsSingleDoShopForHalfOfMoney()
        {
            List<Dwarf> dwarfs = new List<Dwarf> { new Dwarf(TypeEnum.Single) };
            dwarfs[0].BankAccount.Moneys = 20;
            shop.DoShopping(dwarfs);
            decimal expected = 10;
            decimal result = dwarfs[0].BankAccount.Moneys;
            Assert.AreEqual(expected, result);
        }
        Bar bar = new Bar();
        [TestMethod]
        public void IsSupplySubstracted()
        {
            bar.SupplyOfFood = 200;
            List<Dwarf> dwarfs = new List<Dwarf> { new Dwarf(TypeEnum.Single) };
            int expected = 199;
            bar.FeedDwarfs(dwarfs);
            int result = bar.SupplyOfFood;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void IsSupplyDeliveryComes()
        {
            bar.SupplyOfFood = 3;
            List<Dwarf> dwarfs = new List<Dwarf> { new Dwarf(TypeEnum.Single) };
            int expected = 32;
            bar.FeedDwarfs(dwarfs);
            int result = bar.SupplyOfFood;
            Assert.AreEqual(expected, result);
        }
    }
}
