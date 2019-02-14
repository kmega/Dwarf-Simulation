using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class FatherShoppingStrategy : IShoppingStrategy
    {
        private BankAccount _bankAccount;
        public FatherShoppingStrategy(BankAccount bankAccount)
        {
            _bankAccount = bankAccount;
        }
        public void Buy()
        {
            throw new NotImplementedException();
        }
    }
}
