using System.Collections.Generic;

namespace Mine2._0
{
    public interface IBuyStrategy
    {
        void ExecuteShopping(decimal account, Dictionary<E_MarketPlace_Products, decimal> marketStats, IOutputWriter _presenter);
    }
}
