using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public interface IBank
    {
       void ExchangeMaterialsForMoney(BankAccount bankAccount,List<Material> materials);
       void MakeTransaction(BankAccount accountForAddition, BankAccount accountForSubstraction, decimal moneyForTransaction);
    }
}