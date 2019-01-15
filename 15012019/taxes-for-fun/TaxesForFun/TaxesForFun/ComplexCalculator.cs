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
            return (int)((customer.Money - 8000) * 0.18);
        }

        public int ProcessCustomers(List<Customer> customers)
        {
            int tax = 0;

            for (int i = 0; i < customers.Count; i++)
            {
                ITaxCalculator calculator = TaxCalculatorFactory.Create(customers[i].Type);
                tax += calculator.CalculateTax(customers[i].Money);
            }

            return tax;
        }
    }
}
