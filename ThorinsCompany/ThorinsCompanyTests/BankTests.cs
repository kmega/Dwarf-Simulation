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

            var accountID_1 = IDCreator.GetUniqueID();
            var accountID_2 = IDCreator.GetUniqueID();

            AccountCreator.CreateNewAccountWithUniqueID(accountID_1);
            AccountCreator.CreateNewAccountWithUniqueID(accountID_2);


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
    }
}
