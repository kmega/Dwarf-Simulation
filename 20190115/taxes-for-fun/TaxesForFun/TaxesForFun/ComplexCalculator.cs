using System;
using System.Collections.Generic;
using System.Text;
using TaxesForFun.Business;
using TaxesForFun.TaxCalculators;

namespace TaxesForFun
{
    public class ComplexCalculator
    {
        public int ProcessCustomer(Customer customer)
        {
            if (customer.Type == CustomerType.Personal)
            {
                ITaxCalculator personalCalc = new PersonalTaxCalculator
                {
                    Type = "personal first tax level"
                };
                return personalCalc.CalculateTax(customer.Money);
            }
            else return 0;
        }

        public int ProcessCustomers(List<Customer> customers)
        {
            int sum = 0;
            foreach (var customer in customers)
            {
                if (customer.Type == CustomerType.Personal)
                {
                    ITaxCalculator personalCalc = new PersonalTaxCalculator
                    {
                        Type = "personal first tax level"
                    };
                    sum += personalCalc.CalculateTax(customer.Money);
                }
                else if (customer.Type == CustomerType.BusinessLinear)
                {
                    ITaxCalculator personalCalc = new LinearTaxCalculator()
                    {
                        Type = "linear business"
                    };
                    sum += personalCalc.CalculateTax(customer.Money);
                }
                else sum += 0;
            }

            return sum;
        }
    }
}
