using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    public class LinearTaxCalculator : ITaxCalculator
    {
        private int generatedCosts;

        public LinearTaxCalculator(){}

        public LinearTaxCalculator(int generatedCosts)
        {
            this.generatedCosts = generatedCosts;
        }

        public int CalculateTax(int receivedMoney)
        {
            //throw new NotImplementedException("Implement me for happiness and joy!");
            receivedMoney -= generatedCosts;
            return (int)(receivedMoney * 0.19);
        }
    }
}
