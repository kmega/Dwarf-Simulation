using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class AccountCreator
    {
        private static Bank _bank;

        public  AccountCreator(Bank bank)
        {
            _bank = bank;
        }

        public static void CreateNewAccountWithUniqueID(int ID)
        {
            _bank.CreateAccount(new BankAccount(), ID);
        }

    }
}
