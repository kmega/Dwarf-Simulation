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
            if (type == "personal second tax level")
            {
                return new PersonalTaxCalculator();
            }
            else
            {
                if (type == "linear business")
                {
                    return new LinearTaxCalculator(null);
                }
                else
                {
                    return new PersonalTaxCalculator();
                }
            }
        }

        public static ITaxCalculator Create(CustomerType type)
        {
            if (type == CustomerType.Personal)
            {
                return new TotalPersonalTaxCalculator();
            }
            else
            {
                return new LinearTaxCalculator(null);
            }            
        }

        public static ITaxCalculator Create(CustomerType type, List<Goods> goods)
        {
            if (type == CustomerType.BusinessLinear)
            {
                return new LinearTaxCalculator(goods);
            }
            else
            {
                return new PersonalTaxCalculator();
            }
        }
    }
}
