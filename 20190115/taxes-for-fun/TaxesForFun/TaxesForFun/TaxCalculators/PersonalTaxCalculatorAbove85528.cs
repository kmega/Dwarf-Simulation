using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    class PersonalTaxCalculatorAbove85528 : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {

            double value = (receivedMoney) * 0.32;
            return (int)value;
        }
    }
}
