using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    public class PersonalTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            var taxCredit = 8000;
            return (int)((receivedMoney - taxCredit) * 0.18);
        }
    }
}
