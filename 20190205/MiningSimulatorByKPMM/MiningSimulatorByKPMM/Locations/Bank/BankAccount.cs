using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Bank
{
   public class BankAccount
    {
        public decimal OverallAccount { get; private set; }
        public decimal LastInput { get; private set; }

        public BankAccount()
        {
            OverallAccount = 0.0m;
            LastInput = 0.0m;
        }
        public void SetDailyIncome(decimal income)
        {
            LastInput = income;
        }
        public void CalculateOverallAccount()
        {
            OverallAccount += LastInput;
        }
    }
}
