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
            if (type == "personal first tax level") return new PersonalTaxCalculator();
            else if (type == "personal second tax level") return new PersonalSecondTaxCalculator();
            else if (type == "linear business") return new LinearTaxCalculator();
            else throw new NotImplementedException();

        }

        public static ITaxCalculator Create(CustomerType type)
        {
            if (type == CustomerType.Personal) return new PersonalTotalTaxCalculator();
            else throw new NotImplementedException();

        }

        public static ITaxCalculator Create(CustomerType type, List<Goods> goods)
        {
            if (type == CustomerType.BusinessLinear)
                return new BuisnessLinearTaxCalculator(goods);
            else
                throw new NotImplementedException();
        }
    }
}
