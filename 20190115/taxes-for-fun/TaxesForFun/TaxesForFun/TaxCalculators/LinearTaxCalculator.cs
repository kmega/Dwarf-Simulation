using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    public class LinearTaxCalculator : ITaxCalculator
    {
        public int costOfGeneratingTheProfits;
        public LinearTaxCalculator() { }
        public LinearTaxCalculator(int sum)
        {
            costOfGeneratingTheProfits = sum;
        }

        public int CalculateTax(int receivedMoney)
        {
            return (int)((receivedMoney-this.costOfGeneratingTheProfits) * 0.19);
        }
    }
}
