using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    class TotalPersonalTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            if (receivedMoney <= 85528)
            {
                var taxCredit = 8000;
                return (int)((receivedMoney - taxCredit) * 0.18);
            }
            else
            {
               
                var firstLevel = (int)((85528 - 8000) * 0.18);
                var secondLevel = (int)((receivedMoney - 85528) * 0.32);
                return firstLevel + secondLevel;
            }
        }
    }
}
