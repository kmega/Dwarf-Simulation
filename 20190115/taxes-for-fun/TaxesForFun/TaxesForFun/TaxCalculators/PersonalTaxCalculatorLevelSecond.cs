using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    public class PersonalTaxCalculatorLevelSecond : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
           
            int expectedTax = (int)(receivedMoney * 0.32);
            return expectedTax;

        }
    }
}
