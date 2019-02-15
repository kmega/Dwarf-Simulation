using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Locations.Banks
{
    public class Bank
    {
        private Dictionary<int, BankAccount> accounts;
        private BankAccount generalAccount;

        protected Dictionary<int, BankAccount> Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }

        protected BankAccount GeneralAccount
        {
            get { return generalAccount; }
            set { generalAccount = value; }
        }

        protected Bank()
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

        public decimal GetDailyIncome(int accountId)
        {
            return accounts[accountId].DailyIncome;
        }

		public decimal GetOverallAccountMoney(int customerAccountId)
		{
			return accounts[customerAccountId].OverallMoney;
		}

		public void Transfer(int fromAccountId, int toAccountId, decimal howMuchISpent)
        {
            accounts[fromAccountId].DailyIncome -= howMuchISpent;
            accounts[toAccountId].DailyIncome += howMuchISpent;
        }

        public void PayTax(int id)
        {
            var income = accounts[id].DailyIncome;
            var tax = income * 0.23m;
            generalAccount.DailyIncome += tax;
            accounts[id].DailyIncome = (income - tax);
            // generalAccount.OverallMoney += tax;
            // accounts[id].OverallMoney += (income - tax);
            // accounts[id].DailyIncome = 0.0m;
        }

        public int CreateAccount()
        {
            int newId = accounts.Count + 1;
            accounts.Add(newId, new BankAccount());
            return newId;
        }

        public void PayIntoAccount(int id, decimal income)
        {
            accounts[id].DailyIncome = income;
        }

        public void TransferSavings()
        {
            foreach(var account in accounts)
            {
                account.Value.OverallMoney += account.Value.DailyIncome;
                account.Value.DailyIncome = 0m;
            }

            generalAccount.OverallMoney += generalAccount.DailyIncome;
            generalAccount.DailyIncome = 0m;
        }
		public int GetNumbersOfAccounts()
		{
			return accounts.Count;
		}
    }
}
