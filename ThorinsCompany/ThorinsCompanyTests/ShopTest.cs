using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ThorinsCompany;

namespace ThorinsCompanyTests
{
    public class ShopTest
    {
        private Bank _bank;
        [SetUp]
        public void Setup()
        {
            _bank = new Bank();
        }
        [Test]
        public void ShouldPayHalfMoneyForProductWhenFatherShoppingStrategyIsActive()
        {
            //given
            Shop shop = new Shop();
            BankAssistant.TopUpYourAccount(shop.accountID, 100);
            Dwarf dwarf = new Dwarf(DwarfType.Father,null,null);
            dwarf.ShoppingStrategy = new FatherShoppingStrategy(dwarf.accountID);
            BankAssistant.TopUpYourAccount(dwarf.accountID, 500);
            //expected
            decimal dwarfMoneyExpected = 250;
            decimal shopMoneyExpected = 350;

            //when
            shop.PerformShopping(dwarf.ShoppingStrategy);

            //then
            decimal dwarfMoneyActual = BankAssistant.CheckMoneyOnAccount(dwarf.accountID);
            decimal shopMoneyActual = BankAssistant.CheckMoneyOnAccount(shop.accountID);
            Assert.AreEqual(dwarfMoneyExpected, dwarfMoneyActual);
            Assert.AreEqual(shopMoneyExpected, shopMoneyActual);
        }
        [Test]
        public void ShouldPayHalfMoneyForProductWhenSingleShoppingStrategyIsActive()
        {
            //given
            Shop shop = new Shop();
            BankAssistant.TopUpYourAccount(shop.accountID, 100);
            Dwarf dwarf = new Dwarf(DwarfType.Father, null, null);
            dwarf.ShoppingStrategy = new SingleShoppingStrategy(dwarf.accountID);
            BankAssistant.TopUpYourAccount(dwarf.accountID, 500);
            //expected
            decimal dwarfMoneyExpected = 250;
            decimal shopMoneyExpected = 350;

            //when
            shop.PerformShopping(dwarf.ShoppingStrategy);

            //then
            decimal dwarfMoneyActual = BankAssistant.CheckMoneyOnAccount(dwarf.accountID);
            decimal shopMoneyActual = BankAssistant.CheckMoneyOnAccount(shop.accountID);
            Assert.AreEqual(dwarfMoneyExpected, dwarfMoneyActual);
            Assert.AreEqual(shopMoneyExpected, shopMoneyActual);
        }

        [Test]
        public void ShouldNotChangeDwarfAndMarketStatetWhenLazyShoppingStrategyIsActive()
        {
            //given
            Shop shop = new Shop();
            BankAssistant.TopUpYourAccount(shop.accountID, 100);
            Dwarf dwarf = new Dwarf(DwarfType.Lazy,null,null);
            dwarf.ShoppingStrategy = new LazyShoppingStrategy(dwarf.accountID);
            BankAssistant.TopUpYourAccount(dwarf.accountID, 500);
            //expected
            decimal dwarfMoneyExpected = 500;
            decimal shopMoneyExpected = 100;

            //when
            shop.PerformShopping(dwarf.ShoppingStrategy);

            //then
            decimal dwarfMoneyActual = BankAssistant.CheckMoneyOnAccount(dwarf.accountID);
            decimal shopMoneyActual = BankAssistant.CheckMoneyOnAccount(shop.accountID);
            Assert.AreEqual(dwarfMoneyExpected, dwarfMoneyActual);
            Assert.AreEqual(shopMoneyExpected, shopMoneyActual);
        }
    }
}
