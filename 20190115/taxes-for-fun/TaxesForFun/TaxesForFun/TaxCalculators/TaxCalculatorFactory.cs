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
                PersonalTaxCalculator taxcalculator = new PersonalTaxCalculator();
                return taxcalculator;
            }
            else if (type == "linear business")
            {
                LinearTaxCalculator taxcalculator = new LinearTaxCalculator();
                return taxcalculator;
            }
            else if (type == "personal second tax level")
            {
                PersonalLevel2 taxcalculator = new PersonalLevel2();
                return taxcalculator;
            }
            throw new Exception();
        }
           
        

        public static ITaxCalculator Create(CustomerType type)
        {
            int money = 20000;
            //Customer customer = new Customer();
            //if (customer.Money <= 20000)
            //{
            TotalPersonalTaxCalculator personal = new TotalPersonalTaxCalculator();
                //int owed = personal.CalculateTax(money);
                return personal;
            //}
            //else
            //{
            //    TotalPersonalTaxCalculator total = new TotalPersonalTaxCalculator();
            //    int owed = total.CalculateTax(customer.Money);
            //    return total;
            //}
        }


        public static ITaxCalculator Create(CustomerType type, List<Goods> goods)
        {
            throw new NotImplementedException("Implement me for happiness and joy!");
        }
    }
}
