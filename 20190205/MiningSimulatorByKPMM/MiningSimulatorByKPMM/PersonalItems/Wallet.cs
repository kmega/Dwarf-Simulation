using System;
namespace MiningSimulatorByKPMM.PersonalItems
{
    public class Wallet
    {
        public decimal DailyIncome { get; private set; }
        public decimal TotalMoney { get; private set; }

        public void SetDailyIncome(decimal income)
        {
           DailyIncome = income;
        }

        public void SetTotalMoney()
        {
            TotalMoney += DailyIncome;
        }
    }
}
