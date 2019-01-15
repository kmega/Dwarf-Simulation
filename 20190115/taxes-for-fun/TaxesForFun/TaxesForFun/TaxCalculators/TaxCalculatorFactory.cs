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
            if (type == "personal first tax level")
            {
                return new PersonalTaxCalculator();
            }

            if (type == "linear business")
            {
                return new LinearTaxCalculator();
            }

            if (type == "personal second tax level")
            {
                return new PersonalSecondTaskLevel();
            }
            return null;

        }

        public static ITaxCalculator Create(CustomerType type)
        {
            if (type == CustomerType.Personal)
            {
                return new TotalPersonalTaxCalculator();
            }
            if (type == CustomerType.BusinessLinear)
            {
                return new LinearTaxCalculator();
            }
            return new LinearTaxCalculator();
        }

        public static ITaxCalculator Create(CustomerType type, List<Goods> goods)
        {
            int sum = 0;
            foreach (var good in goods)
            {
                if (good.Value >= 10000)
                {
                    sum += (int)(good.Value * 0.25);
                }
                else
                {
                    sum += good.Value;
                }
                
            }

            return new LinearTaxCalculator(sum);
        }

    }
}
