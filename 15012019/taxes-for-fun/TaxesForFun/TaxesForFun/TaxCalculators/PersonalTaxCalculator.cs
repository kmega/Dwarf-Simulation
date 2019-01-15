using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    public class PersonalTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            if (receivedMoney > 85528)
            {
                return (int)(receivedMoney * 0.32);
            }
            else
            {
                return (int)((receivedMoney - 8000) * 0.18);
            }
        }
    }
}
