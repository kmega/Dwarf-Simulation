using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Bank
{
    public class Bank
    {
       private decimal BankAccount;

        public Bank()
        {
            BankAccount = 0;
        }

        public void PayIntoYourAccount (decimal dailybankaccount, decimal daily)
        {
            dailybankaccount += daily;
        }

        public void PayTax (decimal receipt)
        {
            BankAccount += (receipt * 23) / 100;
        }

        public void SumUp (decimal overalaccount, decimal daily)
        {
            overalaccount += daily;
            daily = 0;
        }
    }
}
