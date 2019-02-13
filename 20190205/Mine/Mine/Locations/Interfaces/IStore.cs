using System.Collections.Generic;
using Mine.Dwarfs;

namespace Mine.Locations.Interfaces
{
    interface IStore
    {
        IBankAccount BancAccount { get;  }
        void PerformShopping(List<IDwarf> dwarfs);
        void BuyProductsFromMarket(List<IDwarf> customers);


    }
}
