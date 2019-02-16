using System;
using System.Collections.Generic;
using System.Text;
using ThorinsCompany;

namespace ThorinsCompany
{
    public class AccountCreator
    {
        private static Bank _bank;

        public  AccountCreator(Bank bank)
        {
            _bank = bank;
        }

        public static BankAccount CreateNewAccount(int ID)
        {
            var newAccount = new BankAccount();
            _bank.CreateAccount(newAccount, ID);
            return newAccount;
        }

    }
}
