using System;

namespace ThorinsCompany
{
    public class BankAccount
    {
        private decimal _money = 0;
        private decimal _dailyIncome = 0;

        public void TopUp(decimal moneyToTopUpAccount)
        {
            _money += moneyToTopUpAccount;
            _dailyIncome += moneyToTopUpAccount;
        }

        public bool CanGetMoneyFromAccount(decimal moneyToDraw)
        {
            if (_money - moneyToDraw < 0)
                return false;
            else
            {
                _money -= moneyToDraw;
                return true;
            }
                
        }

        public void ResetDailyIncome()
        {
            _dailyIncome = 0;
        }

        public decimal GetDailyIncome()
        {
            return _dailyIncome;
        }
    }
}