using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    public class PersonalTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            //throw new NotImplementedException("Implement me for happiness and joy!");
            return (int)(receivedMoney * 0.18);
        }
    }
}
