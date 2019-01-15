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
                return new TotalPersonalTaxCalculator();
            }
            throw new NotImplementedException("Implement me for happiness and joy!");
        }

        public static ITaxCalculator Create(CustomerType type, List<Goods> goods)
        {
            if(type == CustomerType.BusinessLinear)
            {
                int result = 0;
                foreach (var item in goods)
                {
                    if(item.Value >= 10000)
                    {
                        result += (int)(item.Value * 0.25);
                        continue;
                    }
                    result += item.Value;
                }
                return new LinearTaxCalculator(result);
            }


            throw new NotImplementedException("Implement me for happiness and joy!");
        }
    }
}
