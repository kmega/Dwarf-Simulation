using System.Collections.Generic;

namespace Mine2._0
{
    public interface IBuy
    {
        void Buy(decimal account, Dictionary<E_MarketPlace_Products, decimal>  marketStats, IOutputWriter _presenter);
        decimal GetDailyWageToSpend();
        void SetNewDailyAfterTransaction(decimal rest);
    }
}
