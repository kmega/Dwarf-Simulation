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
            Assert.AreEqual(expected: shopAccount.DailyIncome, actual: 15.4m);
            Assert.AreEqual(expected: bankAccount.DailyIncome, actual: 4.6m);
            // Assert.AreEqual(expected: shopAccount.OverallMoney, actual: 15.4m);
            // Assert.AreEqual(expected: bankAccount.OverallMoney, actual: 4.6m);
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
                Assert.AreEqual(bankMock.GetDailyIncome(account.Key), expected);
            }
        }

        [TestCase(150, 115.5)]
        [TestCase(200, 154)]
        [TestCase(250, 192.5)]
        [TestCase(300, 231)]
        [TestCase(350, 269.5)]
        [TestCase(400, 308)]
        [TestCase(450, 346.50)]
        [TestCase(500, 385)]
        [TestCase(550, 423.5)]
        [TestCase(600, 462)]
        public void BankCollectTaxes(decimal actual, decimal expected)
        {
            // given
            accounts = new Dictionary<int, BankAccount>();
            accounts.Add(1, new BankAccount());
            accounts[1].DailyIncome = actual;
            bankAccount = new BankAccount();
            bankMock = new BankMock(accounts, bankAccount);

            // when
            bankMock.PayTax(1);

            // then
            Assert.AreEqual(bankAccount.DailyIncome, actual * 0.23m);
            Assert.AreEqual(accounts[1].DailyIncome, expected);
        }
        
        [Test]
        public void BankCreated15AccountsAndCheckTheirIds()
        {
            // given
            accounts = new Dictionary<int, BankAccount>();
            bankAccount = new BankAccount();
            bankMock = new BankMock(accounts, bankAccount);

            // when
            for (int i = 1; i <= 15; i++)
            {
                bankMock.CreateAccount();
                accounts[i].DailyIncome = i;
            }

            // then
            Assert.IsTrue(accounts.Count == 15);
            for (int i = 1; i <= 15; i++)
                Assert.AreEqual(accounts[i].DailyIncome, i);
        }

        [Test]
        public void CheckIfSumOfCollectTaxesAre()
        {
            // given
            var actual = 150m;
            var expected = 862.5m;
            accounts = new Dictionary<int, BankAccount>();
            for (int i = 1; i <= 10; i++)
            {
                accounts.Add(i, new BankAccount());
                accounts[i].DailyIncome = actual;
                actual += 50m;
            }
            bankAccount = new BankAccount();
            bankMock = new BankMock(accounts, bankAccount);

            // when
            foreach(var account in accounts)
                bankMock.PayTax(account.Key);

            // then
            Assert.AreEqual(bankAccount.DailyIncome, expected);
        }

        [Test]
        public void BankTransferSaving()
        {
            // given
            var actual = 150m;
            var expectedBank = 862.5m;
            var expected = 115.5m;
            accounts = new Dictionary<int, BankAccount>();
            for (int i = 1; i <= 10; i++)
            {
                accounts.Add(i, new BankAccount());
                accounts[i].DailyIncome = actual;
                actual += 50m;
            }
            bankAccount = new BankAccount();
            bankMock = new BankMock(accounts, bankAccount);

            // when
            foreach(var account in accounts)
                bankMock.PayTax(account.Key);
            bankMock.TransferSavings();

            // then
            Assert.AreEqual(bankAccount.OverallMoney, expectedBank);
            foreach(var account in accounts)
            {
                Assert.AreEqual(account.Value.OverallMoney, expected);
                expected += 38.5m;
            }
        }
    }
}