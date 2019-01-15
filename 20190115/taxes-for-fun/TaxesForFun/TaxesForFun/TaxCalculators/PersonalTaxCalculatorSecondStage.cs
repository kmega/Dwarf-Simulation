using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    public class PersonalTaxCalculatorSecondStage : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            return (int)(receivedMoney * 0.32);
        }
    }
}
