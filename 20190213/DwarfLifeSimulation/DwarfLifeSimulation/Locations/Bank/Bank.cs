using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Locations.Bank
{
    class Bank
    {
        private Dictionary<int, BankAccount> accounts;
        private BankAccount generalAccount;
        private Bank()
        {
            accounts = new Dictionary<int, BankAccount>();
            generalAccount = new BankAccount();
        }
        private static Bank instance = null;

        public static Bank Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Bank();
                }
                return instance;
            }
        }

        public decimal GetDailyIncome(int customerAccountId)
        {
            return accounts[customerAccountId].DailyIncome;
        }

        public void Transfer(int customerAccountId, int shopAccountId, decimal howMuchISpent)
        {
            accounts[customerAccountId].DailyIncome -= howMuchISpent;
            accounts[shopAccountId].DailyIncome += howMuchISpent;
        }

        public void PayTax(int id)
        {
            var income = accounts[id].DailyIncome;
            var tax = income * 0.23m;
            generalAccount.OverallMoney += tax;
            accounts[id].OverallMoney += (income - tax);
            accounts[id].DailyIncome = 0.0m;
        }

        public int CreateAccount()
        {
            int newId = accounts.Count + 1;
            accounts.Add(newId, new BankAccount());
            return newId;
        }

    }
}
