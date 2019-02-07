using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Bank
{
    public class GeneralBank
    {
        private BankAccount bankAccount = new BankAccount();

        public void PayTax (decimal receipt)
        {
            bankAccount.ReceivedMoney(Math.Round(((receipt * 23) / 100),2));
            bankAccount.CalculateOverallAccount();
        }

        public decimal BankTresure()
        {
            return bankAccount.OverallAccount;
        }
    }
}
