using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    public class LinearTaxCalculator : ITaxCalculator
    {
        int goodValue = 0;
        public int CalculateTax(int receivedMoney)
        {
            return (int)((receivedMoney - goodValue) * 0.19);
        }
        public LinearTaxCalculator()
        {

        }
        public LinearTaxCalculator(int goodValue)
        {
            this.goodValue = goodValue;
        }
    }
}
