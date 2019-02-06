using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Bank
{
    public class Bank
    {
       private decimal BankAccount;

        public static void PayIntoYourAccount (decimal bankaccount, decimal value)
        {
            bankaccount += value;
        }

        public static void PayTax (decimal receipt)
        {
           



        }


    }
}
