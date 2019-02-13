using System;
using System.Collections.Generic;
using System.Text;

namespace Mine
{
    interface IStore
    {
        IBankAccount BancAccount { get;  }
        void PerformShopping(List<IDwarf> dwarfs);
        void BuyProductsFromMarket(List<IDwarf> customers, IBank bank);


    }
}
