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
            else if (type == "personal second tax level")
            {
                return new PersonalTaxCalculatorLevelSecond();
            }
            else
            {
                return new LinearTaxCalculator();
            }
        }

        public static ITaxCalculator Create(CustomerType type)
        {
            if (type == CustomerType.Personal)
            {
                return new PersonalTaxCalculator();
            }
            else 
            {
                return new LinearTaxCalculator();
            }
           
            
        }

        public static ITaxCalculator Create(CustomerType type, List<Goods> goods)
        {
           
                return new TaxCalculatorWithSubstract(goods, type);
            
        }
    }
}
