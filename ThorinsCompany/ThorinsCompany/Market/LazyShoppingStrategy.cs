using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class LazyShoppingStrategy : IShoppingStrategy
    {
        private BankAccount _bankAccount;
        public LazyShoppingStrategy(BankAccount bankAccount)
        {
            _bankAccount = bankAccount;
        }
        public void Buy()
        {
            throw new NotImplementedException();
        }
    }
}
