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
            switch (type)
            {
                case "personal first tax level":
                    return new PersonalTaxCalculator();
                case "linear business":
                    return new LinearTaxCalculator();
            }

            throw new NotImplementedException("Implement me for happiness and joy!");
        }

        public static ITaxCalculator Create(CustomerType type)
        {
            switch (type)
            {
                case CustomerType.Personal:
                    return new PersonalTaxCalculator();
                case CustomerType.BusinessLinear:
                    return new LinearTaxCalculator();
            }

            throw new NotImplementedException("Implement me for happiness and joy!");
        }

        public static ITaxCalculator Create(CustomerType type, List<Goods> goods)
        {
            throw new NotImplementedException("Implement me for happiness and joy!");
        }
    }
}
