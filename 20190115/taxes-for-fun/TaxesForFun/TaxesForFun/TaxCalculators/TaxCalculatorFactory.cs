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
            if (type.Equals("personal first tax level"))
            {
                return new PersonalTaxCalculator();
            }
            else if (type.Equals("linear business"))
            {
                return new LinearTaxCalculator();
            }
            else if(type.Equals("personal second tax level"))
            {
                return new PersonalTaxCalculatorSecondStage();
            }
            else
            {
                return null;
            }
        }

        public static ITaxCalculator Create(CustomerType type)
        {
            if (type == CustomerType.Personal)
            {
                return new TotalPersonalTaxCalculator();
            }
            else return null;
        }

        public static ITaxCalculator Create(CustomerType type, List<Goods> goods)
        {
            return new LinearTaxCalculator(goods);
        }
    }
}
