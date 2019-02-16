using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class Shop
    {
        public readonly int accountID;
        private BankAccount _bankAccount;
        public Shop()
        {
            accountID = IDCreator.GetUniqueID();
            _bankAccount = AccountCreator.CreateNewAccount(accountID);

        }
        public void PerformShopping(Dwarf dwarf)
        {
            dwarf.Buy(_bankAccount);
        }

        public void PerformShoppingForAllDwarves(List<Dwarf> dwarves)
        {
            foreach(Dwarf dwarf in dwarves)
            {
                PerformShopping(dwarf);
            }
        }
        public BankAccount GetBankAccount() => _bankAccount;

    }
}
