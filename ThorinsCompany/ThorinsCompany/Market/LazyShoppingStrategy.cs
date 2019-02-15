using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class LazyShoppingStrategy : IShoppingStrategy
    {
        private readonly int _dwarfAccountID;
        public LazyShoppingStrategy(int dwarfAccountID)
        {
            _dwarfAccountID = dwarfAccountID;
        }

        public void Pay(int shopAccountID)
        {
            // Do nothing
        }
    }
}
