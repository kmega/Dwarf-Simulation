using System;
using System.Collections.Generic;
using System.Text;
using ThorinsCompany.Raports;

namespace ThorinsCompany
{
    public class FatherShoppingStrategy : IShoppingStrategy
    {
        public void Buy(BankAccount dwarfBankAccount, BankAccount bankAccountToTopUp)
        {
            decimal moneyForTransaction = dwarfBankAccount.CheckMoneyOnAccount() / 2;
            dwarfBankAccount.MakeTransaction(bankAccountToTopUp, moneyForTransaction);
        }
    }
}
