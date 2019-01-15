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
            PersonalTaxCalculator personalTaxCalculator = new PersonalTaxCalculator();
            return personalTaxCalculator.CalculateTax(customer.Money);
        }

        public int ProcessCustomers(List<Customer> customers)
        {
            int value = 0;
            PersonalTaxCalculator personalTaxCalculator = new PersonalTaxCalculator();
            LinearTaxCalculator linearTaxCalculator = new LinearTaxCalculator();
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Type == CustomerType.BusinessLinear)
                {
                    value += linearTaxCalculator.CalculateTax(customers[i].Money);
                }
                else
                {
                    value += personalTaxCalculator.CalculateTax(customers[i].Money);
                }
            }
            return value;
        }
    }
}
