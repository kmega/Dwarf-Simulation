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
            ITaxCalculator calculator = TaxCalculatorFactory.Create(customer.Type);
            return calculator.CalculateTax(customer.Money);
        }

        public int ProcessCustomers(List<Customer> customers)
        {
            int result = 0;   
            foreach (var customer in customers)
            {
                ITaxCalculator calculator = TaxCalculatorFactory.Create(customer.Type);
                result += calculator.CalculateTax(customer.Money);
            }

            return result;
        }
    }
}
