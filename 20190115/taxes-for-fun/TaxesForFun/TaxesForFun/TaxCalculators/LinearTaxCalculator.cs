using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    public class LinearTaxCalculator : ITaxCalculator
    {
        int totalValue = 0;
        public LinearTaxCalculator() { }
        public LinearTaxCalculator(int totalValue)
        {
            this.totalValue = totalValue;
        }
        public int CalculateTax(int receivedMoney)
        {
            return (int)((receivedMoney - totalValue) * 0.19);
        }
    }
}
