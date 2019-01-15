using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    public class PersonalTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            int expectedtax = 0;
            int taxCredit = 8000;
            int taxLevel = 85528;

            
            if (receivedMoney < taxLevel)
            {
                receivedMoney -= taxCredit;

                expectedtax = (int)(receivedMoney * 0.18);
            }
            else
            {
                receivedMoney -= taxCredit;
                expectedtax += (int)(taxLevel * 0.18);

                expectedtax += (int)((receivedMoney - taxLevel) * 0.32);
                
            }
            return expectedtax;
           

        }
    }
}
