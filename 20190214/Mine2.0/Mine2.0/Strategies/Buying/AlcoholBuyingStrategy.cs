using System;
using System.Collections.Generic;

namespace Mine2._0
{
    public class AlcoholBuyingStrategy : IBuyStrategy
    {
        void IBuyStrategy.ExecuteShopping(decimal account, Dictionary<E_MarketPlace_Products, decimal> marketStats, IOutputWriter _presenter)
        {
            marketStats[E_MarketPlace_Products.Alcohol] += account; //amountOfFood;
            _presenter.WriteLine($"Dwarf bought alcohol for {account} money");
        }
    }
}
