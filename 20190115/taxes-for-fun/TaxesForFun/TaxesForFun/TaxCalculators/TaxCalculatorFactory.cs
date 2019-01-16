using System;
using System.Collections.Generic;
using System.Text;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    public static class TaxCalculatorFactory
    {
        public static ITaxCalculator Create(string type)
        {
            throw new NotImplementedException("Implement me for happiness and joy!");
        }

        public static ITaxCalculator Create(CustomerType type)
        {
            throw new NotImplementedException("Implement me for happiness and joy!");
        }

        public static ITaxCalculator Create(CustomerType type, List<Goods> goods)
        {
            throw new NotImplementedException("Implement me for happiness and joy!");
        }
    }
}
