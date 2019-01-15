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
            int taxlevel = 85528;

            if (receivedMoney < taxlevel)
            {


                expectedtax = (int)((receivedMoney - taxCredit) * 0.18);
            }
            else
            {
                expectedtax += (int)((taxlevel - taxCredit) * 0.18);

                expectedtax += (int)((receivedMoney - taxlevel) * 0.32);
                
            }
            return expectedtax;
           

        }
    }
}
