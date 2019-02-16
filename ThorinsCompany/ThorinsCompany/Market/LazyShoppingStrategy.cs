using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class LazyShoppingStrategy : IShoppingStrategy
    {
        public void Buy(BankAccount dwarfBankAccount, BankAccount bankAccountToTopUp)
        {
            // Do nothing , Too lazy to buy
        }
    }
}
