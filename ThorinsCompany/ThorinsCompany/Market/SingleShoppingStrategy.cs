using System;
using System.Collections.Generic;
using System.Text;
using ThorinsCompany.Raports;

namespace ThorinsCompany
{
    public class SingleShoppingStrategy : IShoppingStrategy
    {
        private readonly int _dwarfAccountID;
        public SingleShoppingStrategy(int dwarfAccountID)
        {
            _dwarfAccountID = dwarfAccountID;
        }

        public void Pay(int shopAccountID)
        {
            decimal charge = BankAssistant.CheckMoneyOnAccount(_dwarfAccountID) / 2;
            BankAssistant.MakeTransaction(shopAccountID, _dwarfAccountID, charge);
            Logger.GetInstance().AddLog("SHOP: Dwarf bough Food");
        }
    }
}
