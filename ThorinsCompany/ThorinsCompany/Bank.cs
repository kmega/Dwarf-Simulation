using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class Bank : IBank
    {
        public void ExchangeMaterialsForMoney(BankAccount bankAccount, List<Material> materials)
        {
            throw new NotImplementedException();
        }

        public void MakeTransaction(BankAccount accountForAddition, BankAccount accountForSubstraction)
        {
            throw new NotImplementedException();
        }
    }
}
