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
            if (type == "linear business")
            {
                LinearTaxCalculator linearTaxCalculator = new LinearTaxCalculator();
                return linearTaxCalculator;
            }
            else if (type == "personal second tax level")
            {
                PersonalTaxCalculatorAbove85528 linearTaxCalculatorOver85528 = new PersonalTaxCalculatorAbove85528();
                return linearTaxCalculatorOver85528;
            }
            else
            {
                PersonalTaxCalculator personalTaxCalculator = new PersonalTaxCalculator();
                return personalTaxCalculator;
            }
        }

        public static ITaxCalculator Create(CustomerType type)
        {

            PersonalTaxCalculator personal = new PersonalTaxCalculator();
            return personal;


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
