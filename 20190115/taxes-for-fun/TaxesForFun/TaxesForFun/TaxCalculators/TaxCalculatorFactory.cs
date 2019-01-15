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
            if(type.Equals("personal first tax level"))
                return new PersonalTaxCalculator();
            if (type.Equals("linear business"))
                return new LinearTaxCalculator();
            if (type.Equals("personal second tax level"))
                return new PersonalSecondTaxLevelCalculator();
            throw new NotImplementedException();
        }

        public static ITaxCalculator Create(CustomerType type)
        {
            if (type == CustomerType.Personal)
                return new TotalPersonalTaxCalculator();
            return null;
        }

        public static ITaxCalculator Create(CustomerType type, List<Goods> goods)
        {
            int totalValue = 0;
            foreach(Goods element in goods)
            {
                totalValue += element.Value;
            }
            return new LinearTaxCalculator(totalValue);
            
        }
    }
}
