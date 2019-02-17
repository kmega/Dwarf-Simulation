using System;
using System.Collections.Generic;

namespace Mine2._0
{
    public class FoodBuyingStrategy : IBuyStrategy
    {
        void IBuyStrategy.ExecuteShopping(decimal account, Dictionary<E_MarketPlace_Products, decimal> marketStats, IOutputWriter _presenter)
        {
            decimal amountOfFood = Math.Round(account*0.5m, 2);
            account *= 0.5m;
            marketStats[E_MarketPlace_Products.Food] += amountOfFood;
            _presenter.WriteLine($"Dwarf bought food for {amountOfFood} money");
        }
    }
}
