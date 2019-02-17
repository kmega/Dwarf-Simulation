using System;
using System.Collections.Generic;

namespace Mine2._0
{
    public class MarketPlace
    {
        private PersonalBankAccount _marketAccount = new PersonalBankAccount();

        private readonly Dictionary<E_MarketPlace_Products, decimal> _marketStats = new Dictionary<E_MarketPlace_Products, decimal>
        {
            {E_MarketPlace_Products.Alcohol, 0},
            {E_MarketPlace_Products.Food, 0}
        };

        public void PerformShopping(List<IBuy> buyers, IOutputWriter _presenter)
        {
            _marketAccount._overallIncome = 0;
            foreach (var buyer in buyers)
            {
                decimal moneyToSpend = Math.Round(buyer.GetDailyWageToSpend(),2);
                _marketAccount._overallIncome += moneyToSpend;
                buyer.Buy(moneyToSpend, _marketStats, _presenter);
                buyer.SetNewDailyAfterTransaction(moneyToSpend);
            }
        }

        public Dictionary<E_MarketPlace_Products, decimal> GetStats()
        {
            return _marketStats;
        }

        public decimal GetOverAllAccount() => _marketAccount._overallIncome;
    }
}
