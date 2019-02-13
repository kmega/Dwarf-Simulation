using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Locations.Bank
{
    class Bank
    {
        private Dictionary<int, BankAccount> Accounts;

        private Bank()
        {
            Accounts = new Dictionary<int, BankAccount>();
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

        public int CreateAccount()
        {
            int newId = Accounts.Count + 1;
            Accounts.Add(newId, new BankAccount());
            return newId;
        }

    }
}
