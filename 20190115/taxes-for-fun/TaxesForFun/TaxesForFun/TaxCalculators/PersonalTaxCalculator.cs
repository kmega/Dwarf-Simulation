using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    public class PersonalTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            int taxCredit = 8000;
            if (receivedMoney < 85528)
            {
                double value = (receivedMoney - taxCredit) * 0.18;
                return (int)value;
            }
            else
            {
                double firtTaxLevel = (85528 - taxCredit) * 0.18;
                double secotsTaxLevel = (receivedMoney - 85528) * 0.32;
                return (int)firtTaxLevel + (int)secotsTaxLevel;
            }
        }
    }
}
