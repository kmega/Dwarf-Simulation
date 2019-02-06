using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Bank
{
    public class GeneralBank
    {
       private decimal BankAccount;

        public GeneralBank()
        {
            BankAccount = 0;
        }

        public void PayTax (decimal receipt)
        {
            BankAccount += (receipt * 23) / 100;
           
        }
    }
}
