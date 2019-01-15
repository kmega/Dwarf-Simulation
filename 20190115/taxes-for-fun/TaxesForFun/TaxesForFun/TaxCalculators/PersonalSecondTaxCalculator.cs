using System;

namespace TaxesForFun.TaxCalculators
{
    internal class PersonalSecondTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            return (int)((receivedMoney) * 0.32);
            //throw new NotImplementedException("Implement me for happiness and joy!");
        }
    }
}