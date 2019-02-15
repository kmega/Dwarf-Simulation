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
        public void MakeTransactionFor50_TopUpAccountToHave200FromAccountThatHas100()
        {
            //given
            Bank bank = new Bank();
            decimal transactionMoney = 50;

            var accountID_1 = AccountCreator.CreateNewAccountWithUniqueID();       
            var accountID_2 = AccountCreator.CreateNewAccountWithUniqueID();


            //when,then
            bank.TopUpYourAccount(accountID_1,150);
            bank.TopUpYourAccount(accountID_2,100);

            Assert.AreEqual(150, bank.CheckYourDailyIncome(accountID_1));
            Assert.AreEqual(100, bank.CheckYourDailyIncome(accountID_2));


            //when,then
            bank.MakeTransaction(accountIDForAddition: accountID_1,
               accountIDForSubtraction: accountID_2,
               moneyForTransaction: transactionMoney);

            Assert.AreEqual(200, bank.CheckYourDailyIncome(accountID_1));
            Assert.AreEqual(100, bank.CheckYourDailyIncome(accountID_2));

            //when, then
            bank.ResetDailyIncomeOfAccounts();

            Assert.AreEqual(0, bank.CheckYourDailyIncome(accountID_1));
            Assert.AreEqual(0, bank.CheckYourDailyIncome(accountID_2));


        }

        [Test]
        public void ExchangeMaterialOfAllDwarfsToMoney_EachDwarfShouldHave25OnAccount()
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
                Assert.IsTrue(bank.CheckMoneyOnAccount(dwarf.accountID) > 0);
            }
        }


    }
}
