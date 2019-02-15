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
        private BankMock bankMock;
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
        }

        [Test]
        public void DwarfBuySomething_BankTransferMoneyFromDwarfToReceiverAndCollectTax()
        {
            // given
            accounts = new Dictionary<int, BankAccount>()
            {
                { 1, shopAccount },
                { 2, dwarfAccount }
            };
            dwarfAccount.DailyIncome = 30;
            bankMock = new BankMock(accounts, bankAccount);

            // when
            bankMock.Transfer(2, 1, 20);
            bankMock.PayTax(1);

            //then
            Assert.AreEqual(expected: dwarfAccount.DailyIncome, actual: 10m);
            Assert.AreEqual(expected: shopAccount.OverallMoney, actual: 15.4m);
            Assert.AreEqual(expected: bankAccount.OverallMoney, actual: 4.6m);
        }

        [Test]
        public void TenDwarfsReceivedPaymentIntoBankAccount()
        {
            // given
            accounts = new Dictionary<int, BankAccount>();
            for (int i = 1; i <= 10; i++)
                accounts.Add(i, new BankAccount());

            bankAccount = new BankAccount();
            bankMock = new BankMock(accounts, bankAccount);
            var payment = 1634m;
            var expected = 1634m;

            // then
            foreach(var account in accounts)
            {
                if(account.Key % 2 == 0)
                    payment += 150m;
                bankMock.PayIntoAccount(account.Key, payment);
            }

            // then
            foreach(var account in accounts)
            {
                if(account.Key % 2 == 0)
                    expected += 150m;
                Assert.AreEqual(account.Value.DailyIncome, expected);
            }
        }

        [Test]
        public void BankCollectTaxes()
        {
            // given
            var assets = 150m;
            var expected = 115.5m;
            accounts = new Dictionary<int, BankAccount>();
            for (int i = 1; i <= 10; i++)
            {
                accounts.Add(i, new BankAccount());
                accounts[i].DailyIncome = assets;
                assets += 50m;
            }

            bankAccount = new BankAccount();
            bankMock = new BankMock(accounts, bankAccount);

            // when
            foreach(var account in accounts)
                bankMock.PayTax(account.Key);

            // then
            Assert.AreEqual(bankAccount.OverallMoney, 862.5m);
            foreach(var account in accounts)
            {
                Assert.AreEqual(account.Value.OverallMoney, expected);
                expected += 38.5m;
            }
            // Assert.AreEqual(accounts[1].OverallMoney, 115.5m);
            // Assert.AreEqual(accounts[2].OverallMoney, 154m);
            // Assert.AreEqual(accounts[3].OverallMoney, 192.5m);
            // Assert.AreEqual(accounts[4].OverallMoney, 231m);
            // Assert.AreEqual(accounts[5].OverallMoney, 269.5m);
            // Assert.AreEqual(accounts[6].OverallMoney, 308m);
            // Assert.AreEqual(accounts[7].OverallMoney, 346.5m);
            // Assert.AreEqual(accounts[8].OverallMoney, 385m);
            // Assert.AreEqual(accounts[9].OverallMoney, 423.5m);
            // Assert.AreEqual(accounts[10].OverallMoney, 462m);
        }
        
    }
}