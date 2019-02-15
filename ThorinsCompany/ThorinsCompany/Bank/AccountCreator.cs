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

        public static int CreateNewAccountWithUniqueID()
        {
            int ID = IDCreator.GetUniqueID();
            _bank.CreateAccount(new BankAccount(), ID);
            return ID;
        }

    }
}
