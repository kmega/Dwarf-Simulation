using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ThorinsCompany;

namespace ThorinsCompanyTests
{
    public class ShopTest
    {
        Bank bank = new Bank();

        [Test]
        public void WhenDwarfFatherVisitsShopThenShopAccountIncreasesForHalfDwarfMoney()
        {
            // Given
            Shop shop = new Shop();
            shop.GetBankAccount().TopUpYourAccount(100);
            Dwarf dwarf = new Dwarf(DwarfType.Father, new FatherShoppingStrategy(), null);
            dwarf.GetBankAccount().TopUpYourAccount(200);
            decimal expectedDwarfMoney = 100;
            decimal expectedShopMoney = 200;
            
            // when
            shop.PerformShopping(dwarf);

            //then
            decimal actualDwarfMoney = dwarf.GetBankAccount().CheckMoneyOnAccount();
            decimal actualShopMoney = shop.GetBankAccount().CheckMoneyOnAccount();
            Assert.AreEqual(expectedDwarfMoney, actualDwarfMoney);
            Assert.AreEqual(expectedShopMoney, actualShopMoney);
        }

        [Test]
        public void WhenDwarfSingleVisitsShopThenShopAccountIncreasesForHalfDwarfMoney()
        {
            // Given
            Shop shop = new Shop();
            shop.GetBankAccount().TopUpYourAccount(100);
            Dwarf dwarf = new Dwarf(DwarfType.Single, new SingleShoppingStrategy(), null);
            dwarf.GetBankAccount().TopUpYourAccount(200);
            decimal expectedDwarfMoney = 100;
            decimal expectedShopMoney = 200;

            // when
            shop.PerformShopping(dwarf);

            //then
            decimal actualDwarfMoney = dwarf.GetBankAccount().CheckMoneyOnAccount();
            decimal actualShopMoney = shop.GetBankAccount().CheckMoneyOnAccount();
            Assert.AreEqual(expectedDwarfMoney, actualDwarfMoney);
            Assert.AreEqual(expectedShopMoney, actualShopMoney);
        }
        [Test]
        public void WhenDwarfLazyVisitsShopThenShopAccountDoesntChange()
        {
            // Given
            Shop shop = new Shop();
            shop.GetBankAccount().TopUpYourAccount(100);
            Dwarf dwarf = new Dwarf(DwarfType.Lazy, new LazyShoppingStrategy(), null);
            dwarf.GetBankAccount().TopUpYourAccount(200);
            decimal expectedDwarfMoney = 200;
            decimal expectedShopMoney = 100;

            // when
            shop.PerformShopping(dwarf);

            //then
            decimal actualDwarfMoney = dwarf.GetBankAccount().CheckMoneyOnAccount();
            decimal actualShopMoney = shop.GetBankAccount().CheckMoneyOnAccount();
            Assert.AreEqual(expectedDwarfMoney, actualDwarfMoney);
            Assert.AreEqual(expectedShopMoney, actualShopMoney);
        }
    }

}
