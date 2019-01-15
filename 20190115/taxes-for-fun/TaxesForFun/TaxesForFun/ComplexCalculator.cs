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
            PersonalTaxCalculator personal = new PersonalTaxCalculator();
            return personal.CalculateTax(customer.Money);

        }

        public int ProcessCustomers(List<Customer> customers)
        {
            int sum = 0;

            foreach (var customer in customers)
            {
                if (customer.Type == CustomerType.Personal)
                {
                    PersonalTaxCalculator personal = new PersonalTaxCalculator();
                    sum += personal.CalculateTax(customer.Money);
                }
                else
                {
                    LinearTaxCalculator linearTaxCalculator = new LinearTaxCalculator();
                    sum += linearTaxCalculator.CalculateTax(customer.Money);
                }
            }
            return sum;
        }
    }
}
