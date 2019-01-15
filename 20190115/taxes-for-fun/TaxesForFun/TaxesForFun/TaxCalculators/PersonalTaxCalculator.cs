using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    public class PersonalTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            if (receivedMoney < 85528)
            {
                double value = (receivedMoney - 8000) * 0.18;
                return (int)value;
            }
            else
            {
                double firstTaxLevelValue = (85528 - 8000)*0.18;
                double secondTaxLevelValue = (receivedMoney - 85528) * 0.32;
                return (int)firstTaxLevelValue + (int)secondTaxLevelValue;
            }


        }
    }
}
