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
            if(type == "personal first tax level")
            {
                return new PersonalTaxCalculator();
            }

            if (type == "linear business")
            {
                return new LinearTaxCalculator();
            }

            if (type == "personal second tax level")
            {
                return new SecondLevelTaxCalculator();
            }
            return null;
            //throw new NotImplementedException("Implement me for happiness and joy!");
        }

        public static ITaxCalculator Create(CustomerType type)
        {
            if(type == CustomerType.Personal)
            {
                return new PersonalTaxCalculator();
            }
            throw new NotImplementedException("Implement me for happiness and joy!");
        }

        public static ITaxCalculator Create(CustomerType type, List<Goods> goods)
        {
            throw new NotImplementedException("Implement me for happiness and joy!");
        }
    }
}
