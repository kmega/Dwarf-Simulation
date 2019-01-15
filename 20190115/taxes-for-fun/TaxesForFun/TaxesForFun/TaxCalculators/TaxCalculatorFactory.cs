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
                case "personal second tax level":
                    return new PersonalSecondTaxCalculator();
            }

            throw new NotImplementedException("Implement me for happiness and joy!");
        }

        public static ITaxCalculator Create(CustomerType type)
        {
            switch (type)
            {
                case CustomerType.Personal:
                    return new TotalPersonalTaxCalculator();
                case CustomerType.BusinessLinear:
                    return new LinearTaxCalculator();
            }

            throw new NotImplementedException("Implement me for happiness and joy!");
        }

        public static ITaxCalculator Create(CustomerType type, List<Goods> goods)
        {
            int generatedCosts = 0;

            goods.ForEach(x =>
            {
                generatedCosts += x.Value;
            });

            return new LinearTaxCalculator(generatedCosts);

            //throw new NotImplementedException("Implement me for happiness and joy!");
        }
    }
}
