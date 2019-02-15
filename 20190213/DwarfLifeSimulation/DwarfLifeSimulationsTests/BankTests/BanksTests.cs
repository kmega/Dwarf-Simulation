using Moq;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Banks;
using System.Reflection;
using System;

namespace DwarfLifeSimulationsTests.BankTests
{
    public class BankMock : Bank
    {
        public BankMock(Dictionary<int, BankAccount> Accounts, BankAccount GeneralAccount)
        {
            this.Accounts = Accounts;
            this.GeneralAccount = GeneralAccount;
        }    
    }

    [TestFixture]
    public class BanksTests
    {
        private BankAccount bankAccount;
        private BankAccount dwarfAccount;
        private BankAccount shopAccount;
        private Dictionary<int, BankAccount> accounts;

        [SetUp]
        public void Setup()
        {
            bankAccount = new BankAccount();
            dwarfAccount = new BankAccount();
            shopAccount = new BankAccount();
            accounts = new Dictionary<int, BankAccount>()
            {
                { 1, shopAccount },
                { 2, dwarfAccount }
            };
        }

        [Test]
        public void DwarfBuySomething_BankTransferMoneyFromDwarfToReceiverAndCollectTax()
        {
            // given
            var bankMock = new BankMock(accounts, bankAccount);
            bankMock.PayIntoAccount(2, 30);

            // when
            bankMock.Transfer(2, 1, 20);
            bankMock.PayTax(1);

            //then
            Assert.AreEqual(expected: dwarfAccount.DailyIncome, actual: 10m);
            Assert.AreEqual(expected: shopAccount.OverallMoney, actual: 15.4m);
            Assert.AreEqual(expected: bankAccount.OverallMoney, actual: 4.6m);
        }
        
    }
}