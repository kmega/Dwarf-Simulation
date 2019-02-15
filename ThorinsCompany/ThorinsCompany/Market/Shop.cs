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
        public void PerformShopping(IShoppingStrategy shoppingStrategy)
        {
            shoppingStrategy.Pay(accountID);
        }

        public void PerformShoppingForAllDwarves(List<Dwarf> dwarves)
        {
            foreach(Dwarf dwarf in dwarves)
            {
                PerformShopping(dwarf.ShoppingStrategy);
            }
        }
    }
}
