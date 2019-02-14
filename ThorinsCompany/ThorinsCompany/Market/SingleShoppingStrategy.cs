using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class SingleShoppingStrategy : IShoppingStrategy
    {
        private BankAccount _bankAccount;
        public SingleShoppingStrategy(BankAccount bankAccount)
        {
            _bankAccount = bankAccount;
        }
        public void Buy()
        {
            throw new NotImplementedException();
        }
    }
}
