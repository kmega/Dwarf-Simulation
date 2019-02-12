using System;
using System.Collections.Generic;
using System.Text;
using MiningSimulatorByKPMM.Locations.Bank;
using NUnit.Framework;

namespace SimulationTests.Bank_Tests
{
    public class BankAccountTest
    {
        BankAccount bankAccount;

        [SetUp]
        public void Setup()
        {
            bankAccount = new BankAccount();

        }

        [Test]
        public void ShouldMoveMoneyFromDailyToAccount()
        {
            //given
            bankAccount.ReceivedMoney(100);

            //when
            bankAccount.SendLastIncomeToYourAccount();

            //then
            Assert.AreEqual(100, bankAccount.OverallAccount);

        }

        [Test]
        public void ShouldDecreaseMoneyOnAccount()
        {
            //given
            bankAccount.ReceivedMoney(100);

            //when
            bankAccount.Withdraw(20);
            bankAccount.SendLastIncomeToYourAccount();

            //then
            Assert.AreEqual(80, bankAccount.OverallAccount);

        }



    }
}
