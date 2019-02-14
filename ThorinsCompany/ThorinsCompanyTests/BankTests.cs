using NUnit.Framework;
using ThorinsCompany;

namespace Tests
{
    public class BankTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void MakeTransactionFor50_TopUpAccountToHave200FromAccountThatHas100()
        {
            //given
            Bank bank = new Bank();
            AccountCreator accountCreator = new AccountCreator(bank);
            decimal transactionMoney = 50;

            AccountCreator.CreateNewAccountWithUniqueID(1);
            AccountCreator.CreateNewAccountWithUniqueID(2);


            //when,then
            bank.TopUpYourAccount(1,150);
            bank.TopUpYourAccount(2,100);

            Assert.AreEqual(150, bank.CheckYourDailyIncome(1));
            Assert.AreEqual(100, bank.CheckYourDailyIncome(2));


            //when,then
            bank.MakeTransaction(accountIDForAddition: 1,
               accountIDForSubtraction: 2,
               moneyForTransaction: transactionMoney);

            Assert.AreEqual(200, bank.CheckYourDailyIncome(1));
            Assert.AreEqual(100, bank.CheckYourDailyIncome(2));

            //when, then
            bank.ResetDailyIncomeOfAccounts();

            Assert.AreEqual(0, bank.CheckYourDailyIncome(1));
            Assert.AreEqual(0, bank.CheckYourDailyIncome(2));


        }
    }
}
