using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    public class LinearTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            //throw new NotImplementedException("Implement me for happiness and joy!");
            return (int)(receivedMoney * 0.19);
        }
    }
}
