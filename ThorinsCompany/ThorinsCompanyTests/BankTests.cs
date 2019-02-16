using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using ThorinsCompany;

namespace ThorinsCompanyTests
{
    public class BankTests
    {
        Bank bank = new Bank();

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void ShouldGenerateUniqueID()
        {
            int ID_1 = IDCreator.GetUniqueID();
            int ID_2 = IDCreator.GetUniqueID();
            Assert.AreNotEqual(ID_1, ID_2);
        }

        [Test]
        public void DwarvesHasEmptyAccountsWhenCreated()
        {
            //given
            List<Dwarf> dwarves = new Hospital().CreateDwarves(10);
            decimal moneyToDraw = 0.01m;

            //when, then
            foreach (var dwarf in dwarves)
            {
                Assert.IsFalse(dwarf.GetBankAccount().CanGetMoneyFromAccount(moneyToDraw));
            }

        }

        [Test]
        public void DwarvesTopUpAccountsWithValueOf100_CheckDailyIncomeAndTotalMoneyAndResetDailyIncome()
        {
            //given
            List<Dwarf> dwarves = new Hospital().CreateDwarves(10);
            decimal moneyToTopUp = 100;

            //when
            foreach (var dwarf in dwarves)
            {
                dwarf.GetBankAccount().TopUp(moneyToTopUp);
            }

            //then
            foreach (var dwarf in dwarves)
            {
               Assert.AreEqual(moneyToTopUp, dwarf.GetBankAccount().CheckYourDailyIncome());
               Assert.AreEqual(moneyToTopUp, dwarf.GetBankAccount().CheckMoneyOnAccount());
  
            }

            //when
            bank.ResetDailyIncomeOfAccounts();

            //then
            foreach (var dwarf in dwarves)
            {
                Assert.AreEqual(0, dwarf.GetBankAccount().CheckYourDailyIncome());
                Assert.AreEqual(moneyToTopUp, dwarf.GetBankAccount().CheckMoneyOnAccount());

            }

        }

     

        [Test]
        public void ExchangeMaterialOfAllDwarfsToMoney_EachDwarfShouldHaveMoneyOnAccount()
        {
            //given
            Mock<IRamdomizerThorins> mithrilWorth25 = new Mock<IRamdomizerThorins>();
            mithrilWorth25.Setup(x => x.ReturnPriceMaterials(Material.Mithril)).Returns(25);
            List<Dwarf> dwarves = new Hospital().CreateDwarves(10);
            foreach (var dwarf in dwarves)
            {
                dwarf.ShowDiggedMaterials().Add(Material.Mithril, 1);
            }

            //when
            bank.ExchangeMaterialsForMoneyFromAllDwarves(dwarves);

            //then
            foreach (var dwarf in dwarves)
            {
                Assert.IsTrue(dwarf.GetBankAccount().CheckMoneyOnAccount() > 0);
            }
        }


    }
}
