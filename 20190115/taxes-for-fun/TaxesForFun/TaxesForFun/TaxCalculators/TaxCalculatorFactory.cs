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
                PersonalTaxCalculator personalTaxCalculator = new PersonalTaxCalculator();
                return personalTaxCalculator;
            }
            else if (type == "linear business")
            {
                LinearTaxCalculator linearTaxCalculator = new LinearTaxCalculator();
                return linearTaxCalculator;
            }
            else if (type == "personal second tax level")
            {
                PersnoltaxAvboew85528 persnoltaxAvboew85528 = new PersnoltaxAvboew85528();
                return persnoltaxAvboew85528;
            }
            else
                return null;
        }

        public static ITaxCalculator Create(CustomerType type)
        {
            PersonalTaxCalculator personalTaxCalculator = new PersonalTaxCalculator();
            return personalTaxCalculator;
        }

        public static ITaxCalculator Create(CustomerType type, List<Goods> goods)
        {
            int sum = 0;
            foreach (var good in goods)
            {
                sum += good.Value;
            }
            LinearTaxCalculator linearTaxCalculator = new LinearTaxCalculator(sum);
            return linearTaxCalculator;
        }
    }
}
