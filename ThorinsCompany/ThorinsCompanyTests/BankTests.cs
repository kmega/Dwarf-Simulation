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
            BankAccount bankAccount_1 = new BankAccount();
            BankAccount bankAccount_2 = new BankAccount();
            decimal transactionMoney = 50;

            Assert.IsFalse(bankAccount_2.CanGetMoneyFromAccount(transactionMoney));

            //when,then
            bankAccount_1.TopUp(150);
            bankAccount_2.TopUp(100);

            Assert.AreEqual(150, bankAccount_1.GetDailyIncome());
            Assert.IsTrue(bankAccount_2.CanGetMoneyFromAccount(transactionMoney));


            //when,then
            bank.MakeTransaction(accountForAddition: bankAccount_1,
                accountForSubstraction: bankAccount_2, 
                moneyForTransaction: transactionMoney);

            Assert.AreEqual(200, bankAccount_1.GetDailyIncome());
            Assert.AreEqual(100, bankAccount_2.GetDailyIncome());

            //when, then
            bankAccount_1.ResetDailyIncome();
            bankAccount_2.ResetDailyIncome();

            Assert.AreEqual(0, bankAccount_1.GetDailyIncome());
            Assert.AreEqual(0, bankAccount_2.GetDailyIncome());


        }
    }
}
