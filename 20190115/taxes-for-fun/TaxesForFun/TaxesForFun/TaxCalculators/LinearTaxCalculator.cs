using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    public class LinearTaxCalculator : ITaxCalculator
    {
        private int result;

        public LinearTaxCalculator()
        {
            result = 0;
        }

        public LinearTaxCalculator(int result)
        {
            this.result = result;
        }


        public int CalculateTax(int receivedMoney)
        {
            return (int)((receivedMoney-result) * 0.19);
        }
    }
}
